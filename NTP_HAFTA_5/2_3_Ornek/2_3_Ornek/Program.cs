using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_3_Ornek
{

   
    public class Yazar
    {
        public string Ad { get; set; }
        public string Ulke { get; set; }
        public List<Kitap> Kitaplar { get; set; } = new List<Kitap>();

        // Kitap ekleme metodu
        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
            kitap.YazarAtama(this); // Kitabın yazarı olarak kendisini atar
            
        }
    }

    // Kitap Sınıfı
    public class Kitap
    {
        public string Baslik { get; set; }
        public DateTime YayinTarihi { get; set; }
        public Yazar Yazar { get; private set; }

        // Yazar atama metodu
        public void YazarAtama(Yazar yazar)
        {
            Yazar = yazar;
            if (!yazar.Kitaplar.Contains(this)) // Tekrar eklenmesini önler
            {
                yazar.Kitaplar.Add(this);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Yazar oluştur
            Yazar yazar1 = new Yazar { Ad = "Orhan Pamuk", Ulke = "Türkiye" };

            // Kitap oluştur
            Kitap kitap1 = new Kitap { Baslik = "Masumiyet Müzesi", YayinTarihi = new DateTime(2008, 8, 1) };
            Kitap kitap2 = new Kitap { Baslik = "Kar", YayinTarihi = new DateTime(2002, 10, 1) };

            // Yazar ile kitapları ilişkilendir
            yazar1.KitapEkle(kitap1);
            yazar1.KitapEkle(kitap2);

            // Ekrana yazdır
            Console.WriteLine($"Yazar: {yazar1.Ad}, Ülke: {yazar1.Ulke}");
            Console.WriteLine("Kitapları:");
            foreach (var kitap in yazar1.Kitaplar)
            {
                Console.WriteLine($"- {kitap.Baslik} ({kitap.YayinTarihi.ToShortDateString()})");
            }

            // Kitabın yazarını kontrol et
            Console.WriteLine($"\nKitap: {kitap1.Baslik}, Yazar: {kitap1.Yazar.Ad}");

            Console.Read();
        }
    }
}

