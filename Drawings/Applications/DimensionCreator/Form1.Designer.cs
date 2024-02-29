namespace DimensionCreator
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
            this.quitButton = new System.Windows.Forms.Button();
            this.angleDimensionButton = new System.Windows.Forms.Button();
            this.straightDimensionButton = new System.Windows.Forms.Button();
            this.radiusDimensionButton = new System.Windows.Forms.Button();
            this.distanceLabel = new System.Windows.Forms.Label();
            this.distanceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.curvedRadialDimensionButton = new System.Windows.Forms.Button();
            this.repeatCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.curvedOrthogonalDimensionButton = new System.Windows.Forms.Button();
            this.numberOfPointsToPickLabel = new System.Windows.Forms.Label();
            this.numberOfPointsToPickNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.distanceNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPointsToPickNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(322, 229);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(75, 23);
            this.quitButton.TabIndex = 1;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // angleDimensionButton
            // 
            this.angleDimensionButton.Location = new System.Drawing.Point(202, 18);
            this.angleDimensionButton.Name = "angleDimensionButton";
            this.angleDimensionButton.Size = new System.Drawing.Size(188, 23);
            this.angleDimensionButton.TabIndex = 0;
            this.angleDimensionButton.Text = "Create angle dimension";
            this.angleDimensionButton.UseVisualStyleBackColor = true;
            this.angleDimensionButton.Click += new System.EventHandler(this.angleDimensionButton_Click);
            // 
            // straightDimensionButton
            // 
            this.straightDimensionButton.Location = new System.Drawing.Point(193, 48);
            this.straightDimensionButton.Name = "straightDimensionButton";
            this.straightDimensionButton.Size = new System.Drawing.Size(188, 23);
            this.straightDimensionButton.TabIndex = 0;
            this.straightDimensionButton.Text = "Create straight dimension";
            this.straightDimensionButton.UseVisualStyleBackColor = true;
            this.straightDimensionButton.Click += new System.EventHandler(this.straightDimensionButton_Click);
            // 
            // radiusDimensionButton
            // 
            this.radiusDimensionButton.Location = new System.Drawing.Point(193, 19);
            this.radiusDimensionButton.Name = "radiusDimensionButton";
            this.radiusDimensionButton.Size = new System.Drawing.Size(188, 23);
            this.radiusDimensionButton.TabIndex = 0;
            this.radiusDimensionButton.Text = "Create radius dimension";
            this.radiusDimensionButton.UseVisualStyleBackColor = true;
            this.radiusDimensionButton.Click += new System.EventHandler(this.radiusDimensionButton_Click);
            // 
            // distanceLabel
            // 
            this.distanceLabel.AutoSize = true;
            this.distanceLabel.Location = new System.Drawing.Point(15, 53);
            this.distanceLabel.Name = "distanceLabel";
            this.distanceLabel.Size = new System.Drawing.Size(52, 13);
            this.distanceLabel.TabIndex = 6;
            this.distanceLabel.Text = "Distance:";
            // 
            // distanceNumericUpDown
            // 
            this.distanceNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.distanceNumericUpDown.Location = new System.Drawing.Point(73, 51);
            this.distanceNumericUpDown.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.distanceNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.distanceNumericUpDown.Name = "distanceNumericUpDown";
            this.distanceNumericUpDown.Size = new System.Drawing.Size(57, 20);
            this.distanceNumericUpDown.TabIndex = 2;
            this.distanceNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // curvedRadialDimensionButton
            // 
            this.curvedRadialDimensionButton.Location = new System.Drawing.Point(193, 77);
            this.curvedRadialDimensionButton.Name = "curvedRadialDimensionButton";
            this.curvedRadialDimensionButton.Size = new System.Drawing.Size(188, 23);
            this.curvedRadialDimensionButton.TabIndex = 0;
            this.curvedRadialDimensionButton.Text = "Create curved radial dimension";
            this.curvedRadialDimensionButton.UseVisualStyleBackColor = true;
            this.curvedRadialDimensionButton.Click += new System.EventHandler(this.curvedRadialDimensionButton_Click);
            // 
            // repeatCheckBox
            // 
            this.repeatCheckBox.AutoSize = true;
            this.repeatCheckBox.Location = new System.Drawing.Point(27, 22);
            this.repeatCheckBox.Name = "repeatCheckBox";
            this.repeatCheckBox.Size = new System.Drawing.Size(119, 17);
            this.repeatCheckBox.TabIndex = 3;
            this.repeatCheckBox.Text = "Use previous points";
            this.repeatCheckBox.UseVisualStyleBackColor = true;
            this.repeatCheckBox.CheckedChanged += new System.EventHandler(this.repeatCheckBox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.repeatCheckBox);
            this.groupBox1.Controls.Add(this.angleDimensionButton);
            this.groupBox1.Location = new System.Drawing.Point(7, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 220);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.straightDimensionButton);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.radiusDimensionButton);
            this.groupBox3.Controls.Add(this.distanceLabel);
            this.groupBox3.Controls.Add(this.distanceNumericUpDown);
            this.groupBox3.Controls.Add(this.curvedRadialDimensionButton);
            this.groupBox3.Location = new System.Drawing.Point(9, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(400, 167);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.curvedOrthogonalDimensionButton);
            this.groupBox2.Controls.Add(this.numberOfPointsToPickLabel);
            this.groupBox2.Controls.Add(this.numberOfPointsToPickNumericUpDown);
            this.groupBox2.Location = new System.Drawing.Point(9, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 54);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // curvedOrthogonalDimensionButton
            // 
            this.curvedOrthogonalDimensionButton.Location = new System.Drawing.Point(184, 17);
            this.curvedOrthogonalDimensionButton.Name = "curvedOrthogonalDimensionButton";
            this.curvedOrthogonalDimensionButton.Size = new System.Drawing.Size(188, 23);
            this.curvedOrthogonalDimensionButton.TabIndex = 6;
            this.curvedOrthogonalDimensionButton.Text = "Create curved orthogonal dimension";
            this.curvedOrthogonalDimensionButton.UseVisualStyleBackColor = true;
            this.curvedOrthogonalDimensionButton.Click += new System.EventHandler(this.curvedOrthogonalDimensionButton_Click);
            // 
            // numberOfPointsToPickLabel
            // 
            this.numberOfPointsToPickLabel.AutoSize = true;
            this.numberOfPointsToPickLabel.Location = new System.Drawing.Point(6, 22);
            this.numberOfPointsToPickLabel.Name = "numberOfPointsToPickLabel";
            this.numberOfPointsToPickLabel.Size = new System.Drawing.Size(125, 13);
            this.numberOfPointsToPickLabel.TabIndex = 8;
            this.numberOfPointsToPickLabel.Text = "Number of points to pick:";
            // 
            // numberOfPointsToPickNumericUpDown
            // 
            this.numberOfPointsToPickNumericUpDown.Location = new System.Drawing.Point(135, 19);
            this.numberOfPointsToPickNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfPointsToPickNumericUpDown.Name = "numberOfPointsToPickNumericUpDown";
            this.numberOfPointsToPickNumericUpDown.Size = new System.Drawing.Size(43, 20);
            this.numberOfPointsToPickNumericUpDown.TabIndex = 7;
            this.numberOfPointsToPickNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numberOfPointsToPickNumericUpDown.ValueChanged += new System.EventHandler(this.numberOfPointsToPickNumericUpDown_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 259);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.quitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Create Dimension";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.distanceNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPointsToPickNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button angleDimensionButton;
        private System.Windows.Forms.Button straightDimensionButton;
        private System.Windows.Forms.Button radiusDimensionButton;
        private System.Windows.Forms.Label distanceLabel;
        private System.Windows.Forms.NumericUpDown distanceNumericUpDown;
        private System.Windows.Forms.Button curvedRadialDimensionButton;
        private System.Windows.Forms.CheckBox repeatCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button curvedOrthogonalDimensionButton;
        private System.Windows.Forms.Label numberOfPointsToPickLabel;
        private System.Windows.Forms.NumericUpDown numberOfPointsToPickNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

