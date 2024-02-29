using System.Collections.Generic;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Plugins;
using Tekla.Structures.Drawing;
using Tekla.Structures.Drawing.Tools;
using Tekla.Structures.Drawing.UI;

namespace EllipsePlugin
{
    #region Plugin implementation
    [Plugin("EllipsePlugin")]
    [InputObjectDependency(PluginBase.InputObjectDependency.DEPENDENT)]
    [PluginUserInterface("EllipsePlugin.EllipsePluginForm")]
    [UpdateMode(DrawingPluginBase.UpdateMode.DRAWING_OPENED)]
    public class EllipsePlugin : DrawingPluginBase
    {
        private EllipsePluginData Data { get; set; }

        public EllipsePlugin(EllipsePluginData data)
        {
            Data = data;
        }

        #region Plugin interface implementation

        public override List<InputDefinition> DefineInput()
        {
            List<InputDefinition> inputs = new List<InputDefinition>();
            DrawingHandler drawingHandler = new DrawingHandler();

            if (drawingHandler.GetConnectionStatus())
            {
                Picker picker = drawingHandler.GetPicker();

                ViewBase view;
                PointList points;

                StringList prompts = new StringList();
                prompts.Add("albl_Pick_center_point");
                prompts.Add("albl_Pick_major_axis_point");

                picker.PickPoints(2, prompts, out points, out view);
                inputs.Add(InputDefinitionFactory.CreateInputDefinition(view, points));
            }

            return inputs;
        }

        public override bool Run(List<InputDefinition> inputs)
            {
                ViewBase view = InputDefinitionFactory.GetView(inputs[0]);
                PointList points = InputDefinitionFactory.GetPoints(inputs[0]);
                if(Distance.PointToPoint(points[0], points[1]) <= Point.EPSILON_SQUARED)
                {
                    return false;
                }

                Data.CheckDefaults(this);
                EllipsePluginShapes.DrawAnEllipse(view, points[0], points[1], Data.MajorAxis, Data.MinorAxis, Data.Precision);

                return true;
            }

        #endregion
    }

    #endregion
}
