using Sifrovy_Prekladac.src.sifry.related;
using Sifrovy_Prekladac.src.static_methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.sifry
{
    /// <summary>
    /// Třída pro šifrování a dešifrování textu pomocí Morseovy šifry.
    /// </summary>
    public class MorseovaSifra : Sifra
    {
        #region Slovník a List
        /// <summary>
        /// Pole obsahující typy Morseovy šifry.
        /// </summary>
        private static string[] typyMorseovky = { "DEF", "REV", "NUM" };
        /// <summary>
        /// Slovník obsahující přiřazení znaků k jejich Morseově kódům.
        /// </summary>
        private static Dictionary<char, string> MorseABC = new Dictionary<char, string>()
        {
            {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."},
            {'F', "..-."}, {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"},
            {'K', "-.-"}, {'L', ".-.."}, {'M', "--"}, {'N', "-."}, {'O', "---"},
            {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
            {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"}, {'Y', "-.--"},
            {'Z', "--.."}, {'0', "-----"}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"},
            {'4', "....-"}, {'5', "....."}, {'6', "-...."}, {'7', "--..."}, {'8', "---.."},
            {'9', "----."}
        };
        #endregion
        #region Konstruktory/// <summary>
        /// <summary>
        /// Konstruktor pro vytvoření instance Morseovy šifry.
        /// </summary>
        /// <param name="rawText">Vstupní text, který má být zašifrován.</param>
        public MorseovaSifra(string rawText) : base(typyMorseovky, "DEF")
        {
            DecText = TextMethods.WithoutDiacriticsToUpper(rawText);
            EncText = Encrypt(rawText);
        }
        /// <summary>
        /// Konstruktor pro vytvoření instance Morseovy šifry s možností dešifrování.
        /// </summary>
        /// <param name="rawText">Vstupní text, který má být zašifrován nebo dešifrován.</param>
        /// <param name="decypher">Určuje, zda se má provést dešifrování.</param>
        public MorseovaSifra(string rawText, bool decypher) : base(typyMorseovky, "DEF")
        {
            if (!decypher)
            {
                DecText = TextMethods.WithoutDiacriticsToUpper(rawText);
                EncText = Encrypt(rawText);
            }
            else
            {
                EncText = rawText;
                DecText = Decrypt(rawText);
            }
        }
        /// <summary>
        /// Konstruktor pro vytvoření instance Morseovy šifry s možností volby typu šifrování a dešifrování.
        /// </summary>
        /// <param name="rawText">Vstupní text, který má být zašifrován nebo dešifrován.</param>
        /// <param name="type">Typ Morseovy šifry (DEF, REV, NUM).</param>
        /// <param name="decypher">Určuje, zda se má provést dešifrování.</param>
        public MorseovaSifra(string rawText, string type, bool decypher) : base(typyMorseovky, type)
        {
            if (!decypher)
            {
                DecText = TextMethods.WithoutDiacriticsToUpper(rawText);
                EncText = Encrypt(rawText);
            }
            else
            {
                EncText = rawText;
                DecText = Decrypt(rawText);
            }
        }
        #endregion
        #region Zašifrování
        /// <summary>
        /// Metoda pro zašifrování vstupního textu pomocí Morseovy šifry.
        /// </summary>
        /// <param name="text">Vstupní text, který má být zašifrován.</param>
        /// <returns>Šifrovaný text ve formátu Morseovy šifry.</returns>
        /// <exception cref="Exception">Vyjímka, která se vyvolá, pokud je zadaný typ šifrování nepodporovaný.</exception>
        public override string Encrypt(string text)
        {
            string output = string.Empty;
            switch (TypeOfEnc)
            {
                case "DEF":
                    StringBuilder encryptedText = new StringBuilder();
                    foreach (char c in text.ToUpper())
                    {
                        if (MorseABC.ContainsKey(c))
                        {
                            encryptedText.Append(MorseABC[c]);
                            encryptedText.Append(" | ");
                        }
                        else if (c == ' ')
                        {
                            encryptedText.Remove(encryptedText.Length - 1, 1);
                            encryptedText.Append("| ");
                        }
                    }
                    encryptedText.Remove(encryptedText.Length - 1, 1);
                    encryptedText.Append("|| ");

                    return encryptedText.ToString();
                case "REV":
                    MorseovaSifra def = new MorseovaSifra(text);
                    string morseText = def.EncText;
                    foreach (char c in morseText)
                    {
                        if (c == '.')
                        {
                            output += "-";
                        }
                        else if (c == '-')
                        {
                            output += ".";
                        }
                        else
                        {
                            output += c;
                        }
                    }

                    return output;
                case "NUM":
                    def = new MorseovaSifra(text);
                    morseText = def.EncText;
                    foreach (char c in morseText)
                    {
                        if (c == '.')
                        {
                            output += "0";
                        }
                        else if (c == '-')
                        {
                            output += "1";
                        }
                        else if (c == '|')
                        {
                            output += "";
                        }
                        else
                        {
                            output += c;
                        }
                    }

                    return output;
                default:
                    throw new Exception("Nepodporovaný typ šifrování.");
            }
        }
        #endregion
        #region Rozšifrování
        /// <summary>
        /// Metoda pro dešifrování vstupního textu zašifrovaného pomocí Morseovy šifry.
        /// </summary>
        /// <param name="text">Zašifrovaný text ve formátu Morseovy šifry.</param>
        /// <returns>Dešifrovaný text.</returns>
        /// <exception cref="Exception">Vyjímka, která se vyvolá, pokud je zadaný typ šifrování nepodporovaný.</exception>
        public override string Decrypt(string text)
        {
            StringBuilder decryptedText = new StringBuilder();
            switch (TypeOfEnc)
            {
                case "DEF":
                    string[] words = text.Split(new string[] { "||" }, StringSplitOptions.None);

                    foreach (string word in words)
                    {
                        string[] letters = word.Split(new string[] { "| " }, StringSplitOptions.None);
                        foreach (string letter in letters)
                        {
                            string[] codes = letter.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string code in codes)
                            {
                                foreach (KeyValuePair<char, string> kvp in MorseABC)
                                {
                                    if (code == kvp.Value)
                                    {
                                        decryptedText.Append(kvp.Key);
                                        break;
                                    }
                                }
                            }
                            decryptedText.Append(" ");
                        }
                        decryptedText.Remove(decryptedText.Length - 1, 1); // Odstranění poslední mezery za slovem
                        decryptedText.Append(" ");
                    }
                    decryptedText.Remove(decryptedText.Length - 1, 1); // Odstranění poslední mezery za větou

                    return decryptedText.ToString();

                case "REV":
                    string output = string.Empty;
                    foreach (char c in text)
                    {
                        if (c == '.')
                        {
                            output += "-";
                        }
                        else if (c == '-')
                        {
                            output += ".";
                        }
                        else
                        {
                            output += c;
                        }
                    }
                    MorseovaSifra def = new MorseovaSifra(output, true);

                    return def.DecText;
                    
                case "NUM":
                    output = string.Empty;
                    foreach (char c in text)
                    {
                        if (c == '0')
                        {
                            output += ".";
                        }
                        else if (c == '1')
                        {
                            output += "-";
                        }
                        else if (c == ' ')
                        {
                            output += "|";
                        }
                        else
                        {
                            output += c;
                        }
                    }
                    def = new MorseovaSifra(output, true);

                    return def.DecText;

                default:
                    throw new Exception("Nepodporovaný typ šifrování.");
            }
        }
        #endregion 
    }
}
