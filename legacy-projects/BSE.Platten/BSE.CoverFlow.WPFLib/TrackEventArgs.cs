using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using BSE.Platten.BO;

namespace BSE.CoverFlow.WPFLib
{
    /// <summary>
    /// Represents the method that will handle <see cref="BSE.Platten.BO.CTrack"/> events of a form, control, or other component.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="TrackEventArgs"/> that contains the event data.</param>
    public delegate void TrackEventHandler(object sender, TrackEventArgs e);
    
    public class TrackEventArgs : RoutedEventArgs
    {
        #region FieldsPrivate
        private readonly CTrack m_track;
        #endregion

        #region Properties
        public CTrack Track
        {
            get
            {
                return this.m_track;
            }
        }
        #endregion

        #region MethodsPublic
        public TrackEventArgs(RoutedEvent routedEvent, CTrack track)
            : base(routedEvent)
        {
            this.m_track = track;
        }
        #endregion
    }
}
