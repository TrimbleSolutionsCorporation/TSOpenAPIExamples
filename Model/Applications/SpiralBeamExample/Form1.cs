using System;
using System.Windows.Forms;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace SpiralBeamExample
{
    /// <summary>
    /// Simple example to show how to create, modify and delete spiral beam part using API.
    /// </summary>
    public partial class SpiralBeamForm : Form
    {
        SpiralBeam spiralBeam = null;
        Model model = new Model();

        public SpiralBeamForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creation example of a simple spiral beam.
        /// </summary>
        private void CreateSpiralBeam_Click(object sender, EventArgs e)
        {
            if(spiralBeam == null)
            {
                //define geometry of the spiral beam.
                Point startPoint = new Point(0.0, 0.0, 0.0);
                Point rotationAxisBasePoint = new Point(3000.0, 0.0, 0.0);
                Point rotationAxisUpPoint = new Point(3000.0, 0.0, 1000.0);
                const double rotationAngle = 90.0;
                const double totalRise = 500.0;

                //twist angles can be optional.
                const double TwistAngleStart = 0.0;
                const double TwistAngleEnd = 0.0;

                spiralBeam = new SpiralBeam(startPoint, rotationAxisBasePoint, rotationAxisUpPoint, totalRise, rotationAngle, TwistAngleStart, TwistAngleEnd);

                //define basic attributes for spiral beam.
                spiralBeam.Name = "Spiral beam";
                spiralBeam.Material.MaterialString = "S235JR";
                spiralBeam.Profile.ProfileString = "HEA300";

                //insert spiral beam into the database and update the model.
                if (spiralBeam.Insert())
                {
                    model.CommitChanges();

                    this.CreateSpiralBeam.Enabled = false;
                    this.ModifySpiralBeam.Enabled = true;
                    this.DeleteSpiralBeam.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Modify spiral beam attributes example.
        /// </summary>
        private void ModifySpiralBeam_Click(object sender, EventArgs e)
        {
            if (spiralBeam != null)
            {
                // we can modify spiral beam using public properties.
                spiralBeam.TwistAngleStart = 0.0;
                spiralBeam.TwistAngleEnd = 90.0;
                spiralBeam.TotalRise = spiralBeam.TotalRise * 2;

                spiralBeam.StartPoint = new Point(1500.0, 500.0, 0.0);

                if (spiralBeam.Modify())
                {
                    model.CommitChanges();
                }
            }
        }

        /// <summary>
        /// Delete spiral beam example.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteSpiralBeam_Click(object sender, EventArgs e)
        {
            if (spiralBeam != null)
            {
                //Delete is used the same way as any other part part.
                if (spiralBeam.Delete())
                {
                    spiralBeam = null;
                    model.CommitChanges();

                    this.ModifySpiralBeam.Enabled = false;
                    this.DeleteSpiralBeam.Enabled = false;
                    this.CreateSpiralBeam.Enabled = true;
                }
            }
        }
    }
}
