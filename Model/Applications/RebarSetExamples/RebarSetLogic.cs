using System.Linq;
using Tekla.Structures;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.History;
using Tekla.Structures.Model.UI;

namespace RebarSetExamples
{
    class RebarSetLogic
    {

        // Change hardcoded values to test other rebar properties
        internal class Parameters
        {
            internal const double Width = 800;
            internal const double Depth = 1200;
            internal const double Height = 500;
            internal const string Name = "REBAR";
            internal const double BendingRadius = 20.0;
            internal const double SpacingTarget = 200.0;
            internal const int LayerOrderNumber = 0;
        }

        internal class Message
        {
            internal const string FailInsert = "Failed to insert rebar set";
            internal const string FailSelect = "Failed to select rebar set";
            internal const string FailModify = "Failed to modify rebar set";
            internal const string FailDelete = "Failed to delete rebar set";
            internal const string IncorrectNumberFace = "Incorrect number of faces selected";
            internal const string IncorrectNumberGuideline = "Incorrect number of guidelines selected";
            internal const string IncorrectType = "Incorrect type in ArrayList";
            internal const string IncorrectNumberPoint = "Incorrect number of poinrs in contour";
            internal const string FailInsertAddition = "Failed to insert rebar set addition";
            internal const string IncorrectNumberChildren = "Incorrect number of children";
            internal const string FailIterate = "Failed to iterate model objects";
            internal const string FailInsertPropertyStrip = "Failed to insert property strip";
            internal const string FailSelectPropertyStrip = "Failed to select property strip";
            internal const string FailDeletePropertyStrip = "Failed to delete property strip";
            internal const string FailModifyPropertyStrip = "Failed to modify property strip";
            internal const string FailInsertEndDetailStrip = "Failed to insert end-detail strip";
            internal const string FailSelectEndDetailStrip = "Failed to select end-detail strip";
            internal const string FailDeleteEndDetailStrip = "Failed to delete end-detail strip";
            internal const string FailModifyEndDetailStrip = "Failed to modify end-detail strip";
            internal const string FailInsertSplitter = "Failed to insert splitter";
            internal const string FailSelectSplitter = "Failed to select splitter";
            internal const string FailDeleteSplitter = "Failed to delete splitter";
            internal const string FailModifySplitter = "Failed to modify splitter";
        }

        #region Private Methods

        private static void SetProperties(RebarSet rebarSet)
        {
            rebarSet.RebarProperties.Name = Parameters.Name;
            rebarSet.RebarProperties.Grade = "H";
            rebarSet.RebarProperties.BendingRadius = Parameters.BendingRadius;
            rebarSet.RebarProperties.Class = 7;
            rebarSet.RebarProperties.Size = "10";
            rebarSet.LayerOrderNumber = Parameters.LayerOrderNumber;
        }

        private static void SetProperties(ContourPlate slab)
        {
            slab.AddContourPoint(new ContourPoint(new Point(0.0, 0.0, 0.0), null));
            slab.AddContourPoint(new ContourPoint(new Point(Parameters.Width, 0.0, 0.0), null));
            slab.AddContourPoint(new ContourPoint(new Point(Parameters.Width, Parameters.Depth, 0.0), null));
            slab.AddContourPoint(new ContourPoint(new Point(0.0, Parameters.Depth, 0.0), null));
            slab.Name = "SLAB";
            slab.Profile.ProfileString = "200";
            slab.Material.MaterialString = "C25/30";
            slab.CastUnitType = Part.CastUnitTypeEnum.CAST_IN_PLACE;
        }

        private static RebarLegFace CreateLegFace1()
        {
            var result = new RebarLegFace
            {
                LayerOrderNumber = 2,
                AdditonalOffset = 25.0,
                Reversed = false
            };

            result.Contour.AddContourPoint(new ContourPoint(new Point(0, 0, 0), null));
            result.Contour.AddContourPoint(new ContourPoint(new Point(Parameters.Width, 0, 0), null));
            result.Contour.AddContourPoint(new ContourPoint(new Point(Parameters.Width, Parameters.Depth, 0), null));
            result.Contour.AddContourPoint(new ContourPoint(new Point(0, Parameters.Depth, 0), null));
            return result;
        }

