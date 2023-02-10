using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TS = Tekla.Structures.Geometry3d;
using Tekla.Structures;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Solid;
using TSM = Tekla.Structures.Model;
using Tekla.Structures.Model;
using Tekla.Structures.ModelInternal;

namespace ObjectTestApplication
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.StatusBar statusBar1;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.TextBox textBox1;
        private static TSM.Model Model = new TSM.Model();
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button1;
        private static ArrayList ObjectList = new ArrayList();

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            if (!Model.GetConnectionStatus())
            {
                WriteLine("Failed to connect to TS!");
                Environment.Exit(-1);
            }
            TSM.ModelInfo Info = Model.GetInfo();
            TeklaStructuresInfo.GetCurrentProgramVersion();
            this.Text = "ObjectTest with " + Info.ModelName;

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 523);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(568, 25);
            this.statusBar1.TabIndex = 1;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "Objecttest started..";
            this.statusBarPanel1.Width = 447;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.statusBarPanel2.Name = "statusBarPanel2";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Location = new System.Drawing.Point(0, 207);
            this.textBox1.MaxLength = 2147483647;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(568, 316);
            this.textBox1.TabIndex = 5;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(416, 28);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(144, 72);
            this.button6.TabIndex = 7;
            this.button6.Text = "Run Selected Tests";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.ColumnWidth = 140;
            this.checkedListBox1.Items.AddRange(new object[] {
            "All",
            "BeamTest",
            "PolyBeamTest",
            "ContourPlateTest",
            "BooleanTests",
            "RebarTests",
            "BoltTests",
            "WeldTest",
            "CastUnitTest",
            "AssemblyTest",
            "LoadTests",
            "PlaneTests",
            "SurfaceTreatmentTest",
            "EnumerationTest",
            "SolidTests",
            "ComponentTests"});
            this.checkedListBox1.Location = new System.Drawing.Point(19, 28);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(346, 157);
            this.checkedListBox1.TabIndex = 9;
            this.checkedListBox1.ThreeDCheckBoxes = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(416, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 65);
            this.button1.TabIndex = 10;
            this.button1.Text = "Clear Model";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(568, 548);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.statusBar1);
            this.Name = "Form1";
            this.Text = "Object Test Application for Tekla Open API";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

        private void WriteLine(string text)
        {
            if (textBox1.TextLength + text.Length < textBox1.MaxLength)
            {
                textBox1.AppendText(text);
                textBox1.AppendText("\r\n");
            }
            statusBarPanel1.Text = text;
            statusBarPanel2.Text = ObjectList.Count.ToString() + " Objects Inserted";
        }

        private void BeamTest()
        {
            double Test = 0;
            WriteLine("Starting BeamTest...");
            TS.Point point = new TS.Point(0, 0, 0);
            TS.Point point2 = new TS.Point(1000, 0, 0);

            Beam Beam = new Beam(point, point2);

            Beam.Profile.ProfileString = "L60*6";
            Beam.Material.MaterialString = "Steel_Undefined";
            Beam.Finish = "PAINT";

            if (!Beam.Insert())
            {
                WriteLine("BeamTest failed - unable to create beam");
                MessageBox.Show("Insert failed!");
                return;
            }
            else
            {
                ObjectList.Add(Beam);
            }

            if (Beam.GetReportProperty("PROFILE.FLANGE_THICKNESS_1", ref Test))
                WriteLine("PROFILE.FLANGE_THICKNESS_1 returned " + Test.ToString());

            if (Beam.GetReportProperty("PROFILE.FLANGE_THICKNESS_2", ref Test))
                WriteLine("PROFILE.FLANGE_THICKNESS_2 returned " + Test.ToString());

            WriteLine(Beam.Identifier.ID + " Inserted");

            if (!Beam.Select())
                MessageBox.Show("Select failed!");

            Beam.StartPoint.Translate(0, 1000, 0);
            Beam.EndPoint.Translate(0, 1000, 0);

            if (!Beam.Modify())
                MessageBox.Show("Modify failed!");

            WriteLine("BeamTest complete!");
        }

        private void PolyBeamTest()
        {

            WriteLine("PolyBeamTest complete!");

            ContourPoint point = new ContourPoint(new TS.Point(0, 2000, 0), null);
            ContourPoint point2 = new ContourPoint(new TS.Point(2000, 2000, 0), new Chamfer(0, 0, Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT));
            ContourPoint point3 = new ContourPoint(new TS.Point(0, 4000, 0), null);

            PolyBeam PolyBeam = new PolyBeam();

            PolyBeam.AddContourPoint(point);
            PolyBeam.AddContourPoint(point2);
            PolyBeam.AddContourPoint(point3);

            PolyBeam.Profile.ProfileString = "HI400-15-20*400";
            PolyBeam.Material.MaterialString = "Steel_Undefined";
            PolyBeam.Finish = "PAINT";

            if (!PolyBeam.Insert())
            {
                WriteLine("PolyBeamTest failed - unable to create polybeam");
                MessageBox.Show("Insert failed!");
                return;
            }
            else
            {
                ObjectList.Add(PolyBeam);
            }

            if (!PolyBeam.Select())
                MessageBox.Show("Select failed!");

            WriteLine("PolyBeamTest complete!");
        }

        private void ContourPlateTest()
        {
            WriteLine("Starting ContourPlateTest...");

            ContourPoint point = new ContourPoint(new TS.Point(0, 4000, 0), null);
            ContourPoint point2 = new ContourPoint(new TS.Point(2000, 4000, 0), new Chamfer(0, 0, Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT));
            ContourPoint point3 = new ContourPoint(new TS.Point(0, 6000, 0), null);

            point2.Chamfer.DZ1 = 2500;
            point2.Chamfer.DZ2 = 300;

            ContourPlate CP = new ContourPlate();

            CP.AddContourPoint(point);
            CP.AddContourPoint(point2);
            CP.AddContourPoint(point3);
            CP.Profile.ProfileString = "PL10";
            CP.Finish = "FOO";
            CP.Material.MaterialString = "Concrete_Undefined";
            CP.Name = "FOOSLAB";

            if (!CP.Insert())
            {
                WriteLine("PolyBeamTest failed - unable to create polybeam");
                MessageBox.Show("Insert failed!");
                return;
            }
            else
            {
                ObjectList.Add(CP);
            }

            if (!CP.Select())
                MessageBox.Show("Select failed!");

            if (!CP.Modify())
                MessageBox.Show("Modify failed!");

            WriteLine(CP.Identifier.ID + " Inserted");
            WriteLine("ContourPlateTest complete!");
        }

        private string BooleanPartTest()
        {
            WriteLine("Starting BooleanPartTest...");

            TS.Point point = new TS.Point(0, 7000, 0);
            TS.Point point2 = new TS.Point(1000, 7000, 0);

            Beam Beam1 = new Beam();
            Beam1.StartPoint = point;
            Beam1.EndPoint = point2;
            Beam1.Profile.ProfileString = "HI400-15-20*400";
            Beam1.Material.MaterialString = "Steel_Undefined";
            Beam1.Finish = "PAINT";

            if (!Beam1.Insert())
            {
                WriteLine("BooleanPartTest failed - unable to create beam1");
                MessageBox.Show("Insert failed!");
                return string.Empty;
            }
            else
            {
                ObjectList.Add(Beam1);
            }

            Beam Beam2 = new Beam();
            Beam2.Profile.ProfileString = "HI100-10-10*100";
            Beam2.Material.MaterialString = "Steel_Undefined";
            Beam2.StartPoint = new TS.Point(500, 6000, 0);
            Beam2.EndPoint = new TS.Point(500, 8000, 0);
            // set Class for operative part
            Beam2.Class = BooleanPart.BooleanOperativeClassName;

            if (!Beam2.Insert())
            {
                WriteLine("BooleanPartTest failed - unable to create beam2");
                MessageBox.Show("Insert failed!");
                return string.Empty;
            }

            BooleanPart Beam = new BooleanPart();
            Beam.Father = Beam1;
            Beam.SetOperativePart(Beam2);

            if (!Beam.Insert())
            {
                WriteLine("BooleanPartTest failed - unable to create boolean part");
                MessageBox.Show("Insert failed!");
                return string.Empty;
            }
            else
            {
                ObjectList.Add(Beam);
            }

            Beam2.Delete();

            if (!Beam.Select())
                MessageBox.Show("Select failed!");

            Beam.OperativePart.Profile.ProfileString = "HI200-15-10*200";

            if (!Beam.Modify())
                MessageBox.Show("Modify failed!");

            WriteLine("BooleanPartTest complete!");
            return Beam.Identifier.ID.ToString();
        }

        private string CutTest()
        {
            WriteLine("Starting CutTest...");

            TS.Point point = new TS.Point(5000, 5000, 0);
            TS.Point point2 = new TS.Point(6000, 5000, 0);

            Beam Beam = new Beam();
            Beam.StartPoint = point;
            Beam.EndPoint = point2;
            Beam.Profile.ProfileString = "HI400-15-20*400";
            Beam.Material.MaterialString = "Steel_Undefined";
            Beam.Finish = "PAINT";

            if (!Beam.Insert())
            {
                WriteLine("CutTest failed - unable to create beam");
                MessageBox.Show("Insert failed!");
                return string.Empty;
            }
            else
            {
                ObjectList.Add(Beam);
            }

            CutPlane Cut = new CutPlane();
            Cut.Father = Beam;
            Cut.Plane.Origin = new TS.Point(5500, 0, 0);
            Cut.Plane.AxisX = new Vector(0, 1.0, 0);
            Cut.Plane.AxisY = new Vector(0, 0, 1.0);

            if (!Cut.Insert())
            {
                WriteLine("CutTest failed - unable to create cut");
                MessageBox.Show("Insert failed!");
                return string.Empty;
            }
            else
            {
                ObjectList.Add(Cut);
            }

            if (!Cut.Select())
                MessageBox.Show("Select failed!");

            Cut.Plane.AxisX = new Vector(0, 500, 0);
            Cut.Plane.AxisY = new Vector(0, 0, 5000);

            if (!Cut.Modify())
                MessageBox.Show("Modify failed!");

            WriteLine("CutTest complete!");
            return Cut.Identifier.ID.ToString();
        }

        private string FittingTest()
        {
            WriteLine("Starting FittingTest...");

            TS.Point point = new TS.Point(5000, 6000, 0);
            TS.Point point2 = new TS.Point(6000, 6000, 0);

            Beam Beam = new Beam();
            Beam.StartPoint = point;
            Beam.EndPoint = point2;
            Beam.Profile.ProfileString = "HI400-15-20*400";
            Beam.Material.MaterialString = "Steel_Undefined";
            Beam.Finish = "PAINT";

            if (!Beam.Insert())
            {
                WriteLine("FittingTest failed - unable to create beam");
                MessageBox.Show("Insert failed!");
                return string.Empty;
            }
            else
            {
                ObjectList.Add(Beam);
            }

            Fitting Fitting = new Fitting();
            Fitting.Father = Beam;
            Fitting.Plane.Origin.X = 5800;
            Fitting.Plane.Origin.Y = 5800;
            Fitting.Plane.Origin.Z = -500;
            Fitting.Plane.AxisX = new Vector(0, 6000, 1000);
            Fitting.Plane.AxisY = new Vector(0, 0, 6000);

            if (!Fitting.Insert())
            {
                WriteLine("FittingTest failed - unable to create fitting");
                MessageBox.Show("Insert failed!");
                return string.Empty;
            }
            else
            {
                ObjectList.Add(Fitting);
            }

            if (!Fitting.Select())
                MessageBox.Show("Select failed!");

            Fitting.Plane.AxisX = new Vector(0, 500, 0);
            Fitting.Plane.AxisY = new Vector(3000, 0, 4000);

            if (!Fitting.Modify())
                MessageBox.Show("Modify failed!");

            WriteLine("FittingTest complete!");
            return Fitting.Identifier.ID.ToString();
        }

        private void SingleRebarTest()
        {
            WriteLine("Starting the SingleRebarTest...");

            Beam Beam = new Beam(new TS.Point(5000, 7000, 0), new TS.Point(6000, 7000, 0));
            Beam.Profile.ProfileString = "250*250";
            Beam.Material.MaterialString = "Concrete_Undefined";
            Beam.Finish = "PAINT";

            if (!Beam.Insert())
            {
                WriteLine("SingleRebarTest failed - unable to create beam");
                MessageBox.Show("Insert beam failed!");
                return;
            }
            else
            {
                ObjectList.Add(Beam);
            }

            double MinimumY = Beam.GetSolid().MinimumPoint.Y;
            double MinimumX = Beam.GetSolid().MinimumPoint.X;
            double MinimumZ = Beam.GetSolid().MinimumPoint.Z;
            double MaximumY = Beam.GetSolid().MaximumPoint.Y;
            double MaximumX = Beam.GetSolid().MaximumPoint.X;
            double MaximumZ = Beam.GetSolid().MaximumPoint.Z;

            // 1st single 
            Polygon Polygon = new Polygon();
            Polygon.Points.Add(new TS.Point(MinimumX, MaximumY, MaximumZ));
            Polygon.Points.Add(new TS.Point(MaximumX, MaximumY, MaximumZ));

            SingleRebar SingleRebar = new SingleRebar();
            SingleRebar.Polygon = Polygon;
            SingleRebar.Father = Beam;
            SingleRebar.Name = "SingleRebar1";
            SingleRebar.Class = 9;
            SingleRebar.Size = "12";
            SingleRebar.NumberingSeries.StartNumber = 0;
            SingleRebar.NumberingSeries.Prefix = "Single 1";
            SingleRebar.Grade = "A500HW";
            SingleRebar.OnPlaneOffsets.Add(25.00);
            SingleRebar.FromPlaneOffset = 50;
            SingleRebar.StartHook.Angle = -90;
            SingleRebar.StartHook.Length = 10;
            SingleRebar.StartHook.Radius = 10;
            SingleRebar.StartHook.Shape = RebarHookData.RebarHookShapeEnum.CUSTOM_HOOK;
            SingleRebar.EndHook.Angle = 90;
            SingleRebar.EndHook.Length = 10;
            SingleRebar.EndHook.Radius = 10;
            SingleRebar.EndHook.Shape = RebarHookData.RebarHookShapeEnum.CUSTOM_HOOK;

            if (!SingleRebar.Insert())
            {
                WriteLine("SingleRebarTest failed - unable to create single rebar");
                MessageBox.Show("Insert single rebar failed!");
                return;
            }
            else
            {
                ObjectList.Add(SingleRebar);
            }

            WriteLine(SingleRebar.Identifier.ID.ToString());

            // 2nd single
            Polygon.Points.Clear();
            Polygon.Points.Add(new TS.Point(MinimumX, MinimumY, MaximumZ));
            Polygon.Points.Add(new TS.Point(MaximumX, MinimumY, MaximumZ));
            SingleRebar SingleRebar2 = new SingleRebar();
            SingleRebar2.Polygon = Polygon;
            SingleRebar2.Father = Beam;
            SingleRebar2.Name = "SingleRebar2";
            SingleRebar2.Class = 8;
            SingleRebar2.Size = "12";
            SingleRebar2.NumberingSeries.StartNumber = 0;
            SingleRebar2.NumberingSeries.Prefix = "Single 2";
            SingleRebar2.Grade = "A500HW";
            SingleRebar2.OnPlaneOffsets.Add(65.00);
            SingleRebar2.OnPlaneOffsets.Add(65.00);
            SingleRebar2.OnPlaneOffsets.Add(65.00);
            SingleRebar2.FromPlaneOffset = -30;
            SingleRebar2.StartPointOffsetType = Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;
            SingleRebar2.StartPointOffsetValue = 15;
            SingleRebar2.EndPointOffsetType = Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;
            SingleRebar2.EndPointOffsetValue = 15;
            SingleRebar2.StartHook.Angle = 50;
            SingleRebar2.StartHook.Length = 50;
            SingleRebar2.StartHook.Radius = 30;
            SingleRebar2.StartHook.Shape = RebarHookData.RebarHookShapeEnum.CUSTOM_HOOK;
            SingleRebar2.EndHook.Angle = 50;
            SingleRebar2.EndHook.Length = 50;
            SingleRebar2.EndHook.Radius = 30;
            SingleRebar2.EndHook.Shape = RebarHookData.RebarHookShapeEnum.CUSTOM_HOOK;

            if (!SingleRebar2.Insert())
            {
                WriteLine("SingleRebarTest failed - unable to create single rebar 2");
                MessageBox.Show("Insert single rebar 2 failed!");
                return;
            }
            else
            {
                ObjectList.Add(SingleRebar2);
            }

            WriteLine(SingleRebar2.Identifier.ID.ToString());

            if (!SingleRebar.Select())
                WriteLine("Select failed!");

            WriteLine(SingleRebar.Identifier.ID.ToString());

            SingleRebar.Class = 10;
            SingleRebar.Name = "Modified single 1";

            if (!SingleRebar.Modify())
                WriteLine("Modify failed!");

            WriteLine(SingleRebar.Identifier.ID.ToString());
            WriteLine("SingleRebarTest complete!");
        }

        private static bool CompareRebarGeometries(RebarGeometry G1, RebarGeometry G2)
        {
            ArrayList Points1 = G1.Shape.Points;
            ArrayList Points2 = G2.Shape.Points;

            bool Result = Points1.Count == Points2.Count;

            for (int ii = 0; ii < Points1.Count && Result; ii++)
            {
                TS.Point Point1 = Points1[ii] as TS.Point;
                TS.Point Point2 = Points2[ii] as TS.Point;

                Result = Point1 != null && Point2 != null &&
                        (Math.Abs(Point1.X - Point2.X) < Epsilon.Value) &&
                        (Math.Abs(Point1.Y - Point2.Y) < Epsilon.Value) &&
                        (Math.Abs(Point1.Z - Point2.Z) < Epsilon.Value);
            }

            return Result;
        }

        private static ContourPlate InsertPlate()
        {
            ContourPlate CP = new ContourPlate();

            ContourPoint Point1 = new ContourPoint(new TS.Point(0, 0, 0), null);
            ContourPoint Point2 = new ContourPoint(new TS.Point(7200, 0, 0), null);
            ContourPoint Point3 = new ContourPoint(new TS.Point(7200, 6000, 0), null);
            ContourPoint Point4 = new ContourPoint(new TS.Point(0, 6000, 0), null);
            CP.AddContourPoint(Point1);
            CP.AddContourPoint(Point2);
            CP.AddContourPoint(Point3);
            CP.AddContourPoint(Point4);
            CP.Profile.ProfileString = "PL200";
            CP.Material.MaterialString = "Concrete_Undefined";
            CP.Finish = "PAINT";

            if (!CP.Insert())
            {
                MessageBox.Show("Insert contour plate failed!");
                return null;
            }
            else
            {
                ObjectList.Add(CP);
            }

            return CP;
        }

        private void RebarGroupTest1()
        {
            WriteLine("Starting the first RebarGroupTest...");

            Beam Beam = new Beam(new TS.Point(5000, 8000, 0), new TS.Point(6000, 8000, 0));
            Beam.Profile.ProfileString = "250*250";
            Beam.Material.MaterialString = "Concrete_Undefined";
            Beam.Finish = "PAINT";
            if (!Beam.Insert())
            {
                WriteLine("RebarGroupTest1 failed - unable to create beam");
                MessageBox.Show("Insert beam failed!");
                return;
            }
            else
            {
                ObjectList.Add(Beam);
            }

            double MinimumX = Beam.GetSolid().MinimumPoint.X;
            double MinimumY = Beam.GetSolid().MinimumPoint.Y;
            double MinimumZ = Beam.GetSolid().MinimumPoint.Z;
            double MaximumX = Beam.GetSolid().MaximumPoint.X;
            double MaximumY = Beam.GetSolid().MaximumPoint.Y;
            double MaximumZ = Beam.GetSolid().MaximumPoint.Z;

            Polygon Polygon = new Polygon();
            Polygon.Points.Add(new TS.Point(MinimumX, MaximumY, MinimumZ));
            Polygon.Points.Add(new TS.Point(MinimumX, MinimumY, MinimumZ));
            Polygon.Points.Add(new TS.Point(MinimumX, MinimumY, MaximumZ));
            Polygon.Points.Add(new TS.Point(MinimumX, MaximumY, MaximumZ));

            Polygon Polygon2 = new Polygon();
            Polygon2.Points.Add(new TS.Point(MaximumX, MaximumY, MinimumZ));
            Polygon2.Points.Add(new TS.Point(MaximumX, MinimumY, MinimumZ));
            Polygon2.Points.Add(new TS.Point(MaximumX, MinimumY, MaximumZ));
            Polygon2.Points.Add(new TS.Point(MaximumX, MaximumY, MaximumZ));

            RebarGroup RebarGroup = new RebarGroup();
            RebarGroup.Polygons.Add(Polygon);
            RebarGroup.Polygons.Add(Polygon2);
            RebarGroup.RadiusValues.Add(40.0);
            RebarGroup.SpacingType = RebarGroup.RebarGroupSpacingTypeEnum.SPACING_TYPE_TARGET_SPACE;
            RebarGroup.Spacings.Add(30.0);
            RebarGroup.ExcludeType = RebarGroup.ExcludeTypeEnum.EXCLUDE_TYPE_BOTH;
            RebarGroup.Father = Beam;
            RebarGroup.Name = "RebarGroup";
            RebarGroup.Class = 3;
            RebarGroup.Size = "12";
            RebarGroup.NumberingSeries.StartNumber = 0;
            RebarGroup.NumberingSeries.Prefix = "Group";
            RebarGroup.Grade = "A500HW";
            RebarGroup.StartHook.Shape = RebarHookData.RebarHookShapeEnum.CUSTOM_HOOK;
            RebarGroup.StartHook.Angle = -90;
            RebarGroup.StartHook.Length = 3;
            RebarGroup.StartHook.Radius = 20;
            RebarGroup.EndHook.Shape = RebarHookData.RebarHookShapeEnum.CUSTOM_HOOK;
            RebarGroup.EndHook.Angle = -90;
            RebarGroup.EndHook.Length = 3;
            RebarGroup.EndHook.Radius = 20;
            RebarGroup.OnPlaneOffsets.Add(25.0);
            RebarGroup.OnPlaneOffsets.Add(10.0);
            RebarGroup.OnPlaneOffsets.Add(25.0);
            RebarGroup.StartPointOffsetType = Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;
            RebarGroup.StartPointOffsetValue = 20;
            RebarGroup.EndPointOffsetType = Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;
            RebarGroup.EndPointOffsetValue = 60;
            RebarGroup.FromPlaneOffset = 40;

            if (!RebarGroup.Insert())
            {
                WriteLine("RebarGroupTest1 failed - unable to create rebar group");
                MessageBox.Show("Cannot insert rebar group!");
                return;
            }
            else
            {
                ObjectList.Add(RebarGroup);
            }

            ArrayList InnerRebars = RebarGroup.GetRebarGeometries(false);
            RebarGroup.Name = "Modified Group 1";

            if (!RebarGroup.Modify())
                MessageBox.Show("Rebar group modify failed");

            WriteLine(RebarGroup.Identifier.ID.ToString());
            WriteLine("The first RebarGroupTest complete!");
        }

        private void RebarGroupTest2()
        {
            WriteLine("Starting the second RebarGroupTest...");

            Beam Beam = new Beam(new TS.Point(5000, 9000, 0), new TS.Point(6000, 9000, 0));
            Beam.Profile.ProfileString = "250*250";
            Beam.Material.MaterialString = "Concrete_Undefined";
            Beam.Finish = "PAINT";
            if (!Beam.Insert())
            {
                WriteLine("RebarGroupTest2 failed - unable to create beam");
                MessageBox.Show("Insert beam failed!");
                return;
            }
            else
            {
                ObjectList.Add(Beam);
            }

            double MinimumX = Beam.GetSolid().MinimumPoint.X;
            double MinimumY = Beam.GetSolid().MinimumPoint.Y;
            double MinimumZ = Beam.GetSolid().MinimumPoint.Z;
            double MaximumX = Beam.GetSolid().MaximumPoint.X;
            double MaximumY = Beam.GetSolid().MaximumPoint.Y;
            double MaximumZ = Beam.GetSolid().MaximumPoint.Z;

            Polygon Polygon = new Polygon();
            Polygon.Points.Add(new TS.Point(MinimumX, MaximumY, MinimumZ));
            Polygon.Points.Add(new TS.Point(MinimumX, MinimumY, MinimumZ));
            Polygon.Points.Add(new TS.Point(MinimumX, MinimumY, MaximumZ));
            Polygon.Points.Add(new TS.Point(MinimumX, MaximumY, MaximumZ));

            Polygon Polygon2 = new Polygon();
            Polygon2.Points.Add(new TS.Point(MaximumX - (MaximumX - MinimumX) / 2, MaximumY, MinimumZ));
            Polygon2.Points.Add(new TS.Point(MaximumX - (MaximumX - MinimumX) / 2, MinimumY, MinimumZ));
            Polygon2.Points.Add(new TS.Point(MaximumX - (MaximumX - MinimumX) / 2, MinimumY, MaximumZ));
            Polygon2.Points.Add(new TS.Point(MaximumX - (MaximumX - MinimumX) / 2, MaximumY, MaximumZ));

            Polygon Polygon3 = new Polygon();
            Polygon3.Points.Add(new TS.Point(MaximumX - 150, MaximumY, MinimumZ));
            Polygon3.Points.Add(new TS.Point(MaximumX - 150, MinimumY, MinimumZ));
            Polygon3.Points.Add(new TS.Point(MaximumX - 150, MinimumY, MaximumZ));
            Polygon3.Points.Add(new TS.Point(MaximumX - 150, MaximumY, MaximumZ));

            Polygon Polygon4 = new Polygon();
            Polygon4.Points.Add(new TS.Point(MaximumX, MaximumY, MinimumZ));
            Polygon4.Points.Add(new TS.Point(MaximumX, MinimumY, MinimumZ));
            Polygon4.Points.Add(new TS.Point(MaximumX, MinimumY, MaximumZ));
            Polygon4.Points.Add(new TS.Point(MaximumX, MaximumY, MaximumZ));

            RebarGroup RebarGroup = new RebarGroup();
            RebarGroup.Polygons.Add(Polygon);
            RebarGroup.Polygons.Add(Polygon2);
            RebarGroup.Polygons.Add(Polygon3);
            RebarGroup.Polygons.Add(Polygon4);
            RebarGroup.RadiusValues.Add(20.0);
            RebarGroup.SpacingType = RebarGroup.RebarGroupSpacingTypeEnum.SPACING_TYPE_TARGET_SPACE;
            RebarGroup.Spacings.Add(40.0);
            RebarGroup.ExcludeType = RebarGroup.ExcludeTypeEnum.EXCLUDE_TYPE_BOTH;
            RebarGroup.Father = Beam;
            RebarGroup.Name = "RebarGroup";
            RebarGroup.Class = 4;
            RebarGroup.Size = "12";
            RebarGroup.NumberingSeries.StartNumber = 0;
            RebarGroup.NumberingSeries.Prefix = "Group2";
            RebarGroup.Grade = "A500HW";
            RebarGroup.OnPlaneOffsets.Add(30.0);
            RebarGroup.StartPointOffsetType = Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;
            RebarGroup.StartPointOffsetValue = 50;
            RebarGroup.EndPointOffsetType = Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;
            RebarGroup.EndPointOffsetValue = 50;
            RebarGroup.FromPlaneOffset = 20;

            if (!RebarGroup.Insert())
            {
                WriteLine("RebarGroupTest2 failed - unable to create RebarGroup");
                MessageBox.Show("Cannot insert rebar group!");
                return;
            }
            else
            {
                ObjectList.Add(RebarGroup);
            }

            WriteLine(RebarGroup.Identifier.ID.ToString());

            RebarGroup.Name = "Modified Group 2";
            RebarGroup.SpacingType = RebarGroup.RebarGroupSpacingTypeEnum.SPACING_TYPE_EXACT_NUMBER;
            RebarGroup.Spacings.Clear();
            RebarGroup.Spacings.Add(20.0);
            if (!RebarGroup.Modify()) MessageBox.Show("Rebar group modify failed");

            ArrayList InnerRebars = RebarGroup.GetRebarGeometries(false);

            RebarGroup.Father = null;
            try
            {
                if (!RebarGroup.Modify()) WriteLine("Rebar group disconnected from father");
                WriteLine(RebarGroup.Identifier.ID.ToString());
            }
            catch 
            {
                WriteLine("Rebar group disconnected from father");
            }
            WriteLine("The second RebarGroupTest complete!");
        }

        private void RebarGroupTest3()
        {
            WriteLine("Starting the third RebarGroupTest...");

            TS.Point BeamPoint = new TS.Point(5000, 10000, 0);
            TS.Point BeamPoint2 = new TS.Point(6000, 10000, 0);

            Beam Beam = new Beam();
            Beam.StartPoint = BeamPoint;
            Beam.EndPoint = BeamPoint2;
            Beam.Profile.ProfileString = "250*250";
            Beam.Material.MaterialString = "C50/60";
            Beam.Finish = "PAINT";
            if (!Beam.Insert())
            {
                WriteLine("RebarGroupTest3 failed - unable to create beam");
                MessageBox.Show("Insert beam failed!");
                return;
            }
            else
            {
                ObjectList.Add(Beam);
            }

            double MinimumX = Beam.GetSolid().MinimumPoint.X;
            double MinimumY = Beam.GetSolid().MinimumPoint.Y;
            double MinimumZ = Beam.GetSolid().MinimumPoint.Z;
            double MaximumX = Beam.GetSolid().MaximumPoint.X;
            double MaximumY = Beam.GetSolid().MaximumPoint.Y;
            double MaximumZ = Beam.GetSolid().MaximumPoint.Z;

            Polygon Polygon = new Polygon();
            TS.Point PolygonPoint1 = new TS.Point();
            PolygonPoint1.X = MinimumX;
            PolygonPoint1.Y = MinimumY;
            PolygonPoint1.Z = MaximumZ;
            Polygon.Points.Add(PolygonPoint1);
            TS.Point PolygonPoint2 = new TS.Point();
            PolygonPoint2.X = MinimumX;
            PolygonPoint2.Y = MinimumY;
            PolygonPoint2.Z = MinimumZ;
            Polygon.Points.Add(PolygonPoint2);
            TS.Point PolygonPoint3 = new TS.Point();
            PolygonPoint3.X = MinimumX;
            PolygonPoint3.Y = MaximumY;
            PolygonPoint3.Z = MinimumZ;
            Polygon.Points.Add(PolygonPoint3);
            TS.Point PolygonPoint4 = new TS.Point();
            PolygonPoint4.X = MinimumX;
            PolygonPoint4.Y = MaximumY;
            PolygonPoint4.Z = MaximumZ;
            Polygon.Points.Add(PolygonPoint4);

            Polygon Polygon2 = new Polygon();
            PolygonPoint1 = new TS.Point();
            PolygonPoint1.X = MinimumX + (MaximumX - MinimumX) / 2;
            PolygonPoint1.Y = MinimumY;
            PolygonPoint1.Z = MaximumZ - 100;
            Polygon2.Points.Add(PolygonPoint1);
            PolygonPoint2 = new TS.Point();
            PolygonPoint2.X = MinimumX + (MaximumX - MinimumX) / 2;
            PolygonPoint2.Y = MinimumY;
            PolygonPoint2.Z = MinimumZ;
            Polygon2.Points.Add(PolygonPoint2);
            PolygonPoint3 = new TS.Point();
            PolygonPoint3.X = MinimumX + (MaximumX - MinimumX) / 2;
            PolygonPoint3.Y = MaximumY;
            PolygonPoint3.Z = MinimumZ;
            Polygon2.Points.Add(PolygonPoint3);
            PolygonPoint4 = new TS.Point();
            PolygonPoint4.X = MinimumX + (MaximumX - MinimumX) / 2;
            PolygonPoint4.Y = MaximumY;
            PolygonPoint4.Z = MaximumZ - 100;
            Polygon2.Points.Add(PolygonPoint4);

            Polygon Polygon3 = new Polygon();
            PolygonPoint1 = new TS.Point();
            PolygonPoint1.X = MaximumX;
            PolygonPoint1.Y = MinimumY;
            PolygonPoint1.Z = MaximumZ;
            Polygon3.Points.Add(PolygonPoint1);
            PolygonPoint2 = new TS.Point();
            PolygonPoint2.X = MaximumX;
            PolygonPoint2.Y = MinimumY;
            PolygonPoint2.Z = MinimumZ;
            Polygon3.Points.Add(PolygonPoint2);
            PolygonPoint3 = new TS.Point();
            PolygonPoint3.X = MaximumX;
            PolygonPoint3.Y = MaximumY;
            PolygonPoint3.Z = MinimumZ;
            Polygon3.Points.Add(PolygonPoint3);
            PolygonPoint4 = new TS.Point();
            PolygonPoint4.X = MaximumX;
            PolygonPoint4.Y = MaximumY;
            PolygonPoint4.Z = MaximumZ;
            Polygon3.Points.Add(PolygonPoint4);

            RebarGroup RebarGroup = new RebarGroup();
            RebarGroup.Polygons.Add(Polygon);
            RebarGroup.Polygons.Add(Polygon2);
            RebarGroup.Polygons.Add(Polygon3);
            RebarGroup.RadiusValues.Add(50.0);
            RebarGroup.SpacingType = RebarGroup.RebarGroupSpacingTypeEnum.SPACING_TYPE_EXACT_SPACE_FLEX_AT_MIDDLE;
            RebarGroup.Spacings.Add(20.0);
            RebarGroup.ExcludeType = RebarGroup.ExcludeTypeEnum.EXCLUDE_TYPE_NONE;
            RebarGroup.Father = Beam;
            RebarGroup.Name = "TestGroup 3";
            RebarGroup.Class = 7;
            RebarGroup.Size = "10";
            RebarGroup.NumberingSeries.StartNumber = 0;
            RebarGroup.NumberingSeries.Prefix = "Group 3";
            RebarGroup.Grade = "A500HW";
            RebarGroup.OnPlaneOffsets.Add(10.0);
            RebarGroup.OnPlaneOffsets.Add(20.0);
            RebarGroup.OnPlaneOffsets.Add(10.0);
            RebarGroup.FromPlaneOffset = 40;

            if (!RebarGroup.Insert())
            {
                WriteLine("RebarGroupTest3 failed - unable to create rebar group");
                MessageBox.Show("Cannot insert rebar group!");
                return;
            }
            else
            {
                ObjectList.Add(RebarGroup);
            }

            WriteLine(RebarGroup.Identifier.ID.ToString());

            ArrayList InnerRebars = RebarGroup.GetRebarGeometries(false);
            RebarGroup.Name = "Modified Group 3";

            if (!RebarGroup.Modify()) MessageBox.Show("Cannot Modify rebar group");

            WriteLine(RebarGroup.Identifier.ID.ToString());
            WriteLine("The third RebarGroupTest complete!");
        }

        private void RebarGroupTest4()
        {
            WriteLine("Starting the fourth RebarGroupTest...");

            ContourPlate CP = InsertPlate();

            if (CP == null)
            {
                WriteLine("RebarGroupTest4 unable to create contour plate");
            }

            Polygon Polygon1 = new Polygon();
            Polygon1.Points.Add(new TS.Point(0, 0, 0));
            Polygon1.Points.Add(new TS.Point(0, 6000, 0));
            Polygon Polygon2 = new Polygon();
            Polygon2.Points.Add(new TS.Point(7200, 0, 0));
            Polygon2.Points.Add(new TS.Point(7200, 6000, 0));

            RebarGroup RebarGroup = new RebarGroup();
            RebarGroup.Polygons.Add(Polygon1);
            RebarGroup.Polygons.Add(Polygon2);
            RebarGroup.RadiusValues.Add(50.0);
            RebarGroup.SpacingType = RebarGroup.RebarGroupSpacingTypeEnum.SPACING_TYPE_TARGET_SPACE;
            RebarGroup.Spacings.Add(1200.0);
            RebarGroup.ExcludeType = RebarGroup.ExcludeTypeEnum.EXCLUDE_TYPE_NONE;
            RebarGroup.Father = CP;
            RebarGroup.Name = "TestGroup 4";
            RebarGroup.Class = 7;
            RebarGroup.Size = "10";
            RebarGroup.NumberingSeries.StartNumber = 0;
            RebarGroup.NumberingSeries.Prefix = "Group 4";
            RebarGroup.Grade = "A500HW";
            RebarGroup.OnPlaneOffsets.Add(10.0);
            RebarGroup.FromPlaneOffset = -50;

            if (!RebarGroup.Insert())
            {
                WriteLine("RebarGroupTest4 failed - unable to create rebar group");
                MessageBox.Show("Cannot insert rebar group!");
                return;
            }
            else
            {
                ObjectList.Add(RebarGroup);
            }

            WriteLine(RebarGroup.Identifier.ID.ToString());

            ArrayList InnerRebars = RebarGroup.GetRebarGeometries(false);
            RebarGroup.Name = "Modified Group 4";

            if (!RebarGroup.Modify()) MessageBox.Show("Cannot Modify rebar group");

            WriteLine(RebarGroup.Identifier.ID.ToString());
            WriteLine("The fourth RebarGroupTest complete!");
        }

        private void RebarSpliceTest()
        {
            WriteLine("Starting the RebarSpliceTest...");
            Beam Beam = new Beam(new TS.Point(5000, 15000, 0), new TS.Point(6000, 15000, 0));
            Beam.Profile.ProfileString = "250*250";
            Beam.Material.MaterialString = "Concrete_Undefined";
            Beam.Finish = "PAINT";
            if (!Beam.Insert())
            {
                WriteLine("RebarSpliceTest failed - unable to create beam");
                MessageBox.Show("Insert beam failed!");
                return;
            }
            else
            {
                ObjectList.Add(Beam);
            }

            double MinimumX = Beam.GetSolid().MinimumPoint.X;
            double MinimumY = Beam.GetSolid().MinimumPoint.Y;
            double MinimumZ = Beam.GetSolid().MinimumPoint.Z;
            double MaximumX = Beam.GetSolid().MaximumPoint.X;
            double MaximumY = Beam.GetSolid().MaximumPoint.Y;
            double MaximumZ = Beam.GetSolid().MaximumPoint.Z;
            double MidX = (MinimumX + MaximumX) / 2.0;

            Polygon Polygon = new Polygon();
            Polygon.Points.Add(new TS.Point(MinimumX, MinimumY, MaximumZ));
            Polygon.Points.Add(new TS.Point(MinimumX, MinimumY, MinimumZ));
            Polygon.Points.Add(new TS.Point(MidX, MinimumY, MinimumZ));

            Polygon Polygon2 = new Polygon();
            Polygon2.Points.Add(new TS.Point(MinimumX, MaximumY, MaximumZ));
            Polygon2.Points.Add(new TS.Point(MinimumX, MaximumY, MinimumZ));
            Polygon2.Points.Add(new TS.Point(MidX, MaximumY, MinimumZ));

            RebarGroup RebarGroup1 = new RebarGroup();
            RebarGroup1.Polygons.Add(Polygon);
            RebarGroup1.Polygons.Add(Polygon2);
            RebarGroup1.RadiusValues.Add(40.0);
            RebarGroup1.SpacingType = RebarGroup.RebarGroupSpacingTypeEnum.SPACING_TYPE_TARGET_SPACE;
            RebarGroup1.Spacings.Add(30.0);
            RebarGroup1.ExcludeType = RebarGroup.ExcludeTypeEnum.EXCLUDE_TYPE_BOTH;
            RebarGroup1.Father = Beam;
            RebarGroup1.Name = "RebarGroup1";
            RebarGroup1.Class = 3;
            RebarGroup1.Size = "12";
            RebarGroup1.NumberingSeries.StartNumber = 0;
            RebarGroup1.NumberingSeries.Prefix = "Group";
            RebarGroup1.Grade = "A500HW";
            RebarGroup1.StartHook.Shape = RebarHookData.RebarHookShapeEnum.NO_HOOK;
            RebarGroup1.StartHook.Angle = -90;
            RebarGroup1.StartHook.Length = 3;
            RebarGroup1.StartHook.Radius = 20;
            RebarGroup1.EndHook.Shape = RebarHookData.RebarHookShapeEnum.NO_HOOK;
            RebarGroup1.EndHook.Angle = -90;
            RebarGroup1.EndHook.Length = 3;
            RebarGroup1.EndHook.Radius = 20;
            RebarGroup1.OnPlaneOffsets.Add(25.0);
            RebarGroup1.OnPlaneOffsets.Add(25.0);
            RebarGroup1.OnPlaneOffsets.Add(25.0);
            RebarGroup1.StartPointOffsetType = Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;
            RebarGroup1.StartPointOffsetValue = 20;
            RebarGroup1.EndPointOffsetType = Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;
            RebarGroup1.EndPointOffsetValue = 20;
            RebarGroup1.FromPlaneOffset = 40;

            if (!RebarGroup1.Insert())
            {
                WriteLine("RebarSpliceTest failed - unable to create rebar group 1");
                MessageBox.Show("Cannot insert rebar group 1!");
                return;
            }
            else
            {
                ObjectList.Add(RebarGroup1);
            }

            Polygon Polygon3 = new Polygon();
            Polygon3.Points.Add(new TS.Point(MidX, MinimumY, MinimumZ));
            Polygon3.Points.Add(new TS.Point(MaximumX, MinimumY, MinimumZ));
            Polygon3.Points.Add(new TS.Point(MaximumX, MinimumY, MaximumZ));

            Polygon Polygon4 = new Polygon();
            Polygon4.Points.Add(new TS.Point(MidX, MaximumY, MinimumZ));
            Polygon4.Points.Add(new TS.Point(MaximumX, MaximumY, MinimumZ));
            Polygon4.Points.Add(new TS.Point(MaximumX, MaximumY, MaximumZ));

            RebarGroup RebarGroup2 = new RebarGroup();
            RebarGroup2.Polygons.Add(Polygon3);
            RebarGroup2.Polygons.Add(Polygon4);
            RebarGroup2.RadiusValues.Add(40.0);
            RebarGroup2.SpacingType = RebarGroup.RebarGroupSpacingTypeEnum.SPACING_TYPE_TARGET_SPACE;
            RebarGroup2.Spacings.Add(30.0);
            RebarGroup2.ExcludeType = RebarGroup.ExcludeTypeEnum.EXCLUDE_TYPE_BOTH;
            RebarGroup2.Father = Beam;
            RebarGroup2.Name = "RebarGroup2";
            RebarGroup2.Class = 3;
            RebarGroup2.Size = "12";
            RebarGroup2.NumberingSeries.StartNumber = 0;
            RebarGroup2.NumberingSeries.Prefix = "Group";
            RebarGroup2.Grade = "A500HW";
            RebarGroup2.StartHook.Shape = RebarHookData.RebarHookShapeEnum.NO_HOOK;
            RebarGroup2.StartHook.Angle = -90;
            RebarGroup2.StartHook.Length = 3;
            RebarGroup2.StartHook.Radius = 20;
            RebarGroup2.EndHook.Shape = RebarHookData.RebarHookShapeEnum.NO_HOOK;
            RebarGroup2.EndHook.Angle = -90;
            RebarGroup2.EndHook.Length = 3;
            RebarGroup2.EndHook.Radius = 20;
            RebarGroup2.OnPlaneOffsets.Add(25.0);
            RebarGroup2.OnPlaneOffsets.Add(25.0);
            RebarGroup2.OnPlaneOffsets.Add(25.0);
            RebarGroup2.StartPointOffsetType = Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;
            RebarGroup2.StartPointOffsetValue = 20;
            RebarGroup2.EndPointOffsetType = Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;
            RebarGroup2.EndPointOffsetValue = 20;
            RebarGroup2.FromPlaneOffset = 40;

            if (!RebarGroup2.Insert())
            {
                WriteLine("RebarSpliceTest failed - unable to create rebar group 2");
                MessageBox.Show("Cannot insert rebar group 2!");
                return;
            }
            else
            {
                ObjectList.Add(RebarGroup2);
            }

            RebarSplice RebarSplice = new RebarSplice(RebarGroup1, RebarGroup2);

            if (!RebarSplice.Insert())
            {
                WriteLine("RebarSpliceTest failed - unable to create rebar splice");
                MessageBox.Show("Cannot insert rebar splice!");
                return;
            }
            else
            {
                ObjectList.Add(RebarSplice);
            }

            WriteLine(RebarSplice.Identifier.ID.ToString());
            if (!RebarSplice.Select()) WriteLine("Can not select rebar splice");
            WriteLine(RebarSplice.Identifier.ID.ToString());

            RebarSplice.LapLength = 300.0;
            RebarSplice.Type = RebarSplice.RebarSpliceTypeEnum.SPLICE_TYPE_LAP_BOTH;
            if (!RebarSplice.Modify()) MessageBox.Show("Can not modify rebar splice");

            WriteLine(RebarSplice.Identifier.ID.ToString());
            WriteLine("The RebarSpliceTest complete!");
        }

        private void WeldTest()
        {
            WriteLine("Starting WeldTest...");

            TS.Point Beam1P1 = new TS.Point(0, 12000, 0);
            TS.Point Beam1P2 = new TS.Point(3000, 12000, 0);

            TS.Point Beam2P1 = new TS.Point(3000, 12000, 0);
            TS.Point Beam2P2 = new TS.Point(3000, 18000, 0);

            Beam Beam1 = new Beam(Beam1P1, Beam1P2);
            Beam Beam2 = new Beam(Beam2P1, Beam2P2);

            Beam1.Profile.ProfileString = "HI400-15-20*400";
            Beam1.Material.MaterialString = "Steel_Undefined";
            Beam1.Finish = "PAINT";
            Beam1.Name = "Beam 1";
            Beam2.Profile.ProfileString = "HI300-15-20*300";
            Beam2.Material.MaterialString = "Steel_Undefined";
            Beam2.Name = "Beam 2";

            if (!Beam1.Insert())
            {
                WriteLine("WeldTest failed - unable to create beam 1");
                MessageBox.Show("Insert failed!");
                return;
            }
            else
            {
                ObjectList.Add(Beam1);
            }

            if (!Beam2.Insert())
            {
                WriteLine("WeldTest failed - unable to create beam 2");
                MessageBox.Show("Insert failed!");
                return;
            }
            else
            {
                ObjectList.Add(Beam2);
            }

            WriteLine("Weld Beams Inserted, Ids " + Beam1.Identifier.ID.ToString() + " " + Beam2.Identifier.ID.ToString());

            Weld Weld = new Weld();
            Weld.MainObject = Beam1;
            Weld.SecondaryObject = Beam2;
            Weld.TypeAbove = Weld.WeldTypeEnum.WELD_TYPE_SQUARE_GROOVE_SQUARE_BUTT;
            Weld.ShopWeld = true;

            if (!Weld.Insert())
            {
                WriteLine("WeldTest failed - unable to create weld");
                MessageBox.Show("Insert failed!");
                return;
            }
            else
            {
                ObjectList.Add(Weld);
            }

            WriteLine(Weld.Identifier.ID.ToString());

            if (!Weld.Select())
                WriteLine("Weld Select failed!");

            WriteLine(Weld.Identifier.ID.ToString());

            Weld.LengthAbove = 12;
            Weld.TypeBelow = Weld.WeldTypeEnum.WELD_TYPE_SLOT;

            if (!Weld.Modify())
                WriteLine("Weld Modify failed!");

            WriteLine(Weld.Identifier.ID.ToString());

            PolygonWeld polyWeld = new PolygonWeld();
            polyWeld.MainObject = Beam1;
            polyWeld.SecondaryObject = Beam2;
            polyWeld.TypeAbove = Weld.WeldTypeEnum.WELD_TYPE_SQUARE_GROOVE_SQUARE_BUTT;
            polyWeld.Polygon.Points.Add(new TS.Point(3000, 12000, 0));
            polyWeld.Polygon.Points.Add(new TS.Point(3000, 18000, 0));

            if (!polyWeld.Insert())
            {
                WriteLine("WeldTest failed - unable to create polyWeld");
                MessageBox.Show("Insert failed!");
                return;
            }
            else
            {
                ObjectList.Add(polyWeld);
            }

            WriteLine(polyWeld.Identifier.ID.ToString());
            WriteLine("WeldTest complete!");
        }

        private void CastUnitTest()
        {
            WriteLine("Starting CastUnitTest...");

            Beam Beam1 = new Beam(new TS.Point(6000, 0, 0), new TS.Point(9000, 0, 0));
            Beam Beam2 = new Beam(new TS.Point(9000, 0, 0), new TS.Point(9000, 6000, 0));
            Beam Beam3 = new Beam(new TS.Point(9000, 6000, 0), new TS.Point(12000, 6000, 0));
            Beam Beam4 = new Beam(new TS.Point(12000, 6000, 0), new TS.Point(12000, 12000, 0));

            Beam1.Profile.ProfileString = "RHS100*100*4";
            Beam1.Name = "Beam 1";
            Beam1.Material.MaterialString = "Concrete_Undefined";

            Beam2.Profile.ProfileString = "RHS200*100*4";
            Beam2.Name = "Beam 2";
            Beam2.Material.MaterialString = "Concrete_Undefined";

            Beam3.Profile.ProfileString = "RHS300*100*4";
            Beam3.Name = "Beam 3";
            Beam3.Material.MaterialString = "Concrete_Undefined";

            Beam4.Profile.ProfileString = "RHS400*100*4";
            Beam4.Name = "Beam 4";
            Beam4.Material.MaterialString = "Concrete_Undefined";

            if (!Beam1.Insert())
            {
                WriteLine("CastUnitTest failed - unable to create beam 1");
                MessageBox.Show("Insert beam 1 failed!");
                return;
            }
            else
            {
                ObjectList.Add(Beam1);
            }

            if (!Beam2.Insert())
            {
                WriteLine("CastUnitTest failed - unable to create beam 2");
                MessageBox.Show("Insert beam 2 failed!");
                return;
            }
            else
            {
                ObjectList.Add(Beam2);
            }

            if (!Beam3.Insert())
            {
                WriteLine("CastUnitTest failed - unable to create beam 3");
                MessageBox.Show("Insert beam 3 failed!");
                return;
            }
            else
            {
                ObjectList.Add(Beam3);
            }

            if (!Beam4.Insert())
            {
                WriteLine("CastUnitTest failed - unable to create beam 4");
                MessageBox.Show("Insert beam 4 failed!");
                return;
            }
            else
            {
                ObjectList.Add(Beam4);
            }

            WriteLine("CastUnit Beams Inserted, Ids " + " " + Beam1.Identifier.ID.ToString() + " " + Beam2.Identifier.ID.ToString() + " " + Beam3.Identifier.ID.ToString() + " " + Beam4.Identifier.ID.ToString());

            Assembly As = Beam1.GetAssembly();
            WriteLine(As.Identifier.ID.ToString());
            As.Add(Beam2);

            if (!As.Modify())
                WriteLine("CastUnit Insert Failed!");

            WriteLine(As.Identifier.ID.ToString());

            if (!As.Select())
                WriteLine("CastUnit Select Failed!");

            WriteLine(As.Identifier.ID.ToString());

            As.Remove(Beam1);
            As.Add(Beam3);
            As.Add(Beam4);

            if (!As.Modify())
                WriteLine("CastUnit Modify Failed!");

            WriteLine(As.Identifier.ID.ToString());

            if (!As.Select())
                WriteLine("CastUnit Select Failed!");

            WriteLine(As.Identifier.ID.ToString());

            WriteLine("CastUnitTest complete!");
        }

        private void ControlPlaneTest()
        {
            WriteLine("Starting ControlPlaneTest...");

            ControlPlane controlPlane = new ControlPlane();

            Plane plane = new Plane();
            plane.Origin = new TS.Point(4500, 4500, 0);
            plane.AxisX = new Vector(-2000, 0, 0);
            plane.AxisY = new Vector(0, 5000, 0);

            controlPlane.Plane = plane;
            controlPlane.IsMagnetic = true;

            if (!controlPlane.Insert())
            {
                WriteLine("ControlPlaneTest failed - unable to create ControlPlane");
                MessageBox.Show("Insert ControlPlane failed!");
                return;
            }
            else
            {
                ObjectList.Add(controlPlane);
            }
            WriteLine(controlPlane.Identifier.ID.ToString());

            if (!controlPlane.Select())
                WriteLine("ControlPlane Select failed!");
            WriteLine(controlPlane.Identifier.ID.ToString());

            controlPlane.Name = "Plane name changed";
            if (!controlPlane.Modify())
                WriteLine("ControlPlane Modify failed!");
            WriteLine(controlPlane.Identifier.ID.ToString());
            WriteLine("ControlPlaneTest complete!");
        }

        private Grid GridTest()
        {
            WriteLine("Starting GridTest...");

            Grid grid = new Grid();

            grid.CoordinateX = "0.00 4*3000.00";
            grid.CoordinateY = "0.00 5*6000.00";
            grid.CoordinateZ = "0.00 6000.00 8000.00 9000.00";
            grid.LabelX = "A B C D E";
            grid.LabelY = "1 2 3 4 5 6";
            grid.LabelZ = "+0 +6000 +8000 +9000";

            grid.ExtensionLeftX = 2000.0;
            grid.ExtensionLeftY = 2000.0;
            grid.ExtensionLeftZ = 2000.0;
            grid.ExtensionRightX = 2000.0;
            grid.ExtensionRightY = 2000.0;
            grid.ExtensionRightZ = 2000.0;
            grid.IsMagnetic = true;

            if (!grid.Insert())
            {
                WriteLine("GridTest failed - unable to create Grid");
                MessageBox.Show("Insert Grid failed!");
                return null;
            }
            else
            {
                ObjectList.Add(grid);
            }
            WriteLine(grid.Identifier.ID.ToString());

            if (!grid.Select())
                WriteLine("Grid Select failed!");
            WriteLine(grid.Identifier.ID.ToString());

            grid.CoordinateX = "0.00 4*5000.00";
            grid.CoordinateY = "0.00 5*1000.00";
            grid.CoordinateZ = "0.00 3000.00 4000.00 4500.00";
            grid.LabelX = "X Y Z M N";
            grid.LabelY = "6 5 4 3 2 1";
            grid.LabelZ = "+0 +3000 +4000 +4500";
            grid.ExtensionLeftX = 5000.0;
            grid.ExtensionLeftY = 5000.0;
            grid.ExtensionLeftZ = 5000.0;
            grid.ExtensionRightX = 5000.0;
            grid.ExtensionRightY = 5000.0;
            grid.ExtensionRightZ = 5000.0;
            grid.IsMagnetic = false;

            if (!grid.Modify())
                WriteLine("Grid Modify failed!");
            WriteLine(grid.Identifier.ID.ToString());
            WriteLine("Grid complete!");

            return grid;
        }

        private void GridPlaneTest()
        {
            bool Success = false;

            WriteLine("Starting GridPlaneTest...");

            ModelObjectEnumerator Enumerator = Model.GetModelObjectSelector().GetAllObjects();

            while (!Success && Enumerator.MoveNext())
            {
                ModelObject ModelObject = Enumerator.Current as ModelObject;
                System.Type ObjectType = ModelObject.GetType();

                while (ObjectType != typeof(Grid) &&
                    ObjectType.BaseType != null)
                    ObjectType = ObjectType.BaseType;

                if (ObjectType == typeof(Grid))
                    Success = true;
            }

            Grid Grid = null;
            GridPlane gridPlane = new GridPlane();

            if (Success)
            {
                Grid = Enumerator.Current as Grid;
                gridPlane.Parent = Grid;
            }
            else
            {
                Success = false;
            }

            gridPlane.Plane.Origin = new TS.Point(1000.0, 0.0, 0.0);
            gridPlane.Plane.AxisX = new Vector(0.0, 2000.0, 0.0);
            gridPlane.Plane.AxisY = new Vector(0.0, 0.0, 5000.0);

            gridPlane.Label = "Muksu";
            gridPlane.IsMagnetic = true;
            gridPlane.DrawingVisibility = true;

            if (Success && !gridPlane.Insert())
            {
                Success = false;
                WriteLine("GridPlane Insert failed!");
            }
            else
                ObjectList.Add(gridPlane);
            WriteLine(gridPlane.Identifier.ID.ToString());

            if (Success && !gridPlane.Select())
            {
                Success = false;
                WriteLine("GridPlane Select failed!");
            }
            WriteLine(gridPlane.Identifier.ID.ToString());

            gridPlane.Plane.Origin = new TS.Point(1000.0, 0.0, 0.0);
            gridPlane.Plane.AxisX = new Vector(0.0, 6000.0, 0.0);
            gridPlane.Plane.AxisY = new Vector(0.0, 0.0, 2500.0);

            gridPlane.Label = "Tested";
            gridPlane.IsMagnetic = false;
            gridPlane.DrawingVisibility = false;

            if (Success && !gridPlane.Modify())
            {
                Success = false;
                WriteLine("GridPlane Modify failed!");
            }

            WriteLine(gridPlane.Identifier.ID.ToString());
            WriteLine("GridPlaneTest complete" + (Success ? "d succesfully " : "") + "!");
        }

        private void SurfaceTreatmentTest()
        {
            WriteLine("Starting SurfaceTreatmentTest...");

            ContourPlate cp = new ContourPlate();
            cp.AddContourPoint(new ContourPoint(new TS.Point(6000, 15000, 0), null));
            cp.AddContourPoint(new ContourPoint(new TS.Point(9000, 15000, 0), null));
            cp.AddContourPoint(new ContourPoint(new TS.Point(9000, 21000, 0), null));
            cp.AddContourPoint(new ContourPoint(new TS.Point(10500, 24000, 0), null));
            cp.AddContourPoint(new ContourPoint(new TS.Point(6000, 21000, 0), null));

            Contour c = new Contour();
            c.AddContourPoint(new ContourPoint(new TS.Point(6000, 15000, 5), null));
            c.AddContourPoint(new ContourPoint(new TS.Point(9000, 15000, 5), null));
            c.AddContourPoint(new ContourPoint(new TS.Point(9000, 21000, 5), new Chamfer(300, 300, Chamfer.ChamferTypeEnum.CHAMFER_ARC)));
            c.AddContourPoint(new ContourPoint(new TS.Point(10500, 24000, 5), null));
            c.AddContourPoint(new ContourPoint(new TS.Point(7500, 21000, 5), null));

            cp.Profile.ProfileString = "PL10";
            cp.Material.MaterialString = "Concrete_Undefined";
            if (!cp.Insert())
            {
                WriteLine("SurfaceTreatmentTest failed - unable to create contour plate");
                MessageBox.Show("Insert ContourPlate failed!");
                return;
            }
            else
            {
                ObjectList.Add(cp);
            }
            WriteLine("ContourPlate ID " + " " + cp.Identifier.ID.ToString());

            SurfaceTreatment treatment = new SurfaceTreatment();
            treatment.Father = cp;
            treatment.Polygon = c;
            treatment.StartPoint = new TS.Point(7500, 15000, 5);
            treatment.EndPoint = new TS.Point(7500, 21000, 5);

            treatment.Position.Depth = Position.DepthEnum.MIDDLE;

            treatment.Name = "Treatment Test";
            treatment.Class = "66";
            treatment.Thickness = 40;
            treatment.Color = SurfaceTreatment.SurfaceColorEnum.CYAN;
            treatment.Type = SurfaceTreatment.SurfaceTypeEnum.TILE_SURFACE;
            treatment.Material.MaterialString = "Concrete_Undefined";

            if (!treatment.Insert())
            {
                WriteLine("SurfaceTreatmentTest failed - unable to create SurfaceTreatment");
                MessageBox.Show("Insert SurfaceTreatment failed!");
                return;
            }
            else
            {
                ObjectList.Add(treatment);
            }
            WriteLine(treatment.Identifier.ID.ToString());

            if (!treatment.Select())
                WriteLine("SurfaceTreatment Select failed!");
            WriteLine(treatment.Identifier.ID.ToString());

            treatment.Name = "Name modified";
            treatment.Class = "1";
            treatment.Color = SurfaceTreatment.SurfaceColorEnum.RED;
            treatment.Type = SurfaceTreatment.SurfaceTypeEnum.SPECIAL_MIX;
            if (!treatment.Modify())
                WriteLine("Modify failed!");
            WriteLine(treatment.Identifier.ID.ToString());
            WriteLine("SurfaceTreatmentTest complete!");
        }

        private void AssemblyTest()
        {
            WriteLine("Starting AssemblyTest...");

            TS.Point Beam1P1 = new TS.Point(9000, 18000, 0);
            TS.Point Beam1P2 = new TS.Point(12000, 18000, 0);

            TS.Point Beam2P1 = new TS.Point(12000, 18000, 0);
            TS.Point Beam2P2 = new TS.Point(12000, 24000, 0);

            Beam Beam1 = new Beam(Beam1P1, Beam1P2);
            Beam Beam2 = new Beam(Beam2P1, Beam2P2);

            Beam1.Profile.ProfileString = "HI400-15-20*400";
            Beam1.Material.MaterialString = "Steel_Undefined";
            Beam1.Finish = "PAINT";
            Beam1.Name = "Beam 1";

            if (!Beam1.Insert())
            {
                WriteLine("AssemblyTest failed - unable to create beam 1");
                MessageBox.Show("Insert beam 1 failed!");
                return;
            }
            else
            {
                ObjectList.Add(Beam1);
            }

            Beam2.Profile.ProfileString = "HI300-15-20*300";
            Beam2.Material.MaterialString = "Steel_Undefined";
            Beam2.Name = "Beam 2";
            if (!Beam2.Insert())
            {
                WriteLine("AssemblyTest failed - unable to create beam 2");
                MessageBox.Show("Insert beam 2 failed!");
                return;
            }
            else
            {
                ObjectList.Add(Beam2);
            }

            WriteLine("Beams Inserted, Ids " + " " + Beam1.Identifier.ID.ToString() + " " + Beam2.Identifier.ID.ToString());

            Weld Weld = new Weld();
            Weld.MainObject = Beam1;
            Weld.SecondaryObject = Beam2;
            Weld.TypeAbove = Weld.WeldTypeEnum.WELD_TYPE_SQUARE_GROOVE_SQUARE_BUTT;
            Weld.ShopWeld = true;

            if (!Weld.Insert())
            {
                WriteLine("AssemblyTest failed - unable to create weld");
                MessageBox.Show("Insert weld failed!");
                return;
            }
            else
            {
                ObjectList.Add(Weld);
            }
            WriteLine("Weld created, Id " + " " + Weld.Identifier.ID.ToString());

            Assembly assembly = Beam1.GetAssembly();
            if (assembly == null)
                WriteLine("GetAssembly failed!");
            WriteLine(assembly.Identifier.ID.ToString());
            assembly.AssemblyNumber.Prefix = "C";
            assembly.AssemblyNumber.StartNumber = 3050;
            assembly.Modify();
            WriteLine("AssemblyTest complete!");
        }

        private void GetPartMarkTest()
        {
            WriteLine("Starting GetPartMark Test...");

            TS.Point Beam1P1 = new TS.Point(9500, 20000, 0);
            TS.Point Beam1P2 = new TS.Point(9500, 23000, 0);

            TS.Point Beam2P1 = new TS.Point(10500, 20000, 0);
            TS.Point Beam2P2 = new TS.Point(10500, 23000, 0);

            Beam Beam1 = new Beam(Beam1P1, Beam1P2);

            Beam Beam2 = new Beam(Beam2P1, Beam2P2);

            Beam1.Profile.ProfileString = "HI400-15-20*400";
            Beam1.Material.MaterialString = "Steel_Undefined";
            Beam1.Finish = "PAINT";
            Beam1.Name = "Beam 1";

            Beam2.Profile.ProfileString = "HI300-15-20*300";
            Beam2.Material.MaterialString = "Steel_Undefined";
            Beam2.Finish = "PAINT";
            Beam2.Name = "Beam 2";

            if (!Beam1.Insert())
            {
                WriteLine("GetPartMarkTest failed - unable to create beam 1");
                MessageBox.Show("Insert beam 1 failed!");
                return;
            }
            else
            {
                ObjectList.Add(Beam1);
            }

            if (!Beam2.Insert())
            {
                WriteLine("GetPartMarkTest failed - unable to create beam 2");
                MessageBox.Show("Insert beam 2 failed!");
                return;
            }
            else
            {
                ObjectList.Add(Beam2);
            }

            WriteLine("Beams Inserted, Id " + " " + Beam1.Identifier.ID.ToString() + " " + Beam2.Identifier.ID.ToString());

            string mark = Beam1.GetPartMark();
            string mark2 = Beam2.GetPartMark();

            if (mark == null || mark2 == null)
                WriteLine("GetParkMark failed!");
            else
                WriteLine("PartMark is " + " " + mark + "\\" + mark2);
            WriteLine("GetPartMark Test complete!");
        }

        private void BoltArrayTest()
        {
            WriteLine("Starting BoltArrayTest...");

            //Create for instance a contour plate that we can bolt to, insert it into the model
            ContourPlate cp = new ContourPlate();
            cp.Profile.ProfileString = "PL10";
            cp.Material.MaterialString = "Steel_Undefined";
            cp.AddContourPoint(new ContourPoint(new TS.Point(0, 18000, 0), null));
            cp.AddContourPoint(new ContourPoint(new TS.Point(1000, 18000, 0), null));
            cp.AddContourPoint(new ContourPoint(new TS.Point(1000, 19000, 0), null));
            cp.AddContourPoint(new ContourPoint(new TS.Point(0, 19000, 0), null));

            if (!cp.Insert())
            {
                WriteLine("BoltArrayTest failed - unable to create contour plate");
                MessageBox.Show("Insert failed!");
                return;
            }
            else
            {
                ObjectList.Add(cp);
            }

            WriteLine("ContourPlate ID " + " " + cp.Identifier.ID.ToString());

            BoltArray B = new BoltArray();

            B.PartToBeBolted = cp;
            B.PartToBoltTo = cp;

            B.FirstPosition = new TS.Point(0, 18000, 0);
            B.SecondPosition = new TS.Point(1000, 19000, 0);

            B.BoltSize = 16;
            B.Tolerance = 3.00;
            B.BoltStandard = "7990";
            B.BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_WORKSHOP;
            B.CutLength = 105;
            //B.StartPointOffset.Dx = 1;
            //B.EndPointOffset.Dx = 2;
            //B.StartPointOffset.Dy = 3;
            //B.EndPointOffset.Dy = 4;
            //B.StartPointOffset.Dz = 5;
            //B.EndPointOffset.Dz = 6;

            B.Length = 100;
            B.ExtraLength = 15;
            B.SlottedHoleX = 11;
            B.SlottedHoleY = 22;
            B.ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_NO;

            B.RotateSlots = BoltGroup.BoltRotateSlotsEnum.ROTATE_SLOTS_ODD;
            B.HoleType = BoltGroup.BoltHoleTypeEnum.HOLE_TYPE_OVERSIZED;

            //B.Position.Depth = Position.DepthEnum.MIDDLE;
            //B.Position.DepthOffset = 3;
            //B.Position.Plane = Position.PlaneEnum.MIDDLE;
            //B.Position.PlaneOffset = 1;
            //B.Position.Rotation = Position.RotationEnum.FRONT;
            //B.Position.RotationOffset = 2;

            B.Bolt = true;
            B.Washer1 = true;
            B.Washer2 = true;
            B.Washer3 = true;
            B.Nut1 = true;
            B.Nut2 = true;

            B.Hole1 = true;
            B.Hole2 = true;
            B.Hole3 = true;
            B.Hole4 = true;
            B.Hole5 = true;

            B.AddBoltDistX(100);
            B.AddBoltDistX(90);
            B.AddBoltDistX(80);

            B.AddBoltDistY(70);
            B.AddBoltDistY(60);
            B.AddBoltDistY(50);

            if (!B.Insert())
                WriteLine("BoltArray Insert Failed!");
            else
                ObjectList.Add(B);
            WriteLine(B.Identifier.ID.ToString());

            BoltArray BSel = new BoltArray();
            BSel.Identifier = B.Identifier;

            if (!BSel.Select())
                WriteLine("BoltArray Select failed!");
            WriteLine(BSel.Identifier.ID.ToString());

            B.FirstPosition = new TS.Point(1000, 18000, 0);
            B.SecondPosition = new TS.Point(0, 19000, 0);

            B.BoltSize = 20;
            B.Tolerance = 4.00;
            B.BoltStandard = "7990";
            B.BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE;
            B.CutLength = 155;
            //B.StartPointOffset.Dx = 11;
            //B.EndPointOffset.Dx = 12;
            //B.StartPointOffset.Dy = 13;
            //B.EndPointOffset.Dy = 14;
            //B.StartPointOffset.Dz = 15;
            //B.EndPointOffset.Dz = 16;

            B.Length = 50;
            B.ExtraLength = 45;
            B.SlottedHoleX = 55;
            B.SlottedHoleY = 66;
            B.ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES;

            B.RotateSlots = BoltGroup.BoltRotateSlotsEnum.ROTATE_SLOTS_EVEN;
            B.HoleType = BoltGroup.BoltHoleTypeEnum.HOLE_TYPE_SLOTTED;

            //B.Position.Depth = Position.DepthEnum.FRONT;
            //B.Position.DepthOffset = 13;
            //B.Position.Plane = Position.PlaneEnum.LEFT;
            //B.Position.PlaneOffset = 11;
            //B.Position.Rotation = Position.RotationEnum.TOP;
            //B.Position.RotationOffset = 12;

            B.Bolt = true;
            B.Washer1 = false;
            B.Washer2 = false;
            B.Washer3 = false;
            B.Nut1 = true;
            B.Nut2 = true;

            B.Hole1 = true;
            B.Hole2 = false;
            B.Hole3 = true;
            B.Hole4 = false;
            B.Hole5 = true;

            B.AddBoltDistX(150);
            B.AddBoltDistX(160);
            B.AddBoltDistX(170);

            if (!B.Modify())
                WriteLine("BoltArray Modify failed!");

            WriteLine(B.Identifier.ID.ToString());
            WriteLine("BoltArrayTest complete!");
        }

        private void BoltXYListTest()
        {
            WriteLine("Starting BoltXYListTest...");

            //Create for instance a contour plate that we can bolt to, insert it into the model
            ContourPlate cp = new ContourPlate();
            cp.Profile.ProfileString = "PL10";
            cp.Material.MaterialString = "Steel_Undefined";
            cp.AddContourPoint(new ContourPoint(new TS.Point(0, 19000, 0), null));
            cp.AddContourPoint(new ContourPoint(new TS.Point(1000, 19000, 0), null));
            cp.AddContourPoint(new ContourPoint(new TS.Point(1000, 20000, 0), null));
            cp.AddContourPoint(new ContourPoint(new TS.Point(0, 20000, 0), null));

            if (!cp.Insert())
            {
                WriteLine("BoltXYListTest failed - unable to create contour plate");
                MessageBox.Show("Insert failed!");
                return;
            }
            else
            {
                ObjectList.Add(cp);
            }
            WriteLine("ContourPlate ID " + " " + cp.Identifier.ID.ToString());

            BoltXYList B = new BoltXYList();

            B.PartToBeBolted = cp;
            B.PartToBoltTo = cp;

            B.FirstPosition = new TS.Point(0, 19000, 0);
            B.SecondPosition = new TS.Point(1000, 20000, 0);

            B.BoltSize = 16;
            B.Tolerance = 3.00;
            B.BoltStandard = "7968";
            B.BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_WORKSHOP;
            B.CutLength = 105;
            //B.StartPointOffset.Dx = 1;
            //B.EndPointOffset.Dx = 2;
            //B.StartPointOffset.Dy = 3;
            //B.EndPointOffset.Dy = 4;
            //B.StartPointOffset.Dz = 5;
            //B.EndPointOffset.Dz = 6;

            B.Length = 88;
            B.ExtraLength = 15;
            B.SlottedHoleX = 11;
            B.SlottedHoleY = 22;
            B.ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_NO;

            B.RotateSlots = BoltGroup.BoltRotateSlotsEnum.ROTATE_SLOTS_ODD;
            B.HoleType = BoltGroup.BoltHoleTypeEnum.HOLE_TYPE_OVERSIZED;

            //B.Position.Depth = Position.DepthEnum.MIDDLE;
            //B.Position.DepthOffset = 3;
            //B.Position.Plane = Position.PlaneEnum.MIDDLE;
            //B.Position.PlaneOffset = 1;
            //B.Position.Rotation = Position.RotationEnum.FRONT;
            //B.Position.RotationOffset = 2;

            B.Bolt = true;
            B.Washer1 = true;
            B.Washer2 = true;
            B.Washer3 = true;
            B.Nut1 = true;
            B.Nut2 = true;

            B.Hole1 = true;
            B.Hole2 = true;
            B.Hole3 = true;
            B.Hole4 = true;
            B.Hole5 = true;

            B.AddBoltDistX(100);
            B.AddBoltDistX(200);
            B.AddBoltDistX(300);

            B.AddBoltDistY(100);
            B.AddBoltDistY(200);
            B.AddBoltDistY(300);

            if (!B.Insert())
                WriteLine("BoltXYList Insert Failed!");
            else
                ObjectList.Add(B);
            WriteLine(B.Identifier.ID.ToString());

            BoltXYList BSel = new BoltXYList();
            BSel.Identifier = B.Identifier;

            if (!BSel.Select())
                WriteLine("BoltXYList Select failed!");
            WriteLine(BSel.Identifier.ID.ToString());

            B.BoltSize = 20;
            B.Tolerance = 4.00;
            B.BoltStandard = "7990";
            B.BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE;
            B.CutLength = 155;
            //B.StartPointOffset.Dx = 11;
            //B.EndPointOffset.Dx = 12;
            //B.StartPointOffset.Dy = 13;
            //B.EndPointOffset.Dy = 14;
            //B.StartPointOffset.Dz = 15;
            //B.EndPointOffset.Dz = 16;

            B.Length = 88;
            B.ExtraLength = 45;
            B.SlottedHoleX = 55;
            B.SlottedHoleY = 66;
            B.ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES;

            B.RotateSlots = BoltGroup.BoltRotateSlotsEnum.ROTATE_SLOTS_EVEN;
            B.HoleType = BoltGroup.BoltHoleTypeEnum.HOLE_TYPE_SLOTTED;

            //B.Position.Depth = Position.DepthEnum.FRONT;
            //B.Position.DepthOffset = 13;
            //B.Position.Plane = Position.PlaneEnum.LEFT;
            //B.Position.PlaneOffset = 11;
            //B.Position.Rotation = Position.RotationEnum.TOP;
            //B.Position.RotationOffset = 12;

            B.Bolt = true;
            B.Washer1 = false;
            B.Washer2 = false;
            B.Washer3 = false;
            B.Nut1 = true;
            B.Nut2 = true;

            B.Hole1 = true;
            B.Hole2 = false;
            B.Hole3 = true;
            B.Hole4 = false;
            B.Hole5 = true;

            B.AddBoltDistX(500);
            B.AddBoltDistY(500);

            if (!B.Modify())
                WriteLine("BoltXYList Modify failed!");
            WriteLine(B.Identifier.ID.ToString());
            WriteLine("BoltXYListTest complete!");
        }

        private void BoltCircleTest()
        {
            WriteLine("Starting BoltCircleTest...");

            //Create for instance a contour plate that we can bolt to, insert it into the model
            ContourPlate cp = new ContourPlate();
            cp.Profile.ProfileString = "PL10";
            cp.Material.MaterialString = "Steel_Undefined";
            cp.AddContourPoint(new ContourPoint(new TS.Point(0, 20000, 0), null));
            cp.AddContourPoint(new ContourPoint(new TS.Point(1000, 20000, 0), null));
            cp.AddContourPoint(new ContourPoint(new TS.Point(1000, 21000, 0), null));
            cp.AddContourPoint(new ContourPoint(new TS.Point(0, 21000, 0), null));

            if (!cp.Insert())
            {
                WriteLine("BoltCircleTest failed - unable to create contour plate");
                MessageBox.Show("Insert failed!");
                return;
            }
            else
            {
                ObjectList.Add(cp);
            }
            WriteLine("ContourPlate ID " + " " + cp.Identifier.ID.ToString());

            BoltCircle B = new BoltCircle();

            B.PartToBeBolted = cp;
            B.PartToBoltTo = cp;

            B.FirstPosition = new TS.Point(0, 20000, 0);
            B.SecondPosition = new TS.Point(1000, 21000, 0);

            B.BoltSize = 16;
            B.Tolerance = 3.00;
            B.BoltStandard = "7968";
            B.BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_WORKSHOP;
            B.CutLength = 105;
            //B.StartPointOffset.Dx = 1;
            //B.EndPointOffset.Dx = 2;
            //B.StartPointOffset.Dy = 3;
            //B.EndPointOffset.Dy = 4;
            //B.StartPointOffset.Dz = 5;
            //B.EndPointOffset.Dz = 6;

            B.Length = 88;
            B.ExtraLength = 15;
            B.SlottedHoleX = 11;
            B.SlottedHoleY = 22;
            B.ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_NO;

            B.RotateSlots = BoltGroup.BoltRotateSlotsEnum.ROTATE_SLOTS_ODD;
            B.HoleType = BoltGroup.BoltHoleTypeEnum.HOLE_TYPE_OVERSIZED;

            //B.Position.Depth = Position.DepthEnum.MIDDLE;
            //B.Position.DepthOffset = 3;
            //B.Position.Plane = Position.PlaneEnum.MIDDLE;
            //B.Position.PlaneOffset = 1;
            //B.Position.Rotation = Position.RotationEnum.FRONT;
            //B.Position.RotationOffset = 2;

            B.Bolt = true;
            B.Washer1 = true;
            B.Washer2 = true;
            B.Washer3 = true;
            B.Nut1 = true;
            B.Nut2 = true;

            B.Hole1 = true;
            B.Hole2 = true;
            B.Hole3 = true;
            B.Hole4 = true;
            B.Hole5 = true;

            B.NumberOfBolts = 7;
            B.Diameter = 160;

            if (!B.Insert())
                WriteLine("BoltCircle Insert Failed!");
            else
                ObjectList.Add(B);
            WriteLine(B.Identifier.ID.ToString());

            BoltCircle BSel = new BoltCircle();
            BSel.Identifier = B.Identifier;

            if (!BSel.Select())
                WriteLine("BoltCircle Select failed!");
            WriteLine(BSel.Identifier.ID.ToString());

            B.BoltSize = 20;
            B.Tolerance = 4.00;
            B.BoltStandard = "7990";
            B.BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE;
            B.CutLength = 155;
            //B.StartPointOffset.Dx = 11;
            //B.EndPointOffset.Dx = 12;
            //B.StartPointOffset.Dy = 13;
            //B.EndPointOffset.Dy = 14;
            //B.StartPointOffset.Dz = 15;
            //B.EndPointOffset.Dz = 16;

            B.Length = 88;
            B.ExtraLength = 45;
            B.SlottedHoleX = 55;
            B.SlottedHoleY = 66;
            B.ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES;

            B.RotateSlots = BoltGroup.BoltRotateSlotsEnum.ROTATE_SLOTS_EVEN;
            B.HoleType = BoltGroup.BoltHoleTypeEnum.HOLE_TYPE_SLOTTED;

            //B.Position.Depth = Position.DepthEnum.FRONT;
            //B.Position.DepthOffset = 13;
            //B.Position.Plane = Position.PlaneEnum.LEFT;
            //B.Position.PlaneOffset = 11;
            //B.Position.Rotation = Position.RotationEnum.TOP;
            //B.Position.RotationOffset = 12;

            B.Bolt = true;
            B.Washer1 = false;
            B.Washer2 = false;
            B.Washer3 = false;
            B.Nut1 = true;
            B.Nut2 = true;

            B.Hole1 = true;
            B.Hole2 = false;
            B.Hole3 = true;
            B.Hole4 = false;
            B.Hole5 = true;

            B.NumberOfBolts = 9;
            B.Diameter = 240;

            if (!B.Modify())
                WriteLine("BoltCircle Modify failed!");
            WriteLine(B.Identifier.ID.ToString());
            WriteLine("BoltCircle complete!");
        }

        private void LoadPointTest()
        {
            WriteLine("Starting LoadPointTest...");
            Beam FatherBeam = new Beam(new TS.Point(0, 24000, 0), new TS.Point(1000, 24000, 0));
            FatherBeam.Profile.ProfileString = "HI400-15-20*400";
            FatherBeam.Material.MaterialString = "Steel_Undefined";
            if (!FatherBeam.Insert())
            {
                WriteLine("LoadPointTest failed - unable to create father beam");
                MessageBox.Show("Insert father beam failed!");
                return;
            }
            else
            {
                ObjectList.Add(FatherBeam);
            }
            
            WriteLine(FatherBeam.Identifier.ID.ToString());
            
            LoadPoint L = new LoadPoint();
            L.P = new Vector(3000, 4000, 5000);
            L.Moment = new Vector(6000, 7000, 8000);
            L.Position = new TS.Point(0, 24000, 0);

            L.FatherId = FatherBeam.Identifier;

            L.AutomaticPrimaryAxisWeight = true;
            L.BoundingBoxDx = 500;
            L.BoundingBoxDy = 500;
            L.BoundingBoxDz = 500;
            L.LoadDispersionAngle = 0.77;
            L.PartFilter = "testing";
            L.PartNames = TSM.Load.LoadPartNamesEnum.LOAD_PART_NAMES_INCLUDE; ;
            L.PrimaryAxisDirection = new Vector(1000, 500, 0);
            L.Spanning = TSM.Load.LoadSpanningEnum.LOAD_SPANNING_SINGLE;
            L.Weight = 2;
            L.CreateFixedSupportConditionsAutomatically = true;

            L.LoadAttachment = TSM.Load.LoadAttachmentEnum.LOAD_ATTACHMENT_ATTACH_TO_MEMBER; //Can't be Set atm

            if (!L.Insert())
            {
                WriteLine("LoadPointTest failed - unable to create load point");
                MessageBox.Show("Insert load point failed!");
                return;
            }
            else
            {
                ObjectList.Add(L);
            }
            WriteLine("LoadPoint ID " + " " + L.Identifier.ID.ToString());

            LoadPoint LSel = new LoadPoint();
            LSel.Identifier = L.Identifier;

            if (!LSel.Select())
                WriteLine("LoadPoint Select failed!");
            WriteLine(LSel.Identifier.ID.ToString());

            L.P = new Vector(13000, 14000, 15000);
            L.Moment = new Vector(16000, 17000, 18000);
            L.Position = new TS.Point(1000, 24000, 0);

            //LP.FatherId = FatherBeam.Identifier; //Can't be changed, at least not right now

            L.AutomaticPrimaryAxisWeight = false;
            L.BoundingBoxDx = 1500;
            L.BoundingBoxDy = 1500;
            L.BoundingBoxDz = 1500;
            L.LoadDispersionAngle = 0.99;
            L.PartFilter = "testing modified";
            L.PartNames = TSM.Load.LoadPartNamesEnum.LOAD_PART_NAMES_EXCLUDE;
            L.PrimaryAxisDirection = new Vector(2000, 1500, 0);
            L.Spanning = TSM.Load.LoadSpanningEnum.LOAD_SPANNING_DOUBLE;
            L.Weight = 5;
            L.CreateFixedSupportConditionsAutomatically = false;

            L.LoadAttachment = TSM.Load.LoadAttachmentEnum.LOAD_ATTACHMENT_DONT_ATTACH; //Can't be Set atm

            if (!L.Modify())
                WriteLine("LoadPoint Modify failed!");
            WriteLine(L.Identifier.ID.ToString());
            WriteLine("LoadPoint complete!");
        }

        private void LoadAreaTest()
        {
            WriteLine("Starting LoadAreaTest...");

            LoadArea L = new LoadArea();
            L.P1 = new Vector(1000, 2000, 3000);
            L.P2 = new Vector(4000, 5000, 6000);
            L.P3 = new Vector(7000, 8000, 9000);
            L.DistanceA = 5;
            L.Position1 = new TS.Point(1000, 24000, 0);
            L.Position2 = new TS.Point(2000, 24000, 0);
            L.Position3 = new TS.Point(2000, 26000, 0);
            L.LoadForm = LoadArea.AreaLoadFormEnum.LOAD_FORM_AREA_PARALLELOGRAM;

            //L.FatherId = FatherBeam.Identifier;

            L.AutomaticPrimaryAxisWeight = true;
            L.BoundingBoxDx = 500;
            L.BoundingBoxDy = 500;
            L.BoundingBoxDz = 500;
            L.LoadDispersionAngle = 0.77;
            L.PartFilter = "testing";
            L.PartNames = TSM.Load.LoadPartNamesEnum.LOAD_PART_NAMES_INCLUDE; ;
            L.PrimaryAxisDirection = new Vector(1000, 500, 0);
            L.Spanning = TSM.Load.LoadSpanningEnum.LOAD_SPANNING_SINGLE;
            L.Weight = 2;
            L.CreateFixedSupportConditionsAutomatically = true;

            L.LoadAttachment = TSM.Load.LoadAttachmentEnum.LOAD_ATTACHMENT_DONT_ATTACH;

            if (!L.Insert())
            {
                WriteLine("LoadAreaTest failed - unable to create load area");
                MessageBox.Show("Insert load area failed!");
                return;
            }
            else
            {
                ObjectList.Add(L);
            }
            WriteLine("LoadArea ID " + " " + L.Identifier.ID.ToString());

            LoadArea LSel = new LoadArea();
            LSel.Identifier = L.Identifier;

            if (!LSel.Select())
                WriteLine("LoadArea Select failed!");
            WriteLine(LSel.Identifier.ID.ToString());

            L.P1 = new Vector(11000, 12000, 13000);
            L.P2 = new Vector(14000, 15000, 16000);
            L.P3 = new Vector(17000, 18000, 19000);
            L.DistanceA = 15;
            L.Position1 = new TS.Point(1000, 24000, 0);
            L.Position2 = new TS.Point(2000, 24000, 0);
            L.Position3 = new TS.Point(1000, 26000, 0);
            L.LoadForm = LoadArea.AreaLoadFormEnum.LOAD_FORM_AREA_TRIANGLE;

            //LP.FatherId = FatherBeam.Identifier; //Can't be changed, at least not right now

            L.AutomaticPrimaryAxisWeight = false;
            L.BoundingBoxDx = 1500;
            L.BoundingBoxDy = 1500;
            L.BoundingBoxDz = 1500;
            L.LoadDispersionAngle = 0.99;
            L.PartFilter = "testing modified";
            L.PartNames = TSM.Load.LoadPartNamesEnum.LOAD_PART_NAMES_EXCLUDE;
            L.PrimaryAxisDirection = new Vector(2000, 1500, 0);
            L.Spanning = TSM.Load.LoadSpanningEnum.LOAD_SPANNING_DOUBLE;
            L.Weight = 5;
            L.CreateFixedSupportConditionsAutomatically = false;

            L.LoadAttachment = TSM.Load.LoadAttachmentEnum.LOAD_ATTACHMENT_DONT_ATTACH;

            if (!L.Modify())
                WriteLine("LoadArea Modify failed!");
            WriteLine(L.Identifier.ID.ToString());
            WriteLine("LoadArea complete!");
        }

        private void LoadLineTest()
        {
            WriteLine("Starting LoadLineTest...");
            Beam FatherBeam = new Beam(new TS.Point(3000, 24000, 0), new TS.Point(5000, 24000, 0));
            FatherBeam.Profile.ProfileString = "HI400-15-20*400";
            if (!FatherBeam.Insert())
            {
                WriteLine("LoadLineTest failed - unable to create father beam");
                MessageBox.Show("Insert father beam failed!");
                return;
            }
            else
            {
                ObjectList.Add(FatherBeam);
            }
            WriteLine(FatherBeam.Identifier.ID.ToString());


            LoadLine L = new LoadLine();
            L.P1 = new Vector(0000, 0000, -1000);
            L.P2 = new Vector(0000, 0000, -1000);
            L.DistanceA = 5;
            L.DistanceB = 6;
            L.Torsion1 = 1000;
            L.Torsion2 = 2000;
            L.Position1 = new TS.Point(3000, 24000, 0);
            L.Position2 = new TS.Point(4000, 24000, 0);
            L.LoadForm = LoadLine.LineLoadFormEnum.LOAD_FORM_LINE_1;

            L.FatherId = FatherBeam.Identifier;

            L.AutomaticPrimaryAxisWeight = true;
            L.BoundingBoxDx = 500;
            L.BoundingBoxDy = 500;
            L.BoundingBoxDz = 500;
            L.LoadDispersionAngle = 0.77;
            L.PartFilter = "testing";
            L.PartNames = TSM.Load.LoadPartNamesEnum.LOAD_PART_NAMES_INCLUDE; ;
            L.PrimaryAxisDirection = new Vector(1000, 500, 0);
            L.Spanning = TSM.Load.LoadSpanningEnum.LOAD_SPANNING_SINGLE;
            L.Weight = 2;
            L.CreateFixedSupportConditionsAutomatically = true;

            L.LoadAttachment = TSM.Load.LoadAttachmentEnum.LOAD_ATTACHMENT_ATTACH_TO_MEMBER;

            if (!L.Insert())
            {
                WriteLine("LoadLineTest failed - unable to create load line");
                MessageBox.Show("Insert load line failed!");
                return;
            }
            else
            {
                ObjectList.Add(L);
            }
            WriteLine("LoadLine ID " + " " + L.Identifier.ID.ToString());

            LoadLine LSel = new LoadLine();
            LSel.Identifier = L.Identifier;

            if (!LSel.Select())
                WriteLine("LoadLine Select failed!");
            WriteLine(LSel.Identifier.ID.ToString());

            L.P1 = new Vector(0000, 0000, -2000);
            L.P2 = new Vector(0000, 0000, -3000);
            L.DistanceA = 15;
            L.DistanceB = 16;
            L.Torsion1 = 1500;
            L.Torsion2 = 2500;
            L.Position1 = new TS.Point(4000, 24000, 0);
            L.Position2 = new TS.Point(5000, 24000, 0);
            L.LoadForm = LoadLine.LineLoadFormEnum.LOAD_FORM_LINE_2;

            //LP.FatherId = FatherBeam.Identifier; //Can't be changed, at least not right now

            L.AutomaticPrimaryAxisWeight = false;
            L.BoundingBoxDx = 1500;
            L.BoundingBoxDy = 1500;
            L.BoundingBoxDz = 1500;
            L.LoadDispersionAngle = 0.99;
            L.PartFilter = "testing modified";
            L.PartNames = TSM.Load.LoadPartNamesEnum.LOAD_PART_NAMES_EXCLUDE;
            L.PrimaryAxisDirection = new Vector(2000, 1500, 0);
            L.Spanning = TSM.Load.LoadSpanningEnum.LOAD_SPANNING_DOUBLE;
            L.Weight = 5;
            L.CreateFixedSupportConditionsAutomatically = false;

            L.LoadAttachment = TSM.Load.LoadAttachmentEnum.LOAD_ATTACHMENT_DONT_ATTACH; //Can't be Set atm

            if (!L.Modify())
                WriteLine("LoadLine Modify failed!");
            WriteLine(L.Identifier.ID.ToString());
            WriteLine("LoadLine complete!");
        }

        private void LoadUniformTest()
        {
            LoadUniform L = new LoadUniform();
            L.P1 = new Vector(1000, 2000, 3000);
            L.DistanceA = 5;
            L.Polygon.Points.Add(new TS.Point(5000, 24000, 0));
            L.Polygon.Points.Add(new TS.Point(7000, 24000, 0));
            L.Polygon.Points.Add(new TS.Point(8000, 26000, 0));
            L.Polygon.Points.Add(new TS.Point(5000, 26000, 0));

            //L.FatherId = FatherBeam.Identifier;

            L.AutomaticPrimaryAxisWeight = true;
            L.BoundingBoxDx = 500;
            L.BoundingBoxDy = 500;
            L.BoundingBoxDz = 500;
            L.LoadDispersionAngle = 0.77;
            L.PartFilter = "testing";
            L.PartNames = TSM.Load.LoadPartNamesEnum.LOAD_PART_NAMES_INCLUDE; ;
            L.PrimaryAxisDirection = new Vector(1000, 500, 0);
            L.Spanning = TSM.Load.LoadSpanningEnum.LOAD_SPANNING_SINGLE;
            L.Weight = 2;
            L.CreateFixedSupportConditionsAutomatically = true;

            L.LoadAttachment = TSM.Load.LoadAttachmentEnum.LOAD_ATTACHMENT_DONT_ATTACH;

            if (!L.Insert())
            {
                WriteLine("LoadUniformTest failed - unable to create load uniform");
                MessageBox.Show("Insert load uniform failed!");
                return;
            }
            else
            {
                ObjectList.Add(L);
            }
            WriteLine("LoadLine ID " + " " + L.Identifier.ID.ToString());

            LoadUniform LSel = new LoadUniform();
            LSel.Identifier = L.Identifier;

            if (!LSel.Select())
                WriteLine("LoadUniform Select failed!");
            WriteLine(LSel.Identifier.ID.ToString());

            L.P1 = new Vector(11000, 12000, 13000);
            L.DistanceA = 15;

            //LP.FatherId = FatherBeam.Identifier; //Can't be changed, at least not right now

            L.AutomaticPrimaryAxisWeight = false;
            L.BoundingBoxDx = 1500;
            L.BoundingBoxDy = 1500;
            L.BoundingBoxDz = 1500;
            L.LoadDispersionAngle = 0.99;
            L.PartFilter = "testing modified";
            L.PartNames = TSM.Load.LoadPartNamesEnum.LOAD_PART_NAMES_EXCLUDE;
            L.PrimaryAxisDirection = new Vector(2000, 1500, 0);
            L.Spanning = TSM.Load.LoadSpanningEnum.LOAD_SPANNING_DOUBLE;
            L.Weight = 5;
            L.CreateFixedSupportConditionsAutomatically = false;

            L.LoadAttachment = TSM.Load.LoadAttachmentEnum.LOAD_ATTACHMENT_DONT_ATTACH;

            if (!L.Modify())
                WriteLine("LoadUniform Modify failed!");
            WriteLine(L.Identifier.ID.ToString());
            WriteLine("LoadUniform complete!");
        }

        private void GetAndSetPropertyTest()
        {
            WriteLine("Starting GetAndSetPropertyTest...");

            TS.Point point = new TS.Point(3000, 0, 0);
            TS.Point point2 = new TS.Point(4000, 0, 0);

            Beam B = new Beam(point, point2);

            B.Profile.ProfileString = "HI400-15-20*400";
            B.Material.MaterialString = "Steel_Undefined";
            B.Finish = "PAINT";
            if (!B.Insert())
            {
                WriteLine("GetAndSetPropertyTest failed - unable to create beam");
                MessageBox.Show("Insert beam failed!");
                return;
            }
            else
            {
                ObjectList.Add(B);
            }

            WriteLine(B.Identifier.ID.ToString());
            
            if (!B.SetUserProperty("comment", "Test comment"))
                WriteLine("SetProperty failed!");
            if (!B.SetUserProperty("fabricator", "Test fabricator"))
                WriteLine("SetProperty failed!");
            if (!B.SetUserProperty("AD_n_part_splits", 66))
                WriteLine("SetProperty failed!");

            string commentVal = "";
            string fabVal = "";
            int splitsVal = 0;
            if (!B.GetUserProperty("comment", ref commentVal))
                WriteLine("GetProperty failed!");
            if (!B.GetUserProperty("fabricator", ref fabVal))
                WriteLine("GetProperty failed!");
            if (!B.GetUserProperty("AD_n_part_splits", ref splitsVal))
                WriteLine("GetProperty failed!");

            // Test report GETTERS
            string AssPos = "";
            double COG = 0.0;
            int CurrPhase = 0;
            string ProjName = "";
            if (!B.GetReportProperty("ASSEMBLY_POS", ref AssPos))
                WriteLine("GetReportProperty failed!!!");
            if (!B.GetReportProperty("COG_X", ref COG))
                WriteLine("GetReportProperty failed!!!");
            if (!B.GetReportProperty("PROJECT.CURRENT_PHASE", ref CurrPhase))
                WriteLine("GetReportProperty failed!!!");
            if (!B.GetReportProperty("PROJECT.NAME", ref ProjName))
                WriteLine("GetReportProperty failed!!!");

            WriteLine("GetAndSetPropertyTest complete!");
        }

        private void HandlePart(Part Part)
        {
            WriteLine(Part.Identifier.ID + " was a part, printing solid and coordsys...");
            Solid Solid = Part.GetSolid();

            if (Solid != null)
            {
                WriteLine(Solid.MinimumPoint.ToString());
                WriteLine(Solid.MaximumPoint.ToString());
            }
            CoordinateSystem CoordinateSystem = Part.GetCoordinateSystem();
            WriteLine("O: " + CoordinateSystem.Origin);
            WriteLine("X: " + CoordinateSystem.AxisX);
            WriteLine("Y: " + CoordinateSystem.AxisY);
            WriteLine("Part class is " + Part.Class);

            ModelObjectEnumerator Enum2 = Part.GetChildren();
            WriteLine("Number of children for the part is " + Enum2.GetSize());

            ModelObjectEnumerator ConnectedEnum = Part.GetBolts();
            WriteLine("Part " + Part.Identifier.ID + " has " + ConnectedEnum.GetSize() + " connected bolt groups");
            while (ConnectedEnum.MoveNext())
            {
                BoltGroup Connected = ConnectedEnum.Current as BoltGroup;
                WriteLine(Connected.Identifier.ID.ToString());
            }

            ConnectedEnum = Part.GetBooleans();
            WriteLine("Part " + Part.Identifier.ID + " has " + ConnectedEnum.GetSize() + " connected boolean objets");
            while (ConnectedEnum.MoveNext())
            {
                Tekla.Structures.Model.Boolean Connected = ConnectedEnum.Current as Tekla.Structures.Model.Boolean;
                WriteLine(Connected.Identifier.ID.ToString());
            }

            ConnectedEnum = Part.GetWelds();
            WriteLine("Part " + Part.Identifier.ID + " has " + ConnectedEnum.GetSize() + " connected welds");
            while (ConnectedEnum.MoveNext())
            {
                WriteLine(ConnectedEnum.Current.Identifier.ID.ToString());
            }

            ConnectedEnum = Part.GetComponents();

            WriteLine("Part " + Part.Identifier.ID + " has " + ConnectedEnum.GetSize() + " connected components");
            while (ConnectedEnum.MoveNext())
            {
                BaseComponent Connected = ConnectedEnum.Current as BaseComponent;
                WriteLine(Connected.Identifier.ID.ToString());
            }

            Assembly Ass = Part.GetAssembly();
            if (Ass != null)
            {
                ArrayList List = Ass.GetSubAssemblies();
                WriteLine("Number of subasseblies is " + List.Count);
            }
        }

        private void EnumTest(Model Model)
        {
            int Counter = 0;
            int PartCounter = 0;
            int BooleanCounter = 0;
            int WeldCounter = 0;
            int ReinforcementCounter = 0;
            int CutPlaneCounter = 0;
            int FittingCounter = 0;
            int CastUnitCounter = 0;
            int ControlPlaneCounter = 0;
            int SurfaceTreatmentCounter = 0;
            int BoltGroupCounter = 0;
            int LoadCounter = 0;
            ArrayList Parts = new ArrayList();

            WriteLine("Starting EnumTest...");
            ModelObjectEnumerator Enum = Model.GetModelObjectSelector().GetAllObjects();

            while (Enum.MoveNext())
            {
                WriteLine("-------------------------------------");
                WriteLine("Moving to object number " + Counter++ + " ID " + ((ModelObject)Enum.Current).Identifier.ID.ToString());

                Part Part = Enum.Current as Part;
                if (Part != null)
                {
                    PartCounter++;
                    HandlePart(Part);
                    Parts.Add(Part);
                    continue;
                }

                Tekla.Structures.Model.Boolean Bool = Enum.Current as Tekla.Structures.Model.Boolean;
                if (Bool != null)
                {
                    CutPlane CutPlane = Enum.Current as CutPlane;
                    if (CutPlane != null)
                    {
                        CutPlaneCounter++;
                        WriteLine(CutPlane.Identifier.ID + " was a cutplane, printing father id...");
                        WriteLine("CutPlane Father Object ID is " + CutPlane.Father.Identifier.ID.ToString());
                        continue;
                    }
                    Fitting Fitting = Enum.Current as Fitting;
                    if (Fitting != null)
                    {
                        FittingCounter++;
                        WriteLine(Fitting.Identifier.ID + " was a fitting, printing main father id...");
                        WriteLine("Fitting Father Object ID is " + Fitting.Father.Identifier.ID.ToString());
                        continue;
                    }

                    WriteLine("it was a Boolean with father " + Bool.Father.Identifier.ID.ToString());
                    BooleanCounter++;
                    continue;
                }

                Weld Weld = Enum.Current as Weld;
                if (Weld != null)
                {
                    WeldCounter++;
                    WriteLine("it was a weld, printing main and secondary object ids...");
                    WriteLine("Weld Main Object ID is " + Weld.MainObject.Identifier.ID.ToString());
                    WriteLine("Weld Seconardy Object ID is " + Weld.SecondaryObject.Identifier.ID.ToString());

                    continue;
                }

                Reinforcement Reinforcement = Enum.Current as Reinforcement;
                if (Reinforcement != null)
                {
                    ReinforcementCounter++;
                    if (Reinforcement as SingleRebar != null)
                        WriteLine(Reinforcement.Identifier.ID + " was a reinforcement (a SingleRebar), printing father object id and the name of the rebar...");
                    else if (Reinforcement as RebarGroup != null)
                        WriteLine(Reinforcement.Identifier.ID + " was a reinforcement (a RebarGroup), printing father object id and the name of the rebar...");
                    else if (Reinforcement as RebarMesh != null)
                        WriteLine(Reinforcement.Identifier.ID + " was a reinforcement (a RebarMesh), printing father object id and the name of the rebar...");
                    else if (Reinforcement as RebarStrand != null)
                        WriteLine(Reinforcement.Identifier.ID + " was a reinforcement (a RebarStrand), printing father object id and the name of the rebar...");
                    else
                        WriteLine(Reinforcement.Identifier.ID + " was a reinforcement, printing father object id and the name of the rebar...");
                    WriteLine("Reinforcement Father Object ID is " + Reinforcement.Father.Identifier.ID.ToString());
                    WriteLine("Reinforcement name is " + Reinforcement.Name);
                    continue;
                }

                ControlPlane ControlPlane = Enum.Current as ControlPlane;
                if (ControlPlane != null)
                {
                    ControlPlaneCounter++;
                    WriteLine("it was a ControlPlane, printing ID...");

                    WriteLine("ControlPlane ID is " + ControlPlane.Identifier.ID.ToString());
                    continue;
                }

                SurfaceTreatment SurfaceTreatment = Enum.Current as SurfaceTreatment;
                if (SurfaceTreatment != null)
                {
                    SurfaceTreatmentCounter++;
                    WriteLine("it was a SurfaceTreatment, printing ID...");

                    WriteLine("SurfaceTreatment ID is " + SurfaceTreatment.Identifier.ID.ToString());
                    continue;
                }

                BoltGroup BG = Enum.Current as BoltGroup;
                if (BG != null)
                {
                    BoltGroupCounter++;
                    if (BG as BoltArray != null)
                        WriteLine(BG.Identifier.ID + " was a BoltGroup (a BoltArray), printing Part to be bolted ID and Part to bolt to ID of the boltgroup...");
                    else if (BG as BoltCircle != null)
                        WriteLine(BG.Identifier.ID + " was a BoltGroup (a BoltCircle), printing Part to be bolted ID and Part to bolt to ID of the boltgroup...");
                    else if (BG as BoltXYList != null)
                        WriteLine(BG.Identifier.ID + " was a BoltGroup (a BoltXYList), printing Part to be bolted ID and Part to bolt to ID of the boltgroup...");
                    else
                        WriteLine(BG.Identifier.ID + " was of an unknown BoltGroup type, printing Part to be bolted ID and Part to bolt to ID of the boltgroup...");
                    if (BG.PartToBeBolted != null)
                        WriteLine("Part to be bolted ID is " + BG.PartToBeBolted.Identifier.ID.ToString());
                    if (BG.PartToBoltTo != null)
                        WriteLine("Part to bolt to ID is " + BG.PartToBoltTo.Identifier.ID.ToString());
                    continue;
                }

                Load L = Enum.Current as Load;
                if (L != null)
                {
                    LoadCounter++;
                    if (L as LoadArea != null)
                        WriteLine(L.Identifier.ID + " was a Load (a LoadArea), printing Father ID...");
                    else if (L as LoadLine != null)
                        WriteLine(L.Identifier.ID + " was a Load (a LoadLIne), printing Father ID...");
                    else if (L as LoadPoint != null)
                        WriteLine(L.Identifier.ID + " was a Load (a LoadPoint), printing Father ID...");
                    else if (L as LoadUniform != null)
                        WriteLine(L.Identifier.ID + " was a Load (a LoadUniform), printing Father ID...");
                    else
                        WriteLine(L.Identifier.ID + " was of an unknown Load type, printing Father ID...");
                    WriteLine("Father ID is " + L.FatherId.ID);
                    continue;
                }

                //                WriteLine("it was of type " + Enum.Current.GetType());
            }

            WriteLine("-------------------------------------");
            WriteLine("Found " + PartCounter.ToString() + " Parts" + ", " + BooleanCounter.ToString() + " Booleans, " +
                WeldCounter.ToString() + " Welds, " + ReinforcementCounter.ToString() + " Reinforcements, " +
                FittingCounter.ToString() + " Fittings, " + CutPlaneCounter + " Cuttings and " +
                CastUnitCounter.ToString() + " CastUnits, " + ControlPlaneCounter.ToString() + " ControlPlanes, " +
                SurfaceTreatmentCounter.ToString() + " SurfaceTreatments, " +
                BoltGroupCounter.ToString() + " BoltGroups, " +
                LoadCounter.ToString() + " Loads.");

            Tekla.Structures.Model.UI.ModelObjectSelector Selector = new Tekla.Structures.Model.UI.ModelObjectSelector();
            Selector.Select(Parts);    // Select all parts from model
        }

        private void FilterTest(Model Model)
        {
            string FilterName = "testfilter";
            int Counter = 0;

            WriteLine("Starting FilterTest...");
            ModelObjectEnumerator Enum = Model.GetModelObjectSelector().GetObjectsByFilterName(FilterName);

            while (Enum.MoveNext())
            {
                WriteLine("-------------------------------------");
                WriteLine("Moving to object number " + Counter++);

                Part Part = Enum.Current as Part;
                if (Part != null)
                {
                    WriteLine(Part.Identifier.ID + " was a part, matched filter " + FilterName);
                }
                else
                {
                    WriteLine(Part.Identifier.ID + " was not a part...");
                }
            }
            WriteLine("Total number of " + Counter + " objects matched filter " + FilterName);
            return;
        }

        private void SolidTest(Model Model)
        {
            WriteLine("Starting BeamSolidTest...");
            TS.Point point = new TS.Point(5000, 0, 0);
            TS.Point point2 = new TS.Point(7000, 0, 0);

            Beam Beam = new Beam(point, point2);

            Beam.Profile.ProfileString = "PL500*200";
            Beam.Material.MaterialString = "Steel_Undefined";
            Beam.Name = "SolidTestBeam";
            Beam.Finish = "Normal";
            Beam.Class = "5";
            if (!Beam.Insert())
            {
                WriteLine("SolidTest failed - unable to create beam");
                MessageBox.Show("Insert beam failed!");
                return;
            }
            else
            {
                ObjectList.Add(Beam);
            }
            WriteLine(Beam.Identifier.ID.ToString());

            if (!Beam.Select())
                WriteLine("Select failed!");
            WriteLine(Beam.Identifier.ID.ToString());

            Solid Solid = Beam.GetSolid();

            FaceEnumerator FaceEnum = Solid.GetFaceEnumerator();

            int nFaces = 0, nLoops = 0, nVertexes = 0;

            while (FaceEnum.MoveNext())
            {
                nFaces++;
                nLoops = 0;

                Face Face = FaceEnum.Current as Face;
                LoopEnumerator LoopEnum = Face.GetLoopEnumerator();

                while (LoopEnum.MoveNext())
                {
                    nLoops++;
                    nVertexes = 0;

                    Loop Loop = LoopEnum.Current as Loop;
                    VertexEnumerator VertexEnum = Loop.GetVertexEnumerator();

                    while (VertexEnum.MoveNext())
                    {
                        nVertexes++;

                        WriteLine("Solid " + Beam.Identifier.ID + " Face " + nFaces +
                            " Loop " + nLoops + " Vertex " + nVertexes);
                        TS.Point Vertex = VertexEnum.Current as TS.Point;
                        WriteLine(Vertex.ToString());
                    }
                }
            }

            WriteLine(Beam.Identifier.ID.ToString());
            WriteLine("BeamSolidTest complete!");
        }

        private void TransformationPlaneTest(Model Model)
        {
            WriteLine("Starting TransformationPlaneTest...");

            WorkPlaneHandler PlaneHandler = Model.GetWorkPlaneHandler();
            TransformationPlane CurrentPlane = PlaneHandler.GetCurrentTransformationPlane();

            WriteLine("Current plane in the model:");
            WriteLine(CurrentPlane.ToString());

            Beam Beam = new Beam(new TS.Point(0, 7000, 0), new TS.Point(0, 8000, 0));

            Beam.Profile.ProfileString = "HI400-15-20*400";
            Beam.Material.MaterialString = "Steel_Undefined";
            Beam.Finish = "PAINT";
            if (!Beam.Insert())
            {
                WriteLine("TransformationPlaneTest failed - unable to create Beam");
                MessageBox.Show("Insert Beam failed!");
                return;
            }
            else
            {
                ObjectList.Add(Beam);
            }
            Beam.Select();

            WriteLine("Change current plane to object " + Beam.Identifier.ID + " plane");
            TransformationPlane Plane = new TransformationPlane(Beam.GetCoordinateSystem());
            PlaneHandler.SetCurrentTransformationPlane(Plane);

            Plane = PlaneHandler.GetCurrentTransformationPlane();
            WriteLine("Current plane in the model after change:");
            WriteLine(Plane.ToString());

            WriteLine("Change plane to global:");
            TransformationPlane GlobalPlane = new TransformationPlane();
            WriteLine(GlobalPlane.ToString());
            PlaneHandler.SetCurrentTransformationPlane(GlobalPlane);

            WriteLine("And get it from model:");
            Plane = PlaneHandler.GetCurrentTransformationPlane();
            WriteLine(Plane.ToString());

            WriteLine("Then set plane back to original:");
            PlaneHandler.SetCurrentTransformationPlane(CurrentPlane);
            WriteLine(CurrentPlane.ToString());
        }

        private void SolidLineIntersectionTest(Model Model)
        {
            WriteLine("Starting SolidIntersectionTest...");
            TS.Point point1 = new TS.Point(5000, 4000, 0);
            TS.Point point2 = new TS.Point(10000, 4000, 0);

            Beam Beam = new Beam(point1, point2);

            Beam.Profile.ProfileString = "PL500*200";
            Beam.Material.MaterialString = "Steel_Undefined";
            Beam.Name = "SolidLine";
            Beam.Finish = "Normal";
            Beam.Class = "5";
            if (!Beam.Insert())
            {
                WriteLine("SolidLineIntersectionTest failed - unable to create Beam");
                MessageBox.Show("Insert Beam failed!");
                return;
            }
            else
            {
                ObjectList.Add(Beam);
            }
            WriteLine(Beam.Identifier.ID.ToString());

            if (!Beam.Select())
                WriteLine("Select failed!");
            WriteLine(Beam.Identifier.ID.ToString());

            Solid Solid = Beam.GetSolid();

            ArrayList Points = Solid.Intersect(new TS.Point(8000, -1000, -100), new TS.Point(8000, 9000, -100));
            WriteLine("Got " + Points.Count + " line intersection points");
            IEnumerator PointsEnum = Points.GetEnumerator();

            while (PointsEnum.MoveNext())
            {
                TS.Point Point = PointsEnum.Current as TS.Point;

                WriteLine("Point: " + Point);
            }
        }

        private void SolidPlaneIntersectionTest()
        {
            Beam Beam = new Beam(new TS.Point(500, 500, -1000), new TS.Point(500, 500, 1000));

            Beam.Profile.ProfileString = "RHS150*5";
            Beam.Material.MaterialString = "Steel_Undefined";
            Beam.Name = "SolidPlane";
            Beam.Finish = "Normal";
            Beam.Class = "6";
            if (!Beam.Insert())
            {
                WriteLine("SolidPlaneIntersectionTest failed - unable to create Beam");
                MessageBox.Show("Insert Beam failed!");
                return;
            }
            else
            {
                ObjectList.Add(Beam);
            }
            WriteLine(Beam.Identifier.ID.ToString());

            if (!Beam.Select())
                WriteLine("Select failed!");
            WriteLine(Beam.Identifier.ID.ToString());

            Solid Solid = Beam.GetSolid();

            var Points = Solid.IntersectAllFaces(new TS.Point(0, 0, 0), 
                new TS.Point(1000, 0, 0), new TS.Point(0, 1000, 0));
            
            //IEnumerator LoopsEnum = Points.GetEnumerator();
            int nLoops = 0;
            int nPoints = 0;

            while (Points.MoveNext())
            {
                nPoints = 0;
                nLoops++;
                ArrayList LoopPoints = Points.Current as ArrayList;
                IEnumerator LoopPointsEnum = LoopPoints.GetEnumerator();

                WriteLine(nLoops + ". Loop: " + LoopPoints.Count + " plane intersection points");

                while (LoopPointsEnum.MoveNext())
                {
                    nPoints++;
                    TS.Point Point = LoopPointsEnum.Current as TS.Point;
                    WriteLine("   " + nPoints + ". Point: " + Point);
                }
            }

            WriteLine("Got " + nLoops + " plane intersection loops");
        }

        private void GetCoordSysTest()
        {
            //TODO - Make sure we get a meaningful test here...
            WriteLine("Starting Get CoordSys Test...");

            TS.Point point = new TS.Point(0, 0, 0);
            TS.Point point2 = new TS.Point(1000, 0, 0);

            Beam Beam = new Beam(point, point2);

            Beam.Profile.ProfileString = "HI400-15-20*400";
            Beam.Finish = "PAINT";
            if (!Beam.Insert())
                WriteLine("Insert failed!");
            else
                ObjectList.Add(Beam);
            WriteLine(Beam.Identifier.ID.ToString());

            Beam.Select();

            CoordinateSystem Test1 = Beam.GetCoordinateSystem();

            WriteLine("CoordSys Test complete!");
        }

        private void ComponentTest()
        {
            WriteLine("Starting Component Test...");

            Beam B = new Beam(new TS.Point(12000, 0, 0), new TS.Point(12000, 0, 6000));
            B.Profile.ProfileString = "380*380";
            B.Material.MaterialString = "Concrete_Undefined";
            if (B.Insert())
            {
                ObjectList.Add(B);
                TSM.Component C = new TSM.Component();
                C.Name = "Component Test";
                C.Number = 30000063;

                ComponentInput CI = new ComponentInput();
                CI.AddInputObject(B);

                C.SetComponentInput(CI);

                C.LoadAttributesFromFile("standard");

                C.SetAttribute("side_bar_space", 333.0);

                if (!C.Insert())
                {
                    WriteLine("ComponentTest failed - unable to create Component");
                    MessageBox.Show("Insert component failed!");
                    return;
                }
                else
                {
                    ObjectList.Add(C);
                }
                WriteLine(C.Identifier.ID.ToString());

                Double DValue = 0.0;
                if (!C.GetAttribute("side_bar_space", ref DValue) || DValue != 333)
                    WriteLine("Component GetAttribute failed");
            }
            else
            {
                WriteLine("Unable to perform the Component test, creation of the concrete column failed");
            }

            WriteLine("Component Test complete!");
        }

        private void ConnectionTest()
        {
            WriteLine("Starting Connection Test...");

            Beam B1 = new Beam(new TS.Point(15000, 0, -500), new TS.Point(15000, 0, 6000));
            B1.Profile.ProfileString = "HI400-15-20*400";
            B1.Material.MaterialString = "Steel_Undefined";

            Beam B2 = new Beam(new TS.Point(15000, 0, 0), new TS.Point(18000, 0, 0));
            B2.Profile.ProfileString = "HI300-15-20*300";
            B2.Material.MaterialString = "Steel_Undefined";

            if (B1.Insert() && B2.Insert())
            {
                ObjectList.Add(B1);
                ObjectList.Add(B2);
                Connection C = new Connection();
                C.Name = "Test End Plate";
                C.Number = 144;
                C.LoadAttributesFromFile("standard");
                C.UpVector = new Vector(0, 0, 1000);
                C.PositionType = PositionTypeEnum.COLLISION_PLANE;

                C.SetPrimaryObject(B1);
                C.SetSecondaryObject(B2);

                C.SetAttribute("e2", 10.0);
                C.SetAttribute("e1", 10.0);

                if (!C.Insert())
                {
                    WriteLine("PolyBeamTest failed - unable to create connection");
                    MessageBox.Show("Insert connection failed!");
                    return;
                }
                else
                {
                    ObjectList.Add(C);
                }
                WriteLine(C.Identifier.ID.ToString());

                Double DValue = 0.0;
                if (!C.GetAttribute("e2", ref DValue) || DValue != 10)
                    WriteLine("Connection GetAttribute failed");

                Connection CSel = new Connection();
                CSel.Identifier.ID = C.Identifier.ID;
                if (!CSel.Select() || CSel.PositionType != PositionTypeEnum.COLLISION_PLANE)
                    WriteLine("Select failed");
            }
            else
            {
                WriteLine("Unable to perform the connection test, creation of the main and secondary parts failed");
            }

            WriteLine("Connection Test complete!");
        }

        private void SeamTest()
        {
            WriteLine("Starting Seam Test...");

            Beam B1 = new Beam(new TS.Point(15000, 3000, 0), new TS.Point(21000, 3000, 0));
            B1.Profile.ProfileString = "780*380";
            B1.Material.MaterialString = "Concrete_Undefined";
            B1.Class = "5";
            B1.Position.Plane = Position.PlaneEnum.MIDDLE;
            B1.Position.Rotation = Position.RotationEnum.TOP;
            B1.Position.Depth = Position.DepthEnum.BEHIND;

            Beam B2 = new Beam(new TS.Point(15000, 3000, 0), new TS.Point(21000, 3000, 0));
            B2.Profile.ProfileString = "780*380";
            B2.Material.MaterialString = "Concrete_Undefined";
            B2.Class = "6";
            B2.Position.Plane = Position.PlaneEnum.MIDDLE;
            B2.Position.Rotation = Position.RotationEnum.TOP;
            B2.Position.Depth = Position.DepthEnum.FRONT;

            if (B1.Insert() && B2.Insert())
            {
                ObjectList.Add(B1);
                ObjectList.Add(B2);
                Seam S = new Seam();
                S.Name = "seamdm";
                S.Number = -1;
                S.LoadAttributesFromFile("standard");
                S.UpVector = new Vector(0, 0, 0);
                S.AutoDirectionType = AutoDirectionTypeEnum.AUTODIR_BASIC;
                S.AutoPosition = true;

                S.SetPrimaryObject(B1);
                S.SetSecondaryObject(B2);

                S.SetInputPositions(new TS.Point(15000, 3000, 0), new TS.Point(21000, 3000, 0));

                if (!S.Insert())
                {
                    WriteLine("Seam Insert failed, please check that you have the seam called \"seamdm\" in your model.");
                    WriteLine(S.Identifier.ID.ToString());
                }
                else
                {
                    ObjectList.Add(S);
                    Connection SSel = new Connection();
                    SSel.Identifier.ID = S.Identifier.ID;
                    if (!SSel.Select())
                        WriteLine("Select failed");
                }
            }
            else
            {
                WriteLine("Unable to perform the Seam test, creation of the main and secondary parts failed");
            }

            WriteLine("Seam Test complete!");
        }

        private void TaperedCustomPartTest()
        {
            WriteLine("Starting TaperedCustomPart Test...");

            ComponentInput CI = new ComponentInput();
            CI.AddOneInputPosition(new TS.Point(5000, 0, 0));

            TSM.Component C = new TSM.Component(CI);

            C.Name = "COL8";
            C.Number = -1;
            C.LoadAttributesFromFile("standard");

            C.SetAttribute("P7", 8.0);
            C.SetAttribute("P1", 8000.0);

            if (C.Insert())
            {
                ObjectList.Add(C);
                ModelObjectEnumerator Enum2 = C.GetChildren();
                WriteLine("Number of children for the part is " + Enum2.GetSize());
            }
            else
            {
                WriteLine("Creation of COL8 failed, please check that you have the \"COL8\" in your model.");
            }
        }

        private void TaperedBeamTest()
        {
            WriteLine("Starting TaperedBeam Test...");

            for (int i = 0; i < 1; i++)
            {
                ComponentInput CI = new ComponentInput();
                CI.AddOneInputPosition(new TS.Point(500 * i, 0, 0));
                CI.AddOneInputPosition(new TS.Point(500 * i, 6000, 0));

                TSM.Component C = new TSM.Component(CI);

                C.Name = "TaperedBeam";
                C.Number = 1000045;
                C.LoadAttributesFromFile("standard");

                C.SetAttribute("end_height", 500.0);
                C.SetAttribute("stp_height", 800.0);

                if (C.Insert())
                    ObjectList.Add(C);
                else
                    WriteLine("Creation of TaperedBeam failed!");
            }
            WriteLine("Completed TaperedBeam Test!");
        }

        private void DetailTest()
        {
            WriteLine("Starting Detail Test...");

            Beam B = new Beam(new TS.Point(13000, 3000, -500), new TS.Point(13000, 3000, 6000));
            B.Profile.ProfileString = "HI400-15-20*400";
            B.Material.MaterialString = "Steel_Undefined";

            if (B.Insert())
            {
                ObjectList.Add(B);

                Detail D = new Detail();
                D.Name = "Test End Plate Detail";
                D.Number = 1002;
                D.LoadAttributesFromFile("standard");
                D.UpVector = new Vector(0, 0, 0);
                D.PositionType = PositionTypeEnum.MIDDLE_PLANE;
                D.AutoDirectionType = AutoDirectionTypeEnum.AUTODIR_DETAIL;
                D.DetailType = DetailTypeEnum.END;

                D.SetPrimaryObject(B);
                D.SetReferencePoint(new TS.Point(13000, 3000, 3000));

                D.SetAttribute("el", 33.0);
                D.SetAttribute("er", 33.0);

                if (!D.Insert())
                    WriteLine("Detail Insert failed");
                else
                    ObjectList.Add(D);
                WriteLine(D.Identifier.ID.ToString());

                Double DValue = 0.0;
                if (!D.GetAttribute("er", ref DValue) || DValue != 33)
                    WriteLine("Detail GetAttribute failed");

                Detail DSel = new Detail();
                DSel.Identifier.ID = D.Identifier.ID;
                if (!DSel.Select() || DSel.AutoDirectionType != AutoDirectionTypeEnum.AUTODIR_DETAIL)
                    WriteLine("Detail Select failed");
            }
            else
            {
                WriteLine("Unable to perform the Detail test, creation of the primary part failed");
            }

            WriteLine("Detail Test complete!");
        }

        private void DeleteAll(Model Model)
        {
            int Counter = 0;

            WriteLine("Starting DeleteAll...");

            IEnumerator Enum = ObjectList.GetEnumerator();
            while (Enum.MoveNext())
            {
                WriteLine("Deleting object number " + Counter++);
                ModelObject MO = Enum.Current as ModelObject;
                if (MO != null)
                    MO.Delete();
                else
                    WriteLine("Object already deleted or unsupported!");
            }
            WriteLine("All created objects deleted, have fun!");
        }

        private void RunTest(string test)
        {
            if (test.Equals("All") || test.Equals("BeamTest"))
                BeamTest();
            if (test.Equals("All") || test.Equals("PolyBeamTest"))
                PolyBeamTest();
            if (test.Equals("All") || test.Equals("ContourPlateTest"))
                ContourPlateTest();
            if (test.Equals("All") || test.Equals("BooleanTests"))
            {
                BooleanPartTest();
                CutTest();
                FittingTest();
            }
            if (test.Equals("All") || test.Equals("WeldTest"))
                WeldTest();
            if (test.Equals("All") || test.Equals("CastUnitTest"))
                CastUnitTest();
            if (test.Equals("All") || test.Equals("PlaneTests"))
            {
                ControlPlaneTest();
                TransformationPlaneTest(Model);
                Grid grid = GridTest();
            }
            if (test.Equals("All") || test.Equals("RebarTests"))
            {
                SingleRebarTest();
                RebarGroupTest1();
                RebarGroupTest2();
                RebarGroupTest3();
                RebarGroupTest4();
                RebarSpliceTest();
            }
            if (test.Equals("All") || test.Equals("AssemblyTest"))
            {
                AssemblyTest();
                GetPartMarkTest();
                GetAndSetPropertyTest();
            }
            if (test.Equals("All") || test.Equals("SurfaceTreatmentTest"))
                SurfaceTreatmentTest();
            if (test.Equals("All") || test.Equals("BoltTests"))
            {
                BoltArrayTest();
                BoltXYListTest();
                BoltCircleTest();
            }
            if (test.Equals("All") || test.Equals("LoadTests"))
            {
                LoadPointTest();
                LoadAreaTest();
                LoadLineTest();
                LoadUniformTest();
            }
            if (test.Equals("All") || test.Equals("EnumerationTest"))
            {
                EnumTest(Model);
                FilterTest(Model);
            }
            if (test.Equals("All") || test.Equals("SolidTests"))
            {
                SolidTest(Model);
                SolidLineIntersectionTest(Model);
                SolidPlaneIntersectionTest();
            }
            if (test.Equals("All") || test.Equals("ComponentTests"))
            {
                ConnectionTest();
                ComponentTest();
                TaperedBeamTest();
                //TaperedCustomPartTest(); //COL8 custom part should be available to insert
                DetailTest();
                //SeamTest(); // Model should have seamdm seam connection
            }
            Model.CommitChanges();
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            foreach (object itemChecked in checkedListBox1.CheckedItems)
                RunTest(itemChecked.ToString());
        }

        private void button1_Click_1(object sender, System.EventArgs e)
        {
            DeleteAll(Model);
            Model.CommitChanges();
            ObjectList.Clear();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            checkedListBox1.SetItemChecked(0, true);
        }
    }

    public class Epsilon
    {
        public static double Value = 1E-3;
    }
}
