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
    /// 
    /// </summary>
    public class MorseovaSifra : Sifra
    {
        #region Slovník a List
        /// <summary>
        /// 
        /// </summary>
        private static string[] typyMorseovky = { "DEF", "REV", "NUM" };
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="rawText"></param>
        public MorseovaSifra(string rawText) : base(typyMorseovky, "DEF")
        {
            DecText = TextMethods.WithoutDiacriticsToUpper(rawText);
            EncText = Encrypt(rawText);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawText"></param>
        /// <param name="decypher"></param>
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
        /// 
        /// </summary>
        /// <param name="rawText"></param>
        /// <param name="type"></param>
        /// <param name="decypher"></param>
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
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

                    output = encryptedText.ToString();
                    break;
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

                    break;
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

                    break;
                default:
                    throw new Exception("Nepodporovaný typ šifrování.");
            }

            return output;
        }
        #endregion 
        #region Rozšifrování
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
                        else
                        {
                            output += c;
                        }
                    }

                    return "Prozatím mimo provoz.";

                default:
                    throw new Exception("Nepodporovaný typ šifrování.");
            }
        }
        #endregion 
    }
}
