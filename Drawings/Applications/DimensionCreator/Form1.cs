using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DimensionCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void angleDimensionButton_Click(object sender, EventArgs e)
        {
            try
            {
                DimensionCreator.CreateAngleDimension();
            }
            catch (Exception) { }
        }

        private void radiusDimensionButton_Click(object sender, EventArgs e)
        {
            try { DimensionCreator.CreateRadiusDimension((double)this.distanceNumericUpDown.Value); }
            catch (Exception) { }
        }

        private void straightDimensionButton_Click(object sender, EventArgs e)
        {
            try { DimensionCreator.CreateStraightDimension((double)this.distanceNumericUpDown.Value); }
            catch (Exception) { }
        }

        private void curvedRadialDimensionButton_Click(object sender, EventArgs e)
        {
            try { DimensionCreator.CreateCurvedRadialDimension((double)this.distanceNumericUpDown.Value); }
            catch
            {
            }
        }

        private void curvedOrthogonalDimensionButton_Click(object sender, EventArgs e)
        {
            try
            {
                DimensionCreator.CreateCurvedOrthoDimension((double)this.distanceNumericUpDown.Value);
            }
            catch (Exception) { }
        }

        private void repeatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DimensionCreator.Repeat = !DimensionCreator.Repeat;
        }

        private void numberOfPointsToPickNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            DimensionCreator.Points = (int)this.numberOfPointsToPickNumericUpDown.Value;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}