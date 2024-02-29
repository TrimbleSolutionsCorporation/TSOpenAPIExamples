using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Plugins;
using Tekla.Structures.Datatype;
using Distance = Tekla.Structures.Datatype.Distance;

namespace ReinforcedBeam
{
    public class StructuresData
    {
        [StructuresField("BeamName")]
        public string BeamName;

        [StructuresField("BeamProfile")]
        public string BeamProfile;

        [StructuresField("BeamMaterial")]
        public string BeamMaterial;

        [StructuresField("BeamFinish")]
        public string BeamFinish;

        [StructuresField("BeamClass")]
        public string BeamClass;

        [StructuresField("RebarName")]
        public string RebarName;

        [StructuresField("RebarSize")]
        public string RebarSize;

        [StructuresField("RebarGrade")]
        public string RebarGrade;

        [StructuresField("RebarBendingRadius")]
        public double RebarBendingRadius;

        [StructuresField("RebarClass")]
        public int RebarClass;

        [StructuresField("RebarSpacing")]
        public string RebarSpacing;
    }

    [Plugin("ReinforcedBeam")]
    [PluginUserInterface("ReinforcedBeam.ReinforcedBeamForm")]
    public class ReinforcedBeam : PluginBase
    {
        #region Fields
        private Model _Model;
        private StructuresData _Data;
        private string _BeamName = string.Empty;
        private string _BeamProfile = string.Empty;
        private string _BeamMaterial = string.Empty;
        private string _BeamFinish = string.Empty;
        private string _BeamClass = string.Empty;
        private string _RebarName = string.Empty;
        private string _RebarSize = string.Empty;
        private string _RebarGrade = string.Empty;
        private double _RebarBendingRadius;
        private int _RebarClass = new int();
        private string _RebarSpacing;
        private DistanceList distanceList = new DistanceList();
        private ArrayList _RebarSpacingList = new ArrayList();
        #endregion

        #region Properties
        private Model Model
        {
            get { return this._Model; }
            set { this._Model = value; }
        }

        private StructuresData Data
        {
            get { return this._Data; }
            set { this._Data = value; }
        }

        #endregion

        #region Constructor
        public ReinforcedBeam(StructuresData StructuresData)
        {
            Model = new Model();
            Data = StructuresData;
        }
        #endregion

        #region Overriden methods
        public override List<InputDefinition> DefineInput()
        {
            List<InputDefinition> PointList = new List<InputDefinition>();
            Picker Picker = new Picker();
            ArrayList PickedPoints = Picker.PickPoints(Picker.PickPointEnum.PICK_TWO_POINTS);

            PointList.Add(new InputDefinition(PickedPoints));

            return PointList;
        }

