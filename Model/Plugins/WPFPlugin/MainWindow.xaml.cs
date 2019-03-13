using System;
using System.Windows;
using System.ComponentModel;
using Tekla.Structures.Dialog;

namespace WPFPlugin
{
    /// <summary>
    /// Interaction logic for MainPluginWindow.xaml
    /// </summary>
    public partial class MainWindow : PluginWindowBase
    {
        // define event
        public MainWindowViewModel dataModel;

        public MainWindow(MainWindowViewModel DataModel)
        {
            InitializeComponent();
            dataModel = DataModel;
        }

        private void WPFOkApplyModifyGetOnOffCancel_ApplyClicked(object sender, EventArgs e)
        {
            this.Apply();
        }

        private void WPFOkApplyModifyGetOnOffCancel_CancelClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WPFOkApplyModifyGetOnOffCancel_GetClicked(object sender, EventArgs e)
        {
            this.Get();
        }

        private void WPFOkApplyModifyGetOnOffCancel_ModifyClicked(object sender, EventArgs e)
        {
            this.Modify();
        }

        private void WPFOkApplyModifyGetOnOffCancel_OkClicked(object sender, EventArgs e)
        {
            this.Apply();
            this.Close();
        }

        private void WPFOkApplyModifyGetOnOffCancel_OnOffClicked(object sender, EventArgs e)
        {
            this.ToggleSelection();
        }

        private void WPFMaterialCatalog_SelectClicked(object sender, EventArgs e)
        {
            this.materialCatalog.SelectedMaterial = this.dataModel.Material;
        }

        private void WPFMaterialCatalog_SelectionDone(object sender, EventArgs e)
        {
            this.dataModel.Material = this.materialCatalog.SelectedMaterial;
        }

        private void profileCatalog_SelectClicked(object sender, EventArgs e)
        {
            this.profileCatalog.SelectedProfile = this.dataModel.Profilename;
        }

        private void profileCatalog_SelectionDone(object sender, EventArgs e)
        {
            this.dataModel.Profilename = this.profileCatalog.SelectedProfile;
        }
        private void componentCatalog_SelectClicked(object sender, EventArgs e)
        {
            this.componentCatalog.SelectedName = this.dataModel.ComponentName;
            this.componentCatalog.SelectedNumber = this.dataModel.ComponentNumber;
        }

        private void componentCatalog_SelectionDone(object sender, EventArgs e)
        {
            this.dataModel.ComponentName = this.componentCatalog.SelectedName;
            this.dataModel.ComponentNumber = this.componentCatalog.SelectedNumber;
        }
    }
}
