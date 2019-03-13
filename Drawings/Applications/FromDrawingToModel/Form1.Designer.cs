namespace FromDrawingToModel
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
            this.PickObjectInDrawing = new System.Windows.Forms.Button();
            this.Quit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.modelObjectTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PickObjectInDrawing
            // 
            this.PickObjectInDrawing.Location = new System.Drawing.Point(652, 32);
            this.PickObjectInDrawing.Name = "PickObjectInDrawing";
            this.PickObjectInDrawing.Size = new System.Drawing.Size(132, 32);
            this.PickObjectInDrawing.TabIndex = 0;
            this.PickObjectInDrawing.Text = "Pick object in drawing";
            this.PickObjectInDrawing.UseVisualStyleBackColor = true;
            this.PickObjectInDrawing.Click += new System.EventHandler(this.PickObjectInDrawing_Click);
            // 
            // Quit
            // 
            this.Quit.Location = new System.Drawing.Point(652, 382);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(132, 32);
            this.Quit.TabIndex = 3;
            this.Quit.Text = "Close";
            this.Quit.UseVisualStyleBackColor = true;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.modelObjectTextBox);
            this.groupBox1.Location = new System.Drawing.Point(7, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 407);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Model object info";
            // 
            // modelObjectTextBox
            // 
            this.modelObjectTextBox.Location = new System.Drawing.Point(6, 19);
            this.modelObjectTextBox.Multiline = true;
            this.modelObjectTextBox.Name = "modelObjectTextBox";
            this.modelObjectTextBox.Size = new System.Drawing.Size(627, 382);
            this.modelObjectTextBox.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 429);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.PickObjectInDrawing);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PickObjectInDrawing;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox modelObjectTextBox;
    }
}

