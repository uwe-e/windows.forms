using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public class PlayableViewModel : EnvironmentViewModel
    {
        #region Events
        #endregion

        #region Constants
        #endregion

        #region FieldsPrivate
        #endregion

        #region Properties
        public PlayerManagerViewModel PlayerManagerViewModel
        {
            get;
            private set;
        }
        #endregion

        #region MethodsPublic
        public PlayableViewModel()
        {
        }
        public PlayableViewModel(BSE.Platten.BO.Environment environment)
            : base(environment)
        {
        }
        public PlayableViewModel(BSE.Platten.BO.Environment environment, PlayerManagerViewModel playerManagerViewModel)
            : base(environment)
        {
            this.PlayerManagerViewModel = playerManagerViewModel;
        }
        #endregion

        #region MethodsProtected
        #endregion

        #region MethodsPrivate
        #endregion

    }
}
