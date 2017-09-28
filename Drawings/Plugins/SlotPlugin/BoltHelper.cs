namespace SlotPlugin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Tekla.Structures;
    using Tekla.Structures.Drawing;
    using Tekla.Structures.Geometry3d;
    using Tekla.Structures.Model;

    using Part = Tekla.Structures.Model.Part;
    using TSD = Tekla.Structures.Drawing;

    /// <summary>
    /// Class to ease dealing with the bolts.
    /// </summary>
    public static class BoltHelper
    {
        #region Private fields
        /// <summary>
        /// Tolerance for the bolt's X and Y direction
        /// </summary>
        private const double Epsilon = 0.001;

        /// <summary>
        /// Connection to Tekla Structures model
        /// </summary>
        private static readonly Model Model = new Model();
        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the parts with slotted holes and their index.
        /// </summary>
        /// <param name="bolts">
        /// The bolt group which defines the slots
        /// </param>
        /// <returns>
        /// Parts with slotted holes with the index (index is the number of order from the bolt head to the nut).
        /// </returns>
        public static Dictionary<Identifier, int> GetSlottedParts(BoltGroup bolts)
        {
            var slottedParts = new Dictionary<Identifier, int>();

            var orderedParts = PartsBoltedInOrder(bolts);

            if (bolts.Hole1 && orderedParts.Count > 0)
            {
                slottedParts.Add(orderedParts[0].Identifier, 0);
            }

            if (bolts.Hole2 && orderedParts.Count > 1)
            {
                slottedParts.Add(orderedParts[1].Identifier, 1);
            }

            if (bolts.Hole3 && orderedParts.Count > 2)
            {
                slottedParts.Add(orderedParts[2].Identifier, 2);
            }

            if (bolts.Hole4 && orderedParts.Count > 3)
            {
                slottedParts.Add(orderedParts[3].Identifier, 3);
            }

            if (bolts.Hole5 && orderedParts.Count > 4)
            {
                slottedParts.Add(orderedParts[4].Identifier, 4);
            }

            return slottedParts;
        }

        /// <summary>
        /// Gets the slot dimensions in the part in the bolt group coordinate system
        /// </summary>
        /// <param name="bolts">
        /// The bolt object.
        /// </param>
        /// <param name="part">
        /// The part to look for slots.
        /// </param>
        /// <param name="dimensionX">
        /// The slot X dimension.
        /// </param>
        /// <param name="dimensionY">
        /// The slot Y dimension.
        /// </param>
        /// <returns>
        /// false if the part doesn't have a slot.
        /// </returns>
        public static bool GetSlotDimensions(BoltGroup bolts, Part part, out double dimensionX, out double dimensionY)
        {
            var parts = GetSlottedParts(bolts);
            int index;

            if (parts.TryGetValue(part.Identifier, out index))
            {
                if ((bolts.SlottedHoleX < Epsilon && bolts.SlottedHoleY < Epsilon) ||
                    Math.Abs(bolts.SlottedHoleX - bolts.SlottedHoleY) <= Epsilon ||
                    bolts.HoleType == BoltGroup.BoltHoleTypeEnum.HOLE_TYPE_OVERSIZED)
                {
                    dimensionX = double.NaN;
                    dimensionY = double.NaN;
                    return false;
                }

                dimensionX = bolts.SlottedHoleX;
                dimensionY = bolts.SlottedHoleY;

                if (bolts.RotateSlots == BoltGroup.BoltRotateSlotsEnum.ROTATE_SLOTS_PARALLEL)
                {
                    return true;
                }

                if ((index & 1) == 0)
                {
                    // It's even
                    if (bolts.RotateSlots == BoltGroup.BoltRotateSlotsEnum.ROTATE_SLOTS_EVEN)
                    {
                        dimensionX = bolts.SlottedHoleY;
                        dimensionY = bolts.SlottedHoleX;
                    }
                }
                else
                {
                    // It's odd
                    if (bolts.RotateSlots == BoltGroup.BoltRotateSlotsEnum.ROTATE_SLOTS_ODD)
                    {
                        dimensionX = bolts.SlottedHoleY;
                        dimensionY = bolts.SlottedHoleX;
                    }
                }

                return true;
            }

            dimensionX = double.NaN;
            dimensionY = double.NaN;
            return false;
        }

        /// <summary>
        /// Parts bolted by the bolt group ordered from the bolt head to the nut.
        /// </summary>
        /// <param name="bolts">
        /// The bolts group.
        /// </param>
        /// <returns>
        /// Parts in order.
        /// </returns>
        public static List<Part> PartsBoltedInOrder(BoltGroup bolts)
        {
            var parts = new List<Part>();

            if (bolts != null)
            {
                var boltPositions = bolts.BoltPositions;
                var startPoint = boltPositions[0] as Point;

                if (startPoint != null)
                {
                    var boltCs = bolts.GetCoordinateSystem();
                    var boltAxisZ = 0.5 * bolts.CutLength * Vector.Cross(boltCs.AxisY, boltCs.AxisX).GetNormal();
                    var endPoint = startPoint + boltAxisZ;
                    var startSegment = startPoint - boltAxisZ;
                    var boltAxis = new LineSegment(startSegment, endPoint);

                    var partsBolted = GetPartsBolted(bolts);

                    var distances = new SortedDictionary<double, Part>();

                    foreach (var item in partsBolted)
                    {
                        var solid = item.GetSolid();
                        var points = solid.Intersect(boltAxis);

                        var count = (points.Count + 1) / 2;
                        for (var ii = 0; ii < count; ii++)
                        {
                            var distanceToBoltHead = Distance.PointToPoint((Point)points[2 * ii], startPoint);

                            var pointToPoint = new Vector((Point)points[2 * ii] - startPoint);

                            if (Vector.Dot(boltAxisZ.GetNormal(), pointToPoint.GetNormal()) == -1)
                            {
                                distanceToBoltHead = -distanceToBoltHead;
                            }

                            if (!distances.ContainsKey(distanceToBoltHead))
                            {
                                distances.Add(distanceToBoltHead, item);
                            }
                        }
                    }

                    if (distances.Count > 1)
                    {
                        parts = distances.Values.ToList();
                    }
                }
            }

            return parts;
        }

        /// <summary>
        /// Parts bolted by the bolt group.
        /// </summary>
        /// <param name="bolts">
        /// The bolts group.
        /// </param>
        /// <returns>
        /// Parts in order.
        /// </returns>
        public static List<Part> GetPartsBolted(BoltGroup bolts)
        {
            var parts = new List<Part>();

            if (bolts != null)
            {
                if (bolts.PartToBoltTo != null)
                {
                    parts.Add(bolts.PartToBoltTo);
                }

                if (bolts.PartToBeBolted != null)
                {
                    parts.Add(bolts.PartToBeBolted);
                }

                parts.AddRange(bolts.GetOtherPartsToBolt().Cast<Part>().Where(item => item != null));
            }

            return parts;
        }

        /// <summary>
        /// Gets the angle between the slot and the view X axis in the drawing.
        /// </summary>
        /// <param name="boltGroup">
        /// The bolt group in the model.
        /// </param>
        /// <param name="boltView">
        /// The view in the drawing containing the bolt.
        /// </param>
        /// <returns>
        /// Angle between the bolt and the view X axis.
        /// </returns>
        public static double GetSlotPartAngleInDrawing(BoltGroup boltGroup, View boltView)
        {
            var index = -1;
            Part slottedPart = null;

            if (boltGroup != null)
            {
                var slottedParts = GetSlottedParts(boltGroup);

                var drawingObjectEnumerator = boltView.GetObjects(new[] { typeof(TSD.Part) });

                if (slottedParts != null)
                {
                    foreach (TSD.Part item in drawingObjectEnumerator)
                    {
                        if (slottedParts.TryGetValue(item.ModelIdentifier, out index))
                        {
                            slottedPart = Model.SelectModelObject(item.ModelIdentifier) as Part;
                            break;
                        }
                    }
                }
            }

            var angle = double.NaN;

            if (index >= 0 && slottedPart != null)
            {
                // Calculation of the direction of the slot.
                if (boltView.Select())
                {
                    var displayCs = boltView.DisplayCoordinateSystem;
                    double dimX;
                    double dimY;
                    GetSlotDimensions(boltGroup, slottedPart, out dimX, out dimY);
                    boltGroup.Select();
                    var boltCs = boltGroup.GetCoordinateSystem();

                    var dot = Vector.Dot(boltCs.AxisX.GetNormal(), displayCs.AxisX.GetNormal());
                    angle = Math.Acos(dot);
                    var cross = Vector.Cross(boltCs.AxisX.GetNormal(), displayCs.AxisX.GetNormal());
                    if (cross.Z > 0)
                    {
                        angle = -1 * angle;
                    }

                    if (dimX < Epsilon && dimY < Epsilon)
                    {
                        return double.NaN;
                    }

                    if (dimX < dimY)
                    {
                        angle += Math.PI * 0.5;
                    }

                    angle %= Math.PI;
                }
            }

            return angle;
        }
        #endregion
    }
}