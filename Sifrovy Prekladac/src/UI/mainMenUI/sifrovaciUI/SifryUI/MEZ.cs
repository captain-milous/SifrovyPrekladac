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
    /// 
    /// </summary>
    public static class MEZ
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public static void Encrypt(string text)
        {
            MezerovaSifra mez = new MezerovaSifra(text);
            HistoryHandler.Write(MainMenu.LoggedInUser, mez.ToString(), ActiveSifry.Mezerova_Sifra);
            SaveToFileUI.Start(mez.EncText, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public static void Decrypt(string text)
        {
            MezerovaSifra mez = new MezerovaSifra(text, true);
            HistoryHandler.Write(MainMenu.LoggedInUser, mez.ToString(), ActiveSifry.Mezerova_Sifra);
            SaveToFileUI.Start(mez.DecText, true);
        }
    }
}
