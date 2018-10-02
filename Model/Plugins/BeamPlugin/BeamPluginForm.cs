using System;

using Tekla.Structures.Dialog;

namespace BeamPlugin
{
    public partial class BeamPluginForm : PluginFormBase
    {
        public BeamPluginForm()
        {
            InitializeComponent();
        }

        //Use default values for plugins in models without a standard attribute file
        protected override string LoadValuesPath(string fileName)
        {
            SetAttributeValue(textBoxLengthFactor, 2d);  // One line for each plugin attribute
            SetAttributeValue(textBoxProfile, "HEA300");
            string Result = base.LoadValuesPath(fileName);
            Apply();
            return Result;
        }

        //Remember to assign these events to the buttons.
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
    }
}