        private static RebarLegFace CreateLegFace2()
        {
            var result = new RebarLegFace
            {
                LayerOrderNumber = 2,
                AdditonalOffset = 25.0,
                Reversed = false
            };

            result.Contour.AddContourPoint(new ContourPoint(new Point(0, 0, 0), null));
            result.Contour.AddContourPoint(new ContourPoint(new Point(0, 0, Parameters.Height), null));
            result.Contour.AddContourPoint(new ContourPoint(new Point(0, Parameters.Depth, Parameters.Height), null));
            result.Contour.AddContourPoint(new ContourPoint(new Point(0, Parameters.Depth, 0), null));
            return result;
        }

        private static RebarLegFace CreateLegFace3()
        {
            var result = new RebarLegFace
            {
                LayerOrderNumber = 2,
                AdditonalOffset = 25.0,
                Reversed = false
            };

            result.Contour.AddContourPoint(new ContourPoint(new Point(Parameters.Width, 0, 0), null));
            result.Contour.AddContourPoint(new ContourPoint(new Point(Parameters.Width, 0, Parameters.Height), null));
            result.Contour.AddContourPoint(new ContourPoint(new Point(Parameters.Width, Parameters.Depth, Parameters.Height), null));
            result.Contour.AddContourPoint(new ContourPoint(new Point(Parameters.Width, Parameters.Depth, 0), null));
            return result;
        }

        private static RebarGuideline CreateGuideline1()
        {
            var result = new RebarGuideline();
            result.Spacing = RebarSpacing.Create(
                        RebarSpacing.SpacingType.EXACT_FLEXIBLE_LAST,
                        new RebarSpacing.Offset(true, 0.0),
                        new RebarSpacing.Offset(true, 0.0),
                        200.0);

            result.Spacing.ExcludeType = RebarSpacing.ExcludeTypeEnum.EXCLUDE_TYPE_LAST;
            result.Curve.AddContourPoint(new ContourPoint(new Point(0.0, 0.0, 0.0), null));
            result.Curve.AddContourPoint(new ContourPoint(new Point(0.0, Parameters.Depth, 0.0), null));
            return result;
        }

        private static RebarGuideline CreateGuideline2()
        {
            var result = new RebarGuideline();
            result.Spacing = RebarSpacing.Create(
                        RebarSpacing.SpacingType.EXACT_FLEXIBLE_LAST,
                        new RebarSpacing.Offset(true, 0.0),
                        new RebarSpacing.Offset(true, 0.0),
                        200.0);

            result.Spacing.InheritFromPrimary = true;
            result.Curve.AddContourPoint(new ContourPoint(new Point(Parameters.Width, 0.0, 0.0), null));
            result.Curve.AddContourPoint(new ContourPoint(new Point(Parameters.Width, Parameters.Depth, 0.0), null));
            return result;
        }

        private static RebarPropertyModifier CreatePropertyStrip()
        {
            var rebarSet = new RebarSet();
            SetProperties(rebarSet);
            rebarSet.LegFaces.Add(CreateLegFace1());
            rebarSet.LegFaces.Add(CreateLegFace2());
            rebarSet.Guidelines.Add(CreateGuideline1());
            rebarSet.Insert();

            var strip = new RebarPropertyModifier();
            strip.Father = rebarSet;
            strip.RebarProperties.Name = "REBAR";
            strip.RebarProperties.Class = 3;
            strip.RebarProperties.Grade = "H";
            strip.RebarProperties.Size = "12";
            strip.RebarProperties.BendingRadius = 24;
            strip.RebarProperties.NumberingSeries.StartNumber = 1;
            strip.Curve.AddContourPoint(new ContourPoint(new Point(200, 200, 0), null));
            strip.Curve.AddContourPoint(new ContourPoint(new Point(200, Parameters.Depth - 200, 0), null));
            strip.Insert();

            return strip;
        }

