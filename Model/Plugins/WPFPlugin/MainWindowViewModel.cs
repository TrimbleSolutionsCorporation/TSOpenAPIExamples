using System.ComponentModel;
using TD = Tekla.Structures.Datatype;
using Tekla.Structures.Dialog;
using System.Globalization;

namespace WPFPlugin
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
        #endregion

        #region Properties
        [StructuresDialog("name",typeof(TD.String))]
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

    }
}
