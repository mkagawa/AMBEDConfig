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
namespace AMBEDConfig
{
    using System.Threading;
    using System.Windows.Forms;

    partial class AMBEDConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AMBEDConfig));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.countryCode = new System.Windows.Forms.TextBox();
            this.label_countryCode = new System.Windows.Forms.Label();
            this.label_wifiType = new System.Windows.Forms.Label();
            this.wifiType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ipAddr2_4 = new System.Windows.Forms.TextBox();
            this.ipAddr2_3 = new System.Windows.Forms.TextBox();
            this.ipAddr2_2 = new System.Windows.Forms.TextBox();
            this.ipAddr2_1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ipAddr1_5 = new System.Windows.Forms.TextBox();
            this.ipAddr1_4 = new System.Windows.Forms.TextBox();
            this.ipAddr1_3 = new System.Windows.Forms.TextBox();
            this.ipAddr1_2 = new System.Windows.Forms.TextBox();
            this.ipAddr1_1 = new System.Windows.Forms.TextBox();
            this.keyPhrase = new System.Windows.Forms.TextBox();
            this.ssid = new System.Windows.Forms.TextBox();
            this.label_routerAddr2 = new System.Windows.Forms.Label();
            this.label_ipAddr1 = new System.Windows.Forms.Label();
            this.label_keyPhrase = new System.Windows.Forms.Label();
            this.label_ssid = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_useUSB = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.ipAddr4_4 = new System.Windows.Forms.TextBox();
            this.ipAddr4_3 = new System.Windows.Forms.TextBox();
            this.ipAddr4_2 = new System.Windows.Forms.TextBox();
            this.ipAddr4_1 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.ipAddr3_5 = new System.Windows.Forms.TextBox();
            this.ipAddr3_4 = new System.Windows.Forms.TextBox();
            this.ipAddr3_3 = new System.Windows.Forms.TextBox();
            this.ipAddr3_2 = new System.Windows.Forms.TextBox();
            this.ipAddr3_1 = new System.Windows.Forms.TextBox();
            this.label_routerAddr4 = new System.Windows.Forms.Label();
            this.label_ipAddr3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ambePort = new System.Windows.Forms.TextBox();
            this.sshPort = new System.Windows.Forms.TextBox();
            this.label_ambePort = new System.Windows.Forms.Label();
            this.label_sshPort = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labe_about = new System.Windows.Forms.Label();
            this.label_prodName = new System.Windows.Forms.Label();
            this.label_version = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.countryCode);
            this.groupBox1.Controls.Add(this.label_countryCode);
            this.groupBox1.Controls.Add(this.label_wifiType);
            this.groupBox1.Controls.Add(this.wifiType);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.ipAddr2_4);
            this.groupBox1.Controls.Add(this.ipAddr2_3);
            this.groupBox1.Controls.Add(this.ipAddr2_2);
            this.groupBox1.Controls.Add(this.ipAddr2_1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ipAddr1_5);
            this.groupBox1.Controls.Add(this.ipAddr1_4);
            this.groupBox1.Controls.Add(this.ipAddr1_3);
            this.groupBox1.Controls.Add(this.ipAddr1_2);
            this.groupBox1.Controls.Add(this.ipAddr1_1);
            this.groupBox1.Controls.Add(this.keyPhrase);
            this.groupBox1.Controls.Add(this.ssid);
            this.groupBox1.Controls.Add(this.label_routerAddr2);
            this.groupBox1.Controls.Add(this.label_ipAddr1);
            this.groupBox1.Controls.Add(this.label_keyPhrase);
            this.groupBox1.Controls.Add(this.label_ssid);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // countryCode
            // 
            resources.ApplyResources(this.countryCode, "countryCode");
            this.countryCode.Name = "countryCode";
            // 
            // label_countryCode
            // 
            resources.ApplyResources(this.label_countryCode, "label_countryCode");
            this.label_countryCode.Name = "label_countryCode";
            // 
            // label_wifiType
            // 
            resources.ApplyResources(this.label_wifiType, "label_wifiType");
            this.label_wifiType.Name = "label_wifiType";
            // 
            // wifiType
            // 
            this.wifiType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wifiType.FormattingEnabled = true;
            this.wifiType.Items.AddRange(new object[] {
            resources.GetString("wifiType.Items"),
            resources.GetString("wifiType.Items1"),
            resources.GetString("wifiType.Items2"),
            resources.GetString("wifiType.Items3")});
            resources.ApplyResources(this.wifiType, "wifiType");
            this.wifiType.Name = "wifiType";
            this.wifiType.Tag = "WiFi encryption type (if not known, WPA-PSK)";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // ipAddr2_4
            // 
            resources.ApplyResources(this.ipAddr2_4, "ipAddr2_4");
            this.ipAddr2_4.Name = "ipAddr2_4";
            this.ipAddr2_4.TextChanged += new System.EventHandler(this.numericField255_TextChanged);
            this.ipAddr2_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            // 
            // ipAddr2_3
            // 
            resources.ApplyResources(this.ipAddr2_3, "ipAddr2_3");
            this.ipAddr2_3.Name = "ipAddr2_3";
            this.ipAddr2_3.TextChanged += new System.EventHandler(this.numericField255_TextChanged);
            this.ipAddr2_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            // 
            // ipAddr2_2
            // 
            resources.ApplyResources(this.ipAddr2_2, "ipAddr2_2");
            this.ipAddr2_2.Name = "ipAddr2_2";
            this.ipAddr2_2.TextChanged += new System.EventHandler(this.numericField255_TextChanged);
            this.ipAddr2_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            // 
            // ipAddr2_1
            // 
            resources.ApplyResources(this.ipAddr2_1, "ipAddr2_1");
            this.ipAddr2_1.Name = "ipAddr2_1";
            this.ipAddr2_1.Tag = "Router\'s IP address";
            this.ipAddr2_1.TextChanged += new System.EventHandler(this.numericField255_TextChanged);
            this.ipAddr2_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // ipAddr1_5
            // 
            resources.ApplyResources(this.ipAddr1_5, "ipAddr1_5");
            this.ipAddr1_5.Name = "ipAddr1_5";
            this.ipAddr1_5.TextChanged += new System.EventHandler(this.numericField32_TextChanged);
            this.ipAddr1_5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            // 
            // ipAddr1_4
            // 
            resources.ApplyResources(this.ipAddr1_4, "ipAddr1_4");
            this.ipAddr1_4.Name = "ipAddr1_4";
            this.ipAddr1_4.TextChanged += new System.EventHandler(this.numericField255_TextChanged);
            this.ipAddr1_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            // 
            // ipAddr1_3
            // 
            resources.ApplyResources(this.ipAddr1_3, "ipAddr1_3");
            this.ipAddr1_3.Name = "ipAddr1_3";
            this.ipAddr1_3.TextChanged += new System.EventHandler(this.numericField255_TextChanged);
            this.ipAddr1_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            // 
            // ipAddr1_2
            // 
            resources.ApplyResources(this.ipAddr1_2, "ipAddr1_2");
            this.ipAddr1_2.Name = "ipAddr1_2";
            this.ipAddr1_2.TextChanged += new System.EventHandler(this.numericField255_TextChanged);
            this.ipAddr1_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            // 
            // ipAddr1_1
            // 
            resources.ApplyResources(this.ipAddr1_1, "ipAddr1_1");
            this.ipAddr1_1.Name = "ipAddr1_1";
            this.ipAddr1_1.Tag = "Static IP address for the ambe server";
            this.ipAddr1_1.TextChanged += new System.EventHandler(this.numericField255_TextChanged);
            this.ipAddr1_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            // 
            // keyPhrase
            // 
            resources.ApplyResources(this.keyPhrase, "keyPhrase");
            this.keyPhrase.Name = "keyPhrase";
            this.keyPhrase.Tag = "WiFi key phrase or password";
            this.keyPhrase.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.text_HelpRequested);
            // 
            // ssid
            // 
            resources.ApplyResources(this.ssid, "ssid");
            this.ssid.Name = "ssid";
            this.ssid.Tag = "SSID for your WiFi tethering";
            this.ssid.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.text_HelpRequested);
            // 
            // label_routerAddr2
            // 
            resources.ApplyResources(this.label_routerAddr2, "label_routerAddr2");
            this.label_routerAddr2.Name = "label_routerAddr2";
            // 
            // label_ipAddr1
            // 
            resources.ApplyResources(this.label_ipAddr1, "label_ipAddr1");
            this.label_ipAddr1.Name = "label_ipAddr1";
            // 
            // label_keyPhrase
            // 
            resources.ApplyResources(this.label_keyPhrase, "label_keyPhrase");
            this.label_keyPhrase.Name = "label_keyPhrase";
            // 
            // label_ssid
            // 
            resources.ApplyResources(this.label_ssid, "label_ssid");
            this.label_ssid.Name = "label_ssid";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_useUSB);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.ipAddr4_4);
            this.groupBox2.Controls.Add(this.ipAddr4_3);
            this.groupBox2.Controls.Add(this.ipAddr4_2);
            this.groupBox2.Controls.Add(this.ipAddr4_1);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.ipAddr3_5);
            this.groupBox2.Controls.Add(this.ipAddr3_4);
            this.groupBox2.Controls.Add(this.ipAddr3_3);
            this.groupBox2.Controls.Add(this.ipAddr3_2);
            this.groupBox2.Controls.Add(this.ipAddr3_1);
            this.groupBox2.Controls.Add(this.label_routerAddr4);
            this.groupBox2.Controls.Add(this.label_ipAddr3);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // checkBox_useUSB
            // 
            resources.ApplyResources(this.checkBox_useUSB, "checkBox_useUSB");
            this.checkBox_useUSB.Name = "checkBox_useUSB";
            this.checkBox_useUSB.UseVisualStyleBackColor = true;
            this.checkBox_useUSB.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // ipAddr4_4
            // 
            resources.ApplyResources(this.ipAddr4_4, "ipAddr4_4");
            this.ipAddr4_4.Name = "ipAddr4_4";
            this.ipAddr4_4.TextChanged += new System.EventHandler(this.numericField255_TextChanged);
            this.ipAddr4_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            // 
            // ipAddr4_3
            // 
            resources.ApplyResources(this.ipAddr4_3, "ipAddr4_3");
            this.ipAddr4_3.Name = "ipAddr4_3";
            this.ipAddr4_3.TextChanged += new System.EventHandler(this.numericField255_TextChanged);
            this.ipAddr4_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            // 
            // ipAddr4_2
            // 
            resources.ApplyResources(this.ipAddr4_2, "ipAddr4_2");
            this.ipAddr4_2.Name = "ipAddr4_2";
            this.ipAddr4_2.TextChanged += new System.EventHandler(this.numericField255_TextChanged);
            this.ipAddr4_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            // 
            // ipAddr4_1
            // 
            resources.ApplyResources(this.ipAddr4_1, "ipAddr4_1");
            this.ipAddr4_1.Name = "ipAddr4_1";
            this.ipAddr4_1.TextChanged += new System.EventHandler(this.numericField255_TextChanged);
            this.ipAddr4_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // ipAddr3_5
            // 
            resources.ApplyResources(this.ipAddr3_5, "ipAddr3_5");
            this.ipAddr3_5.Name = "ipAddr3_5";
            this.ipAddr3_5.TextChanged += new System.EventHandler(this.numericField32_TextChanged);
            this.ipAddr3_5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            // 
            // ipAddr3_4
            // 
            resources.ApplyResources(this.ipAddr3_4, "ipAddr3_4");
            this.ipAddr3_4.Name = "ipAddr3_4";
            this.ipAddr3_4.TextChanged += new System.EventHandler(this.numericField255_TextChanged);
            this.ipAddr3_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            // 
            // ipAddr3_3
            // 
            resources.ApplyResources(this.ipAddr3_3, "ipAddr3_3");
            this.ipAddr3_3.Name = "ipAddr3_3";
            this.ipAddr3_3.TextChanged += new System.EventHandler(this.numericField255_TextChanged);
            this.ipAddr3_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            // 
            // ipAddr3_2
            // 
            resources.ApplyResources(this.ipAddr3_2, "ipAddr3_2");
            this.ipAddr3_2.Name = "ipAddr3_2";
            this.ipAddr3_2.TextChanged += new System.EventHandler(this.numericField255_TextChanged);
            this.ipAddr3_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            // 
            // ipAddr3_1
            // 
            resources.ApplyResources(this.ipAddr3_1, "ipAddr3_1");
            this.ipAddr3_1.Name = "ipAddr3_1";
            this.ipAddr3_1.TextChanged += new System.EventHandler(this.numericField255_TextChanged);
            this.ipAddr3_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            // 
            // label_routerAddr4
            // 
            resources.ApplyResources(this.label_routerAddr4, "label_routerAddr4");
            this.label_routerAddr4.Name = "label_routerAddr4";
            // 
            // label_ipAddr3
            // 
            resources.ApplyResources(this.label_ipAddr3, "label_ipAddr3");
            this.label_ipAddr3.Name = "label_ipAddr3";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ambePort);
            this.groupBox3.Controls.Add(this.sshPort);
            this.groupBox3.Controls.Add(this.label_ambePort);
            this.groupBox3.Controls.Add(this.label_sshPort);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // ambePort
            // 
            resources.ApplyResources(this.ambePort, "ambePort");
            this.ambePort.Name = "ambePort";
            this.ambePort.Tag = "AMBE server port number (default: 2465)";
            this.ambePort.TextChanged += new System.EventHandler(this.numericField65536_TextChanged);
            this.ambePort.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.text_HelpRequested);
            this.ambePort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            // 
            // sshPort
            // 
            resources.ApplyResources(this.sshPort, "sshPort");
            this.sshPort.Name = "sshPort";
            this.sshPort.Tag = "SSH port number";
            this.sshPort.TextChanged += new System.EventHandler(this.numericField65536_TextChanged);
            this.sshPort.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.text_HelpRequested);
            this.sshPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            // 
            // label_ambePort
            // 
            resources.ApplyResources(this.label_ambePort, "label_ambePort");
            this.label_ambePort.Name = "label_ambePort";
            // 
            // label_sshPort
            // 
            resources.ApplyResources(this.label_sshPort, "label_sshPort");
            this.label_sshPort.Name = "label_sshPort";
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labe_about
            // 
            this.labe_about.Cursor = System.Windows.Forms.Cursors.Help;
            resources.ApplyResources(this.labe_about, "labe_about");
            this.labe_about.Name = "labe_about";
            this.labe_about.Click += new System.EventHandler(this.labelAbout_Click);
            // 
            // label_prodName
            // 
            this.label_prodName.Cursor = System.Windows.Forms.Cursors.Help;
            resources.ApplyResources(this.label_prodName, "label_prodName");
            this.label_prodName.Name = "label_prodName";
            this.label_prodName.Click += new System.EventHandler(this.labelAbout_Click);
            // 
            // label_version
            // 
            this.label_version.Cursor = System.Windows.Forms.Cursors.Help;
            resources.ApplyResources(this.label_version, "label_version");
            this.label_version.Name = "label_version";
            // 
            // AMBEDConfig
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_version);
            this.Controls.Add(this.label_prodName);
            this.Controls.Add(this.labe_about);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.HelpButton = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AMBEDConfig";
            this.Load += new System.EventHandler(this.AMBEDConfig_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AMBEDConfig_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_routerAddr2;
        private System.Windows.Forms.Label label_wifiType;
        private System.Windows.Forms.Label label_ipAddr1;
        private System.Windows.Forms.ComboBox wifiType;
        private System.Windows.Forms.Label label_keyPhrase;
        private System.Windows.Forms.Label label_ssid;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox ipAddr2_4;
        private System.Windows.Forms.TextBox ipAddr2_3;
        private System.Windows.Forms.TextBox ipAddr2_2;
        private System.Windows.Forms.TextBox ipAddr2_1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ipAddr1_5;
        private System.Windows.Forms.TextBox ipAddr1_4;
        private System.Windows.Forms.TextBox ipAddr1_3;
        private System.Windows.Forms.TextBox ipAddr1_2;
        private System.Windows.Forms.TextBox ipAddr1_1;
        private System.Windows.Forms.TextBox keyPhrase;
        private System.Windows.Forms.TextBox ssid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox ipAddr4_4;
        private System.Windows.Forms.TextBox ipAddr4_3;
        private System.Windows.Forms.TextBox ipAddr4_2;
        private System.Windows.Forms.TextBox ipAddr4_1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox ipAddr3_5;
        private System.Windows.Forms.TextBox ipAddr3_4;
        private System.Windows.Forms.TextBox ipAddr3_3;
        private System.Windows.Forms.TextBox ipAddr3_2;
        private System.Windows.Forms.TextBox ipAddr3_1;
        private System.Windows.Forms.Label label_routerAddr4;
        private System.Windows.Forms.Label label_ipAddr3;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox ambePort;
        private System.Windows.Forms.TextBox sshPort;
        private System.Windows.Forms.Label label_ambePort;
        private System.Windows.Forms.Label label_sshPort;
        private System.Windows.Forms.CheckBox checkBox_useUSB;
        private TextBox countryCode;
        private Label label_countryCode;
        private Label labe_about;
        private Label label_prodName;
        private Label label_version;
    }
}

