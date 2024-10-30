using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Soru
{
    class Program
    {
        static void Main(string[] args)
        {
            // labirent boyutlarını al
            Console.WriteLine("Labirent boyutlarını girin (M N):");
            string[] boyutlar = Console.ReadLine().Split(' ');
            int M = int.Parse(boyutlar[0]);
            int N = int.Parse(boyutlar[1]);

            // labirentteki hücreleri kontrol et
            List<string> yol = YeniYolBul(M, N);

            // yol durumu kontrol et
            if (yol.Count > 0)
            {
                Console.WriteLine("Şehre giden yol:");
                foreach (var adim in yol)
                {
                    Console.WriteLine(adim);
                }
            }
            else
            {
                Console.WriteLine("Şehir kayboldu!");
            }
            static List<string> YeniYolBul(int M, int N)
            {
                // ziyaret edilen hücreleri tutmak için bir dizi
                bool[,] ziyaretEdildi = new bool[M, N];
                List<string> yol = new List<string>();

                // derinlik öncelikli arama ile yolu bul
                if (YoluBul(0, 0, M, N, ziyaretEdildi, yol))
                {
                    return yol;
                }

                return new List<string>(); // yol bulamazsa boş döner
            }

            static bool YoluBul(int x, int y, int M, int N, bool[,] ziyaretEdildi, List<string> yol)
            {
                // geçerli sınırları kontrol et
                if (x < 0 || x >= M || y < 0 || y >= N || ziyaretEdildi[x, y] || !KapiyiAc(x, y))
                {
                    return false;
                }

                // hedefe ulaşıldı mı?
                if (x == M - 1 && y == N - 1)
                {
                    yol.Add($"({x}, {y})");
                    return true;
                }

                // bu hücreyi ziyaret et
                ziyaretEdildi[x, y] = true;
                yol.Add($"({x}, {y})");

                // komşu hücrelere git
                if (YoluBul(x + 1, y, M, N, ziyaretEdildi, yol) || // aşağı
                    YoluBul(x, y + 1, M, N, ziyaretEdildi, yol) || // sağ
                    YoluBul(x + 1, y + 1, M, N, ziyaretEdildi, yol)) // çapraz
                {
                    return true; // yol bulundu
                }

                // geri dön ve bu hücreyi ziyaret edilmemiş olarak işaretle
                ziyaretEdildi[x, y] = false;
                yol.RemoveAt(yol.Count - 1);
                return false; // yol bulunamadı
            }

            static bool KapiyiAc(int x, int y)
            {
                // x ve y asal sayı mı kontrol et
                if (!IsPrime(x) || !IsPrime(y))
                    return false;

                // toplam ve çarpım kontrolü
                int toplam = x + y;
                int carpim = x * y;
                return carpim != 0 && toplam % carpim == 0; // bölünebilir mi?
            }

            static bool IsPrime(int sayi)
            {
                if (sayi <= 1) return false;
                for (int i = 2; i <= Math.Sqrt(sayi); i++)
                {
                    if (sayi % i == 0) return false;
                }
                return true;
            }
        }
    }
}
