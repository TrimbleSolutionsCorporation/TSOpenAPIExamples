namespace ConstructionObjectsExample
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
            this.CreateExampleArc = new System.Windows.Forms.Button();
            this.ArcRadiusBox = new System.Windows.Forms.TextBox();
            this.ArcRadiusLabel = new System.Windows.Forms.Label();
            this.ArcLineType = new System.Windows.Forms.ComboBox();
            this.ArcLineTypeLabel = new System.Windows.Forms.Label();
            this.ModifyArcButton = new System.Windows.Forms.Button();
            this.CreateExamplePolycurveButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ConvertArcToLinesButton = new System.Windows.Forms.Button();
            this.ConvertLinesToArcsButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.AppendTangentArcButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TangentLineLength = new System.Windows.Forms.TextBox();
            this.AppendTangentLineButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateExampleArc
            // 
            this.CreateExampleArc.Location = new System.Drawing.Point(39, 39);
            this.CreateExampleArc.Name = "CreateExampleArc";
            this.CreateExampleArc.Size = new System.Drawing.Size(142, 23);
            this.CreateExampleArc.TabIndex = 0;
            this.CreateExampleArc.Text = "Create example arc";
            this.CreateExampleArc.UseVisualStyleBackColor = true;
            this.CreateExampleArc.Click += new System.EventHandler(this.CreateExampleArc_Click);
            // 
            // ArcRadiusBox
            // 
            this.ArcRadiusBox.Location = new System.Drawing.Point(39, 103);
            this.ArcRadiusBox.Name = "ArcRadiusBox";
            this.ArcRadiusBox.Size = new System.Drawing.Size(142, 20);
            this.ArcRadiusBox.TabIndex = 1;
            this.ArcRadiusBox.Text = "6000.0";
            // 
            // ArcRadiusLabel
            // 
            this.ArcRadiusLabel.AutoSize = true;
            this.ArcRadiusLabel.Location = new System.Drawing.Point(80, 87);
            this.ArcRadiusLabel.Name = "ArcRadiusLabel";
            this.ArcRadiusLabel.Size = new System.Drawing.Size(54, 13);
            this.ArcRadiusLabel.TabIndex = 2;
            this.ArcRadiusLabel.Text = "Arc radius";
            // 
            // ArcLineType
            // 
            this.ArcLineType.FormattingEnabled = true;
            this.ArcLineType.Items.AddRange(new object[] {
            "SolidLine",
            "DashedLine",
            "SlashedLine",
            "DashDot",
            "DottedLine"});
            this.ArcLineType.Location = new System.Drawing.Point(39, 158);
            this.ArcLineType.Name = "ArcLineType";
            this.ArcLineType.Size = new System.Drawing.Size(142, 21);
            this.ArcLineType.TabIndex = 3;
            this.ArcLineType.Text = "SolidLine";
            // 
            // ArcLineTypeLabel
            // 
            this.ArcLineTypeLabel.AutoSize = true;
            this.ArcLineTypeLabel.Location = new System.Drawing.Point(75, 142);
            this.ArcLineTypeLabel.Name = "ArcLineTypeLabel";
            this.ArcLineTypeLabel.Size = new System.Drawing.Size(65, 13);
            this.ArcLineTypeLabel.TabIndex = 4;
            this.ArcLineTypeLabel.Text = "Arc line type";
            // 
            // ModifyArcButton
            // 
            this.ModifyArcButton.Location = new System.Drawing.Point(75, 204);
            this.ModifyArcButton.Name = "ModifyArcButton";
            this.ModifyArcButton.Size = new System.Drawing.Size(80, 49);
            this.ModifyArcButton.TabIndex = 5;
            this.ModifyArcButton.Text = "Modify arc";
            this.ModifyArcButton.UseVisualStyleBackColor = true;
            this.ModifyArcButton.Click += new System.EventHandler(this.ModifyArcButton_Click);
            // 
            // CreateExamplePolycurveButton
            // 
            this.CreateExamplePolycurveButton.Location = new System.Drawing.Point(115, 39);
            this.CreateExamplePolycurveButton.Name = "CreateExamplePolycurveButton";
            this.CreateExamplePolycurveButton.Size = new System.Drawing.Size(142, 23);
            this.CreateExamplePolycurveButton.TabIndex = 6;
            this.CreateExamplePolycurveButton.Text = "Create example polycurve";
            this.CreateExamplePolycurveButton.UseVisualStyleBackColor = true;
            this.CreateExamplePolycurveButton.Click += new System.EventHandler(this.CreateExamplePolycurveButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ModifyArcButton);
            this.groupBox1.Controls.Add(this.ArcLineTypeLabel);
            this.groupBox1.Controls.Add(this.ArcLineType);
            this.groupBox1.Controls.Add(this.ArcRadiusLabel);
            this.groupBox1.Controls.Add(this.ArcRadiusBox);
            this.groupBox1.Controls.Add(this.CreateExampleArc);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 291);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Construction arc example";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.CreateExamplePolycurveButton);
            this.groupBox2.Location = new System.Drawing.Point(275, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 291);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Construction polycurve example";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ConvertArcToLinesButton);
            this.groupBox5.Controls.Add(this.ConvertLinesToArcsButton);
            this.groupBox5.Location = new System.Drawing.Point(20, 211);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(329, 61);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            // 
            // ConvertArcToLinesButton
            // 
            this.ConvertArcToLinesButton.Location = new System.Drawing.Point(177, 19);
            this.ConvertArcToLinesButton.Name = "ConvertArcToLinesButton";
            this.ConvertArcToLinesButton.Size = new System.Drawing.Size(142, 23);
            this.ConvertArcToLinesButton.TabIndex = 12;
            this.ConvertArcToLinesButton.Text = "Convert arcs  to lines";
            this.ConvertArcToLinesButton.UseVisualStyleBackColor = true;
            this.ConvertArcToLinesButton.Click += new System.EventHandler(this.ConvertArcToLinesButton_Click);
            // 
            // ConvertLinesToArcsButton
            // 
            this.ConvertLinesToArcsButton.Location = new System.Drawing.Point(8, 19);
            this.ConvertLinesToArcsButton.Name = "ConvertLinesToArcsButton";
            this.ConvertLinesToArcsButton.Size = new System.Drawing.Size(142, 23);
            this.ConvertLinesToArcsButton.TabIndex = 11;
            this.ConvertLinesToArcsButton.Text = "Convert lines to arcs";
            this.ConvertLinesToArcsButton.UseVisualStyleBackColor = true;
            this.ConvertLinesToArcsButton.Click += new System.EventHandler(this.ConvertLinesToArcsButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.AppendTangentArcButton);
            this.groupBox4.Location = new System.Drawing.Point(20, 147);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(329, 58);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            // 
            // AppendTangentArcButton
            // 
            this.AppendTangentArcButton.Location = new System.Drawing.Point(174, 20);
            this.AppendTangentArcButton.Name = "AppendTangentArcButton";
            this.AppendTangentArcButton.Size = new System.Drawing.Size(142, 23);
            this.AppendTangentArcButton.TabIndex = 9;
            this.AppendTangentArcButton.Text = "Append tangent arc";
            this.AppendTangentArcButton.UseVisualStyleBackColor = true;
            this.AppendTangentArcButton.Click += new System.EventHandler(this.AppendTangentArcButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.TangentLineLength);
            this.groupBox3.Controls.Add(this.AppendTangentLineButton);
            this.groupBox3.Location = new System.Drawing.Point(20, 76);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(329, 66);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Line length";
            // 
            // TangentLineLength
            // 
            this.TangentLineLength.Location = new System.Drawing.Point(11, 26);
            this.TangentLineLength.Name = "TangentLineLength";
            this.TangentLineLength.Size = new System.Drawing.Size(142, 20);
            this.TangentLineLength.TabIndex = 6;
            this.TangentLineLength.Text = "6000.0";
            // 
            // AppendTangentLineButton
            // 
            this.AppendTangentLineButton.Location = new System.Drawing.Point(177, 24);
            this.AppendTangentLineButton.Name = "AppendTangentLineButton";
            this.AppendTangentLineButton.Size = new System.Drawing.Size(142, 23);
            this.AppendTangentLineButton.TabIndex = 7;
            this.AppendTangentLineButton.Text = "Append tangent line";
            this.AppendTangentLineButton.UseVisualStyleBackColor = true;
            this.AppendTangentLineButton.Click += new System.EventHandler(this.AppendTangentLineButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 319);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Construction objects example";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateExampleArc;
        private System.Windows.Forms.TextBox ArcRadiusBox;
        private System.Windows.Forms.Label ArcRadiusLabel;
        private System.Windows.Forms.ComboBox ArcLineType;
        private System.Windows.Forms.Label ArcLineTypeLabel;
        private System.Windows.Forms.Button ModifyArcButton;
        private System.Windows.Forms.Button CreateExamplePolycurveButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button ConvertArcToLinesButton;
        private System.Windows.Forms.Button ConvertLinesToArcsButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button AppendTangentArcButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TangentLineLength;
        private System.Windows.Forms.Button AppendTangentLineButton;
    }
}

