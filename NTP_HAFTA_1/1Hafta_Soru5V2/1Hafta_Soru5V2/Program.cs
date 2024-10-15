using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Hafta_Soru5V2
{
    class Program
    {
        static void Main()
        {
            // Labirent 0 ve 1'lerden oluşuyor
            int[,] labirent = {
            { 1, 0, 0, 0 },
            { 1, 1, 0, 1 },
            { 0, 1, 1, 1 },
            { 0, 0, 0, 1 }
        };

            // En kısa yolu hesapla
            int sonuc = EnKisaYol(labirent);
            if (sonuc == -1)
            {
                Console.WriteLine("Yol Yok");
            }
            else
            {
                Console.WriteLine("En Kısa Yol: " + sonuc + " adım");
            }
            Console.ReadLine();
        }

        static int EnKisaYol(int[,] labirent)
        {
            int n = labirent.GetLength(0);
            // Hareket yönleri: yukarı, aşağı, sola, sağa
            int[,] hareketYönleri = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

            // BFS için kuyruk
            Queue queueX = new Queue();
            Queue queueY = new Queue();
            Queue queueAdim = new Queue();

            bool[,] ziyaretEdilen = new bool[n, n];

            // Başlangıç noktasını ekle
            queueX.Enqueue(0);
            queueY.Enqueue(0);
            queueAdim.Enqueue(0);
            ziyaretEdilen[0, 0] = true;

            while (queueX.Count > 0)
            {
                int x = (int)queueX.Dequeue();
                int y = (int)queueY.Dequeue();
                int adimSayisi = (int)queueAdim.Dequeue();

                // Hazineye ulaştık mı?
                if (x == n - 1 && y == n - 1)
                {
                    return adimSayisi; // En kısa yol
                }

                // Komşu hücrelere git
                for (int i = 0; i < 4; i++)
                {
                    int yeniX = x + hareketYönleri[i, 0];
                    int yeniY = y + hareketYönleri[i, 1];

                    // Geçerli hücre kontrolü
                    if (GecerliMi(yeniX, yeniY, labirent, ziyaretEdilen))
                    {
                        ziyaretEdilen[yeniX, yeniY] = true; // Ziyaret edildi olarak işaretle
                        queueX.Enqueue(yeniX);
                        queueY.Enqueue(yeniY);
                        queueAdim.Enqueue(adimSayisi + 1); // Kuyruğa ekle
                    }
                }
            }

            return -1; // Hazineye ulaşılamadı
        }

        // Geçerli bir hücre olup olmadığını kontrol eden fonksiyon
        static bool GecerliMi(int x, int y, int[,] labirent, bool[,] ziyaretEdilen)
        {
            return x >= 0 && x < labirent.GetLength(0) &&
                   y >= 0 && y < labirent.GetLength(1) &&
                   labirent[x, y] == 1 &&
                   !ziyaretEdilen[x, y];
        }
    }

}
