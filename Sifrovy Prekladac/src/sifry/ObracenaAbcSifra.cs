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
        /// Inicializuje novou instanci ObracenaAbcSifra s daným nešifrovaným textem.
        /// </summary>
        /// <param name="rawText">Nešifrovaný text.</param>
        public ObracenaAbcSifra(string rawText) : base()
        {
            DecText = TextMethods.WithoutDiacriticsToUpper(rawText);
            EncText = Encrypt(DecText);
        }
        /// <summary>
        /// Inicializuje novou instanci ObracenaAbcSifra s daným textem a volbou provést šifrování nebo dešifrování.
        /// </summary>
        /// <param name="rawText">Vstupní text.</param>
        /// <param name="decypher">True, pokud se má provést dešifrování; jinak false.</param>
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
        /// Zašifruje zadaný text podle pravidel pro obrácenou abecední šifru.
        /// </summary>
        /// <param name="text">Text k zašifrování.</param>
        /// <returns>Zašifrovaný text.</returns>
        /// <exception cref="Exception">Vyjímka v případě nepodporovaného typu šifrování.</exception>
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
        /// Dešifruje zadaný text podle pravidel pro obrácenou abecední šifru.
        /// </summary>
        /// <param name="text">Zašifrovaný text.</param>
        /// <returns>Dešifrovaný text.</returns>
        /// <exception cref="Exception">Vyjímka v případě nepodporovaného typu šifrování.</exception>
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
