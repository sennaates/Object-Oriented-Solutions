using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Soru
{
    class Program
    {
        static void Main(string[] args)
        {
            // kullanıcıdan şifrelenmiş mesajı al
            Console.WriteLine("Şifrelenmiş mesajı girin:");
            string sifrelenmisMesaj = Console.ReadLine();

            // orijinal mesajı çöz
            string orijinalMesaj = OrijinalMesajiBul(sifrelenmisMesaj);
            Console.WriteLine($"Orijinal mesaj: {orijinalMesaj}");
            Console.ReadLine();

        }
        
        static string OrijinalMesajiBul(string sifrelenmisMesaj)
        {
            // Fibonacci sayıları için liste
            List<int> fibonacci = HesaplaFibonacci(sifrelenmisMesaj.Length);
            char[] orijinalKarakterler = new char[sifrelenmisMesaj.Length];

            // her karakter için işlem yap
            for (int i = 0; i < sifrelenmisMesaj.Length; i++)
            {
                int asciiDegeri = (int)sifrelenmisMesaj[i];

                // pozisyon 1'den başlar
                int pozisyon = i + 1;

                // mod işlemine göre değerleri tersine çevir
                int orijinalAscii = 0;
                if (IsPrime(pozisyon)) // pozisyon asal mı?
                {
                    orijinalAscii = asciiDegeri + 100; // 100 ile bölündüğünde kalan
                }
                else
                {
                    orijinalAscii = asciiDegeri + 256; // 256 ile bölündüğünde kalan
                }

                // ASCII değerini Fibonacci sayısıyla bölerek orijinal karakteri bul
                orijinalKarakterler[i] = (char)(orijinalAscii / fibonacci[i]);
            }

            return new string(orijinalKarakterler);
        }

        static List<int> HesaplaFibonacci(int n)
        {
            List<int> fibonacci = new List<int> { 1, 1 };
            for (int i = 2; i < n; i++)
            {
                fibonacci.Add(fibonacci[i - 1] + fibonacci[i - 2]);
            }
            return fibonacci;
        }

        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
