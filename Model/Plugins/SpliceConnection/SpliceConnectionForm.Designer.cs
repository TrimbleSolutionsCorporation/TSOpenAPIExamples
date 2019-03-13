    partial class SpliceConnection
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
            if(disposing && (components != null))
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
            this.PlateLengthTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BoltStandardTextBox = new System.Windows.Forms.TextBox();
            this.okApplyModifyGetOnOffCancel1 = new Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel();
            this.saveLoad1 = new Tekla.Structures.Dialog.UIControls.SaveLoad();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBoxBoltStandard = new System.Windows.Forms.CheckBox();
            this.checkBoxPlateLength = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.checkBoxLocked = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBoxAutoConnection = new System.Windows.Forms.CheckBox();
            this.checkBoxConnectionCode = new System.Windows.Forms.CheckBox();
            this.checkBoxRotationAngleX = new System.Windows.Forms.CheckBox();
            this.checkBoxClass = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoDefault = new System.Windows.Forms.CheckBox();
            this.checkBoxRotationAngleY = new System.Windows.Forms.CheckBox();
            this.checkBoxUpDirection = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PlateLengthTextBox
            // 
            this.structuresExtender.SetAttributeName(this.PlateLengthTextBox, "PlateLength");
            this.structuresExtender.SetAttributeTypeName(this.PlateLengthTextBox, "Distance");
            this.structuresExtender.SetBindPropertyName(this.PlateLengthTextBox, null);
            this.PlateLengthTextBox.Location = new System.Drawing.Point(128, 21);
            this.PlateLengthTextBox.Name = "PlateLengthTextBox";
            this.PlateLengthTextBox.Size = new System.Drawing.Size(90, 20);
            this.PlateLengthTextBox.TabIndex = 1;
            this.PlateLengthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.anyTextBox_KeyPress);
            // 
            // label1
            // 
            this.structuresExtender.SetAttributeName(this.label1, null);
            this.structuresExtender.SetAttributeTypeName(this.label1, null);
            this.label1.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label1, null);
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Plate length";
            // 
            // label3
            // 
            this.structuresExtender.SetAttributeName(this.label3, null);
            this.structuresExtender.SetAttributeTypeName(this.label3, null);
            this.label3.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label3, null);
            this.label3.Location = new System.Drawing.Point(27, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bolt standard";
            // 
            // BoltStandardTextBox
            // 
            this.structuresExtender.SetAttributeName(this.BoltStandardTextBox, "BoltStandard");
            this.structuresExtender.SetAttributeTypeName(this.BoltStandardTextBox, "String");
            this.structuresExtender.SetBindPropertyName(this.BoltStandardTextBox, null);
            this.BoltStandardTextBox.Location = new System.Drawing.Point(128, 47);
            this.BoltStandardTextBox.Name = "BoltStandardTextBox";
            this.BoltStandardTextBox.Size = new System.Drawing.Size(90, 20);
            this.BoltStandardTextBox.TabIndex = 5;
            this.BoltStandardTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.anyTextBox_KeyPress);
            // 
            // okApplyModifyGetOnOffCancel1
            // 
            this.structuresExtender.SetAttributeName(this.okApplyModifyGetOnOffCancel1, null);
            this.structuresExtender.SetAttributeTypeName(this.okApplyModifyGetOnOffCancel1, null);
            this.structuresExtender.SetBindPropertyName(this.okApplyModifyGetOnOffCancel1, null);
            this.okApplyModifyGetOnOffCancel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okApplyModifyGetOnOffCancel1.Location = new System.Drawing.Point(0, 392);
            this.okApplyModifyGetOnOffCancel1.Margin = new System.Windows.Forms.Padding(4);
            this.okApplyModifyGetOnOffCancel1.Name = "okApplyModifyGetOnOffCancel1";
            this.okApplyModifyGetOnOffCancel1.Size = new System.Drawing.Size(523, 29);
            this.okApplyModifyGetOnOffCancel1.TabIndex = 8;
            this.okApplyModifyGetOnOffCancel1.OkClicked += new System.EventHandler(this.okApplyModifyGetOnOffCancel1_OkClicked);
            this.okApplyModifyGetOnOffCancel1.ApplyClicked += new System.EventHandler(this.okApplyModifyGetOnOffCancel1_ApplyClicked);
            this.okApplyModifyGetOnOffCancel1.ModifyClicked += new System.EventHandler(this.okApplyModifyGetOnOffCancel1_ModifyClicked);
            this.okApplyModifyGetOnOffCancel1.GetClicked += new System.EventHandler(this.okApplyModifyGetOnOffCancel1_GetClicked);
            this.okApplyModifyGetOnOffCancel1.OnOffClicked += new System.EventHandler(this.okApplyModifyGetOnOffCancel1_OnOffClicked);
            this.okApplyModifyGetOnOffCancel1.CancelClicked += new System.EventHandler(this.okApplyModifyGetOnOffCancel1_CancelClicked);
            // 
            // saveLoad1
            // 
            this.structuresExtender.SetAttributeName(this.saveLoad1, null);
            this.structuresExtender.SetAttributeTypeName(this.saveLoad1, null);
            this.saveLoad1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.structuresExtender.SetBindPropertyName(this.saveLoad1, null);
            this.saveLoad1.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveLoad1.HelpFileType = Tekla.Structures.Dialog.UIControls.SaveLoad.HelpFileTypeEnum.General;
            this.saveLoad1.HelpKeyword = "";
            this.saveLoad1.HelpUrl = "";
            this.saveLoad1.Location = new System.Drawing.Point(0, 0);
            this.saveLoad1.Margin = new System.Windows.Forms.Padding(4);
            this.saveLoad1.Name = "saveLoad1";
            this.saveLoad1.SaveAsText = "";
            this.saveLoad1.Size = new System.Drawing.Size(523, 43);
            this.saveLoad1.TabIndex = 9;
            this.saveLoad1.UserDefinedHelpFilePath = null;
            // 
            // tabControl1
            // 
            this.structuresExtender.SetAttributeName(this.tabControl1, null);
            this.structuresExtender.SetAttributeTypeName(this.tabControl1, null);
            this.structuresExtender.SetBindPropertyName(this.tabControl1, null);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 49);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(523, 337);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.structuresExtender.SetAttributeName(this.tabPage1, null);
            this.structuresExtender.SetAttributeTypeName(this.tabPage1, null);
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.structuresExtender.SetBindPropertyName(this.tabPage1, null);
            this.tabPage1.Controls.Add(this.checkBoxBoltStandard);
            this.tabPage1.Controls.Add(this.checkBoxPlateLength);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.PlateLengthTextBox);
            this.tabPage1.Controls.Add(this.BoltStandardTextBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(515, 311);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "albl_Parameters";
            // 
            // checkBoxBoltStandard
            // 
            this.structuresExtender.SetAttributeName(this.checkBoxBoltStandard, "BoltStandard");
            this.structuresExtender.SetAttributeTypeName(this.checkBoxBoltStandard, null);
            this.checkBoxBoltStandard.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.checkBoxBoltStandard, "Checked");
            this.checkBoxBoltStandard.Checked = true;
            this.checkBoxBoltStandard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.checkBoxBoltStandard, true);
            this.checkBoxBoltStandard.Location = new System.Drawing.Point(107, 50);
            this.checkBoxBoltStandard.Name = "checkBoxBoltStandard";
            this.checkBoxBoltStandard.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBoltStandard.TabIndex = 8;
            this.checkBoxBoltStandard.UseVisualStyleBackColor = true;
            // 
            // checkBoxPlateLength
            // 
            this.structuresExtender.SetAttributeName(this.checkBoxPlateLength, "PlateLength");
            this.structuresExtender.SetAttributeTypeName(this.checkBoxPlateLength, null);
            this.checkBoxPlateLength.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.checkBoxPlateLength, "Checked");
            this.checkBoxPlateLength.Checked = true;
            this.checkBoxPlateLength.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.checkBoxPlateLength, true);
            this.checkBoxPlateLength.Location = new System.Drawing.Point(107, 24);
            this.checkBoxPlateLength.Name = "checkBoxPlateLength";
            this.checkBoxPlateLength.Size = new System.Drawing.Size(15, 14);
            this.checkBoxPlateLength.TabIndex = 7;
            this.checkBoxPlateLength.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.structuresExtender.SetAttributeName(this.tabPage2, null);
            this.structuresExtender.SetAttributeTypeName(this.tabPage2, null);
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.structuresExtender.SetBindPropertyName(this.tabPage2, null);
            this.tabPage2.Controls.Add(this.textBox6);
            this.tabPage2.Controls.Add(this.textBox5);
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.comboBox4);
            this.tabPage2.Controls.Add(this.checkBoxLocked);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.checkBoxAutoConnection);
            this.tabPage2.Controls.Add(this.checkBoxConnectionCode);
            this.tabPage2.Controls.Add(this.checkBoxRotationAngleX);
            this.tabPage2.Controls.Add(this.checkBoxClass);
            this.tabPage2.Controls.Add(this.checkBoxAutoDefault);
            this.tabPage2.Controls.Add(this.checkBoxRotationAngleY);
            this.tabPage2.Controls.Add(this.checkBoxUpDirection);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(515, 311);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "General";
            // 
            // textBox6
            // 
            this.structuresExtender.SetAttributeName(this.textBox6, "ac_root");
            this.structuresExtender.SetAttributeTypeName(this.textBox6, "String");
            this.structuresExtender.SetBindPropertyName(this.textBox6, "Text");
            this.textBox6.Location = new System.Drawing.Point(278, 226);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 7;
            this.textBox6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.anyTextBox_KeyPress);
            // 
            // textBox5
            // 
            this.structuresExtender.SetAttributeName(this.textBox5, "ad_root");
            this.structuresExtender.SetAttributeTypeName(this.textBox5, "String");
            this.structuresExtender.SetBindPropertyName(this.textBox5, "Text");
            this.textBox5.Location = new System.Drawing.Point(278, 199);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 6;
            this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.anyTextBox_KeyPress);
            // 
            // textBox4
            // 
            this.structuresExtender.SetAttributeName(this.textBox4, "joint_code");
            this.structuresExtender.SetAttributeTypeName(this.textBox4, "String");
            this.structuresExtender.SetBindPropertyName(this.textBox4, "Text");
            this.textBox4.Location = new System.Drawing.Point(278, 171);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 5;
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.anyTextBox_KeyPress);
            // 
            // textBox1
            // 
            this.structuresExtender.SetAttributeName(this.textBox1, "group_no");
            this.structuresExtender.SetAttributeTypeName(this.textBox1, "Integer");
            this.structuresExtender.SetBindPropertyName(this.textBox1, "Text");
            this.textBox1.Location = new System.Drawing.Point(278, 145);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.anyTextBox_KeyPress);
            // 
            // textBox3
            // 
            this.structuresExtender.SetAttributeName(this.textBox3, "zang1");
            this.structuresExtender.SetAttributeTypeName(this.textBox3, "Double");
            this.structuresExtender.SetBindPropertyName(this.textBox3, "Text");
            this.textBox3.Location = new System.Drawing.Point(278, 49);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 5;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.anyTextBox_KeyPress);
            // 
            // pictureBox1
            // 
            this.structuresExtender.SetAttributeName(this.pictureBox1, null);
            this.structuresExtender.SetAttributeTypeName(this.pictureBox1, null);
            this.structuresExtender.SetBindPropertyName(this.pictureBox1, null);
            this.pictureBox1.Image = global::SpliceConn.Properties.Resources.UpDirection;
            this.pictureBox1.Location = new System.Drawing.Point(165, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 76);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // textBox2
            // 
            this.structuresExtender.SetAttributeName(this.textBox2, "zang2");
            this.structuresExtender.SetAttributeTypeName(this.textBox2, "Double");
            this.structuresExtender.SetBindPropertyName(this.textBox2, "Text");
            this.textBox2.Location = new System.Drawing.Point(278, 74);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.anyTextBox_KeyPress);
            // 
            // comboBox4
            // 
            this.structuresExtender.SetAttributeName(this.comboBox4, "OBJECT_LOCKED");
            this.structuresExtender.SetAttributeTypeName(this.comboBox4, "Integer");
            this.structuresExtender.SetBindPropertyName(this.comboBox4, "SelectedIndex");
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.comboBox4.Location = new System.Drawing.Point(278, 121);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(100, 21);
            this.comboBox4.TabIndex = 2;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.anyComboBox_SelectedIndexChanged);
            // 
            // checkBoxLocked
            // 
            this.structuresExtender.SetAttributeName(this.checkBoxLocked, "OBJECT_LOCKED");
            this.structuresExtender.SetAttributeTypeName(this.checkBoxLocked, null);
            this.checkBoxLocked.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.checkBoxLocked, "Checked");
            this.checkBoxLocked.Checked = true;
            this.checkBoxLocked.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.checkBoxLocked, true);
            this.checkBoxLocked.Location = new System.Drawing.Point(257, 124);
            this.checkBoxLocked.Name = "checkBoxLocked";
            this.checkBoxLocked.Size = new System.Drawing.Size(15, 14);
            this.checkBoxLocked.TabIndex = 1;
            this.checkBoxLocked.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.structuresExtender.SetAttributeName(this.comboBox1, "zsuunta");
            this.structuresExtender.SetAttributeTypeName(this.comboBox1, "Integer");
            this.structuresExtender.SetBindPropertyName(this.comboBox1, "SelectedIndex");
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "none",
            "-z",
            "+z",
            "+x",
            "-x",
            "-y",
            "+y",
            "auto"});
            this.comboBox1.Location = new System.Drawing.Point(278, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.anyComboBox_SelectedIndexChanged);
            // 
            // checkBoxAutoConnection
            // 
            this.structuresExtender.SetAttributeName(this.checkBoxAutoConnection, "ac_root");
            this.structuresExtender.SetAttributeTypeName(this.checkBoxAutoConnection, null);
            this.checkBoxAutoConnection.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.checkBoxAutoConnection, "Checked");
            this.checkBoxAutoConnection.Checked = true;
            this.checkBoxAutoConnection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.checkBoxAutoConnection, true);
            this.checkBoxAutoConnection.Location = new System.Drawing.Point(257, 229);
            this.checkBoxAutoConnection.Name = "checkBoxAutoConnection";
            this.checkBoxAutoConnection.Size = new System.Drawing.Size(15, 14);
            this.checkBoxAutoConnection.TabIndex = 1;
            this.checkBoxAutoConnection.UseVisualStyleBackColor = true;
            // 
            // checkBoxConnectionCode
            // 
            this.structuresExtender.SetAttributeName(this.checkBoxConnectionCode, "joint_code");
            this.structuresExtender.SetAttributeTypeName(this.checkBoxConnectionCode, null);
            this.checkBoxConnectionCode.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.checkBoxConnectionCode, "Checked");
            this.checkBoxConnectionCode.Checked = true;
            this.checkBoxConnectionCode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.checkBoxConnectionCode, true);
            this.checkBoxConnectionCode.Location = new System.Drawing.Point(257, 173);
            this.checkBoxConnectionCode.Name = "checkBoxConnectionCode";
            this.checkBoxConnectionCode.Size = new System.Drawing.Size(15, 14);
            this.checkBoxConnectionCode.TabIndex = 1;
            this.checkBoxConnectionCode.UseVisualStyleBackColor = true;
            // 
            // checkBoxRotationAngleX
            // 
            this.structuresExtender.SetAttributeName(this.checkBoxRotationAngleX, "zang2");
            this.structuresExtender.SetAttributeTypeName(this.checkBoxRotationAngleX, null);
            this.checkBoxRotationAngleX.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.checkBoxRotationAngleX, "Checked");
            this.checkBoxRotationAngleX.Checked = true;
            this.checkBoxRotationAngleX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.checkBoxRotationAngleX, true);
            this.checkBoxRotationAngleX.Location = new System.Drawing.Point(257, 77);
            this.checkBoxRotationAngleX.Name = "checkBoxRotationAngleX";
            this.checkBoxRotationAngleX.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRotationAngleX.TabIndex = 1;
            this.checkBoxRotationAngleX.UseVisualStyleBackColor = true;
            // 
            // checkBoxClass
            // 
            this.structuresExtender.SetAttributeName(this.checkBoxClass, "group_no");
            this.structuresExtender.SetAttributeTypeName(this.checkBoxClass, null);
            this.checkBoxClass.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.checkBoxClass, "Checked");
            this.checkBoxClass.Checked = true;
            this.checkBoxClass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.checkBoxClass, true);
            this.checkBoxClass.Location = new System.Drawing.Point(257, 147);
            this.checkBoxClass.Name = "checkBoxClass";
            this.checkBoxClass.Size = new System.Drawing.Size(15, 14);
            this.checkBoxClass.TabIndex = 1;
            this.checkBoxClass.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoDefault
            // 
            this.structuresExtender.SetAttributeName(this.checkBoxAutoDefault, "ad_root");
            this.structuresExtender.SetAttributeTypeName(this.checkBoxAutoDefault, null);
            this.checkBoxAutoDefault.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.checkBoxAutoDefault, "Checked");
            this.checkBoxAutoDefault.Checked = true;
            this.checkBoxAutoDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.checkBoxAutoDefault, true);
            this.checkBoxAutoDefault.Location = new System.Drawing.Point(257, 202);
            this.checkBoxAutoDefault.Name = "checkBoxAutoDefault";
            this.checkBoxAutoDefault.Size = new System.Drawing.Size(15, 14);
            this.checkBoxAutoDefault.TabIndex = 1;
            this.checkBoxAutoDefault.UseVisualStyleBackColor = true;
            // 
            // checkBoxRotationAngleY
            // 
            this.structuresExtender.SetAttributeName(this.checkBoxRotationAngleY, "zang1");
            this.structuresExtender.SetAttributeTypeName(this.checkBoxRotationAngleY, null);
            this.checkBoxRotationAngleY.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.checkBoxRotationAngleY, "Checked");
            this.checkBoxRotationAngleY.Checked = true;
            this.checkBoxRotationAngleY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.checkBoxRotationAngleY, true);
            this.checkBoxRotationAngleY.Location = new System.Drawing.Point(257, 51);
            this.checkBoxRotationAngleY.Name = "checkBoxRotationAngleY";
            this.checkBoxRotationAngleY.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRotationAngleY.TabIndex = 1;
            this.checkBoxRotationAngleY.UseVisualStyleBackColor = true;
            // 
            // checkBoxUpDirection
            // 
            this.structuresExtender.SetAttributeName(this.checkBoxUpDirection, "zsuunta");
            this.structuresExtender.SetAttributeTypeName(this.checkBoxUpDirection, null);
            this.checkBoxUpDirection.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.checkBoxUpDirection, "Checked");
            this.checkBoxUpDirection.Checked = true;
            this.checkBoxUpDirection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structuresExtender.SetIsFilter(this.checkBoxUpDirection, true);
            this.checkBoxUpDirection.Location = new System.Drawing.Point(257, 26);
            this.checkBoxUpDirection.Name = "checkBoxUpDirection";
            this.checkBoxUpDirection.Size = new System.Drawing.Size(15, 14);
            this.checkBoxUpDirection.TabIndex = 1;
            this.checkBoxUpDirection.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.structuresExtender.SetAttributeName(this.label8, null);
            this.structuresExtender.SetAttributeTypeName(this.label8, null);
            this.label8.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label8, null);
            this.label8.Location = new System.Drawing.Point(28, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "AutoConnection rule group";
            // 
            // label7
            // 
            this.structuresExtender.SetAttributeName(this.label7, null);
            this.structuresExtender.SetAttributeTypeName(this.label7, null);
            this.label7.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label7, null);
            this.label7.Location = new System.Drawing.Point(28, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "AutoDefaults rule group";
            // 
            // label6
            // 
            this.structuresExtender.SetAttributeName(this.label6, null);
            this.structuresExtender.SetAttributeTypeName(this.label6, null);
            this.label6.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label6, null);
            this.label6.Location = new System.Drawing.Point(28, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Connection code";
            // 
            // label5
            // 
            this.structuresExtender.SetAttributeName(this.label5, null);
            this.structuresExtender.SetAttributeTypeName(this.label5, null);
            this.label5.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label5, null);
            this.label5.Location = new System.Drawing.Point(28, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Class";
            // 
            // label4
            // 
            this.structuresExtender.SetAttributeName(this.label4, null);
            this.structuresExtender.SetAttributeTypeName(this.label4, null);
            this.label4.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label4, null);
            this.label4.Location = new System.Drawing.Point(28, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Locked";
            // 
            // label2
            // 
            this.structuresExtender.SetAttributeName(this.label2, null);
            this.structuresExtender.SetAttributeTypeName(this.label2, null);
            this.label2.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label2, null);
            this.label2.Location = new System.Drawing.Point(28, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Up direction";
            // 
            // SpliceConnection
            // 
            this.structuresExtender.SetAttributeName(this, null);
            this.structuresExtender.SetAttributeTypeName(this, null);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(523, 421);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.saveLoad1);
            this.Controls.Add(this.okApplyModifyGetOnOffCancel1);
            this.Name = "SpliceConnection";
            this.Text = "SpliceConnection";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox PlateLengthTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BoltStandardTextBox;
        private Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel okApplyModifyGetOnOffCancel1;
        private Tekla.Structures.Dialog.UIControls.SaveLoad saveLoad1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBoxUpDirection;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox checkBoxRotationAngleX;
        private System.Windows.Forms.CheckBox checkBoxRotationAngleY;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.CheckBox checkBoxLocked;
        private System.Windows.Forms.CheckBox checkBoxAutoConnection;
        private System.Windows.Forms.CheckBox checkBoxConnectionCode;
        private System.Windows.Forms.CheckBox checkBoxClass;
        private System.Windows.Forms.CheckBox checkBoxAutoDefault;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.CheckBox checkBoxBoltStandard;
        private System.Windows.Forms.CheckBox checkBoxPlateLength;
    }
