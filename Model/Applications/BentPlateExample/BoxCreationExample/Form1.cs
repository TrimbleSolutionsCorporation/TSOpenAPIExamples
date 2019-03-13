using System;
using System.Windows.Forms;

using Tekla.Structures.Model;
using Tekla.Structures.Geometry3d;

namespace BoxCreationExample
{
    /// <summary>
    /// This example shows how to create simple box using different bent plate creation methods:
    /// 1. Using Operations namespace: CreateBentPlateByFaces method.
    /// 2. Using ConnectiveGeometry and BentPlateGeometrySolver classes.
    /// </summary>
    public partial class Form1 : Form
    {
        BentPlate bentPlate;
        ContourPlate bottomPlate, sidePlate1, sidePlate2, sidePlate3, sidePlate4;
        Model model;

        public Form1()
        {
            InitializeComponent();
            this.bentPlate = null;
            this.bottomPlate = null;
            this.sidePlate1 = null;
            this.sidePlate2 = null;
            this.sidePlate3 = null;
            this.sidePlate4 = null;
            this.model = new Model();
        }

        //Creates ContourPlates in the model with specified position for box shape creation.
        private void CreateContourPlates_Click(object sender, EventArgs e)
        {
            if (this.bentPlate != null)
            {
                this.bentPlate.Delete();
                this.bentPlate = null;
            }

            //Create sample contour plates for box creation.
            this.CreatePlatesForBox();

            this.CreateBends.Enabled = true;
            this.CreateBoxWithCustomRadius.Enabled = true;
        }

        //Creates bends between created plates to obtain box shape.
        private void CreateBends_Click(object sender, EventArgs e)
        {
            this.CreateBends.Enabled = false;
            this.CreateBoxWithCustomRadius.Enabled = false;

            if(this.bentPlate != null)
            {
                this.bentPlate.Delete();
                this.bentPlate = null;
            }

            if (this.bottomPlate != null && this.sidePlate1 != null && this.sidePlate2 != null && this.sidePlate3 != null && this.sidePlate4 != null)
            {
                //get solid faces to create bends from the bottom contour plate.
                var bottomFacesEnum = this.bottomPlate.GetSolid().GetFaceEnumerator();
                while (bottomFacesEnum.MoveNext())
                {
                    //use to connect only side faces from the bottom contour plate.
                    if (bottomFacesEnum.Current.Normal.Y > 0.0)
                    {
                        //Get the bottom facing face for creation from the side contour plate.
                        var plateBottomFace = this.GetPlateBottomFace(this.sidePlate2.GetSolid().GetFaceEnumerator());
                        //Create a bend between plates using faces.
                        this.CreateBend(bottomPlate, bottomFacesEnum.Current, sidePlate2, plateBottomFace);
                    }
                    else if (bottomFacesEnum.Current.Normal.Y < 0.0)
                    {
                        var plateBottomFace = this.GetPlateBottomFace(this.sidePlate4.GetSolid().GetFaceEnumerator());
                        this.CreateBend(bottomPlate, bottomFacesEnum.Current, sidePlate4, plateBottomFace);
                    }

                    if (bottomFacesEnum.Current.Normal.X > 0.0)
                    {
                        var plateBottomFace = this.GetPlateBottomFace(this.sidePlate3.GetSolid().GetFaceEnumerator());
                        this.CreateBend(bottomPlate, bottomFacesEnum.Current, sidePlate3, plateBottomFace);
                    }
                    else if (bottomFacesEnum.Current.Normal.X < 0.0)
                    {
                        var plateBottomFace = this.GetPlateBottomFace(this.sidePlate1.GetSolid().GetFaceEnumerator());
                        this.CreateBend(bottomPlate, bottomFacesEnum.Current, sidePlate1, plateBottomFace);
                    }
                }

                model.CommitChanges();
            }
        }

