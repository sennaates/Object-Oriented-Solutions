using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_3_Ornek
{
    class Motor
    {
        private int Güç;
        private string Tip;

        public Motor(int güç, string tip)
        {
            Güç = güç;
            Tip = tip;
        }

        public void MotorBilgisi()
        {
            Console.WriteLine($"Motor Gücü: {Güç} HP");
            Console.WriteLine($"Motor Tipi: {Tip}");
        }
    }

    class Otomobil
    {
        public string Marka { get; private set; }
        private Motor motor;

        public Otomobil(string marka, int motorGücü, string motorTipi)
        {
            Marka = marka;
            motor = new Motor(motorGücü, motorTipi);
        }

        public void MotorOlustur()
        {
            Console.WriteLine($"Otomobil Markası: {Marka}");
            motor.MotorBilgisi();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Otomobilin markasını girin: ");
            string marka = Console.ReadLine();

            Console.Write("Motor gücünü girin (HP): ");
            int güç = int.Parse(Console.ReadLine());

            Console.Write("Motor tipini girin: ");
            string tip = Console.ReadLine();

            Otomobil otomobil = new Otomobil(marka, güç, tip);
            otomobil.MotorOlustur();

            Console.WriteLine("Program sona erdi.");
            Console.ReadLine();
        }
    }
}
