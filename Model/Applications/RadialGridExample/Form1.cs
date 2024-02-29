using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Tekla.Structures.Datatype;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

using Distance = Tekla.Structures.Datatype.Distance;

namespace RadialGridExample
{
    public partial class RadialGridExample : Form
    {
        /// <summary>
        /// The example radial grid
        /// </summary>
        private RadialGrid radialGrid;

        public RadialGridExample()
        {
            InitializeComponent();
        }

        private void RadialGridExample_Load(object sender, EventArgs e)
        {
            // Set the angle unit to degrees *in the context of this application* (won't affect the user-set unit in
            // Tekla Structures).
            Angle.CurrentUnitType = Angle.UnitType.Degrees;
        }

        /// <summary>
        /// Parses a text box to get a double value. If the text box does not contain a valid number, returns
        /// not a number.
        /// </summary>
        /// <returns>The parsed value, or NaN if the text cannot be parsed</returns>
        private static double ParseValue(string text)
        {
            double value;
            if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
            {
                return value;
            }
            else
            {
                return double.NaN;
            }
        }

        /// <summary>
        /// Event handler to create an example radial grid
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">Event args</param>
        private void CreateExampleRadialGridButton_Click(object sender, EventArgs e)
        {
            if (this.radialGrid != null)
            {
                this.radialGrid.Delete();
            }

            this.radialGrid = new RadialGrid
            {
                IsMagnetic = false,
                RadialCoordinates = "0 5*5000",
                AngularCoordinates = "0 6*15",
                CoordinateZ = "0 5000 10000",
                RadialLabels = "R1 R2 R3 R4 R5",
                AngularLabels = "A1 A2 A3 A4 A5 A6 A7",
                LabelZ = "Z1 Z2 Z3",
                ArcStartExtension = 2000.0, // Length of the arc section appended before the start of the arcs
                AngularLinesStartExtension = 2000.0,
                ExtensionBelowZ = 2000.0,
                ArcEndExtension = 2000.0, // Length of the arc section appended after the end of the arc
                AngularLinesEndExtension = 2000.0,
                ExtensionAboveZ = 2000.0,
                Color = System.Drawing.Color.DarkMagenta,
            };

            this.radialGrid.Insert();
            new Model().CommitChanges();
        }

        /// <summary>
        /// Computes the actual list of values of a radial grid parameter, since the expected format of the strings is
        /// as adjacent difference of the values.
        /// </summary>
        /// <param name="diff">Values given as adjacent difference</param>
        /// <returns>List of the absolute values of the radial grid</returns>
        private static List<double> CummulativeSum(List<double> diff)
        {
            var result = new List<double>(diff.Count);

            double lastValue = 0.0;
            for (int i = 0; i < diff.Count; ++i)
            {
                result.Add(diff[i] + lastValue);
                lastValue = result[i];
            }

            return result;
        }

        /// <summary>
        /// Computes the adjacent difference of a list of absolute values, to produce it in the format expected by
        /// the radial grid class
        /// </summary>
        /// <param name="values">Values given in absolute values</param>
        /// <returns>List of value differences in the format expected by the radial grid class</returns>
        private static List<double> AdjacentDifference(List<double> values)
        {
            var result = new List<double>(values.Count);

            double lastValue = 0.0;
            for (int i = 0; i < values.Count; ++i)
            {
                result.Add(values[i] - lastValue);
                lastValue = values[i];
            }

            return result;
        }

