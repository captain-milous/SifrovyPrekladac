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
    /// 
    /// </summary>
    public class MezerovaSifra : Sifra
    {
        #region Proměnné
        /// <summary>
        /// Mezi dvojicí písmen se ukrývá zašifrované písmeno
        /// </summary>
        private static List<string> MezAbc = new List<string>()
        {
            "ZB","AC","BD","CE","DF",
            "EG","FH","GI","HJ","IK",
            "JL","KM","LN","MO","NP",
            "OQ","PR","QS","RT","SU",
            "TV","UW","VX","WY","XZ","YA"
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
                        if (TextMethods.Abeceda.Contains(c))
                        {
                            int index = TextMethods.FindIndexInAlphabet(c);
                            encryptedText.Append(MezAbc[index]);
                            encryptedText.Append(' ');
                        }
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
