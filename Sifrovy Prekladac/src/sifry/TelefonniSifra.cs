using Sifrovy_Prekladac.src.static_methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.sifry
{
    public class TelefonniSifra : Sifra
    {
        #region Proměnné  
        /// <summary>
        /// 
        /// </summary>
        private static string[] typyTelefonu = { "TEL", "TEL2" };
        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<char, string> Telephone = new Dictionary<char, string>()
        {
            {'A', "2"},
            {'B', "22"},
            {'C', "222"},
            {'D', "3"},
            {'E', "33"},
            {'F', "333"},
            {'G', "4"},
            {'H', "44"},
            {'I', "444"},
            {'J', "5"},
            {'K', "55"},
            {'L', "555"},
            {'M', "6"},
            {'N', "66"},
            {'O', "666"},
            {'P', "7"},
            {'Q', "77"},
            {'R', "777"},
            {'S', "7777"},
            {'T', "8"},
            {'U', "88"},
            {'V', "888"},
            {'W', "9"},
            {'X', "99"},
            {'Y', "999"},
            {'Z', "9999"}
        };
        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<char, string> Telephone2 = new Dictionary<char, string>()
        {
            {'A', "12"},
            {'B', "22"},
            {'C', "32"},
            {'D', "13"},
            {'E', "23"},
            {'F', "33"},
            {'G', "14"},
            {'H', "24"},
            {'I', "34"},
            {'J', "15"},
            {'K', "25"},
            {'L', "35"},
            {'M', "16"},
            {'N', "26"},
            {'O', "36"},
            {'P', "17"},
            {'Q', "27"},
            {'R', "37"},
            {'S', "47"},
            {'T', "18"},
            {'U', "28"},
            {'V', "38"},
            {'W', "19"},
            {'X', "29"},
            {'Y', "39"},
            {'Z', "49"}
        };
        #endregion
        #region Konstruktory
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawText"></param>
        /// <param name="type"></param>
        public TelefonniSifra(string rawText, string type) : base(typyTelefonu, type)
        {
            DecText = TextMethods.WithoutSpaces(TextMethods.Simplify(rawText));
            EncText = Encrypt(DecText);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawText"></param>
        /// <param name="type"></param>
        /// <param name="decipher"></param>
        public TelefonniSifra(string rawText, string type, bool decipher) : base(typyTelefonu, type)
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
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public override string Encrypt(string text)
        {
            StringBuilder encryptedText = new StringBuilder();
            switch (TypeOfEnc)
            {
                case "TEL":

                    foreach (char c in text)
                    {
                        string eChar = Telephone[c];
                        encryptedText.Append(eChar);
                        encryptedText.Append(' ');
                    }
                    return encryptedText.ToString();

                case "TEL2":

                    foreach (char c in text)
                    {
                        string eChar = Telephone2[c];
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
                case "TEL":

                    string[] encryptedChars = text.Trim().Split(' ');
                    foreach (string eChar in encryptedChars)
                    {
                        char originalChar = Telephone.FirstOrDefault(x => x.Value == eChar).Key;
                        decryptedText.Append(originalChar);
                    }
                    return decryptedText.ToString();

                case "TEL2":

                    encryptedChars = text.Trim().Split(' ');
                    foreach (string eChar in encryptedChars)
                    {
                        char originalChar = Telephone2.FirstOrDefault(x => x.Value == eChar).Key;
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
