using Tekla.Structures.Plugins.PropertyPane;

namespace SpliceConnSidePaneFeature
{
    public class SpliceConnSidePaneFeature : PluginPropertyPaneFeatureBase
    {
        public SpliceConnSidePaneFeature()
        {
            //InitializeFeature("SpliceConnection", "Title", string.Empty);
            this.InitializeFeature("SpliceConnection", "SpliceConnection", "no_help_implemented", PropertyPaneType.Connection, string.Empty, false);
            BuildTemplate();
        }

        private void BuildTemplate()
        {
            AddPropertyGroup("Props", "General Properties");
            AddSingleProperty("Props", Single.Double, "PlateLength", "Plate Length", "Not in use");
            AddSingleProperty("Props", Single.String, "BoltStandard", "Bolt Standard", "Not in use");

            AddPropertyGroup("General", "General");
            AddSingleProperty("General", Single.Integer, "OBJECT_LOCKED", "Object locked", "1 to lock");
            AddSingleProperty("General", Single.Integer, "group_no", "Class", "class");
        }
    }
}
