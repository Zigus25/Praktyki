using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Check_Disk
{
    public class Logika
    {
        string DomyslnaSciezka = Directory.GetCurrentDirectory();
        Task taskJob;
        static string ConfigFileDirectory = Directory.GetCurrentDirectory() + @"\config.txt";
        string czytaj = "";

        public Kontrolki PreDefiniowanyTest()
        {
            double wynikZapis = 0.0;
            double wynikOdczyt = 0.0;
            bool mozna = false;
            if (SprawdzMiejsceNaDysku(CalcMBToB(100 * (Environment.ProcessorCount * 3)), DomyslnaSciezka))
            {
                string popr;
                try
                {
                    DomyslnaSciezka = CreateFolder(DomyslnaSciezka);
                    if (SprawdzPoprawnosc(DomyslnaSciezka))
                    {
                        popr = "Pliki są zapisywane poprawnie";
                    }
                    else
                    {
                        popr = "Pliki nie są zapisywane poprawnie";
                    }
                    mozna = true;
                }
                catch (Exception e)
                {
                    return new Kontrolki { bledy = e };
                }
                if (mozna)
                {
                    for (int j = 0; j < Environment.ProcessorCount; j++)
                    {
                        try
                        {
                            taskJob = Task.Factory.StartNew(() => {
                                double wynikteraz = WriteTest(CalcMBToB(100), DomyslnaSciezka + @"\testowyplik" + j);
                                wynikZapis += wynikteraz;
                            });
                        }
                        catch (Exception e)
                        {
                            return new Kontrolki { bledy = e };
                        }
                    }
                    for (int j = 0; j < Environment.ProcessorCount; j++)
                    {
                        try
                        {
                            taskJob = Task.Factory.StartNew(() => {
                                double wynikterazOdczyt = ReadTest(czytaj);
                                wynikOdczyt += wynikterazOdczyt;
                            });
                        }
                        catch (Exception e)
                        {
                            return new Kontrolki { bledy = e };
                        }
                    }
                    Task.WaitAll(taskJob);

                    try
                    {
                        DeleteTestFileFolder(DomyslnaSciezka);
                    }
                    catch (Exception e)
                    {
                        return new Kontrolki { bledy = e };
                    }


                    return new Kontrolki
                    {
                        TextWeryfikacji = popr,
                        ZapisText = $@"Zapis: {Math.Round(wynikZapis / Environment.ProcessorCount, 2)}MB\s",
                        kopia = $@"Zapis: {Math.Round(wynikZapis / Environment.ProcessorCount, 2)}MB\s Odczyt: {Math.Round(wynikOdczyt / Environment.ProcessorCount, 2)}MB\s",
                        OdczytText = $@"Odczyt: {Math.Round(wynikOdczyt / Environment.ProcessorCount, 2)}MB\s"
                    };
                }
                else
                {
                    return new Kontrolki { PojemnikBledow = "Nie mozna bylo stworzyc sciezki do testu" };
                }
            }
            else
            {
                return new Kontrolki{ PojemnikBledow = "Brak wystarczającego miejsca na dysku" };
            }
        }

        public Kontrolki TestZapisOdczyt(int nWL, int LPlikow, int Rozmiar, string sciezka, bool wer)
        {
            double wynikZapis = 0.0;
            double wynikOdczyt = 0.0;
            bool mozna = false;
            string popr = "";
            string Sciezka = sciezka;
            try
            {
                Sciezka = CreateFolder(Sciezka);
                mozna = true;
            }
            catch (Exception e)
            {
                return new Kontrolki { bledy = e };
            }
            if (mozna)
            {
                if (wer)
                {
                    try
                    {
                        if (SprawdzPoprawnosc(Sciezka))
                        {
                            popr = "Pliki są zapisywane poprawnie";
                        }
                        else
                        {
                            popr = "Pliki nie są zapisywane poprawnie";
                        }
                    }
                    catch (Exception e)
                    {
                        return new Kontrolki { bledy = e };
                    }
                }
                for (int j = 0; j < Environment.ProcessorCount; j++)
                {
                    try
                    {
                        taskJob = Task.Factory.StartNew(() => {
                            double wynikteraz = WriteTest(CalcMBToB(100), Sciezka + @"\testowyplik" + j);
                            wynikZapis += wynikteraz;
                        });
                    }
                    catch (Exception e)
                    {
                        return new Kontrolki { bledy = e };
                    }
                }
                Task.WaitAll(taskJob);
                try
                {
                    taskJob = Task.Factory.StartNew(() => {
                        double wynikterazOdczyt = ReadTest(czytaj);
                        wynikOdczyt += wynikterazOdczyt;
                    });
                }
                catch (Exception e)
                {
                    return new Kontrolki { bledy = e };
                }
                Task.WaitAll(taskJob);

                try
                {
                    DeleteTestFileFolder(Sciezka);
                }
                catch (Exception e)
                {
                    return new Kontrolki { bledy = e };
                }

                return new Kontrolki
                {
                    kopia = $@"Zapis: {Math.Round(wynikZapis / nWL, 2)}MB\s Odczyt: {Math.Round(wynikOdczyt / nWL, 2)}MB\s",
                    ZapisText = $@"Zapis: {Math.Round(wynikZapis / nWL, 2)}MB\s",
                    OdczytText = $@"Odczyt: {Math.Round(wynikOdczyt / nWL, 2)}MB\s"
                };
            }
            else
            {
                return new Kontrolki{ PojemnikBledow = "Nie można utworzyć folderu testowego" };
            }
        }

        public Kontrolki TestZapisu(int nWL, int LPlikow, int Rozmiar , string sciezka , bool wer)
        {
            double wynikZapis = 0.0;
            bool mozna = false;
            string Sciezka = sciezka;
            string popr = "";
            try
            {
                Sciezka = CreateFolder(Sciezka);
                mozna = true;
            }
            catch (Exception e)
            {
                return new Kontrolki { bledy = e };
            }
            if (mozna)
            {
                if (wer)
                {
                    try
                    {
                        if (SprawdzPoprawnosc(Sciezka))
                        {
                            popr = "Pliki są zapisywane poprawnie";
                        }
                        else
                        {
                            popr = "Pliki nie są zapisywane poprawnie";
                        }
                    }
                    catch (Exception e)
                    {
                        return new Kontrolki { bledy = e };
                    }
                }
                for (int i = 0; i < LPlikow; i++)
                {
                    for (int j = 0; j < nWL / LPlikow; j++)
                    {
                        try
                        {
                            taskJob = Task.Factory.StartNew(() => {
                                double wynikteraz = WriteTest(CalcMBToB(Convert.ToInt32(Rozmiar)), Sciezka + @"\testowyplik" + j);
                                wynikZapis += wynikteraz;
                            });
                        }
                        catch (Exception e)
                        {
                            return new Kontrolki { bledy = e };
                        }
                    }
                }
                Task.WaitAll(taskJob);
                try
                {
                    DeleteTestFileFolder(Sciezka);
                }
                catch (Exception e)
                {
                    return new Kontrolki { bledy = e };
                }
                return new Kontrolki
                {
                    TextWeryfikacji = popr,
                    kopia = $@"Zapis: {Math.Round(wynikZapis / (nWL / LPlikow), 2)}MB\s",
                    ZapisText = $@"Zapis: {Math.Round(wynikZapis / (nWL / LPlikow), 2)}MB\s"
                };
            }
            else
            {
                return new Kontrolki { PojemnikBledow = "Nie można utworzyć folderu testowego" };
            }
        }

        public Kontrolki TestOdczytu(int nWL, string sciezka)
        {
            double wynikOdczyt = 0.0;
            for (int j = 0; j < nWL; j++)
            {
                try
                {
                    taskJob = Task.Factory.StartNew(() => {
                        double wynikterazOdczyt = ReadTest(sciezka);
                        wynikOdczyt += wynikterazOdczyt;
                    });
                }
                catch (Exception e)
                {
                    return new Kontrolki { bledy = e };
                }
            }
            Task.WaitAll(taskJob);
            return new Kontrolki
            {
                OdczytText = $@"Odczyt: {Math.Round(wynikOdczyt / nWL, 2)}MB\s",
                kopia = $@"Odczyt: {Math.Round(wynikOdczyt / nWL, 2)}MB\s"
            };
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

        public Config WczytajConfig()
        {
            if (File.Exists(ConfigFileDirectory))
            {
                StreamReader sr = new StreamReader(ConfigFileDirectory);
                string line = sr.ReadLine();
                Config config = JsonConvert.DeserializeObject<Config>(line);
                sr.Close();
                return config;
            }
            else
            {
                return null;
            }
        }

        public void zapiszConfig(Config config)
        {
            File.WriteAllText(ConfigFileDirectory, JsonConvert.SerializeObject(config));
        }

        public double WriteTest(int whatSizeFile, string path)
        {
            Random random = new Random();
            int bytes = whatSizeFile;
            double wyniki = 0.0;
           
            for (int i = 0; i < 3; i++)
            {
                var bity = new byte[bytes];
                random.NextBytes(bity);
                string curPath = $@"{path}{Guid.NewGuid()}.txt";
                if(czytaj == "")
                {
                    czytaj = curPath;
                }
                var watch = System.Diagnostics.Stopwatch.StartNew();
                File.WriteAllBytes(curPath, bity);
                watch.Stop();
                double elapsedMs = watch.ElapsedMilliseconds;
                double wynik = (CalcBToMB(bytes) / Math.Round(elapsedMs / 1000,3));
                wyniki += wynik;
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
                File.ReadAllBytes(path);
                watch.Stop();
                double elapsedMs = watch.ElapsedMilliseconds;
                double wynik = rozmiar / Math.Round(elapsedMs / 1000, 3);
                wyniki += wynik;
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

        public bool SprawdzPoprawnosc(string path)
        {
            Random random = new Random();
            var bity = new byte[CalcMBToB(500)];
            random.NextBytes(bity);
            File.WriteAllBytes($@"{path}\PlikZgodnosci.txt", bity);

            if (File.ReadAllBytes($@"{path}\PlikZgodnosci.txt").ToString().Contains(bity.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
