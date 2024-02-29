using System;
using System.Collections.Generic;

using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Plugins;
using TSM = Tekla.Structures.Model;

namespace BeamPlugin
{
    public class StructuresData
    {
        [StructuresField("LengthFactor")]
        public double LengthFactor;
        [StructuresField("Profile")]
        public string Profile;
    }

    /// <summary>
    /// This is the same example found in the Open API Reference PluginBase section, 
    /// but implemented using Windows Forms. The plugin asks the user to pick two points.
    /// The plug-in then calculates new insertion points using a double parameter from the 
    /// dialog and creates a beam.
    /// </summary>
    [Plugin("BeamPlugin")] // Mandatory field which defines that the class is a plug-in-and stores the name of the plug-in to the system.
    [PluginUserInterface("BeamPlugin.BeamPluginForm")] // Mandatory field which defines the user interface the plug-in uses. A windows form class of a .inp file.
    public class BeamPlugin : PluginBase
    {
        private StructuresData Data { get; set; }

        private double _LengthFactor;
        private string _Profile;

        // The constructor argument defines the database class StructuresData and set the data to be used in the plug-in.
        public BeamPlugin(StructuresData data)
        {
            TSM.Model M = new TSM.Model();
            Data = data;
        }

        //Defines the inputs to be passed to the plug-in.
        public override List<InputDefinition> DefineInput()
        {
            Picker BeamPicker = new Picker();
            List<InputDefinition> PointList = new List<InputDefinition>();

            Point Point1 = BeamPicker.PickPoint();
            Point Point2 = BeamPicker.PickPoint();

            InputDefinition Input1 = new InputDefinition(Point1);
            InputDefinition Input2 = new InputDefinition(Point2);

            //Add inputs to InputDefinition list.
            PointList.Add(Input1);
            PointList.Add(Input2);

            return PointList;
        }

        private void CreateBeam(Point Point1, Point Point2)
        {
            TSM.Beam MyBeam = new TSM.Beam(Point1, Point2);

            MyBeam.Profile.ProfileString = _Profile;
            MyBeam.Finish = "PAINT";

            // With this we help internal code to assign same ID to beam when plugin is modified.
            // To avoid some problems related to links with UDA values or booleans (cuts, fittings) for example.
            MyBeam.SetLabel("MyBeam01");

            MyBeam.Insert();
        }

        // Gets the values from the dialog and sets the default values if needed
        private void GetValuesFromDialog()
        {
            _LengthFactor = Data.LengthFactor;
            _Profile = Data.Profile;
            if (IsDefaultValue(_LengthFactor))
            {
                _LengthFactor = 2.0;
            }
            if (IsDefaultValue(_Profile))
            {
                _Profile = "HEA300";
            }
        }

        //Main method of the plug-in.
        public override bool Run(List<InputDefinition> Input)
        {
            try
            {
                GetValuesFromDialog();

                Point Point1 = (Point)(Input[0]).GetInput();
                Point Point2 = (Point)(Input[1]).GetInput();
                Point LengthVector = new Point(Point2.X - Point1.X, Point2.Y - Point1.Y, Point2.Z - Point1.Z);

                if (_LengthFactor > 0)
                {
                    Point2.X = _LengthFactor * LengthVector.X + Point1.X;
                    Point2.Y = _LengthFactor * LengthVector.Y + Point1.Y;
                    Point2.Z = _LengthFactor * LengthVector.Z + Point1.Z;
                }

                CreateBeam(Point1, Point2);
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Exception: " + Ex.ToString());
            }

            return true;
        }
    }
}
