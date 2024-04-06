using Sifrovy_Prekladac.src.historie;
using Sifrovy_Prekladac.src.sifry.related;
using Sifrovy_Prekladac.src.sifry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.UI.mainMenUI.sifrovaciUI.SifryUI
{
    /// <summary>
    /// Třída pro šifrování a dešifrování textu pomocí Reverzní šifry.
    /// </summary>
    public static class REV
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
        /// Zašifruje zadaný text pomocí Reverzní šifry.
        /// </summary>
        /// <param name="text">Text, který má být zašifrován.</param>
        public static void Encrypt(string text)
        {
            ReverzniSifra rev = new ReverzniSifra(text);
            HistoryHandler.Write(MainMenu.LoggedInUser, rev.ToString(), ActiveSifry.Reverzni_Sifra);
            SaveToFileUI.Start(rev.EncText, false);
        }
        /// <summary>
        /// Dešifruje zadaný text pomocí Reverzní šifry.
        /// </summary>
        /// <param name="text">Text, který má být dešifrován.</param>
        public static void Decrypt(string text)
        {
            ReverzniSifra rev = new ReverzniSifra(text, true);
            HistoryHandler.Write(MainMenu.LoggedInUser, rev.ToString(), ActiveSifry.Reverzni_Sifra);
            SaveToFileUI.Start(rev.DecText, true);
        }
    }
}
