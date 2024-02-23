using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Sifrovy_Prekladac.src.sifry.related;
using Sifrovy_Prekladac.src.static_methods;

namespace Sifrovy_Prekladac.src.sifry
{
    /// <summary>
    /// Třída reprezentující Numerickou šifru, odvozená od třídy Sifra.
    /// </summary>
    public class NumerickaSifra : Sifra
    {
        #region Slovník a List
        /// <summary>
        /// Pole typů šifry.
        /// DEF (Default): V této metodě se každý znak vstupního textu převádí na odpovídající číslo, které odpovídá jeho pozici v abecedě, plus jedna (protože pozice v abecedě začíná od nuly). Tato čísla jsou oddělena mezerami. 
        /// BTR (Better): Stejně jako u metody DEF, ale pokud je výsledné číslo jednociferné, je před něj přidána nula, aby byla zachována konzistence délky čísel. Opět jsou čísla oddělena mezerami. 
        /// ROM (Římské číslice): Tato metoda převádí každý znak vstupního textu na odpovídající římskou číslici, pokud je znak platným indexem v dictionary RimskaCisla. Výsledné římské číslice jsou odděleny mezerami. 
        /// SPI (Spirálová ABC, neboli Random): Zde se každý znak vstupního textu převádí na číslo podle pozice v abecedě (opět s přičtením jedna), a k tomuto číslu je přičten náhodný počet násobků délky abecedy. Pokud je výsledné číslo větší nebo rovno 100, je odečtena délka abecedy. Čísla jsou oddělena mezerami.
        /// </summary>
        private static string[] typySifry = { "DEF", "BTR", "ROM", "HEX", "SPI" };
        /// <summary>
        /// Slovník obsahující převodní tabulku čísel na římské číslice.
        /// </summary>
        private Dictionary<int, string> RimskaCisla = new Dictionary<int, string>() 
        {
            {1, "I"},
            {2, "II"},
            {3, "III"},
            {4, "IV"},
            {5, "V"},
            {6, "VI"},
            {7, "VII"},
            {8, "VIII"},
            {9, "IX"},
            {10, "X"},
            {11, "XI"},
            {12, "XII"},
            {13, "XIII"},
            {14, "XIV"},
            {15, "XV"},
            {16, "XVI"},
            {17, "XVII"},
            {18, "XVIII"},
            {19, "XIX"},
            {20, "XX"},
            {21, "XXI"},
            {22, "XXII"},
            {23, "XXIII"},
            {24, "XXIV"},
            {25, "XXV"},
            {26, "XXVI"}
        };
        /// <summary>
        /// Slovník obsahující převodní tabulku čísel na hexadecimalní číslice.
        /// </summary>
        private Dictionary<int, string> HexCisla = new Dictionary<int, string>()
        {
            {1, "01"},
            {2, "02"},
            {3, "03"},
            {4, "04"},
            {5, "05"},
            {6, "06"},
            {7, "07"},
            {8, "08"},
            {9, "09"},
            {10, "0A"},
            {11, "0B"},
            {12, "0C"},
            {13, "0D"},
            {14, "0E"},
            {15, "0F"},
            {16, "10"},
            {17, "11"},
            {18, "12"},
            {19, "13"},
            {20, "14"},
            {21, "15"},
            {22, "16"},
            {23, "17"},
            {24, "18"},
            {25, "19"},
            {26, "1A"}
        };
        #endregion
        #region Konstrukrory
        /// <summary>
        /// Inicializuje novou instanci NumerickaSifra s daným nešifrovaným textem a typem šifry.
        /// </summary>
        /// <param name="rawText">Nešifrovaný text.</param>
        /// <param name="type">Typ šifry.</param>
        public NumerickaSifra(string rawText, string type) : base(typySifry, type)
        {
            DecText = TextMethods.SimplifyWithoutSpaces(rawText);
            EncText = Encrypt(rawText);
        }
        /// <summary>
        /// Inicializuje novou instanci NumerickaSifra s daným textem, typem šifry a volbou provést šifrování nebo dešifrování.
        /// </summary>
        /// <param name="rawText">Vstupní text.</param>
        /// <param name="type">Typ šifry.</param>
        /// <param name="decipher">True, pokud se má provést dešifrování; jinak false.</param>
        public NumerickaSifra(string rawText, string type, bool decypher) : base(typySifry, type)
        {
            if (!decypher)
            {
                DecText = TextMethods.SimplifyWithoutSpaces(rawText);
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
        /// Zašifruje zadaný text podle typu šifry.
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
                                int num = index + 1;
                                encryptedText.Append(num.ToString());
                                encryptedText.Append(' ');
                            }
                        }
                    }
                    return encryptedText.ToString();
                case "BTR":
                    foreach (char c in text)
                    {
                        if (TextMethods.Abeceda.Contains(c))
                        {
                            int index = TextMethods.FindIndexInAlphabet(c);
                            if (index >= 0)
                            {
                                int num = index + 1;
                                string sNum = string.Empty;
                                if(num < 10)
                                {
                                    sNum = "0" + num.ToString(); 
                                }
                                else
                                {
                                    sNum = num.ToString();
                                }
                                encryptedText.Append(sNum);
                                encryptedText.Append(' ');
                            }
                        }
                    }
                    return encryptedText.ToString();
                case "ROM":
                    foreach (char c in text)
                    {
                        string eChar = RimskaCisla[c];
                        encryptedText.Append(eChar);
                        encryptedText.Append(' ');
                    }
                    return encryptedText.ToString();
                case "SPI":
                    foreach (char c in text)
                    {
                        if (TextMethods.Abeceda.Contains(c))
                        {
                            int index = TextMethods.FindIndexInAlphabet(c);
                            if (index >= 0)
                            {
                                int num = index + 1;
                                Random rnd = new Random();
                                num += TextMethods.Abeceda.Length * rnd.Next(0, 4);
                                if(num >= 100)
                                {
                                    num -= TextMethods.Abeceda.Length;
                                }
                                encryptedText.Append(num.ToString());
                                encryptedText.Append(' ');
                            }
                        }
                    }
                    return encryptedText.ToString();
                case "HEX":
                    foreach (char c in text)
                    {
                        string eChar = HexCisla[c];
                        encryptedText.Append(eChar);
                        encryptedText.Append(' ');
                    }
                    return encryptedText.ToString();
                default:
                    throw new Exception("Nepodporovaný typ šifrování.");
            }
        }
        #endregion
        /// <summary>
        /// Dešifruje zadaný text podle typu šifry.
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
                    string[] numbers = text.Trim().Split(' ');
                    foreach (string num in numbers)
                    {
                        if (int.TryParse(num, out int index))
                        {
                            if (index >= 1 && index <= TextMethods.Abeceda.Length)
                            {
                                decryptedText.Append(TextMethods.Abeceda[index - 1]);
                            }
                        }
                    }
                    return decryptedText.ToString();
                case "BTR":
                    string[] numbersBTR = text.Trim().Split(' ');
                    foreach (string num in numbersBTR)
                    {
                        if (int.TryParse(num, out int index))
                        {
                            if (index >= 1 && index <= TextMethods.Abeceda.Length)
                            {
                                decryptedText.Append(TextMethods.Abeceda[index - 1]);
                            }
                        }
                    }
                    return decryptedText.ToString();
                case "ROM":
                    string[] romans = text.Trim().Split(' ');
                    foreach (string roman in romans)
                    {
                        foreach (var kvp in RimskaCisla)
                        {
                            if (kvp.Value == roman)
                            {
                                int index = kvp.Key;
                                decryptedText.Append(TextMethods.Abeceda[index - 1]);
                                break;
                            }
                        }
                    }
                    return decryptedText.ToString();
                case "HEX":
                    string[] hexNums = text.Trim().Split(' ');
                    foreach (string hexNum in hexNums)
                    {
                        foreach (var kvp in RimskaCisla)
                        {
                            if (kvp.Value == hexNum)
                            {
                                int index = kvp.Key;
                                decryptedText.Append(TextMethods.Abeceda[index - 1]);
                                break;
                            }
                        }
                    }
                    return decryptedText.ToString();
                case "SPI":
                    string[] numbersSPI = text.Trim().Split(' ');
                    foreach (string number in numbersSPI)
                    {
                        if (int.TryParse(number, out int num))
                        {
                            int originalIndex = (num - 1) % TextMethods.Abeceda.Length;
                            char decryptedChar = TextMethods.Abeceda[originalIndex];
                            decryptedText.Append(decryptedChar);
                        }
                    }
                    return decryptedText.ToString();
                default:
                    throw new Exception("Nepodporovaný typ šifrování.");
            }
        }
    }
}
