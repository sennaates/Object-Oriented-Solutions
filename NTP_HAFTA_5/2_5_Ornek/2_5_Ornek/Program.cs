using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_5_Ornek
{
   
    public class Ebeveyn
    {
        public string Ad { get; set; }
        public int Yas { get; set; }
        public List<Cocuk> Cocuklar { get; set; } = new List<Cocuk>();

        // Çocuk ekleme metodu
        public void CocukEkle(Cocuk cocuk)
        {
            Cocuklar.Add(cocuk);
            cocuk.EbeveynAtama(this); // Çocuğun ebeveyni olarak kendisini atar
        }
    }

    // Çocuk Sınıfı
    public class Cocuk
    {
        public string Ad { get; set; }
        public int Yas { get; set; }
        public Ebeveyn Ebeveyn { get; private set; }

        // Ebeveyn atama metodu
        public void EbeveynAtama(Ebeveyn ebeveyn)
        {
            Ebeveyn = ebeveyn;
            if (!ebeveyn.Cocuklar.Contains(this)) // Tekrar eklenmesini önler
            {
                ebeveyn.Cocuklar.Add(this);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Kullanıcıdan ebeveyn bilgileri al
            Console.WriteLine("Ebeveynin adını giriniz:");
            string ebeveynAdi = Console.ReadLine();

            Console.WriteLine("Ebeveynin yaşını giriniz:");
            int ebeveynYasi = int.Parse(Console.ReadLine());

            Ebeveyn ebeveyn = new Ebeveyn { Ad = ebeveynAdi, Yas = ebeveynYasi };

            Console.WriteLine("Kaç çocuk eklemek istiyorsunuz?");
            int cocukSayisi = int.Parse(Console.ReadLine());

            for (int i = 1; i <= cocukSayisi; i++)
            {
                Console.WriteLine($"{i}. Çocuğun adını giriniz:");
                string cocukAdi = Console.ReadLine();

                Console.WriteLine($"{i}. Çocuğun yaşını giriniz:");
                int cocukYasi = int.Parse(Console.ReadLine());

                Cocuk cocuk = new Cocuk { Ad = cocukAdi, Yas = cocukYasi };
                ebeveyn.CocukEkle(cocuk);
            }

            // Ebeveyn ve çocuk bilgilerini yazdır
            Console.WriteLine($"\nEbeveyn: {ebeveyn.Ad}, Yaş: {ebeveyn.Yas}");
            Console.WriteLine("Çocuklar:");
            foreach (var cocuk in ebeveyn.Cocuklar)
            {
                Console.WriteLine($"- {cocuk.Ad} (Yaş: {cocuk.Yas})");
            }

            // Çocukların ebeveynlerini kontrol et
            foreach (var cocuk in ebeveyn.Cocuklar)
            {
                Console.WriteLine($"\nÇocuk: {cocuk.Ad}, Ebeveyni: {cocuk.Ebeveyn.Ad}");
            }

            Console.WriteLine("\nProgramı kapatmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}