        /// <summary>
        /// Adds an angle to the example radial grid
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">Event args</param>
        private void AddAngleButton_Click(object sender, EventArgs e)
        {
            if (this.radialGrid == null)
            {
                return;
            }

            // This example shows how to parse an angle list expressed as a string (as expected by the radial grid
            // class). Since the radial grid provides its angles as adjacent difference, some further operations
            // (as shown below) are necessary to operate at angle level.
            List<Angle> diffAngles = AngleList.Parse(this.radialGrid.AngularCoordinates, CultureInfo.InvariantCulture);

            double angleToAdd = ParseValue(this.AngleTextBox.Text);
            if (double.IsNaN(angleToAdd))
            {
                return;
            }

            List<double> currentAngles = CummulativeSum(diffAngles.Select(a => a.Degrees).ToList());

            // Finding the index of the first angle which is greater than the angle to insert is not a strictly
            // necessary step (we could insert the angle into any arbitrary position), but if we compute this
            // index first then the resulting string in the radial grid will not have negative values (at least not
            // caused by the insertion of this angle), because it is generated as an adjacent difference.
            int indexToInsert = currentAngles.FindIndex(angle => angle > angleToAdd);
            if (indexToInsert == -1)
            {
                indexToInsert = currentAngles.Count;
            }

            currentAngles.Insert(indexToInsert, angleToAdd);
            var newAngleList = AdjacentDifference(currentAngles).Select(a => Angle.FromDegrees(a));

            // This example shows how to generate the angle list string from the list of Angle that we generated when
            // we added the extra angle
            string format = string.Empty;
            this.radialGrid.AngularCoordinates = AngleList.ToString(newAngleList, format, CultureInfo.InvariantCulture);

            // NOTE: In versions prior to 2019, calling Modify() on a grid would remove all the user defined grid lines.
            // This is *no longer the case* from version 2019 onward, and *it is safe* to call Modify() on a grid.
            // All the manual grid lines will be preserved.
            this.radialGrid.Modify();
            new Model().CommitChanges();
        }

        /// <summary>
        /// Adds a new radius to the example radial grid
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">Event args</param>
        private void AddRadiusButton_Click(object sender, EventArgs e)
        {
            if (this.radialGrid == null)
            {
                return;
            }

            // This example shows how to parse a distance list expressed as a string (as expected by the radial grid
            // class). This example is similar to the one of the angles, but note that the DistanceList class is used
            // differently.
            DistanceList diffRadiuses = DistanceList.Parse(this.radialGrid.RadialCoordinates, CultureInfo.InvariantCulture,
                                                           Distance.UnitType.Millimeter);

            double radiusToAdd = ParseValue(this.AddRadiusTextBox.Text);
            if (double.IsNaN(radiusToAdd))
            {
                return;
            }

            List<double> currentRadiuses = CummulativeSum(diffRadiuses.Select(r => r.Millimeters).ToList());

            // Here we have the same situation as in the angle case, we don't need to find the index to get the grid we
            // want, but we do it to make sure we get a nice looking string.
            int indexToInsert = currentRadiuses.FindIndex(radius => radius > radiusToAdd);
            if (indexToInsert == -1)
            {
                indexToInsert = currentRadiuses.Count;
            }

            currentRadiuses.Insert(indexToInsert, radiusToAdd);
            var newRadiusList = new DistanceList(AdjacentDifference(currentRadiuses).Select(r => new Distance(r, Distance.UnitType.Millimeter)));

            string format = string.Empty;
            this.radialGrid.RadialCoordinates = newRadiusList.ToString(format, CultureInfo.InvariantCulture);

            // NOTE: In versions prior to 2019, calling Modify() on a grid would remove all the user defined grid lines.
            // This is *no longer the case* from version 2019 onward, and *it is safe* to call Modify() on a grid.
            // All the manual grid lines will be preserved.
            this.radialGrid.Modify();
            new Model().CommitChanges();
        }

