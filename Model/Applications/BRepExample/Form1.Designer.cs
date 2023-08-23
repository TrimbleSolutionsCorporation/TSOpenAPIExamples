namespace BRepExample
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.validateResult = new System.Windows.Forms.TextBox();
            this.shapeSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.xPos = new System.Windows.Forms.TextBox();
            this.yPos = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.shapeType = new System.Windows.Forms.Label();
            this.shapeTypeBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Insert cube into catalog";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(25, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(219, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Validate cube shape";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // validateResult
            // 
            this.validateResult.Location = new System.Drawing.Point(65, 59);
            this.validateResult.Name = "validateResult";
            this.validateResult.Size = new System.Drawing.Size(179, 20);
            this.validateResult.TabIndex = 2;
            // 
            // shapeSize
            // 
            this.shapeSize.Location = new System.Drawing.Point(200, 16);
            this.shapeSize.Name = "shapeSize";
            this.shapeSize.Size = new System.Drawing.Size(56, 20);
            this.shapeSize.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cube side length in mm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "X-position";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Y-position";
            // 
            // xPos
            // 
            this.xPos.Location = new System.Drawing.Point(80, 50);
            this.xPos.Name = "xPos";
            this.xPos.Size = new System.Drawing.Size(41, 20);
            this.xPos.TabIndex = 7;
            // 
            // yPos
            // 
            this.yPos.Location = new System.Drawing.Point(202, 53);
            this.yPos.Name = "yPos";
            this.yPos.Size = new System.Drawing.Size(41, 20);
            this.yPos.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(24, 111);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(219, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Modify shape in catalog to pyramid";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(24, 91);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(219, 22);
            this.button4.TabIndex = 10;
            this.button4.Text = "Add current shape to model";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Result";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 155);
            this.panel1.TabIndex = 13;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(24, 75);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(219, 23);
            this.button5.TabIndex = 16;
            this.button5.Text = "Insert CUT cube into catalog";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.shapeType);
            this.panel2.Controls.Add(this.shapeTypeBox);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.xPos);
            this.panel2.Controls.Add(this.yPos);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(12, 166);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(286, 129);
            this.panel2.TabIndex = 14;
            // 
            // shapeType
            // 
            this.shapeType.AutoSize = true;
            this.shapeType.Location = new System.Drawing.Point(21, 22);
            this.shapeType.Name = "shapeType";
            this.shapeType.Size = new System.Drawing.Size(73, 13);
            this.shapeType.TabIndex = 12;
            this.shapeType.Text = "Current shape";
            // 
            // shapeTypeBox
            // 
            this.shapeTypeBox.Location = new System.Drawing.Point(120, 20);
            this.shapeTypeBox.Name = "shapeTypeBox";
            this.shapeTypeBox.Size = new System.Drawing.Size(123, 20);
            this.shapeTypeBox.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.validateResult);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Location = new System.Drawing.Point(12, 301);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(286, 98);
            this.panel3.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 443);
            this.Controls.Add(this.shapeSize);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "Form1";
            this.Text = "BRep API example application";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox validateResult;
        private System.Windows.Forms.TextBox shapeSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox xPos;
        private System.Windows.Forms.TextBox yPos;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label shapeType;
        private System.Windows.Forms.TextBox shapeTypeBox;
        private System.Windows.Forms.Button button5;
    }
}

