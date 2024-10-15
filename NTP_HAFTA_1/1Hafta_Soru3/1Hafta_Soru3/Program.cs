using System;

class Program
{
    static void Main()
    {
        // kullanıcıdan N sayısını al
        Console.Write("N sayısını girin: ");
        int n = int.Parse(Console.ReadLine()); // kullanıcıdan N'yi al

        // asal sayıların toplamını hesapla
        int toplam = AsalSayilarinToplami(n); // toplamı bul

        // sonucu ekrana yazdır
        Console.WriteLine($"1 ile {n} arasındaki asal sayıların toplamı: {toplam}");

        // sonlandırmak için kullanıcıdan bir tuşa basmasını bekle
        Console.WriteLine("Devam etmek için bir tuşa basın...");
        Console.ReadLine();
    }

    // asal sayıların toplamını bulan fonksiyon
    static int AsalSayilarinToplami(int n)
    {
        int toplam = 0; // toplamı 0'dan başlat

        // 2'den n'ye kadar olan sayıları kontrol et
        for (int i = 2; i <= n; i++)
        {
            if (AsalMi(i)) // eğer sayı asal ise
            {
                toplam += i; // sayıyı toplama ekle
            }
        }

        return toplam; // toplamı döndür
    }

    // asal sayıyı kontrol eden fonksiyon
    static bool AsalMi(int sayi)
    {
        // 2'den küçük sayılar asal değildir
        if (sayi < 2) return false;

        // 2'den sayının kareköküne kadar olan sayılarla kontrol et
        for (int i = 2; i * i <= sayi; i++)
        {
            if (sayi % i == 0) // eğer tam bölünüyorsa
            {
                return false; // asal değil
            }
        }

        return true; // asal
    }
}
