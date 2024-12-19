using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalitimOdev3
{
    // Temel Hesap sınıfı
    public class Hesap
    {
        public string HesapNumarasi { get; set; }
        public decimal Bakiye { get; set; }
        public string HesapSahibi { get; set; }

        // Hesap bilgilerini yazdıran metod
        public void BilgiYazdir()
        {
            Console.WriteLine($"Hesap Sahibi: {HesapSahibi} | Hesap Numarası: {HesapNumarasi} | Bakiye: {Bakiye} TL");
        }

        // Para yatırma metodunun temel hali
        public virtual void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($"{miktar} TL yatırıldı. Yeni bakiye: {Bakiye} TL");
        }

        // Para çekme metodunun temel hali
        public virtual void ParaCek(decimal miktar)
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
    }

    // Vadesiz Hesap sınıfı, Hesap sınıfından türemektedir
    public class VadesizHesap : Hesap
    {
        public decimal EkHesapLimiti { get; set; }

        // Para yatırma metodunu override ediyoruz
        public override void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($"{miktar} TL vadesiz hesaba yatırıldı. Yeni bakiye: {Bakiye} TL");
        }

        // Para çekme metodunu override ediyoruz
        public override void ParaCek(decimal miktar)
        {
            if (Bakiye + EkHesapLimiti >= miktar)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Yeni bakiye: {Bakiye} TL");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye ve ek hesap limiti!");
            }
        }
    }

    // Vadeli Hesap sınıfı, Hesap sınıfından türemektedir
    public class VadeliHesap : Hesap
    {
        public DateTime VadeTarihi { get; set; }
        public double FaizOrani { get; set; }

        // Para yatırma metodunu override ediyoruz
        public override void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($"{miktar} TL vadeli hesaba yatırıldı. Yeni bakiye: {Bakiye} TL");
        }

        // Para çekme metodunu override ediyoruz
        public override void ParaCek(decimal miktar)
        {
            if (DateTime.Now < VadeTarihi)
            {
                Console.WriteLine("Vade dolmadan para çekilemez!");
            }
            else
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
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Kullanıcıdan hesap türünü seçmesini istiyoruz
            Console.WriteLine("Lütfen hesap türünü seçin (1 - Vadesiz Hesap, 2 - Vadeli Hesap):");
            int secim = Convert.ToInt32(Console.ReadLine());

            // Hesap bilgilerini alıyoruz
            Console.WriteLine("Hesap sahibinin adını girin:");
            string hesapSahibi = Console.ReadLine();
            Console.WriteLine("Hesap numarasını girin:");
            string hesapNumarasi = Console.ReadLine();

            // Seçime göre hesap türünü oluşturuyoruz
            if (secim == 1)
            {
                // Vadesiz hesap oluşturuyoruz
                VadesizHesap vadesizHesap = new VadesizHesap
                {
                    HesapSahibi = hesapSahibi,
                    HesapNumarasi = hesapNumarasi,
                    Bakiye = 0 // Başlangıç bakiyesi 0
                };

                Console.WriteLine("Ek hesap limiti girin:");
                vadesizHesap.EkHesapLimiti = Convert.ToDecimal(Console.ReadLine());

                // Vadesiz hesabın bilgilerini yazdırıyoruz
                vadesizHesap.BilgiYazdir();

                // Para yatırma işlemi
                Console.WriteLine("Yatırmak istediğiniz miktarı girin:");
                decimal yatirilanMiktar = Convert.ToDecimal(Console.ReadLine());
                vadesizHesap.ParaYatir(yatirilanMiktar);

                // Para çekme işlemi
                Console.WriteLine("Çekmek istediğiniz miktarı girin:");
                decimal cekilenMiktar = Convert.ToDecimal(Console.ReadLine());
                vadesizHesap.ParaCek(cekilenMiktar);
            }
            else if (secim == 2)
            {
                // Vadeli hesap oluşturuyoruz
                VadeliHesap vadeliHesap = new VadeliHesap
                {
                    HesapSahibi = hesapSahibi,
                    HesapNumarasi = hesapNumarasi,
                    Bakiye = 0 // Başlangıç bakiyesi 0
                };

                Console.WriteLine("Vade tarihini (yyyy-MM-dd) formatında girin:");
                vadeliHesap.VadeTarihi = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Faiz oranını (%) girin:");
                vadeliHesap.FaizOrani = Convert.ToDouble(Console.ReadLine());

                // Vadeli hesabın bilgilerini yazdırıyoruz
                vadeliHesap.BilgiYazdir();

                // Para yatırma işlemi
                Console.WriteLine("Yatırmak istediğiniz miktarı girin:");
                decimal yatirilanMiktar = Convert.ToDecimal(Console.ReadLine());
                vadeliHesap.ParaYatir(yatirilanMiktar);

                // Para çekme işlemi
                Console.WriteLine("Çekmek istediğiniz miktarı girin:");
                decimal cekilenMiktar = Convert.ToDecimal(Console.ReadLine());
                vadeliHesap.ParaCek(cekilenMiktar);
            }
            else
            {
                Console.WriteLine("Geçersiz seçim.");
            }
        }
    }
    
}
