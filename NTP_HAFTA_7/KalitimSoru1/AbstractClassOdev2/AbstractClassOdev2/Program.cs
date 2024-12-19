using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassOdev2
{
    // Soyut Urun sınıfı
    public abstract class Urun
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }

        // Her ürüne özel ödeme hesaplamasını soyut metodla tanımlıyoruz
        public abstract decimal HesaplaOdeme();

        // Ürün bilgilerini yazdıran metot
        public abstract void BilgiYazdir();
    }

    // Kitap sınıfı, Urun sınıfından türemektedir
    public class Kitap : Urun
    {
        public string Yazar { get; set; }

        // Kitap için ödeme hesaplaması (Fiyat + %10 vergi)
        public override decimal HesaplaOdeme()
        {
            decimal vergi = Fiyat * 0.10m;
            return Fiyat + vergi;
        }

        // Kitap bilgilerini yazdırma
        public override void BilgiYazdir()
        {
            Console.WriteLine($"Kitap: {Ad}, Yazar: {Yazar}, Fiyat: {Fiyat} TL, Ödenecek Tutar: {HesaplaOdeme()} TL");
        }
    }

    // Elektronik sınıfı, Urun sınıfından türemektedir
    public class Elektronik : Urun
    {
        public string Marka { get; set; }

        // Elektronik ürün için ödeme hesaplaması (Fiyat + %25 vergi)
        public override decimal HesaplaOdeme()
        {
            decimal vergi = Fiyat * 0.25m;
            return Fiyat + vergi;
        }

        // Elektronik ürün bilgilerini yazdırma
        public override void BilgiYazdir()
        {
            Console.WriteLine($"Elektronik Ürün: {Ad}, Marka: {Marka}, Fiyat: {Fiyat} TL, Ödenecek Tutar: {HesaplaOdeme()} TL");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            // Urun türlerini içeren bir liste oluşturuyoruz
            List<Urun> urunler = new List<Urun>();

            // Kitap ve Elektronik ürünleri listeye ekliyoruz
            Kitap kitap1 = new Kitap { Ad = "C# Programlama", Fiyat = 50.00m, Yazar = "Ahmet Yılmaz" };
            Elektronik elektronik1 = new Elektronik { Ad = "Telefon", Fiyat = 1500.00m, Marka = "Samsung" };

            urunler.Add(kitap1);
            urunler.Add(elektronik1);

            // Listeyi gezerek her ürünün bilgilerini ve ödenecek tutarı yazdırıyoruz
            foreach (var urun in urunler)
            {
                urun.BilgiYazdir();
            }
        }
    }
    
}
