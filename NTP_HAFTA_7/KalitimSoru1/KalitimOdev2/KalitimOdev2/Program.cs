using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalitimOdev2
{
    // Temel Hayvan sınıfı
    public class Hayvan
    {
        public string Ad { get; set; }
        public string Tur { get; set; }
        public int Yas { get; set; }

        // SesCikar metodunun temel hali
        public virtual void SesCikar()
        {
            Console.WriteLine("Bu hayvan ses çıkarmıyor.");
        }

        // Hayvan bilgilerini yazdıran metod
        public void BilgiYazdir()
        {
            Console.WriteLine($"Ad: {Ad} | Tür: {Tur} | Yaş: {Yas}");
        }
    }

    // Memeli sınıfı, Hayvan sınıfından türemektedir
    public class Memeli : Hayvan
    {
        public string TuyRengi { get; set; }

        // SesCikar metodunu override ediyoruz
        public override void SesCikar()
        {
            Console.WriteLine("Memeli hayvan gürültü yapıyor: Grrrr!");
        }

        // Memelinin bilgilerini yazdırma
        public void MemeliBilgileriniYazdir()
        {
            BilgiYazdir();
            Console.WriteLine($"Tüy Rengi: {TuyRengi}");
        }
    }

    // Kus sınıfı, Hayvan sınıfından türemektedir
    public class Kus : Hayvan
    {
        public double KanatGenisligi { get; set; }

        // SesCikar metodunu override ediyoruz
        public override void SesCikar()
        {
            Console.WriteLine("Kuş cıvıldıyor: Cıv cıv!");
        }

        // Kuşun bilgilerini yazdırma
        public void KusBilgileriniYazdir()
        {
            BilgiYazdir();
            Console.WriteLine($"Kanat Genişliği: {KanatGenisligi} cm");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Kullanıcıdan hayvan türünü seçmesini istiyoruz
            Console.WriteLine("Lütfen hayvan türünü seçin (1 - Memeli, 2 - Kuş):");
            int secim = Convert.ToInt32(Console.ReadLine());

            // Hayvan bilgilerini alıyoruz
            Console.WriteLine("Adınızı girin:");
            string ad = Console.ReadLine();
            Console.WriteLine("Türünü girin:");
            string tur = Console.ReadLine();
            Console.WriteLine("Yaşını girin:");
            int yas = Convert.ToInt32(Console.ReadLine());

            // Seçime göre hayvan türünü oluşturuyoruz
            if (secim == 1)
            {
                // Memeli hayvanı oluşturuyoruz
                Memeli memeli = new Memeli
                {
                    Ad = ad,
                    Tur = tur,
                    Yas = yas
                };

                Console.WriteLine("Tüy rengini girin:");
                memeli.TuyRengi = Console.ReadLine();

                // Memelinin bilgilerini yazdırıyoruz
                memeli.MemeliBilgileriniYazdir();

                // Memeli hayvanın sesini çıkarıyoruz
                memeli.SesCikar();
            }
            else if (secim == 2)
            {
                // Kuş hayvanını oluşturuyoruz
                Kus kus = new Kus
                {
                    Ad = ad,
                    Tur = tur,
                    Yas = yas
                };

                Console.WriteLine("Kanat genişliğini cm cinsinden girin:");
                kus.KanatGenisligi = Convert.ToDouble(Console.ReadLine());

                // Kuşun bilgilerini yazdırıyoruz
                kus.KusBilgileriniYazdir();

                // Kuşun sesini çıkarıyoruz
                kus.SesCikar();
            }
            else
            {
                Console.WriteLine("Geçersiz seçim.");
            }
            Console.Read();
        }
    }
    

}
