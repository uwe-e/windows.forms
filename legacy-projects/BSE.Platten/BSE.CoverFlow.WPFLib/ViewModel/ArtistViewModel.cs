using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSE.Platten.BO;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public class ArtistViewModel : TreeViewItemViewModel
    {
        #region FieldsPrivate
        private readonly CInterpretData m_interpret;
        #endregion

        #region Properties
        public int Id
        {
            get
            {
                return this.m_interpret.InterpretId;
            }
        }
        public string Name
        {
            get { return m_interpret.Interpret; }
        }
        public CInterpretData Artist
        {
            get
            {
                return this.m_interpret;
            }
        }
        #endregion

        #region MethodsPublic
        public ArtistViewModel(CInterpretData interpret) 
            : base(null, true)
        {
            this.m_interpret = interpret;
        }
        #endregion

        #region MethodsProtected
        protected override void LoadChildren()
        {
            Album[] albums = this.m_interpret.Albums;
            if (albums != null)
            {
                foreach (Album album in this.m_interpret.Albums)
                {
                    if (albums != null)
                    {
                        base.Children.Add(new AlbumViewModel(album, this));
                    }
                }
            }
        }
        #endregion
    }
}
