namespace ExportComponents
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
            this.comboBoxFile = new System.Windows.Forms.ComboBox();
            this.labelFile = new System.Windows.Forms.Label();
            this.labelFormat = new System.Windows.Forms.Label();
            this.comboBoxFormat = new System.Windows.Forms.ComboBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxFile
            // 
            this.comboBoxFile.Enabled = false;
            this.comboBoxFile.FormattingEnabled = true;
            this.comboBoxFile.Location = new System.Drawing.Point(435, 254);
            this.comboBoxFile.Name = "comboBoxFile";
            this.comboBoxFile.Size = new System.Drawing.Size(414, 39);
            this.comboBoxFile.TabIndex = 3;
            this.comboBoxFile.SelectedIndexChanged += new System.EventHandler(this.comboBoxFile_SelectedIndexChanged);
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelFile.Location = new System.Drawing.Point(86, 261);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(247, 32);
            this.labelFile.TabIndex = 2;
            this.labelFile.Text = "Attribute Filename";
            // 
            // labelFormat
            // 
            this.labelFormat.AutoSize = true;
            this.labelFormat.Location = new System.Drawing.Point(86, 103);
            this.labelFormat.Name = "labelFormat";
            this.labelFormat.Size = new System.Drawing.Size(193, 32);
            this.labelFormat.TabIndex = 4;
            this.labelFormat.Text = "Export Format";
            // 
            // comboBoxFormat
            // 
            this.comboBoxFormat.FormattingEnabled = true;
            this.comboBoxFormat.Items.AddRange(new object[] {
            "CAD",
            "DGN",
            "DWG/DXF",
            "FEM",
            "IFC"});
            this.comboBoxFormat.Location = new System.Drawing.Point(435, 100);
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.Size = new System.Drawing.Size(414, 39);
            this.comboBoxFormat.TabIndex = 5;
            this.comboBoxFormat.SelectedIndexChanged += new System.EventHandler(this.comboBoxFormat_SelectedIndexChanged);
            // 
            // buttonExport
            // 
            this.buttonExport.Enabled = false;
            this.buttonExport.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.buttonExport.Location = new System.Drawing.Point(92, 395);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(241, 60);
            this.buttonExport.TabIndex = 6;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 537);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.comboBoxFormat);
            this.Controls.Add(this.labelFormat);
            this.Controls.Add(this.comboBoxFile);
            this.Controls.Add(this.labelFile);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "ExportComponents";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxFile;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label labelFormat;
        private System.Windows.Forms.ComboBox comboBoxFormat;
        private System.Windows.Forms.Button buttonExport;
    }
}

