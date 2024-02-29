using System;
using System.Windows.Forms;
using Tekla.Structures;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Plugins;
using Tekla.Structures.Model;

namespace SpliceConn
{
    public class StructuresData
    {
        [StructuresField("PlateLength")]
        public double PlateLength;
        [StructuresField("BoltStandard")]
        public string BoltStandard;
        [StructuresField("zsuunta")] // It is mandatory to use type integer for this attribute
        public int UpDirection;
        [StructuresField("zang1")] // It is mandatory to use type double for this attribute
        public double RotationAngleY;
        [StructuresField("zang2")] // It is mandatory to use type double for this attribute
        public double RotationAngleX;
        [StructuresField("OBJECT_LOCKED")] // It is mandatory to use type integer for this attribute
        public int Locked;
        [StructuresField("group_no")] // It is mandatory to use type integer for this attribute
        public int Class;
        [StructuresField("joint_code")] // It is mandatory to use type string for this attribute
        public string ConnectionCode;
        [StructuresField("ad_root")] // It is mandatory to use type string for this attribute
        public string AutoDefaults;
        [StructuresField("ac_root")] // It is mandatory to use type string for this attribute
        public string AutoConnection;
    }

    // If the plug-in is inherited from ConnectionPluginBase, the dialog class name must be the same as plug-in name
    [Plugin("SpliceConnection")] //Name of the connetion in the catalog
    [PluginUserInterface("SpliceConnection")]
    [SecondaryType(ConnectionBase.SecondaryType.SECONDARYTYPE_ONE)]
    [AutoDirectionType(AutoDirectionTypeEnum.AUTODIR_BASIC)]
    [PositionType(PositionTypeEnum.COLLISION_PLANE)]
    public class SpliceConnection : ConnectionBase
    {
        #region Fields
        private readonly Model _model;
        private readonly StructuresData _data;
        private const double GAP = 10.0;
        private const double EPSILON = 0.001;
        private double _PlateLength;
        private string _BoltStandard = string.Empty;
        private int _UpDirection = new int();
        private double _RotationAngleY;
        private double _RotationAngleX;
        private int _Locked = new int();
        private int _Class = new int();
        private string _ConnectionCode = string.Empty;
        private string _AutoDefaults = string.Empty;
        private string _AutoConnection = string.Empty;
        #endregion

        #region Constructor
        public SpliceConnection(StructuresData data)
        {
            _model = new Model();
            _data = data;
        }
        #endregion

        #region Overriden methods
        public override bool Run()
        {
            bool Result = false;
            try
            {
                GetValuesFromDialog();

                //Get primary and secondary
                Beam PrimaryBeam = _model.SelectModelObject(Primary) as Beam;
                Beam SecondaryBeam = _model.SelectModelObject(Secondaries[0]) as Beam;
                if(PrimaryBeam != null && SecondaryBeam != null)
                {
                    string PrimaryProfileType = "";
                    string SecondaryProfileType = "";

                    PrimaryBeam.GetReportProperty("PROFILE_TYPE", ref PrimaryProfileType);
                    SecondaryBeam.GetReportProperty("PROFILE_TYPE", ref SecondaryProfileType);

                    if(PrimaryBeam.Profile.ProfileString == SecondaryBeam.Profile.ProfileString &&
                       PrimaryProfileType == SecondaryProfileType)
                    {
                        if(CheckIfBeamsAreAligned(PrimaryBeam, SecondaryBeam))
                        {
                            if(CreateSpliceConnection(PrimaryBeam, SecondaryBeam))
                                Result = true;
                        }
                    }
                }
            }

            catch(Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }

            return Result;
        }
        #endregion

        #region Private methods
        private static bool CheckIfBeamsAreAligned(Beam PrimaryBeam, Beam SecondaryBeam)
        {
            bool result = false;

            if(PrimaryBeam != null && SecondaryBeam != null)
            {
                Line primaryLine = new Line(PrimaryBeam.StartPoint, PrimaryBeam.EndPoint);
                Line secondaryLine = new Line(SecondaryBeam.StartPoint, SecondaryBeam.EndPoint);
                if(Parallel.LineToLine(primaryLine, secondaryLine))
                    result = true;
            }

            return result;
        }

