using System;
using System.Windows.Forms;

using Tekla.Structures;

namespace RebarSetExamples
{
    public partial class Form1 : Form
    {
        private Identifier rebarSetId;
        private Identifier propertyModifierId;
        private Identifier endDetailModifierId;
        private Identifier rebarSplitterId;
        private Identifier cutPlaneId;
        private RebarSetLogic rebarSetLogic;

        public Form1()
        {
            InitializeComponent();
            rebarSetLogic = new RebarSetLogic();
        }

        private void DisableControls(Control con)
        {
            foreach (Button c in con.Controls)
            {
                c.Enabled = false;
            }
        }

        private void btnInsertRebarSet_Click(object sender, EventArgs e)
        {
            rebarSetId = rebarSetLogic.InsertRebarSet();
            btnInsertRebarSet.Enabled = false;
            btnDeleteRebar.Enabled = true;
            btnCreateAddition.Enabled = true;
            btnCut.Enabled = true;
            btnPropertyModifier.Enabled = true;
            btnEndDetail.Enabled = true;
            btnRebarSplitter.Enabled = true;
            btnModifyGuideline.Enabled = true;
            btnModifyLegs.Enabled = true;
        }

        private void btnModifyLegs_Click(object sender, EventArgs e)
        {
            rebarSetLogic.ModifyLegs(rebarSetId);
            btnModifyLegs.Enabled = false;
        }

        private void btnModifyGuideline_Click(object sender, EventArgs e)
        {
            rebarSetLogic.ModifyGuideline(rebarSetId);
            btnModifyGuideline.Enabled = false;
        }

        private void btnDeleteRebar_Click(object sender, EventArgs e)
        {
            rebarSetLogic.DeleteRebar(rebarSetId);
            DisableControls(this);
            btnInsertRebarSet.Enabled = true;
        }

        private void btnCreateAddition_Click(object sender, EventArgs e)
        {
            rebarSetLogic.CreateAddition(rebarSetId);
            btnCreateAddition.Enabled = false;
        }

        private void btnPropertyModifier_Click(object sender, EventArgs e)
        {
            propertyModifierId = rebarSetLogic.CreatePropertyModifier(rebarSetId);
            btnPropertyModifier.Enabled = false;
            btnChangeModifier.Enabled = true;
            btnDeleteModifier.Enabled = true;
        }

        private void btnChangeModifier_Click(object sender, EventArgs e)
        {
            rebarSetLogic.ChangeModifier(propertyModifierId);
            btnChangeModifier.Enabled = false;
        }

        private void btnDeleteModifier_Click(object sender, EventArgs e)
        {
            rebarSetLogic.DeleteModifier(propertyModifierId);
            btnPropertyModifier.Enabled = true;
            btnChangeModifier.Enabled = false;
            btnDeleteModifier.Enabled = false;
        }

        private void btnEndDetail_Click(object sender, EventArgs e)
        {
            endDetailModifierId = rebarSetLogic.CreateEndDetail(rebarSetId);
            btnEndDetail.Enabled = false;
            btnModifyEndDetail.Enabled = true;
            btnDeleteEndDetail.Enabled = true;
        }

        private void btnModifyEndDetail_Click(object sender, EventArgs e)
        {
            rebarSetLogic.ChangeEndDetail(endDetailModifierId);
            btnModifyEndDetail.Enabled = false;
        }

        private void btnDeleteEndDetail_Click(object sender, EventArgs e)
        {
            rebarSetLogic.DeleteEndDetail(endDetailModifierId);
            btnEndDetail.Enabled = true;
            btnModifyEndDetail.Enabled = false;
            btnDeleteEndDetail.Enabled = false;
        }

        private void btnRebarSplitter_Click(object sender, EventArgs e)
        {
            rebarSplitterId = rebarSetLogic.CreateRebarSplitter(rebarSetId);
            btnChangeSplitter.Enabled = true;
            btnDeleteSplitter.Enabled = true;
            btnRebarSplitter.Enabled = false;
        }

        private void btnChangeSplitter_Click(object sender, EventArgs e)
        {
            rebarSetLogic.ChangeSplitter(rebarSplitterId);
            btnChangeSplitter.Enabled = false;
        }

        private void btnDeleteSplitter_Click(object sender, EventArgs e)
        {
            rebarSetLogic.DeleteSplitter(rebarSplitterId);
            btnRebarSplitter.Enabled = true;
            btnChangeSplitter.Enabled = false;
            btnDeleteSplitter.Enabled = false;
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            cutPlaneId = rebarSetLogic.CreateCutPlane(rebarSetId);
            btnDeleteCut.Enabled = true;
            btnCut.Enabled = false;
        }

        private void btnDeleteCut_Click(object sender, EventArgs e)
        {
            rebarSetLogic.DeleteCutPlane(cutPlaneId);
            btnCut.Enabled = true;
            btnDeleteCut.Enabled = false;
        }

    }
}
