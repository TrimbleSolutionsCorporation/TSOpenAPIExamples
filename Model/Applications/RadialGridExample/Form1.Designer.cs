namespace RadialGridExample
{
    partial class RadialGridExample
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
            this.CreateExampleRadialGridButton = new System.Windows.Forms.Button();
            this.AngleTextBox = new System.Windows.Forms.TextBox();
            this.AddAngleButton = new System.Windows.Forms.Button();
            this.AddRadiusButton = new System.Windows.Forms.Button();
            this.AddRadiusTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RemoveRadiusButton = new System.Windows.Forms.Button();
            this.RemoveRadiusTextBox = new System.Windows.Forms.TextBox();
            this.RemoveAngleButton = new System.Windows.Forms.Button();
            this.RemoveAngleTextBox = new System.Windows.Forms.TextBox();
            this.ExpandEverySecondArcButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ShrinkEverySecondArcButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateExampleRadialGridButton
            // 
            this.CreateExampleRadialGridButton.Location = new System.Drawing.Point(31, 20);
            this.CreateExampleRadialGridButton.Name = "CreateExampleRadialGridButton";
            this.CreateExampleRadialGridButton.Size = new System.Drawing.Size(153, 22);
            this.CreateExampleRadialGridButton.TabIndex = 0;
            this.CreateExampleRadialGridButton.Text = "Create example radial grid";
            this.CreateExampleRadialGridButton.UseVisualStyleBackColor = true;
            this.CreateExampleRadialGridButton.Click += new System.EventHandler(this.CreateExampleRadialGridButton_Click);
            // 
            // AngleTextBox
            // 
            this.AngleTextBox.Location = new System.Drawing.Point(12, 18);
            this.AngleTextBox.Name = "AngleTextBox";
            this.AngleTextBox.Size = new System.Drawing.Size(153, 20);
            this.AngleTextBox.TabIndex = 1;
            this.AngleTextBox.Text = "37.5";
            // 
            // AddAngleButton
            // 
            this.AddAngleButton.Location = new System.Drawing.Point(184, 18);
            this.AddAngleButton.Name = "AddAngleButton";
            this.AddAngleButton.Size = new System.Drawing.Size(155, 22);
            this.AddAngleButton.TabIndex = 2;
            this.AddAngleButton.Text = "Add angle (degrees)";
            this.AddAngleButton.UseVisualStyleBackColor = true;
            this.AddAngleButton.Click += new System.EventHandler(this.AddAngleButton_Click);
            // 
            // AddRadiusButton
            // 
            this.AddRadiusButton.Location = new System.Drawing.Point(184, 63);
            this.AddRadiusButton.Name = "AddRadiusButton";
            this.AddRadiusButton.Size = new System.Drawing.Size(155, 24);
            this.AddRadiusButton.TabIndex = 4;
            this.AddRadiusButton.Text = "Add radius";
            this.AddRadiusButton.UseVisualStyleBackColor = true;
            this.AddRadiusButton.Click += new System.EventHandler(this.AddRadiusButton_Click);
            // 
            // AddRadiusTextBox
            // 
            this.AddRadiusTextBox.Location = new System.Drawing.Point(12, 65);
            this.AddRadiusTextBox.Name = "AddRadiusTextBox";
            this.AddRadiusTextBox.Size = new System.Drawing.Size(153, 20);
            this.AddRadiusTextBox.TabIndex = 3;
            this.AddRadiusTextBox.Text = "7500.0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddRadiusButton);
            this.groupBox1.Controls.Add(this.AddRadiusTextBox);
            this.groupBox1.Controls.Add(this.AddAngleButton);
            this.groupBox1.Controls.Add(this.AngleTextBox);
            this.groupBox1.Location = new System.Drawing.Point(19, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 99);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RemoveRadiusButton);
            this.groupBox2.Controls.Add(this.RemoveRadiusTextBox);
            this.groupBox2.Controls.Add(this.RemoveAngleButton);
            this.groupBox2.Controls.Add(this.RemoveAngleTextBox);
            this.groupBox2.Location = new System.Drawing.Point(19, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 99);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // RemoveRadiusButton
            // 
            this.RemoveRadiusButton.Location = new System.Drawing.Point(184, 63);
            this.RemoveRadiusButton.Name = "RemoveRadiusButton";
            this.RemoveRadiusButton.Size = new System.Drawing.Size(155, 24);
            this.RemoveRadiusButton.TabIndex = 4;
            this.RemoveRadiusButton.Text = "Remove radius";
            this.RemoveRadiusButton.UseVisualStyleBackColor = true;
            this.RemoveRadiusButton.Click += new System.EventHandler(this.RemoveRadiusButton_Click);
            // 
            // RemoveRadiusTextBox
            // 
            this.RemoveRadiusTextBox.Location = new System.Drawing.Point(12, 65);
            this.RemoveRadiusTextBox.Name = "RemoveRadiusTextBox";
            this.RemoveRadiusTextBox.Size = new System.Drawing.Size(153, 20);
            this.RemoveRadiusTextBox.TabIndex = 3;
            this.RemoveRadiusTextBox.Text = "5000.0";
            // 
            // RemoveAngleButton
            // 
            this.RemoveAngleButton.Location = new System.Drawing.Point(184, 18);
            this.RemoveAngleButton.Name = "RemoveAngleButton";
            this.RemoveAngleButton.Size = new System.Drawing.Size(155, 22);
            this.RemoveAngleButton.TabIndex = 2;
            this.RemoveAngleButton.Text = "Remove angle (degrees)";
            this.RemoveAngleButton.UseVisualStyleBackColor = true;
            this.RemoveAngleButton.Click += new System.EventHandler(this.RemoveAngleButton_Click);
            // 
            // RemoveAngleTextBox
            // 
            this.RemoveAngleTextBox.Location = new System.Drawing.Point(12, 18);
            this.RemoveAngleTextBox.Name = "RemoveAngleTextBox";
            this.RemoveAngleTextBox.Size = new System.Drawing.Size(153, 20);
            this.RemoveAngleTextBox.TabIndex = 1;
            this.RemoveAngleTextBox.Text = "15.0";
            // 
            // ExpandEverySecondArcButton
            // 
            this.ExpandEverySecondArcButton.Location = new System.Drawing.Point(184, 14);
            this.ExpandEverySecondArcButton.Name = "ExpandEverySecondArcButton";
            this.ExpandEverySecondArcButton.Size = new System.Drawing.Size(153, 22);
            this.ExpandEverySecondArcButton.TabIndex = 7;
            this.ExpandEverySecondArcButton.Text = "Expand every second arc";
            this.ExpandEverySecondArcButton.UseVisualStyleBackColor = true;
            this.ExpandEverySecondArcButton.Click += new System.EventHandler(this.ExpandEverySecondArcButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ShrinkEverySecondArcButton);
            this.groupBox3.Controls.Add(this.ExpandEverySecondArcButton);
            this.groupBox3.Location = new System.Drawing.Point(19, 271);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(361, 45);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // ShrinkEverySecondArcButton
            // 
            this.ShrinkEverySecondArcButton.Location = new System.Drawing.Point(12, 14);
            this.ShrinkEverySecondArcButton.Name = "ShrinkEverySecondArcButton";
            this.ShrinkEverySecondArcButton.Size = new System.Drawing.Size(153, 22);
            this.ShrinkEverySecondArcButton.TabIndex = 8;
            this.ShrinkEverySecondArcButton.Text = "Shrink every second arc";
            this.ShrinkEverySecondArcButton.UseVisualStyleBackColor = true;
            this.ShrinkEverySecondArcButton.Click += new System.EventHandler(this.ShrinkEverySecondArcButton_Click);
            // 
            // RadialGridExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 331);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CreateExampleRadialGridButton);
            this.Name = "RadialGridExample";
            this.Text = "Radial grid example";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RadialGridExample_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateExampleRadialGridButton;
        private System.Windows.Forms.TextBox AngleTextBox;
        private System.Windows.Forms.Button AddAngleButton;
        private System.Windows.Forms.Button AddRadiusButton;
        private System.Windows.Forms.TextBox AddRadiusTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button RemoveRadiusButton;
        private System.Windows.Forms.TextBox RemoveRadiusTextBox;
        private System.Windows.Forms.Button RemoveAngleButton;
        private System.Windows.Forms.TextBox RemoveAngleTextBox;
        private System.Windows.Forms.Button ExpandEverySecondArcButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ShrinkEverySecondArcButton;
    }
}

