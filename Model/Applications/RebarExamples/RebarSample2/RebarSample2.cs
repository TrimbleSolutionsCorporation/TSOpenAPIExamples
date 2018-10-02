using System;
using System.Collections;
using Tekla.Structures;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using TSMUI = Tekla.Structures.Model.UI;

namespace RebarSample2
{
    /// <summary>
    /// This is a sample #2 of reinforcement creation with Tekla.Net API. In this sample #2 we have a static application 
    /// which creates longitudinal bars at bottom and top of part and stirrups around them for selected parts. 
    /// The implementatiomn is based on usage of two system components throught Tekla.Net. The advanatage of this compared to 
    /// usage of basic classess that the actual reinforcement have the limited intelligence provided by the system components like
    /// stirrups and bars reaction to voids.
    /// </summary>
    class Class1
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Model myModel = new Model();
                ModelObjectEnumerator myEnum = new TSMUI.ModelObjectSelector().GetSelectedObjects();
                
                while(myEnum.MoveNext())
                {
                    Beam myPart = myEnum.Current as Beam;
                    if(myPart != null)
                    {
                        // first store current work plane 
                        TransformationPlane currentPlane = myModel.GetWorkPlaneHandler().GetCurrentTransformationPlane();

                        // set new work plane same as part's local coordsys
                        TransformationPlane localPlane = new TransformationPlane(myPart.GetCoordinateSystem());
                        myModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(localPlane);

                        // get solid of part to be used for rebar component point calculations
                        Solid solid = myPart.GetSolid() as Solid;

                        // initialize the component used to model longitudinal bars
                        Component component1 = new Component();
                        component1.Number = 30000070;    // unique number for "longitudinal rebars" component

                        // mamange the settings i.e. load standard defaults and set the few important attribute values explicitely
                        component1.LoadAttributesFromFile("standard");
                        component1.SetAttribute("bar1_no", 4);      // number of bars
                        component1.SetAttribute("cc_side", 45.0);   // cover thickness at side
                        component1.SetAttribute("cc_bottom", 45.0); // cover thickness at bottom


                        // prepare input points for the "longitudinal rebars" component
                        Point p1 = new Point(solid.MinimumPoint.X, solid.MinimumPoint.Y, solid.MaximumPoint.Z);
                        Point p2 = new Point(solid.MaximumPoint.X, solid.MinimumPoint.Y, solid.MaximumPoint.Z);
                        Point p3 = new Point(solid.MinimumPoint.X, solid.MinimumPoint.Y, solid.MinimumPoint.Z);

                        // set up component input sequence
                        ComponentInput input1 = new ComponentInput();
                        input1.AddInputObject(myPart);
                        input1.AddTwoInputPositions(p1, p2);
                        input1.AddOneInputPosition(p3);

                        // Add the input for component 
                        component1.SetComponentInput(input1);

                        // insert new component instance into model
                        component1.Insert();

                        // resuse the same component object to add new instance at top of beam
                        
                        // modify input points
                        p1.Y = p2.Y = p3.Y = solid.MaximumPoint.Y;  // "move" points to top of beam

                        // modify neccesary settings & insert compoent instance into model
                        component1.SetAttribute("bar1_no",2);  
                        component1.Insert();
                    
                        // initialize the component to be used to model stirrups
                        Component component2 = new Component();
                        component2.Number = 30000067;    // unique number for "Stirrup reinforcement" component

                        // prepare input polygon for the component
                        Polygon polygon = new Polygon();
                        polygon.Points.Add(new Point(solid.MinimumPoint.X, solid.MaximumPoint.Y, solid.MinimumPoint.Z));
                        polygon.Points.Add(new Point(solid.MinimumPoint.X, solid.MaximumPoint.Y, solid.MaximumPoint.Z));
                        polygon.Points.Add(new Point(solid.MinimumPoint.X, solid.MinimumPoint.Y, solid.MaximumPoint.Z));
                        polygon.Points.Add(new Point(solid.MinimumPoint.X, solid.MinimumPoint.Y, solid.MinimumPoint.Z));
                        polygon.Points.Add(new Point(solid.MinimumPoint.X, solid.MinimumPoint.Y, solid.MinimumPoint.Z));

                        // set up component input sequence
                        ComponentInput input2 = new ComponentInput();
                        input2.AddInputObject(myPart);
                        input2.AddInputPolygon(polygon);
                        input2.AddTwoInputPositions(new Point(solid.MinimumPoint.X, 0, 0), new Point(solid.MaximumPoint.X, 0, 0));

                        // Add the input for component 
                        component2.SetComponentInput(input2);

                        // mamange the settings i.e. load standard defaults and set the few important attribute values explicitely
                        component2.LoadAttributesFromFile("standard");
                        component2.SetAttribute("bar1_size", "8");      

                        // insert new component instance into model
                        component2.Insert();

                        // remember to restore current work plane
                        myModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(currentPlane);

                    }
                }
                myModel.CommitChanges();  
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());
            }

            finally
            {
            }
        }
    }
}
