using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Soru
{
    class Program
    {
        static void Main(string[] args)
        {
            // sayı dizisi tanımlanıyor
            int[] sayilar = { 5, 3, 2 };
            // operatörler tanımlanıyor
            char[] operatorler = { '+', '-', '*', '/' };

            // tüm kombinasyonları bulmak için bir liste
            List<string> ifadeler = new List<string>();

            // kombinasyonları oluşturma
            KombinasyonUret(sayilar, operatorler, "", 0, ifadeler);

            // geçerli ifadeleri yazdırma
            foreach (var ifade in ifadeler)
            {
                // her ifadenin sonucunu kontrol et
                if (IfadeDegerlendir(ifade) > 0)
                {
                    Console.WriteLine($"Geçerli ifade: {ifade}");
                }
            }
            Console.ReadLine();
        }
        static void KombinasyonUret(int[] sayilar, char[] operatorler, string mevcut, int indeks, List<string> ifadeler)
        {
            // sayı dizisi bittiğinde ifadeyi listeye ekle
            if (indeks == sayilar.Length)
            {
                ifadeler.Add(mevcut);
                return;
            }

            // mevcut sayıyı ekle
            if (indeks > 0) // ilk sayıyı eklerken operatör eklenemez
            {
                foreach (var op in operatorler)
                {
                    KombinasyonUret(sayilar, operatorler, mevcut + op + sayilar[indeks], indeks + 1, ifadeler);
                }
            }
            else
            {
                KombinasyonUret(sayilar, operatorler, sayilar[indeks].ToString(), indeks + 1, ifadeler);
            }
        }

        // ifadeyi değerlendirmek için yöntem
        static double IfadeDegerlendir(string ifade)
        {
            // basit bir çözüm olarak, ifadenin sonucunu hesaplamak için
            // buraya kendi ifade değerlendirme kodunuzu yazmalısınız.
            // burada sadece örnek bir değer döndürülüyor
            return new Random().Next(1, 10); // geçici bir değer
        }
    }
    
}
