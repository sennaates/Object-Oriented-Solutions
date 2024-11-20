using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_2_Örnek
{
    class Program
    {
        static void Main(string[] args)
        {
            Kitap kitap1 = new Kitap("Nutuk", "45347837939");
            Yazar yazar1 = new Yazar("Mustafa Kemal Atatürk", "Türkiye");
            yazar1.KitapEkle(new List<Kitap> { kitap1 });
            Console.WriteLine($"Yazar: {yazar1.Ad}, Kitap: ");
            
            

            Console.Read();
        }
    }
    class Kitap
    {
        public string Baslik { get; set; }
        public string Isbn { get; set; }

        public Kitap(string baslik, string isbn)
        {
            Baslik = baslik;
            Isbn = isbn;
        }
        public void KitapEkle()
        {
            Console.WriteLine($"Kitap eklendi: {Baslik}, ISBN: {Isbn}");
        }
    }

    class Yazar
    {
        public string Ad { get; set; }
        public string Ulke { get; set; }
        public List<Kitap> Kitaplar { get; set; }

        public Yazar(string ad, string ulke)
        {
            Ad = ad;
            Ulke = ulke;
            Kitaplar = new List<Kitap>();
        }
        public void KitapEkle(List<Kitap> kitaplar)
        {
            Kitaplar = kitaplar;
            Kitaplar.AddRange(kitaplar);
        }
    }
}