        public override bool Run(List<InputDefinition> Input)
        {
            try
            {
                GetValuesFromDialog();
                
                ArrayList Points = (ArrayList) Input[0].GetInput();
                Point StartPoint = Points[0] as Point;
                Point EndPoint = Points[1] as Point;

                Beam Beam = CreateBeam(StartPoint, EndPoint);

                if(Beam != null)
                    AddReinforcement(Beam);
                

            }
            catch(Exception Exc)
            {
                MessageBox.Show(Exc.ToString());
            }

            return true;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Gets the values from the dialog and sets the default values if needed
        /// </summary>
        private void GetValuesFromDialog()
        {
            _BeamName = Data.BeamName;
            _BeamProfile = Data.BeamProfile;
            _BeamMaterial = Data.BeamMaterial;
            _BeamFinish = Data.BeamFinish;
            _BeamClass = Data.BeamClass;
            _RebarName = Data.RebarName;
            _RebarSize = Data.RebarSize;
            _RebarGrade = Data.RebarGrade;
            _RebarBendingRadius = Data.RebarBendingRadius;
            _RebarClass = Data.RebarClass;
            _RebarSpacing = Data.RebarSpacing;

            if(IsDefaultValue(_BeamName))
                _BeamName = "Beam";
            if(IsDefaultValue(_BeamProfile))
                _BeamProfile = "800*400";
            if(IsDefaultValue(_BeamMaterial))
                _BeamMaterial = "Concrete_Undefined";
            if(IsDefaultValue(_BeamClass))
                _BeamClass = "99";
            if(IsDefaultValue(_RebarName))
                _RebarName = "REBAR";
            if(IsDefaultValue(_RebarSize))
                _RebarSize = "12";
            if(IsDefaultValue(_RebarGrade))
                _RebarGrade = "Undefined";
            if (IsDefaultValue(_RebarBendingRadius) || _RebarBendingRadius <= 0)
                _RebarBendingRadius = 30.00;
            if(IsDefaultValue(_RebarClass) || _RebarClass <= 0)
                _RebarClass = 99;
            if (IsDefaultValue(_RebarSpacing))
                _RebarSpacing = "30*200.0";

            if (Distance.CurrentUnitType == Distance.UnitType.Millimeter)
            {
                distanceList = DistanceList.Parse(_RebarSpacing,CultureInfo.InvariantCulture, Distance.UnitType.Millimeter);
                foreach (Distance distance in distanceList)
                    _RebarSpacingList.Add(distance.ConvertTo(Distance.UnitType.Millimeter));
            }
            else if (Distance.CurrentUnitType == Distance.UnitType.Inch)
            {
                distanceList = DistanceList.Parse(_RebarSpacing, CultureInfo.InvariantCulture, Distance.UnitType.Inch);
                foreach (Distance distance in distanceList)
                    _RebarSpacingList.Add(distance.ConvertTo(Distance.UnitType.Inch));
            }
        }

        /// <summary>
        /// Creates a beam between the picked points
        /// </summary>
        /// <param name="StartPoint">Start point of the beam</param>
        /// <param name="EndPoint">End point of the beam</param>
        /// <returns></returns>
        private Beam CreateBeam(Point StartPoint, Point EndPoint)
        {
            Beam Beam = new Beam(StartPoint, EndPoint);
            Beam.Name = _BeamName;
            Beam.Profile.ProfileString = _BeamProfile;
            Beam.Material.MaterialString = _BeamMaterial;
            Beam.Finish = _BeamFinish;
            Beam.Class = _BeamClass;

            if(Beam.Insert())
                return Beam;
            else
            {
                MessageBox.Show("Failed to insert beam");
                return null;
            }
        }

        /// <summary>
        /// Adds a reinforcement to the beam
        /// </summary>
        /// <param name="Beam">Beam to reinforce</param>
        private void AddReinforcement(Beam Beam)
        {
            TransformationPlane CurrentTP = Model.GetWorkPlaneHandler().GetCurrentTransformationPlane();

            Model.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane(Beam.GetCoordinateSystem()));

            double MinimumX = Beam.GetSolid().MinimumPoint.X;
            double MinimumY = Beam.GetSolid().MinimumPoint.Y;
            double MinimumZ = Beam.GetSolid().MinimumPoint.Z;
            double MaximumX = Beam.GetSolid().MaximumPoint.X;
            double MaximumY = Beam.GetSolid().MaximumPoint.Y;
            double MaximumZ = Beam.GetSolid().MaximumPoint.Z;
            double MidX = (MinimumX + MaximumX) / 2.0;

            Polygon Polygon = new Polygon();
            Polygon.Points.Add(new Point(MinimumX, MaximumY, MinimumZ));
            Polygon.Points.Add(new Point(MinimumX, MinimumY, MinimumZ));
            Polygon.Points.Add(new Point(MinimumX, MinimumY, MaximumZ));
            Polygon.Points.Add(new Point(MinimumX, MaximumY, MaximumZ));
            
            RebarGroup RebarGroup1 = new RebarGroup();
            RebarGroup1.Name = _RebarName;
            RebarGroup1.Size = _RebarSize;
            RebarGroup1.Grade = _RebarGrade;
            RebarGroup1.RadiusValues.Add(_RebarBendingRadius);
            RebarGroup1.Class = _RebarClass;
            RebarGroup1.Father = Beam;
            RebarGroup1.StartPoint = new Point(MinimumX, 0, 0);
            RebarGroup1.EndPoint = new Point(MaximumX, 0, 0);

            RebarGroup1.Polygons.Add(Polygon);
            RebarGroup1.SpacingType = RebarGroup.RebarGroupSpacingTypeEnum.SPACING_TYPE_EXACT_SPACINGS;
            RebarGroup1.Spacings = _RebarSpacingList;
            RebarGroup1.ExcludeType = RebarGroup.ExcludeTypeEnum.EXCLUDE_TYPE_BOTH;
            RebarGroup1.OnPlaneOffsets.Add(25.0);
            RebarGroup1.OnPlaneOffsets.Add(25.0);
            RebarGroup1.OnPlaneOffsets.Add(25.0);
            
            if(!RebarGroup1.Insert())
                MessageBox.Show("Failed to insert rebar group");

            Model.GetWorkPlaneHandler().SetCurrentTransformationPlane(CurrentTP);
        }
        #endregion
    }
}
