using System;
using System.Windows.Forms;
using System.IO;

using Tekla.Structures;
using Tekla.Structures.Model;
using TSMO = Tekla.Structures.Model.Operations;

namespace CNC_Exporter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            # region connection to Tekla Structures and basic model path, version information

            Model Model1 = new Model();
            string modelname = Model1.GetInfo().ModelName;
            string modelpath = Model1.GetInfo().ModelPath;
            string configuration = ModuleManager.Configuration.ToString();
            string TSversion = TeklaStructuresInfo.GetCurrentProgramVersion();
            string macrodir = "";
            TeklaStructuresSettings.GetAdvancedOption("XS_MACRO_DIRECTORY", ref macrodir);

            # endregion

            // This will be the folder inside of the current Tekla Structures Model folder where the CNC files will be stored.
            string CNC_Files = "CNC_Output";

            if (!Directory.Exists(modelpath + @"\" + CNC_Files))
            {
                Directory.CreateDirectory(modelpath + @"\" + CNC_Files);
            }

            // This creates the macro file if it doesn't exist in order to create the DSTV files.
            if (!File.Exists(macrodir + @"\modeling\CreateDstv.cs"))
            {
                StreamWriter SW3 = new StreamWriter(macrodir + @"\modeling\CreateDstv.cs");
                SW3.Write(Resource1.CreateDSTV);
                SW3.Close();
            }

            // This just writes a text file for the macro script to use to export the DSTV files
            StreamWriter SW4 = new StreamWriter(modelpath + @"\CNCProps.txt");
            // "Saved" CNC settings to that the script "loads" up and used from CNC dialog box
            SW4.WriteLine("standard");
            // The folder where the CNC files will be written to
            SW4.WriteLine("");
            SW4.WriteLine(CNC_Files);
            SW4.Close();
            // This runs the script which reads the above SW4 Text file that was written.
            // This code below works for version 16.0
            TSMO.Operation.RunMacro("CreateDstv.cs");
            // This code below works for version 15.0
            //Model1.RunMacro("CreateDstv.cs");

            // This just tells this application to wait for the Macro thread in Tekla Structures to be complete
            // then continue on.
            while (TSMO.Operation.IsMacroRunning())
            {
                // just leave empty as it is only there to wait until the macro is done running
            }

            if (MessageBox.Show("DSTV Export Complete. Do you want me to open the Folder?", "Export Complete Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string filepath = modelpath + @"\" + CNC_Files;
                System.Diagnostics.Process Explorer = new System.Diagnostics.Process();
                Explorer.EnableRaisingEvents = false;
                Explorer.StartInfo.FileName = "explorer";
                Explorer.StartInfo.Arguments = "\"" + filepath + "\"";
                Explorer.Start();
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            # region connection to Tekla Structures and basic model path, version information

            Model Model1 = new Model();
            string modelname = Model1.GetInfo().ModelName;
            string modelpath = Model1.GetInfo().ModelPath;
            string configuration = ModuleManager.Configuration.ToString();
            string TSversion = TeklaStructuresInfo.GetCurrentProgramVersion();

            # endregion

            // This will be the folder inside of the current Tekla Structures Model folder where the CNC files will be stored.
            // In this example it was important to put a "\" at the end of the CNC_Files Directory string below.
            string CNC_Files = @"CNC_Output\";

            if (!Directory.Exists(modelpath + @"\" + CNC_Files))
            {
                Directory.CreateDirectory(modelpath + @"\" + CNC_Files);
            }

            // The only bad thing about this way is you have to know which CNC settings in the list you want to use
            // There isn't an enumerator or collection of all the settings that appear in the list.
            // The only way to get a list of all the settings is to search in the Tekla search paths like XS_SYSTEM,
            // XS_FIRM, XS_PROJECT, and Model Attributes folders for the *.ncf files. Then read through that file
            // for the NC settings that you would use in the methods shown directly below.

            bool Create1 = TSMO.Operation.CreateNCFilesFromSelected("DSTV for plates", modelpath + @"\" + CNC_Files);
            bool Create2 = TSMO.Operation.CreateNCFilesFromSelected("DSTV for profiles", modelpath + @"\" + CNC_Files);

            // This was just to output if the files were being created
            //MessageBox.Show(Create1 + " " + Create2);

            if (MessageBox.Show("DSTV Export Complete. Do you want me to open the Folder?", "Export Complete Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string filepath = modelpath + @"\" + CNC_Files;
                System.Diagnostics.Process Explorer = new System.Diagnostics.Process();
                Explorer.EnableRaisingEvents = false;
                Explorer.StartInfo.FileName = "explorer";
                Explorer.StartInfo.Arguments = "\"" + filepath + "\"";
                Explorer.Start();
            }
        }
    }
}