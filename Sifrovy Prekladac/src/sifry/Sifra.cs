using Sifrovy_Prekladac.src.static_methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.sifry
{
    /// <summary>
    /// Třída pro šifrování a dešifrování textu.
    /// </summary>
    public class Sifra
    {
        #region Proměnné
        protected List<string> AllowedTypes = new List<string>();
        /// <summary>
        /// Určuje typ použitého šifrovacího algoritmu.
        /// </summary>
        public string TypeOfEnc { get; set; }
        /// <summary>
        /// Dešifrovaný text.
        /// </summary>
        public string DecText { get; set; }
        /// <summary>
        /// Zašifrovaný text.
        /// </summary>
        public string EncText { get; set; }
        #endregion
        #region Konstruktory
        /// <summary>
        /// Vytvoří instanci třídy Sifra s výchozími hodnotami.
        /// </summary>
        public Sifra()
        {
            TypeOfEnc = "DEF";
            DecText = string.Empty;
            EncText = string.Empty;
        }
        /// <summary>
        /// Vytvoří instanci třídy Sifra s definovanými povolenými typy a typem šifrování.
        /// </summary>
        /// <param name="allowed">Pole povolených typů šifrování.</param>
        /// <param name="type">Typ šifrování.</param>
        public Sifra(string[] allowed, string type)
        {
            AllowedTypes = new List<string>(allowed);
            TypeOfEnc = type;
            DecText = string.Empty;
            EncText = string.Empty;
        }
        /// <summary>
        /// Vytvoří instanci třídy Sifra na základě zadaného textu a parametru pro dešifrování.
        /// </summary>
        /// <param name="rawText">Základní text k zašifrování nebo dešifrování.</param>
        /// <param name="decypher">Určuje, zda se má provést dešifrování.</param>
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
        /// Vrací textovou reprezentaci instance třídy Sifra.
        /// </summary>
        /// <returns>Dešifrovaný text a zašifrovaný text oddělené " => ".</returns>
        public override string ToString()
        {
            return DecText + " => " + EncText;
        }
        #endregion
        #region Encrypt/Decrypt methods
        /// <summary>
        /// Zašifruje zadaný text.
        /// </summary>
        /// <param name="text">Text k zašifrování.</param>
        /// <returns>Šifrovaný text.</returns>
        public virtual string Encrypt(string text)
        {
            string output = text;

            return output;
        }
        /// <summary>
        /// Dešifruje zadaný text.
        /// </summary>
        /// <param name="text">Text k dešifrování.</param>
        /// <returns>Dešifrovaný text.</returns>
        public virtual string Decrypt(string text)
        {
            string output = text;

            return output;
        }
        #endregion
    }
}