        /// <summary>
        /// Removes an angle from the example radial grid
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">Event args</param>
        private void RemoveAngleButton_Click(object sender, EventArgs e)
        {
            if (this.radialGrid == null)
            {
                return;
            }

            List<Angle> diffAngles = AngleList.Parse(this.radialGrid.AngularCoordinates, CultureInfo.InvariantCulture);

            double angleToRemove = ParseValue(this.RemoveAngleTextBox.Text);
            if (double.IsNaN(angleToRemove))
            {
                return;
            }

            List<double> currentAngles = CummulativeSum(diffAngles.Select(a => a.Degrees).ToList());

            const double AngleTolerance = 0.01;
            int nRemovedAngles = currentAngles.RemoveAll(angle => Math.Abs(angle - angleToRemove) < AngleTolerance);
            if (nRemovedAngles <= 0)
            {
                return; // Do not regenerate the string if no angle was removed
            }

            var newAngleList = AdjacentDifference(currentAngles).Select(a => Angle.FromDegrees(a));

            string format = string.Empty;
            this.radialGrid.AngularCoordinates = AngleList.ToString(newAngleList, format, CultureInfo.InvariantCulture);

            this.radialGrid.Modify();
            new Model().CommitChanges();
        }

        /// <summary>
        /// Removes a radius from the example radial grid
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">Event args</param>
        private void RemoveRadiusButton_Click(object sender, EventArgs e)
        {
            if (this.radialGrid == null)
            {
                return;
            }

            DistanceList diffRadiuses = DistanceList.Parse(this.radialGrid.RadialCoordinates, CultureInfo.InvariantCulture,
                                                           Distance.UnitType.Millimeter);

            double radiusToRemove = ParseValue(this.RemoveRadiusTextBox.Text);
            if (double.IsNaN(radiusToRemove))
            {
                return;
            }

            List<double> currentRadiuses = CummulativeSum(diffRadiuses.Select(a => a.Millimeters).ToList());

            const double RadiusTolerance = 0.0001;
            int nRemovedRadiuses = currentRadiuses.RemoveAll(radius => Math.Abs(radius - radiusToRemove) < RadiusTolerance);
            if (nRemovedRadiuses <= 0)
            {
                return; // Do not regenerate the string if no radius was removed
            }

            var newRadiusList = new DistanceList(AdjacentDifference(currentRadiuses).Select(r => new Distance(r, Distance.UnitType.Millimeter)));

            string format = string.Empty;
            this.radialGrid.RadialCoordinates = newRadiusList.ToString(format, CultureInfo.InvariantCulture);

            this.radialGrid.Modify();
            new Model().CommitChanges();
        }

        /// <summary>
        /// Modifies every second arc of the radial grid
        /// </summary>
        /// <param name="angleExpansionFactor">Factor to multiply the angle of the grid arcs</param>
        private void ModifyEverySecondArc(double angleExpansionFactor)
        {
            if (this.radialGrid == null)
            {
                return;
            }

            var gridSurfaces = this.radialGrid.GetChildren();
            int cylinderIndex = 0;

            // This example shows how to modify individual grid surfaces of the grid. The arc lines are defined by
            // the grid cylindrical surfaces. Thus, by modifying the cylinder base, we can modify the resulting arcs
            foreach (GridSurface surface in gridSurfaces)
            {
                if (surface is GridCylindricalSurface)
                {
                    var cylinder = surface as GridCylindricalSurface;
                    if (cylinderIndex % 2 == 0)
                    {
                        Arc baseArc = cylinder.CylinderBase;
                        double currentAngle = baseArc.Angle;
                        double modifiedAngle = Math.Min(currentAngle * angleExpansionFactor, 2 * Math.PI);

                        Arc newBaseArc = new Arc(baseArc.CenterPoint, baseArc.StartDirection, baseArc.StartTangent,
                                                 baseArc.Radius, modifiedAngle);

                        cylinder.CylinderBase = newBaseArc;
                        cylinder.Modify();
                    }

                    ++cylinderIndex;
                }
            }

            new Model().CommitChanges();
        }

        /// <summary>
        /// Shrinks every second arc from the example radial grid
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">Event args</param>
        private void ShrinkEverySecondArcButton_Click(object sender, EventArgs e)
        {
            this.ModifyEverySecondArc(0.8);
        }

        /// <summary>
        /// Expands every second arc from the example radial grid
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">Event args</param>
        private void ExpandEverySecondArcButton_Click(object sender, EventArgs e)
        {
            this.ModifyEverySecondArc(1.25);
        }
    }
}
