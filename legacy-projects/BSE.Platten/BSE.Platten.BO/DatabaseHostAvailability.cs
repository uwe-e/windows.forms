using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.BO
{
    public class DatabaseHostAvailability
    {
        public bool IsAvailable
        {
            get;
            set;
        }
        public CUserGrant UserGrant
        {
            get;
            set;
        }
    }
}
