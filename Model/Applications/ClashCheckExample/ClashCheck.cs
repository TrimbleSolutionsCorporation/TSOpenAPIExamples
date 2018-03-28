using System;
using System.Collections;

using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using ModelObjectSelector = Tekla.Structures.Model.UI.ModelObjectSelector;

namespace ClashCheckExample
{
    /// <summary>
    /// This example shows how to run Clash Check and use related events from Tekla OpenAPI.
    /// </summary>
    public class ClashCheckExample
    {
        #region fields & properties
        /// <summary>
        /// Connection to Tekla Structures model
        /// </summary>
        private readonly Model _model = new Model();

        /// <summary>
        /// Select objects from the Tekla Structures user interface
        /// </summary>
        private ModelObjectSelector _selector;

        /// <summary>
        /// Register event listeners
        /// </summary>
        protected Events TsEvent;

        /// <summary>
        /// Handle ClashCheck
        /// </summary>
        private ClashCheckHandler _clashCheckHandler;

        /// <summary>
        /// Count Clashes
        /// </summary>
        private int _numberClashes;

        /// <summary>
        /// Check if clash check is completed
        /// </summary>
        private bool _clashCheckDone;

        /// <summary>
        /// Specified time for thread
        /// </summary>
        private const int WAITTIME = 1500;

        /// <summary>
        /// 30 Sec is enough to run clash check for 3 parts.
        /// Use bigger number for bigger model.
        /// </summary>
        private const int MAXTIME = 30;

        /// <summary>
        /// EventLock
        /// </summary>
        private readonly object _eventLock = new object();

        /// <summary>
        /// Add ClashCheckData
        /// </summary>
        private ArrayList _clashes;
        public ArrayList Clashes { get { return _clashes; } }
        #endregion

        public bool ClashCheck()
        {
             bool result = false;
            _selector = new ModelObjectSelector();
            _clashes = new ArrayList();
            _clashCheckDone = false;
            ArrayList objectsToSelect = new ArrayList();

            objectsToSelect = InsertThreeClashingParts();
            #region Use below commented codes to run clash check of entire model object instead of three inserted clashing parts.
            //ModelObjectEnumerator modelObjectEnumerator = _Model.GetModelObjectSelector().GetAllObjects();
            //foreach (ModelObject modelObject in modelObjectEnumerator)
            //{
            //    ObjectsToSelect.Add(modelObject);
            //}
            #endregion

            _selector.Select(objectsToSelect);
            _model.CommitChanges();

            result = RunClashCheck();
            //Result = _Clashes.Count == _NumberClashes && _NumberClashes == 3;

            if (TsEvent != null)
                TsEvent.UnRegister();

            return result;
        }

        /// <summary> 
        /// Insert three clashing parts
        /// </summary>
        /// <returns>
        /// Inserted objects
        /// </returns>
        private ArrayList InsertThreeClashingParts()
        {
            ArrayList insertedObjects = new ArrayList();
            Beam beam1 = new Beam(new Point(2500.0, 0.0, 0.0), new Point(2500.0, 5000.0, 0.0));
            Beam beam2 = new Beam(new Point(0.0, 2500.0, 0.0), new Point(5000.0, 2500.0, 0.0));
            Beam column = new Beam(new Point(2500.0, 2500.0, -200.0), new Point(2500.0, 2500.0, 2000.0));

            beam1.Profile.ProfileString = "780*380";
            beam2.Profile.ProfileString = "780*380";
            column.Profile.ProfileString = "300*300";
            beam1.Insert();
            insertedObjects.Add(beam1);
            beam2.Insert();
            insertedObjects.Add(beam2);
            column.Insert();
            insertedObjects.Add(column);

            return insertedObjects;
        }

        /// <summary> 
        /// ClashDetected event delegate
        /// </summary>
        /// <param name="clashCheckData">
        /// ClashCheckData
        /// </param>
        private void TsEventOnClashDetected(ClashCheckData clashCheckData)
        {
            lock (_eventLock)
            {
                _clashes.Add("Clash: " + clashCheckData.Object1.Identifier.ID + " <-> " + clashCheckData.Object2.Identifier.ID + ".");
            }
        }

        /// <summary> 
        /// ClashCheckDone event delegate
        /// </summary>
        /// <param name="numberClashes">
        /// Number of clashes
        /// </param>
        private void TsEventOnClashCheckDone(int numberClashes)
        {
            lock (_eventLock)
            {
                System.Threading.Thread.Sleep(WAITTIME);
                _numberClashes = numberClashes;
                _clashCheckDone = true;
            }
        }

        /// <summary> 
        /// Registers ClashCheck events and runs the clash check. 
        /// </summary>
        /// <returns>
        /// Result
        /// </returns>
        private bool RunClashCheck()
        {
            bool result = true;
            _clashCheckDone = false;
            _numberClashes = 0;
            _clashes.Clear();

            try
            {
                _clashCheckHandler = _model.GetClashCheckHandler();
                TsEvent = new Events();
                TsEvent.ClashDetected += TsEventOnClashDetected;
                TsEvent.ClashCheckDone += TsEventOnClashCheckDone;
                TsEvent.Register();
            }
            catch (ApplicationException Exc)
            {
                Console.WriteLine("Exception: " + Exc.ToString());
            }

            DateTime start = DateTime.Now;
            _clashCheckHandler.RunClashCheck();

            TimeSpan span = new TimeSpan();

            while (!_clashCheckDone && span.TotalSeconds < MAXTIME)
            {
                System.Threading.Thread.Sleep(WAITTIME);
                DateTime end = DateTime.Now;
                span = end.Subtract(start);
            }
            return result;
        }
    }
}

