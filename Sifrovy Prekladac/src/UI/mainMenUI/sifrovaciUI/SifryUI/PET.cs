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
    /// Třída pro šifrování a dešifrování textu pomocí Petronilovy šifry.
    /// </summary>
    public static class PET
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
        /// Zašifruje zadaný text pomocí Petronilovy šifry.
        /// </summary>
        /// <param name="text">Text, který má být zašifrován.</param>
        public static void Encrypt(string text)
        {
            PetronilkaSifra pet = new PetronilkaSifra(text);
            Console.WriteLine("Napište 'PETRONILKA', pokud nemáte vlastní klíč.");
            while (true)
            {
                Console.Write("Zadejte desetimístný klíč pro zašifrování: ");
                try
                {
                    string key = Console.ReadLine().ToUpper();
                    if (string.IsNullOrEmpty(key))
                    {
                        key = "PETRONILKA";
                    }
                    pet = new PetronilkaSifra(text, key);
                    break;
                }
                catch (Exception ex) 
                {
                    Console.WriteLine("Chyba: " + ex.Message);
                }
            }
            HistoryHandler.Write(MainMenu.LoggedInUser, pet.ToString(), ActiveSifry.Petronilka);
            string output = pet.EncText + "\n" + pet.KlicSlovo;
            SaveToFileUI.Start(pet.EncText, false);
        }
        /// <summary>
        /// Dešifruje zadaný text pomocí Petronilovy šifry.
        /// </summary>
        /// <param name="text">Text, který má být dešifrován.</param>
        public static void Decrypt(string text)
        {
            PetronilkaSifra pet = new PetronilkaSifra(text, "PETRONILKA", true);
            Console.WriteLine("Pokud chcete použít klíč 'PETRONILKA', stačí zmáčknout Enter.");
            while (true)
            {
                Console.Write("Zadejte desetimístný klíč pro zašifrování: ");
                try
                {
                    string key = Console.ReadLine().ToUpper();
                    if (string.IsNullOrEmpty(key))
                    {
                        key = "PETRONILKA";
                    }
                    pet = new PetronilkaSifra(text, key, true);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Chyba: " + ex.Message);
                }
            }
            HistoryHandler.Write(MainMenu.LoggedInUser, pet.ToString(), ActiveSifry.Petronilka);
            string output = pet.DecText + "\n" + pet.KlicSlovo;
            SaveToFileUI.Start(output, true);
        }
    }
}
