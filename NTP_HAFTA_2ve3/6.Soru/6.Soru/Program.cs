using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Soru
{
    class Program
    {
        static void Main(string[] args)
        {
            // güncel tarihi al
            DateTime simdi = DateTime.Now;
            int baslangicYili = 2000;
            int bitisYili = 3000;

            Console.WriteLine("Geçerli tarihler:");
            for (int yil = baslangicYili; yil <= bitisYili; yil++)
            {
                for (int ay = 1; ay <= 12; ay++)
                {
                    // ayın gün sayısını al
                    int gunSayisi = DateTime.DaysInMonth(yil, ay);
                    for (int gun = 1; gun <= gunSayisi; gun++)
                    {
                        // geçerli tarih oluştur
                        DateTime tarih = new DateTime(yil, ay, gun);

                        // tarih koşullarını kontrol et
                        if (TarihGecerlidir(gun, ay, yil) && tarih > simdi)
                        {
                            Console.WriteLine($"{gun:00}/{ay:00}/{yil}");
                        }
                    }
                }
                Console.ReadLine();
            }
            bool TarihGecerlidir(int gun, int ay, int yil)
            {
                // gün asal mı kontrol et
                if (!IsPrime(gun))
                    return false;

                // ayın basamaklarının toplamı çift mi kontrol et
                if (!IsEvenSumOfDigits(ay))
                    return false;

                // yılın rakamları toplamı, yılın dörtte birinden küçük mü kontrol et
                if (!IsLessThanQuarterOfYear(yil))
                    return false;

                return true; // tüm koşullar sağlandı
            }

            bool IsPrime(int sayi)
            {
                if (sayi <= 1) return false;
                for (int i = 2; i <= Math.Sqrt(sayi); i++)
                {
                    if (sayi % i == 0) return false;
                }
                return true;
            }

            bool IsEvenSumOfDigits(int sayi)
            {
                int toplam = 0;
                while (sayi > 0)
                {
                    toplam += sayi % 10;
                    sayi /= 10;
                }
                return toplam % 2 == 0; // toplam çift mi?
            }

            bool IsLessThanQuarterOfYear(int yil)
            {
                int rakamlarToplami = 0;
                while (yil > 0)
                {
                    rakamlarToplami += yil % 10;
                    yil /= 10;
                }
                return rakamlarToplami < (yil * 4); // rakamlar toplamı, yılın dörtte birinden küçük mü?
            }
        }
    }
    
}
