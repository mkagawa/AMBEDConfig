/*
AMBED Config

Copyright © 2018 Masahito Kagawa NW6UP

Permission is hereby granted, free of charge, to any person obtaining a copy 
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.    
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Diagnostics;
using System.Resources;
using System.Threading;
using System.Globalization;
using System.Net;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Collections;
using System.Xml.XPath;
//using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace AMBEDConfig
{
    enum ExeMode
    {
        AMBEDConfig,
        NoraGwConfig
    }

    public partial class AMBEDConfig : Form
    {
        private bool usbEnabled { get; set; }
        private ResourceManager resources { get; set; }
        private static String cwd = Directory.GetCurrentDirectory();
        private static String prodVersion = "";
        private static String defaultCountry = "";
        internal static ExeMode currentExeMode = ExeMode.AMBEDConfig; //default
        private static Regex callsignRegex = new Regex(@"^[0-9A-Z]{3,7}$");
        private String gatewayCallsign = "";
        private static Regex numDotRegEx = new Regex(@"^\d+\.[\d\.]+$");
        private String curIf = "";
        private Dictionary<string, _myObj> fileToRegEx = null;
        private Dictionary<String, Double> freqs = new Dictionary<String, Double>(); //freq
        private Double[] freqRange1 = null;
        private Double[] freqRange2 = null;

        enum ValidState
        {
            Invalid,
            ValidChanged,
            NoChange
        }
        class FieldValueTracker
        {
            public FieldValueTracker(String origValue)
            {
                this.OrigValue = origValue;
                this.ValidationResult = ValidState.NoChange;
            }
            //original value
            public String OrigValue { get; set; }
            public String CurValue
            {
                set
                {
                    if (value == null)
                    {
                        this.ValidationResult = ValidState.Invalid;
                    }
                    else if (value != this.OrigValue)
                    {

                        this.ValidationResult = ValidState.ValidChanged;
                    }
                    else
                    {
                        this.ValidationResult = ValidState.NoChange;
                    }
                }
            }
            public ValidState ValidationResult { get; set; }
        }

        private Dictionary<String, FieldValueTracker> _fieldsValues = new Dictionary<String, FieldValueTracker>();
        void setFieldValue(String name, String strValue)
        {
            if (!this._fieldsValues.ContainsKey(name))
            {
                this._fieldsValues[name] = new FieldValueTracker(strValue);
            }
            this._fieldsValues[name].CurValue = strValue;

            //Reflect state on OK button
            //enable if none of fields are invalid
            var isAnyInvalid = 
                this._fieldsValues.Count > 0 &&
                this._fieldsValues.Where(x => x.Value.ValidationResult == ValidState.Invalid).Count() > 0;
            var isAnyChange = 
                this._fieldsValues.Count > 0 &&
                this._fieldsValues.Where(x => x.Value.ValidationResult == ValidState.ValidChanged).Count() > 0;

            this.button_OK.Enabled = !isAnyInvalid && isAnyChange;
        }

        public AMBEDConfig(String[] args)
        {
            var fvi = FileVersionInfo.GetVersionInfo(typeof(AMBEDConfig).Assembly.Location);
            prodVersion = fvi.FileVersion; InitializeComponent();

            //Get current program name
            var exeInfo = new FileInfo(Application.ExecutablePath);
            var exeName = Path.GetFileName(exeInfo.Name);
            Debug.WriteLine(String.Format("Progran name = {0}", exeName));
            if (exeName.ToLower().Contains("nora") || args.Contains("-nora"))
            {
                currentExeMode = ExeMode.NoraGwConfig;
                this.label_ambePort.Visible = false;
                this.ambePort.Visible = false;
            }
            else
            {
                this.groupBox_noraGwConfig.Visible = false;
                this.tabControl1.Controls.Remove(this.tab_noraGwPage);
            }

            //Force English mode if exe file name includes .en.
            //i.e. AMBEDConfig.en.EXE
            CultureInfo _culture = null;
            if (exeName.ToLower().Contains(".en.") || args.Contains("-en"))
            {
                _culture = CultureInfo.GetCultureInfo("en-US");
            }

            var culture = ApplyCulture(_culture);
            var country = culture.Name.Split('-');
            if (country.Length == 2)
            {
                defaultCountry = country[1];
            }
            else
            {
                defaultCountry = country[0];
            }

            button_OK.Enabled = false;
            keyPhrase.PasswordChar = '\x25CF';
            for (int i = 0; i < sshPort.Items.Count; i++)
            {
                if (sshPort.Items[i].ToString() == "(Disabled)")
                {
                    sshPort.Items[i] = resources.GetString("text_sshDisabledValue");
                }
            }

            ///////////////////////////////////////////////////////////////
            //This hash dictionary defines read/write action for each file
            ///////////////////////////////////////////////////////////////
            fileToRegEx = new Dictionary<string, _myObj>() {
                {"sshd_config.txt",
                 new _myObj(false,
                    new String[] { @"^\s*(Port)\s+(\d+)\s*$" }, 
                    new ExeMode[] {ExeMode.AMBEDConfig,ExeMode.NoraGwConfig},
                    false, //isXml
                    (r,ctx) => { //read function
                        this.sshPort.Text = r.First().Value.Groups[2].Value;
                        if (this.sshPort.Text == "0")
                        {
                            this.sshPort.Text = this.resources.GetString("text_sshDisabledValue");
                      }
                    }, 
                    (r,line,ctx) => { //write function
                        var ret = line.Substring(0, r.Groups[2].Index);
                        if (this.sshPort.Text == this.resources.GetString("text_sshDisabledValue"))
                        {
                            ret += "0";
                        }
                        else
                        {
                            ret += this.sshPort.Text;
                        }
                        ret += line.Substring(r.Groups[2].Index + r.Groups[2].Value.Length);
                        if (line != ret) {
                            return ret;
                        }
                        return null; //no change for this line
                    })
                },
                {"NoraGateway.txt", //this is a XML file
                 new _myObj(true,
                    new String[] {@"\s<Gateway[\n\s]+.*?callsign=""([\w\s]+?)""[\n\s]"},
                    new ExeMode[] {ExeMode.NoraGwConfig},
                    true, //isXml
                    (r,ctx) => {
                        var outFile = @"NoraGateway.txt";
                        var cs = r.First().Value.Groups[1].Value;
                        if (!String.IsNullOrEmpty(cs)) { 
                            this.noraGwCallSign.Text = this.gatewayCallsign = cs.Substring(0, 7).Trim();
                        }

                        var xmlDoc = XElement.Load(outFile);

                        //Get Current Frequencies
                        foreach(var elemName in new String[] { 
                            "RxFrequency", "TxFrequency", "RxFrequencyOffset", "TxFrequencyOffset" }) {
                            foreach (var e in ((IEnumerable)xmlDoc.XPathEvaluate("//"+elemName)).Cast<XElement>())
                            {
                                this.freqs[elemName] = Double.Parse(e.Value);

                            }
                        }

                        this.rxFrequency.Text = string.Format("{0:F06}", this.freqs["RxFrequency"] / 1000 / 1000);
                        this.txFrequency.Text = string.Format("{0:F06}", this.freqs["TxFrequency"] / 1000 / 1000);
                        this.rxFrequencyOffset.Text = string.Format("{0}", this.freqs["RxFrequencyOffset"]);
                        this.txFrequencyOffset.Text = string.Format("{0}", this.freqs["TxFrequencyOffset"]);
                    },
                    (r,line,ctx) => {
                        //Write at once
                        var outFile = @"NoraGateway.txt";
                        var defaultFile = @"NoraGateway.xml.default";
                        if (!File.Exists(defaultFile))
                        {
                            defaultFile = outFile;
                        }
                        var fileFullName = Path.GetFullPath(cwd + @"\" + defaultFile);
                        outFile = Path.GetFullPath(cwd + @"\" + outFile);
                        var mtime1 = File.GetCreationTime(fileFullName);
                        var mtime2 = File.GetCreationTime(outFile);

                        //Load as XML File
                        var xmlDoc = XElement.Load(fileFullName, LoadOptions.PreserveWhitespace);

                        //(1) Replace all callsign attributes with current callsign
                        foreach (var e in ((IEnumerable)xmlDoc.XPathEvaluate("//*[@callsign]")).Cast<XElement>())
                        {
                            var el = e.Attribute("callsign");
                            if (el != null)
                            {
                                var suffix = el.Value.Substring(7, 1);
                                el.Value = String.Format("{0,-7}{1,1}", this.gatewayCallsign, suffix);
                            }
                        }

                        //(2) Replace Frequency
                        foreach (var e in ((IEnumerable)xmlDoc.XPathEvaluate("//RxFrequency")).Cast<XElement>())
                        {
                            e.Value = String.Format("{0}", this.freqs["RxFrequency"]);
                        }
                        foreach (var e in ((IEnumerable)xmlDoc.XPathEvaluate("//TxFrequency")).Cast<XElement>())
                        {
                            //Write same value as RxFreq in this version
                            e.Value = String.Format("{0}", this.freqs["RxFrequency"]);
                        }
                        foreach (var e in ((IEnumerable)xmlDoc.XPathEvaluate("//RxFrequencyOffset")).Cast<XElement>())
                        {
                            e.Value = String.Format("{0}", this.freqs["RxFrequencyOffset"]);
                        }
                        foreach (var e in ((IEnumerable)xmlDoc.XPathEvaluate("//TxFrequencyOffset")).Cast<XElement>())
                        {
                            e.Value = String.Format("{0}", this.freqs["TxFrequencyOffset"]);
                        }

                        xmlDoc.Save(outFile, SaveOptions.DisableFormatting);
                        return null;
                    })
                },
                {"AMBEDCMD.txt",
                 new _myObj(false,
                    new String[] {@"^(.*?)\s-p\s*(\d+)\s+.*$" },
                    new ExeMode[] {ExeMode.AMBEDConfig},
                    false, //isXml
                    (r,ctx) => {
                        this.sshPort.Text = r.First().Value.Groups[2].Value;
                    },
                    (r,line,ctx)=>{
                        var ret = line.Substring(0, r.Groups[2].Index);
                        ret += this.sshPort.Text;
                        ret += line.Substring(r.Groups[2].Index + r.Groups[2].Value.Length);
                        if (line != ret) { 
                            return ret;
                        }
                        return null; //no change for this line
                    })
                },
                {"wpa_supplicant.txt",
                  new _myObj(false, new String[] { 
                        "^\\s*(ssid|psk)=\"(.+?)\"\\s*$", 
                        "^\\s*(key_mgmt|country)=\"?(.+?)\"?\\s*$" },
                    new ExeMode[] {ExeMode.AMBEDConfig,ExeMode.NoraGwConfig},
                    false, //isXml
                    (r, ctx) => {
                        foreach (var mr in r)
                        {
                            var mx = mr.Value;
                            int lineNo = mr.Key;

                            var k = mx.Groups[1].Value;
                            var v = mx.Groups[2].Value;
                            if (k == "country")
                            {
                                this.countryCode.Text = v.ToUpper();
                            }
                            else if (k == "ssid")
                            {
                                this.ssid.Text = v;
                            }
                            else if (k == "psk")
                            {
                                this.keyPhrase.Text = v;
                            }
                            else if (k == "key_mgmt")
                            {
                                if (v == "WPA-PSK")
                                {
                                    v = "WPA-PSK/WPA2-PSK";
                                }
                                this.wifiType.Text = v;
                            }
                        }
                    }, 
                    (r, line, ctx) => { //write func
                        var ret = line.Substring(0, r.Groups[2].Index);
                        var k = r.Groups[1].Value;
                        if (k == "ssid") 
                        {
                            ret += this.ssid.Text;
                        }
                        else if (k == "country")
                        {
                            ret += this.countryCode.Text;
                        }
                        else if (k == "psk")
                        {
                            ret += this.keyPhrase.Text;
                        }
                        else if(k == "key_mgmt") 
                        {
                            var v = this.wifiType.Text;
                            if (v == "WPA-PSK/WPA2-PSK")
                            {
                                v = "WPA-PSK";
                            }
                            ret += v;
                        }
                        ret += line.Substring(r.Groups[2].Index + r.Groups[2].Value.Length);
                        if (line != ret) {
                            return ret;
                        }
                        return null; //no change for this line
                    })
                },
                {"dhcpcd.txt",
                 new _myObj(false, new String[] { 
                        "^\\s*static\\s+(ip_address|routers|domain_name_servers)=(.+?)\\s*$",
                        "^\\s*(_enabled) (\\d)\\s*$",
                        "^\\s*(interface) (\\w+)\\s*$" },
                    new ExeMode[] {ExeMode.AMBEDConfig,ExeMode.NoraGwConfig},
                    false, //isXml
                    (r, ctx) => {
                        this.curIf = "";
                        this.usbEnabled = true;
                        foreach (var mr in r)
                        {
                            var mx = mr.Value;
                            int lineNo = mr.Key;

                            var k = mx.Groups[1].Value;
                            var v = mx.Groups[2].Value;
                            if (k == "interface")
                            {
                                this.curIf = v;
                            }
                            //else if (k == "_enabled")
                            //{
                            //    ctx.usbEnabled = v == "1";
                            //}
                            else if (k == "ip_address")
                            {
                                var parts = v.Split('/');
                                var ipaddr = IPAddress.Parse(parts[0]);
                                var addrs = ipaddr.GetAddressBytes();
                                if (this.curIf == "wlan0")
                                {
                                    this.ipAddr1_1.Text = addrs[0].ToString();
                                    this.ipAddr1_2.Text = addrs[1].ToString();
                                    this.ipAddr1_3.Text = addrs[2].ToString();
                                    this.ipAddr1_4.Text = addrs[3].ToString();
                                    this.ipAddr1_5.Text = Int16.Parse(parts[1]).ToString();
                                }
                                else
                                {
                                    this.ipAddr3_1.Text = addrs[0].ToString();
                                    this.ipAddr3_2.Text = addrs[1].ToString();
                                    this.ipAddr3_3.Text = addrs[2].ToString();
                                    this.ipAddr3_4.Text = addrs[3].ToString();
                                    this.ipAddr3_5.Text = Int16.Parse(parts[1]).ToString();
                                }
                            }
                            else if (k == "routers")
                            {
                                var ipaddr = IPAddress.Parse(v);
                                var addrs = ipaddr.GetAddressBytes();
                                if (this.curIf == "wlan0")
                                {
                                    this.ipAddr2_1.Text = addrs[0].ToString();
                                    this.ipAddr2_2.Text = addrs[1].ToString();
                                    this.ipAddr2_3.Text = addrs[2].ToString();
                                    this.ipAddr2_4.Text = addrs[3].ToString();
                                }
                                else
                                {
                                    this.ipAddr4_1.Text = addrs[0].ToString();
                                    this.ipAddr4_2.Text = addrs[1].ToString();
                                    this.ipAddr4_3.Text = addrs[2].ToString();
                                    this.ipAddr4_4.Text = addrs[3].ToString();
                                }
                            }
                            else if (k == "domain_name_servers")
                            {
                                //Nothing to do
                            }
                        }
                    }, 
                    (r, line, ctx) => {
                        var ret = line.Substring(0, r.Groups[2].Index);
                        var k = r.Groups[1].Value;
                        var v = r.Groups[2].Value;
                        if (k == "_enabled")
                        {
                            ret += this.checkBox_useUSB.Checked ? "1" : "0";
                        }
                        else if (k == "interface")
                        {
                            this.curIf = v;
                            return null;
                        }
                        else if (k == "ip_address")
                        {
                            if (this.curIf == "wlan0")
                            {
                                ret += String.Format("{0}.{1}.{2}.{3}/{4}",
                                    this.ipAddr1_1.Text,
                                    this.ipAddr1_2.Text,
                                    this.ipAddr1_3.Text,
                                    this.ipAddr1_4.Text,
                                    this.ipAddr1_5.Text);
                            }
                            else
                            {
                                ret += String.Format("{0}.{1}.{2}.{3}/{4}",
                                    this.ipAddr3_1.Text,
                                    this.ipAddr3_2.Text,
                                    this.ipAddr3_3.Text,
                                    this.ipAddr3_4.Text,
                                    this.ipAddr3_5.Text);
                            }
                        }
                        else if (k == "routers")
                        {
                            if (this.curIf == "wlan0")
                            {
                                ret += String.Format("{0}.{1}.{2}.{3}",
                                    this.ipAddr2_1.Text,
                                    this.ipAddr2_2.Text,
                                    this.ipAddr2_3.Text,
                                    this.ipAddr2_4.Text);
                            }
                            else
                            {
                                ret += String.Format("{0}.{1}.{2}.{3}",
                                    this.ipAddr4_1.Text,
                                    this.ipAddr4_2.Text,
                                    this.ipAddr4_3.Text,
                                    this.ipAddr4_4.Text);
                            }
                        }
                        else if (k == "domain_name_servers")
                        {
                            //As same value as router
                            if (this.curIf == "wlan0")
                            {
                                ret += String.Format("{0}.{1}.{2}.{3}",
                                    this.ipAddr2_1.Text,
                                    this.ipAddr2_2.Text,
                                    this.ipAddr2_3.Text,
                                    this.ipAddr2_4.Text);
                            }
                            else
                            {
                                ret += String.Format("{0}.{1}.{2}.{3}",
                                    this.ipAddr4_1.Text,
                                    this.ipAddr4_2.Text,
                                    this.ipAddr4_3.Text,
                                    this.ipAddr4_4.Text);
                            }
                        }
                        ret += line.Substring(r.Groups[2].Index + r.Groups[2].Value.Length);
                        if (line != ret) {
                            return ret;
                        }
                        return null; //no change for this line
                    })
                }
            };
        }

        private CultureInfo ApplyCulture(CultureInfo culture)
        {
            if (culture != null)
            {
                // Applies culture to current Thread.
                Thread.CurrentThread.CurrentUICulture = culture;
            }
            else
            {
                culture = Thread.CurrentThread.CurrentUICulture;
            }

            var name = typeof(AMBEDConfig).Name + @".Properties.{0}.resources";
            var manifests = typeof(AMBEDConfig).Assembly.GetManifestResourceNames();
            var rscName = manifests.FirstOrDefault(nm => String.Format(name, culture.Name) == nm);
            if (rscName == null)
            {
                rscName = manifests.First(nm => nm.IndexOf("Properties.Resources.resources") > 0);
            }
            this.resources = new ResourceManager(rscName.Replace(".resources", ""), typeof(AMBEDConfig).Assembly);

            FieldInfo[] fieldInfos = this.GetType().GetFields(BindingFlags.Instance |
                BindingFlags.DeclaredOnly | BindingFlags.NonPublic);

            // Call SuspendLayout for Form and all fields derived from Control, so assignment of 
            // localized text doesn't change layout immediately.
            this.SuspendLayout();
            for (int index = 0; index < fieldInfos.Length; index++)
            {
                if (fieldInfos[index].FieldType.IsSubclassOf(typeof(Control)))
                {
                    fieldInfos[index].FieldType.InvokeMember("SuspendLayout",
                        BindingFlags.InvokeMethod, null,
                        fieldInfos[index].GetValue(this), null);
                }
            }

            // If available, assign localized text to Form and fields with Text property.
            var titleId = "";
            switch (currentExeMode)
            {
                case ExeMode.NoraGwConfig:
                    titleId = "programTitle_nora";
                    break;
                default:
                    titleId = "programTitle_default";
                    break;
            }
            String text = resources.GetString(titleId);
            if (text != null)
                this.Text = text;
            for (int index = 0; index < fieldInfos.Length; index++)
            {
                if (fieldInfos[index].FieldType.GetProperty("Text", typeof(String)) != null)
                {
                    text = resources.GetString(fieldInfos[index].Name);
                    if (text == null)
                    {
                        continue;
                    }
                    //Special handling...
                    if (fieldInfos[index].Name == "label_version")
                    {
                        text = String.Format(text, prodVersion);
                    }

                    if (text != null)
                    {
                        fieldInfos[index].FieldType.InvokeMember("Text",
                            BindingFlags.SetProperty, null,
                            fieldInfos[index].GetValue(this), new object[] { text });
                    }
                }
                if (fieldInfos[index].FieldType.GetProperty("Tag") != null)
                {
                    text = resources.GetString("tag_" + fieldInfos[index].Name);
                    if (text == null)
                    {
                        fieldInfos[index].FieldType.InvokeMember("Tag",
                            BindingFlags.SetProperty, null,
                            fieldInfos[index].GetValue(this), new object[] { text });
                    }
                }
            }

            // Call ResumeLayout for Form and all fields
            // derived from Control to resume layout logic.
            // Call PerformLayout, so layout changes due
            // to assignment of localized text are performed.
            for (int index = 0; index < fieldInfos.Length; index++)
            {
                if (fieldInfos[index].FieldType.IsSubclassOf(typeof(Control)))
                {
                    fieldInfos[index].FieldType.InvokeMember("ResumeLayout",
                            BindingFlags.InvokeMethod, null,
                            fieldInfos[index].GetValue(this), new object[] { false });
                }
            }
            this.ResumeLayout(false);
            this.PerformLayout();

            return culture;
        }

        /// <summary>
        /// Read AMBE server related configuration files
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private Dictionary<int, Match> readConfig(String fileName)
        {
            var mch = new Dictionary<int, Match>();
            var rex = fileToRegEx[fileName].regExs.Select(t => new Regex(t));
            var fileFullName = Path.GetFullPath(cwd + @"\" + fileName);
            var isMultiLine = fileToRegEx[fileName].isMultiLine;
            using (var _file = new StreamReader(fileFullName))
            {
                String line;
                var lines = new StringBuilder();
                int lineCnt = 0;
                while ((line = _file.ReadLine()) != null)
                {
                    if (isMultiLine)
                    {
                        lines.Append(line + "\n");
                    }
                    else
                    {
                        lineCnt++;
                        var m = rex.Select(rx =>
                        {
                            var mx = rx.Matches(line);
                            return mx.Count > 0 ? mx[0] : null;
                        });
                        if (m.Any(x => x != null))
                        {
                            mch[lineCnt] = m.First(x => x != null);
                        }
                    }
                }

                if (isMultiLine)
                {
                    lineCnt++;
                    var m = rex.Select(rx =>
                    {
                        var mx = rx.Matches(lines.ToString());
                        return mx.Count > 0 ? mx[0] : null;
                    });
                    if (m.Any(x => x != null))
                    {
                        mch[lineCnt] = m.First(x => x != null);
                    }
                }
            }
            return mch;
        }

        private void writeConfig(String fileName)
        {
            //var mch = new Dictionary<int, Match>();
            var rex = fileToRegEx[fileName].regExs.Select(t => new Regex(t));
            var rFileName = cwd + @"\" + fileName;
            if (fileToRegEx[fileName].isXml)
            {
                fileToRegEx[fileName].myWriteFunc(null, null, this);
            }
            else
            {
                int modCnt = 0;
                this.curIf = "";
                var tmpStream = new MemoryStream();
                using (TextWriter _wfile = new StreamWriter(tmpStream, Encoding.UTF8))
                {
                    _wfile.NewLine = "\n";
                    using (var _rfile = new StreamReader(rFileName))
                    {
                        String line;
                        while ((line = _rfile.ReadLine()) != null)
                        {
                            var m = rex.Select(rx =>
                            {
                                var mx = rx.Matches(line);
                                return mx.Count > 0 ? mx[0] : null;
                            });
                            if (m.Any(x => x != null))
                            {
                                var mch = m.First(x => x != null);
                                //Transform Line
                                var ret = fileToRegEx[fileName].myWriteFunc(mch, line, this);
                                if (ret != null)
                                {
                                    line = ret;
                                    modCnt++;
                                }
                            }
                            _wfile.WriteLine(line);
                        }
                    }
                    _wfile.Flush();

                    //any changes detected then overwrite original file
                    if (modCnt > 0)
                    {
                        const int chunkSize = 1024; // read the file by chunks of 1KB
                        tmpStream.Seek(0, SeekOrigin.Begin);
                        using (var _rfile2 = new StreamReader(tmpStream))
                        {
                            int bytesRead;
                            var buffer = new char[chunkSize];
                            using (var _wfile2 = new StreamWriter(rFileName))
                            {
                                while ((bytesRead = _rfile2.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    _wfile2.Write(buffer, 0, bytesRead);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void AMBEDConfig_Load(object sender, EventArgs e)
        {
            bool bError = false;
            foreach (var c in fileToRegEx)
            {
                try
                {
                    if (c.Value.isReadable)
                    {
                        c.Value.myReadFunc(readConfig(c.Key), this);
                    }
                }
                catch (Exception ex)
                {
                    bError = true;
                    MessageBox.Show(this, ex.Message, "Error");
                }
            }

            if (bError)
            {
                this.Close();
                return;
            }
            usbLanEnable(this.usbEnabled);
            this.checkBox_useUSB.Checked = this.usbEnabled;
            //this.AcceptButton = this.button_OK;
        }

        private void numberFld_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber = 0;
            if (e.KeyChar != '\b')
            {
                e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
            }
        }

        //Num + "-"
        private void numberFld3_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber = 0;
            if (e.KeyChar != '\b')
            {
                e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber) && e.KeyChar != '-';
            }
        }

        //Num + . floating
        private void numberFld2_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber = 0;
            if (e.KeyChar != '\b')
            {
                e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber) &&
                    e.KeyChar != '.';
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void validateRouterAddr(String fieldName, String[] elements, IPAddress addr, int subnet)
        {
            var rAddr = new IPAddress(elements.Select(e => Byte.Parse(e)).ToArray());
            var mask = (1 << subnet) - 1;
            //disable "depricated" error
#pragma warning disable 0618
            var net1 = rAddr.Address & mask;
            var net2 = addr.Address & mask;
            if (net1 != net2)
            {
                throw new IPAddrException("error_" + fieldName);
            }
        }

        private IPAddress validateIpAddr(String fieldName, String[] elements)
        {
            var _fieldName = resources.GetString(fieldName);
            var bytes = elements.Select(e => Byte.Parse(e)).Take(4).ToArray();
            if (bytes[0] >= 1 && bytes[0] <= 126)
            {
                //class A - subnet >= 8
                if (Byte.Parse(elements[4]) < 8)
                {
                    throw new IPAddrException("error_subnet8");
                }
            }
            else if (bytes[0] >= 128 && bytes[0] <= 191)
            {
                //class B - subnet >= 16
                if (Byte.Parse(elements[4]) < 16)
                {
                    throw new IPAddrException("error_subnet16");
                }
            }
            else if (bytes[0] >= 192 && bytes[0] <= 223)
            {
                //class C - subnet >= 24
                if (Byte.Parse(elements[4]) < 24)
                {
                    throw new IPAddrException("error_subnet24");
                }
            }
            return new IPAddress(bytes);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                var addr1 = validateIpAddr("ipAddr1", new String[] { ipAddr1_1.Text, ipAddr1_2.Text, ipAddr1_3.Text, ipAddr1_4.Text, ipAddr1_5.Text });
                validateRouterAddr("routerAddr2", new String[] { ipAddr2_1.Text, ipAddr2_2.Text, ipAddr2_3.Text, ipAddr2_4.Text }, addr1, Int16.Parse(ipAddr1_5.Text));

                var addr2 = validateIpAddr("ipAddr3", new String[] { ipAddr3_1.Text, ipAddr3_2.Text, ipAddr3_3.Text, ipAddr3_4.Text, ipAddr3_5.Text });
                validateRouterAddr("routerAddr4", new String[] { ipAddr4_1.Text, ipAddr4_2.Text, ipAddr4_3.Text, ipAddr4_4.Text }, addr2, Int16.Parse(ipAddr3_5.Text));

                if (addr1.Equals(addr2))
                {
                    throw new IPAddrException("error_cannotUseSameAddr");
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                if (msg.StartsWith("error_"))
                {
                    msg = resources.GetString(msg);
                }
                MessageBox.Show(this, msg, resources.GetString("label_error"));
                return;
            }

            foreach (var c in fileToRegEx)
            {
                try
                {
                    if (c.Value.isWriteable)
                    {
                        writeConfig(c.Key);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            this.Close();
        }

        private void numericField65536_TextChanged(object sender, EventArgs e)
        {
            checkNumbers((TextBox)sender, 65535);
        }

        private void numericField255_TextChanged(object sender, EventArgs e)
        {
            checkNumbers((TextBox)sender, 255);
        }

        private void numericField32_TextChanged(object sender, EventArgs e)
        {
            checkNumbers((TextBox)sender, 32);
        }

        private void checkNumbers(TextBox textBox, int maxNo)
        {
            var name = textBox.Name;
            try
            {
                var val = Int32.Parse(textBox.Text);
                // Convert the text to a Double and determine if it is a negative number.
                if (val < 0 || val > maxNo)
                {
                    // If the number is negative, display it in Red.
                    textBox.ForeColor = Color.Red;
                    this.setFieldValue(name, null);
                }
                else
                {
                    // If the number is not negative, display it in Black.
                    textBox.ForeColor = Color.Black;
                    //button_OK.Enabled = true;
                    this.setFieldValue(name, val.ToString());
                }
            }
            catch
            {
                // If there is an error, display the text using the system colors.
                textBox.ForeColor = SystemColors.ControlText;
                this.setFieldValue(name, null);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            usbLanEnable(this.checkBox_useUSB.Checked);
        }

        private void usbLanEnable(bool enabled)
        {
            this.ipAddr3_1.Enabled = enabled;
            this.ipAddr3_2.Enabled = enabled;
            this.ipAddr3_3.Enabled = enabled;
            this.ipAddr3_4.Enabled = enabled;
            this.ipAddr3_5.Enabled = enabled;
            this.ipAddr4_1.Enabled = enabled;
            this.ipAddr4_2.Enabled = enabled;
            this.ipAddr4_3.Enabled = enabled;
            this.ipAddr4_4.Enabled = enabled;
        }

        private void text_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Control ctrl = (Control)sender;
            Point mouseScreenPos = Control.MousePosition;
            Point mouseClientPos = ctrl.PointToClient(mouseScreenPos);
            Rectangle rect = ctrl.ClientRectangle;
            bool inside = rect.Contains(mouseClientPos);
            if (inside)
            {
                Help.ShowPopup(ctrl, (String)ctrl.Tag, mouseScreenPos);
            }
            else
            {
                Point ctrlClietnPos = new Point(ctrl.Size.Width / 2, ctrl.Size.Height);
                Point ctrlScreenPos = ctrl.PointToScreen(ctrlClietnPos);
                Help.ShowPopup(ctrl, (String)ctrl.Tag, ctrlScreenPos);
            }
        }

        private void AMBEDConfig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void labelAbout_Click(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            Point mouseScreenPos = Control.MousePosition;
            Point mouseClientPos = ctrl.PointToClient(mouseScreenPos);
            Rectangle rect = ctrl.ClientRectangle;


            String text = resources.GetString("text_aboutUs");
            Help.ShowPopup(ctrl, text, mouseScreenPos);
        }

        private void keyPhrase_ssid_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            var name = tb.Name;
            this.setFieldValue(name, String.IsNullOrEmpty(tb.Text) ? null : tb.Text);
        }

        private void countryCode_TextChanged(object sender, EventArgs e)
        {
            var ctl = ((TextBox)sender);
            ctl.Text = ctl.Text.ToUpper();
            var name = ((TextBox)sender).Name;
            //button_OK.Enabled = ctl.Text.Length > 0;
            this.setFieldValue(name, ctl.Text.Length > 0 ? ctl.Text : null);
        }

        //Double click to country field to fill country code from Windows settings
        private void countryCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).Text = defaultCountry;
        }

        private void textField_MouseHover(object sender, EventArgs e)
        {
            //Help tooltip
            var resId = String.Format("tip_{0}", ((Control)sender).Name);
            var text = resources.GetString(resId);
            if (!String.IsNullOrEmpty(text))
            {
                toolTip1.SetToolTip((Control)sender, text.Replace("\\n", "\n"));
            }
        }

        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            //Toggle password field
            this.keyPhrase.PasswordChar = (this.keyPhrase.PasswordChar == '\0') ? '\x25CF' : '\0';
        }

        private void noraGwCallSign_TextChanged(object sender, EventArgs e)
        {
            //TBD
            var tb = (TextBox)sender;
            if (!AMBEDConfig.callsignRegex.IsMatch(tb.Text))
            {
                this.setFieldValue(tb.Name, null);
                MessageBox.Show(this, "Callsign is invalid", resources.GetString("label_error"));
            }
            else
            {
                this.setFieldValue(tb.Name, tb.Text);
                this.gatewayCallsign = tb.Text;
            }
        }

        private void dhcpMode1_CheckedChanged(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;
            var notChecked = rb.Name.EndsWith("_1") ? rb.Checked : !rb.Checked;
            this.ipAddr1_1.Enabled = notChecked;
            this.ipAddr1_2.Enabled = notChecked;
            this.ipAddr1_3.Enabled = notChecked;
            this.ipAddr1_4.Enabled = notChecked;
            this.ipAddr1_5.Enabled = notChecked;
            this.ipAddr2_1.Enabled = notChecked;
            this.ipAddr2_2.Enabled = notChecked;
            this.ipAddr2_3.Enabled = notChecked;
            this.ipAddr2_4.Enabled = notChecked;
        }

        private void dhcpMode2_CheckedChanged(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;
            var notChecked = rb.Name.EndsWith("_1") ? rb.Checked : !rb.Checked;
            this.ipAddr3_1.Enabled = notChecked;
            this.ipAddr3_2.Enabled = notChecked;
            this.ipAddr3_3.Enabled = notChecked;
            this.ipAddr3_4.Enabled = notChecked;
            this.ipAddr3_5.Enabled = notChecked;
            this.ipAddr4_1.Enabled = notChecked;
            this.ipAddr4_2.Enabled = notChecked;
            this.ipAddr4_3.Enabled = notChecked;
            this.ipAddr4_4.Enabled = notChecked;
        }

        private void noraFreqTextBox_TextChanged(object sender, EventArgs e)
        {
            double freq;
            var tb = (TextBox)sender;
            var name = tb.Name[0].ToString().ToUpper() + tb.Name.Substring(1);
            var isValid = Double.TryParse(tb.Text, out freq);
            //Freq Range Check
            if (this.freqRange1 == null)
                this.freqRange1 = resources.GetString("text_freqRange1").Split(',').Select(x => Double.Parse(x)).ToArray();
            if (this.freqRange2 == null)
                this.freqRange2 = resources.GetString("text_freqRange2").Split(',').Select(x => Double.Parse(x)).ToArray();
            if (isValid &&
                ((freq > this.freqRange1[0] && freq < this.freqRange1[1]) ||
                 (freq > this.freqRange2[0] && freq < this.freqRange2[1]))
                )
            {
                this.setFieldValue(name, String.Format("{0:F06}", freq));
                this.freqs[name] = freq * 1000 * 1000;
                tb.ForeColor = Color.Black;
            }
            else
            {
                //tb.Text = String.Format("{0:F06}", this.freqs[name] / 1000 / 1000);
                this.setFieldValue(name, null);
                tb.ForeColor = Color.Red;
            }
        }

        private void noraFreqTextBox_FocusLeft(object sender, EventArgs e)
        {
            double freq;
            var tb = (TextBox)sender;
            var name = tb.Name[0].ToString().ToUpper() + tb.Name.Substring(1);
            var isValid = Double.TryParse(tb.Text, out freq);
            tb.Text = String.Format("{0:F06}", freq);
        }

        private void noraFreqOffset_TextChanged(object sender, EventArgs e)
        {
            double freq;
            var tb = (TextBox)sender;
            var name = tb.Name[0].ToString().ToUpper() + tb.Name.Substring(1);
            var isValid = Double.TryParse(tb.Text, out freq);
            tb.Text = String.Format("{0:F0}", freq);
            //Ofset range -5000 to +5000
            if (Math.Abs(freq) < 5000)
            {
                this.setFieldValue(name, String.Format("{0:F0}", freq));
                this.freqs[name] = freq;
                tb.ForeColor = Color.Black;
            }
            else
            {
                //tb.Text = String.Format("{0:F06}", this.freqs[name] / 1000 / 1000);
                this.setFieldValue(name, null);
                tb.ForeColor = Color.Red;
            }
            this.setFieldValue(name, isValid ? tb.Text : null);
        }
    }

    //Helper class
    internal class _myObj
    {
        public _myObj(bool isMultiLine, String[] rex, 
            ExeMode[] modesToApply, bool isXml,
            Action<Dictionary<int, Match>, AMBEDConfig> readFunc,
            Func<Match, String, AMBEDConfig, String> writeFunc)
        {
            this.isReadable = modesToApply.Contains(AMBEDConfig.currentExeMode);
            this.isWriteable = modesToApply.Contains(AMBEDConfig.currentExeMode);
            this.regExs = rex;
            this.isXml = isXml;
            this.myReadFunc = readFunc;
            this.myWriteFunc = writeFunc;
            this.isMultiLine = isMultiLine;
        }
        public bool isReadable;
        public bool isWriteable;
        public bool isMultiLine { get; set; }
        public bool isXml { get; set; }
        public String[] regExs { get; set; }
        public Action<Dictionary<int, Match>, AMBEDConfig> myReadFunc { get; set; }
        public Func<Match, String, AMBEDConfig, String> myWriteFunc { get; set; }
    }

    //Internal Exception
    internal class IPAddrException : Exception
    {
        public IPAddrException(String msg)
            : base(msg)
        {

        }
    }
}