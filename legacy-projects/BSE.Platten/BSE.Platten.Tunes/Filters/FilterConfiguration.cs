using System;

using BSE.Platten.BO;
using BSE.Platten.Tunes.Properties;

namespace BSE.Platten.Tunes.Filters
{
	/// <summary>
	/// Summary description for CFilterYearConfig.
	/// </summary>
	/// <remarks></remarks>
	/// <copyright>Copyright © 2004 MCH Messe Basel AG</copyright>
	public class FilterConfiguration : FilterSettings
	{
        #region FieldsPrivate
        private string m_strUsedFilterName = Resources.IDS_FilterNoActiceFilterText;
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the name of the used Filter
		/// </summary>
        public string FilterName
		{
            get { return this.m_strUsedFilterName; }
            set { this.m_strUsedFilterName = value; }
		}
		#endregion
	}
}
