using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_5_Ornek
{
    class Program
    {
        static void Main(string[] args)
        {
            Siparis siparis1 = new Siparis(now , "İYİ");
            Urun urun1 = new Urun("Sena", "5051808743");
        }
    }
    class Siparis
    {
        public DateTime Tarih { get; set; }
        public string Durum { get; set; }
        public Siparis(DateTime tarih, string durum)
        {
            Tarih = tarih;
            Durum = durum;
        
        }

    }
    class Urun
    {
        public string Ad { get; set; }
        public string Telefon { get; set; }

        public Urun(string ad,string telefon)
        {
            Ad = ad;
            Telefon = telefon;
        }
        public void SiparisVer()
        {

        }
    }
}
