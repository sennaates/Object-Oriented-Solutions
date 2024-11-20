using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_2_Ornek
{
    public class Oda
    {
        public string Boyut { get; set; } // Odanın boyutu
        public string Tip { get; set; }   // Odanın tipi (örneğin: yatak odası, mutfak vs.)

        public Oda(string boyut, string tip)
        {
            Boyut = boyut;
            Tip = tip;
        }

        public override string ToString()
        {
            return $"Oda Tipi: {Tip}, Boyut: {Boyut}";
        }
    }

    // "Ev" sınıfı
    public class Ev
    {
        public string Ad { get; set; }                // Evin adı veya tanımı
        public List<Oda> Odalar { get; private set; } // Evdeki odalar listesi

        public Ev(string ad)
        {
            Ad = ad;
            Odalar = new List<Oda>();
        }

        // Odayı eve eklemek için bir yöntem
        public void OdaEkle(Oda oda)
        {
            Odalar.Add(oda);
        }

        public override string ToString()
        {
            string odalarBilgisi = Odalar.Count > 0
                ? string.Join("\n", Odalar)
                : "Odalar yok.";

            return $"Ev Adı: {Ad}\n{odalarBilgisi}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Ev oluştur
            Ev ev = new Ev("Güzel Ev");

            // Odalar oluştur ve ekle
            Oda salon = new Oda("30m2", "Salon");
            Oda yatakOdasi = new Oda("20m2", "Yatak Odası");
            ev.OdaEkle(salon);
            ev.OdaEkle(yatakOdasi);

            // Ev bilgilerini yazdır
            Console.WriteLine(ev);
            Console.Read();
        }
    }
}
