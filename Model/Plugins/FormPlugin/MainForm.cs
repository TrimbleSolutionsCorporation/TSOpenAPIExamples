using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tekla.Structures.Datatype;
using Tekla.Structures.Dialog;

namespace FormPlugin
{
    public partial class MainForm : PluginFormBase
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Apply();
            this.Close();
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            this.Modify();
        }
    }
}