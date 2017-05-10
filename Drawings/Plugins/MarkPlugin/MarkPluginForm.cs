using System;
using System.Collections;
using System.Windows.Forms;
using Tekla.Structures.Dialog;
using Tekla.Structures.Drawing;

namespace MarkPlugin
{
    public partial class MarkPluginForm : PluginFormBase
    {
        public MarkPluginForm()
        {
            InitializeComponent();

            cmbColor.DataSource = GetColors();
        }

        /// <summary>
        /// Get all possible drawing colors for the color dropdown
        /// </summary>
        /// <returns></returns>
        private static ArrayList GetColors()
        {
            var colors = new ArrayList();
            foreach (DrawingColors color in Enum.GetValues(typeof(DrawingColors)))
            {
                colors.Add(color);
            }

            return colors;
        }

        private void cmbColor_SelectionChanged(object sender, EventArgs e)
        {
            /* When the selected color change the bound textbox has to be updated */
            SetAttributeValue(txtColorValue, (int)cmbColor.SelectedItem);
        }

        private void txtColorHelper_TextChanged(object sender, EventArgs e)
        {
            /* The txtColorHelper control is bound to the plugin's "color" data, and gets
             * updated automatically. When it changes, this method is run and we set
             * the selected item in the color dropdown accordingly. */

            int color;
            if (int.TryParse(txtColorValue.Text, out color))
            {
                cmbColor.SelectedItem = (DrawingColors)color;
            }
        }

        private void angleSlider_Scroll(object sender, EventArgs e)
        {
            txtAngle.Text = String.Format("{0}", (sender as TrackBar).Value);
            SetAttributeValue(txtAngle, (double)(sender as TrackBar).Value);

            this.Modify();
        }

        private void OkApplyModifyGetOnOffCancel_AcceptClicked(object sender, EventArgs e)
        {
            this.Apply();
            this.Close();
        }

        private void OkApplyModifyGetOnOffCancel_ApplyClicked(object sender, EventArgs e)
        {
            this.Apply();
        }

        private void OkApplyModifyGetOnOffCancel_CancelClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkApplyModifyGetOnOffCancel_GetClicked(object sender, EventArgs e)
        {
            this.Get();
        }

        private void OkApplyModifyGetOnOffCancel_ModifyClicked(object sender, EventArgs e)
        {
            this.Modify();
        }
            
        private void OkApplyModifyGetOnOffCancel_OnOffClicked(object sender, EventArgs e)
        {
            this.ToggleSelection();
        }
    }
}
