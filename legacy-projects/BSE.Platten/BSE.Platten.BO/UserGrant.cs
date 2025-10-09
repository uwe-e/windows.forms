using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.BO
{
    public class CUserGrant
    {
        #region Konstanten

        public const string GrantRoot = "GRANT ALL PRIVILEGES ON *.*";
        public const string GrantPlatten = "GRANT SELECT, INSERT, UPDATE, DELETE ON `platten`.*";
        public const string GrantPlattenTitel = "GRANT SELECT, INSERT, UPDATE, DELETE ON `platten`.`titel`";

        #endregion

        #region FieldsPrivate

        private bool m_bGrant;

        #endregion

        #region Properties

        public bool Grant
        {
            get { return this.m_bGrant; }
            set { this.m_bGrant = value; }
        }

        #endregion
    }
}
