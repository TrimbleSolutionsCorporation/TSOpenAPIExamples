namespace FormPlugin
{
    partial class MainForm
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
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.heightLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.modifyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // heightTextBox
            // 
            this.structuresExtender.SetAttributeName(this.heightTextBox, "height");
            this.structuresExtender.SetAttributeTypeName(this.heightTextBox, "Distance");
            this.structuresExtender.SetBindPropertyName(this.heightTextBox, null);
            this.heightTextBox.Location = new System.Drawing.Point(67, 27);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(100, 20);
            this.heightTextBox.TabIndex = 0;
            // 
            // heightLabel
            // 
            this.structuresExtender.SetAttributeName(this.heightLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.heightLabel, null);
            this.heightLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.heightLabel, null);
            this.heightLabel.Location = new System.Drawing.Point(23, 30);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(38, 13);
            this.heightLabel.TabIndex = 1;
            this.heightLabel.Text = "Height";
            // 
            // okButton
            // 
            this.structuresExtender.SetAttributeName(this.okButton, null);
            this.structuresExtender.SetAttributeTypeName(this.okButton, null);
            this.structuresExtender.SetBindPropertyName(this.okButton, null);
            this.okButton.Location = new System.Drawing.Point(26, 138);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // modifyButton
            // 
            this.structuresExtender.SetAttributeName(this.modifyButton, null);
            this.structuresExtender.SetAttributeTypeName(this.modifyButton, null);
            this.structuresExtender.SetBindPropertyName(this.modifyButton, null);
            this.modifyButton.Location = new System.Drawing.Point(107, 138);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(75, 23);
            this.modifyButton.TabIndex = 3;
            this.modifyButton.Text = "Modify";
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // MainForm
            // 
            this.structuresExtender.SetAttributeName(this, null);
            this.structuresExtender.SetAttributeTypeName(this, null);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(317, 173);
            this.Controls.Add(this.modifyButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.heightTextBox);
            this.Name = "MainForm";
            this.Text = "Plugin with Forms";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button modifyButton;
    }
}
