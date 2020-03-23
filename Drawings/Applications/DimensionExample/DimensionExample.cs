using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Tekla.Structures;
using Tekla.Structures.Drawing.UI;
using Tekla.Structures.Drawing;
using Tekla.Structures.Model;
using TSMUI = Tekla.Structures.Model.UI;
using Tekla.Structures.Geometry3d;
using ModelObject = Tekla.Structures.Model.ModelObject;
using Part = Tekla.Structures.Drawing.Part;

namespace DimensionExample
{
    /// <summary>
    /// This is a sample of dimension creation with Tekla.Net API. In this sample #1 we have a static application 
    /// which creates straight x dimensions to the beams in the active drawing. The implementation is based on basic Tekla.Net 
    /// dimension classes without any higher level intelligence.
    /// </summary>
    class DimensionExample
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                DrawingHandler DrawingHandler = new DrawingHandler();

                if (DrawingHandler.GetConnectionStatus())
                {
                    Drawing CurrentDrawing = DrawingHandler.GetActiveDrawing();
                    if (CurrentDrawing != null)
                    {
                        DrawingObjectEnumerator DrawingObjectEnumerator = CurrentDrawing.GetSheet().GetAllObjects(typeof(Part));

                        foreach (Part myPart in DrawingObjectEnumerator)
                        {
                            View View = myPart.GetView() as View;
                            TransformationPlane SavePlane = new Model().GetWorkPlaneHandler().GetCurrentTransformationPlane();
                            new Model().GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane(View.DisplayCoordinateSystem));

                            Identifier Identifier = myPart.ModelIdentifier;
                            ModelObject ModelSideObject = new Model().SelectModelObject(Identifier);

                            PointList PointList = new PointList();
                            Beam myBeam = new Beam();
                            if (ModelSideObject.GetType().Equals(typeof(Beam)))
                            {
                                myBeam.Identifier = Identifier;
                                myBeam.Select();

                                PointList.Add(myBeam.StartPoint);
                                PointList.Add(myBeam.EndPoint);
                            }

                            ViewBase ViewBase = myPart.GetView();
                            StraightDimensionSet.StraightDimensionSetAttributes attr = new StraightDimensionSet.StraightDimensionSetAttributes(myPart);

                            if (myBeam.StartPoint.X != myBeam.EndPoint.X)
                            {
                                StraightDimensionSet XDimensions = new StraightDimensionSetHandler().CreateDimensionSet(ViewBase, PointList, new Vector(0, 100, 0), 100, attr);
                                CurrentDrawing.CommitChanges();
                            }

                            new Model().GetWorkPlaneHandler().SetCurrentTransformationPlane(SavePlane);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());
            }
        }
    }
}
