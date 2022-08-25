using Tekla.Structures.Drawing;
using Tekla.Structures.Drawing.UI;
using Tekla.Structures.Geometry3d;
using System;
using System.Windows.Forms;
using Tekla.Structures;

namespace LevelMarkTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void SetDataToForm(Tekla.Structures.Drawing.LevelMark levelMark)
        {
            this.Text = "Level Mark Test";
            if(levelMark == null)
                return;

            var prop = levelMark.GetType().GetProperty("Identifier", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            Identifier id =  prop.GetValue(levelMark) as Identifier;

            if(id != null)
                this.Text = $"Level Mark ID:{id.ID}";

            tb_AssociatedObject.Text = levelMark.ModelObjectIdentifier.ID.ToString();

            if(levelMark.SubType == Tekla.Structures.Drawing.LevelMark.LevelMarkType.NoArrowNoLeaderLine)
                cb_SubType.SelectedIndex = 0;
            else if(levelMark.SubType == Tekla.Structures.Drawing.LevelMark.LevelMarkType.ArrowWithoutLeaderLine)
                cb_SubType.SelectedIndex = 1;
            else if(levelMark.SubType == Tekla.Structures.Drawing.LevelMark.LevelMarkType.InclinedLeaderLine)
                cb_SubType.SelectedIndex = 2;
            else if(levelMark.SubType == Tekla.Structures.Drawing.LevelMark.LevelMarkType.OrthogonalLeaderLine)
                cb_SubType.SelectedIndex = 3;
            else
                cb_Color.SelectedIndex = -1;

            tb_insertionPoint_X.Text = levelMark.InsertionPoint.X.ToString();
            tb_insertionPoint_Y.Text = levelMark.InsertionPoint.Y.ToString();
            tb_insertionPoint_Z.Text = levelMark.InsertionPoint.Z.ToString();
            tb_basePoint_X.Text = levelMark.BasePoint.X.ToString();
            tb_basePoint_Y.Text = levelMark.BasePoint.Y.ToString();
            tb_basePoint_Z.Text = levelMark.BasePoint.Z.ToString();

            tb_Prefix.Text = levelMark.Attributes.Prefix;
            tb_Postfix.Text = levelMark.Attributes.Postfix;
            tb_FontHeight.Text = levelMark.Attributes.Font.Height.ToString();
            if(levelMark.Attributes.Font.Color == DrawingColors.Red)
                cb_Color.SelectedIndex = 0;
            else if(levelMark.Attributes.Font.Color == DrawingColors.Green)
                cb_Color.SelectedIndex = 1;
            else if(levelMark.Attributes.Font.Color == DrawingColors.Blue)
                cb_Color.SelectedIndex = 2;
            else if(levelMark.Attributes.Font.Color == DrawingColors.Black)
                cb_Color.SelectedIndex = 3;
            else
                cb_Color.SelectedIndex = -1;
        }

        public void GetDataFromForm(Tekla.Structures.Drawing.LevelMark levelMark)
        {
            if(levelMark == null)
                return;

            if(cb_SubType.SelectedIndex == 0)
                levelMark.SubType = Tekla.Structures.Drawing.LevelMark.LevelMarkType.NoArrowNoLeaderLine;
            else if(cb_SubType.SelectedIndex == 1)
                levelMark.SubType = Tekla.Structures.Drawing.LevelMark.LevelMarkType.ArrowWithoutLeaderLine;
            else if(cb_SubType.SelectedIndex == 2)
                levelMark.SubType = Tekla.Structures.Drawing.LevelMark.LevelMarkType.InclinedLeaderLine;
            else
                levelMark.SubType = Tekla.Structures.Drawing.LevelMark.LevelMarkType.OrthogonalLeaderLine;

            if(cb_SubType.SelectedIndex == 2 || cb_SubType.SelectedIndex == 3)
            {
                levelMark.Placing = new LeaderLinePlacing(levelMark.BasePoint);
            }
            else
            {
                levelMark.Placing = new PointPlacing();
            }

            levelMark.Attributes.Prefix = tb_Prefix.Text;
            levelMark.Attributes.Postfix = tb_Postfix.Text;
            levelMark.Attributes.Font.Height = Convert.ToDouble(tb_FontHeight.Text);
            if(cb_Color.SelectedIndex == 0)
                levelMark.Attributes.Font.Color = DrawingColors.Red;
            else if(cb_Color.SelectedIndex == 1)
                levelMark.Attributes.Font.Color = DrawingColors.Green;
            else if(cb_Color.SelectedIndex == 2)
                levelMark.Attributes.Font.Color = DrawingColors.Blue;
            else
                levelMark.Attributes.Font.Color = DrawingColors.Black;
        }

        public void LevelMarkModify()
        {
            DrawingHandler myDrawingHandler = new DrawingHandler();
            DrawingObjectSelector dos = myDrawingHandler.GetDrawingObjectSelector();
            DrawingObjectEnumerator allObjectsOnSheet = dos.GetSelected();
            while(allObjectsOnSheet.MoveNext())
            {
                if(allObjectsOnSheet.Current is Tekla.Structures.Drawing.LevelMark)
                {
                    Tekla.Structures.Drawing.LevelMark levelMark = allObjectsOnSheet.Current as Tekla.Structures.Drawing.LevelMark;

                    if(levelMark == null)
                        continue;

                    Point insertionPoint = null, basePoint = null;
                    if(GetPointsFromForm(ref insertionPoint, ref basePoint))
                    {
                        levelMark.InsertionPoint = insertionPoint;
                        levelMark.BasePoint = basePoint;
                    }

                    GetDataFromForm(levelMark);

                    if(!levelMark.Modify())
                    {
                        MessageBox.Show("Could not modify level mark!");
                        return;
                    }
                }
            }
        }

        public Tekla.Structures.Drawing.LevelMark GetSelectedLevelMark()
        {
            DrawingHandler myDrawingHandler = new DrawingHandler();
            DrawingObjectSelector dos = myDrawingHandler.GetDrawingObjectSelector();
            DrawingObjectEnumerator allObjectsOnSheet = dos.GetSelected();
            while(allObjectsOnSheet.MoveNext())
            {
                if(allObjectsOnSheet.Current is Tekla.Structures.Drawing.LevelMark)
                {
                    Tekla.Structures.Drawing.LevelMark levelMark = allObjectsOnSheet.Current as Tekla.Structures.Drawing.LevelMark;
                    return levelMark;
                }
            }
            return null;
        }

        public bool GetPointsFromForm(ref Point insertionPoint, ref Point basePoint)
        {
            insertionPoint = new Point();
            basePoint = new Point();

            try
            {
                insertionPoint.X = Convert.ToDouble(tb_insertionPoint_X.Text);
                insertionPoint.Y = Convert.ToDouble(tb_insertionPoint_Y.Text);
                insertionPoint.Z = Convert.ToDouble(tb_insertionPoint_Z.Text);

                basePoint.X = Convert.ToDouble(tb_basePoint_X.Text);
                basePoint.Y = Convert.ToDouble(tb_basePoint_Y.Text);
                basePoint.Z = Convert.ToDouble(tb_basePoint_Z.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        public bool GetInsertionData(bool ByPickPoints, bool Associative, ref Tekla.Structures.Drawing.ModelObject modelobject, ref ViewBase view, ref Point insertionPoint, ref Point basePoint)
        {
            DrawingHandler drawingHandler = new DrawingHandler();
            Picker picker = drawingHandler.GetPicker();

            try
            {
                if(Associative)
                {
                    DrawingObject res = null;
                    picker.PickObject("Pick object", out res, out view);
                    if(res != null)
                    {
                        modelobject = res as Tekla.Structures.Drawing.ModelObject;
                    }
                }

                if(ByPickPoints)
                {
                    picker.PickPoint("Pick base point", out basePoint, out view);// Selected point should be in a view
                    picker.PickPoint("Pick insertion point", out insertionPoint, out view);// Selected point should be in a view
                }
                else
                {
                    var drawing1 = drawingHandler.GetActiveDrawing();
                    var sheet1 = drawing1.GetSheet();
                    var allviews = sheet1.GetAllViews();
                    if(allviews.MoveNext() && allviews.Current != null)
                    {
                        view = allviews.Current as ViewBase;
                    }
                    else
                    {
                        return false;
                    }

                    if(!GetPointsFromForm(ref insertionPoint, ref basePoint))
                    {
                        return false;
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            return true;
        }

        public void LevelMarkCreate(bool ByPickPoints, bool ByPickObject)
        {
            if(cb_SubType.SelectedIndex < 0)
            {
                cb_SubType.SelectedIndex = 3;
            }

            ViewBase view = null;
            Point insertionPoint = null;
            Point basePoint = null;
            ModelObject obj = null;

            if(!GetInsertionData(ByPickPoints, ByPickObject, ref obj, ref view, ref insertionPoint, ref basePoint))
                return;

            Tekla.Structures.Drawing.LevelMark levelMark = new Tekla.Structures.Drawing.LevelMark(view, insertionPoint, basePoint, obj);

            GetDataFromForm(levelMark);

            if(!levelMark.Insert())
            {
                MessageBox.Show("Could not insert level mark!");
                return;
            }

            SetDataToForm(levelMark);

            DrawingHandler drawingHandler = new DrawingHandler();
            drawingHandler.GetActiveDrawing().CommitChanges();
        }

        private void b_Modify_Click(object sender, EventArgs e)
        {
            LevelMarkModify();

            DrawingHandler myDrawingHandler = new DrawingHandler();
            myDrawingHandler.GetActiveDrawing().CommitChanges();
        }

        private void b_Create_Click(object sender, EventArgs e)
        {
            LevelMarkCreate(cb_PickPoints.Checked, cb_PickObject.Checked);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.tb_insertionPoint_X, "Insertion Point X");
            toolTip1.SetToolTip(this.tb_insertionPoint_Y, "Insertion Point Y");
            toolTip1.SetToolTip(this.tb_insertionPoint_Z, "Insertion Point Z");
            toolTip1.SetToolTip(this.tb_basePoint_X, "Base Point X");
            toolTip1.SetToolTip(this.tb_basePoint_Y, "Base Point Y");
            toolTip1.SetToolTip(this.tb_basePoint_Z, "Base Point Z");
            toolTip1.SetToolTip(this.b_Create, "Click to create level mark with the given settings");
            toolTip1.SetToolTip(this.b_Modify, "Click to modify level mark with the given settings");
            toolTip1.SetToolTip(this.b_Get, "Click to get settings of level mark to dialog");
            toolTip1.SetToolTip(this.tb_FontHeight, "Height of the font");
            toolTip1.SetToolTip(this.tb_Prefix, "Content to be displayed just before the level value");
            toolTip1.SetToolTip(this.tb_Postfix, "Content to be displayed just after the level value");
            toolTip1.SetToolTip(this.cb_Color, "Color of the text displayed");
            toolTip1.SetToolTip(this.cb_SubType, "Display Type of Level Mark");
            toolTip1.SetToolTip(this.tb_AssociatedObject, "Drawing object identifier of the object that level is associated");

            Tekla.Structures.Drawing.UI.Events _events = new Tekla.Structures.Drawing.UI.Events();
            _events.SelectionChange += Events_SelectionChangeEvent;

            DrawingHandler drawingHandler = new DrawingHandler();
            if(drawingHandler.GetConnectionStatus())
            {
                b_Get_Click(sender, e);
            }
        }

        private void b_Get_Click(object sender, EventArgs e)
        {
            Tekla.Structures.Drawing.LevelMark levelmark = GetSelectedLevelMark();
            SetDataToForm(levelmark);
        }

        private object _selectionEventHandlerLock = new object();

        void Events_SelectionChangeEvent()
        {
            /* Make sure that the inner code block is running synchronously */
            lock(_selectionEventHandlerLock)
            {
                b_Get_Click(null, null);
            }
        }
    }
}
