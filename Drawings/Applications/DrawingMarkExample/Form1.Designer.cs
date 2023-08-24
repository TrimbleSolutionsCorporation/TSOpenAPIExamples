namespace DrawingMarkExample
{
    partial class DrawingMarkExampleForm
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
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.buttonModify = new System.Windows.Forms.Button();
            this.checkBoxProfile = new System.Windows.Forms.CheckBox();
            this.checkBoxMainPartSecondary = new System.Windows.Forms.CheckBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.fontDialog2 = new System.Windows.Forms.FontDialog();
            this.radioButtonRed = new System.Windows.Forms.RadioButton();
            this.radioButtonGreen = new System.Windows.Forms.RadioButton();
            this.radioButtonBlue = new System.Windows.Forms.RadioButton();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.StartPointX = new System.Windows.Forms.Label();
            this.StartPointY = new System.Windows.Forms.Label();
            this.textBoxStartPointX = new System.Windows.Forms.TextBox();
            this.textBoxStartPointY = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(39, 29);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(87, 23);
            this.buttonDelete.TabIndex = 0;
            this.buttonDelete.Text = "Delete Marks";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(39, 90);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(130, 23);
            this.buttonInsert.TabIndex = 1;
            this.buttonInsert.Text = "Insert Marks All Objects";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // buttonModify
            // 
            this.buttonModify.Location = new System.Drawing.Point(39, 186);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(87, 23);
            this.buttonModify.TabIndex = 2;
            this.buttonModify.Text = "Modify Marks";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // checkBoxProfile
            // 
            this.checkBoxProfile.AutoSize = true;
            this.checkBoxProfile.Checked = true;
            this.checkBoxProfile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxProfile.Location = new System.Drawing.Point(39, 132);
            this.checkBoxProfile.Name = "checkBoxProfile";
            this.checkBoxProfile.Size = new System.Drawing.Size(55, 17);
            this.checkBoxProfile.TabIndex = 3;
            this.checkBoxProfile.Text = "Profile";
            this.checkBoxProfile.UseVisualStyleBackColor = true;
            // 
            // checkBoxMainPartSecondary
            // 
            this.checkBoxMainPartSecondary.AutoSize = true;
            this.checkBoxMainPartSecondary.Location = new System.Drawing.Point(126, 132);
            this.checkBoxMainPartSecondary.Name = "checkBoxMainPartSecondary";
            this.checkBoxMainPartSecondary.Size = new System.Drawing.Size(133, 17);
            this.checkBoxMainPartSecondary.TabIndex = 4;
            this.checkBoxMainPartSecondary.Text = "Main Part / Secondary";
            this.checkBoxMainPartSecondary.UseVisualStyleBackColor = true;
            // 
            // radioButtonRed
            // 
            this.radioButtonRed.AutoSize = true;
            this.radioButtonRed.Checked = true;
            this.radioButtonRed.Location = new System.Drawing.Point(151, 189);
            this.radioButtonRed.Name = "radioButtonRed";
            this.radioButtonRed.Size = new System.Drawing.Size(45, 17);
            this.radioButtonRed.TabIndex = 5;
            this.radioButtonRed.TabStop = true;
            this.radioButtonRed.Text = "Red";
            this.radioButtonRed.UseVisualStyleBackColor = true;
            // 
            // radioButtonGreen
            // 
            this.radioButtonGreen.AutoSize = true;
            this.radioButtonGreen.Location = new System.Drawing.Point(202, 189);
            this.radioButtonGreen.Name = "radioButtonGreen";
            this.radioButtonGreen.Size = new System.Drawing.Size(54, 17);
            this.radioButtonGreen.TabIndex = 6;
            this.radioButtonGreen.Text = "Green";
            this.radioButtonGreen.UseVisualStyleBackColor = true;
            // 
            // radioButtonBlue
            // 
            this.radioButtonBlue.AutoSize = true;
            this.radioButtonBlue.Location = new System.Drawing.Point(262, 189);
            this.radioButtonBlue.Name = "radioButtonBlue";
            this.radioButtonBlue.Size = new System.Drawing.Size(46, 17);
            this.radioButtonBlue.TabIndex = 7;
            this.radioButtonBlue.Text = "Blue";
            this.radioButtonBlue.UseVisualStyleBackColor = true;
            // 
            // buttonUndo
            // 
            this.buttonUndo.Location = new System.Drawing.Point(262, 29);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(75, 23);
            this.buttonUndo.TabIndex = 8;
            this.buttonUndo.Text = "Undo";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            // 
            // StartPointX
            // 
            this.StartPointX.AutoSize = true;
            this.StartPointX.Location = new System.Drawing.Point(41, 227);
            this.StartPointX.Name = "StartX";
            this.StartPointX.Size = new System.Drawing.Size(51, 13);
            this.StartPointX.TabIndex = 9;
            this.StartPointX.Text = "Start X: ";
            // 
            // StartPointY
            // 
            this.StartPointY.AutoSize = true;
            this.StartPointY.Location = new System.Drawing.Point(195, 227);
            this.StartPointY.Name = "StartY";
            this.StartPointY.Size = new System.Drawing.Size(51, 13);
            this.StartPointY.TabIndex = 10;
            this.StartPointY.Text = "Start Y: ";
            // 
            // textBoxStartPointX
            // 
            this.textBoxStartPointX.Location = new System.Drawing.Point(88, 224);
            this.textBoxStartPointX.Name = "textBoxStartPointX";
            this.textBoxStartPointX.Size = new System.Drawing.Size(97, 20);
            this.textBoxStartPointX.TabIndex = 11;
            this.textBoxStartPointX.Text = "0";
            // 
            // textBoxStartPointY
            // 
            this.textBoxStartPointY.Location = new System.Drawing.Point(243, 224);
            this.textBoxStartPointY.Name = "textBoxStartPointY";
            this.textBoxStartPointY.Size = new System.Drawing.Size(97, 20);
            this.textBoxStartPointY.TabIndex = 12;
            this.textBoxStartPointY.Text = "0";
            // 
            // DrawingMarkExampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 279);
            this.Controls.Add(this.textBoxStartPointY);
            this.Controls.Add(this.textBoxStartPointX);
            this.Controls.Add(this.StartPointY);
            this.Controls.Add(this.StartPointX);
            this.Controls.Add(this.buttonUndo);
            this.Controls.Add(this.radioButtonBlue);
            this.Controls.Add(this.radioButtonGreen);
            this.Controls.Add(this.radioButtonRed);
            this.Controls.Add(this.checkBoxMainPartSecondary);
            this.Controls.Add(this.checkBoxProfile);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.buttonDelete);
            this.Name = "DrawingMarkExampleForm";
            this.Text = "Drawing Mark Example";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.CheckBox checkBoxProfile;
        private System.Windows.Forms.CheckBox checkBoxMainPartSecondary;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.FontDialog fontDialog2;
        private System.Windows.Forms.RadioButton radioButtonRed;
        private System.Windows.Forms.RadioButton radioButtonGreen;
        private System.Windows.Forms.RadioButton radioButtonBlue;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.Label StartPointX;
        private System.Windows.Forms.Label StartPointY;
        private System.Windows.Forms.TextBox textBoxStartPointX;
        private System.Windows.Forms.TextBox textBoxStartPointY;
    }
}

