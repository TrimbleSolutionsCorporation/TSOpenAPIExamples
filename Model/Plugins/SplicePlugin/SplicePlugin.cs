using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Plugins;
using TSM = Tekla.Structures.Model;
using Point = Tekla.Structures.Geometry3d.Point;
using Tekla.Structures.Geometry3d;

namespace Tekla.Samples.SplicePlugin
{
    public class StructuresData
    {
        [Tekla.Structures.Plugins.StructuresField("BeamLength")]
        public double BeamLength;
    }

    [Plugin("SplicePlugin")] // obligatory
    [PluginUserInterface(SplicePlugin.UserInterfaceDefinitions.SplicePluginForm)]
    public class SplicePlugin : PluginBase
    {
        private StructuresData _data;

        private TSM.Model _model;
        private static readonly double EPSILON = 0.05;          //Tolerance
        private static readonly double GAP_LENGTH = 5.0;        //Gap between beams
        private static readonly double BEAM_LENGTH = 3000.0;    //Beam length

        //Constructor
        public SplicePlugin(StructuresData data)
        {
            this._data = data;
            _model = new TSM.Model();
        }

        //Picks the points from the UI
        public override List<InputDefinition> DefineInput()
        {
            Picker BeamPicker = new Picker();
            List<InputDefinition> PointList = new List<InputDefinition>();

            Point Point1 = BeamPicker.PickPoint();
            Point Point2 = BeamPicker.PickPoint();

            InputDefinition Input1 = new InputDefinition(Point1);
            InputDefinition Input2 = new InputDefinition(Point2);
            PointList.Add(Input1);
            PointList.Add(Input2);

            return PointList;
        }

        //Creates connection between two beams. The connection consists of two plates and two bolt arrays.
        private void CreateSpliceConnection(ref ArrayList Parts)
        {
            TransformationPlane originalTransformationPlane = _model.GetWorkPlaneHandler().GetCurrentTransformationPlane();
            double webThickness = 0.0;
            double edgeDistance = 0.0;
            double plateHeight = 0.0;
            double beamHeight = 0.0;
            double flangeHeight = 0.0;
            double innerRoundingRadius = 0.0;
            double innerMargin = 5.0;
            Beam previousBeam = new Beam();
            bool first = true;
            double beamLength = _data.BeamLength;

            // Loops through all the beams that have to be created between the two points
            foreach(Beam beam in Parts)
            {
                // In the first beam no connection is created, connections are always created after the first beam 
                if(first)
                {
                    first = false;
                }
                else
                {
                    // Don't create connection after last part (beam)
                    if(Parts.IndexOf(beam) < (Parts.Count))
                    {
                        // First get the essential dimensions from the beam
                        if(beam.GetReportProperty("PROFILE.WEB_THICKNESS", ref webThickness) &&
                            beam.GetReportProperty("PROFILE.HEIGHT", ref beamHeight) &&
                            beam.GetReportProperty("PROFILE.FLANGE_THICKNESS", ref flangeHeight))
                        {
                            //Creates plates on both sides of the beam.
                            #region Create the Plates

                            Beam plate1 = new Beam();
                            Beam plate2 = new Beam();

                            // And then the optionals if they exist
                            beam.GetReportProperty("PROFILE.ROUNDING_RADIUS_1", ref innerRoundingRadius);
                            edgeDistance = (flangeHeight + innerRoundingRadius + innerMargin);
                            plateHeight = beamHeight - 2 * edgeDistance;

                            CoordinateSystem coordSys = previousBeam.GetCoordinateSystem();
                            _model.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane(coordSys));

                            plate1.Position.Depth = plate2.Position.Depth = Position.DepthEnum.MIDDLE;
                            plate1.Position.Rotation = plate2.Position.Rotation = Position.RotationEnum.FRONT;
                            plate1.StartPoint = new Point(beamLength + GAP_LENGTH / 2.0, (-beamHeight / 2.0) + edgeDistance, webThickness);
                            plate1.EndPoint = new Point(beamLength + GAP_LENGTH / 2.0, (-beamHeight / 2.0) + beamHeight - edgeDistance, webThickness);
                            plate2.StartPoint = new Point(beamLength + GAP_LENGTH / 2.0, (-beamHeight / 2.0) + edgeDistance, -webThickness);
                            plate2.EndPoint = new Point(beamLength + GAP_LENGTH / 2.0, (-beamHeight / 2.0) + beamHeight - edgeDistance, -webThickness);

                            plate1.Profile.ProfileString = plate2.Profile.ProfileString = "PL" + (int)webThickness + "*300";
                            plate1.Finish = plate2.Finish = "PAINT";

                            plate1.Insert();
                            plate2.Insert();

                            #endregion

                            //Creates two boltArrays to connect the plates
                            #region Create the BoltArray

                            _model.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane(plate1.GetCoordinateSystem()));
                            BoltArray B = new BoltArray();

                            B.PartToBoltTo = previousBeam;
                            B.PartToBeBolted = plate1;
                            B.AddOtherPartToBolt(plate2);
                            B.AddOtherPartToBolt(beam);

                            B.FirstPosition = new Point(0.0, 0.0, 0.0);
                            B.SecondPosition = new Point(plateHeight, 0.0, 0.0);

                            B.BoltSize = 16;
                            B.Tolerance = 3.00;
                            B.BoltStandard = "7990";
                            B.BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_WORKSHOP;
                            B.CutLength = 105;

                            B.Length = 100;
                            B.ExtraLength = 15;
                            B.ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_NO;

                            B.Position.Depth = Position.DepthEnum.MIDDLE;
                            B.Position.Plane = Position.PlaneEnum.MIDDLE;
                            B.Position.Rotation = Position.RotationEnum.FRONT;

                            B.Bolt = true;
                            B.Washer1 = B.Washer2 = B.Washer3 = true;
                            B.Nut1 = B.Nut2 = true;
                            B.Hole1 = B.Hole2 = B.Hole3 = B.Hole4 = B.Hole5 = true;

                            B.AddBoltDistX(plateHeight - 100.0);

                            B.AddBoltDistY(200.0);

                            B.StartPointOffset.Dx = 50.0;

                            B.Insert();

                            #endregion

                            _model.GetWorkPlaneHandler().SetCurrentTransformationPlane(originalTransformationPlane);
                        }
                        else
                        {
                            MessageBox.Show("Essential values could not be fetched!");
                        }
                    }
                }

