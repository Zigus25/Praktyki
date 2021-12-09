using System;
using System.IO;
using System.Threading;

namespace Check_Disk
{
    public class Logika
    {
        Form1 f;
        static String ConfigFileDirectory = Directory.GetCurrentDirectory() + @"\config.txt";

        public void PrzekazForm(Form1 form)
        {
            f = form;
        }

        public Boolean SprawdzMiejsceNaDysku(long size,string path)
        {
            long a = 0;
            string dysk = path[0].ToString() + path[1].ToString() + path[2].ToString();
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
                String line = "";
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
            int liczbaWatkow = Convert.ToInt32(Math.Round(f.LiczbaWatkow.Value, 0));
            int rozmiarcplikow = Convert.ToInt32(Math.Round(f.RozmiarPlikow.Value, 0));
            int liczbaPlikow = Convert.ToInt32(Math.Round(f.iloscPlikow.Value, 0));
            String Sciezka = f.sciezka;
            Boolean Weryfikacja = f.weryfikacja.Checked;
            String zaznaczonaOpcja = "";
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
            StreamWriter writer = new StreamWriter(ConfigFileDirectory);
            writer.WriteLine(liczbaWatkow);
            writer.WriteLine(rozmiarcplikow);
            writer.WriteLine(liczbaPlikow);
            writer.WriteLine(Sciezka);
            writer.WriteLine(Weryfikacja);
            writer.WriteLine(zaznaczonaOpcja);
            writer.Close();
        }

        public double WriteTest(int whatSizeFile, string path)
        {
            int bytes = whatSizeFile;
            double wyniki = 0.0;
            for (int i = 0; i < 3; i++)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                System.IO.File.WriteAllBytes(path + i + ".txt", new byte[bytes]);
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
            int rozmiar = CalcBToMB((int)new System.IO.FileInfo(path).Length);
            for (int i = 0; i < 3; i++)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                System.IO.File.ReadAllText(path);
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
            Boolean gotowy = false;
            int i = 1;
            while (!gotowy)
            {
                if (Directory.Exists(path + nazwaFolderu))
                {
                    nazwaFolderu = nazwaFolderu + i;
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
    }
}
