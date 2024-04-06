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
        /// Zahájí proces zašifrování nebo dešifrování zadaného textu pomocí Caesarovy šifry.
        /// </summary>
        /// <param name="text">Text k zašifrování nebo dešifrování.</param>
        /// <param name="decypher">True, pokud se má provést dešifrování; jinak false pro zašifrování.</param>
        public static void Start(string text, bool decypher)
        {
            try
            {
                int input = 0;
                while (true)
                {
                    Console.Write("\nZadejte o kolik písmenek se má text posunout: ");
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
                CaesarovaSifra ces = new CaesarovaSifra(text, input, decypher);
                HistoryHandler.Write(MainMenu.LoggedInUser, ces.ToString(), ActiveSifry.Caesarova_Sifra);
                string output = ces.EncText;
                if (decypher)
                {
                    output = ces.DecText;
                }
                SaveToFileUI.Start(output, decypher);
            }
            catch 
            {
                Console.WriteLine("\n  Chyba: " + text + " nelze zašifrovat/dešifrovat touto šifrou.");
                LogHandler.Write("Nastala chyba při šifraci/dešifraci textu: " + text);
                Thread.Sleep(1000);
            }
        } 
    }
}