        //Creates bends between created plates with selected radius to obtain box shape.
        private void CreateBoxWithCustomRadius_Click(object sender, EventArgs e)
        {
            this.CreateBends.Enabled = false;
            this.CreateBoxWithCustomRadius.Enabled = false;
            if (this.bentPlate != null)
            {
                this.bentPlate.Delete();
                this.bentPlate = null;
            }

            double radius = (double)this.CustomRadiusValue.Value;

            if (this.bottomPlate != null && this.sidePlate1 != null && this.sidePlate2 != null && this.sidePlate3 != null && this.sidePlate4 != null)
            {
                //get solid faces to create bends from the bottom contour plate.
                var bottomFacesEnum = this.bottomPlate.GetSolid().GetFaceEnumerator();
                while (bottomFacesEnum.MoveNext())
                {
                    //use to connect only side faces from the bottom contour plate.
                    if (bottomFacesEnum.Current.Normal.Y > 0.0)
                    {
                        //Get the bottom facing face for creation from the side contour plate.
                        var plateBottomFace = this.GetPlateBottomFace(this.sidePlate2.GetSolid().GetFaceEnumerator());
                        //Create a bend between plates using faces and radius. 
                        this.CreateBendWithRadius(bottomPlate, bottomFacesEnum.Current, sidePlate2, plateBottomFace, radius);
                    }
                    else if (bottomFacesEnum.Current.Normal.Y < 0.0)
                    {
                        var plateBottomFace = this.GetPlateBottomFace(this.sidePlate4.GetSolid().GetFaceEnumerator());
                        this.CreateBendWithRadius(bottomPlate, bottomFacesEnum.Current, sidePlate4, plateBottomFace, radius);
                    }

                    if (bottomFacesEnum.Current.Normal.X > 0.0)
                    {
                        var plateBottomFace = this.GetPlateBottomFace(this.sidePlate3.GetSolid().GetFaceEnumerator());
                        this.CreateBendWithRadius(bottomPlate, bottomFacesEnum.Current, sidePlate3, plateBottomFace, radius);
                    }
                    else if (bottomFacesEnum.Current.Normal.X < 0.0)
                    {
                        var plateBottomFace = this.GetPlateBottomFace(this.sidePlate1.GetSolid().GetFaceEnumerator());
                        this.CreateBendWithRadius(bottomPlate, bottomFacesEnum.Current, sidePlate1, plateBottomFace, radius);
                    }
                }

                model.CommitChanges();
            }
        }

        //Create a bend between plates using faces.
        private void CreateBend(ContourPlate plate1, Tekla.Structures.Solid.Face face1, ContourPlate plate2, Tekla.Structures.Solid.Face face2)
        {
            if (this.bentPlate == null)
            {
                this.bentPlate = Tekla.Structures.Model.Operations.Operation.CreateBentPlateByFaces(plate1, face1, plate2, face2);
            }
            else
            {
                this.bentPlate = Tekla.Structures.Model.Operations.Operation.CreateBentPlateByFaces(this.bentPlate, face1, plate2, face2);
            }
        }

        //Create a bend between plates using faces and radius.
        private void CreateBendWithRadius(ContourPlate plate1, Tekla.Structures.Solid.Face face1, ContourPlate plate2, Tekla.Structures.Solid.Face face2, double radius)
        {
            if (this.bentPlate == null)
            {
                this.bentPlate = Tekla.Structures.Model.Operations.Operation.CreateBentPlateByFaces(plate1, face1, plate2, face2, radius);
            }
            else
            {
                this.bentPlate = Tekla.Structures.Model.Operations.Operation.CreateBentPlateByFaces(this.bentPlate, face1, plate2, face2, radius);
            }
        }

        //Gets solid face which faces into negative Z direction.
        private Tekla.Structures.Solid.Face GetPlateBottomFace(Tekla.Structures.Solid.FaceEnumerator faceEnumerator)
        {
            while(faceEnumerator.MoveNext())
            {
                if(faceEnumerator.Current.Normal.Z < 0.0)
                {
                    return faceEnumerator.Current;
                }
            }

            return null;
        }

