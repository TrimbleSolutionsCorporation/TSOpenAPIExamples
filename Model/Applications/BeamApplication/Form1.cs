using System;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;
using Tekla.Structures.Dialog;

namespace BeamApplication
{
    public partial class Form1 : ApplicationFormBase
    {
        public Form1()
        {
            InitializeComponent();
            InitializeForm();
        }

        protected override string LoadValuesPath(string fileName)
        {
            SetAttributeValue(textBox1, "HEA200");
            string Result = base.LoadValuesPath(fileName);
            Apply();
            return Result;
        }

        private void createApplyCancel1_ApplyClicked(object sender, EventArgs e)
        {
            this.Apply();
        }

        private void createApplyCancel1_CreateClicked(object sender, EventArgs e)
        {
            Model myModel = new Model();

            Beam myBeam = new Beam(new TSG.Point(1000, 1000, 1000),
                                    new TSG.Point(6000, 6000, 1000));
            myBeam.Material.MaterialString = "S235JR";
            string profileName = GetAttributeValue<string>("Profile");
            myBeam.Profile.ProfileString = profileName;
            myBeam.Insert();
            myModel.CommitChanges();
        }

        private void createApplyCancel1_CancelClicked(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}