        private bool CreateSpliceConnection(Beam PrimaryBeam, Beam SecondaryBeam)
        {
            bool Result = false;
            TransformationPlane originalTransformationPlane = _model.GetWorkPlaneHandler().GetCurrentTransformationPlane();
            double webThickness = 0.0;
            double beamHeight = 0.0;
            double flangeHeight = 0.0;
            double innerRoundingRadius = 0.0;
            const double innerMargin = 5.0;

            CoordinateSystem coordSys = PrimaryBeam.GetCoordinateSystem();

            if(Distance.PointToPoint(PrimaryBeam.EndPoint, SecondaryBeam.StartPoint) < EPSILON ||
               Distance.PointToPoint(PrimaryBeam.EndPoint, SecondaryBeam.EndPoint) < EPSILON)
            {
                coordSys.Origin.Translate(coordSys.AxisX.X, coordSys.AxisX.Y, coordSys.AxisX.Z);
                coordSys.AxisX = -1 * coordSys.AxisX;
            }

            // First get the essential dimensions from the beam
            if(CreateGapBetweenBeams(PrimaryBeam, SecondaryBeam) &&
                SecondaryBeam.GetReportProperty("PROFILE.WEB_THICKNESS", ref webThickness) &&
                SecondaryBeam.GetReportProperty("PROFILE.HEIGHT", ref beamHeight) &&
                SecondaryBeam.GetReportProperty("PROFILE.FLANGE_THICKNESS", ref flangeHeight))
            {
                //Creates plates on both sides of the beam.

                #region Create the Plates

                Beam plate1 = new Beam();
                Beam plate2 = new Beam();

                // And then the optionals if they exist
                SecondaryBeam.GetReportProperty("PROFILE.ROUNDING_RADIUS_1", ref innerRoundingRadius);
                double edgeDistance = (flangeHeight + innerRoundingRadius + innerMargin);
                double plateHeight = beamHeight - 2 * edgeDistance;

                _model.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane(coordSys));

                plate1.Position.Depth = plate2.Position.Depth = Position.DepthEnum.MIDDLE;
                plate1.Position.Rotation = plate2.Position.Rotation = Position.RotationEnum.FRONT;


                plate1.StartPoint = new Point(-GAP, (-beamHeight / 2.0) + edgeDistance, webThickness);
                plate1.EndPoint = new Point(plate1.StartPoint.X, (-beamHeight / 2.0) + beamHeight - edgeDistance,
                                            webThickness);
                plate2.StartPoint = new Point(plate1.StartPoint.X, plate1.StartPoint.Y, -webThickness);
                plate2.EndPoint = new Point(plate1.EndPoint.X, plate1.EndPoint.Y, -webThickness);

                plate1.Profile.ProfileString = plate2.Profile.ProfileString = "PL" + (int)webThickness + "*" + (int)_PlateLength;
                plate1.Finish = plate2.Finish = "PAINT";

                // With this we help internal code to assign same ID to plates when plugin is modified.
                // To avoid some problems related to links with UDA values or booleans (cuts, fittings) for example.
                plate1.SetLabel("MyPlate01");
                plate2.SetLabel("MyPlate02");

                plate1.Insert();
                plate2.Insert();

                #endregion

                _model.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane(plate1.GetCoordinateSystem()));

                //Creates two boltArrays to connect the plates
                if(CreateBoltArray(PrimaryBeam, plate1, plate2, plateHeight, true) &&
                   CreateBoltArray(SecondaryBeam, plate1, plate2, plateHeight, false))
                    Result = true;

