using System;
using System.Windows.Forms;

using Tekla.Structures.Model;
using Tekla.Structures.Geometry3d;

namespace BentPlateModificationExample
{
    /// <summary>
    /// Example which shows different possibilities to modify BentPlate object using BentPlateGeometrySolver.
    /// 1. ModifyPolygon: will modify contour of the ConnectiveGeometry PolygonNode geometry section.
    /// 2. ModifyRadius: will modify radius of the ConnectiveGeometry CylindricalSurfaceNode geometry section.
    /// 3. ModifyCylindricalSurface: will modify cylindrical surface of the ConnectiveGeometry CylindricalSurfaceNode geometry section.
    /// </summary>
    public partial class Form1 : Form
    {
        BentPlate bentPlate;
        Model model;

        public Form1()
        {
            InitializeComponent();
            this.bentPlate = null;
            this.model = new Model();
        }

        private void CreateSimpleBentPlate1_Click(object sender, EventArgs e)
        {
            this.ModifyPlateSide.Enabled = true;
            //Creates simple BentPlate object in the model.
            this.CreateSampleBentPlate();
        }

        private void CreateSimpleBentPlate2_Click(object sender, EventArgs e)
        {
            this.ModifyRadius.Enabled = true;
            //Creates simple BentPlate object in the model.
            this.CreateSampleBentPlate();
        }

        private void CreateSimpleBentPlate3_Click(object sender, EventArgs e)
        {
            this.ModifyCylindricalSide.Enabled = true;
            //Creates simple BentPlate object in the model.
            this.CreateSampleBentPlate();
        }

        //Changes contour for the first polygon of the created BentPlate object.
        private void ModifyPlateSide_Click(object sender, EventArgs e)
        {
            this.ModifyPlateSide.Enabled = false;

            //Get enumerator for BentPlate geometry.
            var geometryEnumerator = this.bentPlate.Geometry.GetGeometryEnumerator();

            while (geometryEnumerator.MoveNext())
            {
                //set enumerator Current element on the first PolygonNode GeometrySection. 
                if (geometryEnumerator.Current.GeometryNode is PolygonNode)
                {
                    break;
                }
            }

            if (geometryEnumerator.Current != null)
            {
                //Create new Contour for the PolygonNode to change.
                var contour1 = new Contour();
                contour1.AddContourPoint(new ContourPoint(new Point(500.0, 0.0, 0.0), null));
                contour1.AddContourPoint(new ContourPoint(new Point(2000.0, 0.0, 0.0), null));
                contour1.AddContourPoint(new ContourPoint(new Point(2000.0, 3000.0, 0.0), null));
                contour1.AddContourPoint(new ContourPoint(new Point(500.0, 3000.0, 0.0), null));

                try
                {
                    BentPlateGeometrySolver solver = new BentPlateGeometrySolver();
                    //Modify polygon contour.
                    var changedGeometry = solver.ModifyPolygon(this.bentPlate.Geometry, geometryEnumerator.Current, contour1);

                    //Set new geometry with changed PolygonNode to BentPlate object.
                    this.bentPlate.Geometry = changedGeometry;
                    this.bentPlate.Modify();
                    this.model.CommitChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.ToString());
                }
            }
        }

