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
    /// Třída pro šifrování a dešifrování textu pomocí Reverzní šifry.
    /// </summary>
    public static class REV
    {
        /// <summary>
        /// Zahájí proces zašifrování nebo dešifrování zadaného textu pomocí Reverzní šifry.
        /// </summary>
        /// <param name="text">Text k zašifrování nebo dešifrování.</param>
        /// <param name="decypher">True, pokud se má provést dešifrování; jinak false pro zašifrování.</param>
        public static void Start(string text, bool decypher)
        {
            try
            {
                ReverzniSifra rev = new ReverzniSifra(text, decypher);
                HistoryHandler.Write(MainMenu.LoggedInUser, rev.ToString(), ActiveSifry.Reverzni_Sifra);
                string output = rev.EncText;
                if (decypher)
                {
                    output = rev.DecText;
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
