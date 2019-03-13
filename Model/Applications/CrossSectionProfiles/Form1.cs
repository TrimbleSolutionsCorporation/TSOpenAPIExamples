using System;
using System.Windows.Forms;
using Tekla.Structures.Catalogs;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Geometry3d;

namespace CrossSectionProfiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModelObjectSelector mos = new ModelObjectSelector();

            var moe = mos.GetSelectedObjects();

            if (moe.GetSize() != 1) return;

            moe.MoveNext();
            var mySelectedPart = moe.Current as Tekla.Structures.Model.Part;

            if (mySelectedPart == null || String.IsNullOrEmpty(mySelectedPart.Profile.ProfileString)) return;

            CrossSection section = new CrossSection(mySelectedPart.Profile.ProfileString);

            if (section.Select())
            {
                var outerSurface = section.OuterSurface;
                if (outerSurface != null)
                {
                    foreach (CrossSectionPoint point in outerSurface)
                    {
                        Console.WriteLine("Point " + string.Format("({0:0.000}, {1:0.000}, {2:0.000})", point.X, point.Y, point.Z));
                        Console.WriteLine("Chamfer type " + point.Chamfer.Type.ToString());
                        Console.WriteLine("Chamfer " + string.Format("({0:0.000}, {1:0.000}, {2:0.000}, {3:0.000})", point.Chamfer.X, point.Chamfer.Y, point.Chamfer.DZ1, point.Chamfer.DZ2));
                    }

                    Console.WriteLine(mySelectedPart.Profile.ProfileString + " cross section points selected successfully");
                }

                var outerSurfacePoints = section.OuterSurfacePoints;

                if (outerSurfacePoints != null)
                {
                    foreach (Point p in outerSurfacePoints)
                    {
                        Console.WriteLine("Point " + string.Format("({0:0.000}, {1:0.000}, {2:0.000})", p.X, p.Y, p.Z));
                    }

                    Console.WriteLine(mySelectedPart.Profile.ProfileString + " cross section points selected successfully");
                }
            }
        }
    }
}
