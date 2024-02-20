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
    public class ObracenaAbcSifra : Sifra
    {
        #region Proměnné
        /// <summary>
        /// 
        /// </summary>
        static char[] RevAbeceda = TextMethods.Abeceda;
        #endregion
        #region Konstruktory
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawText"></param>
        public ObracenaAbcSifra(string rawText) : base()
        {
            Array.Reverse(RevAbeceda);
            Console.WriteLine(RevAbeceda.ToString());

            DecText = TextMethods.WithoutDiacriticsToUpper(rawText);
            EncText = Encrypt(DecText);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawText"></param>
        /// <param name="decypher"></param>
        public ObracenaAbcSifra(string rawText, bool decypher) : base()
        {
            Array.Reverse(RevAbeceda);
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
        #region Šifrování
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public override string Encrypt(string text)
        {
            return base.Encrypt(text);
        }
        #endregion
        #region dešifrování
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public override string Decrypt(string text)
        {
            return base.Decrypt(text);
        }
        #endregion
    }
}
