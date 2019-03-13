namespace ReinforcedBeam
{
    partial class ReinforcedBeamForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.saveLoad1 = new Tekla.Structures.Dialog.UIControls.SaveLoad();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.BeamPropertiesTabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.BeamClassCheckBox4 = new System.Windows.Forms.CheckBox();
            this.BeamNameCheckBox = new System.Windows.Forms.CheckBox();
            this.BeamNameTextBox = new System.Windows.Forms.TextBox();
            this.BeamProfileCheckBox1 = new System.Windows.Forms.CheckBox();
            this.BeamMaterialCheckBox = new System.Windows.Forms.CheckBox();
            this.BeamFinishCheckBox = new System.Windows.Forms.CheckBox();
            this.profileCatalog1 = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.BeamProfileTextBox = new System.Windows.Forms.TextBox();
            this.BeamMaterialTextBox = new System.Windows.Forms.TextBox();
            this.BeamFinishTextBox = new System.Windows.Forms.TextBox();
            this.BeamClassTextBox = new System.Windows.Forms.TextBox();
            this.ReinforcementPropertiesTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.RebarClassCheckBox = new System.Windows.Forms.CheckBox();
            this.RebarNameCheckBox = new System.Windows.Forms.CheckBox();
            this.RebarSizeCheckBox = new System.Windows.Forms.CheckBox();
            this.RebarGradeCheckBox = new System.Windows.Forms.CheckBox();
            this.RebarBendingRadiusCheckBox = new System.Windows.Forms.CheckBox();
            this.RebarNameTextBox = new System.Windows.Forms.TextBox();
            this.RebarSizeTextBox = new System.Windows.Forms.TextBox();
            this.RebarGradeTextBox = new System.Windows.Forms.TextBox();
            this.RebarBendingRadiusTextBox = new System.Windows.Forms.TextBox();
            this.RebarClassTextBox = new System.Windows.Forms.TextBox();
            this.reinforcementCatalog1 = new Tekla.Structures.Dialog.UIControls.ReinforcementCatalog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RebarSpacingTextBox = new System.Windows.Forms.TextBox();
            this.RebarSpacingCheckBox = new System.Windows.Forms.CheckBox();
            this.okApplyModifyGetOnOffCancel1 = new Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.saveLoad2 = new Tekla.Structures.Dialog.UIControls.SaveLoad();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.BeamPropertiesTabPage1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.ReinforcementPropertiesTabPage.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel1, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel1, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel1, null);
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.saveLoad1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.okApplyModifyGetOnOffCancel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(653, 410);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // saveLoad1
            // 
            this.structuresExtender.SetAttributeName(this.saveLoad1, null);
            this.structuresExtender.SetAttributeTypeName(this.saveLoad1, null);
            this.saveLoad1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.structuresExtender.SetBindPropertyName(this.saveLoad1, null);
            this.saveLoad1.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveLoad1.HelpKeyword = "";
            this.saveLoad1.HelpUrl = "";
            this.saveLoad1.Location = new System.Drawing.Point(3, 3);
            this.saveLoad1.Name = "saveLoad1";
            this.saveLoad1.SaveAsText = "";
            this.saveLoad1.Size = new System.Drawing.Size(647, 43);
            this.saveLoad1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.structuresExtender.SetAttributeName(this.tabControl1, null);
            this.structuresExtender.SetAttributeTypeName(this.tabControl1, null);
            this.structuresExtender.SetBindPropertyName(this.tabControl1, null);
            this.tabControl1.Controls.Add(this.BeamPropertiesTabPage1);
            this.tabControl1.Controls.Add(this.ReinforcementPropertiesTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(647, 322);
            this.tabControl1.TabIndex = 2;
            // 
            // BeamPropertiesTabPage1
            // 
            this.structuresExtender.SetAttributeName(this.BeamPropertiesTabPage1, null);
            this.structuresExtender.SetAttributeTypeName(this.BeamPropertiesTabPage1, null);
            this.structuresExtender.SetBindPropertyName(this.BeamPropertiesTabPage1, null);
            this.BeamPropertiesTabPage1.Controls.Add(this.tableLayoutPanel3);
            this.BeamPropertiesTabPage1.Location = new System.Drawing.Point(4, 22);
            this.BeamPropertiesTabPage1.Name = "BeamPropertiesTabPage1";
            this.BeamPropertiesTabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.BeamPropertiesTabPage1.Size = new System.Drawing.Size(639, 296);
            this.BeamPropertiesTabPage1.TabIndex = 0;
            this.BeamPropertiesTabPage1.Text = "Beam properties";
            this.BeamPropertiesTabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel3, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel3, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel3, null);
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel3.Controls.Add(this.BeamClassCheckBox4, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.BeamNameCheckBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.BeamNameTextBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.BeamProfileCheckBox1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.BeamMaterialCheckBox, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.BeamFinishCheckBox, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.profileCatalog1, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.BeamProfileTextBox, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.BeamMaterialTextBox, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.BeamFinishTextBox, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.BeamClassTextBox, 1, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(633, 290);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // BeamClassCheckBox4
            // 
            this.structuresExtender.SetAttributeName(this.BeamClassCheckBox4, "BeamClass");
            this.structuresExtender.SetAttributeTypeName(this.BeamClassCheckBox4, null);
            this.BeamClassCheckBox4.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.BeamClassCheckBox4, null);
            this.structuresExtender.SetIsFilter(this.BeamClassCheckBox4, true);
            this.BeamClassCheckBox4.Location = new System.Drawing.Point(3, 114);
            this.BeamClassCheckBox4.Name = "BeamClassCheckBox4";
            this.BeamClassCheckBox4.Size = new System.Drawing.Size(54, 17);
            this.BeamClassCheckBox4.TabIndex = 5;
            this.BeamClassCheckBox4.Text = "Class:";
            this.BeamClassCheckBox4.UseVisualStyleBackColor = true;
            // 
            // BeamNameCheckBox
            // 
            this.structuresExtender.SetAttributeName(this.BeamNameCheckBox, "BeamName");
            this.structuresExtender.SetAttributeTypeName(this.BeamNameCheckBox, null);
            this.BeamNameCheckBox.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.BeamNameCheckBox, null);
            this.structuresExtender.SetIsFilter(this.BeamNameCheckBox, true);
            this.BeamNameCheckBox.Location = new System.Drawing.Point(3, 3);
            this.BeamNameCheckBox.Name = "BeamNameCheckBox";
            this.BeamNameCheckBox.Size = new System.Drawing.Size(57, 17);
            this.BeamNameCheckBox.TabIndex = 0;
            this.BeamNameCheckBox.Text = "Name:";
            this.BeamNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // BeamNameTextBox
            // 
            this.structuresExtender.SetAttributeName(this.BeamNameTextBox, "BeamName");
            this.structuresExtender.SetAttributeTypeName(this.BeamNameTextBox, "String");
            this.structuresExtender.SetBindPropertyName(this.BeamNameTextBox, null);
            this.BeamNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BeamNameTextBox.Location = new System.Drawing.Point(113, 3);
            this.BeamNameTextBox.Name = "BeamNameTextBox";
            this.BeamNameTextBox.Size = new System.Drawing.Size(411, 20);
            this.BeamNameTextBox.TabIndex = 1;
            // 
            // BeamProfileCheckBox1
            // 
            this.structuresExtender.SetAttributeName(this.BeamProfileCheckBox1, "BeamProfile");
            this.structuresExtender.SetAttributeTypeName(this.BeamProfileCheckBox1, null);
            this.BeamProfileCheckBox1.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.BeamProfileCheckBox1, null);
            this.structuresExtender.SetIsFilter(this.BeamProfileCheckBox1, true);
            this.BeamProfileCheckBox1.Location = new System.Drawing.Point(3, 29);
            this.BeamProfileCheckBox1.Name = "BeamProfileCheckBox1";
            this.BeamProfileCheckBox1.Size = new System.Drawing.Size(58, 17);
            this.BeamProfileCheckBox1.TabIndex = 2;
            this.BeamProfileCheckBox1.Text = "Profile:";
            this.BeamProfileCheckBox1.UseVisualStyleBackColor = true;
            // 
            // BeamMaterialCheckBox
            // 
            this.structuresExtender.SetAttributeName(this.BeamMaterialCheckBox, "BeamMaterial");
            this.structuresExtender.SetAttributeTypeName(this.BeamMaterialCheckBox, null);
            this.BeamMaterialCheckBox.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.BeamMaterialCheckBox, null);
            this.structuresExtender.SetIsFilter(this.BeamMaterialCheckBox, true);
            this.BeamMaterialCheckBox.Location = new System.Drawing.Point(3, 62);
            this.BeamMaterialCheckBox.Name = "BeamMaterialCheckBox";
            this.BeamMaterialCheckBox.Size = new System.Drawing.Size(66, 17);
            this.BeamMaterialCheckBox.TabIndex = 3;
            this.BeamMaterialCheckBox.Text = "Material:";
            this.BeamMaterialCheckBox.UseVisualStyleBackColor = true;
            // 
            // BeamFinishCheckBox
            // 
            this.structuresExtender.SetAttributeName(this.BeamFinishCheckBox, "BeamFinish");
            this.structuresExtender.SetAttributeTypeName(this.BeamFinishCheckBox, null);
            this.BeamFinishCheckBox.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.BeamFinishCheckBox, null);
            this.structuresExtender.SetIsFilter(this.BeamFinishCheckBox, true);
            this.BeamFinishCheckBox.Location = new System.Drawing.Point(3, 88);
            this.BeamFinishCheckBox.Name = "BeamFinishCheckBox";
            this.BeamFinishCheckBox.Size = new System.Drawing.Size(56, 17);
            this.BeamFinishCheckBox.TabIndex = 4;
            this.BeamFinishCheckBox.Text = "Finish:";
            this.BeamFinishCheckBox.UseVisualStyleBackColor = true;
            // 
            // profileCatalog1
            // 
            this.profileCatalog1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.structuresExtender.SetAttributeName(this.profileCatalog1, null);
            this.structuresExtender.SetAttributeTypeName(this.profileCatalog1, null);
            this.profileCatalog1.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.profileCatalog1, null);
            this.profileCatalog1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.profileCatalog1.Location = new System.Drawing.Point(536, 29);
            this.profileCatalog1.Name = "profileCatalog1";
            this.profileCatalog1.SelectedProfile = "";
            this.profileCatalog1.Size = new System.Drawing.Size(88, 27);
            this.profileCatalog1.TabIndex = 6;
            this.profileCatalog1.SelectClicked += new System.EventHandler(this.profileCatalog1_SelectClicked);
            this.profileCatalog1.SelectionDone += new System.EventHandler(this.profileCatalog1_SelectionDone);
            // 
            // BeamProfileTextBox
            // 
            this.structuresExtender.SetAttributeName(this.BeamProfileTextBox, "BeamProfile");
            this.structuresExtender.SetAttributeTypeName(this.BeamProfileTextBox, "String");
            this.structuresExtender.SetBindPropertyName(this.BeamProfileTextBox, null);
            this.BeamProfileTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BeamProfileTextBox.Location = new System.Drawing.Point(113, 29);
            this.BeamProfileTextBox.Name = "BeamProfileTextBox";
            this.BeamProfileTextBox.Size = new System.Drawing.Size(411, 20);
            this.BeamProfileTextBox.TabIndex = 7;
            // 
            // BeamMaterialTextBox
            // 
            this.structuresExtender.SetAttributeName(this.BeamMaterialTextBox, "BeamMaterial");
            this.structuresExtender.SetAttributeTypeName(this.BeamMaterialTextBox, "String");
            this.structuresExtender.SetBindPropertyName(this.BeamMaterialTextBox, null);
            this.BeamMaterialTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BeamMaterialTextBox.Location = new System.Drawing.Point(113, 62);
            this.BeamMaterialTextBox.Name = "BeamMaterialTextBox";
            this.BeamMaterialTextBox.Size = new System.Drawing.Size(411, 20);
            this.BeamMaterialTextBox.TabIndex = 8;
            // 
            // BeamFinishTextBox
            // 
            this.structuresExtender.SetAttributeName(this.BeamFinishTextBox, "BeamFinish");
            this.structuresExtender.SetAttributeTypeName(this.BeamFinishTextBox, "String");
            this.structuresExtender.SetBindPropertyName(this.BeamFinishTextBox, null);
            this.BeamFinishTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BeamFinishTextBox.Location = new System.Drawing.Point(113, 88);
            this.BeamFinishTextBox.Name = "BeamFinishTextBox";
            this.BeamFinishTextBox.Size = new System.Drawing.Size(411, 20);
            this.BeamFinishTextBox.TabIndex = 9;
            // 
            // BeamClassTextBox
            // 
            this.structuresExtender.SetAttributeName(this.BeamClassTextBox, "BeamClass");
            this.structuresExtender.SetAttributeTypeName(this.BeamClassTextBox, "String");
            this.structuresExtender.SetBindPropertyName(this.BeamClassTextBox, null);
            this.BeamClassTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BeamClassTextBox.Location = new System.Drawing.Point(113, 114);
            this.BeamClassTextBox.Name = "BeamClassTextBox";
            this.BeamClassTextBox.Size = new System.Drawing.Size(411, 20);
            this.BeamClassTextBox.TabIndex = 10;
            // 
            // ReinforcementPropertiesTabPage
            // 
            this.structuresExtender.SetAttributeName(this.ReinforcementPropertiesTabPage, null);
            this.structuresExtender.SetAttributeTypeName(this.ReinforcementPropertiesTabPage, null);
            this.structuresExtender.SetBindPropertyName(this.ReinforcementPropertiesTabPage, null);
            this.ReinforcementPropertiesTabPage.Controls.Add(this.tableLayoutPanel4);
            this.ReinforcementPropertiesTabPage.Location = new System.Drawing.Point(4, 22);
            this.ReinforcementPropertiesTabPage.Name = "ReinforcementPropertiesTabPage";
            this.ReinforcementPropertiesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ReinforcementPropertiesTabPage.Size = new System.Drawing.Size(639, 296);
            this.ReinforcementPropertiesTabPage.TabIndex = 1;
            this.ReinforcementPropertiesTabPage.Text = "Reinforcement";
            this.ReinforcementPropertiesTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel4, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel4, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel4, null);
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.Controls.Add(this.RebarClassCheckBox, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.RebarNameCheckBox, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.RebarSizeCheckBox, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.RebarGradeCheckBox, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.RebarBendingRadiusCheckBox, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.RebarNameTextBox, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.RebarSizeTextBox, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.RebarGradeTextBox, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.RebarBendingRadiusTextBox, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.RebarClassTextBox, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.reinforcementCatalog1, 3, 2);
            this.tableLayoutPanel4.Controls.Add(this.groupBox1, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.RebarSpacingTextBox, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.RebarSpacingCheckBox, 0, 5);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(633, 290);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // RebarClassCheckBox
            // 
            this.structuresExtender.SetAttributeName(this.RebarClassCheckBox, "RebarClass");
            this.structuresExtender.SetAttributeTypeName(this.RebarClassCheckBox, null);
            this.RebarClassCheckBox.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.RebarClassCheckBox, null);
            this.structuresExtender.SetIsFilter(this.RebarClassCheckBox, true);
            this.RebarClassCheckBox.Location = new System.Drawing.Point(3, 114);
            this.RebarClassCheckBox.Name = "RebarClassCheckBox";
            this.RebarClassCheckBox.Size = new System.Drawing.Size(54, 17);
            this.RebarClassCheckBox.TabIndex = 4;
            this.RebarClassCheckBox.Text = "Class:";
            this.RebarClassCheckBox.UseVisualStyleBackColor = true;
            // 
            // RebarNameCheckBox
            // 
            this.structuresExtender.SetAttributeName(this.RebarNameCheckBox, "RebarName");
            this.structuresExtender.SetAttributeTypeName(this.RebarNameCheckBox, null);
            this.RebarNameCheckBox.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.RebarNameCheckBox, null);
            this.structuresExtender.SetIsFilter(this.RebarNameCheckBox, true);
            this.RebarNameCheckBox.Location = new System.Drawing.Point(3, 3);
            this.RebarNameCheckBox.Name = "RebarNameCheckBox";
            this.RebarNameCheckBox.Size = new System.Drawing.Size(57, 17);
            this.RebarNameCheckBox.TabIndex = 0;
            this.RebarNameCheckBox.Text = "Name:";
            this.RebarNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // RebarSizeCheckBox
            // 
            this.structuresExtender.SetAttributeName(this.RebarSizeCheckBox, "RebarSize");
            this.structuresExtender.SetAttributeTypeName(this.RebarSizeCheckBox, null);
            this.RebarSizeCheckBox.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.RebarSizeCheckBox, null);
            this.structuresExtender.SetIsFilter(this.RebarSizeCheckBox, true);
            this.RebarSizeCheckBox.Location = new System.Drawing.Point(3, 29);
            this.RebarSizeCheckBox.Name = "RebarSizeCheckBox";
            this.RebarSizeCheckBox.Size = new System.Drawing.Size(49, 17);
            this.RebarSizeCheckBox.TabIndex = 1;
            this.RebarSizeCheckBox.Text = "Size:";
            this.RebarSizeCheckBox.UseVisualStyleBackColor = true;
            // 
            // RebarGradeCheckBox
            // 
            this.structuresExtender.SetAttributeName(this.RebarGradeCheckBox, "RebarGrade");
            this.structuresExtender.SetAttributeTypeName(this.RebarGradeCheckBox, null);
            this.RebarGradeCheckBox.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.RebarGradeCheckBox, null);
            this.structuresExtender.SetIsFilter(this.RebarGradeCheckBox, true);
            this.RebarGradeCheckBox.Location = new System.Drawing.Point(3, 55);
            this.RebarGradeCheckBox.Name = "RebarGradeCheckBox";
            this.RebarGradeCheckBox.Size = new System.Drawing.Size(58, 17);
            this.RebarGradeCheckBox.TabIndex = 2;
            this.RebarGradeCheckBox.Text = "Grade:";
            this.RebarGradeCheckBox.UseVisualStyleBackColor = true;
            // 
            // RebarBendingRadiusCheckBox
            // 
            this.structuresExtender.SetAttributeName(this.RebarBendingRadiusCheckBox, "RebarBendingRadius");
            this.structuresExtender.SetAttributeTypeName(this.RebarBendingRadiusCheckBox, null);
            this.RebarBendingRadiusCheckBox.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.RebarBendingRadiusCheckBox, null);
            this.structuresExtender.SetIsFilter(this.RebarBendingRadiusCheckBox, true);
            this.RebarBendingRadiusCheckBox.Location = new System.Drawing.Point(3, 88);
            this.RebarBendingRadiusCheckBox.Name = "RebarBendingRadiusCheckBox";
            this.RebarBendingRadiusCheckBox.Size = new System.Drawing.Size(99, 17);
            this.RebarBendingRadiusCheckBox.TabIndex = 3;
            this.RebarBendingRadiusCheckBox.Text = "Bending radius:";
            this.RebarBendingRadiusCheckBox.UseVisualStyleBackColor = true;
            // 
            // RebarNameTextBox
            // 
            this.structuresExtender.SetAttributeName(this.RebarNameTextBox, "RebarName");
            this.structuresExtender.SetAttributeTypeName(this.RebarNameTextBox, "String");
            this.structuresExtender.SetBindPropertyName(this.RebarNameTextBox, null);
            this.RebarNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RebarNameTextBox.Location = new System.Drawing.Point(113, 3);
            this.RebarNameTextBox.Name = "RebarNameTextBox";
            this.RebarNameTextBox.Size = new System.Drawing.Size(409, 20);
            this.RebarNameTextBox.TabIndex = 5;
            // 
            // RebarSizeTextBox
            // 
            this.structuresExtender.SetAttributeName(this.RebarSizeTextBox, "RebarSize");
            this.structuresExtender.SetAttributeTypeName(this.RebarSizeTextBox, "String");
            this.structuresExtender.SetBindPropertyName(this.RebarSizeTextBox, null);
            this.RebarSizeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RebarSizeTextBox.Location = new System.Drawing.Point(113, 29);
            this.RebarSizeTextBox.Name = "RebarSizeTextBox";
            this.RebarSizeTextBox.Size = new System.Drawing.Size(409, 20);
            this.RebarSizeTextBox.TabIndex = 6;
            // 
            // RebarGradeTextBox
            // 
            this.structuresExtender.SetAttributeName(this.RebarGradeTextBox, "RebarGrade");
            this.structuresExtender.SetAttributeTypeName(this.RebarGradeTextBox, "String");
            this.structuresExtender.SetBindPropertyName(this.RebarGradeTextBox, null);
            this.RebarGradeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RebarGradeTextBox.Location = new System.Drawing.Point(113, 55);
            this.RebarGradeTextBox.Name = "RebarGradeTextBox";
            this.RebarGradeTextBox.Size = new System.Drawing.Size(409, 20);
            this.RebarGradeTextBox.TabIndex = 7;
            // 
            // RebarBendingRadiusTextBox
            // 
            this.structuresExtender.SetAttributeName(this.RebarBendingRadiusTextBox, "RebarBendingRadius");
            this.structuresExtender.SetAttributeTypeName(this.RebarBendingRadiusTextBox, "Distance");
            this.structuresExtender.SetBindPropertyName(this.RebarBendingRadiusTextBox, null);
            this.RebarBendingRadiusTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RebarBendingRadiusTextBox.Location = new System.Drawing.Point(113, 88);
            this.RebarBendingRadiusTextBox.Name = "RebarBendingRadiusTextBox";
            this.RebarBendingRadiusTextBox.Size = new System.Drawing.Size(409, 20);
            this.RebarBendingRadiusTextBox.TabIndex = 8;
            // 
            // RebarClassTextBox
            // 
            this.structuresExtender.SetAttributeName(this.RebarClassTextBox, "RebarClass");
            this.structuresExtender.SetAttributeTypeName(this.RebarClassTextBox, "String");
            this.structuresExtender.SetBindPropertyName(this.RebarClassTextBox, null);
            this.RebarClassTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RebarClassTextBox.Location = new System.Drawing.Point(113, 114);
            this.RebarClassTextBox.Name = "RebarClassTextBox";
            this.RebarClassTextBox.Size = new System.Drawing.Size(409, 20);
            this.RebarClassTextBox.TabIndex = 9;
            // 
            // reinforcementCatalog1
            // 
            this.structuresExtender.SetAttributeName(this.reinforcementCatalog1, null);
            this.structuresExtender.SetAttributeTypeName(this.reinforcementCatalog1, null);
            this.reinforcementCatalog1.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.reinforcementCatalog1, null);
            this.reinforcementCatalog1.Location = new System.Drawing.Point(536, 55);
            this.reinforcementCatalog1.Name = "reinforcementCatalog1";
            this.reinforcementCatalog1.SelectedRebarBendingRadius = 0D;
            this.reinforcementCatalog1.SelectedRebarGrade = "";
            this.reinforcementCatalog1.SelectedRebarSize = "";
            this.reinforcementCatalog1.Size = new System.Drawing.Size(88, 27);
            this.reinforcementCatalog1.TabIndex = 10;
            this.reinforcementCatalog1.SelectClicked += new System.EventHandler(this.reinforcementCatalog1_SelectClicked);
            this.reinforcementCatalog1.SelectionDone += new System.EventHandler(this.reinforcementCatalog1_SelectionDone);
            // 
            // groupBox1
            // 
            this.structuresExtender.SetAttributeName(this.groupBox1, null);
            this.structuresExtender.SetAttributeTypeName(this.groupBox1, null);
            this.structuresExtender.SetBindPropertyName(this.groupBox1, null);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(528, 29);
            this.groupBox1.Name = "groupBox1";
            this.tableLayoutPanel4.SetRowSpan(this.groupBox1, 3);
            this.groupBox1.Size = new System.Drawing.Size(2, 79);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // RebarSpacingTextBox
            // 
            this.structuresExtender.SetAttributeName(this.RebarSpacingTextBox, "RebarSpacing");
            this.structuresExtender.SetAttributeTypeName(this.RebarSpacingTextBox, "DistanceList");
            this.structuresExtender.SetBindPropertyName(this.RebarSpacingTextBox, null);
            this.RebarSpacingTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RebarSpacingTextBox.Location = new System.Drawing.Point(113, 140);
            this.RebarSpacingTextBox.Name = "RebarSpacingTextBox";
            this.RebarSpacingTextBox.Size = new System.Drawing.Size(409, 20);
            this.RebarSpacingTextBox.TabIndex = 13;
            this.RebarSpacingTextBox.Text = "30*200";
            // 
            // RebarSpacingCheckBox
            // 
            this.structuresExtender.SetAttributeName(this.RebarSpacingCheckBox, "RebarSpacing");
            this.structuresExtender.SetAttributeTypeName(this.RebarSpacingCheckBox, null);
            this.RebarSpacingCheckBox.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.RebarSpacingCheckBox, null);
            this.structuresExtender.SetIsFilter(this.RebarSpacingCheckBox, true);
            this.RebarSpacingCheckBox.Location = new System.Drawing.Point(3, 140);
            this.RebarSpacingCheckBox.Name = "RebarSpacingCheckBox";
            this.RebarSpacingCheckBox.Size = new System.Drawing.Size(68, 17);
            this.RebarSpacingCheckBox.TabIndex = 12;
            this.RebarSpacingCheckBox.Text = "Spacing:";
            this.RebarSpacingCheckBox.UseVisualStyleBackColor = true;
            // 
            // okApplyModifyGetOnOffCancel1
            // 
            this.structuresExtender.SetAttributeName(this.okApplyModifyGetOnOffCancel1, null);
            this.structuresExtender.SetAttributeTypeName(this.okApplyModifyGetOnOffCancel1, null);
            this.structuresExtender.SetBindPropertyName(this.okApplyModifyGetOnOffCancel1, null);
            this.okApplyModifyGetOnOffCancel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okApplyModifyGetOnOffCancel1.Location = new System.Drawing.Point(3, 380);
            this.okApplyModifyGetOnOffCancel1.Name = "okApplyModifyGetOnOffCancel1";
            this.okApplyModifyGetOnOffCancel1.Size = new System.Drawing.Size(647, 27);
            this.okApplyModifyGetOnOffCancel1.TabIndex = 3;
            this.okApplyModifyGetOnOffCancel1.OkClicked += new System.EventHandler(this.okApplyModifyGetOnOffCancel1_OkClicked);
            this.okApplyModifyGetOnOffCancel1.ApplyClicked += new System.EventHandler(this.okApplyModifyGetOnOffCancel1_ApplyClicked);
            this.okApplyModifyGetOnOffCancel1.ModifyClicked += new System.EventHandler(this.okApplyModifyGetOnOffCancel1_ModifyClicked);
            this.okApplyModifyGetOnOffCancel1.GetClicked += new System.EventHandler(this.okApplyModifyGetOnOffCancel1_GetClicked);
            this.okApplyModifyGetOnOffCancel1.OnOffClicked += new System.EventHandler(this.okApplyModifyGetOnOffCancel1_OnOffClicked);
            this.okApplyModifyGetOnOffCancel1.CancelClicked += new System.EventHandler(this.okApplyModifyGetOnOffCancel1_CancelClicked);
            // 
            // tableLayoutPanel2
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel2, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel2, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel2, null);
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.saveLoad2, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // saveLoad2
            // 
            this.structuresExtender.SetAttributeName(this.saveLoad2, null);
            this.structuresExtender.SetAttributeTypeName(this.saveLoad2, null);
            this.saveLoad2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.structuresExtender.SetBindPropertyName(this.saveLoad2, null);
            this.tableLayoutPanel2.SetColumnSpan(this.saveLoad2, 4);
            this.saveLoad2.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveLoad2.HelpKeyword = "";
            this.saveLoad2.HelpUrl = "";
            this.saveLoad2.Location = new System.Drawing.Point(3, 3);
            this.saveLoad2.Name = "saveLoad2";
            this.saveLoad2.SaveAsText = "";
            this.saveLoad2.Size = new System.Drawing.Size(194, 14);
            this.saveLoad2.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.structuresExtender.SetAttributeName(this.tabControl2, null);
            this.structuresExtender.SetAttributeTypeName(this.tabControl2, null);
            this.structuresExtender.SetBindPropertyName(this.tabControl2, null);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(3, -6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(90, 1);
            this.tabControl2.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.structuresExtender.SetAttributeName(this.tabPage3, null);
            this.structuresExtender.SetAttributeTypeName(this.tabPage3, null);
            this.structuresExtender.SetBindPropertyName(this.tabPage3, null);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(82, 0);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.structuresExtender.SetAttributeName(this.tabPage4, null);
            this.structuresExtender.SetAttributeTypeName(this.tabPage4, null);
            this.structuresExtender.SetBindPropertyName(this.tabPage4, null);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(82, 0);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ReinforcedBeamForm
            // 
            this.structuresExtender.SetAttributeName(this, null);
            this.structuresExtender.SetAttributeTypeName(this, null);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(653, 410);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ReinforcedBeamForm";
            this.Text = "ReinforcedBeamForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.BeamPropertiesTabPage1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ReinforcementPropertiesTabPage.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Tekla.Structures.Dialog.UIControls.SaveLoad saveLoad1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage BeamPropertiesTabPage1;
        private System.Windows.Forms.TabPage ReinforcementPropertiesTabPage;
        private Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel okApplyModifyGetOnOffCancel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Tekla.Structures.Dialog.UIControls.SaveLoad saveLoad2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox BeamNameCheckBox;
        private System.Windows.Forms.TextBox BeamNameTextBox;
        private System.Windows.Forms.CheckBox BeamClassCheckBox4;
        private System.Windows.Forms.CheckBox BeamProfileCheckBox1;
        private System.Windows.Forms.CheckBox BeamMaterialCheckBox;
        private System.Windows.Forms.CheckBox BeamFinishCheckBox;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog profileCatalog1;
        private System.Windows.Forms.TextBox BeamProfileTextBox;
        private System.Windows.Forms.TextBox BeamMaterialTextBox;
        private System.Windows.Forms.TextBox BeamFinishTextBox;
        private System.Windows.Forms.TextBox BeamClassTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox RebarNameCheckBox;
        private System.Windows.Forms.CheckBox RebarClassCheckBox;
        private System.Windows.Forms.CheckBox RebarSizeCheckBox;
        private System.Windows.Forms.CheckBox RebarGradeCheckBox;
        private System.Windows.Forms.CheckBox RebarBendingRadiusCheckBox;
        private System.Windows.Forms.TextBox RebarNameTextBox;
        private System.Windows.Forms.TextBox RebarSizeTextBox;
        private System.Windows.Forms.TextBox RebarGradeTextBox;
        private System.Windows.Forms.TextBox RebarBendingRadiusTextBox;
        private System.Windows.Forms.TextBox RebarClassTextBox;
        private Tekla.Structures.Dialog.UIControls.ReinforcementCatalog reinforcementCatalog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox RebarSpacingTextBox;
        private System.Windows.Forms.CheckBox RebarSpacingCheckBox;
    }
}