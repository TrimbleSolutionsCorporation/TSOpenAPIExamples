using System;
using System.Collections;

using System.Text;
using System.Windows;
using Tekla.Structures.Model;
using Component = Tekla.Structures.Model.Component;
using Tekla.Structures.Geometry3d;
using Point = Tekla.Structures.Geometry3d.Point;

namespace GetComponentInputExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model myModel = new Model();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!myModel.GetConnectionStatus())
            {
                this.ModelNameLabel.Content = "Not connected to a Tekla Structures model!";
                this.ModelNameLabel.Foreground = System.Windows.Media.Brushes.Red;
            }
            else
            {
                this.ModelNameLabel.Content = "Model Name: " + myModel.GetInfo().ModelName.Replace(".db1", "");
                this.CompInputBox.Text = FillCompInputBox();
            }
        }

        private string FillCompInputBox()
        {
            StringBuilder result = new StringBuilder("Select one component in a model view!");

            TransformationPlane currentTransformationPlane = myModel.GetWorkPlaneHandler().GetCurrentTransformationPlane();
            long StartTicks = DateTime.Now.Ticks;

            var myEnum = new Tekla.Structures.Model.UI.ModelObjectSelector().GetSelectedObjects();

            if (myEnum.GetSize() != 1) return result.ToString();

            myEnum.MoveNext();
            var comp = myEnum.Current as Component;

            if (comp == null) return result.ToString();

            result.Clear();
            result.AppendLine("Component name: " + comp.Name);
            result.AppendLine("Component ID: " + comp.Identifier.ID.ToString());

            var inputIndex = 0;

            foreach (InputItem input in comp.GetComponentInput())
            {
                result.AppendLine("Input " + inputIndex++.ToString() + ": " + input.GetInputType().ToString());
                if (input.GetInputType() == InputItem.InputTypeEnum.INPUT_1_POINT)
                {
                    result.AppendLine((input.GetData() as Point).ToString());
                }

                if (input.GetInputType() == InputItem.InputTypeEnum.INPUT_2_POINTS)
                {
                    var data = input.GetData() as ArrayList;
                    foreach (Point point in data)
                    {
                        result.AppendLine(point.ToString());
                    }
                }

                if (input.GetInputType() == InputItem.InputTypeEnum.INPUT_POLYGON)
                {
                    var data = input.GetData() as ArrayList;
                    foreach (Point point in data)
                    {
                        result.AppendLine(point.ToString());
                    }
                }

                if (input.GetInputType() == InputItem.InputTypeEnum.INPUT_1_OBJECT)
                {
                    result.AppendLine((input.GetData() as ModelObject).Identifier.ID.ToString());
                }

                if (input.GetInputType() == InputItem.InputTypeEnum.INPUT_N_OBJECTS)
                {
                    var data = input.GetData() as ArrayList;
                    foreach (ModelObject o in data)
                    {
                        result.AppendLine(o.Identifier.ID.ToString());
                    }
                }
            }

            return result.ToString();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            this.CompInputBox.Text = FillCompInputBox();
        }
    }
}
