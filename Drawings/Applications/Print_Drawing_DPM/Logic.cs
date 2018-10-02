using System;
using System.Collections;
using Tekla.Structures;
using Tekla.Structures.Drawing;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace Print_Drawing_DPM
{
    public static class Logic
    {
        public static bool CreateAndSelectNewPart()
        {
            bool result = false;
            Beam myBeam = new Beam();
            myBeam.StartPoint = new Point(0, 0, 0);
            myBeam.EndPoint = new Point(1000, 0, 0);
            myBeam.Profile.ProfileString = "500*200";
            bool resultInsert = myBeam.Insert();

            if (resultInsert == false) return false;

            new Model().CommitChanges();

            var mos = new Tekla.Structures.Model.UI.ModelObjectSelector();
            ArrayList myList = new ArrayList();
            myList.Add(myBeam);
            result = mos.Select(myList);

            return result;
        }

        public static bool CreateAndOpenNewDrawing()
        {
            bool result = false;
            Model myModel = new Model();
            var mos = new Tekla.Structures.Model.UI.ModelObjectSelector();
            ModelObjectEnumerator moe = mos.GetSelectedObjects();

            if (moe.GetSize() != 1) return false;

            moe.MoveNext();
            Beam myBeam = moe.Current as Beam;

            if (myBeam == null) return false;

            TransformationPlane current = myModel.GetWorkPlaneHandler().GetCurrentTransformationPlane();
            myModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane());  // We use global transformation
            DrawingHandler dh = new DrawingHandler();
            GADrawing myDrawing = new GADrawing("New Drawing", "standard");

            if (!myDrawing.Insert())
            {
                myModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(current); // return original transformation
                return false;
            }

            if (!dh.SetActiveDrawing(myDrawing, true)) return false;

            if (!CreateRotatedView(myBeam, myDrawing))
            {
                myModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(current); // return original transformation
                return false;
            }

            if (!myDrawing.PlaceViews()) return false;

            dh.CloseActiveDrawing(true); // Save and close the active drawing
            
            myModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(current); // return original transformation
            result = dh.SetActiveDrawing(myDrawing, false);

            return result;
        }

        public static bool CreateRotatedView(Beam myBeam, GADrawing myDrawing)
        {
            CoordinateSystem displayCoordinateSystem = new CoordinateSystem();
            CoordinateSystem myCoordinateSystem = myBeam.GetCoordinateSystem();
            ArrayList myParts = new ArrayList();
            myParts.Add(myBeam);

            Matrix RotationAroundX = MatrixFactory.Rotate(20.0 * Math.PI * 2.0 / 360.0, myCoordinateSystem.AxisX);
            Matrix RotationAroundZ = MatrixFactory.Rotate(30.0 * Math.PI * 2.0 / 360.0, myCoordinateSystem.AxisY);

            Matrix Rotation = RotationAroundX * RotationAroundZ;

            displayCoordinateSystem.AxisX = new Vector(Rotation.Transform(new Point(myCoordinateSystem.AxisX)));
            displayCoordinateSystem.AxisY = new Vector(Rotation.Transform(new Point(myCoordinateSystem.AxisY)));

            View rotatedView = new View(myDrawing.GetSheet(), myCoordinateSystem, displayCoordinateSystem, myParts);

            rotatedView.Name = "Example_View";
            return rotatedView.Insert();
        }

        public static bool PrintActiveDrawing()
        {
            bool result = false;
            DrawingHandler dh = new DrawingHandler();
            Drawing activeDrawing = dh.GetActiveDrawing();

            if (!(activeDrawing is GADrawing) || !activeDrawing.Name.Equals("New Drawing")) return false;

            DPMPrinterAttributes printAttributes = new DPMPrinterAttributes();
            printAttributes.ColorMode = DotPrintColor.BlackAndWhite;
            printAttributes.NumberOfCopies = 1;
            printAttributes.OpenFileWhenFinished = true;
            printAttributes.Orientation = DotPrintOrientationType.Landscape;
            printAttributes.OutputFileName = "ExampleDrawing.pdf";
            printAttributes.OutputType = DotPrintOutputType.PDF;
            printAttributes.PaperSize = DotPrintPaperSize.A4;
            printAttributes.PrinterName = "PDF-XChange 3.0"; // Must use local PDF printer name
            printAttributes.PrintToMultipleSheet = DotPrintToMultipleSheet.Off;
            printAttributes.ScaleFactor = 1.0;
            printAttributes.ScalingMethod = DotPrintScalingType.Auto;
            result = dh.PrintDrawing(activeDrawing, printAttributes);

            return result;
        }
    }
}
