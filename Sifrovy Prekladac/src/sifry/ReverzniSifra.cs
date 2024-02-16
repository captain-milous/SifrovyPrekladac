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
    public class ReverzniSifra : Sifra
    {
        #region Konstruktory
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawText"></param>
        public ReverzniSifra(string rawText) : base()
        {
            DecText = TextMethods.Simplify(rawText);
            EncText = Encrypt(DecText);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawText"></param>
        /// <param name="decipher"></param>
        public ReverzniSifra(string rawText, bool decipher) : base()
        {
            if (!decipher)
            {
                DecText = TextMethods.Simplify(rawText);
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
            switch (TypeOfEnc)
            {
                case "DEF":

                    char[] charArray = text.ToCharArray();
                    Array.Reverse(charArray);
                    return new string(charArray);

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
            switch (TypeOfEnc)
            {
                case "DEF":

                    char[] charArray = text.ToCharArray();
                    Array.Reverse(charArray);
                    return new string(charArray);

                default:
                    throw new Exception("Nepodporovaný typ šifrování.");

            }
        }
        #endregion
    }
}