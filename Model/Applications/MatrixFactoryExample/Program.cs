using System;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace MatrixFactoryExample
{
    internal class Program
    {
        static Beam beam1 = new Beam();
        static Beam beam2 = new Beam();
        static Detail detailEndPlate = new Detail();
        static Beam detailChildBeam = new Beam();
        static CoordinateSystem coordSys1 = new CoordinateSystem();
        static CoordinateSystem coordSys2 = new CoordinateSystem();
        static WorkPlaneHandler wph = new Model().GetWorkPlaneHandler();
        static Beam connectingBeam = new Beam();
        static void Main()
        {
            TransformationPlane oldPlane = wph.GetCurrentTransformationPlane();
            TransformationPlane globalPlane = new TransformationPlane();
            wph.SetCurrentTransformationPlane(globalPlane);

            CreateExampleObjects();

            ExampleToCoordinateSystem();
            ExampleFromCoordinateSystem();
            ExampleByCoordinateSystems();

            DeleteExampleObjects();

            wph.SetCurrentTransformationPlane(oldPlane);
        }

        private static void DeleteExampleObjects()
        {
            beam1.Delete();
            beam2.Delete();
            connectingBeam.Delete();
            new Model().CommitChanges();
        }

        private static void ExampleByCoordinateSystems()
        {
            // It is possible to model using points in different coordinate systems using matrix.
            detailEndPlate.Delete();
            double length1 = 0;
            double length2 = 0;
            beam1.GetReportProperty("LENGTH", ref length1);
            beam2.GetReportProperty("LENGTH", ref length2);

            // Max points of beams in their local coordinate systems, transformed to beam2 local coordinate system
            Matrix fromBeam1ToBeam2 = MatrixFactory.ByCoordinateSystems(coordSys1, coordSys2);
            Point beam1MaxPoint = fromBeam1ToBeam2.Transform(new Point(length1, 0, 0));
            Point beam2MaxPoint = new Point(length2, 0, 0);

            // Insert connecting beam in beam2 local coordinate system
            wph.SetCurrentTransformationPlane(new TransformationPlane(coordSys2));
            connectingBeam = new Beam(beam1MaxPoint, beam2MaxPoint);
            connectingBeam.Profile.ProfileString = "D30";
            connectingBeam.Insert();

            new Model().CommitChanges();

            // Check connecting beam length is same as distance between beam1 and beam2 max points in global coordinate system
            wph.SetCurrentTransformationPlane(new TransformationPlane());
            Point beam1MaxPointGlobal = beam1.GetCenterLine(false)[1] as Point;
            Point beam2MaxPointGlobal = beam2.GetCenterLine(false)[1] as Point;

            double lengthConnectingBeam = 0; 
            connectingBeam.GetReportProperty("LENGTH", ref lengthConnectingBeam);

            double lengthDistanceGlobal = Distance.PointToPoint(beam1MaxPointGlobal, beam2MaxPointGlobal);
            bool connectBeamResult = Math.Abs(lengthConnectingBeam - lengthDistanceGlobal) < 1;
        }

        private static void ExampleFromCoordinateSystem()
        {
            Matrix toCurrentWPFromBeam1 = MatrixFactory.FromCoordinateSystem(coordSys1);
            Matrix toCurrentWPFromBeam2 = MatrixFactory.FromCoordinateSystem(coordSys2);

            wph.SetCurrentTransformationPlane(new TransformationPlane());

            // Getting start points of beams in global coordinate system
            Point beam1SPGlobal = beam1.GetCenterLine(false)[0] as Point;
            Point beam2SPGlobal = beam2.GetCenterLine(false)[0] as Point;

            // Start points of beams in local coordinate systems are always (0,0,0)
            Point beam1SPLocal = new Point(0, 0, 0);
            Point beam2SPLocal = new Point(0, 0, 0);

            // Transforming start points of beams from local to current WP coordinate system
            Point beam1SPTransformed = toCurrentWPFromBeam1.Transform(beam1SPLocal);
            Point beam2SPTransformed = toCurrentWPFromBeam2.Transform(beam2SPLocal);

            bool distance1 = Distance.PointToPoint(beam1SPGlobal, beam1SPTransformed) < 1;
            bool distance2 = Distance.PointToPoint(beam2SPGlobal, beam2SPTransformed) < 1;
        }

        private static void ExampleToCoordinateSystem()
        {
            // Checks detail was inserted at beam1 start point.
            // Points are fetched in global WP, so these must be transformed to local beam coordsys using matrix.
            Matrix toLocalBeam1 = MatrixFactory.ToCoordinateSystem(coordSys1);

            Point beam1CenterLineSP = beam1.GetCenterLine(false)[0] as Point;
            // Start point of beam1 center line must be 0 in local coordinate system
            Point beam1CenterLineSPLocal = toLocalBeam1.Transform(beam1CenterLineSP);

            Point childBeamSPLocal = toLocalBeam1.Transform(detailChildBeam.StartPoint);

            double distance = Distance.PointToPoint(childBeamSPLocal, beam1CenterLineSPLocal);

            bool detailInBeam1StartPoint = Math.Abs(distance) < 300;

            // Second matrix checks beam2 center line start point is also at zero in its local coordinate system
            Matrix toLocalBeam2 = MatrixFactory.ToCoordinateSystem(coordSys2);
            Point beam2CenterLineSP = beam2.GetCenterLine(false)[0] as Point;
            // Start point of beam2 center line must be 0 in local coordinate system
            Point beam2CenterLineSPLocal = toLocalBeam2.Transform(beam2CenterLineSP);

        }

        private static void CreateExampleObjects()
        {
            beam1 = new Beam(new Point(5000, 5000), new Point(2500, 7500, 5000));
            beam2 = new Beam(new Point(5200, 5200), new Point(7500, 2500, 5000));

            beam1.Profile.ProfileString = beam2.Profile.ProfileString = "HEA300";
            beam1.Material.MaterialString = beam2.Material.MaterialString = "S235JR";
            beam1.Class = beam2.Class = "3";

            bool beam1Insert = beam1.Insert();
            bool beam2Insert = beam2.Insert();

            coordSys1 = beam1.GetCoordinateSystem();
            coordSys2 = beam2.GetCoordinateSystem();

            detailEndPlate.Name = "Detail";
            detailEndPlate.Number = 1002;
            detailEndPlate.SetReferencePoint(new Point(5000, 5000));
            detailEndPlate.SetPrimaryObject(beam1);
            detailEndPlate.LoadAttributesFromFile("standard");
            detailEndPlate.DetailType = Tekla.Structures.DetailTypeEnum.END;
            bool detailInsert = detailEndPlate.Insert();

            var moe = detailEndPlate.GetChildren();

            while (moe.MoveNext())
            {
                detailChildBeam = moe.Current as Beam;

                if (detailChildBeam != null) break;
            }

            new Model().CommitChanges();
        }
    }
}
