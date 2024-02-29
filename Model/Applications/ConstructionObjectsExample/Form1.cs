using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Point = Tekla.Structures.Geometry3d.Point;

namespace ConstructionObjectsExample
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// The example construction arc
        /// </summary>
        private ControlArc constructionArc;

        /// <summary>
        /// The example construction polycurve
        /// </summary>
        private ControlPolycurve constructionPolycurve;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Gets the chosen line type for the example arc
        /// </summary>
        /// <returns>The arc line type</returns>
        private ControlObjectLineType GetArcLineType()
        {
            switch (this.ArcLineType.Text)
            {
                case "SolidLine":
                    return ControlObjectLineType.SolidLine;
                case "DashedLine":
                    return ControlObjectLineType.DashedLine;
                case "SlashedLine":
                    return ControlObjectLineType.SlashedLine;
                case "DashDot":
                    return ControlObjectLineType.DashDot;
                case "DottedLine":
                    return ControlObjectLineType.DottedLine;
            }

            return ControlObjectLineType.SolidLine;
        }

        /// <summary>
        /// Parses a text box to get a double value. If the text box does not contain a valid number, gives the provided
        /// default value.
        /// </summary>
        /// <param name="defaultValue">Value to return if the text box does not contain a valid number</param>
        /// <returns>The parsed value</returns>
        private double ParseValueOr(string text, double defaultValue)
        {
            double value;
            if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
            {
                return value;
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Event handler to create an example arc
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">Event args</param>
        private void CreateExampleArc_Click(object sender, EventArgs e)
        {
            if (this.constructionArc != null)
            {
                this.constructionArc.Delete();
            }

            double radius = this.ParseValueOr(this.ArcRadiusBox.Text, 5000.0);

            // This shows the creation of an arc geometry using three points. In this example, the arc will have a
            // radius given by the user and an angle of 270 degrees.
            Point startPoint = new Point(radius, 0.0, 0.0);
            Point endPoint = new Point(0.0, -radius, 0.0);
            Point intermediatePoint = new Point(0.0, radius, 0.0);

            Arc arcByThreePoints = new Arc(startPoint, endPoint, intermediatePoint);
            ControlObjectLineType lineType = this.GetArcLineType();

            this.constructionArc = new ControlArc
            {
                Geometry = arcByThreePoints,
                LineType = lineType,
                Color = ControlObjectColorEnum.BLUE
            };

            this.constructionArc.Insert();
            new Model().CommitChanges();
        }

        /// <summary>
        /// Event handler to modify the example arc
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">Event args</param>
        private void ModifyArcButton_Click(object sender, EventArgs e)
        {
            if (this.constructionArc == null)
            {
                return;
            }

            double userDefinedRadius = this.ParseValueOr(this.ArcRadiusBox.Text, 5000.0);
            Arc previousArc = this.constructionArc.Geometry;

            // This shows the creation of an arc geometry using a set of parameters that easily allows controlling the
            // radius and angle of the arc, especially if another arc is available as a reference.
            Arc modifiedArc = new Arc(previousArc.CenterPoint, previousArc.StartDirection,
                                      previousArc.StartTangent, userDefinedRadius, previousArc.Angle);

            this.constructionArc.Geometry = modifiedArc;
            this.constructionArc.LineType = this.GetArcLineType();

            this.constructionArc.Modify();
            new Model().CommitChanges();
        }

        /// <summary>
        /// Event handler to create an example polycurve
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">Event args</param>
        private void CreateExamplePolycurveButton_Click(object sender, EventArgs e)
        {
            if (this.constructionPolycurve != null)
            {
                this.constructionPolycurve.Delete();
            }

            // This example shows how to use the PolycurveGeometryBuilder to create an arbitrary polycurve using the
            // fluent API.
            Polycurve exampleGeometry = new PolycurveGeometryBuilder()
                                            .Append(new LineSegment(new Point(10000, 0, 0), new Point(10000, 5000, 0)))
                                            .AppendTangentArc(new Point(15000, 5000, 0))
                                            .AppendSegment(new Point(20000, 5000, 0))
                                            .AppendArc(new Point(22500, 10000, 0), new Point(25000, 5000, 0))
                                            .GetPolycurve();

            this.constructionPolycurve = new ControlPolycurve
            {
                Geometry = exampleGeometry,
                LineType = ControlObjectLineType.SolidLine,
                Color = ControlObjectColorEnum.RED
            };

            this.constructionPolycurve.Insert();
            new Model().CommitChanges();
        }

        /// <summary>
        /// Event handler to append a tangent arc to the example polycurve
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">Event args</param>
        private void AppendTangentLineButton_Click(object sender, EventArgs e)
        {
            if (this.constructionPolycurve == null)
            {
                return;
            }

            double lineLength = this.ParseValueOr(this.TangentLineLength.Text, 5000);

            // This example shows how to create a new polycurve geometry using a reference polycurve as input. This
            // allows for easy modification of the polycurve without affecting its immutability.
            Polycurve modifiedGeometry = new PolycurveGeometryBuilder(this.constructionPolycurve.Geometry)
                                            .AppendTangentSegment(lineLength)
                                            .GetPolycurve();

            this.constructionPolycurve.Geometry = modifiedGeometry;

            this.constructionPolycurve.Modify();
            new Model().CommitChanges();
        }

        /// <summary>
        /// Pick an end point for the tangent arc to be appended to the example polycurve
        /// </summary>
        private Point PickTangentArcEndPoint()
        {
            try
            {
                Picker picker = new Picker();
                return picker.PickPoint("Pick end point of the arc");
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Event handler to add a tangent arc to the example polycurve
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">Event args</param>
        private void AppendTangentArcButton_Click(object sender, EventArgs e)
        {
            if (this.constructionPolycurve == null)
            {
                return;
            }

            Point endPoint = this.PickTangentArcEndPoint();
            if (endPoint == null)
            {
                return;
            }

            // This is an alternative example about how to create a new polycurve from an existing one.
            Polycurve modifiedGeometry = new PolycurveGeometryBuilder(this.constructionPolycurve.Geometry)
                                            .AppendTangentArc(endPoint)
                                            .GetPolycurve();

            this.constructionPolycurve.Geometry = modifiedGeometry;

            this.constructionPolycurve.Modify();
            new Model().CommitChanges();
        }

        /// <summary>
        /// Converts a segment to an arc using an arbitrary normal
        /// </summary>
        /// <param name="segment">Input segment</param>
        /// <returns>Segment converted to arc</returns>
        private static Arc SegmentToArc(LineSegment segment)
        {
            Vector arcNormal = new Vector(0, 0, 1);

            Point centerPoint = 0.5 * new Vector(segment.StartPoint + segment.EndPoint);

            // This example shows how to construct arc using a different set of parameters that suits better for the
            // conversion of segment to arc
            return new Arc(centerPoint, segment.StartPoint, arcNormal, Math.PI);
        }

        /// <summary>
        /// Event handler to convert all the polycurve lines to arcs
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">Event args</param>
        private void ConvertLinesToArcsButton_Click(object sender, EventArgs e)
        {
            if (this.constructionPolycurve == null)
            {
                return;
            }

            // This example shows how to easily perform batch modifications to a polycurve using LINQ queries
            var newArcsWithIndex = this.constructionPolycurve.Geometry
                                       .Select((curve, index) => new { Segment = curve as LineSegment, Index = index })
                                       .Where(a => a.Segment != null)
                                       .Select(a => new { Arc = SegmentToArc(a.Segment), Index = a.Index });

            // In this other example, an alternative usage of the PolycurveGeometryBuilder is shown, where the fluent
            // API is not used, but rather the builder is used within a loop
            PolycurveGeometryBuilder builder = new PolycurveGeometryBuilder(this.constructionPolycurve.Geometry);
            foreach (var arcAndIndex in newArcsWithIndex)
            {
                builder.Replace(arcAndIndex.Index, arcAndIndex.Arc);
            }

            this.constructionPolycurve.Geometry = builder.GetPolycurve();

            this.constructionPolycurve.Modify();
            new Model().CommitChanges();
        }

        /// <summary>
        /// Event handler to convert all the polycurve arcs to lines
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">Event args</param>
        private void ConvertArcToLinesButton_Click(object sender, EventArgs e)
        {
            if (this.constructionPolycurve == null)
            {
                return;
            }

            // This example shows the counterpart of the previous example that converts line to arcs, but simplified
            // further since the conversion from arc to segment is trivial.
            var newSegmentsWithIndex = this.constructionPolycurve.Geometry
                    .Select((curve, index) => new { Arc = curve as Arc, Index = index })
                    .Where(a => a.Arc != null)
                    .Select(a => new { Segment = new LineSegment(a.Arc.StartPoint, a.Arc.EndPoint), Index = a.Index });

            PolycurveGeometryBuilder builder = new PolycurveGeometryBuilder(this.constructionPolycurve.Geometry);
            foreach (var lineAndIndex in newSegmentsWithIndex)
            {
                builder.Replace(lineAndIndex.Index, lineAndIndex.Segment);
            }

            this.constructionPolycurve.Geometry = builder.GetPolycurve();

            this.constructionPolycurve.Modify();
            new Model().CommitChanges();
        }
    }
}
