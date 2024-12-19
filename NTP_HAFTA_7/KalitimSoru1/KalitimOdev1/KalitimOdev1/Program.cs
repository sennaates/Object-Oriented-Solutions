using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalitimOdev1
{
    // Temel Calisan sınıfı
    public class Calisan
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public decimal Maas { get; set; }
        public string Pozisyon { get; set; }

        // BilgiYazdir metodunun temel hali
        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Ad: {Ad} | Soyad: {Soyad} | Maaş: {Maas} | Pozisyon: {Pozisyon}");
        }
    }

    // Yazilimci sınıfı, Calisan'dan türemektedir
    public class Yazilimci : Calisan
    {
        public string YazilimDili { get; set; }

        // BilgiYazdir metodunu override ediyoruz
        public override void BilgiYazdir()
        {
            Console.WriteLine($"Ad: {Ad} | Soyad: {Soyad} | Maaş: {Maas} | Pozisyon: {Pozisyon} | Yazılım Dili: {YazilimDili}");
        }
    }

    // Muhasebeci sınıfı, Calisan'dan türemektedir
    public class Muhasebeci : Calisan
    {
        public string MuhasebeYazilimi { get; set; }

        // BilgiYazdir metodunu override ediyoruz
        public override void BilgiYazdir()
        {
            Console.WriteLine($"Ad: {Ad} | Soyad: {Soyad} | Maaş: {Maas} | Pozisyon: {Pozisyon} | Muhasebe Yazılımı: {MuhasebeYazilimi}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Kullanıcıdan çalışan türünü seçmesini istiyoruz
            Console.WriteLine("Lütfen çalışan türünü seçin (1 - Yazilimci, 2 - Muhasebeci):");
            int secim = Convert.ToInt32(Console.ReadLine());

            // Çalışan bilgilerini alıyoruz
            Console.WriteLine("Adınızı girin:");
            string ad = Console.ReadLine();
            Console.WriteLine("Soyadınızı girin:");
            string soyad = Console.ReadLine();
            Console.WriteLine("Maaşınızı girin:");
            decimal maas = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Pozisyonunuzu girin:");
            string pozisyon = Console.ReadLine();

            // Seçime göre çalışan türünü oluşturuyoruz
            if (secim == 1)
            {
                // Yazilimci bilgilerini alıyoruz
                Yazilimci yazilimci = new Yazilimci
                {
                    Ad = ad,
                    Soyad = soyad,
                    Maas = maas,
                    Pozisyon = pozisyon
                };

                Console.WriteLine("Yazılım dili bilgisi girin:");
                yazilimci.YazilimDili = Console.ReadLine();

                // Yazılımcının bilgilerini yazdırıyoruz
                yazilimci.BilgiYazdir();
            }
            else if (secim == 2)
            {
                // Muhasebeci bilgilerini alıyoruz
                Muhasebeci muhasebeci = new Muhasebeci
                {
                    Ad = ad,
                    Soyad = soyad,
                    Maas = maas,
                    Pozisyon = pozisyon
                };

                Console.WriteLine("Muhasebe yazılımı bilgisi girin:");
                muhasebeci.MuhasebeYazilimi = Console.ReadLine();

                // Muhasebecinin bilgilerini yazdırıyoruz
                muhasebeci.BilgiYazdir();
            }
            else
            {
                Console.WriteLine("Geçersiz seçim.");
            }
            Console.Read();
        }
    }
    
}
