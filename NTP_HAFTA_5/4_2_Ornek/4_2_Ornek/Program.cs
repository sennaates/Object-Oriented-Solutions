using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_2_Ornek
{
    public class Islemci
    {
        public int Cekirdekler { get; set; }
        public int Frekans { get; set; } // MHz olarak frekans

        public Islemci(int cekirdekler, int frekans)
        {
            Cekirdekler = cekirdekler;
            Frekans = frekans;
        }

        public void IslemciBilgisi()
        {
            Console.WriteLine($"İşlemci: {Cekirdekler} çekirdek, {Frekans} MHz");
        }
    }

    // Bilgisayar sınıfı
    public class Bilgisayar
    {
        public string Model { get; set; }
        public Islemci Islemci { get; set; }

        public Bilgisayar(string model)
        {
            Model = model;
        }

        public void IslemciOlustur(int cekirdekler, int frekans)
        {
            Islemci = new Islemci(cekirdekler, frekans);
        }

        public void BilgisayarBilgisi()
        {
            Console.WriteLine($"Bilgisayar Modeli: {Model}");
            if (Islemci != null)
            {
                Islemci.IslemciBilgisi();
            }
            else
            {
                Console.WriteLine("İşlemci bilgisi yok.");
            }
        }
    }

    // Test kodu
    class Program
    {
        static void Main(string[] args)
        {
            // Kullanıcıdan bilgisayar modeli al
            Console.Write("Bilgisayar modelini giriniz: ");
            string model = Console.ReadLine();

            // Bilgisayar nesnesi oluştur
            Bilgisayar bilgisayar = new Bilgisayar(model);

            Console.Write("İşlemci çekirdek sayısını giriniz: ");
            int cekirdekler = int.Parse(Console.ReadLine());

            Console.Write("İşlemci frekansını (MHz) giriniz: ");
            int frekans = int.Parse(Console.ReadLine());

            // İşlemci oluştur ve bilgisayara ata
            bilgisayar.IslemciOlustur(cekirdekler, frekans);

            // Bilgisayar ve işlemci bilgilerini yazdır
            Console.WriteLine("\nBilgisayar ve İşlemci Bilgisi:");
            bilgisayar.BilgisayarBilgisi();
        }
    }
}
