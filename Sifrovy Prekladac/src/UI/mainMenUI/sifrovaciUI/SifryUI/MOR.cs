using Sifrovy_Prekladac.src.historie;
using Sifrovy_Prekladac.src.sifry.related;
using Sifrovy_Prekladac.src.sifry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sifrovy_Prekladac.src.logs;

namespace Sifrovy_Prekladac.src.UI.mainMenUI.sifrovaciUI.SifryUI
{
    /// <summary>
    /// Třída pro šifrování a dešifrování textu pomocí Morseovy šifry.
    /// </summary>
    public static class MOR
    {
        /// <summary>
        /// Zahájí proces zašifrování nebo dešifrování zadaného textu pomocí Morseovy šifry.
        /// </summary>
        /// <param name="text">Text k zašifrování nebo dešifrování.</param>
        /// <param name="decypher">True, pokud se má provést dešifrování; jinak false pro zašifrování.</param>
        public static void Start(string text, bool decypher)
        {
            try
            {
                MorseovaSifra mor = new MorseovaSifra(text, decypher);
                while (true)
                {
                    Print.MorPodsifry(decypher);
                    string answer = Console.ReadLine().ToUpper();
                    if (answer == "DEF" || answer == "REV" || answer == "NUM" || answer == "ABC")
                    {
                        mor = new MorseovaSifra(text, answer, decypher);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Neplatná volba.");
                    }
                }
                HistoryHandler.Write(MainMenu.LoggedInUser, mor.ToString(), ActiveSifry.Morseova_Sifra);
                string output = mor.EncText;
                if (decypher)
                {
                    output = mor.DecText;
                }
                SaveToFileUI.Start(output, decypher);
            }
            catch
            {
                Console.WriteLine("\n  Chyba: "+ text + " nelze zašifrovat/dešifrovat touto šifrou.");
                LogHandler.Write("Nastala chyba při šifraci/dešifraci textu: " + text);
                Thread.Sleep(1000);
            }
        }
    }
}
