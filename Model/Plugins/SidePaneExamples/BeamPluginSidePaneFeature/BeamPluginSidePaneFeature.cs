using Tekla.Structures.Plugins.PropertyPane;

namespace BeamPluginSidePaneFeature
{
    // After being compiled, BeamPluginSidePaneFeature.dll must be copied to folder: \Environments\common\extensions\features
    public class BeamPluginSidePaneFeature : PluginPropertyPaneFeatureBase
    {
        public BeamPluginSidePaneFeature()
        {
            // BeamPlugin project is also available in TeklaStructures Open API Examples solution
            this.InitializeFeature("BeamPlugin", "BeamPlugin", "no_help_implemented", PropertyPaneType.Plugin, string.Empty, false);
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
