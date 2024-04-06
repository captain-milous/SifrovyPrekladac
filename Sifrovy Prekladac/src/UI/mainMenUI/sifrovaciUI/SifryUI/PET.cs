using Sifrovy_Prekladac.src.historie;
using Sifrovy_Prekladac.src.sifry.related;
using Sifrovy_Prekladac.src.sifry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;
using Sifrovy_Prekladac.src.logs;

namespace Sifrovy_Prekladac.src.UI.mainMenUI.sifrovaciUI.SifryUI
{
    /// <summary>
    /// Třída pro šifrování a dešifrování textu pomocí Petronilovy šifry.
    /// </summary>
    public static class PET
    {
        /// <summary>
        /// Zahájí proces zašifrování nebo dešifrování zadaného textu pomocí Petronilovy šifry.
        /// </summary>
        /// <param name="text">Text k zašifrování nebo dešifrování.</param>
        /// <param name="decypher">True, pokud se má provést dešifrování; jinak false pro zašifrování.</param>
        public static void Start(string text, bool decypher)
        {
            try
            {
                PetronilkaSifra pet = new PetronilkaSifra(text, "PETRONILKA", true);
                Console.WriteLine("\nPokud chcete použít klíč 'PETRONILKA', zmáčkněte Enter.", Color.Green);
                while (true)
                {
                    string SifDesif = "zašifrování";
                    if (decypher)
                    {
                        SifDesif = "dešifrování";
                    }
                    Console.Write("\nZadejte desetimístný klíč pro " + SifDesif + ": ");
                    try
                    {
                        string key = Console.ReadLine().ToUpper();
                        if (string.IsNullOrEmpty(key))
                        {
                            key = "PETRONILKA";
                        }
                        pet = new PetronilkaSifra(text, key, decypher);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Chyba: " + ex.Message);
                    }
                }
                HistoryHandler.Write(MainMenu.LoggedInUser, pet.ToString(), ActiveSifry.Petronilka);
                string output = pet.EncText + "\n" + pet.KlicSlovo;
                if (decypher)
                {
                    output = pet.DecText + "\n" + pet.KlicSlovo;
                }
                SaveToFileUI.Start(output, decypher);
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
