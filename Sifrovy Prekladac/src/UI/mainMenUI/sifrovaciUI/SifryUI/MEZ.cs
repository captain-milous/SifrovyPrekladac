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
    /// Třída pro šifrování a dešifrování textu pomocí Mezerové šifry.
    /// </summary>
    public static class MEZ
    {
        /// <summary>
        /// Zahájí proces zašifrování nebo dešifrování zadaného textu pomocí Mezerové šifry.
        /// </summary>
        /// <param name="text">Text k zašifrování nebo dešifrování.</param>
        /// <param name="decypher">True, pokud se má provést dešifrování; jinak false pro zašifrování.</param>
        public static void Start(string text, bool decypher)
        {
            try
            {
                MezerovaSifra mez = new MezerovaSifra(text, decypher);
                HistoryHandler.Write(MainMenu.LoggedInUser, mez.ToString(), ActiveSifry.Mezerova_Sifra);
                SaveToFileUI.Start(mez.DecText, decypher);
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
