using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.SoruV2
{
    class Program
    {
        static void Main(string[] args)
        {
            // kullanıcıdan sayıları tutmak için bir liste oluştur
            List<int> sayilar = new List<int>();
            int girdi;

            Console.WriteLine("Pozitif tam sayıları girin (0 ile çıkın):");

            // kullanıcıdan sayılar al
            while (true)
            {
                girdi = Convert.ToInt32(Console.ReadLine());

                // eğer kullanıcı 0 girerse döngüyü kır
                if (girdi == 0)
                    break;

                // girilen sayıyı listeye ekle
                if (girdi > 0) // sadece pozitif tam sayılar al
                {
                    sayilar.Add(girdi);
                }
                else
                {
                    Console.WriteLine("Lütfen pozitif bir tam sayı girin.");
                }
            }

            // eğer hiç sayı girilmediyse uyarı ver
            if (sayilar.Count == 0)
            {
                Console.WriteLine("Hiç pozitif tam sayı girilmedi.");
                return;
            }

            // ortalamayı hesapla
            double ortalama = sayilar.Average();

            // medyanı hesapla
            double medyan = HesaplaMedyan(sayilar);

            // sonuçları ekrana yazdır
            Console.WriteLine($"Ortalama: {ortalama}");
            Console.WriteLine($"Medyan: {medyan}");
            Console.ReadLine();
        }
        
        static double HesaplaMedyan(List<int> sayilar)
        {
            // sayıları sıralıyoruz
            sayilar.Sort();

            int sayiAdedi = sayilar.Count;
            if (sayiAdedi % 2 == 0)
            {
                // çift sayıda eleman varsa, ortadaki iki sayının ortalaması
                double orta1 = sayilar[sayiAdedi / 2 - 1];
                double orta2 = sayilar[sayiAdedi / 2];
                return (orta1 + orta2) / 2;
            }
            else
            {
                // tek sayıda eleman varsa, ortadaki sayı
                return sayilar[sayiAdedi / 2];
            }
        }

    }

}
