using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tekla.Structures;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Plugins;

namespace TeklaWPFConnection
{
    public class PluginData
    {
        #region Fields
        //
        // Define the fields specified on the Form.
        //
        #region Part Fields
        [StructuresField("partButton1")]
        public string partButton1;

        [StructuresField("partButton2")]
        public string partButton2;
        #endregion

        #region Weld Fields

        [StructuresField("weldButton1")]
        public string weldButton1;

        [StructuresField("weldButton2")]
        public string weldButton2;
        #endregion

        #region Fields from Base Component
        //
        // Define the fields specified on the Form.
        //
        #region General Tab Properties
        [StructuresField("zsuunta")] // It is mandatory to use type integer for this attribute
        public int UpDirection;
        [StructuresField("zang1")]  // It is mandatory to use type double for this attribute
        public double RotationAngleY;
        [StructuresField("zang2")]  // It is mandatory to use type double for this attribute
        public double RotationAngleX;
        [StructuresField("OBJECT_LOCKED")] // It is mandatory to use type integer for this attribute
        public int Locked;
        [StructuresField("group_no")]     //  It is mandatory to use type integer for this attribute
        public int Class;
        [StructuresField("joint_code")]  // It is mandatory to use type string for this attribute
        public string ConnectionCode;
        [StructuresField("ad_root")] // It is mandatory to use type string for this attribute
        public string AutoDefaults;
        [StructuresField("ac_root")] // It is mandatory to use type string for this attribute
        public string AutoConnection;

        #endregion

        [StructuresField("name")]
        public string partName;

        [StructuresField("profile")]
        public string profile;

        [StructuresField("offset")]
        public double offset;

        [StructuresField("material")]
        public string material;

        [StructuresField("componentname")]
        public string componentname;

        [StructuresField("componentnumber")]
        public int componentnumber;

        [StructuresField("lengthfactor")]
        public int lengthfactor;

        #endregion

        #endregion
    }

    [Plugin("TeklaWPFConnection")]
    [PluginUserInterface("TeklaWPFConnection.MainWindow")]
    [SecondaryType(ConnectionBase.SecondaryType.SECONDARYTYPE_ONE)]
    [AutoDirectionType(AutoDirectionTypeEnum.AUTODIR_BASIC)]
    [PositionType(PositionTypeEnum.MIDDLE_PLANE)]

    public class TeklaWPFConnection : ConnectionBase
    {
        #region Fields

        #region Fields from Base Component
        private Model _Model;
        private PluginData _Data;
        //
        // Define variables for the field values.
        //
        private string _PartName = string.Empty;
        private string _Profile = string.Empty;
        private string _Material = string.Empty;
        private double _Offset = 0.0;
        private int _LengthFactor = 0;

        #region General Tab Properties
        private int _UpDirection = 0;
        private double _RotationAngleY = 0.00;
        private double _RotationAngleX = 0.00;
        private int _Locked = 0;
        private int _Class = 0;
        private string _ConnectionCode = string.Empty;
        private string _AutoDefaults = string.Empty;
        private string _AutoConnection = string.Empty;
        #endregion
        #endregion

        #endregion

        #region Properties
        private Model Model
        {
            get { return this._Model; }
            set { this._Model = value; }
        }

        private PluginData Data
        {
            get { return this._Data; }
            set { this._Data = value; }
        }
        #endregion

        #region Constructor
        public TeklaWPFConnection(PluginData data)
        {
            Model = new Model();
            Data = data;
        }
        #endregion

        #region Overrides

        public override bool Run()
        {
            try
            {
                {
                    List<ModelObject> SelectedList = new List<ModelObject>
                    {
                        new Model().SelectModelObject(Primary),
                        new Model().SelectModelObject(Secondaries[0])
                    };

                    GetValuesFromDialog();

                    Beam myBeam = new Beam(new Point(0, 0, 0), new Point(1000 * _LengthFactor, 0, 0));
                    myBeam.Profile.ProfileString = _Profile;
                    myBeam.Material.MaterialString = _Material;
                    myBeam.Insert();

                    //Write connection methods here

                }
            }
            catch (Exception Exc)
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
            #region variables from base component
            #region General Tab Properties
            _UpDirection = Data.UpDirection;
            _RotationAngleY = Data.RotationAngleY;
            _RotationAngleX = Data.RotationAngleX;
            _Locked = Data.Locked;
            _Class = Data.Class;
            _ConnectionCode = Data.ConnectionCode;
            _AutoDefaults = Data.AutoDefaults;
            _AutoConnection = Data.AutoConnection;
            #endregion
            _PartName = Data.partName;
            _Profile = Data.profile;
            _Material = Data.material;
            _Offset = Data.offset;
            _LengthFactor = Data.lengthfactor + 1;

            if (IsDefaultValue(_PartName))
                _PartName = "TEST";
            if (IsDefaultValue(_Profile))
                _Profile = "HEA200";
            if (IsDefaultValue(_Material))
                _Material = "STEEL_UNDEFINED";
            if (IsDefaultValue(_Offset))
                _Offset = 0;
            if (IsDefaultValue(_LengthFactor) || _LengthFactor == 0)
                _Offset = 1;
            #endregion

        }
        // Write your private methods here.

        #endregion

    }
}