                _model.GetWorkPlaneHandler().SetCurrentTransformationPlane(originalTransformationPlane);
            }
            return Result;
        }

        private bool CreateBoltArray(Beam beam, Beam plate1, Beam plate2, double plateHeight, bool Primary)
        {
            bool result = false;
            
            BoltArray B = new BoltArray();

            B.PartToBoltTo = plate1;
            B.PartToBeBolted = beam;
            B.AddOtherPartToBolt(plate2);

            if(Primary)
            {
                B.FirstPosition = new Point(plateHeight / 2.0, _PlateLength / 2.0, 0.0);
                B.SecondPosition = new Point(plateHeight / 2.0, -_PlateLength / 2.0, 0.0);
            }
            else
            {
                B.FirstPosition = new Point(plateHeight / 2.0, -_PlateLength / 2.0, 0.0);
                B.SecondPosition = new Point(plateHeight / 2.0, _PlateLength / 2.0, 0.0);
            }

            B.StartPointOffset.Dx = B.EndPointOffset.Dx = _PlateLength - 75;
            B.StartPointOffset.Dy = B.EndPointOffset.Dy = 0;
            B.StartPointOffset.Dz = B.EndPointOffset.Dz = 0;

            B.BoltSize = 20;
            B.Tolerance = 2.00;
            B.BoltStandard = _BoltStandard;
            B.BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE;
            B.CutLength = 105;

            B.Length = 60;
            B.ExtraLength = 0;
            B.ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES;

            B.Position.Depth = Position.DepthEnum.MIDDLE;
            B.Position.Plane = Position.PlaneEnum.MIDDLE;
            B.Position.Rotation = Position.RotationEnum.FRONT;

            B.Bolt = true;
            B.Washer1 = false;
            B.Washer2 = B.Washer3 = true;
            B.Nut1 = true;
            B.Nut2 = false;
            B.Hole1 = B.Hole2 = B.Hole3 = B.Hole4 = B.Hole5 = false;

            B.AddBoltDistX(0.0);
            B.AddBoltDistY(plateHeight - 150.0);

            if(B.Insert())
                result = true;

            return result;
        }

        //Creates a gap between the beams
        private static bool CreateGapBetweenBeams(Beam PrimaryBeam, Beam SecondaryBeam)
        {
            bool result = false;

            if(PrimaryBeam != null && SecondaryBeam != null)
            {
                //Get vectors defined by the beams, to move their extremes along them when creating the gaps
                Vector primaryBeamVector = new Vector(PrimaryBeam.EndPoint.X - PrimaryBeam.StartPoint.X,
                                                      PrimaryBeam.EndPoint.Y - PrimaryBeam.StartPoint.Y,
                                                      PrimaryBeam.EndPoint.Z - PrimaryBeam.StartPoint.Z);
                primaryBeamVector.Normalize(GAP);
                Vector secondaryBeamVector = new Vector(SecondaryBeam.EndPoint.X - SecondaryBeam.StartPoint.X,
                                                        SecondaryBeam.EndPoint.Y - SecondaryBeam.StartPoint.Y,
                                                        SecondaryBeam.EndPoint.Z - SecondaryBeam.StartPoint.Z);
                secondaryBeamVector.Normalize(GAP);

                Point PrimaryBeamEdge;
                Point SecondaryBeamEdge;
            
                if(PrimaryBeam.StartPoint == SecondaryBeam.StartPoint)
                {
                    PrimaryBeamEdge = PrimaryBeam.StartPoint;
                    SecondaryBeamEdge = SecondaryBeam.StartPoint;

                    if(CreateFittings(PrimaryBeam, SecondaryBeam, PrimaryBeamEdge, SecondaryBeamEdge,
                                      primaryBeamVector, secondaryBeamVector))
                        result = true;
                }
                else if(PrimaryBeam.EndPoint == SecondaryBeam.StartPoint)
                {
                    ChangeVectorDirection(primaryBeamVector);

                    PrimaryBeamEdge = PrimaryBeam.EndPoint;
                    SecondaryBeamEdge = SecondaryBeam.StartPoint;

                    if(CreateFittings(PrimaryBeam, SecondaryBeam, PrimaryBeamEdge, SecondaryBeamEdge,
                                      primaryBeamVector, secondaryBeamVector))
                        result = true;
                }
                else if(PrimaryBeam.StartPoint == SecondaryBeam.EndPoint)
                {
                    ChangeVectorDirection(secondaryBeamVector);

                    PrimaryBeamEdge = PrimaryBeam.StartPoint;
                    SecondaryBeamEdge = SecondaryBeam.EndPoint;

                    if(CreateFittings(PrimaryBeam, SecondaryBeam, PrimaryBeamEdge, SecondaryBeamEdge,
                                      primaryBeamVector, secondaryBeamVector))
                        result = true;
                }
                else if(PrimaryBeam.EndPoint == SecondaryBeam.EndPoint)
                {
                    ChangeVectorDirection(primaryBeamVector);
                    ChangeVectorDirection(secondaryBeamVector);

                    PrimaryBeamEdge = PrimaryBeam.EndPoint;
                    SecondaryBeamEdge = SecondaryBeam.EndPoint;

                    if(CreateFittings(PrimaryBeam, SecondaryBeam, PrimaryBeamEdge, SecondaryBeamEdge,
                                      primaryBeamVector, secondaryBeamVector))
                        result = true;
                }
            }

            return result;
        }

        //Creates the fittings used to create the gap between the beams
        private static bool CreateFittings(Beam PrimaryBeam, Beam SecondaryBeam, Point PrimaryBeamEdge, Point SecondaryBeamEdge,
                                           Vector primaryBeamVector, Vector secondaryBeamVector)
        {
            bool Result = false;
            Fitting fitPrimary = new Fitting();
            Fitting fitSecondary = new Fitting();
            CoordinateSystem PrimaryCoordinateSystem = PrimaryBeam.GetCoordinateSystem();
            CoordinateSystem SecondaryCoordinateSystem = PrimaryBeam.GetCoordinateSystem();

            PrimaryBeamEdge.Translate(primaryBeamVector.X, primaryBeamVector.Y, primaryBeamVector.Z);
            SecondaryBeamEdge.Translate(secondaryBeamVector.X, secondaryBeamVector.Y, secondaryBeamVector.Z);

            fitPrimary.Plane = new Plane();
            fitPrimary.Plane.Origin = new Point(PrimaryBeamEdge.X, PrimaryBeamEdge.Y, PrimaryBeamEdge.Z);
            fitPrimary.Plane.AxisX = new Vector(Vector.Cross(PrimaryCoordinateSystem.AxisX,
                                                Vector.Cross(PrimaryCoordinateSystem.AxisX, PrimaryCoordinateSystem.AxisY)));
            fitPrimary.Plane.AxisX.Normalize(500);
            fitPrimary.Plane.AxisY = new Vector(Vector.Cross(PrimaryCoordinateSystem.AxisX, PrimaryCoordinateSystem.AxisY));
            fitPrimary.Plane.AxisY.Normalize(500);
            fitPrimary.Father = PrimaryBeam;

            fitSecondary.Plane = new Plane();
            fitSecondary.Plane.Origin = new Point(SecondaryBeamEdge.X, SecondaryBeamEdge.Y, SecondaryBeamEdge.Z);
            fitSecondary.Plane.AxisX = new Vector(Vector.Cross(SecondaryCoordinateSystem.AxisX,
                                                Vector.Cross(SecondaryCoordinateSystem.AxisX, SecondaryCoordinateSystem.AxisY)));
            fitSecondary.Plane.AxisX.Normalize(500);
            fitSecondary.Plane.AxisY = new Vector(Vector.Cross(SecondaryCoordinateSystem.AxisX, SecondaryCoordinateSystem.AxisY));
            fitSecondary.Plane.AxisY.Normalize(500);
            fitSecondary.Father = SecondaryBeam;

            if(fitPrimary.Insert() && fitSecondary.Insert())
                Result = true;

            return Result;
        }
        private static void ChangeVectorDirection(Point vector)
        {
            vector.X = -1 * vector.X;
            vector.Y = -1 * vector.Y;
            vector.Z = -1 * vector.Z;
        }

        /// <summary>
        /// Gets the values from the dialog and sets the default values if needed
        /// </summary>
        private void GetValuesFromDialog()
        {
            _PlateLength = _data.PlateLength;
            _BoltStandard = _data.BoltStandard;
            _UpDirection = _data.UpDirection;
            _RotationAngleY = _data.RotationAngleY;
            _RotationAngleX = _data.RotationAngleX;
            _Locked = _data.Locked;
            _Class = _data.Class;
            _ConnectionCode = _data.ConnectionCode;
            _AutoDefaults = _data.AutoDefaults;
            _AutoConnection = _data.AutoConnection;

            if (IsDefaultValue(_PlateLength) || _PlateLength == 0)
                _PlateLength = 300.0;
            if (IsDefaultValue(_BoltStandard) || _BoltStandard == "")
                _BoltStandard = "7990";
            if (IsDefaultValue(_UpDirection) || _UpDirection == 0)
                _UpDirection = 0;
            if (IsDefaultValue(_RotationAngleY))
                _RotationAngleY = 0;
            if (IsDefaultValue(_RotationAngleX))
                _RotationAngleX = 0;
            if (IsDefaultValue(_Locked))
                _Locked = 0;
            if (IsDefaultValue(_Class))
                _Class = 99;
            if (IsDefaultValue(_ConnectionCode))
                _ConnectionCode = "";
            if (IsDefaultValue(_AutoDefaults) || _AutoDefaults == "")
                _AutoDefaults = "albl_no_root";
            if (IsDefaultValue(_AutoConnection) || _AutoConnection == "")
                _AutoConnection = "albl_no_root";
        }
        #endregion
    }
}
