namespace WeldMarkExample
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
            this.buttonReady = new System.Windows.Forms.Button();
            this.buttonCreatesPlatesWeld = new System.Windows.Forms.Button();
            this.buttonCreatesAssDrawing = new System.Windows.Forms.Button();
            this.buttonGetWeldInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(505, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create empty model in TeklaStructures";
            // 
            // buttonReady
            // 
            this.buttonReady.Location = new System.Drawing.Point(701, 51);
            this.buttonReady.Name = "buttonReady";
            this.buttonReady.Size = new System.Drawing.Size(176, 54);
            this.buttonReady.TabIndex = 1;
            this.buttonReady.Text = "Ready!";
            this.buttonReady.UseVisualStyleBackColor = true;
            this.buttonReady.Click += new System.EventHandler(this.buttonReady_Click);
            // 
            // buttonCreatesPlatesWeld
            // 
            this.buttonCreatesPlatesWeld.Enabled = false;
            this.buttonCreatesPlatesWeld.Location = new System.Drawing.Point(80, 168);
            this.buttonCreatesPlatesWeld.Name = "buttonCreatesPlatesWeld";
            this.buttonCreatesPlatesWeld.Size = new System.Drawing.Size(490, 50);
            this.buttonCreatesPlatesWeld.TabIndex = 2;
            this.buttonCreatesPlatesWeld.Text = "Creates plates and weld in model";
            this.buttonCreatesPlatesWeld.UseVisualStyleBackColor = true;
            this.buttonCreatesPlatesWeld.Click += new System.EventHandler(this.buttonCreatesPlatesWeld_Click);
            // 
            // buttonCreatesAssDrawing
            // 
            this.buttonCreatesAssDrawing.Enabled = false;
            this.buttonCreatesAssDrawing.Location = new System.Drawing.Point(80, 270);
            this.buttonCreatesAssDrawing.Name = "buttonCreatesAssDrawing";
            this.buttonCreatesAssDrawing.Size = new System.Drawing.Size(490, 61);
            this.buttonCreatesAssDrawing.TabIndex = 3;
            this.buttonCreatesAssDrawing.Text = "Creates assembly drawing with weld";
            this.buttonCreatesAssDrawing.UseVisualStyleBackColor = true;
            this.buttonCreatesAssDrawing.Click += new System.EventHandler(this.buttonCreatesAssDrawing_Click);
            // 
            // buttonGetWeldInfo
            // 
            this.buttonGetWeldInfo.Enabled = false;
            this.buttonGetWeldInfo.Location = new System.Drawing.Point(80, 365);
            this.buttonGetWeldInfo.Name = "buttonGetWeldInfo";
            this.buttonGetWeldInfo.Size = new System.Drawing.Size(490, 97);
            this.buttonGetWeldInfo.TabIndex = 4;
            this.buttonGetWeldInfo.Text = "Gets weld and weld mark info from drawing views";
            this.buttonGetWeldInfo.UseVisualStyleBackColor = true;
            this.buttonGetWeldInfo.Click += new System.EventHandler(this.buttonGetWeldInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 535);
            this.Controls.Add(this.buttonGetWeldInfo);
            this.Controls.Add(this.buttonCreatesAssDrawing);
            this.Controls.Add(this.buttonCreatesPlatesWeld);
            this.Controls.Add(this.buttonReady);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Weld Mark Example";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonReady;
        private System.Windows.Forms.Button buttonCreatesPlatesWeld;
        private System.Windows.Forms.Button buttonCreatesAssDrawing;
        private System.Windows.Forms.Button buttonGetWeldInfo;
    }
}

