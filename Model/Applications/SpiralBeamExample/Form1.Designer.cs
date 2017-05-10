namespace SpiralBeamExample
{
    partial class SpiralBeamForm
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
            this.CreateSpiralBeam = new System.Windows.Forms.Button();
            this.ModifySpiralBeam = new System.Windows.Forms.Button();
            this.DeleteSpiralBeam = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateSpiralBeam
            // 
            this.CreateSpiralBeam.AutoSize = true;
            this.CreateSpiralBeam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateSpiralBeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.CreateSpiralBeam.Location = new System.Drawing.Point(3, 53);
            this.CreateSpiralBeam.Name = "CreateSpiralBeam";
            this.CreateSpiralBeam.Size = new System.Drawing.Size(250, 57);
            this.CreateSpiralBeam.TabIndex = 0;
            this.CreateSpiralBeam.Text = "Create spiral beam";
            this.CreateSpiralBeam.UseVisualStyleBackColor = true;
            this.CreateSpiralBeam.Click += new System.EventHandler(this.CreateSpiralBeam_Click);
            // 
            // ModifySpiralBeam
            // 
            this.ModifySpiralBeam.AutoSize = true;
            this.ModifySpiralBeam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ModifySpiralBeam.Enabled = false;
            this.ModifySpiralBeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.ModifySpiralBeam.Location = new System.Drawing.Point(3, 116);
            this.ModifySpiralBeam.Name = "ModifySpiralBeam";
            this.ModifySpiralBeam.Size = new System.Drawing.Size(250, 57);
            this.ModifySpiralBeam.TabIndex = 1;
            this.ModifySpiralBeam.Text = "Modify spiral beam";
            this.ModifySpiralBeam.UseVisualStyleBackColor = true;
            this.ModifySpiralBeam.Click += new System.EventHandler(this.ModifySpiralBeam_Click);
            // 
            // DeleteSpiralBeam
            // 
            this.DeleteSpiralBeam.AutoSize = true;
            this.DeleteSpiralBeam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteSpiralBeam.Enabled = false;
            this.DeleteSpiralBeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.DeleteSpiralBeam.Location = new System.Drawing.Point(3, 179);
            this.DeleteSpiralBeam.Name = "DeleteSpiralBeam";
            this.DeleteSpiralBeam.Size = new System.Drawing.Size(250, 57);
            this.DeleteSpiralBeam.TabIndex = 2;
            this.DeleteSpiralBeam.Text = "Delete spiral beam";
            this.DeleteSpiralBeam.UseVisualStyleBackColor = true;
            this.DeleteSpiralBeam.Click += new System.EventHandler(this.DeleteSpiralBeam_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.DeleteSpiralBeam);
            this.panel1.Controls.Add(this.CreateSpiralBeam);
            this.panel1.Controls.Add(this.ModifySpiralBeam);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 240);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Spiral beam example";
            // 
            // SpiralBeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 264);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SpiralBeamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Spiral beam example";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateSpiralBeam;
        private System.Windows.Forms.Button ModifySpiralBeam;
        private System.Windows.Forms.Button DeleteSpiralBeam;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}

