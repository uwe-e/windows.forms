using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.Common;

namespace BSE.Platten.Admin
{
    /// <summary>
    /// Used for displaying administration forms in the tree of the main administration form.
    /// </summary>
    public partial class BaseForm : BSE.Platten.Common.BaseForm, IIsInAdminForm
    {
        #region Properties
        /// <summary>
        /// Gets or sets a value whether the form is displayed in the administration tree
        /// </summary>
        public bool ShowInTreeView
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets a value whether the form is displayed in the tools section at the administration tree.
        /// </summary>
        public bool ShowInToolsNode
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets a value whether the form is displayed in the statistic section at the administration tree.
        /// </summary>
        public bool ShowInStatisticNode
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the icon image for displaying the form as a tree node in the tree
        /// </summary>
        public Image TreeNodeImage
        {
            get;
            set;
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the BaseForm class.
        /// </summary>
        public BaseForm()
        {
            InitializeComponent();
        }
        #endregion
    }
}