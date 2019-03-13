using System;
using System.Collections.Generic;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Drawing;
using Line = Tekla.Structures.Drawing.Line;
using Arc = Tekla.Structures.Drawing.Arc;

namespace EllipsePlugin
{
    internal class EllipsePluginShapes
    {
        internal static void DrawAnEllipse(ViewBase selectedView, Point p1, Point p2, double majorAxis, double minorAxis, int precision)
        {
            View currentView = (View) selectedView;
            double scale = currentView.Attributes.Scale;
            Point p3 = p2 - p1;

            double angleOfRotation;
            if (p3.X == 0)
            {
                angleOfRotation = Math.PI/2.0;
            }
            else
            {
                angleOfRotation = Math.Atan(p3.Y/p3.X);
            }

            if ((precision%12) != 0)
            {
                precision += (precision%12);
            }

            List<Point> ellipsePoints = CalculateElipsePoints(p1, angleOfRotation, majorAxis*scale, minorAxis*scale, precision);

            DrawEllipseWithArcs(precision, selectedView, ellipsePoints);
        }

        private static List<OpenGraphicObject> DrawEllipseWithArcs(int precision, ViewBase selectedView, List<Point> ellipsePoints)
        {
            Arc arc;
            List<OpenGraphicObject> ellipse = new List<OpenGraphicObject>();
            Point centerPoint = null;
            for (int i = 0; i < precision - 2; i += 2)
            {
                centerPoint = GetCenterPointOfArc(ellipsePoints[i + 2], ellipsePoints[i + 1], ellipsePoints[i]);
                if (centerPoint != null)
                {
                    arc = new Arc(selectedView, ellipsePoints[i + 2], ellipsePoints[i], centerPoint);
                    if (arc.Insert())
                    {
                        ellipse.Add(arc);
                    }
                }
                else
                {//for big ellipse
                    Line line = new Line(selectedView, ellipsePoints[i + 2], ellipsePoints[i]);
                    if (line.Insert())
                    {
                        ellipse.Add(line);
                    }
                }
            }
            centerPoint = GetCenterPointOfArc(ellipsePoints[0], ellipsePoints[precision - 1], ellipsePoints[precision - 2]);
            if (centerPoint != null)
            {
                arc = new Arc(selectedView, ellipsePoints[0], ellipsePoints[precision - 2], centerPoint);
                if (arc.Insert())
                {
                    ellipse.Add(arc);
                }
            }
            else
            {//for big ellipse
                Line line = new Line(selectedView, ellipsePoints[0], ellipsePoints[precision - 2]);
                if (line.Insert())
                {
                    ellipse.Add(line);
                }
            }
            return ellipse;
        }

        internal static Point GetCenterPointOfArc(Point p1, Point p2, Point p3)
        {
            Point center = null;

            // Check that the points are not coincident or colinear within tollerances
            if (Distance.PointToPoint(p1, p2) <= Point.EPSILON_SQUARED ||
                Distance.PointToPoint(p1, p3) <= Point.EPSILON_SQUARED ||
                Distance.PointToPoint(p2, p3) <= Point.EPSILON_SQUARED ||
                Parallel.LineToLine(new Tekla.Structures.Geometry3d.Line(p1, p2),
                                    new Tekla.Structures.Geometry3d.Line(p2, p3)))
            {
                // points are coincident or colinear, no circle can be calculated
                return center;
            }

            Point deltaA = p2 - p1;
            Point deltaB = p3 - p2;
            center = new Point();
            if (Math.Abs(deltaA.X) <= Point.EPSILON_SQUARED && Math.Abs(deltaB.Y) <= Point.EPSILON_SQUARED)
            {
                center.X = 0.5*(p2.X + p3.X);
                center.Y = 0.5*(p1.Y + p2.Y);
                center.Z = p1.Z;
            }
            else
            {
                double aSlope = deltaA.Y/deltaA.X;
                double bSlope = deltaB.Y/deltaB.X;
                center.X = (aSlope*bSlope*(p1.Y - p3.Y) + bSlope*(p1.X + p2.X) - aSlope*(p2.X + p3.X))/
                           (2*(bSlope - aSlope));
                center.Y = -1*(center.X - (p1.X + p2.X)/2.0)/aSlope + (p1.Y + p2.Y)/2.0;
                center.Z = p1.Z;
            }
            return center;
        }

        internal static List<Point> CalculateElipsePoints(Point centerPoint, double rotationAngle, double majorAxis, double minorAxis, int steps)
        {
            List<Point> ellipsePoints = new List<Point>();
            double sinRotation = Math.Sin(rotationAngle);
            double cosRotation = Math.Cos(rotationAngle);
            for (double angle = 0; angle < 2*Math.PI; angle += (2*Math.PI/steps))
            {
                double sinAngle = Math.Sin(angle);
                double cosAngle = Math.Cos(angle);

                double x = centerPoint.X + (majorAxis*cosAngle*cosRotation - minorAxis*sinAngle*sinRotation);
                double y = centerPoint.Y + (majorAxis*cosAngle*sinRotation + minorAxis*sinAngle*cosRotation);
                ellipsePoints.Add(new Point(x, y));
            }
            return ellipsePoints;
        }
    }
}