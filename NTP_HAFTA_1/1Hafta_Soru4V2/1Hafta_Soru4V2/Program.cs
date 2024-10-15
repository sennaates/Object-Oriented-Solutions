using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Hafta_Soru4V2
{
    class Program
    {
        static void Main()
        {
            // Düğüm durumu grid'i
            int[,] grid = {
                { 1, 1, 0, 1 },
                { 0, 1, 0, 0 },
                { 1, 1, 1, 0 },
                { 0, 0, 1, 1 }
            };

            // Robotların başlangıç pozisyonları
            int[,] baslangicPozisyonlari = {
                { 0, 0 },
                { 2, 2 },
                { 3, 3 }
            };

            // Toplam kurtarılan düğüm sayısını hesapla
            int sonuc = DugumSayisiniHesapla(grid, baslangicPozisyonlari);
            Console.WriteLine("Kurtarilan dugum sayisi: " + sonuc);
            Console.ReadLine();
        }

        // Geçerli bir düğüm olup olmadığını kontrol eden fonksiyon
        static bool GecerliMi(int x, int y, int[,] grid)
        {
            return x >= 0 && x < grid.GetLength(0) && y >= 0 && y < grid.GetLength(1) && grid[x, y] == 1;
        }

        // Derinlik öncelikli arama fonksiyonu
        static int DerinlikOncelikliAra(int x, int y, int[,] grid, bool[,] ziyaretEdilen)
        {
            // Geçerli değilse veya daha önce ziyaret edildiyse döndür
            if (!GecerliMi(x, y, grid) || ziyaretEdilen[x, y]) return 0;

            // Düğümü ziyaret ettik
            ziyaretEdilen[x, y] = true;
            int sayac = 1; // Bu dugumu kurtardik

            // Komşu hücrelere git
            sayac += DerinlikOncelikliAra(x - 1, y, grid, ziyaretEdilen); // Yukarı
            sayac += DerinlikOncelikliAra(x + 1, y, grid, ziyaretEdilen); // Aşağı
            sayac += DerinlikOncelikliAra(x, y - 1, grid, ziyaretEdilen); // Sol
            sayac += DerinlikOncelikliAra(x, y + 1, grid, ziyaretEdilen); // Sağ

            return sayac; // Toplam kurtarılan düğüm sayısını döndür
        }

        // Tüm robotların kurtardığı düğüm sayısını hesaplayan fonksiyon
        static int DugumSayisiniHesapla(int[,] grid, int[,] baslangicPozisyonlari)
        {
            // Ziyaret edilen düğümleri takip etmek için boolean dizisi
            bool[,] ziyaretEdilen = new bool[grid.GetLength(0), grid.GetLength(1)];
            int toplamKurtarilan = 0; // Toplam kurtarılan düğüm sayısı

            // Her robotun başlangıç pozisyonu için derinlik öncelikli arama yap
            for (int i = 0; i < baslangicPozisyonlari.GetLength(0); i++)
            {
                int x = baslangicPozisyonlari[i, 0];
                int y = baslangicPozisyonlari[i, 1];
                toplamKurtarilan += DerinlikOncelikliAra(x, y, grid, ziyaretEdilen);
            }

            return toplamKurtarilan; // Toplam kurtarılan düğüm sayısını döndür
        }

    }
}
