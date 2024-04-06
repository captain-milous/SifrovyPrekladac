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
    /// Třída pro šifrování a dešifrování textu pomocí Prohazené šifry.
    /// </summary>
    public static class SHU
    {
        /// <summary>
        /// Zahájí proces zašifrování nebo dešifrování zadaného textu pomocí Prohazené šifry.
        /// </summary>
        /// <param name="text">Text k zašifrování nebo dešifrování.</param>
        /// <param name="decypher">True, pokud se má provést dešifrování; jinak false pro zašifrování.</param>
        public static void Start(string text, bool decypher)
        {
            try
            {
                ProhazenaSifra shu = new ProhazenaSifra(text, decypher);
                HistoryHandler.Write(MainMenu.LoggedInUser, shu.ToString(), ActiveSifry.Prohazena_Sifra);
                SaveToFileUI.Start(shu.DecText, decypher);
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
