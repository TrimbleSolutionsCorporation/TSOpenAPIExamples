using System;
using System.Collections.Generic;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Plugins;
using TSM = Tekla.Structures.Model;

namespace ImageListComboBoxExample
{
    public class StructuresData
    {
        [StructuresField("Color")]
        public int Color;
        [StructuresField("Profile")]
        public string Profile;
    }

    /// <summary>
    /// This example shows how to use ImageListComboBox control in plugins. 
    /// The plugin asks the user to pick two points and a beam is created between them.
    /// </summary>
    [Plugin("ImageListComboBoxPlugin")] // Mandatory field which defines that the class is a plug-in-and stores the name of the plug-in to the system.
    [PluginUserInterface("ImageListComboBoxExample.PluginForm")] // Mandatory field which defines the user interface the plug-in uses. A windows form class or a .inp file.
    public class ImageListComboBoxPlugin : PluginBase
    {
        private StructuresData Data { get; set; }

        private int _Color;
        private string _Profile;

        // The constructor argument defines the database class StructuresData and set the data to be used in the plug-in.
        public ImageListComboBoxPlugin(StructuresData data)
        {
            TSM.Model myModel = new TSM.Model();
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
            MyBeam.Class = _Color.ToString();
            MyBeam.Insert();
        }

        // Gets the values from the dialog and sets the default values if needed
        private void GetValuesFromDialog()
        {
            _Color = Data.Color;
            _Profile = Data.Profile;
            if (IsDefaultValue(_Color))
            {
                _Color = 2;
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

                CreateBeam(Point1, Point2);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }

            return true;
        }
    }
}