        private static RebarEndDetailModifier CreateEndDetailStrip()
        {
            var rebarSet = new RebarSet();
            SetProperties(rebarSet);
            rebarSet.RebarProperties.Grade = "H";
            rebarSet.RebarProperties.Size = "12";
            rebarSet.RebarProperties.BendingRadius = 24;
            rebarSet.LegFaces.Add(CreateLegFace1());
            rebarSet.LegFaces.Add(CreateLegFace2());
            rebarSet.Guidelines.Add(CreateGuideline1());
            rebarSet.Insert();

            var strip = new RebarEndDetailModifier();
            strip.Father = rebarSet;
            strip.RebarHook.Shape = RebarHookData.RebarHookShapeEnum.HOOK_90_DEGREES;
            strip.RebarThreading.ThreadingType = "ThreadingType1";
            strip.RebarThreading.Length = 100;
            strip.RebarThreading.ExtraFabricationLength = 50;
            strip.Curve.AddContourPoint(new ContourPoint(new Point(0, 200, Parameters.Height), null));
            strip.Curve.AddContourPoint(new ContourPoint(new Point(0, Parameters.Depth - 200, Parameters.Height), null));
            strip.Insert();

            return strip;
        }

        #endregion


        public void ModelHistoryExample()
        {
            ModelHistory.TakeModifications("RebarSetTestStamp");
            var slab = new ContourPlate();
            SetProperties(slab);
            slab.Insert();
            var modifier = CreateEndDetailStrip();
            new Model().CommitChanges();

            var modifications = ModelHistory.TakeModifications("RebarSetTestStamp",
                new[] { ModelObject.ModelObjectEnum.CONTOURPLATE, ModelObject.ModelObjectEnum.REBAR_SET, ModelObject.ModelObjectEnum.REBAR_END_DETAIL_MODIFIER }).ModifiedWithInfo.ToList();

            string firstMod = modifications[0].ModelObject.GetType().ToString();
            string secondMod = modifications[1].ModelObject.GetType().ToString();
            string thirdMod = modifications[2].ModelObject.GetType().ToString();

            modifier.RebarHook.Shape = RebarHookData.RebarHookShapeEnum.HOOK_180_DEGREES;
            modifier.Modify();
            new Model().CommitChanges();

            modifications = ModelHistory.TakeModifications("RebarSetTestStamp",
                new[] { ModelObject.ModelObjectEnum.CONTOURPLATE, ModelObject.ModelObjectEnum.REBAR_SET, ModelObject.ModelObjectEnum.REBAR_END_DETAIL_MODIFIER }).ModifiedWithInfo.ToList();

            string fourthMod = modifications[0].ModelObject.GetType().ToString();
        }

        public Identifier InsertRebarSet()
        {
            var rebarSet = new RebarSet();
            SetProperties(rebarSet);
            rebarSet.LegFaces.Add(CreateLegFace1());
            rebarSet.LegFaces.Add(CreateLegFace2());
            rebarSet.Guidelines.Add(CreateGuideline1());
            rebarSet.Insert();
            ViewHandler.ZoomToBoundingBox(new AABB(new Point(-100, -100, -100), new Point(500, 500, 500)));
            new Model().CommitChanges();

            return rebarSet.Identifier;
        }

        internal void ModifyLegs(Identifier rebarSetId)
        {
            RebarSet rebarSet = new RebarSet { Identifier = rebarSetId };
            rebarSet.Select();

            //rebarSet.LegFaces.RemoveAt(0); // This is also possible to modify rebar geometry
            rebarSet.LegFaces.Add(CreateLegFace3());
            rebarSet.Modify();

            new Model().CommitChanges();
        }

        internal void ModifyGuideline(Identifier rebarSetId)
        {
            RebarSet rebarSet = new RebarSet { Identifier = rebarSetId };
            rebarSet.Select();

            rebarSet.Guidelines.Add(CreateGuideline2());
            rebarSet.Modify();

            new Model().CommitChanges();

        }

