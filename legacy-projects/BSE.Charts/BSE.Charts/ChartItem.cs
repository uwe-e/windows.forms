using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace BSE.Charts
{
    [DefaultProperty("Value"),
    ToolboxItem(false),
    DesignTimeVisible(false)]
    public class ChartItem : ICloneable
    {
        #region FieldsPrivate

        private int m_iIndex;
        private float m_fValue;
        private string m_strText;
        private Color m_Color;
        private Color m_ColorHighlight;
        private Color m_ColorShadow;
        private float m_fStartAngle;
        private float m_fSweepAngle;
        private Chart m_parentCharts;
        private Point m_pExpandingOffset;
        private bool m_bMouseOver = false;
        private bool m_bIsExpanded = false;

        #endregion

        #region Properties

        internal Chart Parent
        {
            get { return this.m_parentCharts; }
            set { this.m_parentCharts = value; }
        }

        public int Index
        {
            get { return this.m_iIndex; }
            set { this.m_iIndex = value; }
        }

        public float Value
        {
            get { return this.m_fValue; }
            set { this.m_fValue = value; }
        }

        public string Text
        {
            get { return this.m_strText; }
            set { this.m_strText = value; }
        }

        public Color Color
        {
            get { return this.m_Color; }
            set
            {
                this.m_Color = value;
                //Create a lighter color for highlight that 
                //is used later when drawing item.
                this.m_ColorHighlight = Color.FromArgb(255,
                    Math.Min(255, (int)((float)(value.R) * (float)(1.5))),
                    Math.Min(255, (int)((float)(value.G) * (float)(1.5))),
                    Math.Min(255, (int)((float)(value.B) * (float)(1.5))));

                //Create a darker color for the shadow of an chartitem 
                this.m_ColorShadow = Color.FromArgb(255,
                    Math.Min(255, (int)((float)(value.R) / (float)(1.5))),
                    Math.Min(255, (int)((float)(value.G) / (float)(1.5))),
                    Math.Min(255, (int)((float)(value.B) / (float)(1.5))));
            }
        }

        //Highlight color is used to gradient fill the item and 
        //highlight when mouse-over.
        [Browsable(false)]
        public Color HighlightColor
        {
            get { return this.m_ColorHighlight; }
            set { this.m_ColorHighlight = value; }
        }

        //Shadowcolor of an chartitem 
        [Browsable(false)]
        public Color ShadowColor
        {
            get { return this.m_ColorShadow; }
            set { this.m_ColorShadow = value; }
        }

        //Starting position of the item. This is relative to the chart type. 
        //For example, this is degrees for pie chart and pixels for bar chart.
        [Browsable(false)]
        public float StartAngle
        {
            get { return this.m_fStartAngle; }
            set { this.m_fStartAngle = value; }
        }

        //Size of the item. This is relative to the chart type. For example, 
        //this is degrees for pie chart and pixels for bar chart.
        [Browsable(false)]
        public float SweepAngle
        {
            get { return this.m_fSweepAngle; }
            set { this.m_fSweepAngle = value; }
        }

        [Browsable(false)]
        public Point ExpandingOffset
        {
            get { return this.m_pExpandingOffset; }
            set { this.m_pExpandingOffset = value; }
        }

        [Browsable(false)]
        public bool MouseOver
        {
            get { return this.m_bMouseOver; }
            set { this.m_bMouseOver = value; }
        }
        
        [Browsable(false)]
        public bool IsExpanded
        {
            get { return this.m_bIsExpanded; }
            set { this.m_bIsExpanded = value; }
        }

        #endregion

        #region MethodsPublic

        public ChartItem()
        { 
        }

        public virtual object Clone()
        {
            ChartItem chartItem = new ChartItem();
            chartItem.Index = this.Index;
            chartItem.Value = this.Value;
            chartItem.Text = this.Text;
            chartItem.Color = this.Color;
            chartItem.HighlightColor = this.HighlightColor;
            chartItem.ShadowColor = this.ShadowColor;
            chartItem.StartAngle = this.StartAngle;
            chartItem.SweepAngle = this.SweepAngle;
            chartItem.ExpandingOffset = this.ExpandingOffset;
            chartItem.MouseOver = this.MouseOver;
            chartItem.IsExpanded = this.IsExpanded;

            return chartItem;
        }

        #endregion

        #region MethodsProtected

        #endregion

        #region MethodsPrivate

        #endregion
    }
}