        //Create sample contour plates for box creation.
        private void CreatePlatesForBox()
        {
            var bottomContour = new Contour();
            bottomContour.AddContourPoint(new ContourPoint(new Point(6000.0, 6000.0, 0.0), null));
            bottomContour.AddContourPoint(new ContourPoint(new Point(6000.0, 12000.0, 0.0), null));
            bottomContour.AddContourPoint(new ContourPoint(new Point(12000.0, 12000.0, 0.0), null));
            bottomContour.AddContourPoint(new ContourPoint(new Point(12000.0, 6000.0, 0.0), null));

            this.bottomPlate = new ContourPlate
            {
                Name = "Plate",
                Material = { MaterialString = "S235JR" },
                Profile = { ProfileString = "PL100" },
                Position = { Depth = Position.DepthEnum.MIDDLE, DepthOffset = 0.0 },
                Contour = bottomContour
            };

            var contour1 = new Contour();
            contour1.AddContourPoint(new ContourPoint(new Point(3000.0, 6000.0, 1500.0), null));
            contour1.AddContourPoint(new ContourPoint(new Point(3000.0, 12000.0, 1500.0), null));
            contour1.AddContourPoint(new ContourPoint(new Point(3000.0, 12000.0, 4500.0), null));
            contour1.AddContourPoint(new ContourPoint(new Point(3000.0, 6000.0, 4500.0), null));

            this.sidePlate1 = new ContourPlate
            {
                Name = "Plate",
                Material = { MaterialString = "S235JR" },
                Profile = { ProfileString = "PL100" },
                Position = { Depth = Position.DepthEnum.MIDDLE, DepthOffset = 0.0 },
                Contour = contour1
            };

            var contour2 = new Contour();
            contour2.AddContourPoint(new ContourPoint(new Point(6000.0, 15000.0, 1500.0), null));
            contour2.AddContourPoint(new ContourPoint(new Point(12000.0, 15000.0, 1500.0), null));
            contour2.AddContourPoint(new ContourPoint(new Point(12000.0, 15000.0, 4500.0), null));
            contour2.AddContourPoint(new ContourPoint(new Point(6000.0, 15000.0, 4500.0), null));

            this.sidePlate2 = new ContourPlate
            {
                Name = "Plate",
                Material = { MaterialString = "S235JR" },
                Profile = { ProfileString = "PL100" },
                Position = { Depth = Position.DepthEnum.MIDDLE, DepthOffset = 0.0 },
                Contour = contour2
            };

            var contour3 = new Contour();
            contour3.AddContourPoint(new ContourPoint(new Point(15000.0, 6000.0, 1500.0), null));
            contour3.AddContourPoint(new ContourPoint(new Point(15000.0, 12000.0, 1500.0), null));
            contour3.AddContourPoint(new ContourPoint(new Point(15000.0, 12000.0, 4500.0), null));
            contour3.AddContourPoint(new ContourPoint(new Point(15000.0, 6000.0, 4500.0), null));

            this.sidePlate3 = new ContourPlate
            {
                Name = "Plate",
                Material = { MaterialString = "S235JR" },
                Profile = { ProfileString = "PL100" },
                Position = { Depth = Position.DepthEnum.MIDDLE, DepthOffset = 0.0 },
                Contour = contour3
            };

            var contour4 = new Contour();
            contour4.AddContourPoint(new ContourPoint(new Point(6000.0, 3000.0, 1500.0), null));
            contour4.AddContourPoint(new ContourPoint(new Point(12000.0, 3000.0, 1500.0), null));
            contour4.AddContourPoint(new ContourPoint(new Point(12000.0, 3000.0, 4500.0), null));
            contour4.AddContourPoint(new ContourPoint(new Point(6000.0, 3000.0, 4500.0), null));

            this.sidePlate4 = new ContourPlate
            {
                Name = "Plate",
                Material = { MaterialString = "S235JR" },
                Profile = { ProfileString = "PL100" },
                Position = { Depth = Position.DepthEnum.MIDDLE, DepthOffset = 0.0 },
                Contour = contour4
            };

            this.bottomPlate.Insert();
            this.sidePlate1.Insert();
            this.sidePlate2.Insert();
            this.sidePlate3.Insert();
            this.sidePlate4.Insert();
            this.model.CommitChanges();
        }