                previousBeam = beam;
            }
        }

        // Creates a beam between two points
        private Beam CreateBeam(Point Point1, Point Point2)
        {
            TSM.Beam MyBeam = new TSM.Beam(Point1, Point2);

            MyBeam.Profile.ProfileString = "HEA300";
            MyBeam.Finish = "PAINT";
            MyBeam.Insert();

            return MyBeam;
        }

        //Main method
        public override bool Run(List<InputDefinition> input)
        {
            try
            {
                ArrayList parts = new ArrayList();
                ArrayList gaps = new ArrayList();

                Vector Point1 = new Vector((Point)input[0].GetInput());
                Vector Point2 = new Vector((Point)input[1].GetInput());
                Vector LengthVector = new Vector(Point2 - Point1);

                if(_data.BeamLength < 10.0)
                    _data.BeamLength = BEAM_LENGTH;

                double beamLength = _data.BeamLength;

                //Calculate distance between picked points
                double distance = Distance.PointToPoint(Point1, Point2);

                int partCount = (int)Math.Ceiling(distance / (beamLength - EPSILON)); // parts - 1 == gaps

                //Calculate the number of beams (6000mm length) that fit between those two points)
                for(int i = 0; i < partCount; i++)
                {
                    Vector startLength = LengthVector.GetNormal() * ((beamLength + GAP_LENGTH) * i);
                    Vector endLength;

                    if(i == partCount - 1)
                        endLength = LengthVector.GetNormal() * (distance - (i * (beamLength + GAP_LENGTH)));
                    else
                        endLength = LengthVector.GetNormal() * beamLength;

                    Point start = Point1 + startLength;
                    Point end = start + endLength;

                    parts.Add(CreateBeam(start, end));

                    Vector gapDistance = LengthVector.GetNormal() * (GAP_LENGTH / 2.0);
                    Point gapPoint = end + gapDistance; // the middle point between the two beams

                    if(i < partCount - 1)
                        gaps.Add(gapPoint);
                }

                //Creates the rest of the beams and connections, first one has already been created
                if(parts.Count > 1)
                    CreateSpliceConnection(ref parts);

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return true;
        }
        public class UserInterfaceDefinitions
        {
            public const string SplicePluginForm = @"" +
                @"page(""TeklaStructures"","""")" + "\n" +
                "{\n" +
                "    plugin(1, SplicePlugin)\n" +
                "    {\n" +
                @"        tab_page(""Splice test"", ""Parameters"", 1)" + "\n" +
                "        {\n" +
                @"            parameter(""Beam length"", ""BeamLength"", distance, number, 1)" + "\n" +
                "        }\n" +
                "    }\n" +
                "}\n";

        }
    }
}
