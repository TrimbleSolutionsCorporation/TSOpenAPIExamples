using System.Windows.Forms;
using Tekla.Structures;
using Tekla.Structures.Drawing;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace WeldMarkExample
{
    public partial class Form1 : Form
    {
        Identifier plateAssembly = new Identifier();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCreatesPlatesWeld_Click(object sender, System.EventArgs e)
        {
            var cp1 = new ContourPlate();
            var cp2 = new ContourPlate();

            Contour contour1 = new Contour();
            contour1.AddContourPoint(new ContourPoint(new Point(2000, 0, 0), null));
            contour1.AddContourPoint(new ContourPoint(new Point(3000, 0, 0), null));
            contour1.AddContourPoint(new ContourPoint(new Point(3000, 2000, 0), null));
            contour1.AddContourPoint(new ContourPoint(new Point(2000, 2000, 0), null));

            Contour contour2 = new Contour();
            contour2.AddContourPoint(new ContourPoint(new Point(3000, 0, 0), null));
            contour2.AddContourPoint(new ContourPoint(new Point(3000, 2000, 0), null));
            contour2.AddContourPoint(new ContourPoint(new Point(4000, 2000, 0), null));
            contour2.AddContourPoint(new ContourPoint(new Point(4000, 0, 0), null));

            cp1.Contour = contour1;
            cp2.Contour = contour2;

            cp1.Profile.ProfileString = cp2.Profile.ProfileString = "PL100";

            cp1.Insert();
            cp2.Insert();

            var weld = new Tekla.Structures.Model.Weld();
            weld.MainObject = cp1;
            weld.SecondaryObject = cp2;
            weld.SizeAbove = 10;
            weld.Insert();

            // This operation can also be done calling macro that executes numbering
            Tekla.Structures.ModelInternal.Operation.dotStartAction("FullNumbering", (string)null);

            double weldLength = -1;

            weld.GetReportProperty("LENGTH", ref weldLength);

            if (weldLength > 4000)
            {
                buttonCreatesPlatesWeld.Enabled = false;
                buttonCreatesAssDrawing.Enabled = true;
                label1.Text = " Close Numbering dialog manually! \n Assembly drawing will be created and opens automatically.";
                plateAssembly = cp1.GetAssembly().Identifier;
            }
            else
            {
                buttonCreatesPlatesWeld.Enabled = false;
                label1.Text = "Oops! Something went wrong. \n Restart TeklaStructures and test again.";
            }

            new Model().CommitChanges();
        }

        private void buttonReady_Click(object sender, System.EventArgs e)
        {
            buttonCreatesPlatesWeld.Enabled = true;
            label1.Text = "Two plates and one weld will be inserted in model, near globlal origin";
            buttonReady.Hide();
        }

        private void buttonCreatesAssDrawing_Click(object sender, System.EventArgs e)
        {
            buttonCreatesAssDrawing.Enabled = false;

            var assDrawing = new AssemblyDrawing(plateAssembly);
            assDrawing.Insert();
            var dh = new DrawingHandler();
            bool result = dh.SetActiveDrawing(assDrawing);

            if (result)
            {
                label1.Text = " You can now check the assembly drawing. \n Modify content to get different results";
                buttonGetWeldInfo.Enabled = true;
            }
            else
            {
                label1.Text = "Oops! Something went wrong. \n Restart TeklaStructures and test again.";
            }

        }

        private void buttonGetWeldInfo_Click(object sender, System.EventArgs e)
        {
            var dh = new DrawingHandler();
            var doe = dh.GetActiveDrawing().GetSheet().GetAllObjects(typeof(Tekla.Structures.Drawing.Weld));

            int numberWelding = doe.GetSize();
            int numberWeldingMark = 0;
            int numberWeldMark = 0;

            var doe2 = dh.GetActiveDrawing().GetSheet().GetAllObjects(typeof(WeldMark));

            while (doe2.MoveNext())
            {
                WeldMark weldMark = doe2.Current as WeldMark;

                if (weldMark.ModelIdentifier.IsValid())
                {
                    numberWeldingMark++;
                }
                else
                {
                    numberWeldMark++;
                }
            }

            if (numberWelding > 0)
            {
                doe.MoveNext();
                Tekla.Structures.Drawing.Weld firstWeld = doe.Current as Tekla.Structures.Drawing.Weld;

                var modelWeld = new Model().SelectModelObject(firstWeld.ModelIdentifier) as Tekla.Structures.Model.Weld;
                double weldSize = modelWeld.SizeAbove;
                double weldLength = 0;
                modelWeld.GetReportProperty("LENGTH", ref weldLength);
                MessageBox.Show("Size above : " + weldSize.ToString() + " mm. \n" +
                    "Weld length: " + weldLength.ToString() + " mm.", "First weld information");
            }

            MessageBox.Show("Number of Weld lines (related to welds in model database): " + numberWelding.ToString() + "\n" +
                "Number of Welding marks (related to welds in model database): " + numberWeldingMark.ToString() + "\n" +
                "Number of Weld marks (NOT related to model welds): " + numberWeldMark.ToString(), "Drawing information");

        }
    }
}
