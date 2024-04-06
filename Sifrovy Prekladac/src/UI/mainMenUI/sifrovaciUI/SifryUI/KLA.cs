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
    /// Třída pro šifrování a dešifrování textu pomocí Klávesnicové šifry.
    /// </summary>
    public static class KLA
    {
        /// <summary>
        /// Zahájí proces zašifrování nebo dešifrování zadaného textu pomocí Klávesnicové šifry.
        /// </summary>
        /// <param name="text">Text k zašifrování nebo dešifrování.</param>
        /// <param name="decypher">True, pokud se má provést dešifrování; jinak false pro zašifrování.</param>
        public static void Start(string text, bool decypher)
        {
            try
            {
                KlavesnicovaSifra kla = new KlavesnicovaSifra(text, "CZK");
                while (true)
                {
                    Print.KlaPodsifry(decypher);
                    string answer = Console.ReadLine().ToUpper();
                    if (answer == "CZ" || answer == "EN")
                    {
                        answer = answer + "K";
                        kla = new KlavesnicovaSifra(text, answer, decypher);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Neplatná volba.");
                    }
                }
                HistoryHandler.Write(MainMenu.LoggedInUser, kla.ToString(), ActiveSifry.Klavesnicova_Sifra);
                string output = kla.EncText;
                if (decypher)
                {
                    output = kla.DecText;
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
