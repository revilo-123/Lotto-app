using System;
using System.Collections.Generic;

namespace LottoConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int forsok = 0;
            int antallRette = 0;
            int[] lottoLapp = new int[7];

            // Brukeren velger om de vil ha egne tall eller system-genererte tall
            Console.WriteLine("Vil du skrive inn egne tall? (ja/nei)");
            string valg = Console.ReadLine().ToLower();

            if (valg == "ja")
            {
                lottoLapp = BrukerGenererLapp();
            }
            else
            {
                lottoLapp = SystemGenererLapp(random);
            }

            // 2 - Løkke for å trekke nye lottotall til vi har 7 rette
            while (antallRette < 7)
            {
                int[] lottoTall = SystemGenererLapp(random);
                antallRette = 0;

                // Sjekker hvor mange rette vi har
                foreach (int tall in lottoLapp)
                {
                    if (FindNumber(tall, lottoTall))
                    {
                        antallRette++;
                    }
                }

                forsok++;  // Øker antall forsøk
            }

            // Skriver ut antall forsøk
            Console.WriteLine($"Alle tallene var riktige etter {forsok} forsøk!");
        }

        /// <summary>
        /// Bruker skriver inn 7 unike tall mellom 1 og 35.
        /// </summary>
        /// <returns>int[]</returns>
        public static int[] BrukerGenererLapp()
        {
            int[] brukerLapp = new int[7];
            HashSet<int> tallSet = new HashSet<int>(); // Sikrer unike tall

            Console.WriteLine("Skriv inn 7 unike tall mellom 1 og 35:");

            for (int i = 0; i < brukerLapp.Length; i++)
            {
                int tall;
                bool gyldig = false;

                while (!gyldig)
                {
                    Console.Write($"Tall {i + 1}: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out tall) && tall >= 1 && tall <= 35 && !tallSet.Contains(tall))
                    {
                        tallSet.Add(tall);
                        brukerLapp[i] = tall;
                        gyldig = true;
                    }
                    else
                    {
                        Console.WriteLine("Ugyldig tall, vennligst skriv et unikt tall mellom 1 og 35.");
                    }
                }
            }

            return brukerLapp;
        }

        /// <summary>
        /// System genererer 7 unike tall mellom 1 og 35.
        /// </summary>
        /// <param name="random"></param>
        /// <returns>int[]</returns>
        public static int[] SystemGenererLapp(Random random)
        {
            int[] systemLapp = new int[7];
            HashSet<int> tallSet = new HashSet<int>(); // Sikrer unike tall

            for (int i = 0; i < systemLapp.Length; i++)
            {
                int tall;
                do
                {
                    tall = random.Next(1, 36); // Genererer et tall mellom 1 og 35
                } while (!tallSet.Add(tall));  // Sikrer at tallet er unikt

                systemLapp[i] = tall;
            }

            return systemLapp;
        }

        /// <summary>
        /// Leter etter et spesifikt tall i en array. Returnerer true om funnet.
        /// </summary>
        /// <param name="userNum"></param>
        /// <param name="lottoNum"></param>
        /// <returns>bool</returns>
        public static bool FindNumber(int userNum, int[] lottoNum)
        {
            foreach (int num in lottoNum)
            {
                if (num == userNum)
                    return true;
            }
            return false;
        }
    }
}// !!!! Har fått litt hjelp fra ChatGPT!!!!
