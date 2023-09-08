namespace FilterExmple
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
            this.checkBox_pourNumber = new System.Windows.Forms.CheckBox();
            this.checkBox_pourType = new System.Windows.Forms.CheckBox();
            this.checkBox_pourCM = new System.Windows.Forms.CheckBox();
            this.textBox_pourNumber = new System.Windows.Forms.TextBox();
            this.textBox_pourType = new System.Windows.Forms.TextBox();
            this.textBox_CM = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.filteredPours = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_PUName = new System.Windows.Forms.CheckBox();
            this.textBox_PUName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.filteredPU = new System.Windows.Forms.TextBox();
            this.checkBox_surfaceName = new System.Windows.Forms.CheckBox();
            this.checkBox_surfaceType = new System.Windows.Forms.CheckBox();
            this.checkBox_surfaceClass = new System.Windows.Forms.CheckBox();
            this.textBox_surfaceName = new System.Windows.Forms.TextBox();
            this.textBox_surfaceType = new System.Windows.Forms.TextBox();
            this.textBox_surfaceClass = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.filteredSurfaces = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // checkBox_pourNumber
            // 
            this.checkBox_pourNumber.AutoSize = true;
            this.checkBox_pourNumber.Checked = true;
            this.checkBox_pourNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_pourNumber.Location = new System.Drawing.Point(42, 21);
            this.checkBox_pourNumber.Name = "checkBox_pourNumber";
            this.checkBox_pourNumber.Size = new System.Drawing.Size(95, 17);
            this.checkBox_pourNumber.TabIndex = 0;
            this.checkBox_pourNumber.Text = "Pour number =";
            this.checkBox_pourNumber.UseVisualStyleBackColor = true;
            // 
            // checkBox_pourType
            // 
            this.checkBox_pourType.AutoSize = true;
            this.checkBox_pourType.Checked = true;
            this.checkBox_pourType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_pourType.Location = new System.Drawing.Point(42, 44);
            this.checkBox_pourType.Name = "checkBox_pourType";
            this.checkBox_pourType.Size = new System.Drawing.Size(80, 17);
            this.checkBox_pourType.TabIndex = 1;
            this.checkBox_pourType.Text = "Pour type =";
            this.checkBox_pourType.UseVisualStyleBackColor = true;
            // 
            // checkBox_pourCM
            // 
            this.checkBox_pourCM.AutoSize = true;
            this.checkBox_pourCM.Checked = true;
            this.checkBox_pourCM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_pourCM.Location = new System.Drawing.Point(42, 67);
            this.checkBox_pourCM.Name = "checkBox_pourCM";
            this.checkBox_pourCM.Size = new System.Drawing.Size(114, 17);
            this.checkBox_pourCM.TabIndex = 2;
            this.checkBox_pourCM.Text = "Concrete mixture =";
            this.checkBox_pourCM.UseVisualStyleBackColor = true;
            // 
            // textBox_pourNumber
            // 
            this.textBox_pourNumber.Location = new System.Drawing.Point(157, 18);
            this.textBox_pourNumber.Name = "textBox_pourNumber";
            this.textBox_pourNumber.Size = new System.Drawing.Size(100, 20);
            this.textBox_pourNumber.TabIndex = 3;
            // 
            // textBox_pourType
            // 
            this.textBox_pourType.Location = new System.Drawing.Point(157, 41);
            this.textBox_pourType.Name = "textBox_pourType";
            this.textBox_pourType.Size = new System.Drawing.Size(100, 20);
            this.textBox_pourType.TabIndex = 4;
            // 
            // textBox_CM
            // 
            this.textBox_CM.Location = new System.Drawing.Point(157, 64);
            this.textBox_CM.Name = "textBox_CM";
            this.textBox_CM.Size = new System.Drawing.Size(100, 20);
            this.textBox_CM.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(301, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 24);
            this.button1.TabIndex = 7;
            this.button1.Text = "Filter pour objects with left properties:";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // filteredPours
            // 
            this.filteredPours.Location = new System.Drawing.Point(422, 54);
            this.filteredPours.Name = "filteredPours";
            this.filteredPours.Size = new System.Drawing.Size(34, 20);
            this.filteredPours.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Filtered Pour Objects:";
            // 
            // checkBox_PUName
            // 
            this.checkBox_PUName.AutoSize = true;
            this.checkBox_PUName.Location = new System.Drawing.Point(42, 131);
            this.checkBox_PUName.Name = "checkBox_PUName";
            this.checkBox_PUName.Size = new System.Drawing.Size(97, 17);
            this.checkBox_PUName.TabIndex = 10;
            this.checkBox_PUName.Text = "Pour unit name";
            this.checkBox_PUName.UseVisualStyleBackColor = true;
            // 
            // textBox_PUName
            // 
            this.textBox_PUName.Location = new System.Drawing.Point(145, 131);
            this.textBox_PUName.Name = "textBox_PUName";
            this.textBox_PUName.Size = new System.Drawing.Size(100, 20);
            this.textBox_PUName.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(289, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(214, 26);
            this.button2.TabIndex = 12;
            this.button2.Text = "Filter pour units with left property";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Filtered Pour Units:";
            // 
            // filteredPU
            // 
            this.filteredPU.Location = new System.Drawing.Point(388, 162);
            this.filteredPU.Name = "filteredPU";
            this.filteredPU.Size = new System.Drawing.Size(58, 20);
            this.filteredPU.TabIndex = 14;
            // 
            // checkBox_surfaceName
            // 
            this.checkBox_surfaceName.AutoSize = true;
            this.checkBox_surfaceName.Location = new System.Drawing.Point(42, 255);
            this.checkBox_surfaceName.Name = "checkBox_surfaceName";
            this.checkBox_surfaceName.Size = new System.Drawing.Size(101, 17);
            this.checkBox_surfaceName.TabIndex = 15;
            this.checkBox_surfaceName.Text = "Surface name =";
            this.checkBox_surfaceName.UseVisualStyleBackColor = true;
            // 
            // checkBox_surfaceType
            // 
            this.checkBox_surfaceType.AutoSize = true;
            this.checkBox_surfaceType.Location = new System.Drawing.Point(42, 278);
            this.checkBox_surfaceType.Name = "checkBox_surfaceType";
            this.checkBox_surfaceType.Size = new System.Drawing.Size(95, 17);
            this.checkBox_surfaceType.TabIndex = 16;
            this.checkBox_surfaceType.Text = "Surface type =";
            this.checkBox_surfaceType.UseVisualStyleBackColor = true;
            // 
            // checkBox_surfaceClass
            // 
            this.checkBox_surfaceClass.AutoSize = true;
            this.checkBox_surfaceClass.Location = new System.Drawing.Point(42, 301);
            this.checkBox_surfaceClass.Name = "checkBox_surfaceClass";
            this.checkBox_surfaceClass.Size = new System.Drawing.Size(99, 17);
            this.checkBox_surfaceClass.TabIndex = 17;
            this.checkBox_surfaceClass.Text = "Surface class =";
            this.checkBox_surfaceClass.UseVisualStyleBackColor = true;
            // 
            // textBox_surfaceName
            // 
            this.textBox_surfaceName.Location = new System.Drawing.Point(145, 252);
            this.textBox_surfaceName.Name = "textBox_surfaceName";
            this.textBox_surfaceName.Size = new System.Drawing.Size(100, 20);
            this.textBox_surfaceName.TabIndex = 18;
            // 
            // textBox_surfaceType
            // 
            this.textBox_surfaceType.Location = new System.Drawing.Point(145, 275);
            this.textBox_surfaceType.Name = "textBox_surfaceType";
            this.textBox_surfaceType.Size = new System.Drawing.Size(100, 20);
            this.textBox_surfaceType.TabIndex = 19;
            // 
            // textBox_surfaceClass
            // 
            this.textBox_surfaceClass.Location = new System.Drawing.Point(145, 298);
            this.textBox_surfaceClass.Name = "textBox_surfaceClass";
            this.textBox_surfaceClass.Size = new System.Drawing.Size(100, 20);
            this.textBox_surfaceClass.TabIndex = 20;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(289, 248);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(213, 23);
            this.button3.TabIndex = 21;
            this.button3.Text = "Filter surface objects with left properties";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Filtered Surface Objects:";
            // 
            // filteredSurfaces
            // 
            this.filteredSurfaces.Location = new System.Drawing.Point(420, 283);
            this.filteredSurfaces.Name = "filteredSurfaces";
            this.filteredSurfaces.Size = new System.Drawing.Size(70, 20);
            this.filteredSurfaces.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 442);
            this.Controls.Add(this.filteredSurfaces);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox_surfaceClass);
            this.Controls.Add(this.textBox_surfaceType);
            this.Controls.Add(this.textBox_surfaceName);
            this.Controls.Add(this.checkBox_surfaceClass);
            this.Controls.Add(this.checkBox_surfaceType);
            this.Controls.Add(this.checkBox_surfaceName);
            this.Controls.Add(this.filteredPU);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox_PUName);
            this.Controls.Add(this.checkBox_PUName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filteredPours);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_CM);
            this.Controls.Add(this.textBox_pourType);
            this.Controls.Add(this.textBox_pourNumber);
            this.Controls.Add(this.checkBox_pourCM);
            this.Controls.Add(this.checkBox_pourType);
            this.Controls.Add(this.checkBox_pourNumber);
            this.Name = "Form1";
            this.Text = "Filter examples for Pours and Surfaces";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_pourNumber;
        private System.Windows.Forms.CheckBox checkBox_pourType;
        private System.Windows.Forms.CheckBox checkBox_pourCM;
        private System.Windows.Forms.TextBox textBox_pourNumber;
        private System.Windows.Forms.TextBox textBox_pourType;
        private System.Windows.Forms.TextBox textBox_CM;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox filteredPours;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_PUName;
        private System.Windows.Forms.TextBox textBox_PUName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox filteredPU;
        private System.Windows.Forms.CheckBox checkBox_surfaceName;
        private System.Windows.Forms.CheckBox checkBox_surfaceType;
        private System.Windows.Forms.CheckBox checkBox_surfaceClass;
        private System.Windows.Forms.TextBox textBox_surfaceName;
        private System.Windows.Forms.TextBox textBox_surfaceType;
        private System.Windows.Forms.TextBox textBox_surfaceClass;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox filteredSurfaces;
    }
}

