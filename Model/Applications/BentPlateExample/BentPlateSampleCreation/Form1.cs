using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace BentPlateSampleCreation
{
    /// <summary>
    /// This example shows how to create simple bent plates using different creation methods:
    /// 1. Using Operations namespace: CreateBentPlateByParts and CreateBentPlateByFaces methods.
    /// 2. Using ConnectiveGeometry and BentPlateGeometrySolver classes.
    /// </summary>
    public partial class Form1 : Form
    {
        BentPlate bentPlate;
        ContourPlate samplePlate1, samplePlate2;
        Model model = null;

        public Form1()
        {
            InitializeComponent();
            bentPlate = null;
            samplePlate1 = null;
            samplePlate2 = null;
            this.model = new Model();
        }

        //Creates simple ContourPlates for the example.
        private void CreateSamplePlatesButton_Click(object sender, EventArgs e)
        {
            this.CheckAndCreateSamplePlates();
        }

        //Creates BentPlate object with maximum radius.
        private void CreateMaxRadiusBentPlate_Click(object sender, EventArgs e)
        {
            try
            {
                if (samplePlate1 != null && samplePlate2 != null)
                {
                    this.bentPlate = Tekla.Structures.Model.Operations.Operation.CreateBentPlateByParts(this.samplePlate1, this.samplePlate2);
                    this.model.CommitChanges();
                }
                else
                {
                    this.CreateMaxRadiusBendPlate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }

        //Creates simple ContourPlates for the example.
        private void CreateSamplePlatesButton2_Click(object sender, EventArgs e)
        {
            this.CreateBentPlateWithGivenRadius.Enabled = true;
            this.CheckAndCreateSamplePlates();
        }

        //Creates BentPlate object with defined radius from the view.
        private void CreateBentPlateWithGivenRadius_Click(object sender, EventArgs e)
        {
            try
            {
                if (samplePlate1 != null && samplePlate2 != null)
                {
                    double radius = (double)this.radiusValue.Value;
                    if (radius < 100.0 && radius > 1500.0)
                    {
                        //Simple creation of bend using 2 existing contour plates from model and defined radius.
                        this.bentPlate = Tekla.Structures.Model.Operations.Operation.CreateBentPlateByParts(this.samplePlate1, this.samplePlate2, 600.0);
                    }
                    else
                    {
                        //Simple creation of bend using 2 existing contour plates from model and radius from numeric view object.
                        this.bentPlate = Tekla.Structures.Model.Operations.Operation.CreateBentPlateByParts(this.samplePlate1, this.samplePlate2, radius);
                    }

                    this.model.CommitChanges();
                }
                else
                {
                    this.CreateMaxRadiusBendPlate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }

        //Simple bent plate creation using ConnectiveGeometry object and AddLeg from BentPlateGeometrySolver helper class.
        private void SimpleCreateByAddLeg_Click(object sender, EventArgs e)
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

        //Simple bent plate creation with defined radius, using ConnectiveGeometry object and AddLeg from BentPlateGeometrySolver helper class.
        private void CreateByAddLEgWithRadius_Click(object sender, EventArgs e)
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

                double radius = (double)this.RadiusForAddLegCreation.Value;

                //Use solver to add new contour and specify desired radius to the existing geometry which will give you as a result a bent plate geometry
                //or an exception if modification failed.
                BentPlateGeometrySolver solver = new BentPlateGeometrySolver();
                geometry = solver.AddLeg(geometry, contour2, radius);

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

        //Creates simple ContourPlates for the example.
        private void CreateByFacesSamplePlates_Click(object sender, EventArgs e)
        {
            this.CreateSampleBentPlateByFaces.Enabled = true;
            this.CheckAndCreateSamplePlates();
        }

        //Simple BentPlate creation using faces from the ContourPlate.
        private void CreateSampleBentPlateByFaces_Click(object sender, EventArgs e)
        {
            try
            {
                //Create face point to use for the sample bent plate creation.
                IList<Point> face1 = new List<Point>();
                face1.Add(new Point(0.0, 3000.0, -10.0));
                face1.Add(new Point(0.0, 3000.0, 10.0));
                face1.Add(new Point(3000.0, 3000.0, 10.0));
                face1.Add(new Point(30000.0, 3000.0, -10.0));

                IList<Point> face2 = new List<Point>();
                face2.Add(new Point(0.0, 6010.0, 1500.0));
                face2.Add(new Point(0.0, 5990.0, 1500.0));
                face2.Add(new Point(3000.0, 5990.0, 1500.0));
                face2.Add(new Point(3000.0, 6010.0, 1500.0));

                if (samplePlate1 != null && samplePlate2 != null)
                {
                    //Simple creation of bend using 2 existing contour plates and faces from model 
                    //using CreateBentPlateByFaces from Operations namespace.
                    this.bentPlate = Tekla.Structures.Model.Operations.Operation.CreateBentPlateByFaces(this.samplePlate1, face1, this.samplePlate2, face2);
                    this.model.CommitChanges();
                }
                else
                {
                    this.CreateMaxRadiusBendPlate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }

        //Simple bent plate creation with segments, using ConnectiveGeometry object and AddLeg from BentPlateGeometrySolver helper class.
        private void CreateByAddLegUsingSegments_Click(object sender, EventArgs e)
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

                double radius = (double)this.RadiusForAddLegWithSegments.Value;

                //Create segments from the plate sides to be connected. First side is from the ConnectiveGeometry, second from the contour.
                LineSegment faceSegment1 = new LineSegment(new Point(500.0, 3000.0, 0.0), new Point(2500.0, 3000.0, 0.0));
                LineSegment faceSegment2 = new LineSegment(new Point(500.0, 6000.0, 1500.0), new Point(2500.0, 6000.0, 1500.0));

                //Use solver to add new contour and specify desired radius and LineSegmets (as faces in 2D) to the existing geometry which will give you as a result a bent plate geometry
                //or an exception if modification failed.
                BentPlateGeometrySolver solver = new BentPlateGeometrySolver();
                geometry = solver.AddLeg(geometry, faceSegment1, contour2, faceSegment2, radius);

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

        private void CheckAndCreateSamplePlates()
        {
            if (!this.CreateMaxRadiusBendPlate.Enabled)
            {
                this.CreateMaxRadiusBendPlate.Enabled = true;
            }

            if (this.bentPlate != null)
            {
                this.bentPlate.Delete();
                this.bentPlate = null;
            }

            //Create sample plates and insert to the model.
            this.CreateSamplePlates();
        }

        /// <summary>
        /// Creates sample contour plates for further bend creation.
        /// </summary>
        private void CreateSamplePlates()
        {
            var contour1 = new Contour();
            contour1.AddContourPoint(new ContourPoint(new Point(0.0, 0.0, 0.0), null));
            contour1.AddContourPoint(new ContourPoint(new Point(3000.0, 0.0, 0.0), null));
            contour1.AddContourPoint(new ContourPoint(new Point(3000.0, 3000.0, 0.0), null));
            contour1.AddContourPoint(new ContourPoint(new Point(0.0, 3000.0, 0.0), null));

            this.samplePlate1 = new ContourPlate
            {
                Name = "Plate",
                Material = { MaterialString = "S235JR" },
                Profile = { ProfileString = "PL20" },
                Position = { Depth = Position.DepthEnum.MIDDLE, DepthOffset = 0.0 }
            };

            this.samplePlate1.Contour = contour1;
            this.samplePlate1.Insert();

            var contour2 = new Contour();
            contour2.AddContourPoint(new ContourPoint(new Point(0.0, 6000.0, 1500.0), null));
            contour2.AddContourPoint(new ContourPoint(new Point(3000.0, 6000.0, 1500.0), null));
            contour2.AddContourPoint(new ContourPoint(new Point(3000.0, 6000.0, 4500.0), null));
            contour2.AddContourPoint(new ContourPoint(new Point(0.0, 6000.0, 4500.0), null));

            this.samplePlate2 = new ContourPlate
            {
                Name = "Plate",
                Material = { MaterialString = "S235JR" },
                Profile = { ProfileString = "PL20" },
                Position = { Depth = Position.DepthEnum.MIDDLE, DepthOffset = 0.0 }
            };

            this.samplePlate2.Contour = contour2;
            this.samplePlate2.Insert();

            this.model.CommitChanges();
        }
    }
}
