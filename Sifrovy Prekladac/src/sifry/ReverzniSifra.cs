using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sifrovy_Prekladac.src.sifry.related;
using Sifrovy_Prekladac.src.static_methods;

namespace Sifrovy_Prekladac.src.sifry
{
    /// <summary>
    /// Třída reprezentující reverzní šifru, odvozená od základní třídy Sifra.
    /// </summary>
    public class ReverzniSifra : Sifra
    {
        #region Konstruktory
        /// <summary>
        /// Konstruktor pro vytvoření instance reverzní šifry.
        /// </summary>
        /// <param name="rawText">Text k zašifrování.</param>
        public ReverzniSifra(string rawText) : base()
        {
            DecText = TextMethods.WithoutDiacriticsToUpper(rawText);
            EncText = Encrypt(DecText);
        }
        /// <summary>
        /// Konstruktor pro vytvoření instance reverzní šifry s možností dešifrování.
        /// </summary>
        /// <param name="rawText">Text k zašifrování nebo dešifrování.</param>
        /// <param name="decipher">Určuje, zda se má provést dešifrování.</param>
        public ReverzniSifra(string rawText, bool decipher) : base()
        {
            if (!decipher)
            {
                DecText = TextMethods.WithoutDiacriticsToUpper(rawText);
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
        /// Metoda pro zašifrování textu pomocí reverzní šifry.
        /// </summary>
        /// <param name="text">Text k zašifrování.</param>
        /// <returns>Zašifrovaný text.</returns>
        /// <exception cref="Exception">Výjimka vrácená, pokud je zadaný typ šifrování nepodporován.</exception>
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
        /// Metoda pro rozšifrování textu pomocí reverzní šifry.
        /// </summary>
        /// <param name="text">Text k rozšifrování.</param>
        /// <returns>Rozšifrovaný text.</returns>
        /// <exception cref="Exception">Výjimka vrácená, pokud je zadaný typ šifrování nepodporován.</exception>
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