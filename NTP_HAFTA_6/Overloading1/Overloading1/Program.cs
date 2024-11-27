using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading1
{
    /*
    1.Matematiksel İşlemleri Çeşitlendiren Bir Fonksiyon
    Bir fonksiyon yazın:
•	Aynı adla ama farklı parametrelerle toplam işlemi yapacak.
•	İlk sürümü iki tam sayıyı toplasın.
•	İkinci sürümü üç tam sayıyı toplasın.
•	Üçüncü sürümü bir dizi (array) tam sayıyı toplasın.
    */


    class Program
    {
        static int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }
        static int Topla(int sayi1, int sayi2, int sayi3 )
        {
            return sayi1 + sayi2+ sayi3;
        }
        static int Topla(int[] array)
        {
            int sonuc = 0;
            foreach(int sayi in array)
            {
                sonuc += sayi;    
            }
            return sonuc;
        }
        
        
        static void Main(string[] args)
        {
            int[] sayilar = { 3, 4, 5, 6, 7 };

            int ikiSayininToplami = Topla(3, 4);
            int ucSayininToplami = Topla(2, 6, 8);
            int diziElemanlariToplami = Topla(sayilar);

            Console.WriteLine(ikiSayininToplami);
            Console.WriteLine(ucSayininToplami);
            Console.WriteLine(diziElemanlariToplami);

            Console.Read();
        }
    }
}
