using Sifrovy_Prekladac.src.historie;
using Sifrovy_Prekladac.src.logs;
using Sifrovy_Prekladac.src.sifry;
using Sifrovy_Prekladac.src.sifry.related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.UI.mainMenUI.sifrovaciUI.SifryUI
{
    /// <summary>
    /// Třída pro šifrování a dešifrování textu pomocí Caesarovy šifry.
    /// </summary>
    public static class CES
    {
        /// <summary>
        /// Zašifruje zadaný text pomocí Caesarovy šifry.
        /// </summary>
        /// <param name="text">Text, který má být zašifrován.</param>
        public static void Encrypt(string text)
        {   
            int input = 0;
            while (true)
            {
                Console.Write("Napište o kolik písmenek dopředu se má text posunout: ");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Zadaná Hodnota musí být integer!");
                }
            }
            CaesarovaSifra ces = new CaesarovaSifra(text, input);
            HistoryHandler.Write(MainMenu.LoggedInUser , ces.ToString(), ActiveSifry.Caesarova_Sifra);
            SaveToFileUI.Start(ces.EncText, false);
            Thread.Sleep(10000);
        }
        /// <summary>
        /// Dešifruje zadaný text pomocí Caesarovy šifry.
        /// </summary>
        /// <param name="text">Text, který má být dešifrován.</param>
        public static void Decrypt(string text)
        {
            int input = 0;
            while (true)
            {
                Console.Write("Napište o kolik písmenek dozadu se má text posunout: ");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Zadaná Hodnota musí být integer!");
                }
            }
            CaesarovaSifra ces = new CaesarovaSifra(text, input, true);
            HistoryHandler.Write(MainMenu.LoggedInUser, ces.ToString(), ActiveSifry.Caesarova_Sifra);
            SaveToFileUI.Start(ces.DecText, true);

        }
    }
}
