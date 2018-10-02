using System;
using Tekla.Structures.Dialog;

namespace BeamCustomPart
{
    public partial class BeamCustomPartForm : PluginFormBase
    {
        public BeamCustomPartForm()
        {
            this.InitializeComponent();
        }

        // Use default values for plugins in models without a standard attribute file
        protected override string LoadValuesPath(string fileName)
        {
            this.SetAttributeValue(this.textBoxLengthFactor, 2d);  // One line for each plugin attribute
            this.SetAttributeValue(this.textBoxProfile, "HEA300");
            string result = base.LoadValuesPath(fileName);
            this.Apply();
            return result;
        }

        // Remember to assign these events to the buttons.
        private void okApplyModifyGetOnOffCancel1_ApplyClicked(object sender, EventArgs e)
        {
            this.Apply();
        }

        private void okApplyModifyGetOnOffCancel1_CancelClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okApplyModifyGetOnOffCancel1_GetClicked(object sender, EventArgs e)
        {
            this.Get();
        }

        private void okApplyModifyGetOnOffCancel1_ModifyClicked(object sender, EventArgs e)
        {
            this.Modify();
        }

        private void okApplyModifyGetOnOffCancel1_OkClicked(object sender, EventArgs e)
        {
            this.Apply();
            this.Close();
        }

        private void okApplyModifyGetOnOffCancel1_OnOffClicked(object sender, EventArgs e)
        {
            this.ToggleSelection();
        }

        private void profileCatalog1_SelectionDone(object sender, EventArgs e)
        {
            this.textBoxProfile.Text = profileCatalog1.SelectedProfile;
            SetAttributeValue(this.textBoxProfile, profileCatalog1.SelectedProfile);
        }

        private void profileCatalog1_SelectClicked(object sender, EventArgs e)
        {
            profileCatalog1.SelectedProfile = this.textBoxProfile.Text;
        }
    }
}