        //Changes radius for the first cylindrical section of the created BentPlate object.
        private void ModifyRadius_Click(object sender, EventArgs e)
        {
            this.ModifyRadius.Enabled = false;

            double radiusValue = (double)this.RadiusValue.Value;

            //Get enumerator for BentPlate geometry.
            var geometryEnumerator = this.bentPlate.Geometry.GetGeometryEnumerator();

            while (geometryEnumerator.MoveNext())
            {
                //set enumerator Current element on the first CylindricalSurfaceNode GeometrySection. 
                if (geometryEnumerator.Current.GeometryNode is CylindricalSurfaceNode)
                {
                    break;
                }
            }

            if (geometryEnumerator.Current != null)
            {
                try
                {
                    BentPlateGeometrySolver solver = new BentPlateGeometrySolver();
                    //Modify radius of the selected CylindricalSurfaceNode to radiusValue.
                    var changedGeometry = solver.ModifyRadius(this.bentPlate.Geometry, geometryEnumerator.Current, radiusValue);

                    //Set new geometry with changed CylindricalSurfaceNode to BentPlate object.
                    this.bentPlate.Geometry = changedGeometry;
                    this.bentPlate.Modify();
                    this.model.CommitChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.ToString());
                }
            }
        }

        //Changes side boundaries for the first cylindrical section of the created BentPlate object.
        private void ModifyCylindricalSide_Click(object sender, EventArgs e)
        {
            this.ModifyCylindricalSide.Enabled = false;

            //Get enumerator for BentPlate geometry.
            var geometryEnumerator = this.bentPlate.Geometry.GetGeometryEnumerator();

            CylindricalSurfaceNode cylindricalSection = null;
            while (geometryEnumerator.MoveNext())
            {
                //Find first CylindricalSurfaceNode and save it.
                if (geometryEnumerator.Current.GeometryNode is CylindricalSurfaceNode)
                {
                    cylindricalSection = geometryEnumerator.Current.GeometryNode as CylindricalSurfaceNode;
                    break;
                }
            }

            if (cylindricalSection != null)
            {
                try
                {
                    Vector endFaceNormal1 = cylindricalSection.Surface.EndFaceNormal1;
                    Vector endFaceNormal2 = cylindricalSection.Surface.EndFaceNormal2;
                    LineSegment sideBoundary1 = new LineSegment(new Point(500.0, 4500.0, 0.0), new Point(2500.0, 4500.0, 0.0));
                    LineSegment sideBoundary2 = new LineSegment(new Point(500.0, 6000.0, 1500.0), new Point(2500.0, 6000.0, 1500.0));

                    //Create new CylindricalSurface to be applied on selected CylindricalSurfaceNode.
                    CylindricalSurface newCylindricalSurface = new CylindricalSurface(endFaceNormal1, endFaceNormal2, sideBoundary1, sideBoundary2);

                    BentPlateGeometrySolver solver = new BentPlateGeometrySolver();

                    //Modify CylindricalSurface of the selected CylindricalSurfaceNode to newCylindricalSurface.
                    var changedGeometry = solver.ModifyCylindricalSurface(this.bentPlate.Geometry, geometryEnumerator.Current, newCylindricalSurface);

                    //Set new geometry with changed CylindricalSurfaceNode to BentPlate object.
                    this.bentPlate.Geometry = changedGeometry;
                    this.bentPlate.Modify();
                    this.model.CommitChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.ToString());
                }
            }
        }

        /// <summary>
        /// Creates sample BentPlate object.
        /// </summary>
        private void CreateSampleBentPlate()
        {
            try
            {
                if (this.bentPlate != null)
                {
                    this.bentPlate.Delete();
                }

                var contour1 = new Contour();
                contour1.AddContourPoint(new ContourPoint(new Point(0.0, 0.0, 0.0), null));
                contour1.AddContourPoint(new ContourPoint(new Point(3000.0, 0.0, 0.0), null));
                contour1.AddContourPoint(new ContourPoint(new Point(3000.0, 3000.0, 0.0), null));
                contour1.AddContourPoint(new ContourPoint(new Point(0.0, 3000.0, 0.0), null));

                //First create a main contour geometry.
                ConnectiveGeometry geometry = new ConnectiveGeometry(contour1);

                var contour2 = new Contour();
                contour2.AddContourPoint(new ContourPoint(new Point(0.0, 6000.0, 1500.0), null));
                contour2.AddContourPoint(new ContourPoint(new Point(3000.0, 6000.0, 1500.0), null));
                contour2.AddContourPoint(new ContourPoint(new Point(3000.0, 6000.0, 4500.0), null));
                contour2.AddContourPoint(new ContourPoint(new Point(0.0, 6000.0, 4500.0), null));

                //Use solver to add new contour to the existing geometry which will give you as a result a bent plate geometry
                //or an exception if creation failed.
                BentPlateGeometrySolver solver = new BentPlateGeometrySolver();
                geometry = solver.AddLeg(geometry, contour2);

                //Create a new BentPlate object.
                this.bentPlate = new BentPlate
                {
                    Name = "Plate",
                    Material = { MaterialString = "S235JR" },
                    Profile = { ProfileString = "PL20" },
                };

                //Set created geometry to BentPlate object.
                this.bentPlate.Geometry = geometry;
                this.bentPlate.Insert();
                this.model.CommitChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }
}
