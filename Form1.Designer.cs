using System.Windows.Forms;


namespace DBSec
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_backupCertificate = new System.Windows.Forms.Button();
            this.SecTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chk_copyDbToHost = new System.Windows.Forms.CheckBox();
            this.chk_copyToHost = new System.Windows.Forms.CheckBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_certificatePath = new System.Windows.Forms.TextBox();
            this.btn_BrowsePathForEncrypt = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_encrypt = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_certificateBackupPath = new System.Windows.Forms.TextBox();
            this.btn_browseForCertificateBak = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txt_dbRestoreName = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btn_dbRestorePath = new System.Windows.Forms.Button();
            this.txt_dbRestorePath = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_privateKeyRestorePath = new System.Windows.Forms.TextBox();
            this.btn_privateKeyRestorePath = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_certificateRestorePath = new System.Windows.Forms.TextBox();
            this.btn_certificateRestorePath = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_restore = new System.Windows.Forms.Button();
            this.txt_masterKeyRestorePath = new System.Windows.Forms.TextBox();
            this.btn_masterKeyRestorePath = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_tinyAddress = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_encryptConfigFile = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_ConfigFilePath = new System.Windows.Forms.TextBox();
            this.btn_ConfigFilePath = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label24 = new System.Windows.Forms.Label();
            this.btn_unlockSql = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_ServerIP = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button6 = new System.Windows.Forms.Button();
            this.TinyCode = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label34 = new System.Windows.Forms.Label();
            this.txt_DbPass = new System.Windows.Forms.TextBox();
            this.txt_DB = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_testDb = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_CurrentSaPassword = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_changeSa = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SecTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_backupCertificate
            // 
            this.btn_backupCertificate.BackColor = System.Drawing.Color.OrangeRed;
            resources.ApplyResources(this.btn_backupCertificate, "btn_backupCertificate");
            this.btn_backupCertificate.Name = "btn_backupCertificate";
            this.btn_backupCertificate.UseVisualStyleBackColor = false;
            this.btn_backupCertificate.Click += new System.EventHandler(this.Button1_Click);
            // 
            // SecTab
            // 
            this.SecTab.Controls.Add(this.tabPage1);
            this.SecTab.Controls.Add(this.tabPage6);
            this.SecTab.Controls.Add(this.tabPage2);
            this.SecTab.Controls.Add(this.tabPage3);
            this.SecTab.Controls.Add(this.tabPage5);
            this.SecTab.Controls.Add(this.tabPage4);
            resources.ApplyResources(this.SecTab, "SecTab");
            this.SecTab.Name = "SecTab";
            this.SecTab.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chk_copyDbToHost);
            this.tabPage1.Controls.Add(this.chk_copyToHost);
            this.tabPage1.Controls.Add(this.label32);
            this.tabPage1.Controls.Add(this.label28);
            this.tabPage1.Controls.Add(this.label27);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.txt_certificatePath);
            this.tabPage1.Controls.Add(this.btn_BrowsePathForEncrypt);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.btn_encrypt);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chk_copyDbToHost
            // 
            resources.ApplyResources(this.chk_copyDbToHost, "chk_copyDbToHost");
            this.chk_copyDbToHost.Name = "chk_copyDbToHost";
            this.chk_copyDbToHost.UseVisualStyleBackColor = true;
            // 
            // chk_copyToHost
            // 
            resources.ApplyResources(this.chk_copyToHost, "chk_copyToHost");
            this.chk_copyToHost.Checked = true;
            this.chk_copyToHost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_copyToHost.Name = "chk_copyToHost";
            this.chk_copyToHost.UseVisualStyleBackColor = true;
            this.chk_copyToHost.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            // 
            // label32
            // 
            resources.ApplyResources(this.label32, "label32");
            this.label32.ForeColor = System.Drawing.Color.Green;
            this.label32.Name = "label32";
            // 
            // label28
            // 
            resources.ApplyResources(this.label28, "label28");
            this.label28.Name = "label28";
            // 
            // label27
            // 
            resources.ApplyResources(this.label27, "label27");
            this.label27.Name = "label27";
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.Name = "label26";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // txt_certificatePath
            // 
            resources.ApplyResources(this.txt_certificatePath, "txt_certificatePath");
            this.txt_certificatePath.Name = "txt_certificatePath";
            // 
            // btn_BrowsePathForEncrypt
            // 
            this.btn_BrowsePathForEncrypt.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.btn_BrowsePathForEncrypt, "btn_BrowsePathForEncrypt");
            this.btn_BrowsePathForEncrypt.Name = "btn_BrowsePathForEncrypt";
            this.btn_BrowsePathForEncrypt.UseVisualStyleBackColor = false;
            this.btn_BrowsePathForEncrypt.Click += new System.EventHandler(this.Button11_Click);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label12.Name = "label12";
            // 
            // btn_encrypt
            // 
            this.btn_encrypt.BackColor = System.Drawing.Color.OrangeRed;
            resources.ApplyResources(this.btn_encrypt, "btn_encrypt");
            this.btn_encrypt.Name = "btn_encrypt";
            this.btn_encrypt.UseVisualStyleBackColor = false;
            this.btn_encrypt.Click += new System.EventHandler(this.btn_encrypt_Click);
            // 
            // tabPage6
            // 
            resources.ApplyResources(this.tabPage6, "tabPage6");
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_backupCertificate);
            this.groupBox1.Controls.Add(this.txt_certificateBackupPath);
            this.groupBox1.Controls.Add(this.btn_browseForCertificateBak);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // checkBox4
            // 
            resources.ApplyResources(this.checkBox4, "checkBox4");
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.Name = "label30";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txt_certificateBackupPath
            // 
            resources.ApplyResources(this.txt_certificateBackupPath, "txt_certificateBackupPath");
            this.txt_certificateBackupPath.Name = "txt_certificateBackupPath";
            // 
            // btn_browseForCertificateBak
            // 
            this.btn_browseForCertificateBak.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.btn_browseForCertificateBak, "btn_browseForCertificateBak");
            this.btn_browseForCertificateBak.Name = "btn_browseForCertificateBak";
            this.btn_browseForCertificateBak.UseVisualStyleBackColor = false;
            this.btn_browseForCertificateBak.Click += new System.EventHandler(this.Button2_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txt_dbRestoreName);
            this.tabPage3.Controls.Add(this.label29);
            this.tabPage3.Controls.Add(this.label31);
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.txt_privateKeyRestorePath);
            this.tabPage3.Controls.Add(this.btn_privateKeyRestorePath);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.txt_certificateRestorePath);
            this.tabPage3.Controls.Add(this.btn_certificateRestorePath);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.btn_restore);
            this.tabPage3.Controls.Add(this.txt_masterKeyRestorePath);
            this.tabPage3.Controls.Add(this.btn_masterKeyRestorePath);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txt_dbRestoreName
            // 
            resources.ApplyResources(this.txt_dbRestoreName, "txt_dbRestoreName");
            this.txt_dbRestoreName.Name = "txt_dbRestoreName";
            // 
            // label29
            // 
            resources.ApplyResources(this.label29, "label29");
            this.label29.Name = "label29";
            // 
            // label31
            // 
            resources.ApplyResources(this.label31, "label31");
            this.label31.Name = "label31";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.radioButton2);
            this.panel4.Controls.Add(this.radioButton1);
            this.panel4.Controls.Add(this.btn_dbRestorePath);
            this.panel4.Controls.Add(this.txt_dbRestorePath);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btn_dbRestorePath
            // 
            this.btn_dbRestorePath.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.btn_dbRestorePath, "btn_dbRestorePath");
            this.btn_dbRestorePath.Name = "btn_dbRestorePath";
            this.btn_dbRestorePath.UseVisualStyleBackColor = false;
            this.btn_dbRestorePath.Click += new System.EventHandler(this.Button13_Click);
            // 
            // txt_dbRestorePath
            // 
            resources.ApplyResources(this.txt_dbRestorePath, "txt_dbRestorePath");
            this.txt_dbRestorePath.Name = "txt_dbRestorePath";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // txt_privateKeyRestorePath
            // 
            resources.ApplyResources(this.txt_privateKeyRestorePath, "txt_privateKeyRestorePath");
            this.txt_privateKeyRestorePath.Name = "txt_privateKeyRestorePath";
            // 
            // btn_privateKeyRestorePath
            // 
            this.btn_privateKeyRestorePath.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.btn_privateKeyRestorePath, "btn_privateKeyRestorePath");
            this.btn_privateKeyRestorePath.Name = "btn_privateKeyRestorePath";
            this.btn_privateKeyRestorePath.UseVisualStyleBackColor = false;
            this.btn_privateKeyRestorePath.Click += new System.EventHandler(this.Button14_Click);
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // txt_certificateRestorePath
            // 
            resources.ApplyResources(this.txt_certificateRestorePath, "txt_certificateRestorePath");
            this.txt_certificateRestorePath.Name = "txt_certificateRestorePath";
            // 
            // btn_certificateRestorePath
            // 
            this.btn_certificateRestorePath.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.btn_certificateRestorePath, "btn_certificateRestorePath");
            this.btn_certificateRestorePath.Name = "btn_certificateRestorePath";
            this.btn_certificateRestorePath.UseVisualStyleBackColor = false;
            this.btn_certificateRestorePath.Click += new System.EventHandler(this.Button12_Click);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // btn_restore
            // 
            this.btn_restore.BackColor = System.Drawing.Color.OrangeRed;
            resources.ApplyResources(this.btn_restore, "btn_restore");
            this.btn_restore.Name = "btn_restore";
            this.btn_restore.UseVisualStyleBackColor = false;
            this.btn_restore.Click += new System.EventHandler(this.Button9_Click);
            // 
            // txt_masterKeyRestorePath
            // 
            resources.ApplyResources(this.txt_masterKeyRestorePath, "txt_masterKeyRestorePath");
            this.txt_masterKeyRestorePath.Name = "txt_masterKeyRestorePath";
            // 
            // btn_masterKeyRestorePath
            // 
            this.btn_masterKeyRestorePath.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.btn_masterKeyRestorePath, "btn_masterKeyRestorePath");
            this.btn_masterKeyRestorePath.Name = "btn_masterKeyRestorePath";
            this.btn_masterKeyRestorePath.UseVisualStyleBackColor = false;
            this.btn_masterKeyRestorePath.Click += new System.EventHandler(this.Button3_Click_1);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label21);
            this.tabPage5.Controls.Add(this.label20);
            this.tabPage5.Controls.Add(this.label19);
            this.tabPage5.Controls.Add(this.label18);
            this.tabPage5.Controls.Add(this.txt_tinyAddress);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.btn_encryptConfigFile);
            this.tabPage5.Controls.Add(this.label5);
            this.tabPage5.Controls.Add(this.txt_ConfigFilePath);
            this.tabPage5.Controls.Add(this.btn_ConfigFilePath);
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label21.Name = "label21";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label20.Name = "label20";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label19.Name = "label19";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // txt_tinyAddress
            // 
            resources.ApplyResources(this.txt_tinyAddress, "txt_tinyAddress");
            this.txt_tinyAddress.Name = "txt_tinyAddress";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // btn_encryptConfigFile
            // 
            this.btn_encryptConfigFile.BackColor = System.Drawing.Color.OrangeRed;
            resources.ApplyResources(this.btn_encryptConfigFile, "btn_encryptConfigFile");
            this.btn_encryptConfigFile.ForeColor = System.Drawing.Color.Black;
            this.btn_encryptConfigFile.Name = "btn_encryptConfigFile";
            this.btn_encryptConfigFile.UseVisualStyleBackColor = false;
            this.btn_encryptConfigFile.Click += new System.EventHandler(this.Button5_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txt_ConfigFilePath
            // 
            resources.ApplyResources(this.txt_ConfigFilePath, "txt_ConfigFilePath");
            this.txt_ConfigFilePath.Name = "txt_ConfigFilePath";
            this.txt_ConfigFilePath.ReadOnly = true;
            // 
            // btn_ConfigFilePath
            // 
            resources.ApplyResources(this.btn_ConfigFilePath, "btn_ConfigFilePath");
            this.btn_ConfigFilePath.Name = "btn_ConfigFilePath";
            this.btn_ConfigFilePath.UseVisualStyleBackColor = true;
            this.btn_ConfigFilePath.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label24);
            this.tabPage4.Controls.Add(this.btn_unlockSql);
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Name = "label24";
            // 
            // btn_unlockSql
            // 
            this.btn_unlockSql.BackColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.btn_unlockSql, "btn_unlockSql");
            this.btn_unlockSql.Name = "btn_unlockSql";
            this.btn_unlockSql.UseVisualStyleBackColor = false;
            this.btn_unlockSql.Click += new System.EventHandler(this.button16_Click);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txt_ServerIP
            // 
            resources.ApplyResources(this.txt_ServerIP, "txt_ServerIP");
            this.txt_ServerIP.Name = "txt_ServerIP";
            this.txt_ServerIP.TextChanged += new System.EventHandler(this.Txt_ServerIP_TextChanged);
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Brown;
            resources.ApplyResources(this.button6, "button6");
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // TinyCode
            // 
            resources.ApplyResources(this.TinyCode, "TinyCode");
            this.TinyCode.Name = "TinyCode";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label34);
            this.panel1.Controls.Add(this.txt_DbPass);
            this.panel1.Controls.Add(this.txt_DB);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.btn_testDb);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txt_ServerIP);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label34
            // 
            resources.ApplyResources(this.label34, "label34");
            this.label34.Name = "label34";
            // 
            // txt_DbPass
            // 
            resources.ApplyResources(this.txt_DbPass, "txt_DbPass");
            this.txt_DbPass.Name = "txt_DbPass";
            // 
            // txt_DB
            // 
            this.txt_DB.FormattingEnabled = true;
            resources.ApplyResources(this.txt_DB, "txt_DB");
            this.txt_DB.Name = "txt_DB";
            this.txt_DB.Enter += new System.EventHandler(this.comboBox1_Enter);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label10.Name = "label10";
            // 
            // btn_testDb
            // 
            this.btn_testDb.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.btn_testDb, "btn_testDb");
            this.btn_testDb.Name = "btn_testDb";
            this.btn_testDb.UseVisualStyleBackColor = false;
            this.btn_testDb.Click += new System.EventHandler(this.Button8_Click);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label11.Name = "label11";
            // 
            // lbl_CurrentSaPassword
            // 
            resources.ApplyResources(this.lbl_CurrentSaPassword, "lbl_CurrentSaPassword");
            this.lbl_CurrentSaPassword.Name = "lbl_CurrentSaPassword";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.textBox4, "textBox4");
            this.textBox4.Name = "textBox4";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.button10);
            this.panel2.Controls.Add(this.textBox10);
            this.panel2.Controls.Add(this.label33);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.textBox16);
            this.panel2.Controls.Add(this.radioButton4);
            this.panel2.Controls.Add(this.radioButton3);
            this.panel2.Controls.Add(this.textBox14);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.TinyCode);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.ForeColor = System.Drawing.Color.DarkGreen;
            this.label25.Name = "label25";
            // 
            // button10
            // 
            resources.ApplyResources(this.button10, "button10");
            this.button10.Name = "button10";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.Button10_Click_4);
            // 
            // textBox10
            // 
            resources.ApplyResources(this.textBox10, "textBox10");
            this.textBox10.Name = "textBox10";
            // 
            // label33
            // 
            resources.ApplyResources(this.label33, "label33");
            this.label33.Name = "label33";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // textBox16
            // 
            resources.ApplyResources(this.textBox16, "textBox16");
            this.textBox16.Name = "textBox16";
            // 
            // radioButton4
            // 
            resources.ApplyResources(this.radioButton4, "radioButton4");
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            resources.ApplyResources(this.radioButton3, "radioButton3");
            this.radioButton3.Checked = true;
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.RadioButton3_CheckedChanged);
            // 
            // textBox14
            // 
            resources.ApplyResources(this.textBox14, "textBox14");
            this.textBox14.Name = "textBox14";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Name = "label22";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_changeSa
            // 
            this.btn_changeSa.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.btn_changeSa, "btn_changeSa");
            this.btn_changeSa.Name = "btn_changeSa";
            this.btn_changeSa.UseVisualStyleBackColor = false;
            this.btn_changeSa.Click += new System.EventHandler(this.button15_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.btn_changeSa);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.textBox4);
            this.panel3.Controls.Add(this.lbl_CurrentSaPassword);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Name = "label7";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(this.SecTab);
            this.panel5.Controls.Add(this.panel1);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.exitToolStripMenuItem1,
            this.dsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            resources.ApplyResources(this.exitToolStripMenuItem1, "exitToolStripMenuItem1");
            // 
            // dsToolStripMenuItem
            // 
            this.dsToolStripMenuItem.Name = "dsToolStripMenuItem";
            resources.ApplyResources(this.dsToolStripMenuItem, "dsToolStripMenuItem");
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed_1);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SecTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #endregion

        private System.Windows.Forms.Button btn_backupCertificate;
        private System.Windows.Forms.TabControl SecTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_certificateBackupPath;
        private System.Windows.Forms.Button btn_browseForCertificateBak;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btn_encryptConfigFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_ConfigFilePath;
        private System.Windows.Forms.Button btn_ConfigFilePath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_ServerIP;
        //private AxTinyPlusCtrl axTinyPlusCtrl1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TinyCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_encrypt;
        private System.Windows.Forms.Button btn_testDb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_masterKeyRestorePath;
        private System.Windows.Forms.Button btn_masterKeyRestorePath;
        private System.Windows.Forms.Button btn_restore;
        private System.Windows.Forms.Label lbl_CurrentSaPassword;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_certificatePath;
        private System.Windows.Forms.Button btn_BrowsePathForEncrypt;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_dbRestorePath;
        private System.Windows.Forms.Button btn_dbRestorePath;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_certificateRestorePath;
        private System.Windows.Forms.Button btn_certificateRestorePath;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_privateKeyRestorePath;
        private System.Windows.Forms.Button btn_privateKeyRestorePath;
        private System.Windows.Forms.Button btn_changeSa;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_tinyAddress;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox txt_DB;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btn_unlockSql;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private TextBox txt_dbRestoreName;
        private Label label29;
        private ToolStripSeparator exitToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem1;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private TextBox textBox14;
        private CheckBox chk_copyToHost;
        private Label label32;
        private TextBox textBox16;
        private Label label33;
        private Label label23;
        private Label label24;
        private TextBox textBox10;
        private Button button10;
        private CheckBox chk_copyDbToHost;
        private Label label25;
        private ToolStripMenuItem dsToolStripMenuItem;
        private CheckBox checkBox4;
        private Label label34;
        private TextBox txt_DbPass;
        private TabPage tabPage6;
    }
}

