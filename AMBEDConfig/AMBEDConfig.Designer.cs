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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AMBEDConfig));
            this.ambePort1 = new System.Windows.Forms.TextBox();
            this.sshPort1 = new System.Windows.Forms.TextBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label_about = new System.Windows.Forms.Label();
            this.label_prodName = new System.Windows.Forms.Label();
            this.label_version = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.sshPort = new System.Windows.Forms.ComboBox();
            this.tab_noraGwPage = new System.Windows.Forms.TabPage();
            this.groupBox_noraGwConfig = new System.Windows.Forms.GroupBox();
            this.labelTxHz = new System.Windows.Forms.Label();
            this.labelRxHz = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label_txOff = new System.Windows.Forms.Label();
            this.txFrequencyOffset = new System.Windows.Forms.TextBox();
            this.rxFrequencyOffset = new System.Windows.Forms.TextBox();
            this.label_txFreq = new System.Windows.Forms.Label();
            this.label_rxFreq = new System.Windows.Forms.Label();
            this.txFrequency = new System.Windows.Forms.TextBox();
            this.rxFrequency = new System.Windows.Forms.TextBox();
            this.noraGwCallSign = new System.Windows.Forms.TextBox();
            this.label_nodeStationCS = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_rxOff = new System.Windows.Forms.Label();
            this.tab_basicPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dhcpMode1_2 = new System.Windows.Forms.RadioButton();
            this.dhcpMode1_1 = new System.Windows.Forms.RadioButton();
            this.showPassword = new System.Windows.Forms.CheckBox();
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
            this.dhcpMode2_2 = new System.Windows.Forms.RadioButton();
            this.dhcpMode2_1 = new System.Windows.Forms.RadioButton();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_advancedPage = new System.Windows.Forms.TabPage();
            this.groupBox_otherConfig = new System.Windows.Forms.GroupBox();
            this.ambePort = new System.Windows.Forms.ComboBox();
            this.label_ambePort = new System.Windows.Forms.Label();
            this.label_sshPort = new System.Windows.Forms.Label();
            this.tab_noraGwPage.SuspendLayout();
            this.groupBox_noraGwConfig.SuspendLayout();
            this.tab_basicPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab_advancedPage.SuspendLayout();
            this.groupBox_otherConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // ambePort1
            // 
            resources.ApplyResources(this.ambePort1, "ambePort1");
            this.ambePort1.Name = "ambePort1";
            this.ambePort1.Tag = "AMBE server port number (default: 2465)";
            this.ambePort1.TextChanged += new System.EventHandler(this.numericField65536_TextChanged);
            this.ambePort1.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.text_HelpRequested);
            this.ambePort1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            this.ambePort1.MouseHover += new System.EventHandler(this.textField_MouseHover);
            // 
            // sshPort1
            // 
            resources.ApplyResources(this.sshPort1, "sshPort1");
            this.sshPort1.Name = "sshPort1";
            this.sshPort1.Tag = "SSH port number";
            this.sshPort1.TextChanged += new System.EventHandler(this.numericField65536_TextChanged);
            this.sshPort1.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.text_HelpRequested);
            this.sshPort1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
            this.sshPort1.MouseHover += new System.EventHandler(this.textField_MouseHover);
            // 
            // button_OK
            // 
            resources.ApplyResources(this.button_OK, "button_OK");
            this.button_OK.Name = "button_OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // button_cancel
            // 
            resources.ApplyResources(this.button_cancel, "button_cancel");
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label_about
            // 
            this.label_about.Cursor = System.Windows.Forms.Cursors.Help;
            resources.ApplyResources(this.label_about, "label_about");
            this.label_about.Name = "label_about";
            this.label_about.Click += new System.EventHandler(this.labelAbout_Click);
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
            // sshPort
            // 
            this.sshPort.FormattingEnabled = true;
            this.sshPort.Items.AddRange(new object[] {
            resources.GetString("sshPort.Items"),
            resources.GetString("sshPort.Items1")});
            resources.ApplyResources(this.sshPort, "sshPort");
            this.sshPort.Name = "sshPort";
            this.sshPort.Tag = "SSH port number";
            this.toolTip1.SetToolTip(this.sshPort, resources.GetString("sshPort.ToolTip"));
            // 
            // tab_noraGwPage
            // 
            this.tab_noraGwPage.Controls.Add(this.groupBox_noraGwConfig);
            resources.ApplyResources(this.tab_noraGwPage, "tab_noraGwPage");
            this.tab_noraGwPage.Name = "tab_noraGwPage";
            this.tab_noraGwPage.UseVisualStyleBackColor = true;
            // 
            // groupBox_noraGwConfig
            // 
            this.groupBox_noraGwConfig.Controls.Add(this.labelTxHz);
            this.groupBox_noraGwConfig.Controls.Add(this.labelRxHz);
            this.groupBox_noraGwConfig.Controls.Add(this.label10);
            this.groupBox_noraGwConfig.Controls.Add(this.label_txOff);
            this.groupBox_noraGwConfig.Controls.Add(this.txFrequencyOffset);
            this.groupBox_noraGwConfig.Controls.Add(this.rxFrequencyOffset);
            this.groupBox_noraGwConfig.Controls.Add(this.label_txFreq);
            this.groupBox_noraGwConfig.Controls.Add(this.label_rxFreq);
            this.groupBox_noraGwConfig.Controls.Add(this.txFrequency);
            this.groupBox_noraGwConfig.Controls.Add(this.rxFrequency);
            this.groupBox_noraGwConfig.Controls.Add(this.noraGwCallSign);
            this.groupBox_noraGwConfig.Controls.Add(this.label_nodeStationCS);
            this.groupBox_noraGwConfig.Controls.Add(this.label5);
            this.groupBox_noraGwConfig.Controls.Add(this.label_rxOff);
            resources.ApplyResources(this.groupBox_noraGwConfig, "groupBox_noraGwConfig");
            this.groupBox_noraGwConfig.Name = "groupBox_noraGwConfig";
            this.groupBox_noraGwConfig.TabStop = false;
            // 
            // labelTxHz
            // 
            resources.ApplyResources(this.labelTxHz, "labelTxHz");
            this.labelTxHz.Name = "labelTxHz";
            // 
            // labelRxHz
            // 
            resources.ApplyResources(this.labelRxHz, "labelRxHz");
            this.labelRxHz.Name = "labelRxHz";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label_txOff
            // 
            resources.ApplyResources(this.label_txOff, "label_txOff");
            this.label_txOff.Name = "label_txOff";
            // 
            // txFrequencyOffset
            // 
            resources.ApplyResources(this.txFrequencyOffset, "txFrequencyOffset");
            this.txFrequencyOffset.Name = "txFrequencyOffset";
            this.txFrequencyOffset.Tag = "TX Offset Frequency for this hotspot";
            this.txFrequencyOffset.TextChanged += new System.EventHandler(this.noraFreqOffset_TextChanged);
            // 
            // rxFrequencyOffset
            // 
            resources.ApplyResources(this.rxFrequencyOffset, "rxFrequencyOffset");
            this.rxFrequencyOffset.Name = "rxFrequencyOffset";
            this.rxFrequencyOffset.Tag = "RX Offset Frequency for this hotspot";
            this.rxFrequencyOffset.TextChanged += new System.EventHandler(this.noraFreqOffset_TextChanged);
            // 
            // label_txFreq
            // 
            resources.ApplyResources(this.label_txFreq, "label_txFreq");
            this.label_txFreq.Name = "label_txFreq";
            // 
            // label_rxFreq
            // 
            resources.ApplyResources(this.label_rxFreq, "label_rxFreq");
            this.label_rxFreq.Name = "label_rxFreq";
            // 
            // txFrequency
            // 
            resources.ApplyResources(this.txFrequency, "txFrequency");
            this.txFrequency.Name = "txFrequency";
            this.txFrequency.Tag = "TX Frequency for this hotspot";
            this.txFrequency.TextChanged += new System.EventHandler(this.noraFreqTextBox_TextChanged);
            this.txFrequency.Leave += new System.EventHandler(this.noraFreqTextBox_FocusLeft);
            // 
            // rxFrequency
            // 
            resources.ApplyResources(this.rxFrequency, "rxFrequency");
            this.rxFrequency.Name = "rxFrequency";
            this.rxFrequency.Tag = "RX Frequency for this hotspot";
            this.rxFrequency.TextChanged += new System.EventHandler(this.noraFreqTextBox_TextChanged);
            this.rxFrequency.Leave += new System.EventHandler(this.noraFreqTextBox_FocusLeft);
            // 
            // noraGwCallSign
            // 
            this.noraGwCallSign.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.noraGwCallSign, "noraGwCallSign");
            this.noraGwCallSign.Name = "noraGwCallSign";
            this.noraGwCallSign.Tag = "SSID for your WiFi tethering";
            this.noraGwCallSign.TextChanged += new System.EventHandler(this.noraGwCallSign_TextChanged);
            // 
            // label_nodeStationCS
            // 
            resources.ApplyResources(this.label_nodeStationCS, "label_nodeStationCS");
            this.label_nodeStationCS.Name = "label_nodeStationCS";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label_rxOff
            // 
            resources.ApplyResources(this.label_rxOff, "label_rxOff");
            this.label_rxOff.Name = "label_rxOff";
            // 
            // tab_basicPage
            // 
            this.tab_basicPage.Controls.Add(this.groupBox1);
            this.tab_basicPage.Controls.Add(this.groupBox2);
            resources.ApplyResources(this.tab_basicPage, "tab_basicPage");
            this.tab_basicPage.Name = "tab_basicPage";
            this.tab_basicPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dhcpMode1_2);
            this.groupBox1.Controls.Add(this.dhcpMode1_1);
            this.groupBox1.Controls.Add(this.showPassword);
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
            // dhcpMode1_2
            // 
            resources.ApplyResources(this.dhcpMode1_2, "dhcpMode1_2");
            this.dhcpMode1_2.Name = "dhcpMode1_2";
            this.dhcpMode1_2.TabStop = true;
            this.dhcpMode1_2.UseVisualStyleBackColor = true;
            this.dhcpMode1_2.CheckedChanged += new System.EventHandler(this.dhcpMode1_CheckedChanged);
            // 
            // dhcpMode1_1
            // 
            resources.ApplyResources(this.dhcpMode1_1, "dhcpMode1_1");
            this.dhcpMode1_1.Name = "dhcpMode1_1";
            this.dhcpMode1_1.TabStop = true;
            this.dhcpMode1_1.UseVisualStyleBackColor = true;
            this.dhcpMode1_1.CheckedChanged += new System.EventHandler(this.dhcpMode1_CheckedChanged);
            // 
            // showPassword
            // 
            resources.ApplyResources(this.showPassword, "showPassword");
            this.showPassword.Name = "showPassword";
            this.showPassword.UseVisualStyleBackColor = true;
            this.showPassword.CheckedChanged += new System.EventHandler(this.showPassword_CheckedChanged);
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
            resources.GetString("wifiType.Items")});
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
            this.ipAddr2_1.MouseHover += new System.EventHandler(this.textField_MouseHover);
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
            this.ipAddr1_5.MouseHover += new System.EventHandler(this.textField_MouseHover);
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
            this.ipAddr1_1.MouseHover += new System.EventHandler(this.textField_MouseHover);
            // 
            // keyPhrase
            // 
            resources.ApplyResources(this.keyPhrase, "keyPhrase");
            this.keyPhrase.Name = "keyPhrase";
            this.keyPhrase.Tag = "WiFi key phrase or password";
            this.keyPhrase.TextChanged += new System.EventHandler(this.keyPhrase_ssid_TextChanged);
            this.keyPhrase.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.text_HelpRequested);
            this.keyPhrase.MouseHover += new System.EventHandler(this.textField_MouseHover);
            // 
            // ssid
            // 
            resources.ApplyResources(this.ssid, "ssid");
            this.ssid.Name = "ssid";
            this.ssid.Tag = "SSID for your WiFi tethering";
            this.ssid.TextChanged += new System.EventHandler(this.keyPhrase_ssid_TextChanged);
            this.ssid.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.text_HelpRequested);
            this.ssid.MouseHover += new System.EventHandler(this.textField_MouseHover);
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
            this.groupBox2.Controls.Add(this.dhcpMode2_2);
            this.groupBox2.Controls.Add(this.dhcpMode2_1);
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
            // dhcpMode2_2
            // 
            resources.ApplyResources(this.dhcpMode2_2, "dhcpMode2_2");
            this.dhcpMode2_2.Name = "dhcpMode2_2";
            this.dhcpMode2_2.TabStop = true;
            this.dhcpMode2_2.UseVisualStyleBackColor = true;
            this.dhcpMode2_2.CheckedChanged += new System.EventHandler(this.dhcpMode2_CheckedChanged);
            // 
            // dhcpMode2_1
            // 
            resources.ApplyResources(this.dhcpMode2_1, "dhcpMode2_1");
            this.dhcpMode2_1.Name = "dhcpMode2_1";
            this.dhcpMode2_1.TabStop = true;
            this.dhcpMode2_1.UseVisualStyleBackColor = true;
            this.dhcpMode2_1.CheckedChanged += new System.EventHandler(this.dhcpMode2_CheckedChanged);
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
            this.ipAddr4_1.MouseHover += new System.EventHandler(this.textField_MouseHover);
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
            this.ipAddr3_5.MouseHover += new System.EventHandler(this.textField_MouseHover);
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
            this.ipAddr3_1.MouseHover += new System.EventHandler(this.textField_MouseHover);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_basicPage);
            this.tabControl1.Controls.Add(this.tab_advancedPage);
            this.tabControl1.Controls.Add(this.tab_noraGwPage);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tab_advancedPage
            // 
            this.tab_advancedPage.Controls.Add(this.groupBox_otherConfig);
            resources.ApplyResources(this.tab_advancedPage, "tab_advancedPage");
            this.tab_advancedPage.Name = "tab_advancedPage";
            this.tab_advancedPage.UseVisualStyleBackColor = true;
            // 
            // groupBox_otherConfig
            // 
            this.groupBox_otherConfig.Controls.Add(this.ambePort);
            this.groupBox_otherConfig.Controls.Add(this.sshPort);
            this.groupBox_otherConfig.Controls.Add(this.label_ambePort);
            this.groupBox_otherConfig.Controls.Add(this.label_sshPort);
            resources.ApplyResources(this.groupBox_otherConfig, "groupBox_otherConfig");
            this.groupBox_otherConfig.Name = "groupBox_otherConfig";
            this.groupBox_otherConfig.TabStop = false;
            // 
            // ambePort
            // 
            this.ambePort.FormattingEnabled = true;
            this.ambePort.Items.AddRange(new object[] {
            resources.GetString("ambePort.Items")});
            resources.ApplyResources(this.ambePort, "ambePort");
            this.ambePort.Name = "ambePort";
            this.ambePort.Tag = "AMBE server port number (default: 2465)";
            this.ambePort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberFld_KeyPress);
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
            // AMBEDConfig
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label_version);
            this.Controls.Add(this.label_prodName);
            this.Controls.Add(this.label_about);
            this.Controls.Add(this.sshPort1);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.ambePort1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AMBEDConfig";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.AMBEDConfig_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AMBEDConfig_KeyDown);
            this.tab_noraGwPage.ResumeLayout(false);
            this.groupBox_noraGwConfig.ResumeLayout(false);
            this.groupBox_noraGwConfig.PerformLayout();
            this.tab_basicPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tab_advancedPage.ResumeLayout(false);
            this.groupBox_otherConfig.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.TextBox ambePort1;
        private System.Windows.Forms.TextBox sshPort1;
        private Label label_about;
        private Label label_prodName;
        private Label label_version;
        private ToolTip toolTip1;
        private TabPage tab_noraGwPage;
        private GroupBox groupBox_noraGwConfig;
        private TabPage tab_basicPage;
        private GroupBox groupBox1;
        private RadioButton dhcpMode1_2;
        private RadioButton dhcpMode1_1;
        private CheckBox showPassword;
        private TextBox countryCode;
        private Label label_countryCode;
        private Label label_wifiType;
        private ComboBox wifiType;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox ipAddr2_4;
        private TextBox ipAddr2_3;
        private TextBox ipAddr2_2;
        private TextBox ipAddr2_1;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox ipAddr1_5;
        private TextBox ipAddr1_4;
        private TextBox ipAddr1_3;
        private TextBox ipAddr1_2;
        private TextBox ipAddr1_1;
        private TextBox keyPhrase;
        private TextBox ssid;
        private Label label_routerAddr2;
        private Label label_ipAddr1;
        private Label label_keyPhrase;
        private Label label_ssid;
        private GroupBox groupBox2;
        private RadioButton dhcpMode2_2;
        private RadioButton dhcpMode2_1;
        private CheckBox checkBox_useUSB;
        private Label label16;
        private Label label17;
        private Label label18;
        private TextBox ipAddr4_4;
        private TextBox ipAddr4_3;
        private TextBox ipAddr4_2;
        private TextBox ipAddr4_1;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private TextBox ipAddr3_5;
        private TextBox ipAddr3_4;
        private TextBox ipAddr3_3;
        private TextBox ipAddr3_2;
        private TextBox ipAddr3_1;
        private Label label_routerAddr4;
        private Label label_ipAddr3;
        private TabControl tabControl1;
        private TabPage tab_advancedPage;
        private GroupBox groupBox_otherConfig;
        private ComboBox ambePort;
        private ComboBox sshPort;
        private Label label_ambePort;
        private Label label_sshPort;
        private Label labelTxHz;
        private Label labelRxHz;
        private Label label10;
        private Label label_txOff;
        private TextBox txFrequencyOffset;
        private TextBox rxFrequencyOffset;
        private Label label_txFreq;
        private Label label_rxFreq;
        private TextBox txFrequency;
        private TextBox rxFrequency;
        private TextBox noraGwCallSign;
        private Label label_nodeStationCS;
        private Label label5;
        private Label label_rxOff;
    }
}

