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
    /// 
    /// </summary>
    public static class REV
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public static void Encrypt(string text)
        {
            ReverzniSifra rev = new ReverzniSifra(text);
            HistoryHandler.Write(MainMenu.LoggedInUser, rev.ToString(), ActiveSifry.Reverzni_Sifra);
            SaveToFileUI.Start(rev.EncText, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public static void Decrypt(string text)
        {
            ReverzniSifra rev = new ReverzniSifra(text, true);
            HistoryHandler.Write(MainMenu.LoggedInUser, rev.ToString(), ActiveSifry.Reverzni_Sifra);
            SaveToFileUI.Start(rev.DecText, true);
        }
    }
}
