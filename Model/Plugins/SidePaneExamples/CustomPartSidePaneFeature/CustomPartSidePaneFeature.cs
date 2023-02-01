using Tekla.Structures.Plugins.PropertyPane;

namespace CustomPartExamplePaneFeature
{
    // After being compiled, CustomPartSidePaneFeature.dll must be copied to folder: \Environments\common\extensions\features
    public class CustomPartSidePaneFeature : PluginPropertyPaneFeatureBase
    {
        public CustomPartSidePaneFeature()
        {
            // BeamCustomPart project is also available in TeklaStructures Open API Examples solution
            this.InitializeFeature("BeamCustomPart", "BeamCustomPart", "no_help_implemented", PropertyPaneType.CustomPart, string.Empty, false);
            BuildTemplate();
        }

        private void BuildTemplate()
        {
            AddPropertyGroup("Props", "General Properties");
            AddCatalogProperty("Props", Catalog.Profile, "Profile", "", "", "Beam Profile", "");

            AddPropertyGroup("General", "General");
            AddSingleProperty("General", Single.Double, "LengthFactor", "Length Factor: ", "");
        }
    }
}
