using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_4_Ornek
{
    public class Kitap
    {
        public string Baslik { get; set; }
        public string Yazar { get; set; }

        public Kitap(string baslik, string yazar)
        {
            Baslik = baslik;
            Yazar = yazar;
        }

        public void KitapBilgisi()
        {
            Console.WriteLine($"Kitap Başlığı: {Baslik}, Yazar: {Yazar}");
        }
    }

    // Kütüphane sınıfı
    public class Kutuphane
    {
        public string Ad { get; set; }
        public List<Kitap> Kitaplar { get; set; }

        public Kutuphane(string ad)
        {
            Ad = ad;
            Kitaplar = new List<Kitap>();
        }

        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
        }

        public void KitaplariListele()
        {
            Console.WriteLine($"{Ad} kütüphanesindeki kitaplar:");
            foreach (var kitap in Kitaplar)
            {
                kitap.KitapBilgisi();
            }
        }
    }

    // Test kodu
    class Program
    {
        static void Main(string[] args)
        {
            // Kullanıcıdan kütüphane adı al
            Console.Write("Kütüphane adını giriniz: ");
            string kutuphaneAdi = Console.ReadLine();
            Kutuphane kutuphane = new Kutuphane(kutuphaneAdi);

            while (true)
            {
                Console.WriteLine("\nBir işlem seçin:");
                Console.WriteLine("1. Kitap ekle");
                Console.WriteLine("2. Kitapları listele");
                Console.WriteLine("3. Çıkış");
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    // Kitap bilgilerini al
                    Console.Write("Kitap başlığını giriniz: ");
                    string baslik = Console.ReadLine();

                    Console.Write("Yazar adını giriniz: ");
                    string yazar = Console.ReadLine();

                    // Yeni kitap oluştur ve kütüphaneye ekle
                    Kitap yeniKitap = new Kitap(baslik, yazar);
                    kutuphane.KitapEkle(yeniKitap);

                    Console.WriteLine("Kitap başarıyla eklendi!");
                }
                else if (secim == "2")
                {
                    // Kitapları listele
                    kutuphane.KitaplariListele();
                }
                else if (secim == "3")
                {
                    // Çıkış
                    Console.WriteLine("Programdan çıkılıyor...");
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyiniz.");
                }
                Console.ReadLine();
            }
        }
    }
}
