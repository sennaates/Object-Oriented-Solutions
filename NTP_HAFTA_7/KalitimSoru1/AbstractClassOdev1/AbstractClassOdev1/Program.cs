using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassOdev1
{
    // Soyut Hesap sınıfı
    public abstract class Hesap
    {
        public string HesapNo { get; set; }
        public decimal Bakiye { get; set; }
        public string HesapSahibi { get; set; }

        // Para yatırma işlemi
        public abstract void ParaYatir(decimal miktar);

        // Para çekme işlemi
        public abstract void ParaCek(decimal miktar);
    }

    // Birikim Hesabı sınıfı, Hesap sınıfından türemektedir
    public class BirikimHesabi : Hesap, IBankaHesabi
    {
        public double FaizOrani { get; set; }
        public DateTime HesapAcilisTarihi { get; set; }

        // Para yatırma metodunda faiz hesaplanır
        public override void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            decimal faiz = miktar * (decimal)(FaizOrani / 100.0);

            Bakiye += faiz;
            Console.WriteLine($"{miktar} TL yatırıldı. Faiz: {faiz} TL. Yeni bakiye: {Bakiye} TL");
        }

        // Para çekme metodunu override ediyoruz
        public override void ParaCek(decimal miktar)
        {
            if (Bakiye >= miktar)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Yeni bakiye: {Bakiye} TL");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye!");
            }
        }

        // Hesap özeti metodunu sağlıyoruz
        public void HesapOzeti()
        {
            Console.WriteLine($"Birikim Hesabı - Hesap No: {HesapNo}, Sahibi: {HesapSahibi}, Bakiye: {Bakiye} TL, Faiz Oranı: {FaizOrani}%, Açılış Tarihi: {HesapAcilisTarihi.ToShortDateString()}");
        }
    }

    // Vadesiz Hesap sınıfı, Hesap sınıfından türemektedir
    public class VadesizHesap : Hesap, IBankaHesabi
    {
        public decimal IslemUcreti { get; set; }
        public DateTime HesapAcilisTarihi { get; set; }

        // Para yatırma işlemi
        public override void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($"{miktar} TL vadesiz hesaba yatırıldı. Yeni bakiye: {Bakiye} TL");
        }

        // Para çekme işlemi, işlem ücreti uygular
        public override void ParaCek(decimal miktar)
        {
            decimal toplamMiktar = miktar + IslemUcreti;
            if (Bakiye >= toplamMiktar)
            {
                Bakiye -= toplamMiktar;
                Console.WriteLine($"{miktar} TL çekildi. İşlem ücreti: {IslemUcreti} TL. Yeni bakiye: {Bakiye} TL");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye!");
            }
        }

        // Hesap özeti metodunu sağlıyoruz
        public void HesapOzeti()
        {
            Console.WriteLine($"Vadesiz Hesap - Hesap No: {HesapNo}, Sahibi: {HesapSahibi}, Bakiye: {Bakiye} TL, İşlem Ücreti: {IslemUcreti} TL, Açılış Tarihi: {HesapAcilisTarihi.ToShortDateString()}");
        }
    }

    // IBankaHesabi arayüzü
    public interface IBankaHesabi
    {
        DateTime HesapAcilisTarihi { get; set; }

        void HesapOzeti();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen hesap türünü seçin (1 - Birikim Hesabı, 2 - Vadesiz Hesap):");
            int secim = Convert.ToInt32(Console.ReadLine());

            // Hesap bilgilerini alıyoruz
            Console.WriteLine("Hesap sahibinin adını girin:");
            string hesapSahibi = Console.ReadLine();
            Console.WriteLine("Hesap numarasını girin:");
            string hesapNumarasi = Console.ReadLine();

            // Seçime göre hesap türünü oluşturuyoruz
            if (secim == 1)
            {
                // Birikim Hesabı oluşturuyoruz
                BirikimHesabi birikimHesabi = new BirikimHesabi
                {
                    HesapSahibi = hesapSahibi,
                    HesapNo = hesapNumarasi,
                    Bakiye = 0, // Başlangıç bakiyesi 0
                    FaizOrani = 5, // Faiz oranı %5
                    HesapAcilisTarihi = DateTime.Now
                };

                // Birikim hesabının bilgilerini yazdırıyoruz
                birikimHesabi.HesapOzeti();

                // Para yatırma işlemi
                Console.WriteLine("Yatırmak istediğiniz miktarı girin:");
                decimal yatirilanMiktar = Convert.ToDecimal(Console.ReadLine());
                birikimHesabi.ParaYatir(yatirilanMiktar);

                // Para çekme işlemi
                Console.WriteLine("Çekmek istediğiniz miktarı girin:");
                decimal cekilenMiktar = Convert.ToDecimal(Console.ReadLine());
                birikimHesabi.ParaCek(cekilenMiktar);
            }
            else if (secim == 2)
            {
                // Vadesiz Hesap oluşturuyoruz
                VadesizHesap vadesizHesap = new VadesizHesap
                {
                    HesapSahibi = hesapSahibi,
                    HesapNo = hesapNumarasi,
                    Bakiye = 0, // Başlangıç bakiyesi 0
                    IslemUcreti = 10, // İşlem ücreti 10 TL
                    HesapAcilisTarihi = DateTime.Now
                };

                // Vadesiz hesabın bilgilerini yazdırıyoruz
                vadesizHesap.HesapOzeti();

                // Para yatırma işlemi
                Console.WriteLine("Yatırmak istediğiniz miktarı girin:");
                decimal yatirilanMiktar = Convert.ToDecimal(Console.ReadLine());
                vadesizHesap.ParaYatir(yatirilanMiktar);

                // Para çekme işlemi
                Console.WriteLine("Çekmek istediğiniz miktarı girin:");
                decimal cekilenMiktar = Convert.ToDecimal(Console.ReadLine());
                vadesizHesap.ParaCek(cekilenMiktar);
            }
            else
            {
                Console.WriteLine("Geçersiz seçim.");
            }
        }
    }
}
