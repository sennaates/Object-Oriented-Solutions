using System;

class Program
{
    static void Main()
    {
        // matris boyutunu kullanıcıdan al
        Console.Write("matris boyutu: ");
        int n = int.Parse(Console.ReadLine()); // kullanıcıdan matris boyutunu al

        // matris oluştur
        int[,] matris = new int[n, n];

        int sayi = 1; // saymaya 1'den başla

        int ust = 0, alt = n - 1, sol = 0, sag = n - 1;

        // spiral döngü
        while (ust <= alt && sol <= sag)
        {
            // sağa doğru doldur
            for (int i = sol; i <= sag; i++)
            {
                matris[ust, i] = sayi++;
            }
            ust++;

            // aşağıya doğru doldur
            for (int i = ust; i <= alt; i++)
            {
                matris[i, sag] = sayi++;
            }
            sag--;

            // sola doğru doldur
            if (ust <= alt)
            {
                for (int i = sag; i >= sol; i--)
                {
                    matris[alt, i] = sayi++;
                }
                alt--;
            }

            // yukarı doğru doldur
            if (sol <= sag)
            {
                for (int i = alt; i >= ust; i--)
                {
                    matris[i, sol] = sayi++;
                }
                sol++;
            }
        }

        // matrisi ekrana yazdır
        yazdir(matris, n);

        // sonlandırmak için kullanıcıdan bir tuşa basmasını bekle
        Console.WriteLine("Devam etmek için bir tuşa basın...");
        Console.ReadLine();
    }

    // matris yazdırma
    static void yazdir(int[,] matris, int boyut)
    {
        for (int i = 0; i < boyut; i++)
        {
            for (int j = 0; j < boyut; j++)
            {
                Console.Write(matris[i, j] + " ");
            }
            Console.WriteLine(); // yeni satıra geç
        }
    }
}
