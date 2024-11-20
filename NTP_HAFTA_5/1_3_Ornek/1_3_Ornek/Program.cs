using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3_Ornek
{
    class Program
    {
        static void Main(string[] args)
        {
            Departman departman1 = new Departman("Teknik Ekip", "Toplantı Odası");
            Calisan calisan1 = new Calisan("Sena", "Mühendis", departman1) ;

            Console.WriteLine($"Yeni çalışan aramıza katıldı: Ad: {calisan1.Ad}, Pozisyon: {calisan1.Pozisyon}, Departman: {calisan1.Departman.Ad} ({calisan1.Departman.Lokasyon})");
            Console.Read();
        }
    }
    class Departman
    {
        public string Ad { get; set; }
        public string Lokasyon { get; set; }

        public Departman(string ad, string lokasyon)
        {
            Ad = ad;
            Lokasyon = lokasyon;
        } 

    }
    class Calisan
    {
        public string Ad { get; set; }
        public string Pozisyon { get; set; }
        public Departman Departman { get; set;}

        public Calisan(string ad, string pozisyon, Departman departman)
        {
            Ad = ad;
            Pozisyon = pozisyon;
            Departman = departman;
           
        }

        public void DepartmanAtama(Departman departman)
        {
            Departman = departman;

        }
        public override string ToString()
        {
            return $"Ad: {Ad}, Pozisyon: {Pozisyon}, Departman: {Departman.Ad} ({Departman.Lokasyon})";
        }
    }
}
