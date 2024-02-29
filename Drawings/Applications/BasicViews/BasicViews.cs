using System;
using System.Collections;
using System.Windows.Forms;

using Tekla.Structures.Model;
using Tekla.Structures.Drawing;
using TSMUI = Tekla.Structures.Model.UI;

namespace DrawingTestApplication1
{
    public partial class BasicViews : Form
    {
        public BasicViews()
        {
            InitializeComponent();
        }

        private Model Model = new Model();
        private DrawingHandler DrawingHandler = new DrawingHandler();

        #region Coordinate system calculations

        readonly Tekla.Structures.Geometry3d.Vector UpDirection = new Tekla.Structures.Geometry3d.Vector(0.0, 0.0, 1.0);
        /// <summary>
        /// Gets part default front view coordinate system
        /// Gets coordinate system as it is defined in the TS core for part/component basic views, which is different than in singlepart/assembly drawings.
        /// </summary>
        /// <param name="objectCoordinateSystem"></param>
        /// <returns></returns>
        private Tekla.Structures.Geometry3d.CoordinateSystem GetBasicViewsCoordinateSystemForFrontView(Tekla.Structures.Geometry3d.CoordinateSystem objectCoordinateSystem)
        {
            Tekla.Structures.Geometry3d.CoordinateSystem result = new Tekla.Structures.Geometry3d.CoordinateSystem();

            result.Origin = new Tekla.Structures.Geometry3d.Point(objectCoordinateSystem.Origin);
            result.AxisX = new Tekla.Structures.Geometry3d.Vector(objectCoordinateSystem.AxisX) * -1.0;
            result.AxisY = new Tekla.Structures.Geometry3d.Vector(objectCoordinateSystem.AxisY);
            
            Tekla.Structures.Geometry3d.Vector tempVector = (result.AxisX.Cross(UpDirection));
            
            if(tempVector == new Tekla.Structures.Geometry3d.Vector())
                tempVector = (objectCoordinateSystem.AxisY.Cross(UpDirection));

            result.AxisX = tempVector.Cross(UpDirection).GetNormal();
            result.AxisY = UpDirection.GetNormal();

            return result;
        }
        
        /// <summary>
        /// Gets part default top view coordinate system
        /// Gets coordinate system as it is defined in the TS core for part/component basic views, which is different than in singlepart/assembly drawings.
        /// </summary>
        /// <param name="objectCoordinateSystem"></param>
        /// <returns></returns>
        private Tekla.Structures.Geometry3d.CoordinateSystem GetBasicViewsCoordinateSystemForTopView(Tekla.Structures.Geometry3d.CoordinateSystem objectCoordinateSystem)
        {
            Tekla.Structures.Geometry3d.CoordinateSystem result = new Tekla.Structures.Geometry3d.CoordinateSystem();

            result.Origin = new Tekla.Structures.Geometry3d.Point(objectCoordinateSystem.Origin);
            result.AxisX = new Tekla.Structures.Geometry3d.Vector(objectCoordinateSystem.AxisX) * -1.0;
            result.AxisY = new Tekla.Structures.Geometry3d.Vector(objectCoordinateSystem.AxisY);
            
            Tekla.Structures.Geometry3d.Vector tempVector = (result.AxisX.Cross(UpDirection));

            if(tempVector == new Tekla.Structures.Geometry3d.Vector())
                tempVector = (objectCoordinateSystem.AxisY.Cross(UpDirection));

            result.AxisX = tempVector.Cross(UpDirection);
            result.AxisY = tempVector;

            return result;
        }

