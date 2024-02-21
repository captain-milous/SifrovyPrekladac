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
    public static class NUM
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public static void Encrypt(string text)
        {
            NumerickaSifra num = new NumerickaSifra(text, "DEF");
            while (true)
            {
                bool wrong = false;
                Console.WriteLine("Vyberte na jaká čísla chcete aby se text zašifrovat:");
                Console.WriteLine("  DEF - Defaultní (Dle indexu abecedy +1); \n  BTR - Lepší (čísla 1 - 9, mají před sebou 0); \n  ROM - Římské číslice \n  SPI - Spirálové šifrování (čisla 1 - 99)");
                Console.Write("Vaše volba: ");
                string answer = Console.ReadLine().ToUpper();
                switch (answer)
                {
                    case "DEF":
                        num = new NumerickaSifra(text, answer);
                        break;
                    case "BTR":
                        num = new NumerickaSifra(text, answer);
                        break;
                    case "ROM":
                        num = new NumerickaSifra(text, answer);
                        break;
                    case "SPI":
                        num = new NumerickaSifra(text, answer);
                        break;
                    default:
                        Console.WriteLine("Neplatná volba.");
                        wrong = true;
                        break;
                }
                if(!wrong)
                {
                    break;
                }
            }
            HistoryHandler.Write(MainMenu.LoggedInUser, num.ToString(), ActiveSifry.Numericka_Sifra);
            SaveToFileUI.Start(num.EncText, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public static void Decrypt(string text)
        {
            NumerickaSifra num = new NumerickaSifra(text, "DEF", true);
            while (true)
            {
                bool wrong = false;
                Console.WriteLine("Vyberte na jaká čísla chcete aby se text dešifrovat:");
                Console.WriteLine("  DEF - Defaultní (Dle indexu abecedy +1); \n  BTR - Lepší (čísla 1 - 9, mají před sebou 0); \n  ROM - Římské číslice \n  SPI - Spirálové šifrování (čisla 1 - 99)");
                Console.Write("Vaše volba: ");
                string answer = Console.ReadLine().ToUpper();
                switch (answer)
                {
                    case "DEF":
                        num = new NumerickaSifra(text, answer, true);
                        break;
                    case "BTR":
                        num = new NumerickaSifra(text, answer, true);
                        break;
                    case "ROM":
                        num = new NumerickaSifra(text, answer, true);
                        break;
                    case "SPI":
                        num = new NumerickaSifra(text, answer, true);
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
            HistoryHandler.Write(MainMenu.LoggedInUser, num.ToString(), ActiveSifry.Numericka_Sifra);
            SaveToFileUI.Start(num.DecText, true);
        }
    }
}
