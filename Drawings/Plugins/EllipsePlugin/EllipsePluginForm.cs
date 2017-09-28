using System;
using Tekla.Structures.Dialog;

namespace EllipsePlugin
{
    public partial class EllipsePluginForm : PluginFormBase
    {
        public EllipsePluginForm()
        {
            InitializeComponent();
        }

        private void ApplyClicked(object sender, EventArgs e)
        {
            Apply();
        }

        private void CancelClicked(object sender, EventArgs e)
        {
            Close();
        }

        private void GetClicked(object sender, EventArgs e)
        {
            Get();
        }

        private void ModifyClicked(object sender, EventArgs e)
        {
            Modify();
        }

        private void OnOffClicked(object sender, EventArgs e)
        {
            ToggleSelection();
        }

        private void AcceptClicked(object sender, EventArgs e)
        {
            Apply();
            Close();
        }

    }
}