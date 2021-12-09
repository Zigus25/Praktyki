using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZmianaNazwyOkna
{
    public partial class Form1 : Form
    {
        String aktualnyTytul = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Zatwierdzenie_Click(object sender, EventArgs e)
        {
            if (Zmiana.Checked)
            {
                this.Text = NowaNazwa.Text;
                if (aktualnyTytul != NowaNazwa.Text)
                {
                    aktualnyTytul = NowaNazwa.Text;
                    TextHistory.Text += "\n" + NowaNazwa.Text;
                }
            }
        }

        private void Zmiana_CheckedChanged(object sender, EventArgs e)
        {
            if (Zmiana.Checked)
            {
                text.Visible = false;
            }
            else
            {
                text.Visible = true;
            }
        }
    }
}
