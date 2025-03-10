using Tekla.Structures;
using Tekla.Structures.Model;
using Tekla.Structures.CustomPropertyPlugin;

namespace CustomProperty2025
{
    [CustomPropertyPlugin("CUSTOM.TEKLAVERSION")]
    public class CustomProperty2025 : ICustomPropertyPlugin
    {
        public int GetIntegerProperty(int objectId)
        {
            return 2025;
        }

        public double GetDoubleProperty(int objectId)
        {
            return 2025.0;
        }

        public string GetStringProperty(int objectId)
        {
            return "TS version - 2025 Beta";
        }
    }
}
