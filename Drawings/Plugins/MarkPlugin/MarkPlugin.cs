using System;
using System.Collections.Generic;
using System.Drawing;
using Tekla.Structures.Plugins;
using Tekla.Structures.Drawing;
using Tekla.Structures.Drawing.Tools;
using Tekla.Structures.Drawing.UI;

namespace MarkPlugin
{
    #region Plugin attribute data structure

    public class MarkPluginData
    {
        [StructuresField("text")]
        public string Text;

        [StructuresField("color")]
        public int Color;

        [StructuresField("angle")]
        public double Angle;
    }

    #endregion

    #region Plugin implementation

    [Plugin("MarkPlugin")]
    [PluginUserInterface("MarkPlugin.MarkPluginForm")]
    public class MarkPlugin : DrawingPluginBase
    {
        readonly StringList _pickerPrompts = new StringList { "Pick first point", "Pick second point" };
        private MarkPluginData Data { get; set; }

        public MarkPlugin(MarkPluginData data)
        {
            Data = data;
        }

        #region Plugin interface implementation

        public override List<InputDefinition> DefineInput()
        {
            var drawingHandler = new DrawingHandler();

            Picker picker = drawingHandler.GetPicker();
            var pick = picker.PickPoints(2, _pickerPrompts);

            return new List<InputDefinition>
            {
                InputDefinitionFactory.CreateInputDefinition(pick)
            };
        }

        private static string FormatMarkText(string prefix, ViewBase view, PointList points)
        {
            return String.Format("{0} Points to: {1}", prefix, points[0]);
        }

        public override bool Run(List<InputDefinition> inputs)
        {
            ViewBase view = InputDefinitionFactory.GetView(inputs[0]);
            PointList points = InputDefinitionFactory.GetPoints(inputs[0]);

            if(IsDefaultValue(Data.Angle))
            {
                Data.Angle = 0.0; // Default value of drawing plugins can be set with empty text field or 0.0
            }
            if(IsDefaultValue(Data.Text))
            {
                Data.Text = "Mark Plugin";
            }
            if(IsDefaultValue(Data.Color))
            {
                Data.Color = (int)DrawingColors.Black;
            }

            var frame = new Frame(FrameTypes.Rectangular, (DrawingColors)Data.Color);
            var text = new Text(view, points[0], FormatMarkText(Data.Text, view, points), new LeaderLinePlacing(points[1]))
                {
                    Attributes = {
                        Frame = frame,
                        Angle = this.Data.Angle,
                        Font = { Color = (DrawingColors)this.Data.Color } }
                };

            text.Insert();

            return true;
        }

        #endregion
    }

    #endregion
}
