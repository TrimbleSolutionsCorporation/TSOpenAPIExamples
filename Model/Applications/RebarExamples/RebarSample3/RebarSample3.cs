using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using Tekla.Structures.Plugins;
using Tekla.Structures;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace RebarSample3
{
    /// <summary>
    /// This is a sample #3 of reinforcement creation with Tekla.Net API. In this sample #3
    /// we are implementing a Tekla Structures plug-in. Plug-in has its' own behavior and the main 
    /// difference compared to static applications is the fact that plug-in will have its' own UI in Tekla Structures
    /// and it can defined to be dependent on its' input. When ever the input is modified Tekla Structures will
    /// call the plug-in Run() method and this way the output objects of the plug-in will be modified 
    /// and updated to match with the modified input.
    /// 
    /// In this specific example the actual code inside Run() method is like in Sample #2 with a few additions 
    /// which are typical to plug-ins like default value handling. Also the management of number of bars at bottom/top
    /// has been added.
    /// 
    /// </summary>
public class StructuresData 
{
    [Tekla.Structures.Plugins.StructuresField("bottom_number")]
    public int BottomNumber;
    [Tekla.Structures.Plugins.StructuresField("top_number")]
    public int TopNumber;
}

    [Plugin("RebarPluginSample")]      // obligatory 
    [PluginUserInterface(RebarPluginSample.UserInterfaceDefinitions.dialog)]
    public class RebarPluginSample : PluginBase 
    {
        private StructuresData data;

        public RebarPluginSample(StructuresData data) 
        {
            this.data = data;
        }

        public override List<InputDefinition> DefineInput()   // this is called by TS when the command is started
        {
            Picker  picker = new Picker();
            List<InputDefinition> inputList = new List<InputDefinition>();

            ModelObject o1 = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);

            InputDefinition input1 = new InputDefinition(o1.Identifier);

            inputList.Add(input1);

            return inputList;
        }

        public override bool Run(List<InputDefinition> Input)  // this is called by TS when the component is created or modified
        {
            try
            {
                Model myModel = new Model();
                Identifier id = ((InputDefinition) Input[0]).GetInput() as Identifier;
                Part myPart = myModel.SelectModelObject(id) as Part;
                
                // we need to calculate final values for input properties which have default (=empty)
                // input values.
                if(IsDefaultValue(data.BottomNumber))
                        data.BottomNumber = 6;
                if(IsDefaultValue(data.TopNumber))
                    data.TopNumber = 2;

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

                // prepare input points for the "longitudinal rebars" component
                Point point1 = new Point(solid.MinimumPoint.X, solid.MinimumPoint.Y, solid.MaximumPoint.Z);
                Point point2 = new Point(solid.MaximumPoint.X, solid.MinimumPoint.Y, solid.MaximumPoint.Z);
                Point point3 = new Point(solid.MinimumPoint.X, solid.MinimumPoint.Y, solid.MinimumPoint.Z);

                // set up component input sequence
                ComponentInput input1 = new ComponentInput();
                input1.AddInputObject(myPart);
                input1.AddTwoInputPositions(point1, point2);
                input1.AddOneInputPosition(point3);

                // Add the input for component 
                component1.SetComponentInput(input1);

                // mamange the settings i.e. load standard defaults and set the few important attribute values explicitely
                component1.LoadAttributesFromFile("standard");
                component1.SetAttribute("bar1_no", data.BottomNumber);  // number of bars
                component1.SetAttribute("cc_side", 45.0);   // cover thickness at side
                component1.SetAttribute("cc_bottom", 45.0); // cover thickness at bottom

                // insert new component instance into model
                component1.Insert();

                // resuse the same component object to add new instance at top of beam
                        
                // modify input points
                point1.Y = point2.Y = point3.Y = solid.MaximumPoint.Y;  // "move" points to top of beam

                // modify neccesary settings & insert compoent instance into model
                component1.SetAttribute("bar1_no",data.TopNumber);  
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
            catch
            {

                 
            }

            return true;
        }

        public class UserInterfaceDefinitions   
            // this is a nested class conatining the UI definition for plug-in component
            // the format for UI definitionm is same as for custom components
        {
            public const string dialog = 
                @"page(""TeklaStructures"","""")
                {
                    plugin(1, ""RebarPluginSample"")
                    {
                        tab_page("""", ""Parameters 1"", 1)
                        {
                            parameter(""Number of bottom bars"", ""bottom_number"", integer, number, 1)
                            parameter(""Number of top bars"", ""top_number"", integer, number, 4)
                        }
                        depend(2)
                        modify(1)
                        draw(1, 100.0, 100.0, 0.0, 0.0)
                   }
                }";
        }
    }
}

