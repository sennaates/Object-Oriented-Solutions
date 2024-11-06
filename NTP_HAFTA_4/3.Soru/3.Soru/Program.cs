using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Soru
{
    class Program
    {
        static void Main(string[] args)
        {
            KiralikArac bettle = new KiralikArac("06 SEK 018", 2500);
            bettle.AracKirala();
            bettle.AracTeslimEt();
            Console.Read();
        }
    }
    class KiralikArac
    {
        public string Plaka { get; set; }
        public decimal GunlukUcret { get; set; }
        public bool MusaitMi { get; set; }

        public KiralikArac(string plaka, decimal gunlukUcret)
        {
            Plaka = plaka;
            GunlukUcret = gunlukUcret;
            MusaitMi = true;
        }

        public void AracKirala()
        {
            if (MusaitMi)
            {
                Console.WriteLine(Plaka + "plakali arac kiralandi." + "Gunluk ucreti:" + GunlukUcret);
                MusaitMi = false;
            }
        }
        public void AracTeslimEt()
        {
            if (!MusaitMi)
            {
                Console.WriteLine(Plaka + "arac teslim edidli");
                MusaitMi = true;
            }
        }
    }
}
