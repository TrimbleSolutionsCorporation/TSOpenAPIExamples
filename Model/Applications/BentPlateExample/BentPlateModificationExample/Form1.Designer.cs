namespace BentPlateModificationExample
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CreateSimpleBentPlate1 = new System.Windows.Forms.Button();
            this.ModifyPlateSide = new System.Windows.Forms.Button();
            this.CreateSimpleBentPlate2 = new System.Windows.Forms.Button();
            this.ModifyRadius = new System.Windows.Forms.Button();
            this.CreateSimpleBentPlate3 = new System.Windows.Forms.Button();
            this.ModifyCylindricalSide = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.RadiusValue = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RadiusValue)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(925, 260);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.CreateSimpleBentPlate1);
            this.panel2.Controls.Add(this.ModifyPlateSide);
            this.panel2.Location = new System.Drawing.Point(3, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 177);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.RadiusValue);
            this.panel3.Controls.Add(this.ModifyRadius);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.CreateSimpleBentPlate2);
            this.panel3.Location = new System.Drawing.Point(308, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(272, 177);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.ModifyCylindricalSide);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.CreateSimpleBentPlate3);
            this.panel4.Location = new System.Drawing.Point(629, 60);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(266, 177);
            this.panel4.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(304, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bent plate modification example";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.Location = new System.Drawing.Point(29, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Plate side modification";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.Location = new System.Drawing.Point(52, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Radius modification";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label4.Location = new System.Drawing.Point(13, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(241, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "Cylindrical side modification";
            // 
            // CreateSimpleBentPlate1
            // 
            this.CreateSimpleBentPlate1.Location = new System.Drawing.Point(33, 50);
            this.CreateSimpleBentPlate1.Name = "CreateSimpleBentPlate1";
            this.CreateSimpleBentPlate1.Size = new System.Drawing.Size(192, 23);
            this.CreateSimpleBentPlate1.TabIndex = 1;
            this.CreateSimpleBentPlate1.Text = "Create simple bent plate";
            this.CreateSimpleBentPlate1.UseVisualStyleBackColor = true;
            this.CreateSimpleBentPlate1.Click += new System.EventHandler(this.CreateSimpleBentPlate1_Click);
            // 
            // ModifyPlateSide
            // 
            this.ModifyPlateSide.Enabled = false;
            this.ModifyPlateSide.Location = new System.Drawing.Point(33, 106);
            this.ModifyPlateSide.Name = "ModifyPlateSide";
            this.ModifyPlateSide.Size = new System.Drawing.Size(192, 23);
            this.ModifyPlateSide.TabIndex = 2;
            this.ModifyPlateSide.Text = "Modify plate side";
            this.ModifyPlateSide.UseVisualStyleBackColor = true;
            this.ModifyPlateSide.Click += new System.EventHandler(this.ModifyPlateSide_Click);
            // 
            // CreateSimpleBentPlate2
            // 
            this.CreateSimpleBentPlate2.Location = new System.Drawing.Point(56, 50);
            this.CreateSimpleBentPlate2.Name = "CreateSimpleBentPlate2";
            this.CreateSimpleBentPlate2.Size = new System.Drawing.Size(169, 23);
            this.CreateSimpleBentPlate2.TabIndex = 3;
            this.CreateSimpleBentPlate2.Text = "Create simple bent plate";
            this.CreateSimpleBentPlate2.UseVisualStyleBackColor = true;
            this.CreateSimpleBentPlate2.Click += new System.EventHandler(this.CreateSimpleBentPlate2_Click);
            // 
            // ModifyRadius
            // 
            this.ModifyRadius.Enabled = false;
            this.ModifyRadius.Location = new System.Drawing.Point(56, 126);
            this.ModifyRadius.Name = "ModifyRadius";
            this.ModifyRadius.Size = new System.Drawing.Size(169, 23);
            this.ModifyRadius.TabIndex = 4;
            this.ModifyRadius.Text = "Modify bend radius";
            this.ModifyRadius.UseVisualStyleBackColor = true;
            this.ModifyRadius.Click += new System.EventHandler(this.ModifyRadius_Click);
            // 
            // CreateSimpleBentPlate3
            // 
            this.CreateSimpleBentPlate3.Location = new System.Drawing.Point(45, 50);
            this.CreateSimpleBentPlate3.Name = "CreateSimpleBentPlate3";
            this.CreateSimpleBentPlate3.Size = new System.Drawing.Size(180, 23);
            this.CreateSimpleBentPlate3.TabIndex = 5;
            this.CreateSimpleBentPlate3.Text = "Create simple bent plate";
            this.CreateSimpleBentPlate3.UseVisualStyleBackColor = true;
            this.CreateSimpleBentPlate3.Click += new System.EventHandler(this.CreateSimpleBentPlate3_Click);
            // 
            // ModifyCylindricalSide
            // 
            this.ModifyCylindricalSide.Enabled = false;
            this.ModifyCylindricalSide.Location = new System.Drawing.Point(45, 106);
            this.ModifyCylindricalSide.Name = "ModifyCylindricalSide";
            this.ModifyCylindricalSide.Size = new System.Drawing.Size(180, 23);
            this.ModifyCylindricalSide.TabIndex = 6;
            this.ModifyCylindricalSide.Text = "Modify cylindrical side";
            this.ModifyCylindricalSide.UseVisualStyleBackColor = true;
            this.ModifyCylindricalSide.Click += new System.EventHandler(this.ModifyCylindricalSide_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(44, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Set radius value :";
            // 
            // RadiusValue
            // 
            this.RadiusValue.DecimalPlaces = 2;
            this.RadiusValue.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.RadiusValue.Location = new System.Drawing.Point(151, 93);
            this.RadiusValue.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.RadiusValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.RadiusValue.Name = "RadiusValue";
            this.RadiusValue.Size = new System.Drawing.Size(74, 20);
            this.RadiusValue.TabIndex = 11;
            this.RadiusValue.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 284);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RadiusValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button ModifyRadius;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CreateSimpleBentPlate2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button ModifyCylindricalSide;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CreateSimpleBentPlate3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CreateSimpleBentPlate1;
        private System.Windows.Forms.Button ModifyPlateSide;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown RadiusValue;
    }
}

