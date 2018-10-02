namespace SplitPolygonWeld
{
    /// <summary>
    /// Form of the application.
    /// </summary>
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
            this.splitPolygonWeldButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // splitPolygonWeldButton
            // 
            this.splitPolygonWeldButton.Location = new System.Drawing.Point(41, 26);
            this.splitPolygonWeldButton.Name = "splitPolygonWeldButton";
            this.splitPolygonWeldButton.Size = new System.Drawing.Size(191, 24);
            this.splitPolygonWeldButton.TabIndex = 0;
            this.splitPolygonWeldButton.Text = "Split polygon weld";
            this.splitPolygonWeldButton.UseVisualStyleBackColor = true;
            this.splitPolygonWeldButton.Click += new System.EventHandler(this.splitPolygonWeldButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 76);
            this.Controls.Add(this.splitPolygonWeldButton);
            this.Name = "MainForm";
            this.Text = "Split Polygon Weld";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button splitPolygonWeldButton;
    }
}

