using System;
using Tekla.Structures.Drawing.UI;
using Tekla.Structures.Drawing;
using Tekla.Structures.Geometry3d;

namespace DimensionCreator
{
    class DimensionCreator
    {
        private static readonly PointList lastPoints = new PointList();
        private static ViewBase lastView;
        public static bool Repeat = false;
        public static int Points = 3;

        static void PickPoints(int numberToPick, ref PointList pointList, ref ViewBase view)
        {
            if (Repeat)
            {
                view = lastView;
                foreach (Point pointt in lastPoints)
                {
                    pointList.Add(new Point(pointt));
                }
                return;
            }

            var picker = new DrawingHandler().GetPicker();
            int ii = numberToPick;
            lastPoints.Clear();
            while (--ii != -1)
            {
                Point point;
                picker.PickPoint("Pick point", out point, out view);
                pointList.Add(point);
                lastPoints.Add(new Point(point));
            }
            lastView = view;
        }

        public static void CreateAngleDimension()
        {
            PointList pointList = new PointList();
            ViewBase view = null;
            PickPoints(3, ref pointList, ref view);
            double distance = Math.Sqrt(new Vector(pointList[1] - pointList[0]).Dot(new Vector(pointList[1] - pointList[0])));

            double viewScale = 1.0;
            if (view is View)
                viewScale = (view as View).Attributes.Scale;

            distance = distance / viewScale;
            AngleDimension ad = new AngleDimension(view, pointList[0], pointList[1], pointList[2], distance);
            ad.Insert();

            new DrawingHandler().GetActiveDrawing().CommitChanges();
        }


        internal static void CreateRadiusDimension(double distance)
        {
            PointList pointList = new PointList();
            ViewBase view = null;
            PickPoints(3, ref pointList, ref view);
            RadiusDimension rd = new RadiusDimension(view, pointList[0], pointList[1], pointList[2], distance);
            rd.Insert();

            new DrawingHandler().GetActiveDrawing().CommitChanges();
        }

        internal static void CreateStraightDimension(double distance)
        {
            PointList pointList = new PointList();
            ViewBase view;
            Point firstPoint;
            Point secondPoint;

            Picker picker = new DrawingHandler().GetPicker();
            picker.PickTwoPoints("Pick first point", "Pick second point", out firstPoint, out secondPoint, out view);
            pointList.Add(firstPoint);
            pointList.Add(secondPoint);
            // At least one point must be associated to part or tags won't work.
            Vector direction = new Vector(firstPoint.Y - secondPoint.Y, secondPoint.X - firstPoint.X, firstPoint.Z);

            StraightDimensionSet sds = new StraightDimensionSetHandler().CreateDimensionSet(view, pointList, direction, distance);

            sds.Attributes.LeftLowerTag.Add(new TextElement("LeftLow"));
            sds.Attributes.LeftMiddleTag.Add(new TextElement("LeftMiddle"));
            sds.Attributes.LeftUpperTag.Add(new TextElement("LeftUpper"));
            sds.Attributes.RightLowerTag.Add(new TextElement("RightLow"));
            sds.Attributes.RightMiddleTag.Add(new TextElement("RightMiddle"));
            sds.Attributes.RightUpperTag.Add(new TextElement("RightUpper"));
            bool isOk = sds.Modify();

            new DrawingHandler().GetActiveDrawing().CommitChanges();
        }

        internal static void CreateCurvedOrthoDimension(double distance)
        {
            PointList pointList = new PointList();
            ViewBase view = null;
            PickPoints(Points, ref pointList, ref view);
            new CurvedDimensionSetHandler().CreateCurvedDimensionSetOrthogonal(view, pointList[0], pointList[1], pointList[pointList.Count-1], pointList,
                                                                               distance);

            new DrawingHandler().GetActiveDrawing().CommitChanges();
        }

        internal static void CreateCurvedRadialDimension(double distance)
        {
            PointList pointList = new PointList();
            ViewBase view = null;
            PickPoints(3, ref pointList, ref view);
            new CurvedDimensionSetHandler().CreateCurvedDimensionSetRadial(view, pointList[0], pointList[1], pointList[2], pointList,
                                                                               distance);

            new DrawingHandler().GetActiveDrawing().CommitChanges();
        }
    }
}