        /// <summary>
        /// Gets part default end view coordinate system
        /// Gets coordinate system as it is defined in the TS core for part/component basic views, which is different than in singlepart/assembly drawings.
        /// </summary>
        /// <param name="objectCoordinateSystem"></param>
        /// <returns></returns>
        private Tekla.Structures.Geometry3d.CoordinateSystem GetBasicViewsCoordinateSystemForEndView(Tekla.Structures.Geometry3d.CoordinateSystem objectCoordinateSystem)
        {
            Tekla.Structures.Geometry3d.CoordinateSystem result = new Tekla.Structures.Geometry3d.CoordinateSystem();

            result.Origin = new Tekla.Structures.Geometry3d.Point(objectCoordinateSystem.Origin);
            result.AxisX = new Tekla.Structures.Geometry3d.Vector(objectCoordinateSystem.AxisX) * -1.0;
            result.AxisY = new Tekla.Structures.Geometry3d.Vector(objectCoordinateSystem.AxisY);
            
            Tekla.Structures.Geometry3d.Vector tempVector = (result.AxisX.Cross(UpDirection));

            if(tempVector == new Tekla.Structures.Geometry3d.Vector())
                tempVector = (objectCoordinateSystem.AxisY.Cross(UpDirection));

            result.AxisX = tempVector;
            result.AxisY = UpDirection;

            return result;
        }

        #endregion

        /// <summary>
        /// Creates the basic views
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Create_click(object sender, EventArgs e)
        {
            TransformationPlane current = Model.GetWorkPlaneHandler().GetCurrentTransformationPlane(); // We use global transformation

            try
            {
                Model.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane()); // We use global transformation
                ModelObjectEnumerator selectedModelObjects = new TSMUI.ModelObjectSelector().GetSelectedObjects();

                GADrawing MyDrawing = null;

                while (selectedModelObjects.MoveNext())
                {
                    Tekla.Structures.Geometry3d.CoordinateSystem ModelObjectCoordSys;

                    string ModelObjectName;
                    string DrawingName = "Part basic views" + (selectedModelObjects.Current as Tekla.Structures.Model.ModelObject).Identifier;

                    GetCoordinateSystemAndNameOfSelectedObject(selectedModelObjects, out ModelObjectCoordSys, out ModelObjectName);

                    // Creates new empty genaral arrangement drawing
                    MyDrawing = new GADrawing(DrawingName, "standard");
                    MyDrawing.Insert();

                    if (openDrawings.Checked)
                        DrawingHandler.SetActiveDrawing(MyDrawing, true); // Open drawing in editor
                    else
                        DrawingHandler.SetActiveDrawing(MyDrawing, false); // Open drawing in invisible mode. When drawing is opened in invisible mode, it must always be saved and closed.

                    // Handle different model object types

                    ArrayList Parts = new ArrayList();

                    if (selectedModelObjects.Current is Tekla.Structures.Model.Part)
                        Parts.Add(selectedModelObjects.Current.Identifier);
                    else if (selectedModelObjects.Current is Tekla.Structures.Model.Assembly)
                        Parts = GetAssemblyParts(selectedModelObjects.Current as Tekla.Structures.Model.Assembly);
                    else if (selectedModelObjects.Current is Tekla.Structures.Model.BaseComponent)
                        Parts = GetComponentParts(selectedModelObjects.Current as Tekla.Structures.Model.BaseComponent);
                    else if (selectedModelObjects.Current is Tekla.Structures.Model.Task)
                        Parts = GetTaskParts(selectedModelObjects.Current as Tekla.Structures.Model.Task);

                    CreateViews(ModelObjectCoordSys, ModelObjectName, MyDrawing, Parts);

                    MyDrawing.PlaceViews();

                    DrawingHandler.CloseActiveDrawing(true); // Save and close the active drawing
                }

                if (MyDrawing != null && openDrawings.Checked)
                    DrawingHandler.SetActiveDrawing(MyDrawing);

                Model.GetWorkPlaneHandler().SetCurrentTransformationPlane(current); // return original transformation
            }
            catch (Exception exception)
            {
                Model.GetWorkPlaneHandler().SetCurrentTransformationPlane(current); // return original transformation
                MessageBox.Show(exception.ToString());
            }


        }

