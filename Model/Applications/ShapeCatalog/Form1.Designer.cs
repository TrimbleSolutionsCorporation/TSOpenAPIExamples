namespace ShapeCatalog
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
            this.shapeCatalog1 = new Tekla.Structures.Dialog.UIControls.ShapeCatalog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.structuresExtender.SetAttributeName(this.button1, null);
            this.structuresExtender.SetAttributeTypeName(this.button1, null);
            this.structuresExtender.SetBindPropertyName(this.button1, null);
            this.button1.Location = new System.Drawing.Point(46, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "BeamButton";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // shapeCatalog1
            // 
            this.structuresExtender.SetAttributeName(this.shapeCatalog1, null);
            this.structuresExtender.SetAttributeTypeName(this.shapeCatalog1, null);
            this.shapeCatalog1.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.shapeCatalog1, null);
            this.shapeCatalog1.Location = new System.Drawing.Point(154, 83);
            this.shapeCatalog1.Name = "shapeCatalog1";
            this.shapeCatalog1.SelectedShape = "";
            this.shapeCatalog1.Size = new System.Drawing.Size(88, 27);
            this.shapeCatalog1.TabIndex = 1;
            this.shapeCatalog1.SelectClicked += new System.EventHandler(this.shapeCatalog1_SelectClicked);
            this.shapeCatalog1.SelectionDone += new System.EventHandler(this.shapeCatalog1_SelectionDone);
            // 
            // textBox1
            // 
            this.structuresExtender.SetAttributeName(this.textBox1, null);
            this.structuresExtender.SetAttributeTypeName(this.textBox1, null);
            this.structuresExtender.SetBindPropertyName(this.textBox1, null);
            this.textBox1.Location = new System.Drawing.Point(9, 83);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(108, 20);
            this.textBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.structuresExtender.SetAttributeName(this, null);
            this.structuresExtender.SetAttributeTypeName(this, null);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(259, 156);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.shapeCatalog1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "ShapeCatalog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Tekla.Structures.Dialog.UIControls.ShapeCatalog shapeCatalog1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