        internal void DeleteRebar(Identifier rebarSetId)
        {
            RebarSet rebarSet = new RebarSet { Identifier = rebarSetId };
            rebarSet.Delete();

            new Model().CommitChanges();
        }

        internal void CreateAddition(Identifier rebarSetId)
        {
            RebarSet rebarSet = new RebarSet { Identifier = rebarSetId };
            rebarSet.Select();

            var rebarSetAddition = new RebarSetAddition();
            rebarSetAddition.LegFaces.Add(CreateLegFace1());
            rebarSetAddition.Father = rebarSet;
            rebarSetAddition.Insert();

            new Model().CommitChanges();
        }

        internal Identifier CreatePropertyModifier(Identifier rebarSetId)
        {
            RebarSet rebarSet = new RebarSet { Identifier = rebarSetId };
            rebarSet.Select();

            var strip = new RebarPropertyModifier();
            strip.Father = rebarSet;
            strip.RebarProperties.Name = "REBAR";
            strip.RebarProperties.Class = 3;
            strip.RebarProperties.Grade = "H";
            strip.RebarProperties.Size = "12";
            strip.RebarProperties.BendingRadius = 24;
            strip.RebarProperties.NumberingSeries.StartNumber = 1;
            strip.Curve.AddContourPoint(new ContourPoint(new Point(200, 200, 0), null));
            strip.Curve.AddContourPoint(new ContourPoint(new Point(200, Parameters.Depth - 200, 0), null));
            strip.Insert();

            new Model().CommitChanges();

            return strip.Identifier;
        }

        internal void ChangeModifier(Identifier propertyModifierId)
        {
            RebarPropertyModifier strip = new RebarPropertyModifier { Identifier = propertyModifierId };
            strip.Select();

            strip.RebarProperties.Size = "20";
            strip.RebarProperties.BendingRadius = 70;
            var contour1 = strip.Curve.ContourPoints;
            (contour1[0] as ContourPoint).Y += 200;
            (contour1[1] as ContourPoint).Y += 200;
            strip.Curve.ContourPoints = contour1;
            strip.Modify();

            new Model().CommitChanges();
        }

        internal void DeleteModifier(Identifier propertyModifierId)
        {
            RebarPropertyModifier strip = new RebarPropertyModifier { Identifier = propertyModifierId };
            strip.Delete();

            new Model().CommitChanges();
        }

        internal Identifier CreateEndDetail(Identifier rebarSetId)
        {
            RebarSet rebarSet = new RebarSet { Identifier = rebarSetId };
            rebarSet.Select();

            var endDetail = new RebarEndDetailModifier();
            endDetail.Father = rebarSet;
            endDetail.RebarHook.Shape = RebarHookData.RebarHookShapeEnum.HOOK_90_DEGREES;
            endDetail.RebarThreading.ThreadingType = "ThreadingType1";
            endDetail.RebarThreading.Length = 100;
            endDetail.RebarThreading.ExtraFabricationLength = 50;
            endDetail.Curve.AddContourPoint(new ContourPoint(new Point(0, 200, Parameters.Height), null));
            endDetail.Curve.AddContourPoint(new ContourPoint(new Point(0, Parameters.Depth - 200, Parameters.Height), null));
            endDetail.Insert();

            new Model().CommitChanges();

            return endDetail.Identifier;
        }

        public void ChangeEndDetail(Identifier endDetailModifierId)
        {
            var endDetail = new RebarEndDetailModifier { Identifier = endDetailModifierId };
            endDetail.Select();

            endDetail.RebarHook.Shape = RebarHookData.RebarHookShapeEnum.HOOK_135_DEGREES;
            endDetail.RebarThreading.ThreadingType = "ThreadingType2";
            endDetail.RebarThreading.Length = 120;
            endDetail.RebarThreading.ExtraFabricationLength = 60;
            var endDetailcontour = endDetail.Curve.ContourPoints;
            (endDetailcontour[0] as ContourPoint).Y += 200;
            (endDetailcontour[1] as ContourPoint).Y += 200;
            endDetail.Curve.ContourPoints = endDetailcontour;
            endDetail.Modify();

            new Model().CommitChanges();

        }

