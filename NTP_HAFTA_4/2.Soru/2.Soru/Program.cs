using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Soru
{
    class Program
    {
        static void Main(string[] args)
        {
            Urun urun1 = new Urun("URUN", 12000);
            urun1.Indirim = 30; 
            decimal indirimliFiyat = urun1.IndirimliFiyat();
            Console.WriteLine($"Eski fiyat: {urun1.Fiyat}, Yeni fiyat: {indirimliFiyat}");
            Console.ReadLine(); 

        }
        class Urun
        {
            private decimal indirim;
            public string Ad { get; set; }
            public decimal Fiyat { get; set; }
            public decimal Indirim
            {

                get { return indirim; }
                set
                {
                    if (value >= 0 && value <= 50)
                        indirim = value;
                    else
                       Console.Write("Negatif değer girişi yapmayınız.");
                }
            }

            public Urun(string ad, decimal fiyat)
            {
                Ad = ad;
                Fiyat = fiyat;
            }

            public decimal IndirimliFiyat()
            {
                return Fiyat - Fiyat * Indirim / 100;
            }
        }
    }
}

