﻿using Sifrovy_Prekladac.src.historie;
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
    /// Třída pro šifrování a dešifrování textu pomocí Prohazené šifry.
    /// </summary>
    public static class SHU
    {
        /// <summary>
        /// Zašifruje zadaný text pomocí Prohazené šifry.
        /// </summary>
        /// <param name="text">Text, který má být zašifrován.</param>
        public static void Encrypt(string text)
        {
            ProhazenaSifra shu = new ProhazenaSifra(text);
            HistoryHandler.Write(MainMenu.LoggedInUser, shu.ToString(), ActiveSifry.Prohazena_Sifra);
            SaveToFileUI.Start(shu.EncText, false);
        }
        /// <summary>
        /// Dešifruje zadaný text pomocí Prohazené šifry.
        /// </summary>
        /// <param name="text">Text, který má být dešifrován.</param>
        public static void Decrypt(string text)
        {
            ProhazenaSifra shu = new ProhazenaSifra(text, true);
            HistoryHandler.Write(MainMenu.LoggedInUser, shu.ToString(), ActiveSifry.Prohazena_Sifra);
            SaveToFileUI.Start(shu.DecText, true);

        }
    }
}
