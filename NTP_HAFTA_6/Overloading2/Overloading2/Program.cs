using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading2
{
    /*Farklı Şekillerin Alanını Hesaplayan Bir Fonksiyon
    //Bir fonksiyon yazın:
    //-Aynı adla ama farklı parametrelerle farklı şekillerin alanını hesaplasın.
    //-İlk sürüm, bir karenin alanını hesaplasın(bir kenar uzunluğu verilerek).
    //-İkinci sürüm, bir dikdörtgenin alanını hesaplasın(iki kenar uzunluğu verilerek).
    //-Üçüncü sürüm, bir dairenin alanını hesaplasın(yarıçap verilerek).
    */
    class Program


    {

        static int AlanHesapla(int kenarUzunlugu)
        {
            return kenarUzunlugu * kenarUzunlugu;
        }
        static double AlanHesapla(double kisaKenar, double uzunKenar)
        {
            return kisaKenar * uzunKenar;
        }
        static double AlanHesapla(double yaricap)
        {
            return Math.PI * yaricap * yaricap;
        }
        static void Main(string[] args)
        {
            int AlanHesapla(int kenarUzunlugu)
            {
                return kenarUzunlugu * kenarUzunlugu;
            }
            double AlanHesapla(double kisaKenar, double uzunKenar)
            {
                return kisaKenar * uzunKenar;
            }
            double AlanHesapla(double yaricap)
            {
                return Math.PI * yaricap * yaricap;
            }
        }
    }
}
