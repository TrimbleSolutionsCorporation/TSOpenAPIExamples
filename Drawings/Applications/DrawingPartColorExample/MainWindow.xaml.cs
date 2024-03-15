using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using Tekla.Structures.Drawing;
using Color = System.Windows.Media.Color;
using Button = System.Windows.Controls.Button;
using System.Collections;

namespace DrawingPartColorExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button pickedButton = (Button)sender;
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if(pickedButton.Name == this.CorrectMarkColor.Name)
                this.CorrectMarkColorBox.Fill = new SolidColorBrush(Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B));

                if (pickedButton.Name == this.WrongMarkColor.Name)
                    this.WrongMarkColorBox.Fill = new SolidColorBrush(Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B));

                if (pickedButton.Name == this.NoMarkColor.Name)
                    this.NoMarkColorBox.Fill = new SolidColorBrush(Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B));

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DrawingHandler dh = new DrawingHandler();
            var doe = dh.GetActiveDrawing().GetSheet().GetAllObjects(typeof(Part));

            foreach (Part part in doe)
            {
                Mark partMark = GetPartMark(part);
                if (partMark == null)
                {
                    Color boxColor = (NoMarkColorBox.Fill as SolidColorBrush).Color;
                    part.Attributes.VisibleLines.TrueColor = new TeklaDrawingColor(System.Drawing.Color.FromArgb(boxColor.R, boxColor.G, boxColor.B));
                    part.Modify();
                    continue;
                }

                if (CorrectPartMark(partMark))
                {
                    Color boxColor = (CorrectMarkColorBox.Fill as SolidColorBrush).Color;
                    part.Attributes.VisibleLines.TrueColor = new TeklaDrawingColor(System.Drawing.Color.FromArgb(boxColor.R, boxColor.G, boxColor.B));
                }
                else
                {
                    Color boxColor = (WrongMarkColorBox.Fill as SolidColorBrush).Color;
                    part.Attributes.VisibleLines.TrueColor = new TeklaDrawingColor(System.Drawing.Color.FromArgb(boxColor.R, boxColor.G, boxColor.B));
                }
                part.Modify();
            }

            dh.GetActiveDrawing().CommitChanges();
        }

        private bool CorrectPartMark(Mark partMark)
        {
            ContainerElement ce = partMark.Attributes.Content;

            if (ce.Count < 3) return false;

            IEnumerator enumerator = ce.GetEnumerator();
            enumerator.MoveNext();
            PropertyElement pe = enumerator.Current as PropertyElement;
            
            if(pe == null) return false;
            if(pe.Name != "PROFILE") return false;

            return true;
        }

        private Mark GetPartMark(Part part)
        {
            var doe = part.GetRelatedObjects();

            while (doe.MoveNext())
            {
                if (doe.Current is Mark)
                {
                    return (Mark)doe.Current;
                }
            }

            return null;
        }
    }
}
