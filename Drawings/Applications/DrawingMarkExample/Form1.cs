using System.Windows.Forms;
using Tekla.Structures.Drawing;
using Tekla.Structures.Geometry3d;

namespace DrawingMarkExample
{
    public partial class DrawingMarkExampleForm : Form
    {
        public DrawingMarkExampleForm()
        {
            InitializeComponent();
        }

        private void buttonDelete_Click(object sender, System.EventArgs e)
        {
            DrawingHandler dh = new DrawingHandler();
            Drawing activeDrawing = dh.GetActiveDrawing();

            DrawingObjectEnumerator marks = activeDrawing.GetSheet().GetAllObjects(typeof(Mark));
            int nMarksBefore = marks.GetSize();

            while(marks.MoveNext())
            {
                Mark currentMark = marks.Current as Mark;
                currentMark.Delete();
            }

            activeDrawing.CommitChanges();
            int nMarksAfter = activeDrawing.GetSheet().GetAllObjects(typeof(Mark)).GetSize();
        }

        private void buttonUndo_Click(object sender, System.EventArgs e)
        {
            Tekla.Structures.ModelInternal.Operation.dotStartAction("Undo", "");
        }

        private void buttonInsert_Click(object sender, System.EventArgs e)
        {
            DrawingHandler dh = new DrawingHandler();
            Drawing activeDrawing = dh.GetActiveDrawing();

            DrawingObjectEnumerator marks = activeDrawing.GetSheet().GetAllObjects(typeof(Mark));
            int nMarksBefore = marks.GetSize();

            DrawingObjectEnumerator parts = activeDrawing.GetSheet().GetAllObjects(typeof(Part));

            while(parts.MoveNext())
            {
                Part part = parts.Current as Part;
                Mark mark = new Mark(part);
                mark.Attributes.LoadAttributes("standard");
                mark.Attributes.Content.Clear();
                mark.Attributes.Content.Add(new TextElement("API mark"));

                if (checkBoxProfile.Checked)
                {
                    mark.Attributes.Content.Add(new NewLineElement());
                    mark.Attributes.Content.Add(new PropertyElement(PropertyElement.PropertyElementType.PartMarkPropertyElementTypes.Profile()));
                }

                if(checkBoxMainPartSecondary.Checked)
                {
                    mark.Attributes.Content.Add(new NewLineElement());
                    var modelpart = new Tekla.Structures.Model.Model().SelectModelObject(part.ModelIdentifier);
                    var partAssembly = (modelpart as Tekla.Structures.Model.Part).GetAssembly();
                    
                    if(partAssembly.GetMainPart().Identifier.ID == part.ModelIdentifier.ID)
                    {
                        mark.Attributes.Content.Add(new TextElement("Main part"));
                    }
                    else
                    {
                        mark.Attributes.Content.Add(new TextElement("Secondary part"));
                    }
                }

                mark.Insert();
            }

            activeDrawing.CommitChanges();
            int nMarksAfter = activeDrawing.GetSheet().GetAllObjects(typeof(Mark)).GetSize();
        }

        private void buttonModify_Click(object sender, System.EventArgs e)
        {
            DrawingHandler dh = new DrawingHandler();
            Drawing activeDrawing = dh.GetActiveDrawing();
            DrawingObjectEnumerator marks = activeDrawing.GetSheet().GetAllObjects(typeof(Mark));

            while (marks.MoveNext())
            {
                Mark currentMark = marks.Current as Mark;
                var elements = currentMark.Attributes.Content.GetEnumerator();

                while(elements.MoveNext())
                {
                    PropertyElement propertyElement = elements.Current as PropertyElement;

                    if (propertyElement != null)
                    {
                        propertyElement.Font.Color = DrawingColors.Red;
                        if (radioButtonGreen.Checked) propertyElement.Font.Color = DrawingColors.Green;
                        if (radioButtonBlue.Checked) propertyElement.Font.Color = DrawingColors.Blue;
                        continue;
                    }

                    TextElement textElement = elements.Current as TextElement;

                    if (textElement != null)
                    {
                        textElement.Font.Color = DrawingColors.Red;
                        if (radioButtonGreen.Checked) textElement.Font.Color = DrawingColors.Green;
                        if (radioButtonBlue.Checked) textElement.Font.Color = DrawingColors.Blue;
                    }
                }

                double startPointX = double.Parse(textBoxStartPointX.Text);
                double startPointY = double.Parse(textBoxStartPointY.Text);
                currentMark.Placing = new LeaderLinePlacing(new Point(startPointX, startPointY));

                currentMark.Modify();
            }

            activeDrawing.CommitChanges();
        }
    }
}
