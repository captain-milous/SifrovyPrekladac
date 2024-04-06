using Sifrovy_Prekladac.src.historie;
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
        /// Zahájí proces zašifrování nebo dešifrování zadaného textu.
        /// </summary>
        /// <param name="text">Text k zašifrování nebo dešifrování.</param>
        /// <param name="decypher">True, pokud se má provést dešifrování; jinak false pro zašifrování.</param>
        public static void Start(string text, bool decypher)
        {
            if (!decypher)
            {
                Encrypt(text);
            }
            else
            {
                Decrypt(text);
            }
        }
        /// <summary>
        /// Zašifruje zadaný text pomocí Klávesnicové šifry.
        /// </summary>
        /// <param name="text">Text, který má být zašifrován.</param>
        public static void Encrypt(string text)
        {
            KlavesnicovaSifra kla = new KlavesnicovaSifra(text, "CZK");
            while (true)
            {
                Console.WriteLine("Vyberte pomocí jakého rozpoložení klávesnice chcete zašifrovat:");
                Console.WriteLine("(CZ - České (QWERTZ); EN - Anglické (QWERTY))");
                Console.Write("Vaše volba: ");
                string answer = Console.ReadLine().ToUpper();
                if (answer == "CZ")
                {
                    kla = new KlavesnicovaSifra(text, "CZK");
                    break;
                }
                else if (answer == "EN")
                {
                    kla = new KlavesnicovaSifra(text, "ENK");
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatná volba.");
                }
            }
            HistoryHandler.Write(MainMenu.LoggedInUser, kla.ToString(), ActiveSifry.Klavesnicova_Sifra);
            SaveToFileUI.Start(kla.EncText, false);
        }
        /// <summary>
        /// Dešifruje zadaný text pomocí Klávesnicové šifry.
        /// </summary>
        /// <param name="text">Text, který má být dešifrován.</param>
        public static void Decrypt(string text)
        {
            KlavesnicovaSifra kla = new KlavesnicovaSifra(text, "CZK", true);
            while (true)
            {
                Console.WriteLine("Vyberte pomocí jakého rozpoložení klávesnice chcete dešifrovat:");
                Console.WriteLine("(CZ - České (QWERTZ); EN - Anglické (QWERTY))");
                Console.Write("Vaše volba: ");
                string answer = Console.ReadLine().ToUpper();
                if (answer == "CZ")
                {
                    kla = new KlavesnicovaSifra(text, "CZK", true);
                    break;
                }
                else if (answer == "EN")
                {
                    kla = new KlavesnicovaSifra(text, "ENK", true);
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatná volba.");
                }
            }
            HistoryHandler.Write(MainMenu.LoggedInUser, kla.ToString(), ActiveSifry.Klavesnicova_Sifra);
            SaveToFileUI.Start(kla.DecText, true);
        }
    }
}
