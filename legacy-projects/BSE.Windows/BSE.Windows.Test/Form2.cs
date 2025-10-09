using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSE.Windows.Forms.Form;

namespace BSE.Windows.Test
{
    public partial class Form2 : MetroForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ClientSize = new Size(
                this.ClientSize.Width,
                this.ClientSize.Height - 30);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FixedToolWindow form = new FixedToolWindow();
            form.Show();
        }
    }
}
