using System;
using System.ComponentModel.Composition;

using Tekla.Structures;
using Tekla.Structures.Model;
using Tekla.Structures.CustomPropertyPlugin;

namespace CustomPropertyTest
{
    /// <summary>The test plugin for object top level.</summary>
    [Export(typeof(ICustomPropertyPlugin))]
    [ExportMetadata("CustomProperty", "CUSTOM.OBJECTTOPLEVEL")]
    public class ObjectTopLevelCustomPropertyExample : ICustomPropertyPlugin
    {
        private Model model = new Model();
        /// <summary>Returns custom property int value for object.</summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int GetIntegerProperty(int objectId)
        {
            return GetObjectTopLevel(objectId);
        }

        /// <summary>Returns custom property string value for object.</summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string GetStringProperty(int objectId)
        {
            return GetObjectTopLevel(objectId).ToString();
        }

        /// <summary>Returns custom property double value for object.</summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The <see cref="double"/>.</returns>
        public double GetDoubleProperty(int objectId)
        {
            return GetObjectTopLevel(objectId);
        }

        private int GetObjectTopLevel(int objectId)
        {
            Model model = new Model();
            var oldPlane = model.GetWorkPlaneHandler().GetCurrentTransformationPlane();
            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane());
            var modelObject = model.SelectModelObject(new Identifier(objectId));
            Solid solid = null;

            if (modelObject is Part)
                solid = (modelObject as Part).GetSolid();

            if (modelObject is Reinforcement)
                solid = (modelObject as Reinforcement).GetSolid();

            if (modelObject is BoltGroup)
                solid = (modelObject as BoltGroup).GetSolid();

            if (modelObject is BaseWeld)
                solid = (modelObject as BaseWeld).GetSolid();

            model.GetWorkPlaneHandler().SetCurrentTransformationPlane(oldPlane);

            if (solid == null || !solid.IsValid()) return Int32.MinValue;

            double maxZ = Math.Round(solid.MaximumPoint.Z);

            return (int)maxZ;
        }
    }
}