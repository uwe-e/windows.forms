using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BSE.Platten.BO;
using BSE.Charts;
using BSE.Platten.Statistic.Properties;
using BSE.Platten.Common;

namespace BSE.Platten.Statistic
{
    /// <summary>
    /// Used to display statistic system informations.
    /// </summary>
    public partial class Statistic : UserControl
    {
        #region Properties
        /// <summary>
        /// Gets or sets the connection string
        /// </summary>
        public string ConnectionString
        {
            get;
            set;
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="CStatistik"/> class.
        /// </summary>
        public Statistic()
        {
            InitializeComponent();
        }
        #endregion

        #region MethodsPrivate
        private void StatisticLoad(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.ConnectionString) == false)
            {
                this.m_backgroundWorkerStatistic.RunWorkerAsync(this.ConnectionString);
            }
        }

        private void BackgroundWorkerStatisticDoWork(object sender, DoWorkEventArgs e)
        {
            string strConnection = e.Argument as string;
            if (string.IsNullOrEmpty(strConnection) == false)
            {
                StatisticBusinessObject statistikBusinessObject = new StatisticBusinessObject
                {
                    ConnectionString = this.ConnectionString
                };
                try
                {
                    e.Result = statistikBusinessObject.GetStatisticInformation();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void BackgroundWorkerStatisticRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            using (BackgroundWorker backgroundWorker = sender as BackgroundWorker)
            {
                if (backgroundWorker != null)
                {
                    backgroundWorker.DoWork -= new DoWorkEventHandler(BackgroundWorkerStatisticDoWork);
                    backgroundWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(BackgroundWorkerStatisticRunWorkerCompleted);
                }
                if (e.Error != null)
                {
                    GlobalizedMessageBox.Show(this, e.Error.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    StatisticData statisticData = e.Result as StatisticData;
                    if (statisticData != null)
                    {
                        LoadTotalDuration(statisticData);
                        LoadCharts(statisticData);
                    }
                }
            }
        }

        private void LoadTotalDuration(StatisticData statisticData)
        {
            if (statisticData != null)
            {
                this.m_lblSystemInfo1Value.Text = statisticData.CountAlbumsTotal.ToString();
                this.m_lblSystemInfo2Value.Text = statisticData.CountAlbumsRecorded.ToString();
                this.m_lblSystemInfo3Value.Text = statisticData.CountTracksTotal.ToString();

                this.m_lblSystemDurationValueSecond.Text = statisticData.TotalDuration.TotalSeconds.ToString("F");
                this.m_lblSystemDurationValueMinute.Text = statisticData.TotalDuration.TotalMinutes.ToString("F");
                this.m_lblSystemDurationValueHour.Text = statisticData.TotalDuration.TotalHours.ToString("F");
                this.m_lblSystemDurationValueDay.Text = statisticData.TotalDuration.TotalDays.ToString("F");
            }
        }

        private void LoadCharts(StatisticData statisticData)
        {
            if (statisticData != null)
            {
                StatisticCountAlbumsGroupedByMedium[] aAlbumsGroupedByMedium
                    = statisticData.CountAlbumsGroupedByMedium;
                if (aAlbumsGroupedByMedium != null)
                {
                    foreach (StatisticCountAlbumsGroupedByMedium albumsGroupedByMedium in aAlbumsGroupedByMedium)
                    {
                        if (albumsGroupedByMedium != null)
                        {
                            ChartItem chartItem = new ChartItem
                            {
                                Text = albumsGroupedByMedium.Medium,
                                Value = albumsGroupedByMedium.Count
                            };
                            this.m_chrtTitelGroupByMedium.ChartItems.Add(chartItem);
                        }
                    }
                }
            }
        }
        #endregion
    }
}
