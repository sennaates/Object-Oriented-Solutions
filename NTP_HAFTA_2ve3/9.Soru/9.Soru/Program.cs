using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Soru
{
    class Program
    {
        static void Main(string[] args)
        {
            // kullanıcıdan matris boyutunu al
            Console.WriteLine("Matris boyutunu girin (N):");
            int N = int.Parse(Console.ReadLine());

            // enerji maliyet matrisini tanımla
            int[,] enerjiMaliyeti = new int[N, N];

            // kullanıcıdan enerji maliyetlerini al
            Console.WriteLine("Enerji maliyetlerini girin (her satır için, sayıları boşlukla ayırarak):");
            for (int i = 0; i < N; i++)
            {
                string[] girdiler = Console.ReadLine().Split(' ');
                for (int j = 0; j < N; j++)
                {
                    enerjiMaliyeti[i, j] = int.Parse(girdiler[j]);
                }
            }

            // en az enerji harcayan yolu bul
            int sonuc = EnAzEnerjiHesapla(enerjiMaliyeti, N);
            Console.WriteLine($"(0, 0) noktasından (N-1, N-1) noktasına kadar en az enerji: {sonuc}");
        }
        static int EnAzEnerjiHesapla(int[,] enerjiMaliyeti, int N)
        {
            // dinamik programlama matrisi
            int[,] dp = new int[N, N];

            // başlangıç noktasının enerji maliyetini al
            dp[0, 0] = enerjiMaliyeti[0, 0];

            // ilk satırı doldur
            for (int i = 1; i < N; i++)
            {
                dp[0, i] = dp[0, i - 1] + enerjiMaliyeti[0, i];
            }

            // ilk sütunu doldur
            for (int i = 1; i < N; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + enerjiMaliyeti[i, 0];
            }

            // dinamik programlama ile diğer hücreleri doldur
            for (int i = 1; i < N; i++)
            {
                for (int j = 1; j < N; j++)
                {
                    // sağdan, yukarıdan veya çaprazdan gelen en az enerji
                    dp[i, j] = enerjiMaliyeti[i, j] + Math.Min(dp[i - 1, j], Math.Min(dp[i, j - 1], dp[i - 1, j - 1]));
                }
            }

            // (N-1, N-1) noktasındaki en az enerji maliyeti
            return dp[N - 1, N - 1];
        }

    }
}

