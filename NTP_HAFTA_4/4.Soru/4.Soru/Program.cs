using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Soru
{
    class Program
    {
        static void Main(string[] args)
        {
            Kisi kisi1 = new Kisi("Enes", "Berat", "5378769065");
            kisi1.KisiBilgisi();
            Console.ReadLine();
        }
    }
    class Kisi
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TelefonNumarasi { get; set; }

        public Kisi(string ad, string soyad, string telefonNumarasi)
        {
            Ad = ad;
            Soyad = soyad;
            TelefonNumarasi = telefonNumarasi;
        }

        public void KisiBilgisi()
        {
            Console.WriteLine("Ad: " + Ad);
            Console.WriteLine("Soyad: " + Soyad);
            Console.WriteLine("Telefon Numarasi: " + TelefonNumarasi);
        }
    }
}
