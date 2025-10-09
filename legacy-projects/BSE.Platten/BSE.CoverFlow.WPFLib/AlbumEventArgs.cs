using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using BSE.Platten.BO;

namespace BSE.CoverFlow.WPFLib
{
    /// <summary>
    /// Represents the method that will handle <see cref="BSE.Platten.BO.Album"/> events of a form, control, or other component.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="AlbumEventArgs"/> that contains the event data.</param>
    public delegate void AlbumEventHandler(object sender, AlbumEventArgs e);
    
    public class AlbumEventArgs : RoutedEventArgs
    {
        #region FieldsPrivate
        private readonly Album m_album;
        #endregion

        #region Properties
        public Album Album
        {
            get
            {
                return this.m_album;
            }
        }
        #endregion

        #region MethodsPublic
        public AlbumEventArgs(RoutedEvent routedEvent, Album album)
            : base(routedEvent)
        {
            this.m_album = album;
        }
        #endregion
    }
}
