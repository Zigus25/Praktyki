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
                logika.WczytajConfig();
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
            string zaznaczonaOpcja = "";
            if (preDifiniowanyTest.Checked)
            {
                zaznaczonaOpcja = "Pre";
            }
            else if (zapisButton.Checked)
            {
                zaznaczonaOpcja = "za";
            }
            else if (odczytButton.Checked)
            {
                zaznaczonaOpcja = "od";
            }
            else if (zapisOdczytButton.Checked)
            {
                zaznaczonaOpcja = "za/od";
            }
            try
            {
                var data = new Config
                {
                    LiczbaWatkow = Convert.ToInt32(LiczbaWatkow.Value),
                    RozmiarPlikow = Convert.ToInt32(RozmiarPlikow.Value),
                    LiczbaPlikow = Convert.ToInt32(iloscPlikow.Value),
                    Sciezka = sciezka,
                    Weryfikacja = weryfikacja.Checked,
                    Zaznaczenie = zaznaczonaOpcja

                };
                logika.zapiszConfig(data);
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
                Config config = logika.WczytajConfig();
                LiczbaWatkow.Value = config.LiczbaWatkow;
                RozmiarPlikow.Value = config.RozmiarPlikow;
                iloscPlikow.Value = config.LiczbaPlikow;
                sciezka = config.Sciezka; wyswietlSciezke.Text = sciezka;
                weryfikacja.Checked = config.Weryfikacja;
                string zaz = config.Zaznaczenie;
                if (zaz == "Pre") { preDifiniowanyTest.Checked = true; } else if (zaz == "za") { zapisButton.Checked = true; } else if (zaz == "od") { odczytButton.Checked = true; } else if (zaz == "za/od") { zapisOdczytButton.Checked = true; }

            }
            catch (Exception ex)
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