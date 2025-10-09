using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSE.Platten.BO;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public class UpdateHistoryViewModel : EnvironmentViewModel
    {
        #region MethodsPublic
        public UpdateHistoryViewModel()
        {
        }
        public UpdateHistoryViewModel(BSE.Platten.BO.Environment environment)
            : base(environment)
        {
            Mediator.Register(this);
        }
        public void UpdateHistory(CTrack currentTrack, BSE.Platten.Audio.PlayMode playMode)
        {
            if (currentTrack != null)
            {
                HistoryData historyData = new HistoryData
                {
                    UserName = this.Environment.UserName,
                    TitelId = currentTrack.TitelId,
                    LiedId = currentTrack.LiedId,
                    AppId = playMode == Platten.Audio.PlayMode.Playlist ? (int)Platten.Audio.PlayMode.Song : (int)playMode,
                    PlayedAt = DateTime.Now
                };
                this.Mediator.NotifyColleagues<HistoryData>(MediatorMessages.MessageHistoryIsChanging, historyData);
            }
        }
        #endregion
    }
}
