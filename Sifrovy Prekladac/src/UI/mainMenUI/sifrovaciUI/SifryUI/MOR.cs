using Sifrovy_Prekladac.src.historie;
using Sifrovy_Prekladac.src.sifry.related;
using Sifrovy_Prekladac.src.sifry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.UI.mainMenUI.sifrovaciUI.SifryUI
{
    /// <summary>
    /// 
    /// </summary>
    public static class MOR
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public static void Encrypt(string text)
        {
            MorseovaSifra mor = new MorseovaSifra(text);
            while (true)
            {
                bool wrong = false;
                Console.WriteLine("Vyberte na jaká čísla chcete aby se text zašifrovat:");
                Console.WriteLine("  DEF - Klasický překlad morseovky; \n  REV - Obrácená (Tečky jsou čárky a naopak); \n  NUM - Pomocí čísel (0 = tečka, 1 = čárka)");
                Console.Write("Vaše volba: ");
                string answer = Console.ReadLine().ToUpper();
                switch (answer)
                {
                    case "DEF":
                        mor = new MorseovaSifra(text);
                        break;
                    case "REV":
                        mor = new MorseovaSifra(text, answer, false);
                        break;
                    case "NUM":
                        mor = new MorseovaSifra(text, answer, false);
                        break;
                    default:
                        Console.WriteLine("Neplatná volba.");
                        wrong = true;
                        break;
                }
                if (!wrong)
                {
                    break;
                }
            }
            HistoryHandler.Write(MainMenu.LoggedInUser, mor.ToString(), ActiveSifry.Morseova_Sifra);
            SaveToFileUI.Start(mor.EncText, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public static void Decrypt(string text)
        {
            Console.WriteLine("Prozatím mimo provoz.");
            
            MorseovaSifra mor = new MorseovaSifra(text, true);
            while (true)
            {
                bool wrong = false;
                Console.WriteLine("Vyberte na jaká čísla chcete aby se text dešifrovat:");
                Console.WriteLine("  DEF - Klasický překlad morseovky; \n  REV - Obrácená (Tečky jsou čárky a naopak); \n  NUM - Pomocí čísel (0 = tečka, 1 = čárka)");
                Console.Write("Vaše volba: ");
                string answer = Console.ReadLine().ToUpper();
                switch (answer)
                {
                    case "DEF":
                        mor = new MorseovaSifra(text, true);
                        break;
                    case "REV":
                        mor = new MorseovaSifra(text, answer, true);
                        break;
                    case "NUM":
                        mor = new MorseovaSifra(text, answer, true);
                        break;
                    default:
                        Console.WriteLine("Neplatná volba.");
                        wrong = true;
                        break;
                }
                if (!wrong)
                {
                    break;
                }
            }
            HistoryHandler.Write(MainMenu.LoggedInUser, mor.ToString(), ActiveSifry.Morseova_Sifra);
            SaveToFileUI.Start(mor.DecText, true);
            
        }
    }
}
