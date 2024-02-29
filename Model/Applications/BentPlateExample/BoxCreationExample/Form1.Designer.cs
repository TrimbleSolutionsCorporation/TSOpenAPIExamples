namespace BoxCreationExample
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
            this.label3 = new System.Windows.Forms.Label();
            this.CreateBoxWithCustomRadius = new System.Windows.Forms.Button();
            this.CustomRadiusValue = new System.Windows.Forms.NumericUpDown();
            this.CreateBends = new System.Windows.Forms.Button();
            this.CreateContourPlates = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.CreateBoxUsingGeometryAndRadius = new System.Windows.Forms.Button();
            this.CreateBoxUsingGeometry = new System.Windows.Forms.Button();
            this.RadiusValueForAddLeg = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomRadiusValue)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RadiusValueForAddLeg)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CreateBoxWithCustomRadius);
            this.panel1.Controls.Add(this.CustomRadiusValue);
            this.panel1.Controls.Add(this.CreateBends);
            this.panel1.Controls.Add(this.CreateContourPlates);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 210);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(31, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Or set bend radius:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CreateBoxWithCustomRadius
            // 
            this.CreateBoxWithCustomRadius.Enabled = false;
            this.CreateBoxWithCustomRadius.Location = new System.Drawing.Point(3, 172);
            this.CreateBoxWithCustomRadius.Name = "CreateBoxWithCustomRadius";
            this.CreateBoxWithCustomRadius.Size = new System.Drawing.Size(254, 23);
            this.CreateBoxWithCustomRadius.TabIndex = 4;
            this.CreateBoxWithCustomRadius.Text = "Create bends between plates using radius";
            this.CreateBoxWithCustomRadius.UseVisualStyleBackColor = true;
            this.CreateBoxWithCustomRadius.Click += new System.EventHandler(this.CreateBoxWithCustomRadius_Click);
            // 
            // CustomRadiusValue
            // 
            this.CustomRadiusValue.DecimalPlaces = 2;
            this.CustomRadiusValue.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.CustomRadiusValue.Location = new System.Drawing.Point(133, 146);
            this.CustomRadiusValue.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.CustomRadiusValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.CustomRadiusValue.Name = "CustomRadiusValue";
            this.CustomRadiusValue.Size = new System.Drawing.Size(90, 20);
            this.CustomRadiusValue.TabIndex = 3;
            this.CustomRadiusValue.ThousandsSeparator = true;
            this.CustomRadiusValue.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // CreateBends
            // 
            this.CreateBends.Enabled = false;
            this.CreateBends.Location = new System.Drawing.Point(34, 108);
            this.CreateBends.Name = "CreateBends";
            this.CreateBends.Size = new System.Drawing.Size(189, 23);
            this.CreateBends.TabIndex = 2;
            this.CreateBends.Text = "Create bends between plates";
            this.CreateBends.UseVisualStyleBackColor = true;
            this.CreateBends.Click += new System.EventHandler(this.CreateBends_Click);
            // 
            // CreateContourPlates
            // 
            this.CreateContourPlates.Location = new System.Drawing.Point(34, 66);
            this.CreateContourPlates.Name = "CreateContourPlates";
            this.CreateContourPlates.Size = new System.Drawing.Size(189, 23);
            this.CreateContourPlates.TabIndex = 1;
            this.CreateContourPlates.Text = "Create contour plates for box";
            this.CreateContourPlates.UseVisualStyleBackColor = true;
            this.CreateContourPlates.Click += new System.EventHandler(this.CreateContourPlates_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(20, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Box creation using \r\nmodelled plates example";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.CreateBoxUsingGeometryAndRadius);
            this.panel2.Controls.Add(this.CreateBoxUsingGeometry);
            this.panel2.Controls.Add(this.RadiusValueForAddLeg);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(293, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 210);
            this.panel2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(43, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Or set bend radius:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CreateBoxUsingGeometryAndRadius
            // 
            this.CreateBoxUsingGeometryAndRadius.Location = new System.Drawing.Point(46, 154);
            this.CreateBoxUsingGeometryAndRadius.Name = "CreateBoxUsingGeometryAndRadius";
            this.CreateBoxUsingGeometryAndRadius.Size = new System.Drawing.Size(189, 23);
            this.CreateBoxUsingGeometryAndRadius.TabIndex = 7;
            this.CreateBoxUsingGeometryAndRadius.Text = "Create box using radius value";
            this.CreateBoxUsingGeometryAndRadius.UseVisualStyleBackColor = true;
            this.CreateBoxUsingGeometryAndRadius.Click += new System.EventHandler(this.CreateBoxUsingGeometryAndRadius_Click);
            // 
            // CreateBoxUsingGeometry
            // 
            this.CreateBoxUsingGeometry.Location = new System.Drawing.Point(46, 85);
            this.CreateBoxUsingGeometry.Name = "CreateBoxUsingGeometry";
            this.CreateBoxUsingGeometry.Size = new System.Drawing.Size(189, 23);
            this.CreateBoxUsingGeometry.TabIndex = 2;
            this.CreateBoxUsingGeometry.Text = "Create box structure";
            this.CreateBoxUsingGeometry.UseVisualStyleBackColor = true;
            this.CreateBoxUsingGeometry.Click += new System.EventHandler(this.CreateBoxUsingGeometry_Click);
            // 
            // RadiusValueForAddLeg
            // 
            this.RadiusValueForAddLeg.DecimalPlaces = 2;
            this.RadiusValueForAddLeg.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.RadiusValueForAddLeg.Location = new System.Drawing.Point(145, 128);
            this.RadiusValueForAddLeg.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.RadiusValueForAddLeg.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.RadiusValueForAddLeg.Name = "RadiusValueForAddLeg";
            this.RadiusValueForAddLeg.Size = new System.Drawing.Size(90, 20);
            this.RadiusValueForAddLeg.TabIndex = 6;
            this.RadiusValueForAddLeg.ThousandsSeparator = true;
            this.RadiusValueForAddLeg.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 48);
            this.label2.TabIndex = 0;
            this.label2.Text = "Box creation using \r\nConnectiveGeometry example";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 246);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomRadiusValue)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RadiusValueForAddLeg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CreateBends;
        private System.Windows.Forms.Button CreateContourPlates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button CreateBoxUsingGeometry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CreateBoxWithCustomRadius;
        private System.Windows.Forms.NumericUpDown CustomRadiusValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CreateBoxUsingGeometryAndRadius;
        private System.Windows.Forms.NumericUpDown RadiusValueForAddLeg;
    }
}

