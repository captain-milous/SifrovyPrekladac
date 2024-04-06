using Sifrovy_Prekladac.src.static_methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sifrovy_Prekladac.src.static_methods;
using Sifrovy_Prekladac.src.sifry.related;

namespace Sifrovy_Prekladac.src.sifry
{
    /// <summary>
    /// Třída reprezentující Mezerovou šifru, odvozená od třídy Sifra.
    /// </summary>
    public class MezerovaSifra : Sifra
    {
        #region Slovník
        /// <summary>
        /// Abecední mapování znaků pro Mezerovou šifru.
        /// </summary>
        private static Dictionary<char,string> MezAbc = new Dictionary<char, string>() 
        {
            {'A', "ZB"}, 
            {'B', "AC"}, 
            {'C', "BD"}, 
            {'D', "CE"},
            {'E', "DF"},
            {'F', "EG"}, 
            {'G', "FH"}, 
            {'H', "GI"}, 
            {'I', "HJ"}, 
            {'J', "IK"},
            {'K', "JL"}, 
            {'L', "KM"}, 
            {'M', "LN"}, 
            {'N', "MO"}, 
            {'O', "NP"},
            {'P', "OQ"}, 
            {'Q', "PR"}, 
            {'R', "QS"}, 
            {'S', "RT"}, 
            {'T', "SU"},
            {'U', "TV"}, 
            {'V', "UW"}, 
            {'W', "VX"}, 
            {'X', "WY"}, 
            {'Y', "XZ"},
            {'Z', "YA"}
        };
        #endregion
        #region Konstruktory
        /// <summary>
        /// Inicializuje novou instanci MezeroveSifry se zadaným nešifrovaným textem.
        /// </summary>
        /// <param name="rawText">Nešifrovaný text.</param>
        public MezerovaSifra(string rawText) : base()
        {
            DecText = TextMethods.SimplifyWithoutSpaces(rawText);
            EncText = Encrypt(DecText);
        }
        /// <summary>
        /// Inicializuje novou instanci MezeroveSifry se zadaným textem a určením, zda se má text zašifrovat nebo dešifrovat.
        /// </summary>
        /// <param name="rawText">Vstupní text.</param>
        /// <param name="decipher">True, pokud se má provést dešifrování; jinak false.</param>
        public MezerovaSifra(string rawText, bool decipher) : base()
        {
            if (!decipher)
            {
                DecText = TextMethods.SimplifyWithoutSpaces(rawText);
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
        /// Zašifruje zadaný text Mezerovou šifrou.
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
                        string eChar = MezAbc[c];
                        encryptedText.Append(eChar);
                        encryptedText.Append(' ');
                    }
                    return encryptedText.ToString();

                default:
                    throw new Exception("Nepodporovaný typ šifrování.");

            }
        }
        #endregion
        #region Rozšifrování
        /// <summary>
        /// Dešifruje zadaný text Mezerovou šifrou.
        /// </summary>
        /// <param name="text">Zašifrovaný text.</param>
        /// <returns>Dešifrovaný text.</returns>
        /// <exception cref="Exception">Vyjímka v případě nepodporovaného typu šifrování.</exception>
        public override string Decrypt(string text)
        {
            StringBuilder decryptedText = new StringBuilder();
            switch (TypeOfEnc)
            {
                case "DEF":

                    string[] encryptedChars = text.Trim().Split(' ');
                    foreach (string eChar in encryptedChars)
                    {
                        char originalChar = MezAbc.FirstOrDefault(x => x.Value == eChar).Key;
                        decryptedText.Append(originalChar);
                    }
                    return decryptedText.ToString();

                default:
                    throw new Exception("Nepodporovaný typ šifrování.");
            }
        }
        #endregion
    }
}
