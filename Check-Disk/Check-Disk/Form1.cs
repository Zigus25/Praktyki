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
                konfig();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void zacznijTest_Click(object sender, EventArgs ev)
        {
            if (sciezka == "" && !preDifiniowanyTest.Checked)
            {
                PojemnikBledow.Text = "Nie wybrano żadnego pliku/ścieżki";
            }
            else
            {
                if (preDifiniowanyTest.Checked)
                {
                    try
                    {
                        var data = logika.PreDefiniowanyTest();
                        if(data.bledy != null)
                        {
                            PokazError(data.bledy);
                        }
                        if(data.PojemnikBledow != null)
                        {
                            PojemnikBledow.Text = data.PojemnikBledow;
                        }
                        if (data.kopia != null)
                        {
                            Zgodnosc.Text = data.TextWeryfikacji;
                            Zgodnosc.Visible = true;
                            wynikiKopia = data.kopia;
                            ZapisStat.Text = data.ZapisText;
                            OdczytStaty.Text = data.OdczytText;
                            ZapisStat.Visible = true;
                            OdczytStaty.Visible = true;
                            Kopiuj.Visible = true;
                        }
                    }
                    catch (Exception e)
                    {
                        PokazError(e);
                    }
                }
                else if (odczytButton.Checked)
                {
                    try
                    {
                        var data = logika.TestOdczytu(Convert.ToInt32(LiczbaWatkow.Value),sciezka);
                        wynikiKopia = data.kopia;
                        OdczytStaty.Text = data.OdczytText;
                        OdczytStaty.Visible = true;
                        Kopiuj.Visible = true;
                    }
                    catch (Exception e)
                    {
                        PokazError(e);
                    }
                }
                else if (logika.SprawdzMiejsceNaDysku(logika.CalcMBToB(Convert.ToInt32(RozmiarPlikow.Value) * Convert.ToInt32(iloscPlikow.Value)), sciezka))
                {
                    if (zapisButton.Checked)
                    {
                        try
                        {
                            var data = logika.TestZapisu(Convert.ToInt32(LiczbaWatkow.Value),Convert.ToInt32(iloscPlikow.Value),Convert.ToInt32(RozmiarPlikow.Value),sciezka,weryfikacja.Checked);
                            if (data.bledy != null)
                            {
                                PokazError(data.bledy);
                            }
                            if (data.PojemnikBledow != null)
                            {
                                PojemnikBledow.Text = data.PojemnikBledow;
                            }
                            if (data.kopia != null)
                            {
                                Zgodnosc.Text = data.TextWeryfikacji;
                                Zgodnosc.Visible = true;
                                wynikiKopia = data.kopia;
                                ZapisStat.Text = data.ZapisText;
                                ZapisStat.Visible = true;
                                Kopiuj.Visible = true;
                            }
                        }
                        catch (Exception e)
                        {
                            PokazError(e);
                        }
                    }
                    else if (zapisOdczytButton.Checked)
                    {
                        try
                        {
                            var data = logika.TestZapisOdczyt(Convert.ToInt32(LiczbaWatkow.Value), Convert.ToInt32(iloscPlikow.Value), Convert.ToInt32(RozmiarPlikow.Value), sciezka, weryfikacja.Checked);
                            if (data.bledy != null)
                            {
                                PokazError(data.bledy);
                            }
                            if (data.PojemnikBledow != null)
                            {
                                PojemnikBledow.Text = data.PojemnikBledow;
                            }
                            if (data.kopia != null)
                            {
                                Zgodnosc.Text = data.TextWeryfikacji;
                                Zgodnosc.Visible = true;
                                wynikiKopia = data.kopia;
                                ZapisStat.Text = data.ZapisText;
                                ZapisStat.Visible = true;
                                OdczytStaty.Text = data.OdczytText;
                                OdczytStaty.Visible = true;
                                Kopiuj.Visible = true;
                            }
                        }
                        catch (Exception e)
                        {
                            PokazError(e);
                        }
                    }
                }
                else
                {
                    PojemnikBledow.Text = "Nie można wykonać żadnego testu";
                }
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
                konfig();
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

        public void konfig()
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
    }
}