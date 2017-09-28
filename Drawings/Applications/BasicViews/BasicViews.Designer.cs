namespace DrawingTestApplication1
{
    partial class BasicViews
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
            this.createTopView = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.create3dView = new System.Windows.Forms.CheckBox();
            this.createEndView = new System.Windows.Forms.CheckBox();
            this.createFrontView = new System.Windows.Forms.CheckBox();
            this.openDrawings = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Create_click);
            // 
            // createTopView
            // 
            this.createTopView.AutoSize = true;
            this.createTopView.Location = new System.Drawing.Point(6, 19);
            this.createTopView.Name = "createTopView";
            this.createTopView.Size = new System.Drawing.Size(70, 17);
            this.createTopView.TabIndex = 1;
            this.createTopView.Text = "Top view";
            this.createTopView.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.create3dView);
            this.groupBox1.Controls.Add(this.createEndView);
            this.groupBox1.Controls.Add(this.createFrontView);
            this.groupBox1.Controls.Add(this.createTopView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(122, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 126);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Views to be created";
            // 
            // create3dView
            // 
            this.create3dView.AutoSize = true;
            this.create3dView.Location = new System.Drawing.Point(6, 88);
            this.create3dView.Name = "create3dView";
            this.create3dView.Size = new System.Drawing.Size(63, 17);
            this.create3dView.TabIndex = 4;
            this.create3dView.Text = "3d view";
            this.create3dView.UseVisualStyleBackColor = true;
            // 
            // createEndView
            // 
            this.createEndView.AutoSize = true;
            this.createEndView.Location = new System.Drawing.Point(6, 65);
            this.createEndView.Name = "createEndView";
            this.createEndView.Size = new System.Drawing.Size(70, 17);
            this.createEndView.TabIndex = 3;
            this.createEndView.Text = "End view";
            this.createEndView.UseVisualStyleBackColor = true;
            // 
            // createFrontView
            // 
            this.createFrontView.AutoSize = true;
            this.createFrontView.Location = new System.Drawing.Point(6, 42);
            this.createFrontView.Name = "createFrontView";
            this.createFrontView.Size = new System.Drawing.Size(75, 17);
            this.createFrontView.TabIndex = 2;
            this.createFrontView.Text = "Front view";
            this.createFrontView.UseVisualStyleBackColor = true;
            // 
            // openDrawings
            // 
            this.openDrawings.AutoSize = true;
            this.openDrawings.Location = new System.Drawing.Point(12, 42);
            this.openDrawings.Name = "openDrawings";
            this.openDrawings.Size = new System.Drawing.Size(97, 17);
            this.openDrawings.TabIndex = 3;
            this.openDrawings.Text = "Open drawings";
            this.openDrawings.UseVisualStyleBackColor = true;
            // 
            // PartBasicViews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 126);
            this.Controls.Add(this.openDrawings);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.MinimumSize = new System.Drawing.Size(280, 160);
            this.Name = "PartBasicViews";
            this.Text = "Create basic views";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox createTopView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox create3dView;
        private System.Windows.Forms.CheckBox createEndView;
        private System.Windows.Forms.CheckBox createFrontView;
        private System.Windows.Forms.CheckBox openDrawings;
    }
}

