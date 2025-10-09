using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSE.Platten.BO.Data.Extensions
{
    public static class LinqExtensions
    {
        public static TrackCollection ToTrackCollection(this System.Collections.IList list)
        {
            TrackCollection trackCollection = null;
            if (list != null)
            {
                IList<CTrack> trackList = list.Cast<CTrack>().ToList();
                trackCollection = new TrackCollection(trackList);
            }
            return trackCollection;
        }
    }
}
