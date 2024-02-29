using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tekla.Structures.Dialog;

namespace WpfBeamApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ApplicationWindowBase
    {
        MainWindowViewModel viewModel = new MainWindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel;
            this.InitializeDataStorage(viewModel);
            if(this.GetConnectionStatus())
            { 
                InitializeDistanceUnitDecimals();
            }
        }

        private void WPFOkCreateCancel_CancelClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WPFOkCreateCancel_CreateClicked(object sender, EventArgs e)
        {
            new Task(delegate
            {
                this.viewModel.CreateBeam();
            }).Start();
        }

        private void WPFOkCreateCancel_OkClicked(object sender, EventArgs e)
        {
            new Task(delegate
            {
                this.viewModel.CreateBeam();
            }).Start();
            this.Close();
        }

        private void materialCatalog_SelectClicked(object sender, EventArgs e)
        {
            this.materialCatalog.SelectedMaterial = this.viewModel.Material;
        }

        private void materialCatalog_SelectionDone_1(object sender, EventArgs e)
        {
            this.viewModel.Material = this.materialCatalog.SelectedMaterial;
        }

        private void profileCatalog_SelectClicked(object sender, EventArgs e)
        {
            this.profileCatalog.SelectedProfile = this.viewModel.Profilename;
        }

        private void profileCatalog_SelectionDone(object sender, EventArgs e)
        {
            this.viewModel.Profilename = this.profileCatalog.SelectedProfile;
        }

        private void componentCatalog_SelectClicked(object sender, EventArgs e)
        {
            this.componentCatalog.SelectedName = this.viewModel.ComponentName;
            this.componentCatalog.SelectedNumber = this.viewModel.ComponentNumber;
        }

        private void componentCatalog_SelectionDone(object sender, EventArgs e)
        {
            this.viewModel.ComponentName = this.componentCatalog.SelectedName;
            this.viewModel.ComponentNumber = this.componentCatalog.SelectedNumber;
        }

        private void rebarCatalog_SelectClicked(object sender, EventArgs e)
        {
            this.rebarCatalog.SelectedRebarGrade = this.viewModel.RebarGrade;
            this.rebarCatalog.SelectedRebarSize = this.viewModel.RebarSize;
            this.rebarCatalog.SelectedRebarBendingRadius = this.viewModel.RebarBend;
        }

        private void rebarCatalog_SelectionDone(object sender, EventArgs e)
        {
            this.viewModel.RebarGrade = this.rebarCatalog.SelectedRebarGrade;
            this.viewModel.RebarSize = this.rebarCatalog.SelectedRebarSize;
            this.viewModel.RebarBend = this.rebarCatalog.SelectedRebarBendingRadius;
        }

        private void meshCatalog_SelectClicked(object sender, EventArgs e)
        {
            this.meshCatalog.SelectedMeshGrade = this.viewModel.MeshGrade;
            this.meshCatalog.SelectedMeshName = this.viewModel.MeshName;
        }

        private void meshCatalog_SelectionDone(object sender, EventArgs e)
        {
            this.viewModel.MeshGrade = this.meshCatalog.SelectedMeshGrade;
            this.viewModel.MeshName = this.meshCatalog.SelectedMeshName;
        }

        private void shapeCatalog_SelectClicked(object sender, EventArgs e)
        {
            this.shapeCatalog.SelectedShape = this.viewModel.ShapeName;
        }

        private void shapeCatalog_SelectionDone(object sender, EventArgs e)
        {
            this.viewModel.ShapeName = this.shapeCatalog.SelectedShape;
        }
    }
}
