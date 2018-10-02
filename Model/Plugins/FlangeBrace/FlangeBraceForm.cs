using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TSPlugins = Tekla.Structures.Plugins;
using Tekla.Structures.Plugins;
using Tekla.Structures.Dialog;
using Tekla.Structures.Datatype;

namespace FlangeBrace
{
    public partial class FlangeBraceForm : PluginFormBase
    {
        public FlangeBraceForm()
        {
            InitializeComponent();
        }

        private void okApplyModifyGetOnOffCancel1_ApplyClicked(object sender, EventArgs e)
        {
            this.Apply();
            
        }

        private void okApplyModifyGetOnOffCancel1_ModifyClicked(object sender, EventArgs e)
        {
            this.Modify();
        }

        private void okApplyModifyGetOnOffCancel1_CancelClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okApplyModifyGetOnOffCancel1_GetClicked(object sender, EventArgs e)
        {
            this.Get();
        }

        private void okApplyModifyGetOnOffCancel1_OnOffClicked(object sender, EventArgs e)
        {
            this.ToggleSelection();
        }

        private void okApplyModifyGetOnOffCancel1_OkClicked(object sender, EventArgs e)
        {
            this.Apply();
            this.Close();
        }

        private void profileCatalog1_SelectClicked(object sender, EventArgs e)
        {
            profileCatalog1.SelectedProfile = textBox1.Text;
        }

        private void profileCatalog1_SelectionDone(object sender, EventArgs e)
        {
            SetAttributeValue(textBox1,profileCatalog1.SelectedProfile);
        }

        private void materialCatalog1_SelectClicked(object sender, EventArgs e)
        {
            materialCatalog1.SelectedMaterial = textBox4.Text;
        }

        private void materialCatalog1_SelectionDone(object sender, EventArgs e)
        {
            SetAttributeValue(textBox4,materialCatalog1.SelectedMaterial);
        }

        private void materialCatalog2_SelectClicked(object sender, EventArgs e)
        {
            materialCatalog2.SelectedMaterial = textBox7.Text;
        }

        private void materialCatalog2_SelectionDone(object sender, EventArgs e)
        {
            SetAttributeValue(textBox7,materialCatalog2.SelectedMaterial);
        }

        private void materialCatalog3_SelectClicked(object sender, EventArgs e)
        {
            materialCatalog3.SelectedMaterial = textBox15.Text;
        }

        private void materialCatalog3_SelectionDone(object sender, EventArgs e)
        {
            SetAttributeValue(textBox15, materialCatalog3.SelectedMaterial);
        }
    }
}