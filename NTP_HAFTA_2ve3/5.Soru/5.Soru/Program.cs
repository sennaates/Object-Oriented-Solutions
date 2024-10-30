using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _5.Soru
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Polinom toplama ve çıkarma programına hoş geldiniz!");
            Console.WriteLine("Çıkmak için 'exit' yazın.");

            while (true)
            {
                // Kullanıcıdan ilk polinomu al
                Console.Write("Birinci polinomu girin: ");
                string polinom1 = Console.ReadLine();
                if (polinom1.ToLower() == "exit") break;

                // Kullanıcıdan ikinci polinomu al
                Console.Write("İkinci polinomu girin: ");
                string polinom2 = Console.ReadLine();
                if (polinom2.ToLower() == "exit") break;

                // Polinomları topla ve çıkar
                var sonucToplama = PolinomTopla(polinom1, polinom2);
                var sonucCikarma = PolinomCikar(polinom1, polinom2);

                // Sonuçları göster
                Console.WriteLine($"Toplam: {sonucToplama}");
                Console.WriteLine($"Çıkarma: {sonucCikarma}");
                Console.WriteLine();
            }
            string PolinomTopla(string p1, string p2)
            {
                var terimler1 = ParsePolinom(p1);
                var terimler2 = ParsePolinom(p2);

                // Birleştirme işlemi
                foreach (var terim in terimler2)
                {
                    terimler1[terim.Key] += terim.Value;
                }

                return PolinomYaz(terimler1);
            }

            string PolinomCikar(string p1, string p2)
            {
                var terimler1 = ParsePolinom(p1);
                var terimler2 = ParsePolinom(p2);

                // Çıkarma işlemi
                foreach (var terim in terimler2)
                {
                    terimler1[terim.Key] -= terim.Value;
                }

                return PolinomYaz(terimler1);
            }

            Dictionary<int, int> ParsePolinom(string polinom)
            {
                var terimler = new Dictionary<int, int>();
                var regex = new Regex(@"([+-]?\d*)(x\^(\d+)|x)?");
                var matches = regex.Matches(polinom);

                foreach (Match match in matches)
                {
                    if (match.Success)
                    {
                        int coef = match.Groups[1].Value == "" || match.Groups[1].Value == "+" ? 1 : (match.Groups[1].Value == "-" ? -1 : int.Parse(match.Groups[1].Value));
                        int power = match.Groups[3].Success ? int.Parse(match.Groups[3].Value) : (match.Groups[2].Success ? 1 : 0);

                        if (terimler.ContainsKey(power))
                        {
                            terimler[power] += coef;
                        }
                        else
                        {
                            terimler[power] = coef;
                        }
                    }
                }
                return terimler;
            }

            string PolinomYaz(Dictionary<int, int> terimler)
            {
                var sonuc = new List<string>();
                foreach (var terim in terimler)
                {
                    if (terim.Value != 0)
                    {
                        string coef = terim.Value > 0 && sonuc.Count > 0 ? $"+{terim.Value}" : $"{terim.Value}";
                        string power = terim.Key == 0 ? "" : (terim.Key == 1 ? "x" : $"x^{terim.Key}");
                        sonuc.Add($"{coef}{power}");
                    }
                }

                return sonuc.Count > 0 ? string.Join(" ", sonuc).Trim() : "0";
            }
        }
    }
}
