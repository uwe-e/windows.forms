using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace BSE.Configuration
{
    public class VisualObject
    {
        #region FieldsPrivate

        private string m_strDescription;
        private string m_strElement;
        private string m_strValue;
        private VisualObjectType m_eVisualObjectType;
        private Collection<VisualObjectItem> m_visualObjectItems;
        private string m_strErrorMessage;
        
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the key of an entry in the configuration
        /// </summary>
        public string Element
        {
            get { return this.m_strElement; }
            set { this.m_strElement = value; }
        }
        /// <summary>
        /// Gets or sets the visible description of an entry in the configuration
        /// </summary>
        public string Description
        {
            get { return this.m_strDescription; }
            set { this.m_strDescription = value; }
        }
        /// <summary>
        /// Gets or sets the value of an entry in the configuration
        /// </summary>
        public string Value
        {
            get { return this.m_strValue; }
            set { this.m_strValue = value; }
        }
        /// <summary>
        /// Gets or sets the type of an entry in the configuration
        /// OpenDialog = 1,
        /// SelectDirectoryDialog = 2,
        /// OpenTextBox = 3,
        /// OpenNumericUpDown = 4,
        /// ComboBox = 5
        /// </summary>
        public VisualObjectType VisualObjectType
        {
            get { return this.m_eVisualObjectType; }
            set { this.m_eVisualObjectType = value; }
        }
        /// <summary>
        /// Gets or sets a collection of VisualObjectItem for displaying a number of items in in a combobox
        /// </summary>
        public Collection<VisualObjectItem> VisualObjectItems
        {
            get { return this.m_visualObjectItems; }
            set { this.m_visualObjectItems = value; }
        }
		/// <summary>
        /// Gets and sets the errormessage for missing configuration entries
		/// </summary>
		public string ErrorMessage
		{
			get { return this.m_strErrorMessage; }
			set { this.m_strErrorMessage = value; }
		}

        #endregion
    }
}
