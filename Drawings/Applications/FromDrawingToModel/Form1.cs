using System;
using System.Drawing;
using System.Windows.Forms;
using Tekla.Structures.Drawing;
using TSD = Tekla.Structures.Drawing;
using Tekla.Structures.Drawing.UI;
using Tekla.Structures.Model;
//using ModelObject=Tekla.Structures.Model.ModelObject;
using TSM = Tekla.Structures.Model;

namespace FromDrawingToModel
{
    public partial class Form1 : Form
    {
        private DrawingHandler _drawingHandler;
        private Model _model;
        private Drawing _drawing;

        public Form1()
        {
            _drawingHandler = new DrawingHandler();
            _model = new Model();

            if(_model.GetConnectionStatus() && 
                _drawingHandler.GetConnectionStatus())
            {
                InitializeComponent();
            }
            else
                MessageBox.Show("Tekla Structures must be opened!");
        }

        //Pick a part from the drawing, to get its information
        //from the model
        private void PickObjectInDrawing_Click(object sender, EventArgs e)
        {
            try
            {
                _drawing = _drawingHandler.GetActiveDrawing();
                //Checks if any drawing is open
                if(_drawing != null)
                {
                    DrawingObject pickedObject;
                    ViewBase pickedView;
                    Tekla.Structures.Geometry3d.Point pickedPoint;

                    //Pick a part in the model 
                    Picker myPicker = _drawingHandler.GetPicker();
                    myPicker.PickObject("Pick a model object in the drawing", out pickedObject, out pickedView, out pickedPoint);

                    GetInfoFromDrawing(pickedObject);
                }
                else
                {
                    MessageBox.Show("A drawing must be opened in Tekla Structures model!");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        //This method gets the pciked object ID and selecs it in the model, showing
        //some of its information in the form
        private void GetInfoFromDrawing(DrawingObject pickedObject)
        {
            modelObjectTextBox.Clear();

            if(pickedObject != null)
            {
                TSD.ModelObject modelObjectInDrawing = pickedObject as TSD.ModelObject;
                if(modelObjectInDrawing != null)
                {
                    TSM.ModelObject modelObjectInModel = _model.SelectModelObject(modelObjectInDrawing.ModelIdentifier);
                    if(modelObjectInModel is TSM.Part)
                    {
                        Beam beam = modelObjectInModel as Beam;
                        if (beam != null)
                        {
                            GetBeamInfo(beam);
                        }
                        PolyBeam polyBeam = modelObjectInModel as PolyBeam;
                        if (polyBeam != null)
                        {
                            GetPolyBeamInfo(polyBeam);
                        }
                        ContourPlate contourPlate = modelObjectInModel as ContourPlate;
                        if (contourPlate != null)
                        {
                            GetContourPlateInfo(contourPlate);
                        }
                    }
                }
            }
        }

        private void GetBeamInfo(Beam beam)
        {
            modelObjectTextBox.Text = TSM.ModelObject.ModelObjectEnum.BEAM.ToString() + Environment.NewLine +
                "Name: " + beam.Name + Environment.NewLine +
                "Id: " + beam.Identifier.ID.ToString() + Environment.NewLine + 
                "Material: " + beam.Material.MaterialString + Environment.NewLine + 
                "Profile: " + beam.Profile.ProfileString + Environment.NewLine  + 
                "Start point: " + beam.StartPoint.ToString() + Environment.NewLine  + 
                "End point: " + beam.EndPoint.ToString() + Environment.NewLine  + 
                "Class: " + beam.Class + Environment.NewLine  + 
                "Finish: " + beam.Finish + Environment.NewLine  + 
                "Position depth: " + beam.Position.Depth.ToString()  + Environment.NewLine  +
                "Position plane: " + beam.Position.Plane.ToString() + Environment.NewLine +
                "Position rotation: " + beam.Position.Rotation.ToString() + Environment.NewLine + 
                "Father assembly: " + beam.GetAssembly().Name.ToString();
        }

        private void GetPolyBeamInfo(PolyBeam polyBeam)
        {
            modelObjectTextBox.Text = TSM.ModelObject.ModelObjectEnum.POLYBEAM.ToString() + Environment.NewLine +
                "Name: " + polyBeam.Name + Environment.NewLine +
                "Id: " + polyBeam.Identifier.ID.ToString() + Environment.NewLine + 
                "Material: " + polyBeam.Material.MaterialString + Environment.NewLine +
                "Profile: " + polyBeam.Profile.ProfileString + Environment.NewLine +
                "Contour points: " + polyBeam.Contour.ContourPoints.ToString() + Environment.NewLine +
                "Class: " + polyBeam.Class + Environment.NewLine +
                "Finish: " + polyBeam.Finish + Environment.NewLine +
                "Position depth: " + polyBeam.Position.Depth.ToString() + Environment.NewLine +
                "Position plane: " + polyBeam.Position.Plane.ToString() + Environment.NewLine +
                "Position rotation: " + polyBeam.Position.Rotation.ToString() + Environment.NewLine +
                "Father assembly: " + polyBeam.GetAssembly().Name.ToString();
        }

        private void GetContourPlateInfo(ContourPlate contourPlate)
        {
            modelObjectTextBox.Text = TSM.ModelObject.ModelObjectEnum.POLYBEAM.ToString() + Environment.NewLine +
                "Name: " + contourPlate.Name + Environment.NewLine +
                "Id: " + contourPlate.Identifier.ID.ToString() + Environment.NewLine +
                "Material: " + contourPlate.Material.MaterialString + Environment.NewLine +
                "Profile: " + contourPlate.Profile.ProfileString + Environment.NewLine +
                "Contour points: " + contourPlate.Contour.ContourPoints.ToString() + Environment.NewLine +
                "Class: " + contourPlate.Class + Environment.NewLine +
                "Finish: " + contourPlate.Finish + Environment.NewLine +
                "Position depth: " + contourPlate.Position.Depth.ToString() + Environment.NewLine +
                "Position plane: " + contourPlate.Position.Plane.ToString() + Environment.NewLine +
                "Position rotation: " + contourPlate.Position.Rotation.ToString() + Environment.NewLine +
                "Father assembly: " + contourPlate.GetAssembly().Name.ToString();
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
    }
}
