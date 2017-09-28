namespace BeamPlugin
{
    partial class BeamPluginForm
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
            this.okApplyModifyGetOnOffCancel1 = new Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel();
            this.saveLoad1 = new Tekla.Structures.Dialog.UIControls.SaveLoad();
            this.textBoxLengthFactor = new System.Windows.Forms.TextBox();
            this.LengthFactor = new System.Windows.Forms.Label();
            this.textBoxProfile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okApplyModifyGetOnOffCancel1
            // 
            this.structuresExtender.SetAttributeName(this.okApplyModifyGetOnOffCancel1, null);
            this.structuresExtender.SetAttributeTypeName(this.okApplyModifyGetOnOffCancel1, null);
            this.structuresExtender.SetBindPropertyName(this.okApplyModifyGetOnOffCancel1, null);
            this.okApplyModifyGetOnOffCancel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okApplyModifyGetOnOffCancel1.Location = new System.Drawing.Point(0, 246);
            this.okApplyModifyGetOnOffCancel1.Name = "okApplyModifyGetOnOffCancel1";
            this.okApplyModifyGetOnOffCancel1.Size = new System.Drawing.Size(519, 29);
            this.okApplyModifyGetOnOffCancel1.TabIndex = 0;
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
            this.saveLoad1.Name = "saveLoad1";
            this.saveLoad1.SaveAsText = "";
            this.saveLoad1.Size = new System.Drawing.Size(519, 43);
            this.saveLoad1.TabIndex = 1;
            this.saveLoad1.UserDefinedHelpFilePath = null;
            // 
            // textBoxLengthFactor
            // 
            this.structuresExtender.SetAttributeName(this.textBoxLengthFactor, "LengthFactor");
            this.structuresExtender.SetAttributeTypeName(this.textBoxLengthFactor, "Double");
            this.structuresExtender.SetBindPropertyName(this.textBoxLengthFactor, null);
            this.textBoxLengthFactor.Location = new System.Drawing.Point(303, 138);
            this.textBoxLengthFactor.Name = "textBoxLengthFactor";
            this.textBoxLengthFactor.Size = new System.Drawing.Size(100, 20);
            this.textBoxLengthFactor.TabIndex = 2;
            // 
            // LengthFactor
            // 
            this.structuresExtender.SetAttributeName(this.LengthFactor, null);
            this.structuresExtender.SetAttributeTypeName(this.LengthFactor, null);
            this.LengthFactor.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.LengthFactor, null);
            this.LengthFactor.Location = new System.Drawing.Point(120, 141);
            this.LengthFactor.Name = "LengthFactor";
            this.LengthFactor.Size = new System.Drawing.Size(70, 13);
            this.LengthFactor.TabIndex = 3;
            this.LengthFactor.Text = "Length factor";
            // 
            // textBoxProfile
            // 
            this.structuresExtender.SetAttributeName(this.textBoxProfile, "Profile");
            this.structuresExtender.SetAttributeTypeName(this.textBoxProfile, "String");
            this.structuresExtender.SetBindPropertyName(this.textBoxProfile, null);
            this.textBoxProfile.Location = new System.Drawing.Point(303, 90);
            this.textBoxProfile.Name = "textBoxProfile";
            this.textBoxProfile.Size = new System.Drawing.Size(100, 20);
            this.textBoxProfile.TabIndex = 2;
            // 
            // label1
            // 
            this.structuresExtender.SetAttributeName(this.label1, null);
            this.structuresExtender.SetAttributeTypeName(this.label1, null);
            this.label1.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label1, null);
            this.label1.Location = new System.Drawing.Point(120, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Profile";
            // 
            // BeamPluginForm
            // 
            this.structuresExtender.SetAttributeName(this, null);
            this.structuresExtender.SetAttributeTypeName(this, null);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(519, 275);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxProfile);
            this.Controls.Add(this.LengthFactor);
            this.Controls.Add(this.textBoxLengthFactor);
            this.Controls.Add(this.saveLoad1);
            this.Controls.Add(this.okApplyModifyGetOnOffCancel1);
            this.Name = "BeamPluginForm";
            this.Text = "BeamPluginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel okApplyModifyGetOnOffCancel1;
        private Tekla.Structures.Dialog.UIControls.SaveLoad saveLoad1;
        private System.Windows.Forms.TextBox textBoxLengthFactor;
        private System.Windows.Forms.Label LengthFactor;
        private System.Windows.Forms.TextBox textBoxProfile;
        private System.Windows.Forms.Label label1;

    }
}

