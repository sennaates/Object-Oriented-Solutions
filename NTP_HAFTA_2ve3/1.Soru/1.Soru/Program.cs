using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Soru
{
    class Program
    {
        static void Main(string[] args) 
        {
            List<int> sayilar = new List<int>();
            int gelenSayi;
            bool mevcutMu=false;

            Console.Write("Kaç tane sayı girmek istiyorsun?: ");
            int sayiAdedi = Convert.ToInt32(Console.ReadLine());

            while (sayiAdedi > 0)
            { 
                Console.Write("Sayı giriniz: ");
                gelenSayi = Convert.ToInt32(Console.ReadLine());
                sayilar.Add(gelenSayi);
                sayiAdedi--;
            }

            sayilar.Sort();
            Console.Write("Listede aramak istediğiniz sayı nedir?: ");
            int aranacakSayi = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < sayilar.Count; i++)
            {
                if (aranacakSayi == sayilar[i])
                {
                    Console.WriteLine("Sayiniz listede vardır. ");
                    mevcutMu = true;
                    break;
                }
               
            }
            if (!mevcutMu)
            {
                Console.WriteLine("Sayiniz listede yoktur. ");
            }
            
            Console.ReadLine();
        }
    }
}
