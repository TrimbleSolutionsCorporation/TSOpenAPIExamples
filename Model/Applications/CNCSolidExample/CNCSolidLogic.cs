using System.Collections.Generic;
using System.Windows.Forms;

using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Solid;
using TSSolid = Tekla.Structures.Solid;
using Tekla.Structures.Model.UI;
using Point = Tekla.Structures.Geometry3d.Point;

namespace CNCSolidExample
{
    /// <summary>
    /// An example application that allows CNC manufacturers to be able to specify a primary part, then a secondary part and return 
    /// the Tekla.Structures.Model.Solid face on the secondary part that is contacting or as close to contacting the primary part. 
    /// The application also draws a mesh surface on the specific face.
    /// </summary>
    internal class CNCSolidLogic
    {
        internal static void GetParts(ref Dictionary<Plane, Face> FirstBeamPlanes, ref Dictionary<Plane, Face> SecondaryBeamPlanes)
        {
            Picker Picker = new Picker();

            Part Part1 = Picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART) as Part;
            Part Part2 = Picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART) as Part;
            
            if (Part1 != null && Part2 != null)
            {
                Solid Solid = Part1.GetSolid(Solid.SolidCreationTypeEnum.RAW);
                FirstBeamPlanes = GetGeometricPlane(Solid);

                Solid Solid2 = Part2.GetSolid(Solid.SolidCreationTypeEnum.RAW);
                SecondaryBeamPlanes = GetGeometricPlane(Solid2);
            }
            else
            {
                MessageBox.Show("You need to pick two parts.");
            }
        }

        /// <summary>
        /// Gets the Planes from the Faces of the Solid.
        /// </summary>
        /// <returns>Dictionary of Planes and corresponding Faces</returns>
        internal static Dictionary<Plane, Face> GetGeometricPlane(Solid Solid)
        {
            FaceEnumerator FaceEnum = Solid.GetFaceEnumerator();
            Dictionary<Plane, Face> Planes = new Dictionary<Plane, Face>();
            while (FaceEnum.MoveNext())
            {
                List<Point> PlaneVertexes = new List<Point>();

                Face Face = FaceEnum.Current as Face;

                LoopEnumerator Loops = Face.GetLoopEnumerator();
                while (Loops.MoveNext())
                {
                    Loop Loop = Loops.Current as Loop;
                    VertexEnumerator Vertexes = Loop.GetVertexEnumerator();

                    while (Vertexes.MoveNext())
                    {
                        Point Vertex = Vertexes.Current as Point;
                        if (!PlaneVertexes.Contains(Vertex))
                        {
                            //Three points form a plane and they cannot be aligned.
                            if (PlaneVertexes.Count != 3 ||
                                (PlaneVertexes.Count == 3 && !ArePointAligned(PlaneVertexes[0], PlaneVertexes[1], Vertex)))
                                PlaneVertexes.Add(Vertex);

                            if (PlaneVertexes.Count == 3)
                            {
                                Vector Vector1 = new Vector(PlaneVertexes[1].X - PlaneVertexes[0].X, PlaneVertexes[1].Y - PlaneVertexes[0].Y, PlaneVertexes[1].Z - PlaneVertexes[0].Z);
                                Vector Vector2 = new Vector(PlaneVertexes[2].X - PlaneVertexes[0].X, PlaneVertexes[2].Y - PlaneVertexes[0].Y, PlaneVertexes[2].Z - PlaneVertexes[0].Z);

                                Plane Plane = new Plane();
                                Plane.Origin = PlaneVertexes[0];
                                Plane.AxisX = Vector1;
                                Plane.AxisY = Vector2;
                                Planes.Add(Plane, Face);
                                break;
                            }
                        }
                    }
                    break;
                }
            }
            return Planes;
        }
        /// <summary>
        /// A simple method to test if points are on the same line.
        /// </summary>
        internal static bool ArePointAligned(Point Point1, Point Point2, Point Point3)
        {
            Vector Vector1 = new Vector(Point2.X - Point1.X, Point2.Y - Point1.Y, Point2.Z - Point1.Z);
            Vector Vector2 = new Vector(Point3.X - Point1.X, Point3.Y - Point1.Y, Point3.Z - Point1.Z);

            return Parallel.VectorToVector(Vector1, Vector2);
        }

        /// <summary>
        /// Compares planes if they are parallel and that the distance between.
        /// </summary>
        /// <param name="MaximumOffset"></param>
        /// <returns>The list of Faces that comply with the MaximumOffset variable set by the user before picking parts.</returns>
        internal static List<Face> CompareNormals(Dictionary<Plane, Face> FirstBeamNormals, Dictionary<Plane, Face> SecondaryBeamNormals, double MaximumOffset)
        {
            List<Face> Faces = new List<Face>();

            foreach (Plane Plane in FirstBeamNormals.Keys)
            {
                foreach (Plane PlaneToCompare in SecondaryBeamNormals.Keys)
                {
                    Vector PlaneNormal = Vector.Cross(Plane.AxisX, Plane.AxisY);
                    Vector PlaneToCompareNormal = Vector.Cross(PlaneToCompare.AxisX, PlaneToCompare.AxisY);

                    if (Vector.Dot(PlaneNormal.GetNormal(), PlaneToCompareNormal.GetNormal()) == -1)
                    {
                        GeometricPlane GeometricPlane = new GeometricPlane(PlaneToCompare.Origin, PlaneToCompareNormal);
                        double distance = Distance.PointToPlane(Plane.Origin, GeometricPlane);

                        if (distance <= MaximumOffset)
                        {
                            DrawMesh(Plane);
                            Faces.Add(FirstBeamNormals[Plane]);
                        }
                    }
                }
            }
            return Faces;
        }

        /// <summary>
        /// Draws a MeshSurface from a Plane to show the outcome more clearly. 
        /// The drawings are temporary graphics and dont do more than show where the plane is.
        /// </summary>
        private static void DrawMesh(Plane Plane)
        {
            GraphicsDrawer GraphicsDrawer = new GraphicsDrawer();

            Mesh Mesh = new Mesh();
            Point Point1 = new Point(Plane.Origin);

            Vector NormalX = Plane.AxisX.GetNormal()*300;

            Point Point2 = new Point(Plane.Origin);
            Point2.Translate(NormalX.X, NormalX.Y, NormalX.Z);

            Vector NormalY = Plane.AxisY.GetNormal() * 300;

            Point Point3 = new Point(Plane.Origin);
            Point3.Translate(NormalY.X, NormalY.Y, NormalY.Z);

            Point Point4 = new Point(Point2);
            Point4.Translate(NormalY.X, NormalY.Y, NormalY.Z);

            Mesh.AddPoint(Point1);
            Mesh.AddPoint(Point2);
            Mesh.AddPoint(Point3);
            Mesh.AddPoint(Point4);

            Mesh.AddTriangle(0, 1, 2);
            Mesh.AddTriangle(2, 1, 0);
            Mesh.AddTriangle(1, 2, 3);
            Mesh.AddTriangle(3, 2, 1);
            
            GraphicsDrawer.DrawMeshSurface(Mesh, new Color(1, 0, 0));
        }
    }
}
