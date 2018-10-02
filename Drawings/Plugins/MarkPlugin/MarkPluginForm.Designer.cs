using System.Windows.Forms;

namespace MarkPlugin
{
    partial class MarkPluginForm : Tekla.Structures.Dialog.PluginFormBase
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
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.angleLabel = new System.Windows.Forms.Label();
            this.txtColorValue = new System.Windows.Forms.TextBox();
            this.OkApplyModifyGetOnOffCancel = new Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel();
            this.SaveLoadSaveAs = new Tekla.Structures.Dialog.UIControls.SaveLoad();
            this.prefixLabel = new System.Windows.Forms.Label();
            this.angleSlider = new System.Windows.Forms.TrackBar();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.angleSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPrefix
            // 
            this.structuresExtender.SetAttributeName(this.txtPrefix, "text");
            this.structuresExtender.SetAttributeTypeName(this.txtPrefix, "String");
            this.structuresExtender.SetBindPropertyName(this.txtPrefix, null);
            this.txtPrefix.Location = new System.Drawing.Point(47, 49);
            this.txtPrefix.Multiline = true;
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(165, 20);
            this.txtPrefix.TabIndex = 0;
            // 
            // cmbColor
            // 
            this.structuresExtender.SetAttributeName(this.cmbColor, null);
            this.structuresExtender.SetAttributeTypeName(this.cmbColor, null);
            this.structuresExtender.SetBindPropertyName(this.cmbColor, null);
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(47, 75);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(121, 21);
            this.cmbColor.TabIndex = 1;
            this.cmbColor.SelectionChangeCommitted += new System.EventHandler(this.cmbColor_SelectionChanged);
            // 
            // txtAngle
            // 
            this.structuresExtender.SetAttributeName(this.txtAngle, "angle");
            this.structuresExtender.SetAttributeTypeName(this.txtAngle, "Double");
            this.structuresExtender.SetBindPropertyName(this.txtAngle, null);
            this.txtAngle.Location = new System.Drawing.Point(174, 102);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(38, 20);
            this.txtAngle.TabIndex = 2;
            this.txtAngle.Text = "0";
            // 
            // colorLabel
            // 
            this.structuresExtender.SetAttributeName(this.colorLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.colorLabel, null);
            this.colorLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.colorLabel, null);
            this.colorLabel.Location = new System.Drawing.Point(9, 78);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(34, 13);
            this.colorLabel.TabIndex = 9;
            this.colorLabel.Text = "Color:";
            // 
            // angleLabel
            // 
            this.structuresExtender.SetAttributeName(this.angleLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.angleLabel, null);
            this.angleLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.angleLabel, null);
            this.angleLabel.Location = new System.Drawing.Point(6, 105);
            this.angleLabel.Name = "angleLabel";
            this.angleLabel.Size = new System.Drawing.Size(37, 13);
            this.angleLabel.TabIndex = 10;
            this.angleLabel.Text = "Angle:";
            // 
            // txtColorValue
            // 
            this.structuresExtender.SetAttributeName(this.txtColorValue, "color");
            this.structuresExtender.SetAttributeTypeName(this.txtColorValue, "Integer");
            this.structuresExtender.SetBindPropertyName(this.txtColorValue, "Text");
            this.txtColorValue.Location = new System.Drawing.Point(174, 75);
            this.txtColorValue.Name = "txtColorValue";
            this.txtColorValue.ReadOnly = true;
            this.txtColorValue.Size = new System.Drawing.Size(38, 20);
            this.txtColorValue.TabIndex = 14;
            this.txtColorValue.TextChanged += new System.EventHandler(this.txtColorHelper_TextChanged);
            // 
            // OkApplyModifyGetOnOffCancel
            // 
            this.structuresExtender.SetAttributeName(this.OkApplyModifyGetOnOffCancel, null);
            this.structuresExtender.SetAttributeTypeName(this.OkApplyModifyGetOnOffCancel, null);
            this.structuresExtender.SetBindPropertyName(this.OkApplyModifyGetOnOffCancel, null);
            this.OkApplyModifyGetOnOffCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OkApplyModifyGetOnOffCancel.Location = new System.Drawing.Point(0, 146);
            this.OkApplyModifyGetOnOffCancel.Name = "OkApplyModifyGetOnOffCancel";
            this.OkApplyModifyGetOnOffCancel.Size = new System.Drawing.Size(519, 29);
            this.OkApplyModifyGetOnOffCancel.TabIndex = 4;
            this.OkApplyModifyGetOnOffCancel.OkClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_AcceptClicked);
            this.OkApplyModifyGetOnOffCancel.ApplyClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_ApplyClicked);
            this.OkApplyModifyGetOnOffCancel.ModifyClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_ModifyClicked);
            this.OkApplyModifyGetOnOffCancel.GetClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_GetClicked);
            this.OkApplyModifyGetOnOffCancel.OnOffClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_OnOffClicked);
            this.OkApplyModifyGetOnOffCancel.CancelClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_CancelClicked);
            // 
            // SaveLoadSaveAs
            // 
            this.structuresExtender.SetAttributeName(this.SaveLoadSaveAs, null);
            this.structuresExtender.SetAttributeTypeName(this.SaveLoadSaveAs, null);
            this.SaveLoadSaveAs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.structuresExtender.SetBindPropertyName(this.SaveLoadSaveAs, null);
            this.SaveLoadSaveAs.Dock = System.Windows.Forms.DockStyle.Top;
            this.SaveLoadSaveAs.HelpFileType = Tekla.Structures.Dialog.UIControls.SaveLoad.HelpFileTypeEnum.General;
            this.SaveLoadSaveAs.HelpKeyword = "";
            this.SaveLoadSaveAs.HelpUrl = "";
            this.SaveLoadSaveAs.Location = new System.Drawing.Point(0, 0);
            this.SaveLoadSaveAs.Name = "SaveLoadSaveAs";
            this.SaveLoadSaveAs.SaveAsText = "";
            this.SaveLoadSaveAs.Size = new System.Drawing.Size(519, 43);
            this.SaveLoadSaveAs.TabIndex = 16;
            this.SaveLoadSaveAs.UserDefinedHelpFilePath = null;
            // 
            // prefixLabel
            // 
            this.structuresExtender.SetAttributeName(this.prefixLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.prefixLabel, null);
            this.prefixLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.prefixLabel, null);
            this.prefixLabel.Location = new System.Drawing.Point(7, 52);
            this.prefixLabel.Name = "prefixLabel";
            this.prefixLabel.Size = new System.Drawing.Size(36, 13);
            this.prefixLabel.TabIndex = 17;
            this.prefixLabel.Text = "Prefix:";
            // 
            // angleSlider
            // 
            this.structuresExtender.SetAttributeName(this.angleSlider, null);
            this.structuresExtender.SetAttributeTypeName(this.angleSlider, null);
            this.structuresExtender.SetBindPropertyName(this.angleSlider, null);
            this.angleSlider.Location = new System.Drawing.Point(49, 102);
            this.angleSlider.Maximum = 180;
            this.angleSlider.Name = "angleSlider";
            this.angleSlider.Size = new System.Drawing.Size(112, 45);
            this.angleSlider.TabIndex = 3;
            this.angleSlider.Scroll += new System.EventHandler(this.angleSlider_Scroll);
            // 
            // MarkPluginForm
            // 
            this.structuresExtender.SetAttributeName(this, null);
            this.structuresExtender.SetAttributeTypeName(this, null);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(519, 175);
            this.Controls.Add(this.angleSlider);
            this.Controls.Add(this.prefixLabel);
            this.Controls.Add(this.SaveLoadSaveAs);
            this.Controls.Add(this.OkApplyModifyGetOnOffCancel);
            this.Controls.Add(this.txtColorValue);
            this.Controls.Add(this.angleLabel);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.txtAngle);
            this.Controls.Add(this.cmbColor);
            this.Controls.Add(this.txtPrefix);
            this.Name = "MarkPluginForm";
            this.Text = "MarkPluginForm";
            ((System.ComponentModel.ISupportInitialize)(this.angleSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrefix;
    private ComboBox cmbColor;
    private TextBox txtAngle;
    private Label colorLabel;
    private Label angleLabel;
        private TextBox txtColorValue;
        private Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel OkApplyModifyGetOnOffCancel;
        private Tekla.Structures.Dialog.UIControls.SaveLoad SaveLoadSaveAs;
        private Label prefixLabel;
        private TrackBar angleSlider;
        private BindingSource bindingSource1;
    }
}
