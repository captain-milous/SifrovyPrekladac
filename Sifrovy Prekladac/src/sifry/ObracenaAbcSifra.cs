using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sifrovy_Prekladac.src.static_methods;

namespace Sifrovy_Prekladac.src.sifry
{
    /// <summary>
    /// Třída reprezentující Obrácenou Abecední šifru, odvozená od třídy Sifra.
    /// </summary>
    public class ObracenaAbcSifra : Sifra
    {
        #region Proměnné
        /// <summary>
        /// Obrácená Abeceda
        /// </summary>
        static char[] RevAbeceda = TextMethods.Abeceda.Reverse().ToArray();
        #endregion
        #region Konstruktory
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawText"></param>
        public ObracenaAbcSifra(string rawText) : base()
        {
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
            StringBuilder encryptedText = new StringBuilder();
            switch (TypeOfEnc)
            {
                case "DEF":
                    foreach (char c in text)
                    {
                        if (TextMethods.Abeceda.Contains(c))
                        {
                            int index = TextMethods.FindIndexInAlphabet(c);
                            if (index >= 0)
                            {
                                encryptedText.Append(RevAbeceda[index]);
                            }
                        }
                        else
                        {
                            encryptedText.Append(c);
                        }
                    }
                    return encryptedText.ToString();

                default:
                    throw new Exception("Nepodporovaný typ šifrování.");

            }
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
            StringBuilder decryptedText = new StringBuilder();
            switch (TypeOfEnc)
            {
                case "DEF":
                    foreach (char c in text)
                    {
                        if (RevAbeceda.Contains(c))
                        {
                            int index = FindIndexInRevAlphabet(c);
                            if (index >= 0)
                            {
                                decryptedText.Append(TextMethods.Abeceda[index]);
                            }
                        }
                        else
                        {
                            decryptedText.Append(c);
                        }
                    }
                    return decryptedText.ToString();

                default:
                    throw new Exception("Nepodporovaný typ šifrování.");

            }
        }
        #endregion
        /// <summary>
        /// Najde index písmenka v abecedě, která je pozpátku. Pokud ale není v této abecedě, tak vrátí -1
        /// </summary>
        /// <param name="input">Písmeno v abecedě</param>
        /// <returns>Index písmena</returns>
        private int FindIndexInRevAlphabet(char input)
        {
            string letter = input.ToString().ToUpper();
            for (int i = 0; i < RevAbeceda.Length; i++)
            {
                if (RevAbeceda[i].ToString() == letter)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
