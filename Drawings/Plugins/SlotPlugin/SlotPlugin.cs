using System;
using System.Collections.Generic;
using Tekla.Structures;
using Tekla.Structures.Drawing;
using Tekla.Structures.Drawing.Tools;
using Tekla.Structures.Drawing.UI;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Plugins;
using Tekla.Structures.Model;

namespace SlotPlugin
{
    /// <summary>
    /// StructuresData class with StructuresFields
    /// </summary>
    public class SlotPluginData
    {
        [StructuresField("SymbolNumber")]
        public int SymbolNumber;

        [StructuresField("SymbolHeight")]
        public double SymbolHeight;

        [StructuresField("FileName")]
        public string FileName;
    }

    /// <summary>
    /// This example drawing plug-in draws an arrow in the direction of the slotted bolt. User has to pick a
    /// bolt and a point where to insert the symbol. You are provided with a symbol "BoltDir", but other symbols
    /// can be used as well. You can also define the height of the symbol in the plug-in dialog. Remember to add the
    /// icon for the drawing plug-in in the toolbar. Look for additional help from Developer's Guide.
    /// </summary>
    [Plugin("SlotPlugin")]
    [PluginUserInterface("SlotPlugin.SlotPluginForm")]
    public class SlotPlugin : DrawingPluginBase
    {
        private SlotPluginData Data { get; set; }

        // Sets the default values.
        private void GetData()
        {
            if (IsDefaultValue(Data.SymbolNumber))
            {
                Data.SymbolNumber = 0;
            }

            if (IsDefaultValue(Data.SymbolHeight))
            {
                Data.SymbolHeight = 4;
            }

            if (IsDefaultValue(Data.FileName))
            {
                Data.FileName = "BoltDir";
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SlotPlugin"/> class. Data is set from the dialog.
        /// </summary>
        /// <param name="data">The data.</param>
        public SlotPlugin(SlotPluginData data)
        {
            Data = data;
        }

        /// <summary>
        /// Run method uses the inputs and the values from the dialog to calculate the direction of the slotted bolt
        /// and then inserts the symbol with the given parameters.
        /// </summary>
        /// <param name="inputs">The inputs.</param>
        /// <returns>True</returns>
        public override bool Run(List<InputDefinition> inputs)
        {
            GetData();

            View BoltView = InputDefinitionFactory.GetView(inputs[0]) as View;
            Bolt Bolt = InputDefinitionFactory.GetDrawingObject(inputs[0]) as Bolt;
            Point InsertionPoint = InputDefinitionFactory.GetPoint(inputs[1]);
            Bolt.Select();

            // Calculation of the direction of the slot.
            Identifier BoltModelObjectIdentifier = Bolt.ModelIdentifier;
            BoltGroup BoltModelSide = new Model().SelectModelObject(BoltModelObjectIdentifier) as BoltGroup;
            double radiansBetween = BoltHelper.GetSlotPartAngleInDrawing(BoltModelSide, BoltView);

            const double HALF_PI = (Math.PI) * 0.5;
            Symbol BoltSymbol = new Symbol(BoltView, InsertionPoint, new SymbolInfo(Data.FileName, Data.SymbolNumber));

            BoltSymbol.Attributes.Angle = radiansBetween * 90 / HALF_PI;
            BoltSymbol.Attributes.Height = Data.SymbolHeight;

            //Symbol insert.
            BoltSymbol.Insert();

            return true;
        }

        /// <summary>
        /// Defines the inputs for the bolt and the point where to insert the symbol.
        /// </summary>
        /// <returns>Inputs</returns>
        public override List<InputDefinition> DefineInput()
        {
            List<InputDefinition> inputs = new List<InputDefinition>();
            DrawingHandler drawingHandler = new DrawingHandler();

            if (drawingHandler.GetConnectionStatus())
            {
                DrawingHandler DrawingHandler = new DrawingHandler();
                Picker Picker = DrawingHandler.GetPicker();
                DrawingObject DrawingObject;
                ViewBase ViewBase;
                Point PickedPoint = new Point();

                Picker.PickObject("Pick a bolt", new Type[] { typeof(Bolt) }, out DrawingObject, out ViewBase, out PickedPoint);

                Bolt Bolt = DrawingObject as Bolt;

                Point InsertionPoint = new Point();

                Picker.PickPoint("Pick a point to insert symbol", out InsertionPoint, out ViewBase);

                // Add inputs to the list of InputDefinitions using the InputDefinitionFactory.
                inputs.Add(InputDefinitionFactory.CreateInputDefinition(ViewBase, Bolt));
                inputs.Add(InputDefinitionFactory.CreateInputDefinition(ViewBase, InsertionPoint));

            }

            return inputs;
        }
    }
}
