using Sifrovy_Prekladac.src.myMethods;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawText"></param>
        /// <param name="decypher"></param>
        public MorseovaSifra(string rawText, bool decypher) : base(typyMorseovky, "DEF")
        {
            if (!decypher)
            {
                rawText = TextMethods.Simplify(rawText);
                DecText = rawText;
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
        /// <param name="metoda"></param>
        /// <param name="decypher"></param>
        public MorseovaSifra(string rawText, string metoda, bool decypher) : base(typyMorseovky, metoda)
        {
            if (!decypher)
            {
                rawText = TextMethods.Simplify(rawText);
                DecText = rawText;
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
                    MorseovaSifra def = new MorseovaSifra(text, false);
                    string morseText = def.EncText;
                    foreach (char c in morseText)
                    {
                        if(c == '.')
                        {
                            output += "-";
                        }
                        else if(c == '-')
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
                    def = new MorseovaSifra(text, false);
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

        public override string Decrypt(string text) 
        {
            switch (TypeOfEnc)
            {
                case "DEF":

                    break;
                case "REV":

                    break;
                case "NUM":

                    break;
                default:
                    throw new Exception("Nepodporovaný typ šifrování.");
            }
            return base.Decrypt(text); 
        }
    }
}
