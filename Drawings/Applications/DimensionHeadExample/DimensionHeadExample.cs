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

namespace DimensionHeadExample
{
    /// <summary>
    /// This is a sample of dimension creation to show how to use the Arrowhead attribute. In this we have a static application 
    /// which creates straight x dimensions to the beams in the active drawing.
    /// 
    /// Specifically we show how to use customized arrows from dimension_arrows.sym
    /// You can find info on how to edit the symbol file here...
    /// https://teklastructures.support.tekla.com/search/site/customize%20dimension%20line%20arrows
    /// 
    /// Once you have your arrow defined in dimension_arrows.sym you can use it from the API using the symbol number.
    ///  ie. attr.Arrowhead.Head = (ArrowheadTypes)8;
    /// </summary>
    class DimensionHeadExample
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

                            // This would create a dimension using the circle arrow.
                            attr.Arrowhead.Head = ArrowheadTypes.CircleArrow;

                            // This creates a dimension using the corresponding arrow (Number 8) defined in dimension_arrows.sym
                            attr.Arrowhead.Head = (ArrowheadTypes)8;

                            if (myBeam.StartPoint.X != myBeam.EndPoint.X)
                            {
                                StraightDimensionSet XDimensions = new StraightDimensionSetHandler().CreateDimensionSet(ViewBase, PointList, new Vector(0, 100, 0), 100, attr);
                            }

                            new Model().GetWorkPlaneHandler().SetCurrentTransformationPlane(SavePlane);
                        }

                        CurrentDrawing.CommitChanges();
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
