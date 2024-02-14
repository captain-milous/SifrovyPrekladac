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
    public class Sifra
    {
        #region Proměnné
        protected List<string> AllowedTypes = new List<string>();
        /// <summary>
        /// Klíč, kterým se dá zadaný text zašifrovat, nebo i rozšifrovat
        /// </summary>
        public string TypeOfEnc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DecText { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EncText { get; set; }
        #endregion
        #region Konstruktory
        /// <summary>
        /// 
        /// </summary>
        public Sifra()
        {
            TypeOfEnc = "DEF";
            DecText = string.Empty;
            EncText = string.Empty;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="allowed"></param>
        /// <param name="type"></param>
        public Sifra(string[] allowed, string type)
        {
            AllowedTypes = new List<string>(allowed);
            TypeOfEnc = type;
            DecText = string.Empty;
            EncText = string.Empty;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawText"></param>
        /// <param name="decypher"></param>
        public Sifra(string rawText, bool decypher)
        {
            TypeOfEnc = "DEF";
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
        public virtual string Encrypt(string text)
        {
            string output = text;

            return output;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public virtual string Decrypt(string text)
        {
            string output = text;

            return output;
        }
        #endregion
    }
}
