using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_2_Ornek
{
    class Program
    {
        static void Main(string[] args)
        {

            Doktor doktor = new Doktor
            {
                Ad = "Dr. Aybars Ateş",
                Brans = "Dermatoloji",
                Hastalar = new List<Hasta>() 
            };

            
            Hasta hasta1 = new Hasta(doktor, "12345678901", "Mutlu Ateş");
            Hasta hasta2 = new Hasta(doktor, "98765432109", "Fethi Ateş");
            Hasta hasta3 = new Hasta(doktor, "45612378902", "Sena Ateş");

            
            doktor.HastaEkle(hasta1);
            doktor.HastaEkle(hasta2);
            doktor.HastaEkle(hasta3);

            // Doktorun bilgilerini yazdır
            Console.WriteLine($"Doktor: {doktor.Ad} - Branş: {doktor.Brans}");
            Console.WriteLine("Hastaları:");
            foreach (var hasta in doktor.Hastalar)
            {
                Console.WriteLine($"- {hasta.Ad} (TC No: {hasta.TcNo})");
            }

            Console.Read();
        }
    }
    class Hasta
    {
        public string Ad { get; set; }
        public string TcNo { get; set; }
        public Doktor Doktor { get; set; }

        public Hasta(Doktor doktor, string tcNo, string ad)
        {
            Doktor = doktor;
            TcNo = tcNo;
            Ad = ad;
        }
        public void DoktorAtama(Doktor doktor)
        {

        }
           

        
    }
    class Doktor
    {
        public string Ad { get; set; }
        public string Brans { get; set; }
        public List<Hasta> Hastalar { get; set; }

        public void HastaEkle(Hasta hasta)
        {
            if (!Hastalar.Contains(hasta))

            {
                Hastalar.Add(hasta);

            }
        }
    }
}
