using System;
using System.Collections.Generic;
using System.Text;
using BSE.Platten.Audio;
using System.Windows.Forms;
using BSE.Platten.BO;
using BSE.Platten.Common;

namespace BSE.Platten.Tunes
{
	public class ListViewEx : BSE.Windows.Forms.ListView
	{
		#region FieldsPrivate
		private CPlayerManager m_playerManager;
		#endregion

		#region Properties
		public CPlayerManager PlayerManager
		{
			get { return this.m_playerManager; }
			set { this.m_playerManager = value; }
		}
		#endregion

		#region MethodsPublic
		#endregion

		#region MethodsProtected

		protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				PlaySelectedTrack();
			}
			base.OnKeyUp(e);
		}

		protected override void OnDoubleClick(EventArgs e)
		{
			PlaySelectedTrack();
			base.OnDoubleClick(e);
		}
		#endregion

		#region MethodsPrivate
		
		private void PlaySelectedTrack()
		{
			ListViewItem listViewItem = this.FocusedItem;
			if (listViewItem != null)
			{
				CTrack selectedTrack = listViewItem.Tag as CTrack;
                if (selectedTrack != null)
				{
					try
					{
                        PlayerManager.PlayTrack(selectedTrack, PlayMode.Song);
					}
					catch (Exception exception)
					{
						GlobalizedMessageBox.Show(this.Parent, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}
		#endregion
	}
}
