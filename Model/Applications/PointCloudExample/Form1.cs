using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Tekla.Structures.Model;
using Tekla.Structures.Model.PointCloudDataServices;
using Tekla.Structures.Model.UI;

namespace PointCloudExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            this.textBox1.Text = this.openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool result = File.Exists(this.textBox1.Text);

            PointCloud pointCloud = new PointCloud
            {
                OriginalPath = this.textBox1.Text, // Local file
                // Url = "http://TestUrlAddress/TestPointCloud/", // Web file
                LocationBy = Guid.Empty,
                Scale = 1.0
            };

            pointCloud.Attach();

            List<Tekla.Structures.Model.UI.View> viewList = new List<Tekla.Structures.Model.UI.View>();
            var mve = ViewHandler.GetVisibleViews();
            
            while(mve.MoveNext())
            {
                viewList.Add(mve.Current);
            }

            pointCloud.SetVisibility(viewList, true);
        }

        private void buttonTCPointCloud_Click(object sender, EventArgs e)
        {
            Form1 programInstance = new Form1();
            programInstance.AttachPointCloudFromTCProject().GetAwaiter().GetResult();
        }

        public async System.Threading.Tasks.Task AttachPointCloudFromTCProject()
        {
            var projects = await PointCloudDataServices.GetProjectsWithPointCloudsAsync();
            var pointClouds = projects.First().PointClouds;
            var url = await PointCloudDataServices.GetPointCloudUrlAsync(projects.First(), pointClouds.First());

            PointCloud pointCloud = new PointCloud
            {
                Name = pointClouds.First().Name,
                Url = url,
                TcProjectId = projects.First().Id,
                TcPointCloudGuid = pointClouds.First().Id,
                LocationBy = Guid.Empty,
                UseAutoCreatedBasePoint = true,
                Scale = 1.0
            };

            pointCloud.Attach();
        }
    }
}
