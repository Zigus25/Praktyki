using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Check_Disk
{
    public partial class Form1 : Form
    {
        Task taskJob;
        public String sciezka = "";
        String DomyslnaSciezka = Directory.GetCurrentDirectory();
        String wynikiKopia = "";
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
            if (sciezka == "" && !preDifiniowanyTest.Checked)
            {
                PojemnikBledow.Text = "Nie wybrano żadnego pliku/ścieżki";
            }
            else
            {
                int nWL = Convert.ToInt32(LiczbaWatkow.Value);
                int LPlikow = Convert.ToInt32(iloscPlikow.Value);
                double wynikZapis = 0.0;
                double wynikOdczyt = 0.0;
                if (preDifiniowanyTest.Checked)
                {
                    if (logika.SprawdzMiejsceNaDysku(logika.CalcMBToB(Convert.ToInt32(RozmiarPlikow.Value)), DomyslnaSciezka))
                    {
                        DomyslnaSciezka = logika.CreateFolder(DomyslnaSciezka);
                        logika.SprawdzPoprawnosc(DomyslnaSciezka);
                        for (int j = 0; j < Environment.ProcessorCount; j++)
                        {
                            taskJob = Task.Factory.StartNew(() => {
                                double wynikteraz = logika.WriteTest(logika.CalcMBToB(100), DomyslnaSciezka + @"\testowyplik" + j);
                                wynikZapis += wynikteraz;
                            });
                            Thread.Sleep(200);
                        }
                        for (int j = 0; j < Environment.ProcessorCount; j++)
                        {
                            taskJob = Task.Factory.StartNew(() => {
                                double wynikterazOdczyt = logika.ReadTest(DomyslnaSciezka + @"\testowyplik10.txt");
                                wynikOdczyt += wynikterazOdczyt;
                            });
                        }
                        Task.WaitAll(taskJob);


                        ZapisStat.Text = "Zapis: " + Math.Round(wynikZapis / Environment.ProcessorCount, 2) + @"MB\s";
                        wynikiKopia = "Zapis: " + Math.Round(wynikZapis / Environment.ProcessorCount, 2) + @"MB\s";
                        ZapisStat.Visible = true;
                        Kopiuj.Visible = true;

                        OdczytStaty.Text = "Odczyt: " + Math.Round(wynikOdczyt / Environment.ProcessorCount, 2) + @"MB\s";
                        wynikiKopia += " Odczyt: " + Math.Round(wynikOdczyt / Environment.ProcessorCount, 2) + @"MB\s";
                        OdczytStaty.Visible = true;
                        logika.DeleteTestFileFolder(DomyslnaSciezka);
                    }
                }else if (logika.SprawdzMiejsceNaDysku(logika.CalcMBToB(Convert.ToInt32(RozmiarPlikow.Value)*LPlikow),sciezka))
                {
                    if (zapisButton.Checked)
                    {
                        sciezka = logika.CreateFolder(sciezka);
                        if (weryfikacja.Checked)
                        {
                            logika.SprawdzPoprawnosc(sciezka);
                        }
                        for (int i = 0; i < LPlikow; i++)
                        {
                            for (int j = 0; j < nWL / LPlikow; j++)
                            {
                                taskJob = Task.Factory.StartNew(() => {
                                    double wynikteraz = logika.WriteTest(logika.CalcMBToB(Convert.ToInt32(RozmiarPlikow.Value)), sciezka + @"\testowyplik" + j);
                                    wynikZapis += wynikteraz;
                                });
                                Thread.Sleep(200);
                            }
                        }
                        Task.WaitAll(taskJob);
                        ZapisStat.Text = "Zapis: " + Math.Round(wynikZapis / (nWL / LPlikow), 2) + @"MB\s";
                        wynikiKopia = "Zapis: " + Math.Round(wynikZapis / (nWL / LPlikow), 2) + @"MB\s";
                        ZapisStat.Visible = true;
                        Kopiuj.Visible = true;
                        logika.DeleteTestFileFolder(sciezka);
                    }
                    else if (odczytButton.Checked)
                    {
                        for (int j = 0; j < nWL / LPlikow; j++)
                        {
                            taskJob = Task.Factory.StartNew(() => {
                                double wynikterazOdczyt = logika.ReadTest(sciezka);
                                wynikOdczyt += wynikterazOdczyt;
                            });
                        }
                        Task.WaitAll(taskJob);

                        OdczytStaty.Text = "Odczyt: " + Math.Round(wynikOdczyt / nWL, 2) + @"MB\s";
                        wynikiKopia = "Odczyt: " + Math.Round(wynikOdczyt / nWL, 2) + @"MB\s";
                        OdczytStaty.Visible = true;
                    }
                    else if (zapisOdczytButton.Checked)
                    {
                        sciezka = logika.CreateFolder(sciezka);
                        if (weryfikacja.Checked)
                        {
                            logika.SprawdzPoprawnosc(sciezka);
                        }
                        for (int j = 0; j < Environment.ProcessorCount; j++)
                        {
                            taskJob = Task.Factory.StartNew(() => {
                                double wynikteraz = logika.WriteTest(logika.CalcMBToB(100), sciezka + @"\testowyplik" + j);
                                wynikZapis += wynikteraz;
                            });
                            Thread.Sleep(200);
                        }
                        for (int j = 0; j < Environment.ProcessorCount; j++)
                        {
                            taskJob = Task.Factory.StartNew(() => {
                                double wynikterazOdczyt = logika.ReadTest(sciezka + @"\testowyplik10.txt");
                                wynikOdczyt += wynikterazOdczyt;
                            });
                        }
                        Task.WaitAll(taskJob);

                        ZapisStat.Text = "Zapis: " + Math.Round(wynikZapis / (nWL / LPlikow), 2) + @"MB\s";
                        wynikiKopia = "Zapis: " + Math.Round(wynikZapis / (nWL / LPlikow), 2) + @"MB\s";
                        ZapisStat.Visible = true;
                        Kopiuj.Visible = true;

                        OdczytStaty.Text = "Odczyt: " + Math.Round(wynikOdczyt / nWL, 2) + @"MB\s";
                        wynikiKopia += " Odczyt: " + Math.Round(wynikOdczyt / nWL, 2) + @"MB\s";
                        OdczytStaty.Visible = true;
                        Thread.Sleep(2000);
                        logika.DeleteTestFileFolder(sciezka);
                    }
                }
            }
        }

        private void podajSciezke_Click(object sender, EventArgs e)
        {
            if (zapisButton.Checked)
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
            else if (zapisOdczytButton.Checked)
            {
                DialogResult res = FolderDialog.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    sciezka = FolderDialog.SelectedPath;
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