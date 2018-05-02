using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Globalization;
using System.Net;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace AMBEDConfig
{
    public partial class AMBEDConfig : Form
    {
        //private int sshPortNo { get; set; }
        //private int ambePortNo { get; set; }
        private bool usbEnabled { get; set; }
        private ResourceManager resources { get; set; }
        private static String cwd = Directory.GetCurrentDirectory();

        class _myObj
        {
            public _myObj(String[] rex,
                Action<Dictionary<int, Match>, AMBEDConfig> readFunc,
                Func<Match, String, AMBEDConfig, String> writeFunc)
            {
                regExs = rex;
                myReadFunc = readFunc;
                myWriteFunc = writeFunc;
            }
            public String[] regExs { get; set; }
            public Action<Dictionary<int, Match>, AMBEDConfig> myReadFunc { get; set; }
            public Func<Match, String, AMBEDConfig, String> myWriteFunc { get; set; }
        }

        class IPAddrException : Exception
        {
            public IPAddrException(String msg)
                : base(msg)
            {

            }
        }

        public AMBEDConfig()
        {
            InitializeComponent();
            ApplyCulture(null);
        }

        private void ApplyCulture(CultureInfo culture)
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

            var name = typeof(AMBEDConfig).Name + @".Resources.{0}.resources";
            var manifests = typeof(AMBEDConfig).Assembly.GetManifestResourceNames();
            var rscName = manifests.FirstOrDefault(nm => String.Format(name, culture.Name) == nm);
            if (rscName == null)
            {
                rscName = manifests.First(nm => String.Format(name, "en") == nm);
            }
            this.resources = new ResourceManager(rscName.Replace(".resources", ""), typeof(AMBEDConfig).Assembly);

            // Create a resource manager for this Form
            // and determine its fields via reflection.
            //var resources = new ComponentResourceManager(this.GetType());

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
            String text = resources.GetString("programTitle");
            if (text != null)
                this.Text = text;
            for (int index = 0; index < fieldInfos.Length; index++)
            {
                if (fieldInfos[index].FieldType.GetProperty("Text", typeof(String)) != null)
                {
                    text = resources.GetString(fieldInfos[index].Name);
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
            using (var _file = new StreamReader(cwd + @"\" + fileName))
            {
                String line;
                int lineCnt = 0;
                while ((line = _file.ReadLine()) != null)
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
            return mch;
        }

        private void writeConfig(String fileName)
        {
            //var mch = new Dictionary<int, Match>();
            var rex = fileToRegEx[fileName].regExs.Select(t => new Regex(t));
            var rFileName = cwd + @"\" + fileName;
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

        String curIf = "";
        Dictionary<String, _myObj> fileToRegEx = new Dictionary<string, _myObj>() {
            {"sshd_config.txt",
                new _myObj(new String[] { @"^\s*(Port)\s+(\d+)\s*$" }, (r,ctx) => { //read function
                    ctx.sshPort.Text = r.First().Value.Groups[2].Value;
            }, (r,line,ctx) => { //write function
                var ret = line.Substring(0, r.Groups[2].Index);
                ret += ctx.sshPort.Text;
                ret += line.Substring(r.Groups[2].Index + r.Groups[2].Value.Length);
                if (line != ret) { 
                    return ret;
                }
                return null; //no change for this line
            })},
            {"AMBEDCMD.txt",
                new _myObj(new String[] {
                    @"^(.*?)\s-p\s*(\d+)\s+.*$" },
                (r,ctx) => {
                    ctx.ambePort.Text = r.First().Value.Groups[2].Value;
            },(r,line,ctx)=>{
                var ret = line.Substring(0, r.Groups[2].Index);
                ret += ctx.ambePort.Text;
                ret += line.Substring(r.Groups[2].Index + r.Groups[2].Value.Length);
                if (line != ret) { 
                    return ret;
                }
                return null; //no change for this line
            })},
            {"wpa_supplicant.txt",
                new _myObj(new String[] { 
                    "^\\s*(ssid|psk)=\"(.+?)\"\\s*$", 
                    "^\\s*(key_mgmt|country)=\"?(.+?)\"?\\s*$" },
                (r, ctx) => {
                foreach (var mr in r)
                {
                    var mx = mr.Value;
                    int lineNo = mr.Key;

                    var k = mx.Groups[1].Value;
                    var v = mx.Groups[2].Value;
                    if (k == "country")
                    {
                        ctx.countryCode.Text = v.ToUpper();
                    }
                    else if (k == "ssid")
                    {
                        ctx.ssid.Text = v;
                    }
                    else if (k == "psk")
                    {
                        ctx.keyPhrase.Text = v;
                    }
                    else if (k == "key_mgmt")
                    {
                        ctx.wifiType.Text = v;
                    }
                }
            }, (r, line, ctx) => { //write func
                var ret = line.Substring(0, r.Groups[2].Index);
                var k = r.Groups[1].Value;
                if (k == "ssid") 
                {
                    ret += ctx.ssid.Text;
                }
                else if (k == "country")
                {
                    ret += ctx.countryCode.Text;
                }
                else if (k == "psk")
                {
                    ret += ctx.keyPhrase.Text;
                }
                else if(k == "key_mgmt") 
                {
                    ret += ctx.wifiType.Text;
                }
                ret += line.Substring(r.Groups[2].Index + r.Groups[2].Value.Length);
                if (line != ret) {
                    return ret;
                }
                return null; //no change for this line
            })},
            {"dhcpcd.txt", new _myObj(new String[] { 
                    "^\\s*static\\s+(ip_address|routers|domain_name_servers)=(.+?)\\s*$",
                    "^\\s*(_enabled) (\\d)\\s*$",
                    "^\\s*(interface) (\\w+)\\s*$" },
                (r, ctx) => {
                ctx.curIf = "";
                ctx.usbEnabled = true;
                foreach (var mr in r)
                {
                    var mx = mr.Value;
                    int lineNo = mr.Key;

                    var k = mx.Groups[1].Value;
                    var v = mx.Groups[2].Value;
                    if (k == "interface")
                    {
                        ctx.curIf = v;
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
                        if (ctx.curIf == "wlan0")
                        {
                            ctx.ipAddr1_1.Text = addrs[0].ToString();
                            ctx.ipAddr1_2.Text = addrs[1].ToString();
                            ctx.ipAddr1_3.Text = addrs[2].ToString();
                            ctx.ipAddr1_4.Text = addrs[3].ToString();
                            ctx.ipAddr1_5.Text = Int16.Parse(parts[1]).ToString();
                        }
                        else
                        {
                            ctx.ipAddr3_1.Text = addrs[0].ToString();
                            ctx.ipAddr3_2.Text = addrs[1].ToString();
                            ctx.ipAddr3_3.Text = addrs[2].ToString();
                            ctx.ipAddr3_4.Text = addrs[3].ToString();
                            ctx.ipAddr3_5.Text = Int16.Parse(parts[1]).ToString();
                        }
                    }
                    else if (k == "routers")
                    {
                        var ipaddr = IPAddress.Parse(v);
                        var addrs = ipaddr.GetAddressBytes();
                        if (ctx.curIf == "wlan0")
                        {
                            ctx.ipAddr2_1.Text = addrs[0].ToString();
                            ctx.ipAddr2_2.Text = addrs[1].ToString();
                            ctx.ipAddr2_3.Text = addrs[2].ToString();
                            ctx.ipAddr2_4.Text = addrs[3].ToString();
                        }
                        else
                        {
                            ctx.ipAddr4_1.Text = addrs[0].ToString();
                            ctx.ipAddr4_2.Text = addrs[1].ToString();
                            ctx.ipAddr4_3.Text = addrs[2].ToString();
                            ctx.ipAddr4_4.Text = addrs[3].ToString();
                        }
                    }
                    else if (k == "domain_name_servers")
                    {
                        //Nothing to do
                    }
                }
            }, (r, line, ctx) => {
                var ret = line.Substring(0, r.Groups[2].Index);
                var k = r.Groups[1].Value;
                var v = r.Groups[2].Value;
                if (k == "_enabled")
                {
                    ret += ctx.checkBox_useUSB.Checked ? "1" : "0";
                }
                else if (k == "interface")
                {
                    ctx.curIf = v;
                    return null;
                }
                else if (k == "ip_address")
                {
                    if (ctx.curIf == "wlan0")
                    {
                        ret += String.Format("{0}.{1}.{2}.{3}/{4}",
                            ctx.ipAddr1_1.Text,
                            ctx.ipAddr1_2.Text,
                            ctx.ipAddr1_3.Text,
                            ctx.ipAddr1_4.Text,
                            ctx.ipAddr1_5.Text);
                    }
                    else
                    {
                        ret += String.Format("{0}.{1}.{2}.{3}/{4}",
                            ctx.ipAddr3_1.Text,
                            ctx.ipAddr3_2.Text,
                            ctx.ipAddr3_3.Text,
                            ctx.ipAddr3_4.Text,
                            ctx.ipAddr3_5.Text);
                    }
                }
                else if (k == "routers")
                {
                    if (ctx.curIf == "wlan0")
                    {
                        ret += String.Format("{0}.{1}.{2}.{3}",
                            ctx.ipAddr2_1.Text,
                            ctx.ipAddr2_2.Text,
                            ctx.ipAddr2_3.Text,
                            ctx.ipAddr2_4.Text);
                    }
                    else
                    {
                        ret += String.Format("{0}.{1}.{2}.{3}",
                            ctx.ipAddr4_1.Text,
                            ctx.ipAddr4_2.Text,
                            ctx.ipAddr4_3.Text,
                            ctx.ipAddr4_4.Text);
                    }
                }
                else if (k == "domain_name_servers")
                {
                    //As same value as router
                    if (ctx.curIf == "wlan0")
                    {
                        ret += String.Format("{0}.{1}.{2}.{3}",
                            ctx.ipAddr2_1.Text,
                            ctx.ipAddr2_2.Text,
                            ctx.ipAddr2_3.Text,
                            ctx.ipAddr2_4.Text);
                    }
                    else
                    {
                        ret += String.Format("{0}.{1}.{2}.{3}",
                            ctx.ipAddr4_1.Text,
                            ctx.ipAddr4_2.Text,
                            ctx.ipAddr4_3.Text,
                            ctx.ipAddr4_4.Text);
                    }
                }
                ret += line.Substring(r.Groups[2].Index + r.Groups[2].Value.Length);
                if (line != ret) {
                    return ret;
                }
                return null; //no change for this line
            })}
        };

        private void AMBEDConfig_Load(object sender, EventArgs e)
        {
            foreach (var c in fileToRegEx)
            {
                try
                {
                    c.Value.myReadFunc(readConfig(c.Key), this);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            usbLanEnable(this.usbEnabled);
            this.checkBox_useUSB.Checked = this.usbEnabled;
            this.AcceptButton = this.buttonOK;
        }

        private void numberFld_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber = 0;
            if (e.KeyChar != '\b')
            {
                e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
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
            var net1 = rAddr.Address & mask;
            var net2 = addr.Address & mask;
            if (net1 != net2)
            {
                throw new IPAddrException(resources.GetString("error_" + fieldName));
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
                    throw new IPAddrException(resources.GetString("error_subnet8"));
                }
            }
            else if (bytes[0] >= 128 && bytes[0] <= 191)
            {
                //class B - subnet >= 16
                if (Byte.Parse(elements[4]) < 16)
                {
                    throw new IPAddrException(resources.GetString("error_subnet16"));
                }
            }
            else if (bytes[0] >= 192 && bytes[0] <= 223)
            {
                //class C - subnet >= 24
                if (Byte.Parse(elements[4]) < 24)
                {
                    throw new IPAddrException(resources.GetString("error_subnet24"));
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
            }
            catch (IPAddrException ex)
            {
                var result = MessageBox.Show(this, ex.Message, "Error");
                return;
            }

            foreach (var c in fileToRegEx)
            {
                try
                {
                    writeConfig(c.Key);
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
            chechNumbers((TextBox)sender, 65535);
        }

        private void numericField255_TextChanged(object sender, EventArgs e)
        {
            chechNumbers((TextBox)sender, 255);
        }

        private void numericField32_TextChanged(object sender, EventArgs e)
        {
            chechNumbers((TextBox)sender, 32);
        }

        private void chechNumbers(TextBox currencyTextBox, int maxNo)
        {
            try
            {
                var val = Int32.Parse(currencyTextBox.Text);
                // Convert the text to a Double and determine if it is a negative number.
                if (val < 0 || val > maxNo)
                {
                    // If the number is negative, display it in Red.
                    currencyTextBox.ForeColor = Color.Red;
                }
                else
                {
                    // If the number is not negative, display it in Black.
                    currencyTextBox.ForeColor = Color.Black;
                }
            }
            catch
            {
                // If there is an error, display the text using the system colors.
                currencyTextBox.ForeColor = SystemColors.ControlText;
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
            Help.ShowPopup(ctrl, "Copyright (c) 2018 by XRFリフレクタ同好会\n\nTest\n", mouseScreenPos);
        }
    }
}