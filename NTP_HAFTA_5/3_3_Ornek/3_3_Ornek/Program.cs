using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_3_Ornek
{
    public class Calisan
    {
        public string Ad { get; set; }
        public string Pozisyon { get; set; }

        public Calisan(string ad, string pozisyon)
        {
            Ad = ad;
            Pozisyon = pozisyon;
        }

        public void CalisanBilgisi()
        {
            Console.WriteLine($"Çalışan Adı: {Ad}, Pozisyon: {Pozisyon}");
        }
    }

    // Şirket sınıfı
    public class Sirket
    {
        public string Ad { get; set; }
        public List<Calisan> Calisanlar { get; set; }

        public Sirket(string ad)
        {
            Ad = ad;
            Calisanlar = new List<Calisan>();
        }

        public void CalisanEkle(Calisan calisan)
        {
            Calisanlar.Add(calisan);
        }

        public void CalisanlariListele()
        {
            Console.WriteLine($"{Ad} şirketinin çalışanları:");
            foreach (var calisan in Calisanlar)
            {
                calisan.CalisanBilgisi();
            }
        }
    }

    // Test kodu
    class Program
    {
        static void Main(string[] args)
        {
            // Şirket oluştur
            Sirket sirket = new Sirket("ABC Teknoloji");

            // Çalışanlar oluştur
            Calisan calisan1 = new Calisan("Ahmet Yılmaz", "Yazılım Geliştirici");
            Calisan calisan2 = new Calisan("Elif Kaya", "Proje Yöneticisi");

            // Çalışanları şirkete ekle
            sirket.CalisanEkle(calisan1);
            sirket.CalisanEkle(calisan2);

            // Şirketin çalışanlarını listele
            sirket.CalisanlariListele();
            Console.ReadLine();
        }
    }
}
