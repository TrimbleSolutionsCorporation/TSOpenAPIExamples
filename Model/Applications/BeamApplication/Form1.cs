using System;
using System.Windows.Forms;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

namespace BeamApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model myModel = new Model();

            Beam myBeam = new Beam(new TSG.Point(1000, 1000, 1000),
                                    new TSG.Point(6000, 6000, 1000));
            myBeam.Material.MaterialString = "S235JR";
            myBeam.Profile.ProfileString = "HEA400";
            myBeam.Insert();
            myModel.CommitChanges();
        }
    }
}