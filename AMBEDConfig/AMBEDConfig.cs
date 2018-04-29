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
        private int sshPortNo { get; set; }
        private int ambePortNo { get; set; }
        private bool usbEnabled { get; set; }

        public AMBEDConfig()
        {
            InitializeComponent();
            var cl = new CultureInfo("ja-JP");





            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(GroupBox))
                {
                    foreach (Control cc in c.Controls)
                    {
                        if (cc.GetType() == typeof(Label))
                        {
                            //resource.ApplyResources(cc, cc.Name, c);
                            Console.WriteLine(" > Name: " + cc.Name);
                        }
                    }
                }
                else
                {
                    //resource.ApplyResources(c, c.Name, originalCulture);
                    Console.WriteLine(" Name: " + c.Name);
                }

            }
            /*
            if(manifest )
            {
                string manifest = manifests[0].Replace(".resources", string.Empty);
            }
             */

            // Works !
            //manager.GetString("PleaseCallIT", null);

            //Language resource handling
            //var resource = new ResourceManager("Resources.Res", typeof(AMBEDConfig).Assembly); 
            //new ComponentResourceManager(typeof(AMBEDConfig));
            //ResourceSet resourceSet = resource.GetResourceSet(CultureInfo.CurrentUICulture, true, true);



            ApplyCulture(cl);
        }

        private void ApplyCulture(CultureInfo culture)
        {
            // Applies culture to current Thread.
            Thread.CurrentThread.CurrentUICulture = culture;

            var name = typeof(AMBEDConfig).Name + @".Resources.{0}.resources";
            var manifests = typeof(AMBEDConfig).Assembly.GetManifestResourceNames();
            var rscName = manifests.FirstOrDefault(nm => String.Format(name, culture.Name) == nm);
            if (rscName == null)
            {
                rscName = manifests.First(nm => String.Format(name, "en") == nm);
            }
            var resources = new ResourceManager(rscName.Replace(".resources",""), typeof(AMBEDConfig).Assembly);

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
        private Match[] readConfig(String fileName)
        {
            var mch = new List<Match>();
            var cwd = Directory.GetCurrentDirectory();
            var rex = fileToRegEx[fileName].regExs.Select(t => new Regex(t));
            using (var sshFile = new StreamReader(cwd + @"\" + fileName))
            {
                String line;
                while ((line = sshFile.ReadLine()) != null)
                {
                    var m = rex.Select(rx =>
                    {
                        var mx = rx.Matches(line);
                        return mx.Count > 0 ? mx[0] : null;
                    });
                    if (m.Any(x => x != null))
                    {
                        mch.Add(m.First(x => x != null));
                        //System.Console.WriteLine(sshPortNo);
                    }
                }
            }
            return mch.ToArray();
        }

        private void writeConfig(String fileName, Dictionary<String, String> valuePairs, String[] regEx)
        {
            var r = readConfig(fileName);
        }

        class _myObj
        {
            public _myObj(String[] rex, Action<Match[], AMBEDConfig> func)
            {
                this.regExs = rex;
                this.myFunc = func;
            }
            public String[] regExs { get; set; }
            public Action<Match[], AMBEDConfig> myFunc { get; set; }
        }

        Dictionary<String, _myObj> fileToRegEx = new Dictionary<string, _myObj>() {
            {"sshd_config.txt", new _myObj(new String[] { @"^\s*Port\s+(\d+)\s*$" },(r,ctx)=>{
                ctx.sshPortNo = Int32.Parse(r[0].Groups[1].Value);
                ctx.sshPort.Text = ctx.sshPortNo.ToString();
            })},
            {"AMBEDCMD.txt", new _myObj(new String[] { @"^.*?\s-p\s*(\d+)\s+.*$" }, (r,ctx)=>{
                ctx.ambePortNo = Int32.Parse(r[0].Groups[1].Value);
                ctx.ambePort.Text = ctx.ambePortNo.ToString();
            })},
            {"wpa_supplicant.txt", new _myObj(new String[] { 
                    "^\\s*(ssid|psk)=\"(.+?)\"\\s*$", "^\\s*(key_mgmt)=\"?(.+?)\"?\\s*$"
            }, (r,ctx)=>{
                foreach (var mx in r)
                {
                    var k = mx.Groups[1].Value;
                    var v = mx.Groups[2].Value;
                    if (k == "ssid")
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
            })},
            {"dhcpcd.txt", new _myObj(new String[] { 
                    "^\\s*static\\s+(ip_address|routers|domain_name_servers)=(.+?)\\s*$",
                    "^\\s*(_enabled) (\\d)\\s*$",
                    "^\\s*(interface) (\\w+)\\s*$"
                }, (r, ctx)=>{
                var curIf = "";
                foreach (var mx in r)
                {
                    var k = mx.Groups[1].Value;
                    var v = mx.Groups[2].Value;
                    if (k == "_enabled")
                    {
                        ctx.usbEnabled = v == "1";
                    }
                    else if (k == "interface")
                    {
                        curIf = v;
                    }
                    else if (k == "ip_address")
                    {
                        var parts = v.Split('/');
                        var ipaddr = IPAddress.Parse(parts[0]);
                        var addrs = ipaddr.GetAddressBytes();
                        if (curIf == "wlan0")
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
                        if (curIf == "wlan0")
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
                        //this.wifiType.Text = v;
                    }
                }
            })}
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            //var rm = new resourcemanager("ambedconfig.resources-ja-jp", typeof(ambedconfig).assembly);
            //string greeting = string.format("the current culture is {0}.\n{1}",
            //                                thread.currentthread.currentuiculture.name,
            //                                rm.getstring("label30"));
            //var assembly = typeof(AMBEDConfig).Assembly;
            //foreach (var resourceName in assembly.GetManifestResourceNames())
            //    System.Console.WriteLine(resourceName);
            //foreach (var resourceName in assembly.GetManifestResourceNames())
            //{
            //    using (var stream = assembly.GetManifestResourceStream(resourceName))
            //    {
            //        // Do something with stream
            //    }
            //}

            foreach (var c in fileToRegEx)
            {
                try
                {
                    c.Value.myFunc(readConfig(c.Key), this);
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

        private void buttonOK_Click(object sender, EventArgs e)
        {

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
                Help.ShowPopup(ctrl, ctrl.Tag.ToString(), mouseScreenPos);
            }
            else
            {
                Point ctrlClietnPos = new Point(ctrl.Size.Width / 2, ctrl.Size.Height);
                Point ctrlScreenPos = ctrl.PointToScreen(ctrlClietnPos);
                Help.ShowPopup(ctrl, ctrl.Tag.ToString(), ctrlScreenPos);
            }
        }

        private void AMBEDConfig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}