namespace SplitPolygonWeld
{
    using System;
    using System.Collections;
    using System.Windows.Forms;

    using Tekla.Structures.Geometry3d;
    using Tekla.Structures.Model;
    using Tekla.Structures.Model.Operations;
    using Tekla.Structures.Model.UI;

    public partial class MainForm : Form
    {
        /// <summary>
        /// Tekla Structures model.
        /// </summary>
        private readonly Model _model;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();
            _model = new Model();
        }

        private void splitPolygonWeldButtonClick(object sender, EventArgs e)
        {
            try
            {
                var picker = new Picker();
                var modelObject = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_WELD);

                if (modelObject != null && modelObject is PolygonWeld)
                {
                    var polygonWeld = modelObject as PolygonWeld;

                    if (!SplitPolygonWeld(polygonWeld))
                    {
                        MessageBox.Show("Splitting couldn't be completed.");
                    }

                    this._model.CommitChanges();
                }
            }
            catch (Exception exception)
            {
                if (exception.Message != "User interrupt.")
                {
                    MessageBox.Show(exception.ToString());
                }
            }
        }

        /// <summary>
        /// Split the polygon weld into its segments.
        /// </summary>
        /// <param name="polygonWeld">The polygon weld.</param>
        /// <returns>True when successful.</returns>
        private static bool SplitPolygonWeld(PolygonWeld polygonWeld)
        {
            if (polygonWeld != null && polygonWeld.Polygon.Points.Count > 1)
            {
                var points = polygonWeld.Polygon.Points;

                var newPoints = new ArrayList();
                newPoints.Add(points[0]);
                newPoints.Add(points[1]);

                // Modify the original weld to be the first segment
                polygonWeld.Polygon.Points = newPoints;
                if (!polygonWeld.Modify())
                {
                    return false;
                }

                // Create copies of the original one for each segment
                for (var i = 1; i < points.Count - 1; i++)
                {
                    var polygonPoints = new ArrayList();
                    polygonPoints.Add(points[i]);
                    polygonPoints.Add(points[i + 1]);
                    var newModelObject = Operation.CopyObject(polygonWeld, new Vector(0, 0, 0));

                    if (newModelObject != null && newModelObject is PolygonWeld)
                    {
                        var newPolygonWeld = newModelObject as PolygonWeld;
                        newPolygonWeld.Polygon.Points = polygonPoints;
                        if (!newPolygonWeld.Modify())
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
