using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using BSE.Platten.BO;
using System.Collections;
using System.Runtime.InteropServices;
using System.Drawing;

namespace BSE.Platten.Common
{
    public static class ToolStripSettingsManager
    {
        /// <summary>
        /// Loads settings for the given Form using the forms control collection and the toolstripsettings collection.
        /// </summary>
        /// <param name="controls">the controls collection of the form</param>
        /// <param name="toolStripSettingsCollection">the toolstripsettings collection which contains
        /// the properties of the toolstrip</param>
        public static void Load(Control.ControlCollection controls, Collection<ToolStripSettings> toolStripSettingsCollection)
        {
            if ((controls != null) && (toolStripSettingsCollection != null))
            {
                ArrayList toolStripPanels = FindToolStripPanels(true, controls);
                ArrayList toolStrips = FindToolStrips(true, controls);
                Dictionary<string, ToolStripPanel> panelDictionary = null;
                foreach (ToolStripPanel toolStripPanel in toolStripPanels)
                {
                    if (panelDictionary == null)
                    {
                        panelDictionary = new Dictionary<string, ToolStripPanel>();
                    }
                    
                    string name = toolStripPanel.Name;
                    if ((string.IsNullOrEmpty(name) && (toolStripPanel.Parent is ToolStripContainer)) && !string.IsNullOrEmpty(toolStripPanel.Parent.Name))
                    {
                        name = toolStripPanel.Parent.Name + "." + toolStripPanel.Dock.ToString();
                    }

                    if (panelDictionary.ContainsKey(name) == false)
                    {
                        panelDictionary.Add(name, toolStripPanel);
                    }
                }

                Dictionary<string, ToolStrip> stripDictionary = null;
                foreach (ToolStrip toolStrip in toolStrips)
                {
                    if (stripDictionary == null)
                    {
                        stripDictionary = new Dictionary<string, ToolStrip>();
                    }
                    if (stripDictionary.ContainsKey(toolStrip.Name) == false)
                    {
                        stripDictionary.Add(toolStrip.Name, toolStrip);
                    }
                }

                if ((panelDictionary != null) && (panelDictionary.Count > 0)
                    && (stripDictionary != null) && (stripDictionary.Count > 0))
                {
                    foreach (ToolStripSettings toolStripSettings in toolStripSettingsCollection)
                    {
                        ToolStripPanel toolStripPanel;
                        if (panelDictionary.TryGetValue(toolStripSettings.ToolStripPanelName, out toolStripPanel) == true)
                        {
                            toolStripPanel.SuspendLayout();
                            toolStripPanel.BeginInit();
                            ToolStrip toolStrip;
                            if (stripDictionary.TryGetValue(toolStripSettings.Name, out toolStrip) == true)
                            {
                                toolStripPanel.Join(toolStrip, toolStripSettings.Location);
                            }
                            toolStripPanel.EndInit();
                            toolStripPanel.ResumeLayout(true);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// finds the toolstrips within the control collection and return a toolstripsettings collection
        /// </summary>
        /// <param name="controls">the controls collection of the form</param>
        /// <returns>the toolstripsettings collection which contains
        /// the properties of the toolstrip</returns>
        public static Collection<ToolStripSettings> Save(Control.ControlCollection controls)
        {
            Collection<ToolStripSettings> toolStripSettingsCollection = null;
            if (controls != null)
            {
                ArrayList toolStrips = FindToolStrips(true, controls);
                foreach (ToolStrip toolStrip in toolStrips)
                {
                    if (toolStripSettingsCollection == null)
                    {
                        toolStripSettingsCollection = new System.Collections.ObjectModel.Collection<ToolStripSettings>();
                    }
                    ToolStripSettings toolStripSettings = new ToolStripSettings();
                    SettingsStub settingsStub = new SettingsStub(toolStrip);
                    if (string.IsNullOrEmpty(settingsStub.ToolStripPanelName) == false)
                    {
                        toolStripSettings.Location = settingsStub.Location;
                        toolStripSettings.Name = settingsStub.Name;
                        toolStripSettings.Size = settingsStub.Size;
                        toolStripSettings.ToolStripPanelName = settingsStub.ToolStripPanelName;
                        toolStripSettings.Visible = toolStrip.Visible;

                        toolStripSettingsCollection.Add(toolStripSettings);
                    }
                }
            }
            return toolStripSettingsCollection;
        }

        #region MethodsPrivate

        private static ArrayList FindToolStrips(bool searchAllChildren, Control.ControlCollection controlsToLookIn)
        {
            return FindControls(typeof(ToolStrip), searchAllChildren, controlsToLookIn, new ArrayList());
        }

        private static ArrayList FindToolStripPanels(bool searchAllChildren, Control.ControlCollection controlsToLookIn)
        {
            return FindControls(typeof(ToolStripPanel), searchAllChildren, controlsToLookIn, new ArrayList());
        }

        private static ArrayList FindControls(Type baseType, bool searchAllChildren, Control.ControlCollection controlsToLookIn, ArrayList foundControls)
        {
            if ((controlsToLookIn == null) || (foundControls == null))
            {
                return null;
            }
            try
            {
                for (int i = 0; i < controlsToLookIn.Count; i++)
                {
                    if ((controlsToLookIn[i] != null) && baseType.IsAssignableFrom(controlsToLookIn[i].GetType()))
                    {
                        foundControls.Add(controlsToLookIn[i]);
                    }
                }
                if (searchAllChildren == false)
                {
                    return foundControls;
                }
                for (int j = 0; j < controlsToLookIn.Count; j++)
                {
                    if (((controlsToLookIn[j] != null) && !(controlsToLookIn[j] is Form)) && ((controlsToLookIn[j].Controls != null) && (controlsToLookIn[j].Controls.Count > 0)))
                    {
                        foundControls = FindControls(baseType, searchAllChildren, controlsToLookIn[j].Controls, foundControls);
                    }
                }
            }
            catch (Exception exception)
            {
                if (IsCriticalException(exception))
                {
                    throw;
                }
            }
            return foundControls;
        }
        
        private static bool IsCriticalException(Exception exception)
        {
            return (((((exception is NullReferenceException) ||
                (exception is StackOverflowException)) ||
                ((exception is OutOfMemoryException) ||
                (exception is System.Threading.ThreadAbortException))) ||
                ((exception is ExecutionEngineException) ||
                (exception is IndexOutOfRangeException))) ||
                (exception is AccessViolationException));
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SettingsStub
        {
            public bool Visible;
            public string ToolStripPanelName;
            public Point Location;
            public Size Size;
            public string Name;
            public SettingsStub(ToolStrip toolStrip)
            {
                this.ToolStripPanelName = string.Empty;
                ToolStripPanel panel = toolStrip.Parent as ToolStripPanel;
                if (panel != null)
                {
                    if (!string.IsNullOrEmpty(panel.Name))
                    {
                        this.ToolStripPanelName = panel.Name;
                    }
                    else if ((panel.Parent is ToolStripContainer) && !string.IsNullOrEmpty(panel.Parent.Name))
                    {
                        this.ToolStripPanelName = panel.Parent.Name + "." + panel.Dock.ToString();
                    }
                }
                this.Visible = toolStrip.Visible;
                this.Size = toolStrip.Size;
                this.Location = toolStrip.Location;
                this.Name = toolStrip.Name;
            }
        }

        #endregion
    }
}
