using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Check_Disk
{
    class Config
    {
        public int LiczbaWatkow { get; set; }
        public int RozmiarPlikow { get; set; }
        public int LiczbaPlikow { get; set; }
        public string Sciezka { get; set; }
        public bool Weryfikacja { get; set; }
        public string Zaznaczenie { get; set; }
    }
}