        //Create box using ConnectiveGeometry class.
        private void CreateBoxUsingGeometry_Click(object sender, EventArgs e)
        {
            if(this.bentPlate != null)
            {
                this.bentPlate.Delete();
                this.bentPlate = null;
            }

            var bottomContour = new Contour();
            bottomContour.AddContourPoint(new ContourPoint(new Point(6000.0, 6000.0, 0.0), null));
            bottomContour.AddContourPoint(new ContourPoint(new Point(6000.0, 12000.0, 0.0), null));
            bottomContour.AddContourPoint(new ContourPoint(new Point(12000.0, 12000.0, 0.0), null));
            bottomContour.AddContourPoint(new ContourPoint(new Point(12000.0, 6000.0, 0.0), null));

            var contour1 = new Contour();
            contour1.AddContourPoint(new ContourPoint(new Point(3000.0, 6000.0, 1500.0), null));
            contour1.AddContourPoint(new ContourPoint(new Point(3000.0, 12000.0, 1500.0), null));
            contour1.AddContourPoint(new ContourPoint(new Point(3000.0, 12000.0, 4500.0), null));
            contour1.AddContourPoint(new ContourPoint(new Point(3000.0, 6000.0, 4500.0), null));

            var contour2 = new Contour();
            contour2.AddContourPoint(new ContourPoint(new Point(6000.0, 15000.0, 1500.0), null));
            contour2.AddContourPoint(new ContourPoint(new Point(12000.0, 15000.0, 1500.0), null));
            contour2.AddContourPoint(new ContourPoint(new Point(12000.0, 15000.0, 4500.0), null));
            contour2.AddContourPoint(new ContourPoint(new Point(6000.0, 15000.0, 4500.0), null));

            var contour3 = new Contour();
            contour3.AddContourPoint(new ContourPoint(new Point(15000.0, 6000.0, 1500.0), null));
            contour3.AddContourPoint(new ContourPoint(new Point(15000.0, 12000.0, 1500.0), null));
            contour3.AddContourPoint(new ContourPoint(new Point(15000.0, 12000.0, 4500.0), null));
            contour3.AddContourPoint(new ContourPoint(new Point(15000.0, 6000.0, 4500.0), null));

            var contour4 = new Contour();
            contour4.AddContourPoint(new ContourPoint(new Point(6000.0, 3000.0, 1500.0), null));
            contour4.AddContourPoint(new ContourPoint(new Point(12000.0, 3000.0, 1500.0), null));
            contour4.AddContourPoint(new ContourPoint(new Point(12000.0, 3000.0, 4500.0), null));
            contour4.AddContourPoint(new ContourPoint(new Point(6000.0, 3000.0, 4500.0), null));

            //create new ConnectiveGeometry object initialized with contour object.
            ConnectiveGeometry geometry = new ConnectiveGeometry(bottomContour);

            //Create solver for ConnectiveGeometry modifications.
            BentPlateGeometrySolver solver = new BentPlateGeometrySolver();

            //Create segments from the plate sides to be connected. First side is from the ConnectiveGeometry, second from the contour.
            LineSegment segment1 = new LineSegment(new Point(6000.0, 6000.0, 0.0), new Point(6000.0, 12000.0, 0.0));
            LineSegment segment2 = new LineSegment(new Point(3000.0, 6000.0, 1500.0), new Point(3000.0, 12000.0, 1500.0));

            //Use AddLeg method to create bend between contours.
            geometry = solver.AddLeg(geometry, segment1, contour1, segment2);

            segment1 = new LineSegment(new Point(6000.0, 12000.0, 0.0), new Point(12000.0, 12000.0, 0.0));
            segment2 = new LineSegment(new Point(6000.0, 15000.0, 1500.0), new Point(12000.0, 15000.0, 1500.0));

            geometry = solver.AddLeg(geometry, segment1, contour2, segment2);

            segment1 = new LineSegment(new Point(12000.0, 6000.0, 0.0), new Point(12000.0, 12000.0, 0.0));
            segment2 = new LineSegment(new Point(15000.0, 6000.0, 1500.0), new Point(15000.0, 12000.0, 1500.0));

            geometry = solver.AddLeg(geometry, segment1, contour3, segment2);

            segment1 = new LineSegment(new Point(6000.0, 6000.0, 0.0), new Point(12000.0, 6000.0, 0.0));
            segment2 = new LineSegment(new Point(6000.0, 3000.0, 1500.0), new Point(12000.0, 3000.0, 1500.0));

            geometry = solver.AddLeg(geometry, segment1, contour4, segment2);

            //Create a new BentPlate object.
            this.bentPlate = new BentPlate
            {
                Name = "Plate",
                Material = { MaterialString = "S235JR" },
                Profile = { ProfileString = "PL100" },
            };

            //Set created geometry to BentPlate object.
            this.bentPlate.Geometry = geometry;
            this.bentPlate.Insert();
            this.model.CommitChanges();
        }

