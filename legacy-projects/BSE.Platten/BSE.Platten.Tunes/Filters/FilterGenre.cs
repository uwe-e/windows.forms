using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.BO;
using BSE.Platten.Common;
using BSE.Platten.Tunes.Properties;

namespace BSE.Platten.Tunes.Filters
{
    public partial class FilterGenre : FilterBase, IFilterConfiguration
    {
        #region Konstanten

        private const FilterSettings.FilterMode m_eFilterMode = FilterSettings.FilterMode.Genre;

        #endregion

        #region Properties

        public override FilterSettings.FilterMode FilterMode
        {
            get { return m_eFilterMode; }
        }

        #endregion

        #region MethodsPublic

        public FilterGenre()
        {
            InitializeComponent();
            this.FilterName = Resources.IDS_FilterActiceFilterGenreText;
        }

        #endregion

        #region MethodsPrivate
        
        #endregion

        
    }
}
