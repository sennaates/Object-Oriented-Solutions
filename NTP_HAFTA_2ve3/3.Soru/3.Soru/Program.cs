using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Soru
{
    class Program
    {
        static void Main(string[] args)
        {
            // kullanıcıdan sayıları tutmak için bir liste oluştur
            List<int> numbers = new List<int>();
            int input;

            Console.WriteLine("Sayıları girin (0 ile çıkın):");

            // kullanıcıdan sayılar al
            while (true)
            {
                input = Convert.ToInt32(Console.ReadLine());

                // eğer kullanıcı 0 girerse döngüyü kır
                if (input == 0)
                    break;

                // girilen sayıyı listeye ekle
                numbers.Add(input);
            }

            // ardışık grupları bul
            List<string> groups = FindConsecutiveGroups(numbers);

            // sonuçları ekrana yazdır
            Console.WriteLine("Ardışık gruplar:");
            foreach (var group in groups)
            {
                Console.WriteLine(group);
            }
            Console.ReadLine();

        }
        static List<string> FindConsecutiveGroups(List<int> numbers)
        {
            // grupları tutmak için bir liste oluştur
            List<string> groups = new List<string>();

            // sayılar sıralanıyor
            numbers.Sort();

            // ilk sayıyı başlangıç olarak al
            int start = numbers[0];
            int end = start;

            // ardışık grupları bul
            for (int i = 1; i < numbers.Count; i++)
            {
                // eğer sayı ardışık değilse grup oluştur
                if (numbers[i] != end + 1)
                {
                    // grup formatında ekle
                    groups.Add(start == end ? start.ToString() : $"{start}-{end}");
                    start = numbers[i]; // yeni grup başlangıcı
                }
                end = numbers[i]; // mevcut son
            }

            // son grubu ekle
            groups.Add(start == end ? start.ToString() : $"{start}-{end}");

            return groups;
        }
    }
}
