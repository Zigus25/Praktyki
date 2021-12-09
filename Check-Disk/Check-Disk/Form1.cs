using System;
using System.Windows.Forms;

namespace Check_Disk
{
    public partial class Form1 : Form
    {
        public string sciezka = "";
        public string wynikiKopia = "";
        Logika logika = new Logika();

        public Form1()
        {
            InitializeComponent();
            LiczbaWatkow.Maximum = Environment.ProcessorCount;
            logika.PrzekazForm(this);
            logika.wczytajConfig();
        }

        private void zacznijTest_Click(object sender, EventArgs e)
        {
            logika.rozpoznajTest();
        }

        private void podajSciezke_Click(object sender, EventArgs e)
        {
            if (zapisButton.Checked || zapisOdczytButton.Checked)
            {
                DialogResult res = FolderDialog.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    sciezka = FolderDialog.SelectedPath;
                    wyswietlSciezke.Text = sciezka;
                }
            }
            else if (odczytButton.Checked)
            {
                DialogResult res = FileDialog.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    sciezka = FileDialog.FileName;
                    wyswietlSciezke.Text = sciezka;
                }
            }
            else
            {
                wyswietlSciezke.Text = "Wybierz odpowiednią opcję";
            }
        }

        private void ZapiszConfig_Click(object sender, EventArgs e)
        {
            logika.zapiszConfig();
        }

        private void WczytajConfig_Click(object sender, EventArgs e)
        {
            logika.wczytajConfig();
        }

        private void Kopiuj_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(wynikiKopia);
        }
    }
}