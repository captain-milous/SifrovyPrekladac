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

        }
        public MorseovaSifra(string rawText, string metoda, bool decypher) : base(typyMorseovky, metoda)
        {

        }

        public override string Encrypt(string text)
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
            return base.Encrypt(text);
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
