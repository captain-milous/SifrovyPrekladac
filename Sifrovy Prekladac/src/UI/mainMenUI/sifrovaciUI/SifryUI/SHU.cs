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
    public static class SHU
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public static void Encrypt(string text)
        {
            ProhazenaSifra shu = new ProhazenaSifra(text);
            HistoryHandler.Write(MainMenu.LoggedInUser, shu.ToString(), ActiveSifry.Prohazena_Sifra);
            SaveToFileUI.Start(shu.EncText, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public static void Decrypt(string text)
        {
            ProhazenaSifra shu = new ProhazenaSifra(text, true);
            HistoryHandler.Write(MainMenu.LoggedInUser, shu.ToString(), ActiveSifry.Prohazena_Sifra);
            SaveToFileUI.Start(shu.DecText, true);

        }
    }
}
