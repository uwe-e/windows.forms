using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.BO;
using BSE.Platten.Tunes.Properties;
using BSE.Platten.Common;
using System.Globalization;
using System.Collections.ObjectModel;

namespace BSE.Platten.Tunes
{
    public partial class TreeInterpretenTitel : UserControl, IWPFHost
    {

        #region Properties
        public object DataContext
        {
            get
            {
                return this.artistTree1.DataContext;
            }
            set
            {
                this.artistTree1.DataContext = value;
            }
        }

        #endregion

        #region MethodsPublic

        public TreeInterpretenTitel()
        {
            InitializeComponent();
        }

        public void SetSelectedItem(Album album)
        {
            //this.artistTree1.SetSelectedItem(album);
        }

        #endregion

        #region MethodsProtected
        #endregion

        #region MethodsPrivate
        #endregion
    }
}
