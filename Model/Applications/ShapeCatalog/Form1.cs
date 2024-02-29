using System;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;
using Tekla.Structures.Dialog;

namespace ShapeCatalog
{
    public partial class Form1 : ApplicationFormBase
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Model myModel = new Model();
            if (this.textBox1.Text == string.Empty)
            {
                Beam myBeam = new Beam(new TSG.Point(1000, 1000, 1000),
                                        new TSG.Point(6000, 6000, 1000));
                myBeam.Material.MaterialString = "S235JR";
                myBeam.Profile.ProfileString = "HEA400";
                myBeam.Insert();
            }
            else
            {
                Brep brep = new Brep(new TSG.Point(1000, 1000, 1000),
                                        new TSG.Point(6000, 6000, 1000));
                brep.Material.MaterialString = "S235JR";
                brep.Profile.ProfileString = this.textBox1.Text;
                brep.Insert();
            }

            ModelObjectEnumerator myEnum = myModel.GetModelObjectSelector().GetAllObjectsWithType(ModelObject.ModelObjectEnum.BEAM);
            myEnum.MoveNext();

            Detail detail = new Detail();
            detail.Number = 1003;
            detail.SetPrimaryObject(myEnum.Current);
            detail.SetReferencePoint(new TSG.Point((myEnum.Current as Beam).StartPoint));
            detail.LoadAttributesFromFile("standard");
            if (detail.Insert())
            {
                detail.Code = "test";
                detail.Modify();
            }

            myModel.CommitChanges();
        }

        private void shapeCatalog1_SelectClicked(object sender, EventArgs e)
        {
            shapeCatalog1.SelectedShape = this.textBox1.Text;
        }

        private void shapeCatalog1_SelectionDone(object sender, EventArgs e)
        {
            this.textBox1.Text = shapeCatalog1.SelectedShape;
        }
    }
}