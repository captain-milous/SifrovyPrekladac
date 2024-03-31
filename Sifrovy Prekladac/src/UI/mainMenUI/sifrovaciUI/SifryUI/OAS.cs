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
    /// Třída pro šifrování a dešifrování textu pomocí Obrácené ABC šifry.
    /// </summary>
    public static class OAS
    {
        /// <summary>
        /// Zašifruje zadaný text pomocí Obrácené ABC šifry.
        /// </summary>
        /// <param name="text">Text, který má být zašifrován.</param>
        public static void Encrypt(string text)
        {
            ObracenaAbcSifra oas = new ObracenaAbcSifra(text);
            HistoryHandler.Write(MainMenu.LoggedInUser, oas.ToString(), ActiveSifry.Obracena_ABC_Sifra);
            SaveToFileUI.Start(oas.EncText, false);
        }
        /// <summary>
        /// Dešifruje zadaný text pomocí Obrácené ABC šifry.
        /// </summary>
        /// <param name="text">Text, který má být dešifrován.</param>
        public static void Decrypt(string text)
        {
            ObracenaAbcSifra oas = new ObracenaAbcSifra(text, true);
            HistoryHandler.Write(MainMenu.LoggedInUser, oas.ToString(), ActiveSifry.Obracena_ABC_Sifra);
            SaveToFileUI.Start(oas.DecText, true);
        }
    }
}
