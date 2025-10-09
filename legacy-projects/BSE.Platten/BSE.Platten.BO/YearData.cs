using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.BO
{
    public class CYearData : ICloneable
    {
        #region FieldsPrivate

        private int m_iYear;
        private Album[] m_albums;

        #endregion

        #region Properties

        public int Year
        {
            get { return m_iYear; }
            set { m_iYear = value; }
        }

        public BSE.Platten.BO.Album[] Albums
        {
            get { return this.m_albums; }
            set { this.m_albums = value; }
        }

        #endregion

        #region MethodsPublic

        public CYearData()
		{
		}

		public virtual object Clone()
		{
            CYearData year = new CYearData();
            year.Year = this.m_iYear;
            if (this.m_albums != null)
            {
                year.Albums = new Album[this.m_albums.Length];
                this.m_albums.CopyTo(year.Albums, 0);
            }
            return year;
		}
		#endregion
    }
}
