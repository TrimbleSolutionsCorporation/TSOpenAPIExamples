namespace BeamApplication
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.saveLoad1 = new Tekla.Structures.Dialog.UIControls.SaveLoad();
            this.createApplyCancel1 = new Tekla.Structures.Dialog.UIControls.CreateApplyCancel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.structuresExtender.SetAttributeName(this.label1, null);
            this.structuresExtender.SetAttributeTypeName(this.label1, null);
            this.label1.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label1, null);
            this.label1.Location = new System.Drawing.Point(12, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Profile String:";
            // 
            // textBox1
            // 
            this.structuresExtender.SetAttributeName(this.textBox1, "Profile");
            this.structuresExtender.SetAttributeTypeName(this.textBox1, "String");
            this.structuresExtender.SetBindPropertyName(this.textBox1, null);
            this.textBox1.Location = new System.Drawing.Point(108, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(245, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "HEA300";
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
            this.saveLoad1.Size = new System.Drawing.Size(429, 43);
            this.saveLoad1.TabIndex = 3;
            this.saveLoad1.UserDefinedHelpFilePath = null;
            // 
            // createApplyCancel1
            // 
            this.structuresExtender.SetAttributeName(this.createApplyCancel1, null);
            this.structuresExtender.SetAttributeTypeName(this.createApplyCancel1, null);
            this.structuresExtender.SetBindPropertyName(this.createApplyCancel1, null);
            this.createApplyCancel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.createApplyCancel1.Location = new System.Drawing.Point(0, 122);
            this.createApplyCancel1.Name = "createApplyCancel1";
            this.createApplyCancel1.Size = new System.Drawing.Size(429, 30);
            this.createApplyCancel1.TabIndex = 4;
            this.createApplyCancel1.CreateClicked += new System.EventHandler(this.createApplyCancel1_CreateClicked);
            this.createApplyCancel1.ApplyClicked += new System.EventHandler(this.createApplyCancel1_ApplyClicked);
            this.createApplyCancel1.CancelClicked += new System.EventHandler(this.createApplyCancel1_CancelClicked);
            // 
            // Form1
            // 
            this.structuresExtender.SetAttributeName(this, null);
            this.structuresExtender.SetAttributeTypeName(this, null);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(429, 152);
            this.Controls.Add(this.createApplyCancel1);
            this.Controls.Add(this.saveLoad1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "BeamApplication";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private Tekla.Structures.Dialog.UIControls.SaveLoad saveLoad1;
        private Tekla.Structures.Dialog.UIControls.CreateApplyCancel createApplyCancel1;
    }
}

