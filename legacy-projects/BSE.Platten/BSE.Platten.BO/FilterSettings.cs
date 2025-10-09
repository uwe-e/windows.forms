using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.BO
{
    public class FilterSettings
    {
        public enum FilterMode
        {
            None = 0,
            Year = 1,
            Genre = 2
        }        

        #region FieldsPrivate

        private int m_iFilterId;
        private FilterSettings.FilterMode m_eFilterMode;
        private string m_strValue;
        private bool m_bIsUsed;
        private string m_strBenutzer;

        #endregion

        #region Properties

        public int FilterId
        {
            get { return this.m_iFilterId; }
            set { this.m_iFilterId = value; }
        }

        public FilterSettings.FilterMode UsedFilterMode
        {
            get { return this.m_eFilterMode; }
            set { this.m_eFilterMode = value; }
        }

        public string Value
        {
            get { return this.m_strValue; }
            set { this.m_strValue = value; }
        }
        
        public bool IsUsed
        {
            get { return this.m_bIsUsed; }
            set { this.m_bIsUsed = value; }
        }

        public string Benutzer
        {
            get { return this.m_strBenutzer; }
            set { this.m_strBenutzer = value; }
        }

        #endregion
    }
}
