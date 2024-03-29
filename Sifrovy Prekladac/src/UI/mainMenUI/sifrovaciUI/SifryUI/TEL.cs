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
    public static class TEL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public static void Encrypt(string text)
        {
            TelefonniSifra tel = new TelefonniSifra(text, "DEF");
            while (true)
            {
                Console.WriteLine("Vyberte jakým způsobem chcete text zašifrovat:");
                Console.WriteLine("(DEF - Zakladní (Stará telefonní klávesnice); BTR - Přehlednější (Dvojice čísel))");
                Console.Write("Vaše volba: ");
                string answer = Console.ReadLine().ToUpper();
                if (answer == "DEF" || answer == "BTR")
                {
                    tel = new TelefonniSifra(text, answer);
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatná volba.");
                }
            }
            HistoryHandler.Write(MainMenu.LoggedInUser, tel.ToString(), ActiveSifry.Telefonni_Sifra);
            SaveToFileUI.Start(tel.EncText, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public static void Decrypt(string text)
        {
            TelefonniSifra tel = new TelefonniSifra(text, "DEF", true);
            while (true)
            {
                Console.WriteLine("Vyberte jakým způsobem chcete text dešifrovat:");
                Console.WriteLine("(DEF - Zakladní (Stará telefonní klávesnice); BTR - Přehlednější (Dvojice čísel))");
                Console.Write("Vaše volba: ");
                string answer = Console.ReadLine().ToUpper();
                if (answer == "DEF" || answer == "BTR")
                {
                    tel = new TelefonniSifra(text, answer, true);
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatná volba.");
                }
            }
            HistoryHandler.Write(MainMenu.LoggedInUser, tel.ToString(), ActiveSifry.Telefonni_Sifra);
            SaveToFileUI.Start(tel.DecText, true);
        }
    }
}
