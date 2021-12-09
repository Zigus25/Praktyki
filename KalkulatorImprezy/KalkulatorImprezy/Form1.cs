using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalkulatorImprezy
{
    public partial class Form1 : Form
    {
        int koszt = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void IleOsob_ValueChanged(object sender, EventArgs e)
        {
            sumuj();
        }

        private void Dekoracje_CheckedChanged(object sender, EventArgs e)
        {
            sumuj();
        }

        private void Jedzenie_CheckedChanged(object sender, EventArgs e)
        {
            sumuj();
        }

        private void sumuj()
        {
            koszt = 0;
            int count = Convert.ToInt32(Math.Round(IleOsob.Value, 0));
            if (Jedzenie.Checked)
            {
                koszt += count * 40;
            }
            else
            {
                koszt += count * 25;
            }

            if (Dekoracje.Checked)
            {
                koszt += 50;
            }

            koszt += count * 30;

            Koszt.Text = "Koszt: " + koszt;
        }
    }
}
