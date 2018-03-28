using System;
using System.Windows.Forms;
using System.Collections.Generic;

using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using TSM = Tekla.Structures.Model;
using Tekla.Structures.Plugins;
using Tekla.Structures.Drawing;
using Tekla.Structures.Drawing.Tools;
using Tekla.Structures.Drawing.UI;
using View = Tekla.Structures.Drawing.View;
using ModelObject = Tekla.Structures.Drawing.ModelObject;

namespace InsertMarkPlugin
{
    /// <summary>
    /// This plugin shows how to insert a mark with defined text on a picked part in drawing.
    /// </summary>
    public class PluginData
    {
        #region Fields
        [Tekla.Structures.Plugins.StructuresField("Text")]
        public string Text;
        #endregion
    }

    [Plugin("InsertMarkPlugin")]
    [PluginUserInterface("InsertMarkPlugin.InsertMarkPluginForm")]
    public class InsertMarkPlugin : DrawingPluginBase
    {
        #region Fields
        private PluginData data;
        #endregion

        #region Properties
        private PluginData Data
        {
            get { return data; }
            set { data = value; }
        }
        #endregion

        #region Constructor
        public InsertMarkPlugin(PluginData data)
        {
            Data = data;
        }
        #endregion

        #region Sets the default value
        private void GetData()
        {
            if (IsDefaultValue(Data.Text))
            {
                Data.Text = "My Mark";
            }
        }
        #endregion

        #region Overrides
        public override List<InputDefinition> DefineInput()
        {
            List<InputDefinition> inputs = new List<InputDefinition>();
            DrawingHandler drawingHandler = new DrawingHandler();

            if (drawingHandler.GetConnectionStatus())
            {
                Picker picker = drawingHandler.GetPicker();

                ViewBase view = null;
                DrawingObject pickedPart = null;

                picker.PickObject("Pick part", out pickedPart, out view);

                inputs.Add(InputDefinitionFactory.CreateInputDefinition(view, pickedPart));
            }

            return inputs;
        }

        public override bool Run(List<InputDefinition> inputs)
        {
            try
            {
                GetData();

                ViewBase view = InputDefinitionFactory.GetView(inputs[0]);
                ModelObject modelObject = (ModelObject)InputDefinitionFactory.GetDrawingObject(inputs[0]);

                Model myModel = new Model();

                Point partMiddleStart = null, partMiddleEnd = null, partCenterPoint = null;
                GetPartPoints(myModel, view, modelObject, out partMiddleStart, out partMiddleEnd, out partCenterPoint);

                Mark mark = new Mark(modelObject);
                mark.Attributes.Content.Clear();
                mark.Attributes.Content.Add(new TextElement(Data.Text));              
                mark.Attributes.Content.Add(new UserDefinedElement("PROFILE"));

                mark.Placing = new AlongLinePlacing(partMiddleStart, partMiddleEnd);
                mark.InsertionPoint = partCenterPoint;
                mark.Insert();
            }
            catch (Exception Exc)
            {
                MessageBox.Show(Exc.ToString());
            }
            return true;
        }
        #endregion

        #region Private methods
        private void GetPartPoints(TSM.Model myModel, ViewBase partView, ModelObject modelObject, out Point partMiddleStart, out Point partMiddleEnd, out Point partCenterPoint)
        {
            TSM.ModelObject modelPart = GetModelObjectFromDrawingModelObject(myModel, modelObject);
            GetModelObjectStartAndEndPoint(modelPart, (View)partView, out partMiddleStart, out partMiddleEnd);
            partCenterPoint = GetInsertionPoint(partMiddleStart, partMiddleEnd);
        }

        private TSM.ModelObject GetModelObjectFromDrawingModelObject(TSM.Model myModel, ModelObject partOfMark)
        {
            TSM.ModelObject modelObject = myModel.SelectModelObject(partOfMark.ModelIdentifier);

            TSM.Part modelPart = (TSM.Part)modelObject;

            return modelPart;
        }

        private void GetModelObjectStartAndEndPoint(TSM.ModelObject modelObject, View partView, out Point partStartPoint, out Point PartEndPoint)
        {
            TSM.Part modelPart = (TSM.Part)modelObject;
            
            TransformationPlane savePlane = new Model().GetWorkPlaneHandler().GetCurrentTransformationPlane();
            new Model().GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane());

            partStartPoint = modelPart.GetSolid().MinimumPoint;
            partStartPoint.Z = 0.0;
            PartEndPoint = modelPart.GetSolid().MaximumPoint;

            Matrix convMatrix = MatrixFactory.ToCoordinateSystem(partView.DisplayCoordinateSystem);
            partStartPoint = convMatrix.Transform(partStartPoint);
            PartEndPoint = convMatrix.Transform(PartEndPoint);

            new Model().GetWorkPlaneHandler().SetCurrentTransformationPlane(savePlane);
        }

        private Point GetInsertionPoint(Point partStartPoint, Point partEndPoint)
        {
            Point minPoint = partStartPoint;
            Point maxPoint = partEndPoint;
            Point insertionPoint = new Point((maxPoint.X + minPoint.X) * 0.5, (maxPoint.Y + minPoint.Y) * 0.5, (maxPoint.Z + minPoint.Z) * 0.5);
            insertionPoint.Z = 0;
            return insertionPoint;
        }
        #endregion
    }
}
