namespace LevelMarkTest
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
            if(disposing && (components != null))
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
            this.b_Create = new System.Windows.Forms.Button();
            this.b_Modify = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.b_Get = new System.Windows.Forms.Button();
            this.cb_SubType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_Color = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Postfix = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Prefix = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_FontHeight = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_AssociatedObject = new System.Windows.Forms.TextBox();
            this.cb_PickPoints = new System.Windows.Forms.CheckBox();
            this.cb_PickObject = new System.Windows.Forms.CheckBox();
            this.tb_insertionPoint_X = new System.Windows.Forms.TextBox();
            this.tb_insertionPoint_Y = new System.Windows.Forms.TextBox();
            this.tb_insertionPoint_Z = new System.Windows.Forms.TextBox();
            this.tb_basePoint_Z = new System.Windows.Forms.TextBox();
            this.tb_basePoint_Y = new System.Windows.Forms.TextBox();
            this.tb_basePoint_X = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // b_Create
            // 
            this.b_Create.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Create.Location = new System.Drawing.Point(161, 338);
            this.b_Create.Name = "b_Create";
            this.b_Create.Size = new System.Drawing.Size(75, 23);
            this.b_Create.TabIndex = 0;
            this.b_Create.Text = "Create";
            this.b_Create.UseVisualStyleBackColor = true;
            this.b_Create.Click += new System.EventHandler(this.b_Create_Click);
            // 
            // b_Modify
            // 
            this.b_Modify.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Modify.Location = new System.Drawing.Point(304, 338);
            this.b_Modify.Name = "b_Modify";
            this.b_Modify.Size = new System.Drawing.Size(75, 23);
            this.b_Modify.TabIndex = 1;
            this.b_Modify.Text = "Modify";
            this.b_Modify.UseVisualStyleBackColor = true;
            this.b_Modify.Click += new System.EventHandler(this.b_Modify_Click);
            // 
            // b_Get
            // 
            this.b_Get.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Get.Location = new System.Drawing.Point(16, 338);
            this.b_Get.Name = "b_Get";
            this.b_Get.Size = new System.Drawing.Size(70, 23);
            this.b_Get.TabIndex = 11;
            this.b_Get.Text = "Get";
            this.b_Get.UseVisualStyleBackColor = true;
            this.b_Get.Click += new System.EventHandler(this.b_Get_Click);
            // 
            // cb_SubType
            // 
            this.cb_SubType.FormattingEnabled = true;
            this.cb_SubType.Items.AddRange(new object[] {
            "None",
            "No Leader Line",
            "Inclined Leader Line",
            "Ortho Leader Line"});
            this.cb_SubType.Location = new System.Drawing.Point(103, 12);
            this.cb_SubType.Name = "cb_SubType";
            this.cb_SubType.Size = new System.Drawing.Size(148, 21);
            this.cb_SubType.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "SubType";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_Color);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tb_Postfix);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_Prefix);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_FontHeight);
            this.groupBox1.Location = new System.Drawing.Point(24, 215);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 78);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Properties";
            // 
            // cb_Color
            // 
            this.cb_Color.FormattingEnabled = true;
            this.cb_Color.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue",
            "Black"});
            this.cb_Color.Location = new System.Drawing.Point(77, 45);
            this.cb_Color.Name = "cb_Color";
            this.cb_Color.Size = new System.Drawing.Size(91, 21);
            this.cb_Color.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "PostFix";
            // 
            // tb_Postfix
            // 
            this.tb_Postfix.Location = new System.Drawing.Point(265, 45);
            this.tb_Postfix.Name = "tb_Postfix";
            this.tb_Postfix.Size = new System.Drawing.Size(86, 20);
            this.tb_Postfix.TabIndex = 16;
            this.tb_Postfix.Text = " mm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Prefix";
            // 
            // tb_Prefix
            // 
            this.tb_Prefix.Location = new System.Drawing.Point(265, 19);
            this.tb_Prefix.Name = "tb_Prefix";
            this.tb_Prefix.Size = new System.Drawing.Size(86, 20);
            this.tb_Prefix.TabIndex = 14;
            this.tb_Prefix.Text = "= ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Color";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Font Height";
            // 
            // tb_FontHeight
            // 
            this.tb_FontHeight.Location = new System.Drawing.Point(77, 19);
            this.tb_FontHeight.Name = "tb_FontHeight";
            this.tb_FontHeight.Size = new System.Drawing.Size(91, 20);
            this.tb_FontHeight.TabIndex = 11;
            this.tb_FontHeight.Text = "5";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LevelMark.Resource1.Untitled;
            this.pictureBox1.Location = new System.Drawing.Point(104, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(269, 155);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Associated Object:";
            // 
            // tb_AssociatedObject
            // 
            this.tb_AssociatedObject.Location = new System.Drawing.Point(232, 99);
            this.tb_AssociatedObject.Name = "tb_AssociatedObject";
            this.tb_AssociatedObject.Size = new System.Drawing.Size(91, 20);
            this.tb_AssociatedObject.TabIndex = 21;
            // 
            // cb_PickPoints
            // 
            this.cb_PickPoints.AutoSize = true;
            this.cb_PickPoints.Checked = true;
            this.cb_PickPoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_PickPoints.Location = new System.Drawing.Point(156, 299);
            this.cb_PickPoints.Name = "cb_PickPoints";
            this.cb_PickPoints.Size = new System.Drawing.Size(106, 17);
            this.cb_PickPoints.TabIndex = 23;
            this.cb_PickPoints.Text = "By picking points";
            this.cb_PickPoints.UseVisualStyleBackColor = true;
            // 
            // cb_PickObject
            // 
            this.cb_PickObject.AutoSize = true;
            this.cb_PickObject.Location = new System.Drawing.Point(156, 315);
            this.cb_PickObject.Name = "cb_PickObject";
            this.cb_PickObject.Size = new System.Drawing.Size(107, 17);
            this.cb_PickObject.TabIndex = 24;
            this.cb_PickObject.Text = "By picking object";
            this.cb_PickObject.UseVisualStyleBackColor = true;
            // 
            // tb_insertionPoint_X
            // 
            this.tb_insertionPoint_X.Location = new System.Drawing.Point(37, 56);
            this.tb_insertionPoint_X.Name = "tb_insertionPoint_X";
            this.tb_insertionPoint_X.Size = new System.Drawing.Size(80, 20);
            this.tb_insertionPoint_X.TabIndex = 25;
            // 
            // tb_insertionPoint_Y
            // 
            this.tb_insertionPoint_Y.Location = new System.Drawing.Point(124, 56);
            this.tb_insertionPoint_Y.Name = "tb_insertionPoint_Y";
            this.tb_insertionPoint_Y.Size = new System.Drawing.Size(80, 20);
            this.tb_insertionPoint_Y.TabIndex = 26;
            // 
            // tb_insertionPoint_Z
            // 
            this.tb_insertionPoint_Z.Location = new System.Drawing.Point(210, 56);
            this.tb_insertionPoint_Z.Name = "tb_insertionPoint_Z";
            this.tb_insertionPoint_Z.Size = new System.Drawing.Size(80, 20);
            this.tb_insertionPoint_Z.TabIndex = 27;
            // 
            // tb_basePoint_Z
            // 
            this.tb_basePoint_Z.Location = new System.Drawing.Point(306, 180);
            this.tb_basePoint_Z.Name = "tb_basePoint_Z";
            this.tb_basePoint_Z.Size = new System.Drawing.Size(80, 20);
            this.tb_basePoint_Z.TabIndex = 30;
            // 
            // tb_basePoint_Y
            // 
            this.tb_basePoint_Y.Location = new System.Drawing.Point(220, 180);
            this.tb_basePoint_Y.Name = "tb_basePoint_Y";
            this.tb_basePoint_Y.Size = new System.Drawing.Size(80, 20);
            this.tb_basePoint_Y.TabIndex = 29;
            // 
            // tb_basePoint_X
            // 
            this.tb_basePoint_X.Location = new System.Drawing.Point(133, 180);
            this.tb_basePoint_X.Name = "tb_basePoint_X";
            this.tb_basePoint_X.Size = new System.Drawing.Size(80, 20);
            this.tb_basePoint_X.TabIndex = 28;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 369);
            this.Controls.Add(this.tb_basePoint_Z);
            this.Controls.Add(this.tb_basePoint_Y);
            this.Controls.Add(this.tb_basePoint_X);
            this.Controls.Add(this.tb_insertionPoint_Z);
            this.Controls.Add(this.tb_insertionPoint_Y);
            this.Controls.Add(this.tb_insertionPoint_X);
            this.Controls.Add(this.cb_PickObject);
            this.Controls.Add(this.cb_PickPoints);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_AssociatedObject);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_SubType);
            this.Controls.Add(this.b_Get);
            this.Controls.Add(this.b_Modify);
            this.Controls.Add(this.b_Create);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Level Mark Test";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_Create;
        private System.Windows.Forms.Button b_Modify;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button b_Get;
        private System.Windows.Forms.ComboBox cb_SubType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cb_Color;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Postfix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Prefix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_FontHeight;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_AssociatedObject;
        private System.Windows.Forms.CheckBox cb_PickPoints;
        private System.Windows.Forms.CheckBox cb_PickObject;
        private System.Windows.Forms.TextBox tb_insertionPoint_X;
        private System.Windows.Forms.TextBox tb_insertionPoint_Y;
        private System.Windows.Forms.TextBox tb_insertionPoint_Z;
        private System.Windows.Forms.TextBox tb_basePoint_Z;
        private System.Windows.Forms.TextBox tb_basePoint_Y;
        private System.Windows.Forms.TextBox tb_basePoint_X;
    }
}

