using System;
using System.Globalization;

using Tekla.Structures.Datatype;
using Tekla.Structures.Dialog;

namespace ReinforcedBeam
{
    public partial class ReinforcedBeamForm : PluginFormBase
    {
        public ReinforcedBeamForm()
        {
            InitializeComponent();
        }

        private void okApplyModifyGetOnOffCancel1_OkClicked(object sender, EventArgs e)
        {
            this.Apply();
            this.Close();
        }

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

        private void okApplyModifyGetOnOffCancel1_OnOffClicked(object sender, EventArgs e)
        {
            this.ToggleSelection();
        }

        // When profile catalog control is clicked the value on the text box is 
        // selected in the Profile selection form, if exists in the catalog
        private void profileCatalog1_SelectClicked(object sender, EventArgs e)
        {
            profileCatalog1.SelectedProfile = BeamProfileTextBox.Text;
        }

        // Adds the profile selected in the Profile selection form to the text box
        private void profileCatalog1_SelectionDone(object sender, EventArgs e)
        {
            //Note: Notice that you cannot set the value straight into the text box using:
            //Note: BeamProfileTextBox.Text = profileCatalog1.SelectedProfile
            SetAttributeValue(BeamProfileTextBox, profileCatalog1.SelectedProfile);
        }

        // When reninforcement catalog control is clicked the value on the text box is 
        // selected in the Reinforcement selection form, if exists in the catalog
        private void reinforcementCatalog1_SelectClicked(object sender, EventArgs e)
        {
            reinforcementCatalog1.SelectedRebarSize = RebarSizeTextBox.Text;
            reinforcementCatalog1.SelectedRebarGrade = RebarGradeTextBox.Text;
            reinforcementCatalog1.SelectedRebarBendingRadius = Distance.Parse(RebarBendingRadiusTextBox.Text, CultureInfo.InvariantCulture).Millimeters;
        }

        // Adds the rebar selected in the Reinforcement selection form to the text box
        private void reinforcementCatalog1_SelectionDone(object sender, EventArgs e)
        {
            //Note: Notice that you cannot set the values straight into the text box using:
            //Note: RebarSizeTextBox.Text = reinforcementCatalog1.RebarSize
            SetAttributeValue(RebarSizeTextBox, reinforcementCatalog1.SelectedRebarSize);
            SetAttributeValue(RebarGradeTextBox, reinforcementCatalog1.SelectedRebarGrade);
            SetAttributeValue(RebarBendingRadiusTextBox, new Distance(reinforcementCatalog1.SelectedRebarBendingRadius));
        }
    }
}