using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.BO;
using BSE.Platten.Tunes.Properties;

namespace BSE.Platten.Tunes.Filters
{
    public partial class FilterYear : FilterBase
    {
        #region Konstanten

        private static FilterSettings.FilterMode m_eFilterMode = FilterSettings.FilterMode.Year;

        #endregion
        
        #region Properties

        public override FilterSettings.FilterMode FilterMode
        {
            get { return m_eFilterMode; }
        }

        #endregion

        #region MethodsPublic

        public FilterYear()
        {
            InitializeComponent();
            this.FilterName = Resources.IDS_FilterActiceFilterYearText;
        }

        #endregion
    }
}

