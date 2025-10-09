using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Charts
{
	public delegate void ChartItemClickEventHandler(object sender, ChartItemClickEventArgs e);
	
	public class ChartItemClickEventArgs
	{
		#region FieldsPrivate

		private ChartItem m_chartItem;

		#endregion

		#region Properties

		public ChartItem ChartItem
		{
			get { return this.m_chartItem; }
			set { this.m_chartItem = value; }
		}

		#endregion

		#region MethodsPublic

		public ChartItemClickEventArgs(ChartItem chartItem)
		{
			this.m_chartItem = chartItem;
		}

		#endregion
	}
}
