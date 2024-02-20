using Sifrovy_Prekladac.src.static_methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.sifry
{
    /// <summary>
    /// Třída reprezentující Prohozenou šifru, odvozená od třídy Sifra.
    /// </summary>
    public class ProhazenaSifra : Sifra
    {
        #region Konstruktory
        /// <summary>
        /// Inicializuje novou instanci ProhazenaSifra s daným nešifrovaným textem.
        /// </summary>
        /// <param name="rawText">Nešifrovaný text.</param>
        public ProhazenaSifra(string rawText) : base()
        {
            DecText = TextMethods.WithoutDiacriticsToUpper(rawText);
            EncText = Encrypt(DecText);
        }
        /// <summary>
        /// Inicializuje novou instanci ProhazenaSifra s daným textem a volbou provést šifrování nebo dešifrování.
        /// </summary>
        /// <param name="rawText">Vstupní text.</param>
        /// <param name="decypher">True, pokud se má provést dešifrování; jinak false.</param>
        public ProhazenaSifra(string rawText, bool decypher) : base()
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
        #region Zašifrování
        /// <summary>
        /// Zašifruje zadaný text podle pravidel pro prohozenou šifru.
        /// </summary>
        /// <param name="text">Text k zašifrování.</param>
        /// <returns>Zašifrovaný text.</returns>
        /// <exception cref="Exception">Vyjímka v případě nepodporovaného typu šifrování.</exception>
        public override string Encrypt(string text)
        {
            char[] chars = text.ToCharArray();
            char[] encryptedText = new char[text.Length];
            switch (TypeOfEnc)
            {
                case "DEF":
                    int x = 0;
                    int y = text.Length - 1;
                    for(int i = 0; i < text.Length; i++)
                    {
                        if(x <= y)
                        {
                            if (i % 2 == 0)
                            {
                                encryptedText[x] = chars[i];
                                x++;
                            }
                            else
                            {
                                encryptedText[y] = chars[i];
                                y--;
                            }
                        }
                    }
                    return new string(encryptedText);

                default:
                    throw new Exception("Nepodporovaný typ šifrování.");
            }                  
        }
        #endregion
        #region Rozšifrování
        /// <summary>
        /// Dešifruje zadaný text podle pravidel pro prohozenou šifru.
        /// </summary>
        /// <param name="text">Zašifrovaný text.</param>
        /// <returns>Dešifrovaný text.</returns>
        /// <exception cref="Exception">Vyjímka v případě nepodporovaného typu šifrování.</exception>
        public override string Decrypt(string text)
        {
            char[] encryptedChars = text.ToCharArray();
            char[] decryptedText = new char[text.Length];
            switch (TypeOfEnc)
            {
                case "DEF":
                    int x = 0;
                    int y = text.Length - 1;
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (x <= y)
                        {
                            if (i % 2 == 0)
                            {
                                decryptedText[i] = encryptedChars[x];
                                x++;
                            }
                            else
                            {
                                decryptedText[i] = encryptedChars[y];
                                y--;
                            }
                        }
                    }
                    return new string(decryptedText);

                default:
                    throw new Exception("Nepodporovaný typ šifrování.");
            }
        }
        #endregion
    }
}
