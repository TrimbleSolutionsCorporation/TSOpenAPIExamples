using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Tekla.Structures.Dialog;


namespace WPFConnection
{
    /// <summary>
    /// Interaction logic for MainPluginWindow.xaml
    /// </summary>
    public partial class MainWindow : PluginWindowBase
    {
        #region Global Variables
        public MainWindowViewModel dataModel;

        #region Custom Weld Form from Offshore Library 
        public static MainWindow mainWindow;
        #endregion

        #endregion
        public MainWindow(MainWindowViewModel DataModel)
        {
            InitializeComponent();
            dataModel = DataModel;
            #region Custom Weld Form and Part Form from Offshore Library
            mainWindow = this;
            Loaded += MainWindow_Loaded;
            #endregion

        }
        #region Custom Weld Form and Part Form from Offshore Library
        public static void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //This method is used to update the weld button Info based on the Tag (weld parameter properties)
            //Find all Buttons from the form
            List<Button> listButtons = new List<Button>();
            GetLogicalChildCollection(mainWindow, listButtons);
            foreach (Button button in listButtons)
            {
                //If a Tag property available for a button then execute
                if(button.Tag != null)
                {
                    if (!string.IsNullOrEmpty(button.Tag.ToString()))
                    {
                        //Update the Weld button information using the Tag (weld parameter)
                        UpdateWeldButtonInfo(button);
                    }
                }
            }
        }

        private static void GetLogicalChildCollection<T>(DependencyObject parent, List<T> logicalCollection) where T : DependencyObject
        {
            IEnumerable children = LogicalTreeHelper.GetChildren(parent);
            foreach (object child in children)
            {
                if (child is DependencyObject)
                {
                    DependencyObject depChild = child as DependencyObject;
                    if (child is T)
                    {
                        logicalCollection.Add(child as T);
                    }
                    GetLogicalChildCollection(depChild, logicalCollection);
                }
            }
        }
        #endregion

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
            MainWindow_Loaded(sender, new RoutedEventArgs());
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
        #region Custom Weld Form from Offshore Library
        private void WeldButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            string WeldParams = button.Tag.ToString();
            if (string.IsNullOrEmpty(WeldParams))
            {
                WeldParams = "";
            }
            Window parentWindow = this;

            UpdateWeldButtonInfo(button);
        }

        private static void UpdateWeldButtonInfo(Button sender)
        {
        }

        private void SetButtonTagProperty(Button sender, string Param)
        {
            sender.Tag = Param;
        }
        #endregion
        #region Mouse Hover Action
        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(@"/TeklaWPFConnection;component/Resources/Main2.bmp", UriKind.RelativeOrAbsolute);
            logo.EndInit();
        }

        private void Button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(@"/TeklaWPFConnection;component/Resources/Main.bmp", UriKind.RelativeOrAbsolute);
            logo.EndInit();
        }
        #endregion

        private void PartButton_Click(object sender, RoutedEventArgs e)
        {
            Button partbutton = (Button)sender;

            string PartParams = partbutton.Tag.ToString();
            if (string.IsNullOrEmpty(PartParams))
            {
                PartParams = "";
            }
            Window parentWindow = this;
        }
    }
}
