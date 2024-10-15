using System;

class Program
{
    static void Main()
    {
        // matris boyutunu kullanıcıdan al
        Console.Write("matris boyutu (N): ");
        int n = int.Parse(Console.ReadLine()); // kullanıcıdan matris boyutunu al

        // iki matris oluştur
        int[,] matris1 = new int[n, n]; // birinci matris
        int[,] matris2 = new int[n, n]; // ikinci matris
        int[,] sonuc = new int[n, n]; // sonuç matris

        // birinci matrisin elemanlarını al
        Console.WriteLine("birinci matrisin elemanlarını girin:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"matris1[{i},{j}]: ");
                matris1[i, j] = int.Parse(Console.ReadLine()); // elemanı al
            }
        }

        // ikinci matrisin elemanlarını al
        Console.WriteLine("ikinci matrisin elemanlarını girin:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"matris2[{i},{j}]: ");
                matris2[i, j] = int.Parse(Console.ReadLine()); // elemanı al
            }
        }

        // matris çarpımı işlemi
        for (int i = 0; i < n; i++) // satır için döngü
        {
            for (int j = 0; j < n; j++) // sütun için döngü
            {
                for (int k = 0; k < n; k++) // çarpma işlemi
                {
                    sonuc[i, j] += matris1[i, k] * matris2[k, j]; // çarpma ve toplama
                }
            }
        }

        // sonucu ekrana yazdır
        Console.WriteLine("matrislerin çarpımı sonucu:");
        yazdir(sonuc, n); // sonucu yazdır

        // sonlandırmak için kullanıcıdan bir tuşa basmasını bekle
        Console.WriteLine("devam etmek için bir tuşa basın...");
        Console.ReadLine();
    }

    // matris yazdırma
    static void yazdir(int[,] matris, int boyut)
    {
        for (int i = 0; i < boyut; i++)
        {
            for (int j = 0; j < boyut; j++)
            {
                Console.Write(matris[i, j] + "\t"); // matris elemanlarını tab ile ayır
            }
            Console.WriteLine(); // yeni satıra geç
        }
    }
}
