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
    /// Třída pro šifrování a dešifrování textu pomocí Morseovy šifry.
    /// </summary>
    public static class MOR
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
        /// Zašifruje zadaný text pomocí Morseovy šifry.
        /// </summary>
        /// <param name="text">Text, který má být zašifrován.</param>
        public static void Encrypt(string text)
        {
            MorseovaSifra mor = new MorseovaSifra(text);
            while (true)
            {
                Print.VypisMorPodsifry(false);
                string answer = Console.ReadLine().ToUpper();
                if (answer == "DEF" || answer == "REV" || answer == "NUM" || answer == "ABC")
                {
                    mor = new MorseovaSifra(text, answer, false);
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatná volba.");
                }
            }
            HistoryHandler.Write(MainMenu.LoggedInUser, mor.ToString(), ActiveSifry.Morseova_Sifra);
            SaveToFileUI.Start(mor.EncText, false);
        }
        /// <summary>
        /// Dešifruje zadaný text pomocí Morseovy šifry.
        /// </summary>
        /// <param name="text">Text, který má být dešifrován.</param>
        public static void Decrypt(string text)
        {
            //Console.WriteLine("Prozatím mimo provoz.");
            
            MorseovaSifra mor = new MorseovaSifra(text, true);
            while (true)
            {
                Print.VypisMorPodsifry(true);
                string answer = Console.ReadLine().ToUpper();
                if (answer == "DEF" || answer == "REV" || answer == "NUM" || answer == "ABC")
                {
                    mor = new MorseovaSifra(text, answer, true);
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatná volba.");
                }
            }
            HistoryHandler.Write(MainMenu.LoggedInUser, mor.ToString(), ActiveSifry.Morseova_Sifra);
            SaveToFileUI.Start(mor.DecText, true);
            
        }
    }
}