        /// <summary>
        /// Gets coordinate system of selected object
        /// Different model objects have different way of getting a proper coordinate system, eg. for Assemblies the main part coordinate system is used, and task has no coordinate system
        /// </summary>
        /// <param name="SelectedModelObjects"></param>
        /// <param name="ModelObjectCoordSys"></param>
        /// <param name="ModelObjectName"></param>
        private static void GetCoordinateSystemAndNameOfSelectedObject(ModelObjectEnumerator SelectedModelObjects, out Tekla.Structures.Geometry3d.CoordinateSystem ModelObjectCoordSys, out string ModelObjectName)
        {
            if(SelectedModelObjects.Current is Tekla.Structures.Model.Part)
            {
                ModelObjectCoordSys = (SelectedModelObjects.Current as Tekla.Structures.Model.Part).GetCoordinateSystem();
                ModelObjectName = (SelectedModelObjects.Current as Tekla.Structures.Model.Part).GetPartMark();
            }
            else if(SelectedModelObjects.Current is Tekla.Structures.Model.Assembly)
            {
                ModelObjectCoordSys = (SelectedModelObjects.Current as Tekla.Structures.Model.Assembly).GetMainPart().GetCoordinateSystem();
                ModelObjectName = (SelectedModelObjects.Current as Tekla.Structures.Model.Assembly).AssemblyNumber.Prefix + (SelectedModelObjects.Current as Tekla.Structures.Model.Assembly).AssemblyNumber.StartNumber;
            }
            else if(SelectedModelObjects.Current is Tekla.Structures.Model.BaseComponent)
            {
                ModelObjectCoordSys = (SelectedModelObjects.Current as Tekla.Structures.Model.BaseComponent).GetCoordinateSystem();
                ModelObjectName = (SelectedModelObjects.Current as Tekla.Structures.Model.BaseComponent).Name;
            }
            else if(SelectedModelObjects.Current is Tekla.Structures.Model.Task)
            {
                ModelObjectCoordSys = new Tekla.Structures.Geometry3d.CoordinateSystem();
                ModelObjectName = (SelectedModelObjects.Current as Tekla.Structures.Model.Task).Name;
            }
            else
            {
                ModelObjectCoordSys = new Tekla.Structures.Geometry3d.CoordinateSystem();
                ModelObjectName = "";
            }
        }

        #region Model object child part fetching
        /// <summary>
        /// Gets list of assembly parts 
        /// </summary>
        /// <param name="SelectedModelObjects"></param>
        /// <returns></returns>
        private static ArrayList GetAssemblyParts(Assembly assembly)
        {
            ArrayList Parts = new ArrayList();
            IEnumerator AssemblyChildren = (assembly).GetSecondaries().GetEnumerator();

            Parts.Add((assembly).GetMainPart().Identifier);

            while(AssemblyChildren.MoveNext())
                Parts.Add((AssemblyChildren.Current as Tekla.Structures.Model.ModelObject).Identifier);
            
            return Parts;
        }

        /// <summary>
        /// Gets list of component parts
        /// </summary>
        /// <param name="SelectedModelObjects"></param>
        /// <returns></returns>
        private static ArrayList GetComponentParts(BaseComponent component)
        {
            ArrayList Parts = new ArrayList();
            IEnumerator myChildren = component.GetChildren();

            while(myChildren.MoveNext())
                Parts.Add((myChildren.Current as Tekla.Structures.Model.ModelObject).Identifier);

            return Parts;
        }

        /// <summary>
        /// Gets list of task parts
        /// </summary>
        /// <param name="TaskMembers"></param>
        /// <returns></returns>
        private static ArrayList GetTaskParts(Task task)
        {
            ArrayList Parts = new ArrayList();

            ModelObjectEnumerator myMembers = task.GetChildren();
            
            while(myMembers.MoveNext())
            {
                if(myMembers.Current is Tekla.Structures.Model.Task)
                    Parts.AddRange(GetTaskParts(myMembers.Current as Tekla.Structures.Model.Task));
                else if(myMembers.Current is Tekla.Structures.Model.Part)
                    Parts.Add(myMembers.Current.Identifier);
            }

            return Parts;
        }

