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
    /// Třída pro šifrování a dešifrování textu pomocí Numerické šifry.
    /// </summary>
    public static class NUM
    {
        /// <summary>
        /// Zahájí proces zašifrování nebo dešifrování zadaného textu pomocí Numerické šifry.
        /// </summary>
        /// <param name="text">Text k zašifrování nebo dešifrování.</param>
        /// <param name="decypher">True, pokud se má provést dešifrování; jinak false pro zašifrování.</param>
        public static void Start(string text, bool decypher)
        {
            try
            {
                NumerickaSifra num = new NumerickaSifra(text, "DEF", true);
                while (true)
                {
                    bool wrong = false;
                    Print.NumPodsifry(decypher);
                    string answer = Console.ReadLine().ToUpper();
                    if (answer == "DEF" || answer == "BTR" || answer == "ROM" || answer == "SPI" || answer == "HEX")
                    {
                        num = new NumerickaSifra(text, answer, decypher);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Neplatná volba.");
                    }
                }
                HistoryHandler.Write(MainMenu.LoggedInUser, num.ToString(), ActiveSifry.Numericka_Sifra);
                SaveToFileUI.Start(num.DecText, decypher);
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