        internal void DeleteEndDetail(Identifier endDetailModifierId)
        {
            var endDetail = new RebarEndDetailModifier { Identifier = endDetailModifierId };
            endDetail.Delete();

            new Model().CommitChanges();
        }

        internal Identifier CreateRebarSplitter(Identifier rebarSetId)
        {
            RebarSet rebarSet = new RebarSet { Identifier = rebarSetId };
            rebarSet.Select();

            var splitter = new RebarSplitter();
            splitter.Father = rebarSet;
            splitter.SplitType = RebarSplitter.SplitTypeEnum.LAPPING;
            splitter.Lapping.LappingType = RebarLapping.LappingTypeEnum.CUSTOM_LAPPING;
            splitter.Lapping.LapLength = 100;
            splitter.StaggerType = RebarSplitter.StaggerTypeEnum.STAGGER_LEFT;
            splitter.StaggerOffset = 200;
            splitter.SplitOffset = 50;
            splitter.Curve.AddContourPoint(new ContourPoint(new Point(400, 200, 0), null));
            splitter.Curve.AddContourPoint(new ContourPoint(new Point(400, Parameters.Depth - 200, 0), null));
            splitter.Insert();

            new Model().CommitChanges();

            return splitter.Identifier;
        }

        internal void ChangeSplitter(Identifier rebarSplitterId)
        {
            var splitter = new RebarSplitter { Identifier = rebarSplitterId };
            splitter.Select();

            splitter.SplitType = RebarSplitter.SplitTypeEnum.CRANKING;
            splitter.Cranking.CrankingType = RebarCranking.CrankingTypeEnum.CUSTOM_CRANKING;
            splitter.Cranking.CrankSide = RebarCranking.CrankSideEnum.CRANK_RIGHT;
            splitter.Cranking.CrankRotation = 90.0;
            splitter.Cranking.CrankStraightLength = 150.0;
            splitter.Cranking.CrankedLengthType = RebarCranking.CrankedLengthTypeEnum.DIAGONAL_RATIO;
            splitter.Cranking.CrankedRatio = 13.0;
            splitter.Cranking.CrankedOffset = 40.0;
            splitter.StaggerType = RebarSplitter.StaggerTypeEnum.STAGGER_RIGHT;
            splitter.StaggerOffset = 250;
            var contourSplitter = splitter.Curve.ContourPoints;
            (contourSplitter[0] as ContourPoint).Y += 200;
            (contourSplitter[1] as ContourPoint).Y += 200;
            splitter.Curve.ContourPoints = contourSplitter;
            splitter.Modify();

            new Model().CommitChanges();
        }

        internal void DeleteSplitter(Identifier rebarSplitterId)
        {
            var splitter = new RebarSplitter { Identifier = rebarSplitterId };
            splitter.Delete();

            new Model().CommitChanges();
        }

        internal Identifier CreateCutPlane(Identifier rebarSetId)
        {
            RebarSet rebarSet = new RebarSet { Identifier = rebarSetId };
            rebarSet.Select();

            var cutter1 = new CutPlane()
            {
                Father = rebarSet,
                Plane = new Plane()
                {
                    AxisX = new Vector(0, 0, 1),
                    AxisY = new Vector(1, 0, 0),
                    Origin = new Point(0.5 * Parameters.Width, 0.5 * Parameters.Depth, 0.0)
                }
            };
            cutter1.Insert();

            new Model().CommitChanges();

            return cutter1.Identifier;
        }

        internal void DeleteCutPlane(Identifier cutPlaneId)
        {
            var cutter1 = new CutPlane { Identifier = cutPlaneId };
            cutter1.Select();
            cutter1.Delete();

            new Model().CommitChanges();
        }
    }
}