        #endregion
        
        /// <summary>
        /// Create all basic views
        /// </summary>
        /// <param name="ModelObjectCoordSys"></param>
        /// <param name="ModelObjectName"></param>
        /// <param name="MyDrawing"></param>
        /// <param name="Parts"></param>
        private void CreateViews(Tekla.Structures.Geometry3d.CoordinateSystem ModelObjectCoordSys, string ModelObjectName, GADrawing MyDrawing, ArrayList Parts)
        {
            if(createFrontView.Checked)
                AddView("Front view of " + ModelObjectName, MyDrawing, Parts, GetBasicViewsCoordinateSystemForFrontView(ModelObjectCoordSys));

            if(createTopView.Checked)
                AddView("Top view of " + ModelObjectName, MyDrawing, Parts, GetBasicViewsCoordinateSystemForTopView(ModelObjectCoordSys));

            if(createEndView.Checked)
                AddView("End view of " + ModelObjectName, MyDrawing, Parts, GetBasicViewsCoordinateSystemForEndView(ModelObjectCoordSys));

            if(create3dView.Checked)
                AddRotatedView("3d view of " + ModelObjectName, MyDrawing, Parts, GetBasicViewsCoordinateSystemForFrontView(ModelObjectCoordSys));
        }     

        /// <summary>
        /// Add one basic view
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="MyDrawing"></param>
        /// <param name="Parts"></param>
        /// <param name="CoordinateSystem"></param>
        private void AddView(String Name, Drawing MyDrawing, ArrayList Parts, Tekla.Structures.Geometry3d.CoordinateSystem CoordinateSystem)
        {
            Tekla.Structures.Drawing.View MyView = new Tekla.Structures.Drawing.View(MyDrawing.GetSheet(),
                                                                                     CoordinateSystem,
                                                                                     CoordinateSystem,
                                                                                     Parts);

            MyView.Name = Name;
            MyView.Insert();
       }
   
        /// <summary>
        /// Add rotated view
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="MyDrawing"></param>
        /// <param name="Parts"></param>
        /// <param name="CoordinateSystem"></param>
        private void AddRotatedView(String Name, Drawing MyDrawing, ArrayList Parts, Tekla.Structures.Geometry3d.CoordinateSystem CoordinateSystem)
        {
            Tekla.Structures.Geometry3d.CoordinateSystem displayCoordinateSystem = new Tekla.Structures.Geometry3d.CoordinateSystem();

            Tekla.Structures.Geometry3d.Matrix RotationAroundX = Tekla.Structures.Geometry3d.MatrixFactory.Rotate(20.0 * Math.PI * 2.0 / 360.0, CoordinateSystem.AxisX);
            Tekla.Structures.Geometry3d.Matrix RotationAroundZ = Tekla.Structures.Geometry3d.MatrixFactory.Rotate(30.0 * Math.PI * 2.0 / 360.0, CoordinateSystem.AxisY);

            Tekla.Structures.Geometry3d.Matrix Rotation = RotationAroundX * RotationAroundZ;

            displayCoordinateSystem.AxisX = new Tekla.Structures.Geometry3d.Vector(Rotation.Transform(new Tekla.Structures.Geometry3d.Point(CoordinateSystem.AxisX)));
            displayCoordinateSystem.AxisY = new Tekla.Structures.Geometry3d.Vector(Rotation.Transform(new Tekla.Structures.Geometry3d.Point(CoordinateSystem.AxisY)));
            
            Tekla.Structures.Drawing.View FrontView = new Tekla.Structures.Drawing.View(MyDrawing.GetSheet(),
                                                                                        CoordinateSystem,
                                                                                        displayCoordinateSystem,
                                                                                        Parts);
           
            FrontView.Name = Name;
            FrontView.Insert();
       }
   }
}