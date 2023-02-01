using System;

using Tekla.Structures.Geometry3d;
using Tekla.Structures.Plugins;
using Tekla.Structures.Catalogs;
using TSM = Tekla.Structures.Model;

namespace BeamCustomPart
{

    // Data structure for the plug-in dialog attributes.
    public class StructuresData
    {
        [StructuresField("LengthFactor")]
        public double LengthFactor;
        [StructuresField("Profile")]
        public string Profile;
    }

    /// <summary>
    /// The plugin asks the user to pick two points.
    /// The plug-in then calculates new insertion points using a double parameter from the 
    /// dialog and creates a tapered beam based on profile parameter.
    /// </summary>
    [Plugin("BeamCustomPart")] // Mandatory field which defines that the class is a plug-in-and stores the name of the plug-in to the system.
    [PluginUserInterface("BeamCustomPart.BeamCustomPartForm")] // Mandatory field which defines the user interface the plug-in uses. A windows form class of a .inp file.
    [CustomPartPositioningType(CustomPartPositioningType.POSITIONING_BY_INPUTPOINTS)]
    //[CustomPartPositioningType(CustomPartPositioningType.POSITIONING_BY_CENTER_OF_BOUNDING_BOX)]
    public class BeamCustomPart : CustomPartBase
    {
        private double lengthFactor;
        private string profile;
        private double flangeThickness;
        private double flangeWidth;
        private double webHeight;
        private double webThickness;

        // The constructor argument defines the database class StructuresData and set the data to be used in the plug-in.
        public BeamCustomPart(StructuresData data)
        {
            this.Data = data;
        }

        private StructuresData Data { get; set; }

        // Main method of the plug-in.
        public override bool Run()
        {
            try
            {
                this.GetValuesFromDialog();

                Point point1 = (Point)this.Positions[0];
                Point point2 = (Point)this.Positions[1];
                Point lengthVector = new Point(point2.X - point1.X, point2.Y - point1.Y, point2.Z - point1.Z);

                if (this.lengthFactor > 0)
                {
                    point2.X = this.lengthFactor * lengthVector.X + point1.X;
                    point2.Y = this.lengthFactor * lengthVector.Y + point1.Y;
                    point2.Z = this.lengthFactor * lengthVector.Z + point1.Z;
                }

                this.CreateTaperedBeam(point1, point2);
            }
            catch (Exception ex)
            {
                Tekla.Structures.Model.Operations.Operation.DisplayPrompt(ex.Message);
            }

            return true;
        }

        // Creates top flange for beam
        private void CreateTopFlangePlate(Point point1, Point point2)
        {
            TSM.Beam myBeam = new TSM.Beam(new Point(point1), new Point(point2));
            myBeam.StartPoint.Y = myBeam.StartPoint.Y + this.webHeight / 2.0;
            myBeam.EndPoint.Y = myBeam.EndPoint.Y + this.webHeight / 2.0;

            string profileString = "PL" + this.flangeThickness.ToString() + "*" + this.flangeWidth.ToString();
            myBeam.Profile.ProfileString = profileString.Replace(",", "."); // convert to Invariant Culture

            myBeam.Finish = "PAINT";
            myBeam.Position.Depth = TSM.Position.DepthEnum.MIDDLE;
            myBeam.Position.Plane = TSM.Position.PlaneEnum.RIGHT;
            myBeam.Position.Rotation = TSM.Position.RotationEnum.BELOW;

            // With this we help internal code to assign same ID to top flange plate when plugin is modified.
            // To avoid some problems related to links with UDA values or booleans (cuts, fittings) for example.
            myBeam.SetLabel("MyTopFlangePlate");

            myBeam.Insert();
        }

        // Creates bottom flange for beam
        private void CreateBottomFlangePlate(Point point1, Point point2)
        {
            TSM.Beam myBeam = new TSM.Beam(new Point(point1), new Point(point2));
            myBeam.StartPoint.Y = myBeam.StartPoint.Y - this.webHeight / 2.0;
            myBeam.EndPoint.Y = myBeam.EndPoint.Y - this.webHeight / 2.0;

            string profileString = "PL" + this.flangeThickness.ToString() + "*" + this.flangeWidth.ToString();
            myBeam.Profile.ProfileString = profileString.Replace(",", "."); // convert to Invariant Culture
            myBeam.Finish = "PAINT";
            myBeam.Position.Depth = TSM.Position.DepthEnum.MIDDLE;
            myBeam.Position.Plane = TSM.Position.PlaneEnum.LEFT;
            myBeam.Position.Rotation = TSM.Position.RotationEnum.TOP;

            // With this we help internal code to assign same ID to bottom flange plate when plugin is modified.
            // To avoid some problems related to links with UDA values or booleans (cuts, fittings) for example.
            myBeam.SetLabel("MyBottomFlangePlate");

            myBeam.Insert();
        }

        // Creates web plate for beam
        private void CreateWebPlate(Point point1, Point point2)
        {
            TSM.Beam myBeam = new TSM.Beam(new Point(point1), new Point(point2));

            string profileString = "PL" + this.webThickness.ToString() + "*" + (this.webHeight - 2.0 * this.flangeThickness).ToString();
            myBeam.Profile.ProfileString = profileString.Replace(",", "."); // convert to Invariant Culture
            myBeam.Finish = "PAINT";
            myBeam.Position.Depth = TSM.Position.DepthEnum.MIDDLE;
            myBeam.Position.Plane = TSM.Position.PlaneEnum.MIDDLE;
            myBeam.Position.Rotation = TSM.Position.RotationEnum.BACK;

            // With this we help internal code to assign same ID to web plate when plugin is modified.
            // To avoid some problems related to links with UDA values or booleans (cuts, fittings) for example.
            myBeam.SetLabel("MyWebPlate");

            myBeam.Insert();
        }

        // Creates tapered beam
        private void CreateTaperedBeam(Point point1, Point point2)
        {
            ProfileItem item = null;

            ParametricProfileItem paramtericItem = new ParametricProfileItem();
            if (paramtericItem.Select(this.profile) && paramtericItem.ProfileItemType == ProfileItem.ProfileItemTypeEnum.PROFILE_I)
                item = paramtericItem;

            if (item == null)
            {
                LibraryProfileItem libraryItem = new LibraryProfileItem();
                if (libraryItem.Select(this.profile) && libraryItem.ProfileItemType == ProfileItem.ProfileItemTypeEnum.PROFILE_I)
                    item = libraryItem;
            }

            if (item != null)
            {
                foreach (ProfileItemParameter p in item.aProfileItemParameters)
                {
                    if (p.Symbol == "h")
                        this.webHeight = p.Value;
                    if (p.Symbol == "s")
                        this.webThickness = p.Value;
                    if (p.Symbol == "b")
                        this.flangeWidth = p.Value;
                    if (p.Symbol == "t")
                        this.flangeThickness = p.Value;
                }

                this.CreateTopFlangePlate(new Point(point1), new Point(point2));
                this.CreateBottomFlangePlate(new Point(point1), new Point(point2));
                this.CreateWebPlate(new Point(point1), new Point(point2));
            }
        }

        // Gets the values from the dialog and sets the default values if needed
        private void GetValuesFromDialog()
        {
            this.lengthFactor = this.Data.LengthFactor;
            this.profile = this.Data.Profile;
            if (this.IsDefaultValue(this.lengthFactor))
            {
                this.lengthFactor = 2.0;
            }
            if (this.IsDefaultValue(this.profile))
            {
                this.profile = "HEA300";
            }
        }

    }
}
