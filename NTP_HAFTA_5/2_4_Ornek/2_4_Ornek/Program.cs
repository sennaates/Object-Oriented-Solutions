using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_4_Ornek
{
   
    public class Sirket
    {
        public string Ad { get; set; }
        public string Konum { get; set; }
        public List<Calisan> Calisanlar { get; set; } = new List<Calisan>();

        // Çalışan ekleme metodu
        public void CalisanEkle(Calisan calisan)
        {
            Calisanlar.Add(calisan);
            calisan.SirketAtama(this); // Çalışanın şirketi olarak kendisini atar
        }
    }

    // Çalışan Sınıfı
    public class Calisan
    {
        public string Ad { get; set; }
        public DateTime IseGirisTarihi { get; set; }
        public Sirket Sirket { get; private set; }

        // Şirket atama metodu
        public void SirketAtama(Sirket sirket)
        {
            Sirket = sirket;
            if (!sirket.Calisanlar.Contains(this)) // Tekrar eklenmesini önler
            {
                sirket.Calisanlar.Add(this);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Şirket oluştur
            Sirket sirket1 = new Sirket { Ad = "TechSoft", Konum = "İstanbul" };

            // Çalışanlar oluştur
            Calisan calisan1 = new Calisan { Ad = "Ahmet Yılmaz", IseGirisTarihi = new DateTime(2020, 5, 1) };
            Calisan calisan2 = new Calisan { Ad = "Ayşe Kara", IseGirisTarihi = new DateTime(2022, 7, 15) };

            // Şirket ile çalışanları ilişkilendir
            sirket1.CalisanEkle(calisan1);
            sirket1.CalisanEkle(calisan2);

            // Ekrana yazdır
            Console.WriteLine($"Şirket: {sirket1.Ad}, Konum: {sirket1.Konum}");
            Console.WriteLine("Çalışanlar:");
            foreach (var calisan in sirket1.Calisanlar)
            {
                Console.WriteLine($"- {calisan.Ad} (İşe Giriş Tarihi: {calisan.IseGirisTarihi.ToShortDateString()})");
            }

            // Çalışanın şirketini kontrol et
            Console.WriteLine($"\nÇalışan: {calisan1.Ad}, Şirket: {calisan1.Sirket.Ad}");

            Console.ReadLine();
        }
    }
}