        private void CreateBoxUsingGeometryAndRadius_Click(object sender, EventArgs e)
        {
            if (this.bentPlate != null)
            {
                this.bentPlate.Delete();
                this.bentPlate = null;
            }

            double radius = (double)this.RadiusValueForAddLeg.Value;

            var bottomContour = new Contour();
            bottomContour.AddContourPoint(new ContourPoint(new Point(6000.0, 6000.0, 0.0), null));
            bottomContour.AddContourPoint(new ContourPoint(new Point(6000.0, 12000.0, 0.0), null));
            bottomContour.AddContourPoint(new ContourPoint(new Point(12000.0, 12000.0, 0.0), null));
            bottomContour.AddContourPoint(new ContourPoint(new Point(12000.0, 6000.0, 0.0), null));

            var contour1 = new Contour();
            contour1.AddContourPoint(new ContourPoint(new Point(3000.0, 6000.0, 1500.0), null));
            contour1.AddContourPoint(new ContourPoint(new Point(3000.0, 12000.0, 1500.0), null));
            contour1.AddContourPoint(new ContourPoint(new Point(3000.0, 12000.0, 4500.0), null));
            contour1.AddContourPoint(new ContourPoint(new Point(3000.0, 6000.0, 4500.0), null));

            var contour2 = new Contour();
            contour2.AddContourPoint(new ContourPoint(new Point(6000.0, 15000.0, 1500.0), null));
            contour2.AddContourPoint(new ContourPoint(new Point(12000.0, 15000.0, 1500.0), null));
            contour2.AddContourPoint(new ContourPoint(new Point(12000.0, 15000.0, 4500.0), null));
            contour2.AddContourPoint(new ContourPoint(new Point(6000.0, 15000.0, 4500.0), null));

            var contour3 = new Contour();
            contour3.AddContourPoint(new ContourPoint(new Point(15000.0, 6000.0, 1500.0), null));
            contour3.AddContourPoint(new ContourPoint(new Point(15000.0, 12000.0, 1500.0), null));
            contour3.AddContourPoint(new ContourPoint(new Point(15000.0, 12000.0, 4500.0), null));
            contour3.AddContourPoint(new ContourPoint(new Point(15000.0, 6000.0, 4500.0), null));

            var contour4 = new Contour();
            contour4.AddContourPoint(new ContourPoint(new Point(6000.0, 3000.0, 1500.0), null));
            contour4.AddContourPoint(new ContourPoint(new Point(12000.0, 3000.0, 1500.0), null));
            contour4.AddContourPoint(new ContourPoint(new Point(12000.0, 3000.0, 4500.0), null));
            contour4.AddContourPoint(new ContourPoint(new Point(6000.0, 3000.0, 4500.0), null));

            //create new ConnectiveGeometry object initialized with contour object.
            ConnectiveGeometry geometry = new ConnectiveGeometry(bottomContour);

            //Create solver for ConnectiveGeometry modifications.
            BentPlateGeometrySolver solver = new BentPlateGeometrySolver();

            //Create segments from the plate sides to be connected. First side is from the ConnectiveGeometry, second from the contour.
            LineSegment segment1 = new LineSegment(new Point(6000.0, 6000.0, 0.0), new Point(6000.0, 12000.0, 0.0));
            LineSegment segment2 = new LineSegment(new Point(3000.0, 6000.0, 1500.0), new Point(3000.0, 12000.0, 1500.0));

            //Use AddLeg method to create bend between contours.
            geometry = solver.AddLeg(geometry, segment1, contour1, segment2, radius);

            segment1 = new LineSegment(new Point(6000.0, 12000.0, 0.0), new Point(12000.0, 12000.0, 0.0));
            segment2 = new LineSegment(new Point(6000.0, 15000.0, 1500.0), new Point(12000.0, 15000.0, 1500.0));

            geometry = solver.AddLeg(geometry, segment1, contour2, segment2, radius);

            segment1 = new LineSegment(new Point(12000.0, 6000.0, 0.0), new Point(12000.0, 12000.0, 0.0));
            segment2 = new LineSegment(new Point(15000.0, 6000.0, 1500.0), new Point(15000.0, 12000.0, 1500.0));

            geometry = solver.AddLeg(geometry, segment1, contour3, segment2, radius);

            segment1 = new LineSegment(new Point(6000.0, 6000.0, 0.0), new Point(12000.0, 6000.0, 0.0));
            segment2 = new LineSegment(new Point(6000.0, 3000.0, 1500.0), new Point(12000.0, 3000.0, 1500.0));

            geometry = solver.AddLeg(geometry, segment1, contour4, segment2, radius);

            //Create a new BentPlate object.
            this.bentPlate = new BentPlate
            {
                Name = "Plate",
                Material = { MaterialString = "S235JR" },
                Profile = { ProfileString = "PL100" },
            };

            //Set created geometry to BentPlate object.
            this.bentPlate.Geometry = geometry;
            this.bentPlate.Insert();
            this.model.CommitChanges();
        }
    }
}
