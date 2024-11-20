using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_4_Ornek
{
    class Program
    {
        static void Main(string[] args)
        {
            Siparis sipariş1 = new Siparis(  )
        }
    }
    class Siparis
    {
        public DateTime Tarih { get; set; }
        public Decimal Toplam { get; set; }

        public Siparis(DateTime tarih, Decimal toplam)
        {
            Tarih = tarih;
            Toplam = toplam;
        }
    
    }
    class Urun
    {
        public string Ad { get; set; }
        private int Fiyat { get; set; }
        private List<stok> StokTakip { get; set; }
        public Urun(string ad, int fiyat)
        {
            Ad = ad;
           
        }
        public StokTakip ()

        public void UrunBilgisi(int fiyat)
        {
            Fiyat = fiyat;
        }
    }
}
