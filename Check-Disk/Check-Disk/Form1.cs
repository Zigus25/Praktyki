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
            try
            {
                logika.PrzekazForm(this);
                logika.wczytajConfig();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void zacznijTest_Click(object sender, EventArgs ev)
        {
            try
            {
                logika.rozpoznajTest();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void podajSciezke_Click(object sender, EventArgs ev)
        {
            if (zapisButton.Checked || zapisOdczytButton.Checked)
            {
                DialogResult res = FolderDialog.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    try
                    {
                        sciezka = FolderDialog.SelectedPath;
                        wyswietlSciezke.Text = sciezka;
                    }catch(Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
            else if (odczytButton.Checked)
            {
                DialogResult res = FileDialog.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    try
                    {
                        sciezka = FileDialog.FileName;
                        wyswietlSciezke.Text = sciezka;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
            else
            {
                wyswietlSciezke.Text = "Wybierz odpowiednią opcję";
            }
        }

        private void ZapiszConfig_Click(object sender, EventArgs e)
        {
            try
            {
                logika.zapiszConfig();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WczytajConfig_Click(object sender, EventArgs e)
        {
            try 
            { 
                logika.wczytajConfig();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Kopiuj_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(wynikiKopia);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PokazError(Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }
}