using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections;

namespace BSE.Platten.BO
{
    public class TrackCollection : ObservableCollection<CTrack>
    {
        #region Events
        #endregion

        #region Constants
        #endregion

        #region FieldsPrivate
        #endregion

        #region Properties
        public int Index
        {
            get;
            private set;
        }
        //public CTrack this[int iIndex]
        //{
        //    get { return this.[iIndex] as CTrack; }
        //    set { this.[iIndex] = value; }
        //}
        public CTrack CurrentTrack
        {
            get
            {
                if ((this.Index >= 0 && this.Index < this.Count) == false)
                {
                    throw new IndexOutOfRangeException();
                }
                return this[this.Index] as CTrack;
            }
        }
        /// <summary>
        /// Checks if a next track is available.
        /// </summary>
        public bool IsNextTrackAvailable
        {
            get
            {
                return (this.Index < this.Count - 1);
            }
        }
        /// <summary>
        /// Checks if a previous track is available.
        /// </summary>
        public bool IsPreviousTrackAvailable
        {
            get { return (this.Index > 0); }
        }
        #endregion

        #region MethodsPublic
        public TrackCollection() : base()
        {
            this.Index = -1;
        }
        public TrackCollection(IList<CTrack> list)
            : base(list)
        {
            this.Index = -1;
        }
        public int GetRandomIndex()
        {
            Random random = new Random();
            return random.Next(0, this.Count - 1);
        }
        public bool MoveNext()
        {
            this.Index++;
            return this.Index >= 0 && this.Index < this.Count;
        }
        public bool MovePrevious()
        {
            bool bMovePrevious = false;
            if (this.IsPreviousTrackAvailable == true)
            {
                this.Index--;
                return this.Index >= 0 && this.Index < this.Count;
            }
            return bMovePrevious;
        }
        public void Reset()
        {
            this.Index = -1;
        }
        public static TrackCollection GetRandomCollection(TrackCollection trackCollection)
        {
            TrackCollection randomTrackCollection = null;
            if (trackCollection != null)
            {
                Random random = new Random(DateTime.Now.Millisecond);
                ArrayList originalTracks = new ArrayList(trackCollection);
                while (originalTracks.Count > 0)
                {
                    int iIndex = random.Next(originalTracks.Count);
                    if (randomTrackCollection == null)
                    {
                        randomTrackCollection = new TrackCollection();
                    }
                    CTrack track = originalTracks[iIndex] as CTrack;
                    randomTrackCollection.Add(track);
                    originalTracks.RemoveAt(iIndex);
                }
            }
            return randomTrackCollection;
        }
        #endregion

        #region MethodsProtected
        #endregion

        #region MethodsPrivate
        #endregion

    }
}
