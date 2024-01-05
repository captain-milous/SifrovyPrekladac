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
    public class Sifra
    {
        #region Proměnné
        /// <summary>
        /// Klíč, kterým se dá zadaný text zašifrovat, nebo i rozšifrovat
        /// </summary>
        protected List<string> encMethods = new List<string>();
        /// <summary>
        /// 
        /// </summary>
        public string DecText { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public string EncText { get; private set; }
        #endregion
        #region Konstruktory
        /// <summary>
        /// 
        /// </summary>
        public Sifra()
        {
            DecText = string.Empty;
            EncText = string.Empty;
        }
        public Sifra(string rawText, bool decypher)
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
        #endregion
        #region ToString()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return DecText + " => " + EncText;
        }
        #endregion
        #region Encrypt/Decrypt methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected string Encrypt(string text)
        {
            string output = text;

            return output;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected string Decrypt(string text)
        {
            string output = text;

            return output;
        }
        #endregion
    }
}
