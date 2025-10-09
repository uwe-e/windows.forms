using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSE.Platten.BO.Extensions
{
    public static class AlbumExtensions
    {
        public static TrackCollection ToTrackCollection(this Album album)
        {
            TrackCollection trackCollection = null;
            if (album != null && album.Tracks != null)
            {
                album.Tracks.ToList().ForEach(delegate(CTrack track)
                {
                    if (track != null)
                    {
                        if (trackCollection == null)
                        {
                            trackCollection = new TrackCollection();
                        }
                        trackCollection.Add(track);
                    }
                });
            }
            return trackCollection;
        }
    }
}
