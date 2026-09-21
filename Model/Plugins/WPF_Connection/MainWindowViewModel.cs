using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Tekla.Structures.Dialog;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using TD = Tekla.Structures.Datatype;

namespace WPFConnection
{
    /// <summary>
    /// Data logic for MainWindow
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string partname = string.Empty;
        private string profile = string.Empty;
        private string material = string.Empty;
        private TD.Distance offset = new TD.Distance();
        private string componentname = string.Empty;
        private int componentnumber = 0;
        private int lengthfactor = 0;

        #region General Tab Properties
        private int zsuunta = 0;
        private double zang1 = 0.0;
        private double zang2 = 0.0;
        private int OBJECT_LOCKED = 0;
        private int group_no = 13;
        private string joint_code = string.Empty;
        private string ad_root = string.Empty;
        private string ac_root = string.Empty;
        #endregion

        private string weldButton1 = string.Empty;
        private string weldButton2 = string.Empty;
        private string partButton1 = string.Empty;
        private string partButton2 = string.Empty;
        #endregion

        #region Properties
        #region General Tab Properties
        [StructuresDialog("zsuunta", typeof(TD.Integer))]
        public int Zsuunta
        {
            get { return zsuunta; }
            set { zsuunta = value; OnPropertyChanged("Zsuunta"); }
        }
        [StructuresDialog("zang1", typeof(TD.Double))]
        public double Zang1
        {
            get { return zang1; }
            set { zang1 = value; OnPropertyChanged("Zang1"); }
        }
        [StructuresDialog("zang2", typeof(TD.Double))]
        public double Zang2
        {
            get { return zang2; }
            set { zang2 = value; OnPropertyChanged("Zang2"); }
        }
        [StructuresDialog("OBJECT_LOCKED", typeof(TD.Integer))]
        public int object_LOCKED
        {
            get { return OBJECT_LOCKED; }
            set { OBJECT_LOCKED = value; OnPropertyChanged("object_LOCKED"); }
        }
        [StructuresDialog("group_no", typeof(TD.Integer))]
        public int Group_no
        {
            get { return group_no; }
            set { group_no = value; OnPropertyChanged("Group_no"); }
        }
        [StructuresDialog("joint_code", typeof(TD.String))]
        public string Joint_code
        {
            get { return joint_code; }
            set { joint_code = value; OnPropertyChanged("Joint_code"); }
        }
        [StructuresDialog("ad_root", typeof(TD.String))]
        public string Ad_root
        {
            get { return ad_root; }
            set { ad_root = value; OnPropertyChanged("Ad_root"); }
        }
        [StructuresDialog("ac_root", typeof(TD.String))]
        public string Ac_root
        {
            get { return ac_root; }
            set { ac_root = value; OnPropertyChanged("Ac_root"); }
        }
        #endregion

        [StructuresDialog("name", typeof(TD.String))]
        public string Name
        {
            get { return partname; }
            set { partname = value; OnPropertyChanged("Name"); }
        }
        [StructuresDialog("profile", typeof(TD.String))]
        public string Profilename
        {
            get { return profile; }
            set { profile = value; OnPropertyChanged("Profilename"); }
        }
        [StructuresDialog("offset", typeof(TD.Distance))]
        public TD.Distance Offset
        {
            get { return offset; }
            set { offset = value; OnPropertyChanged("Offset"); }
        }
        [StructuresDialog("material", typeof(TD.String))]
        public string Material
        {
            get { return material; }
            set { material = value; OnPropertyChanged("Material"); }
        }
        [StructuresDialog("componentname", typeof(TD.String))]
        public string ComponentName
        {
            get { return componentname; }
            set { componentname = value; OnPropertyChanged("ComponentName"); }
        }
        [StructuresDialog("componentnumber", typeof(TD.Integer))]
        public int ComponentNumber
        {
            get { return componentnumber; }
            set { componentnumber = value; OnPropertyChanged("ComponentNumber"); }
        }
        [StructuresDialog("lengthfactor", typeof(TD.Integer))]
        public int LengthFactor
        {
            get { return lengthfactor; }
            set { lengthfactor = value; OnPropertyChanged("LengthFactor"); }
        }

        [StructuresDialog("weldButton1", typeof(TD.String))]
        public TD.String WeldButton1
        {
            get { return weldButton1; }
            set { weldButton1 = value; OnPropertyChanged("WeldButton1"); OnWeldChanged(weldButton1); }
        }

        [StructuresDialog("weldButton2", typeof(TD.String))]
        public TD.String WeldButton2
        {
            get { return weldButton2; }
            set { weldButton2 = value; OnPropertyChanged("WeldButton2"); OnWeldChanged(weldButton2); }
        }

        [StructuresDialog("partButton1", typeof(TD.String))]
        public TD.String PartButton1
        {
            get { return partButton1; }
            set { partButton1 = value; OnPropertyChanged("PartButton1"); OnWeldChanged(partButton1); }
        }

        [StructuresDialog("partButton2", typeof(TD.String))]
        public TD.String PartButton2
        {
            get { return partButton2; }
            set { partButton2 = value; OnPropertyChanged("PartButton2"); OnWeldChanged(partButton2); }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #region Custom Weld Form from Offshore Library
        protected void OnWeldChanged(string weldParameter)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                MainWindow.MainWindow_Loaded(null, null);
            }
        }
        #endregion
    }
}
