﻿using Sifrovy_Prekladac.src.historie;
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
                Console.WriteLine("Vyberte na jaká čísla chcete aby se text zašifrovat:");
                Console.WriteLine("  DEF - Defaultní (Dle indexu abecedy +1); \n  BTR - Lepší (čísla 1 - 9, mají před sebou 0); \n  ROM - Římské číslice \n  SPI - Spirálové šifrování (čisla 1 - 99) \n  HEX - Hexadecimální čísla");
                Console.Write("Vaše volba: ");
                string answer = Console.ReadLine().ToUpper();
                if (answer == "DEF" || answer == "BTR" || answer == "ROM" || answer == "SPI" || answer == "HEX")
                {
                    num = new NumerickaSifra(text, answer);
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatná volba.");
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
                if (answer == "DEF" || answer == "BTR" || answer == "ROM" || answer == "SPI" || answer == "HEX")
                {
                    num = new NumerickaSifra(text, answer, true);
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatná volba.");
                }
            }
            HistoryHandler.Write(MainMenu.LoggedInUser, num.ToString(), ActiveSifry.Numericka_Sifra);
            SaveToFileUI.Start(num.DecText, true);
        }
    }
}
