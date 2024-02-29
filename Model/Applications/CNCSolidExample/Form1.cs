using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Tekla.Structures.Model;
using Tekla.Structures.Solid;

namespace CNCSolidExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model Model = new Model();
            double MaximumOffset = Double.Parse(textBox1.Text);

            Dictionary<Plane, Face> FirstBeamPlanes = new Dictionary<Plane, Face>();
            Dictionary<Plane, Face> SecondaryBeamPlanes = new Dictionary<Plane, Face>();

            CNCSolidLogic.GetParts(ref FirstBeamPlanes, ref SecondaryBeamPlanes);
            CNCSolidLogic.CompareNormals(FirstBeamPlanes, SecondaryBeamPlanes, MaximumOffset);
            
            Model.CommitChanges();
        }
    }
}