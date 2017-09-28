namespace SimpleDrawingList
{
    partial class SimpleDrawingList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleDrawingList));
            this.drawingListTreeView = new System.Windows.Forms.TreeView();
            this.DeleteObject = new System.Windows.Forms.Button();
            this.OpenSelectedDrawing = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.ShowViews = new System.Windows.Forms.CheckBox();
            this.ShowObjectsInViews = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawingListTreeView
            // 
            this.drawingListTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingListTreeView.Location = new System.Drawing.Point(6, 89);
            this.drawingListTreeView.Name = "drawingListTreeView";
            this.drawingListTreeView.Size = new System.Drawing.Size(213, 177);
            this.drawingListTreeView.TabIndex = 1;
            // 
            // DeleteObject
            // 
            this.DeleteObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteObject.Location = new System.Drawing.Point(243, 39);
            this.DeleteObject.Name = "DeleteObject";
            this.DeleteObject.Size = new System.Drawing.Size(144, 23);
            this.DeleteObject.TabIndex = 3;
            this.DeleteObject.Text = "Delete selection";
            this.DeleteObject.UseVisualStyleBackColor = true;
            this.DeleteObject.Click += new System.EventHandler(this.DeleteObject_Click);
            // 
            // OpenSelectedDrawing
            // 
            this.OpenSelectedDrawing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenSelectedDrawing.Location = new System.Drawing.Point(243, 12);
            this.OpenSelectedDrawing.Name = "OpenSelectedDrawing";
            this.OpenSelectedDrawing.Size = new System.Drawing.Size(144, 23);
            this.OpenSelectedDrawing.TabIndex = 4;
            this.OpenSelectedDrawing.Text = "Open selected drawing";
            this.OpenSelectedDrawing.UseVisualStyleBackColor = true;
            this.OpenSelectedDrawing.Click += new System.EventHandler(this.OpenDrawing_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshButton.Location = new System.Drawing.Point(243, 256);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(144, 23);
            this.RefreshButton.TabIndex = 5;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshDrawingList_click);
            // 
            // ShowViews
            // 
            this.ShowViews.AutoSize = true;
            this.ShowViews.Location = new System.Drawing.Point(6, 19);
            this.ShowViews.Name = "ShowViews";
            this.ShowViews.Size = new System.Drawing.Size(83, 17);
            this.ShowViews.TabIndex = 6;
            this.ShowViews.Text = "Show views";
            this.ShowViews.UseVisualStyleBackColor = true;
            this.ShowViews.CheckedChanged += new System.EventHandler(this.ShowViews_CheckedChanged);
            // 
            // ShowObjectsInViews
            // 
            this.ShowObjectsInViews.AutoSize = true;
            this.ShowObjectsInViews.Enabled = false;
            this.ShowObjectsInViews.Location = new System.Drawing.Point(6, 42);
            this.ShowObjectsInViews.Name = "ShowObjectsInViews";
            this.ShowObjectsInViews.Size = new System.Drawing.Size(131, 17);
            this.ShowObjectsInViews.TabIndex = 7;
            this.ShowObjectsInViews.Text = "Show objects in views";
            this.ShowObjectsInViews.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.ShowObjectsInViews);
            this.groupBox1.Controls.Add(this.ShowViews);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 64);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contents";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.drawingListTreeView);
            this.groupBox3.Location = new System.Drawing.Point(12, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(225, 272);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Drawings";
            // 
            // SimpleDrawingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 286);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.OpenSelectedDrawing);
            this.Controls.Add(this.DeleteObject);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "SimpleDrawingList";
            this.Text = "Tekla Structures - Drawing enumerator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView drawingListTreeView;
        private System.Windows.Forms.Button DeleteObject;
        private System.Windows.Forms.Button OpenSelectedDrawing;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.CheckBox ShowViews;
        private System.Windows.Forms.CheckBox ShowObjectsInViews;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

