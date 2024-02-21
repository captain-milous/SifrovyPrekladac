using Sifrovy_Prekladac.src.static_methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.sifry
{
    /// <summary>
    /// Třída reprezentující Klávesnicovou šifru, odvozená od třídy Sifra.
    /// </summary>
    public class KlavesnicovaSifra : Sifra
    {
        #region Slovníky a Listy
        /// <summary>
        /// Pole typů klávesnice.
        /// CZK (České rozložení klávesnice)
        /// ENK (Anglické rozložení klávesnice)
        /// </summary>
        private static string[] typyKlavesnice = { "CZK", "ENK"};
        /// <summary>
        /// Mapování znaků pro českou klávesnici.
        /// </summary>
        private static Dictionary<char,string> CzKeyboard = new Dictionary<char, string>() 
        {
            {'A', "LS"}, 
            {'B', "VN"}, 
            {'C', "XV"}, 
            {'D', "SF"},
            {'E', "WR"},
            {'F', "DG"}, 
            {'G', "FH"}, 
            {'H', "GJ"}, 
            {'I', "UO"}, 
            {'J', "HK"},
            {'K', "JL"}, 
            {'L', "KA"}, 
            {'M', "NY"}, 
            {'N', "BM"}, 
            {'O', "IP"},
            {'P', "OQ"}, 
            {'Q', "PW"}, 
            {'R', "ET"}, 
            {'S', "AD"}, 
            {'T', "RZ"},
            {'U', "ZI"}, 
            {'V', "CB"}, 
            {'W', "QE"}, 
            {'X', "YC"}, 
            {'Y', "MX"},
            {'Z', "TU"}
        };
        /// <summary>
        /// Mapování znaků pro anglickou klávesnici.
        /// </summary>
        private static Dictionary<char, string> EnKeyboard = new Dictionary<char, string>()
        {
            {'A', "LS"},
            {'B', "VN"},
            {'C', "XV"},
            {'D', "SF"},
            {'E', "WR"},
            {'F', "DG"},
            {'G', "FH"},
            {'H', "GJ"},
            {'I', "UO"},
            {'J', "HK"},
            {'K', "JL"},
            {'L', "KA"},
            {'M', "NZ"},
            {'N', "BM"},
            {'O', "IP"},
            {'P', "OQ"},
            {'Q', "PW"},
            {'R', "ET"},
            {'S', "AD"},
            {'T', "RY"},
            {'U', "YI"},
            {'V', "CB"},
            {'W', "QE"},
            {'X', "ZC"},
            {'Y', "MX"},
            {'Z', "TU"}
        };
        #endregion
        #region Konstruktory
        /// <summary>
        /// Inicializuje novou instanci KlavesnicovaSifra s daným nešifrovaným textem a klíčem pro určení typu klávesnice.
        /// </summary>
        /// <param name="rawText">Nešifrovaný text.</param>
        /// <param name="type">Klíč pro určení typu klávesnice (např. "CZK" pro českou klávesnici).</param>
        public KlavesnicovaSifra(string rawText, string type) : base(typyKlavesnice, type)
        {
            DecText = TextMethods.WithoutSpaces(TextMethods.Simplify(rawText));
            EncText = Encrypt(DecText);
        }
        /// <summary>
        /// Inicializuje novou instanci KlavesnicovaSifra s daným textem, klíčem a volbou provést šifrování nebo dešifrování.
        /// </summary>
        /// <param name="rawText">Vstupní text.</param>
        /// <param name="type">Klíč pro určení typu klávesnice.</param>
        /// <param name="decipher">True, pokud se má provést dešifrování; jinak false.</param>
        public KlavesnicovaSifra(string rawText, string type, bool decipher) : base(typyKlavesnice, type)
        {
            if (!decipher)
            {
                DecText = TextMethods.WithoutSpaces(TextMethods.Simplify(rawText));
                EncText = Encrypt(DecText);
            }
            else
            {
                EncText = rawText;
                DecText = Decrypt(EncText);
            }
        }
        #endregion
        #region Zašifrování
        /// <summary>
        /// Zašifruje zadaný text podle klávesnice specifikované v klíči.
        /// </summary>
        /// <param name="text">Text k zašifrování.</param>
        /// <returns>Zašifrovaný text.</returns>
        /// <exception cref="Exception">Vyjímka v případě nepodporovaného typu šifrování.</exception>
        public override string Encrypt(string text)
        {
            StringBuilder encryptedText = new StringBuilder();
            switch (TypeOfEnc)
            {
                case "CZK":

                    foreach (char c in text)
                    {
                        string eChar = CzKeyboard[c];
                        encryptedText.Append(eChar);
                        encryptedText.Append(' ');
                    }
                    return encryptedText.ToString();

                case "ENK":

                    foreach (char c in text)
                    {
                        string eChar = EnKeyboard[c];
                        encryptedText.Append(eChar);
                        encryptedText.Append(' ');
                    }
                    return encryptedText.ToString();

                default:
                    throw new Exception("Nepodporovaný typ šifrování.");

            }
        }
        #endregion
        #region Rozšifrování
        /// <summary>
        /// Dešifruje zadaný text podle klávesnice specifikované v klíči.
        /// </summary>
        /// <param name="text">Zašifrovaný text.</param>
        /// <returns>Dešifrovaný text.</returns>
        /// <exception cref="Exception">Vyjímka v případě nepodporovaného typu šifrování.</exception>
        public override string Decrypt(string text)
        {
            StringBuilder decryptedText = new StringBuilder();
            switch (TypeOfEnc)
            {
                case "CZK":

                    string[] encryptedChars = text.Trim().Split(' ');
                    foreach (string eChar in encryptedChars)
                    {
                        char originalChar = CzKeyboard.FirstOrDefault(x => x.Value == eChar).Key;
                        decryptedText.Append(originalChar);
                    }
                    return decryptedText.ToString();

                case "ENK":

                    encryptedChars = text.Trim().Split(' ');
                    foreach (string eChar in encryptedChars)
                    {
                        char originalChar = EnKeyboard.FirstOrDefault(x => x.Value == eChar).Key;
                        decryptedText.Append(originalChar);
                    }
                    return decryptedText.ToString();

                default:
                    throw new Exception("Nepodporovaný typ šifrování.");

            }
        }
        #endregion
    }
}
