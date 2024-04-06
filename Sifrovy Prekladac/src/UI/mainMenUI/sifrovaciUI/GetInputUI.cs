using Sifrovy_Prekladac.src.conf;
using Sifrovy_Prekladac.src.static_methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;
using Microsoft.Extensions.Options;
using Sifrovy_Prekladac.src.logs;
using static System.Net.Mime.MediaTypeNames;
using Sifrovy_Prekladac.src.UI.mainMenUI.sifrovaciUI;

namespace Sifrovy_Prekladac.src.UI.mainMenUI.SifrovaciUI
{
    /// <summary>
    /// Poskytuje uživatelské rozhraní pro načtení textu ze souboru nebo vstupu z příkazového řádku.
    /// </summary>
    public static class GetInputUI
    {
        /// <summary>
        /// Spustí uživatelské rozhraní pro výběr zdroje textu (soubor, příkazový řádek) pro zašifrování/dešifrování.
        /// </summary>
        public static void Start()
        {
            Console.Clear();
            bool run = true;
            while (run)
            {
                Print.VolbaTextu();
                int input = SelectOption(Console.ReadLine());
                Console.WriteLine();
                switch (input)
                {
                    case 1:
                        FromCMD();
                        run = false;
                        break;
                    case 2:
                        LoadFromFileUI.Start();
                        run = false;
                        break;
                    case 3:
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Vyberte prosím validní možnost!");
                        Thread.Sleep(1000);
                        break;
                }
                Console.Clear();
            }
        }
        /// <summary>
        /// Vybere možnost z textového vstupu.
        /// </summary>
        /// <param name="input">Textový vstup</param>
        /// <returns>Číslo vybrané možnosti</returns>
        private static int SelectOption(string input)
        {
            int output = -1;
            Dictionary<string, int> options = new Dictionary<string, int>()
            {
                { "cmd", 1 },
                { "c", 1 },
                { "soubor", 2 },
                { "sou", 2 },
                { "s", 2 },
                { "file", 2 },
                { "back", 3 },
                { "b", 3 }
            };
            try
            {
                output = Convert.ToInt32(input);
            }
            catch
            {
                input = input.ToLower().Replace(" ", "");
                if (options.ContainsKey(input))
                {
                    output = options[input];
                }
                else
                {
                    output = -1;
                }
            }
            return output;
        }
        /// <summary>
        /// Načte text z příkazového řádku a spustí zašifrování/dešifrování.
        /// </summary>
        public static void FromCMD()
        {
            bool run = true;
            while (run)
            {
                Console.Write("Zadejte text: ");
                string rawText = Console.ReadLine();
                if (ChceckIfCorrect(rawText))
                {
                    SifrovaniUI.Start(rawText);
                    run = false;
                }
                Console.Clear();
                Console.WriteLine();
            }
        }        
        /// <summary>
        /// Zkontroluje, zda je zadaný text správný.
        /// </summary>
        /// <param name="text">Zadaný text.</param>
        /// <returns>True, pokud je text správný; jinak false.</returns>
        static bool ChceckIfCorrect(string text)
        {
            Console.WriteLine();
            Console.WriteLine("'" + text + "'", Color.Green);
            while (true)
            {
                Console.Write("\nJe toto opravdu text, který chcete přeložit? (A/N)");
                Console.Write("\nVaše volba: ");
                string answer = Console.ReadLine().ToLower();
                if (answer.StartsWith("n"))
                {
                    return false;
                }
                else if (answer.StartsWith("y") || answer.StartsWith("a") || answer.StartsWith("j"))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Neplatná volba!");
                }
                Console.WriteLine();
            }
        }     
    }
}
