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
        /// Abeceda, která je použita v některých šifrách
        /// </summary>
        public static char[] abeceda = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        /// <summary>
        /// Text, který je rozšifrovaný
        /// </summary>
        protected string decText;
        /// <summary>
        /// Text, který je zašifrovaný
        /// </summary>
        protected string encText;
        /// <summary>
        /// Klíč, kterým se dá zadaný text zašifrovat, nebo i rozšifrovat
        /// </summary>
        protected List<string> keys = new List<string>();
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
        #endregion
        #region ToString()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
        #region Encrypt/Decrypt methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string Encrypt(string text)
        {
            string output = text;

            return output;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string crypt(string text)
        {
            string output = text;

            return output;
        }
        #endregion
    }
}
