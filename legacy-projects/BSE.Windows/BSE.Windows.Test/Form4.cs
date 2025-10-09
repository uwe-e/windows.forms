using BSE.Windows.Forms;
using BSE.Windows.Forms.Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BSE.Windows.Test
{
    public partial class Form4 : MetroForm
    {
        public Form4()
        {
            InitializeComponent();

            ToolStripProfessionalRenderer toolStripRenderer = new BSE.Windows.Forms.MetroRenderer();
            ToolStripManager.Renderer = toolStripRenderer;
            BSE.Windows.Forms.ProfessionalColorTable colorTable = toolStripRenderer.ColorTable as BSE.Windows.Forms.ProfessionalColorTable;
            if (colorTable != null)
            {
                //this.ProfessionalColorTable = colorTable;
                BSE.Windows.Forms.PanelColors panelColorTable = colorTable.PanelColorTable;
                if (panelColorTable != null)
                {
                    PanelSettingsManager.SetPanelProperties(this.Controls, panelColorTable);
                    //this.PanelColors = panelColorTable;
                }
            }
        }
    }
}
