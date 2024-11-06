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
            BankaHesabi hesap1 = new BankaHesabi("5218", 8888888);

            hesap1.ParaYatir(1);
            hesap1.ParaCek(2);

            Console.ReadLine();
        }
    }
    public class BankaHesabi
    {
        public string HesapNumarasi { get; set; }
        public decimal Bakiye { get; private set; }
        public BankaHesabi(string hesapNumarasi, decimal ilkBakiye)
        {
            HesapNumarasi = hesapNumarasi;
            Bakiye = ilkBakiye;
        }
        public void ParaYatir(decimal miktar)
        {
            if (miktar > 0)
            {
                Bakiye += miktar;
                Console.WriteLine($"{miktar} TL yatırdiniz. Hesap bakiyesi: {Bakiye} TL");
            }
            else
            {
                Console.WriteLine("Yatıracağınız miktar negatif olamaz.");
            }
        }
        public void ParaCek(decimal miktar)
        {
            if (miktar > 0 && miktar <= Bakiye)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Güncel bakiye: {Bakiye} TL");
            }
            else if (miktar > Bakiye)
            {
                Console.WriteLine("Yetersiz bakiye!");
            }
            else
            {
                Console.WriteLine("Çekeceğiniz miktar negatif olamaz.");
            }

        }
    }
}
