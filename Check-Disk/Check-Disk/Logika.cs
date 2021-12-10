using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Check_Disk
{
    public class Logika
    {
        Form1 f;
        string DomyslnaSciezka = Directory.GetCurrentDirectory();
        Task taskJob;
        static string ConfigFileDirectory = Directory.GetCurrentDirectory() + @"\config.txt";

        public void rozpoznajTest()
        {
            if (f.sciezka == "" && !f.preDifiniowanyTest.Checked)
            {
                f.PojemnikBledow.Text = "Nie wybrano żadnego pliku/ścieżki";
            }
            else
            {
                int nWL = Convert.ToInt32(f.LiczbaWatkow.Value);
                int LPlikow = Convert.ToInt32(f.iloscPlikow.Value);
                double wynikZapis = 0.0;
                double wynikOdczyt = 0.0;
                if (f.preDifiniowanyTest.Checked)
                {
                    if (SprawdzMiejsceNaDysku(CalcMBToB(100*(Environment.ProcessorCount*3)), DomyslnaSciezka))
                    {
                        try
                        {
                            DomyslnaSciezka = CreateFolder(DomyslnaSciezka);
                            SprawdzPoprawnosc(DomyslnaSciezka);
                        }
                        catch (Exception e)
                        {
                            f.PokazError(e);
                        }
                        for (int j = 0; j < Environment.ProcessorCount; j++)
                        {
                            try
                            {
                                taskJob = Task.Factory.StartNew(() => {
                                double wynikteraz = WriteTest(CalcMBToB(100), DomyslnaSciezka + @"\testowyplik" + j);
                                wynikZapis += wynikteraz;
                                });
                                Thread.Sleep(200);
                            }
                            catch (Exception e)
                            {
                                f.PokazError(e);
                            }
                        }
                        for (int j = 0; j < Environment.ProcessorCount; j++)
                        {
                            try
                            {
                                taskJob = Task.Factory.StartNew(() => {
                                double wynikterazOdczyt = ReadTest(DomyslnaSciezka + @"\testowyplik10.txt");
                                wynikOdczyt += wynikterazOdczyt;
                                });
                            }
                            catch (Exception e)
                            {
                                f.PokazError(e);
                            }
                        }
                        Task.WaitAll(taskJob);


                        f.ZapisStat.Text = "Zapis: " + Math.Round(wynikZapis / Environment.ProcessorCount, 2) + @"MB\s";
                        f.wynikiKopia = "Zapis: " + Math.Round(wynikZapis / Environment.ProcessorCount, 2) + @"MB\s";
                        f.ZapisStat.Visible = true;
                        f.Kopiuj.Visible = true;

                        f.OdczytStaty.Text = "Odczyt: " + Math.Round(wynikOdczyt / Environment.ProcessorCount, 2) + @"MB\s";
                        f.wynikiKopia += " Odczyt: " + Math.Round(wynikOdczyt / Environment.ProcessorCount, 2) + @"MB\s";
                        f.OdczytStaty.Visible = true;
                        try 
                        { 
                            DeleteTestFileFolder(DomyslnaSciezka);
                        }
                        catch (Exception e)
                        {
                            f.PokazError(e);
                        }
                }
                }
                else if (f.odczytButton.Checked)
                {
                    for (int j = 0; j < nWL / LPlikow; j++)
                    {
                        try
                        {
                            taskJob = Task.Factory.StartNew(() => {
                                double wynikterazOdczyt = ReadTest(f.sciezka);
                                wynikOdczyt += wynikterazOdczyt;
                            });
                        }
                        catch (Exception e)
                        {
                            f.PokazError(e);
                        }
                    }
                    Task.WaitAll(taskJob);

                    f.OdczytStaty.Text = "Odczyt: " + Math.Round(wynikOdczyt / nWL, 2) + @"MB\s";
                    f.wynikiKopia = "Odczyt: " + Math.Round(wynikOdczyt / nWL, 2) + @"MB\s";
                    f.OdczytStaty.Visible = true;
                }
                else if (SprawdzMiejsceNaDysku(CalcMBToB(Convert.ToInt32(f.RozmiarPlikow.Value) * LPlikow), f.sciezka))
                {
                    if (f.zapisButton.Checked)
                    {
                        f.sciezka = CreateFolder(f.sciezka);
                        if (f.weryfikacja.Checked)
                        {
                            try 
                            { 
                                SprawdzPoprawnosc(f.sciezka);
                            }
                            catch (Exception e)
                            {
                                f.PokazError(e);
                            }
                        }
                        for (int i = 0; i < LPlikow; i++)
                        {
                            for (int j = 0; j < nWL / LPlikow; j++)
                            {
                                try
                                {
                                    taskJob = Task.Factory.StartNew(() => {
                                        double wynikteraz = WriteTest(CalcMBToB(Convert.ToInt32(f.RozmiarPlikow.Value)), f.sciezka + @"\testowyplik" + j);
                                        wynikZapis += wynikteraz;
                                    });
                                    Thread.Sleep(200);
                                }
                                catch (Exception e)
                                {
                                    f.PokazError(e);
                                }
                            }
                        }
                        Task.WaitAll(taskJob);
                        f.ZapisStat.Text = "Zapis: " + Math.Round(wynikZapis / (nWL / LPlikow), 2) + @"MB\s";
                        f.wynikiKopia = "Zapis: " + Math.Round(wynikZapis / (nWL / LPlikow), 2) + @"MB\s";
                        f.ZapisStat.Visible = true;
                        f.Kopiuj.Visible = true;
                        try
                        {
                            DeleteTestFileFolder(f.sciezka);
                        }
                        catch (Exception e)
                        {
                            f.PokazError(e);
                        }
                    }
                    else if (f.zapisOdczytButton.Checked)
                    {
                        f.sciezka = CreateFolder(f.sciezka);
                        if (f.weryfikacja.Checked)
                        {
                            try
                            {
                                SprawdzPoprawnosc(f.sciezka);
                            }
                            catch (Exception e)
                            {
                                f.PokazError(e);
                            }
                        }
                        for (int j = 0; j < Environment.ProcessorCount; j++)
                        {
                            try
                            {
                                taskJob = Task.Factory.StartNew(() => {
                                double wynikteraz = WriteTest(CalcMBToB(100), f.sciezka + @"\testowyplik" + j);
                                wynikZapis += wynikteraz;
                                });
                                Thread.Sleep(200);
                            }
                            catch (Exception e)
                            {
                                f.PokazError(e);
                            }
                        }
                        for (int j = 0; j < Environment.ProcessorCount; j++)
                        {
                            try
                            {
                                taskJob = Task.Factory.StartNew(() => {
                                    double wynikterazOdczyt = ReadTest(f.sciezka + @"\testowyplik10.txt");
                                    wynikOdczyt += wynikterazOdczyt;
                                });
                            }
                            catch (Exception e)
                            {
                                f.PokazError(e);
                            }
                        }
                        Task.WaitAll(taskJob);

                        f.ZapisStat.Text = "Zapis: " + Math.Round(wynikZapis / (nWL / LPlikow), 2) + @"MB\s";
                        f.wynikiKopia = "Zapis: " + Math.Round(wynikZapis / (nWL / LPlikow), 2) + @"MB\s";
                        f.ZapisStat.Visible = true;
                        f.Kopiuj.Visible = true;

                        f.OdczytStaty.Text = "Odczyt: " + Math.Round(wynikOdczyt / nWL, 2) + @"MB\s";
                        f.wynikiKopia += " Odczyt: " + Math.Round(wynikOdczyt / nWL, 2) + @"MB\s";
                        f.OdczytStaty.Visible = true;
                        Thread.Sleep(2000);
                        DeleteTestFileFolder(f.sciezka);
                    }
                }
            }
        }

        public void PrzekazForm(Form1 form)
        {
            f = form;
        }

        public bool SprawdzMiejsceNaDysku(long size,string path)
        {
            long a = 0;
            string dysk = Path.GetPathRoot(path);
            DriveInfo drive = new DriveInfo(dysk);
            
            if (drive.IsReady)
            {
                a = drive.AvailableFreeSpace;
            }
            
            return a > size;
        }

        public int CalcMBToB(int MB)
        {
            return MB * 1024 * 1024;
        }

        public int CalcBToMB(int B)
        {
            return B / (1024 * 1024);
        }

        public void wczytajConfig()
        {
            if (File.Exists(ConfigFileDirectory))
            {
                StreamReader sr = new StreamReader(ConfigFileDirectory);
                string line = "";
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    switch (i)
                    {
                        case 0: f.LiczbaWatkow.Value = int.Parse(line); break;
                        case 1: f.RozmiarPlikow.Value = int.Parse(line); break;
                        case 2: f.iloscPlikow.Value = int.Parse(line); break;
                        case 3: f.sciezka = line; f.wyswietlSciezke.Text = line; break;
                        case 4: if (line == "True") f.weryfikacja.Checked = true; break;
                        case 5: if (line == "Pre") { f.preDifiniowanyTest.Checked = true; } else if (line == "za") { f.zapisButton.Checked = true; } else if (line == "od") { f.odczytButton.Checked = true; } else if (line == "za/od") { f.zapisOdczytButton.Checked = true; } break;
                    }
                    i++;
                }
                sr.Close();
            }
        }

        public void zapiszConfig()
        {
            string zaznaczonaOpcja = "";
            if (f.preDifiniowanyTest.Checked)
            {
                zaznaczonaOpcja = "Pre";
            }
            else if (f.zapisButton.Checked)
            {
                zaznaczonaOpcja = "za";
            }
            else if (f.odczytButton.Checked)
            {
                zaznaczonaOpcja = "od";
            }
            else if (f.zapisOdczytButton.Checked)
            {
                zaznaczonaOpcja = "za/od";
            }
            var data = new Config[]
            {
                new Config()
                {
                    LiczbaWatkow = Convert.ToInt32(f.LiczbaWatkow.Value),
                    RozmiarPlikow = Convert.ToInt32(f.RozmiarPlikow.Value),
                    LiczbaPlikow = Convert.ToInt32(f.iloscPlikow.Value),
                    Sciezka = f.sciezka,
                    Weryfikacja = f.weryfikacja.Checked,
                    Zaznaczenie = zaznaczonaOpcja
                   
                }
            };
            Zapis.ExportToTextFile(data,ConfigFileDirectory,';');
        }

        

        public double WriteTest(int whatSizeFile, string path)
        {
            int bytes = whatSizeFile;
            double wyniki = 0.0;
            for (int i = 0; i < 3; i++)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                File.WriteAllBytes(Path.Combine(path, i.ToString(), ".txt"), new byte[bytes]);
                watch.Stop();
                double elapsedMs = watch.ElapsedMilliseconds;
                double wynik = (CalcBToMB(bytes) / Math.Round(elapsedMs / 1000,3));
                wyniki += wynik;
                Thread.Sleep(200);
            }
            return Math.Round(wyniki / 3, 2);
        }

        public double ReadTest(string path)
        {
            double wyniki = 0.0;
            int rozmiar = CalcBToMB((int)new FileInfo(path).Length);
            for (int i = 0; i < 3; i++)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                File.ReadAllText(path);
                watch.Stop();
                double elapsedMs = watch.ElapsedMilliseconds;
                double wynik = rozmiar / Math.Round(elapsedMs / 1000, 3);
                wyniki += wynik;
                Thread.Sleep(200);
            }

            return Math.Round(wyniki / 3, 2);
        }

        public string CreateFolder(string path)
        {
            string nazwaFolderu = @"\testowepliki";
            bool gotowy = false;
            int i = 1;
            while (!gotowy)
            {
                if (Directory.Exists(path + nazwaFolderu))
                {
                    nazwaFolderu += i;
                    i++;
                }
                else
                {
                    Directory.CreateDirectory(path + nazwaFolderu);
                    gotowy = true;
                }
            }
            return path + nazwaFolderu;
        }

        public void DeleteTestFileFolder(string path)
        {
            Directory.Delete(path, true);
        }

        public void SprawdzPoprawnosc(string path)
        {
            string a = "To jest przykladowy tekst do sprawdzania";
            try
            {
                StreamWriter wr = new StreamWriter(path + @"\PlikZgodnosci.txt");
                wr.WriteLine(a);
                wr.Close();
                StreamReader re = new StreamReader(path + @"\PlikZgodnosci.txt");
                if (re.ReadLine().Equals(a))
                {
                    f.Zgodnosc.Text = "Pliki są zapisywane poprawnie";
                    f.Zgodnosc.Visible = true;
                }
                else
                {
                    f.Zgodnosc.Text = "Pliki nie są zapisywane poprawnie";
                    f.Zgodnosc.Visible = true;
                }
            }
            catch (Exception e)
            {
                f.PokazError(e);
            }
}
    }
}
