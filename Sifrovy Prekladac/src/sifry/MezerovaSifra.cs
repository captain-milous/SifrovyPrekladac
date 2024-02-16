using Sifrovy_Prekladac.src.static_methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sifrovy_Prekladac.src.static_methods;

namespace Sifrovy_Prekladac.src.sifry
{
    /// <summary>
    /// Dodělat!
    /// </summary>
    public class MezerovaSifra : Sifra
    {
        #region Proměnné
        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<char,string> MezAbc = new Dictionary<char, string>() 
        {
            {'A', "ZB"}, 
            {'B', "AC"}, 
            {'C', "BD"}, 
            {'D', "CE"},
            {'E', "DF"},
            {'F', "EG"}, 
            {'G', "FH"}, 
            {'H', "GI"}, 
            {'I', "HJ"}, 
            {'J', "IK"},
            {'K', "JL"}, 
            {'L', "KM"}, 
            {'M', "LN"}, 
            {'N', "MO"}, 
            {'O', "NP"},
            {'P', "OQ"}, 
            {'Q', "PR"}, 
            {'R', "QS"}, 
            {'S', "RT"}, 
            {'T', "SU"},
            {'U', "TV"}, 
            {'V', "UW"}, 
            {'W', "VX"}, 
            {'X', "WY"}, 
            {'Y', "XZ"},
            {'Z', "YA"}
        };
        #endregion
        #region Konstruktory
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawText"></param>
        public MezerovaSifra(string rawText) : base()
        {
            DecText = TextMethods.WithoutSpaces(TextMethods.Simplify(rawText));
            EncText = Encrypt(DecText);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawText"></param>
        /// <param name="decipher"></param>
        public MezerovaSifra(string rawText, bool decipher) : base()
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
                case "DEF":
                    foreach (char c in text)
                    {
                        string eChar = MezAbc[c];
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
                case "DEF":

                    return decryptedText.ToString();

                default:
                    throw new Exception("Nepodporovaný typ šifrování.");

            }
        }
        #endregion
    }
}
