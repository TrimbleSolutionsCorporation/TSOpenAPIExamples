using System.Collections;
using System.ComponentModel;
using TD = Tekla.Structures.Datatype;
using TSG = Tekla.Structures.Geometry3d;
using Tekla.Structures.Dialog;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Model.Operations;

namespace WpfBeamApplication
{
    /// <summary>
    /// Data logic for MainWindow
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string partname = string.Empty;
        private string profile = string.Empty;
        private TD.Distance offset = new TD.Distance();
        private string material = string.Empty;
        private string componentname = string.Empty;
        private int componentnumber = 0;
        private string boltstandard = string.Empty;
        private TD.Distance boltsize = new TD.Distance();
        private string rebarGrade = string.Empty;
        private string rebarSize = string.Empty;
        private double rebarBend = 0;
        private string meshGrade = string.Empty;
        private string meshName = string.Empty;
        private string shapeName = string.Empty;
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
        [StructuresDialog("boltstandard", typeof(TD.String))]
        public string BoltStandard
        {
            get { return boltstandard; }
            set { boltstandard = value; OnPropertyChanged("BoltStandard"); }
        }
        [StructuresDialog("boltsize", typeof(TD.Distance))]
        public TD.Distance BoltSize
        {
            get { return boltsize; }
            set { boltsize = value; OnPropertyChanged("BoltSize"); }
        }
        [StructuresDialog("rebargrade", typeof(TD.String))]
        public string RebarGrade
        {
            get { return rebarGrade; }
            set { rebarGrade= value; OnPropertyChanged("RebarGrade"); }
        }
        [StructuresDialog("rebarsize", typeof(TD.String))]
        public string RebarSize
        {
            get { return rebarSize; }
            set { rebarSize= value; OnPropertyChanged("RebarSize"); }
        }
        [StructuresDialog("rebarbend", typeof(TD.Double))]
        public double RebarBend
        {
            get { return rebarBend; }
            set { rebarBend = value; OnPropertyChanged("RebarBend"); }
        }
        [StructuresDialog("meshgrade", typeof(TD.String))]
        public string MeshGrade
        {
            get { return meshGrade; }
            set { meshGrade = value; OnPropertyChanged("MeshGrade"); }
        }
        [StructuresDialog("meshname", typeof(TD.String))]
        public string MeshName
        {
            get { return meshName; }
            set { meshName = value; OnPropertyChanged("MeshName"); }
        }
        [StructuresDialog("shapename", typeof(TD.String))]
        public string ShapeName
        {
            get { return shapeName; }
            set { shapeName = value; OnPropertyChanged("ShapeName"); }
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

        public void CreateBeam()
        {
            Picker picker = new Picker();
            ArrayList PickedPoints = picker.PickPoints(Picker.PickPointEnum.PICK_TWO_POINTS, "Give beam points.. ");

            CheckDefaultValues();

            TSG.Point startPoint = PickedPoints[0] as TSG.Point;
            TSG.Point endPoint = PickedPoints[1] as TSG.Point;

            Beam beam = new Beam(startPoint, endPoint);
            beam.Position.PlaneOffset = this.offset.Millimeters;
            beam.Name = this.partname;
            beam.Profile.ProfileString = this.profile;
            beam.Material.MaterialString = this.material;
            beam.Insert();

            Operation.DisplayPrompt("Selected bolt " + this.boltstandard + ":" + this.boltsize.Millimeters.ToString());

            new Model().CommitChanges();
        }

        #region Private methods
        /// <summary>
        /// Gets the values from the dialog and sets the default values if needed
        /// </summary>
        private void CheckDefaultValues()
        {
            if (this.partname == string.Empty)
                this.partname = "TEST";
            if (this.profile == string.Empty)
                this.profile = "HEA300";
            if (this.material == string.Empty)
                this.material = "STEEL_UNDEFINED";
            if (this.offset.Millimeters == double.MinValue)
                this.offset.Millimeters = 0;
        }

        #endregion

    }
}
