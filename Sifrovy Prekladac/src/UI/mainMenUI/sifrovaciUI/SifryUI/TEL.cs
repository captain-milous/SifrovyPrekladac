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
    /// Třída pro šifrování a dešifrování textu pomocí Telefonní šifry.
    /// </summary>
    public static class TEL
    {
        /// <summary>
        /// Zahájí proces zašifrování nebo dešifrování zadaného textu pomocí Telefonní šifry.
        /// </summary>
        /// <param name="text">Text k zašifrování nebo dešifrování.</param>
        /// <param name="decypher">True, pokud se má provést dešifrování; jinak false pro zašifrování.</param>
        public static void Start(string text, bool decypher)
        {
            try
            {
                TelefonniSifra tel = new TelefonniSifra(text, "DEF", true);
                while (true)
                {
                    Print.TelPodsifry(decypher);
                    string answer = Console.ReadLine().ToUpper();
                    if (answer == "DEF" || answer == "BTR")
                    {
                        tel = new TelefonniSifra(text, answer, decypher);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Neplatná volba.");
                    }
                }
                HistoryHandler.Write(MainMenu.LoggedInUser, tel.ToString(), ActiveSifry.Telefonni_Sifra);
                SaveToFileUI.Start(tel.DecText, decypher);
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
