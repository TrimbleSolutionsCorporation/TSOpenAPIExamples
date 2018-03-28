using System;

using Tekla.Structures.Drawing;
using Tekla.Structures.Drawing.UI;
using Tekla.Structures.Geometry3d;
using System.Reflection;

namespace BoundingBoxDrawer
{
    public class BoundingBoxDrawer
    {
        static readonly DrawingHandler _drawingHandler = new DrawingHandler();

        BoundingBoxDrawer()
        {
            _drawingHandler.GetConnectionStatus();

            Tekla.Structures.Drawing.UI.Events e = new Tekla.Structures.Drawing.UI.Events();
            e.SelectionChange += e_SelectionChange;
            e.Register();

            Console.ReadLine();
            e.UnRegister();
        }

        void e_SelectionChange()
        {
            lock (this)
            {
                DateTime now = DateTime.Now;
                DeleteDrawingObjectsByUda(_drawingHandler.GetActiveDrawing().GetSheet(), "__MyBBPolygon__");
                DateTime then = DateTime.Now;
                System.Diagnostics.Debug.WriteLine(String.Format("Time used (deleting): {0}", then - now));

                now = DateTime.Now;
                DrawBBs(_drawingHandler);
                _drawingHandler.GetActiveDrawing().CommitChanges();
                then = DateTime.Now;
                System.Diagnostics.Debug.WriteLine(String.Format("Time used (drawing): {0}", then - now));
            }
        }

        static void Main()
        {
            new BoundingBoxDrawer();
        }

        public static void DeleteDrawingObjectsByUda(ViewBase view, String Name)
        {
            DrawingObjectEnumerator objects = view.GetAllObjects();
            objects.SelectInstances = false;
            foreach (DrawingObject drawingObject in objects)
            {
                if (drawingObject is Polygon)
                {
                    int Value = 0;
                    if(drawingObject.GetUserProperty(Name, ref Value))
                        drawingObject.Delete();
                }
            }
        }

        static void DrawBBs(DrawingHandler DrawHandler)
        {
            Drawing ActiveDrawing = DrawHandler.GetActiveDrawing();
            ViewBase Sheet = ActiveDrawing.GetSheet();
            DrawingObjectEnumerator allObjectsOnSheet = Sheet.GetAllObjects();

            allObjectsOnSheet.Reset();
            DrawingObjectSelector dos = DrawHandler.GetDrawingObjectSelector();
            allObjectsOnSheet = dos.GetSelected();

            foreach (DrawingObject drawingObject in allObjectsOnSheet)
            {
                DrawBBForObject(drawingObject);
                DrawBBForObjectFrame(drawingObject);
            }
        }

        private static void DrawBBForObjectFrame(DrawingObject drawingObject)
        {
            try
            {
                // Will throw System.Reflection.AmbiguousMatchException for Mark(Base)
                PropertyInfo AttributesInfo = drawingObject.GetType().GetProperty("Attributes");
                object Attributes = AttributesInfo.GetValue(drawingObject, null);
                object Frame = AttributesInfo.PropertyType.GetProperty("Frame").GetValue(Attributes, null);
                if (Frame is IObjectAlignedBoundingBox)
                {
                    Console.WriteLine("Drawing OABB for {0}.Attributes.Frame", drawingObject.GetType().Name);
                    DrawBB(drawingObject.GetView(),
                           (Frame as IObjectAlignedBoundingBox).GetObjectAlignedBoundingBox(),
                           DrawingColors.Cyan);
                }

                if (Frame is IAxisAlignedBoundingBox)
                {
                    Console.WriteLine("Drawing AABB for {0}.Attributes.Frame", drawingObject.GetType().Name);
                    DrawBB(drawingObject.GetView(),
                           (Frame as IAxisAlignedBoundingBox).GetAxisAlignedBoundingBox(),
                           DrawingColors.Red);
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        private static void DrawBBForObject(DrawingObject drawingObject)
        {
            if (drawingObject is IAxisAlignedBoundingBox)
            {
                drawingObject.Select();
                RectangleBoundingBox currentBB = (drawingObject as IAxisAlignedBoundingBox).GetAxisAlignedBoundingBox();
                Console.WriteLine("Drawing AABB for {0}", drawingObject.GetType().Name);

                DrawBB(drawingObject.GetView(), currentBB, DrawingColors.Red);
            }

            if (drawingObject is IObjectAlignedBoundingBox)
            {
                drawingObject.Select();
                RectangleBoundingBox currentBB = (drawingObject as IObjectAlignedBoundingBox).GetObjectAlignedBoundingBox();
                Console.WriteLine("Drawing OABB for {0}: Width: {1}, Height: {2}, Angle: {3}",
                    drawingObject.GetType().Name,
                    Distance.PointToPoint(currentBB.LowerRight, currentBB.LowerLeft),
                    Distance.PointToPoint(currentBB.UpperLeft, currentBB.LowerLeft),
                    currentBB.AngleToAxis);

                DrawBB(drawingObject.GetView(), currentBB, DrawingColors.Cyan);
            }
        }

        static PointList BBToPointList(RectangleBoundingBox BB)
        {
            PointList polygonPoints = new PointList();
            polygonPoints.Add(BB.LowerLeft);
            polygonPoints.Add(BB.UpperLeft);
            polygonPoints.Add(BB.UpperRight);
            polygonPoints.Add(BB.LowerRight);
            return polygonPoints;
        }

        static void DrawBB(ViewBase DrawView, RectangleBoundingBox BB, DrawingColors Color)
        {
            PointList polygonPoints = BBToPointList(BB);
            Polygon MyPolygon = new Polygon(DrawView, polygonPoints);
            MyPolygon.Attributes.Line.Color = Color;
            MyPolygon.Insert();
            MyPolygon.SetUserProperty("__MyBBPolygon__", 1);
        }
    }
}
