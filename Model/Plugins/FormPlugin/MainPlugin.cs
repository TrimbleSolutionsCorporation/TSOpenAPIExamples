using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

using TSDatatype = Tekla.Structures.Datatype;
using TSModel = Tekla.Structures.Model;
using TSPlugins = Tekla.Structures.Plugins;

namespace FormPlugin
{
    /// <summary>
    /// Encapsulates attributes passed from the dialog to the plugin.
    /// </summary>
    public class StructuresData
    {
        [TSPlugins.StructuresField("height")]
        public double height;
    }

    /// <summary>
    /// Description of this plugin.
    /// </summary>
    [TSPlugins.Plugin("FormPlugin")]
    [TSPlugins.PluginUserInterface("FormPlugin.MainForm")]

    public class MainPlugin : TSPlugins.PluginBase
    {
        /// <summary>
        /// Enables inserting of objects in a model.
        /// </summary>
        private readonly TSModel.Model _model;

        public TSModel.Model Model
        {
            get { return _model; }
        }

        /// <summary>
        /// Enables retrieving of input values.
        /// </summary>
        private readonly StructuresData _data;

        public MainPlugin(StructuresData data)
        {
            // Link to model.
            _model = new TSModel.Model();

            // Link to input values.
            _data = data;
        }

        /// <summary>
        /// Specifies the user input needed for the plugin.
        /// </summary>
        /// <returns>List of input definitions</returns>
        public override List<InputDefinition> DefineInput()
        {
            // Define input objects.

            TSModel.UI.Picker PointPicker = new TSModel.UI.Picker();

            List<InputDefinition> PointList = new List<InputDefinition>();

            Tekla.Structures.Geometry3d.Point InputPoint = PointPicker.PickPoint();
            
            InputDefinition InputDef = new InputDefinition(InputPoint);
            
            PointList.Add(InputDef);
            
            return PointList;
        }

        /// <summary>
        /// This function is called upon execution of the plugin.
        /// </summary>
        /// <param name="input">List of input definitions</param>
        /// <returns></returns>
        public override bool Run(List<InputDefinition> input)
        {
            try
            {
                // Write your code here.

                double Height = _data.height;

                // Get picked point in Tekla Structures
                Tekla.Structures.Geometry3d.Point StartPoint = (Tekla.Structures.Geometry3d.Point)input[0].GetInput();

                // Calculate the end point of the beam
                Tekla.Structures.Geometry3d.Point EndPoint = new Tekla.Structures.Geometry3d.Point(StartPoint);
                EndPoint.Z += Height;

                // Create a beam instance
                TSModel.Beam Column = new TSModel.Beam(StartPoint, EndPoint);
                Column.Profile.ProfileString = "HEA400";

                // Insert the beam in the model
                Column.Insert();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return true;
        }
    }
}
