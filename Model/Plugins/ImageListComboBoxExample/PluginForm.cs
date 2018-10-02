namespace ImageListComboBoxExample
{
    using Tekla.Structures.Dialog;

    public partial class PluginForm : PluginFormBase
    {
        public PluginForm()
        {
            InitializeComponent();
        }

        //Use default values for plugins in models without a standard attribute file
        protected override string LoadValuesPath(string fileName)
        {
            SetAttributeValue(ColorComboBox, 2);  // One line for each plugin attribute
            SetAttributeValue(textBoxProfile, "HEA300");
            string Result = base.LoadValuesPath(fileName);
            Apply();
            return Result;
        }

        private void okApplyModifyGetOnOffCancel1_ApplyClicked(object sender, System.EventArgs e)
        {
            this.Apply();
        }

        private void okApplyModifyGetOnOffCancel1_CancelClicked(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void okApplyModifyGetOnOffCancel1_GetClicked(object sender, System.EventArgs e)
        {
            this.Get();
        }

        private void okApplyModifyGetOnOffCancel1_ModifyClicked(object sender, System.EventArgs e)
        {
            this.Modify();
        }

        private void okApplyModifyGetOnOffCancel1_OkClicked(object sender, System.EventArgs e)
        {
            this.Apply();
            this.Close();
        }

        private void okApplyModifyGetOnOffCancel1_OnOffClicked(object sender, System.EventArgs e)
        {
            this.ToggleSelection();
        }
    }
}
