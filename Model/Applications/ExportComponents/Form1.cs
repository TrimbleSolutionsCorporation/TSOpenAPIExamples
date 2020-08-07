using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExportComponents
{
    public partial class Form1 : Form
    {
        #region Fields and Initialization
        private string SelectedFormat_Name = string.Empty;
        private int SelectedFormat_Number = 0;
        private string SelectedFile = string.Empty;
        public Form1()
        {
            InitializeComponent();

            if (!new Tekla.Structures.Model.Model().GetConnectionStatus())
            {
                MessageBox.Show("TeklaStructures is not running, restart the application when a TeklaStructures model is open", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Nothing to do here, all controls must be disabled.
                this.comboBoxFormat.Enabled = false;
                this.labelFormat.ForeColor = System.Drawing.SystemColors.ControlDark;
            }
        }
        #endregion

        #region UI Events
        private void comboBoxFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxFormat.Text)
            {
                case "BVBS":
                    FillAttributeComboBox("BvbsExport.BvbsExportForm.xml");
                    SelectedFormat_Number = Tekla.Structures.Model.BaseComponent.PLUGIN_OBJECT_NUMBER; //Mandatory
                    SelectedFormat_Name = "BVBSExport"; // Mandatory
                    break;
                case "CAD":
                    FillAttributeComboBox("m1000007");
                    SelectedFormat_Number = 1000007;
                    SelectedFormat_Name = "CAD"; // It can be anything
                    break;
                case "CIS Analysis":
                    FillAttributeComboBox("m10000011");
                    SelectedFormat_Number = 10000011;
                    SelectedFormat_Name = "CIS Analysis"; // It can be anything
                    break;
                case "CIS Manufacturing":
                    FillAttributeComboBox("m10000026");
                    SelectedFormat_Number = 10000026;
                    SelectedFormat_Name = "CIS Manufacturing"; // It can be anything
                    break;
                case "DGN":
                    FillAttributeComboBox("m440000003");
                    SelectedFormat_Number = 440000003;
                    SelectedFormat_Name = "DGN"; // It can be anything
                    break;
                case "DWG/DXF":
                    FillAttributeComboBox("m440000004");
                    SelectedFormat_Number = 440000004;
                    SelectedFormat_Name = "Tekla Structures DWG-DXF Export"; // It can be anything
                    break;
                case "ELiPLAN":
                    FillAttributeComboBox("m170000068");
                    SelectedFormat_Number = 170000068;
                    SelectedFormat_Name = "ELiPLAN"; // It can be anything
                    break;
                case "FEM":
                    FillAttributeComboBox("m1000004");
                    SelectedFormat_Number = 1000004;
                    SelectedFormat_Name = "FEM"; // It can be anything
                    break;
                case "IFC":
                    FillAttributeComboBox("IFCExportPlugin.MainDialog.xml");
                    SelectedFormat_Number = Tekla.Structures.Model.BaseComponent.PLUGIN_OBJECT_NUMBER; //Mandatory
                    SelectedFormat_Name = "ExportIFC"; // Mandatory
                    break;
            }

            comboBoxFile.Enabled = true;
            labelFile.ForeColor = System.Drawing.SystemColors.ControlText;
            comboBoxFile.Text = string.Empty;
            this.buttonExport.Enabled = false;
            this.buttonExport.ForeColor = System.Drawing.SystemColors.ControlDark;
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void comboBoxFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonExport.Enabled = true;
            buttonExport.ForeColor = System.Drawing.SystemColors.ControlText;
            SelectedFile = comboBoxFile.Text;
        }
        #endregion

        #region Private methods
        private void FillAttributeComboBox(string ExportFormat)
        {
            this.comboBoxFile.Items.Clear();

            List<string> folders = Tekla.Structures.Dialog.UIControls.EnvironmentFiles.GetStandardPropertyFileDirectories();
            List<string> viewPropertyFiles = Tekla.Structures.Dialog.UIControls.EnvironmentFiles.GetMultiDirectoryFileList(folders, ExportFormat);
            foreach (string propertyFile in viewPropertyFiles)
            {
                this.comboBoxFile.Items.Add(propertyFile);
            }
        }

        private void Export()
        {
            var componentInput = new Tekla.Structures.Model.ComponentInput();
            componentInput.AddOneInputPosition(new Tekla.Structures.Geometry3d.Point(0, 0, 0));
            var component = new Tekla.Structures.Model.Component(componentInput);
            component.Name = SelectedFormat_Name;
            component.Number = SelectedFormat_Number;
            component.LoadAttributesFromFile(SelectedFile);

            // It is also possible to set individual attributes with code
            //component.SetAttribute("outtype", 0);
            //component.SetAttribute("outfile", OutputFileName);
            //component.SetAttribute("cuts", 0);
            //component.SetAttribute("boltaccuracy", 2);
            //component.SetAttribute("partaccuracy", 1);
            //component.SetAttribute("includedobjects", 1);
            //component.SetAttribute("exporttype", 0);

            if (component.Insert())
            {
                MessageBox.Show("Export component inserted correctly!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error when inserting export component", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}