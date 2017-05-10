using System.Collections;
using System.Collections.Generic;

using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Solid;

namespace PartCenterLineIntersection
{
    /// <summary>
    /// This example draws the faces of a part that intersect with the center line of the part.
    /// It demonstrates:
    /// - How to work with solid / faces.
    /// - How to work with geometry functions (distance, intersection).
    /// - How to use temporary graphics in model views.
    /// </summary>
    class PartCenterLineIntersection
    {
        static void Main()
        {
            Model myModel = new Model();
            TransformationPlane savedPlane = myModel.GetWorkPlaneHandler().GetCurrentTransformationPlane();
            myModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane());

            Picker myPicker = new Picker();
            Part myPart = myPicker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, "Pick Part") as Part;

            if (myPart != null)
            {
                Solid mySolid = myPart.GetSolid();
                ArrayList intersectionPoints = PartCenterLineIntersections(myPart, mySolid);

                Dictionary<Plane, Face> partPlanes = GetGeometricPlanes(mySolid);

                foreach (Point intersectPoint in intersectionPoints)
                {
                    DrawFaceOfIntersectionPoint(intersectPoint, partPlanes);
                }
            }

            myModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(savedPlane);
        }

        private static void DrawFaceOfIntersectionPoint(Point intersectPoint, Dictionary<Plane, Face> partPlanes)
        {
            foreach (Plane plane in partPlanes.Keys)
            {
                GeometricPlane geometricPlane = new GeometricPlane(plane.Origin, plane.AxisX, plane.AxisY);
                double myDistance = Distance.PointToPlane(intersectPoint, geometricPlane);

                if (myDistance <= 1)
                    DrawMesh(partPlanes[plane]);
            }
        }

        private static void DrawMesh(Face face)
        {
            GraphicsDrawer graphicsDrawer = new GraphicsDrawer();
            Mesh mesh = new Mesh();
            LoopEnumerator loops = face.GetLoopEnumerator();
            loops.MoveNext();
            Loop loop = loops.Current as Loop;
            VertexEnumerator vertexes = loop.GetVertexEnumerator();

            while (vertexes.MoveNext())
            {
                mesh.AddPoint(vertexes.Current as Point);
            }

            for (int index = 0; index < mesh.Points.Count - 2; index++)
            {
                mesh.AddTriangle(index, index + 1, index + 2);
                mesh.AddTriangle(index + 2, index + 1, index);
            }

            mesh.AddTriangle(mesh.Points.Count - 2, mesh.Points.Count - 1, 0);
            mesh.AddTriangle(0, mesh.Points.Count - 1, mesh.Points.Count - 2);

            graphicsDrawer.DrawMeshSurface(mesh, new Color(1, 0, 0));
        }

        static ArrayList PartCenterLineIntersections(Part myPart, Solid mySolid)
        {
            double partLength = 0;
            myPart.GetReportProperty("LENGTH", ref partLength);

            #region searching center line of the part
            Point centerLinePoint1 = myPart.GetCoordinateSystem().Origin;
            Point centerLinePoint2 = new Point();
            myPart.GetReportProperty("COG_X", ref centerLinePoint2.X);
            myPart.GetReportProperty("COG_Y", ref centerLinePoint2.Y);
            myPart.GetReportProperty("COG_Z", ref centerLinePoint2.Z);

            LineSegment centerLine = new LineSegment(centerLinePoint1, centerLinePoint2);
            #endregion
            ////GetCenterLine() method is available now From OpenAPI.
            ////Use the method instead of above lines searching center line of the part.
            //ArrayList CenterLinePoints = MyPart.GetCenterLine(false);
            //Point CenterLinePoint1 = (Point)CenterLinePoints[0];
            //Point CenterLinePoint2 = (Point)CenterLinePoints[1];
            //LineSegment CenterLine = new LineSegment((Point)CenterLinePoints[0], (Point)CenterLinePoints[1]);

            Vector centerLineVector = centerLine.GetDirectionVector();
            centerLineVector.Normalize(partLength);
            centerLinePoint1 = centerLinePoint1 - centerLineVector;
            centerLinePoint2 = centerLinePoint2 + centerLineVector;
            centerLine = new LineSegment(centerLinePoint1, centerLinePoint2);
            return mySolid.Intersect(centerLine);
        }

        internal static Dictionary<Plane, Face> GetGeometricPlanes(Solid solid)
        {
            FaceEnumerator faceEnum = solid.GetFaceEnumerator();
            Dictionary<Plane, Face> planes = new Dictionary<Plane, Face>();
            while (faceEnum.MoveNext())
            {
                List<Point> planeVertexes = new List<Point>();

                Face face = faceEnum.Current as Face;

                LoopEnumerator loops = face.GetLoopEnumerator();
                while (loops.MoveNext())
                {
                    Loop loop = loops.Current as Loop;
                    VertexEnumerator vertexes = loop.GetVertexEnumerator();

                    while (vertexes.MoveNext())
                    {
                        Point vertex = vertexes.Current as Point;
                        if (!planeVertexes.Contains(vertex))
                        {
                            //Three points form a plane and they cannot be aligned.
                            if (planeVertexes.Count != 3 ||
                                (planeVertexes.Count == 3 && !ArePointAligned(planeVertexes[0], planeVertexes[1], vertex)))
                                planeVertexes.Add(vertex);

                            if (planeVertexes.Count == 3)
                            {
                                Vector vector1 = new Vector(planeVertexes[1].X - planeVertexes[0].X, planeVertexes[1].Y - planeVertexes[0].Y, planeVertexes[1].Z - planeVertexes[0].Z);
                                Vector vector2 = new Vector(planeVertexes[2].X - planeVertexes[0].X, planeVertexes[2].Y - planeVertexes[0].Y, planeVertexes[2].Z - planeVertexes[0].Z);

                                Plane plane = new Plane();
                                plane.Origin = planeVertexes[0];
                                plane.AxisX = vector1;
                                plane.AxisY = vector2;
                                planes.Add(plane, face);
                                break;
                            }
                        }
                    }
                    break;
                }
            }
            return planes;
        }

        internal static bool ArePointAligned(Point point1, Point point2, Point point3)
        {
            Vector vector1 = new Vector(point2.X - point1.X, point2.Y - point1.Y, point2.Z - point1.Z);
            Vector vector2 = new Vector(point3.X - point1.X, point3.Y - point1.Y, point3.Z - point1.Z);

            return Parallel.VectorToVector(vector1, vector2);
        }
    }
}
