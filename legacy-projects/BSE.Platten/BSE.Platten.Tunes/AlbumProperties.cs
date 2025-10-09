using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.Audio;
using BSE.Platten.BO;
using BSE.Platten.Tunes.Properties;
using System.Globalization;

namespace BSE.Platten.Tunes
{
    public partial class AlbumProperties : UserControl, IWPFHost
    {
        #region Properties

        public BSE.Configuration.Configuration Settings
        {
            get;
            set;
        }
        public object DataContext
        {
            get
            {
                return this.propertiesPanel1.DataContext;
            }
            set
            {
                this.propertiesPanel1.DataContext = value;
            }
        }
        #endregion

        #region MethodsPublic
        public AlbumProperties()
        {
            InitializeComponent();
        }
        #endregion

    }
}
