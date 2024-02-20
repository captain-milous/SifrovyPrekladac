using Sifrovy_Prekladac.src.static_methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Sifrovy_Prekladac.src.sifry
{
    /// <summary>
    /// Třída reprezentující šifrovací algoritmus pomocí Petronilka šifry.
    /// </summary>
    public class PetronilkaSifra : Sifra
    {
        #region Proměnné
        /// <summary>
        /// Klíčové slovo použité pro šifrování.
        /// </summary>
        private string _klicSlovo = "PETRONILKA";
        /// <summary>
        /// Veřejná vlastnost pro přístup k klíčovému slovu použitému pro šifrování.
        /// </summary>
        public string KlicSlovo { get { return _klicSlovo; } set { _klicSlovo = value; } }
        /// <summary>
        /// Mapování písmen na jejich pozici v klíčovém slově.
        /// </summary>
        Dictionary<char, int> mapovaniPismen = new Dictionary<char, int>();
        #endregion
        #region Konstruktory
        /// <summary>
        /// Konstruktor pro inicializaci objektu třídy PetronilkaSifra s vstupním textem.
        /// </summary>
        /// <param name="rawText">Vstupní text k zašifrování.</param>
        /// <exception cref="Exception">Výjimka je vyvolána, pokud klíčové slovo neodpovídá požadavkům.</exception>
        public PetronilkaSifra(string rawText) : base()
        {
            if (CheckKey(KlicSlovo))
            {
                string unikatniPismena = new string(KlicSlovo.Distinct().ToArray());
                for (int i = 0; i < unikatniPismena.Length; i++)
                {
                    mapovaniPismen.Add(unikatniPismena[i], i);
                }
                DecText = TextMethods.WithoutDiacriticsToUpper(rawText);
                EncText = Encrypt(DecText);
            }
            else
            {
                throw new Exception("Klíčové slovo neodpovídá požadavkům.");
            }
        }
        /// <summary>
        /// Konstruktor pro inicializaci objektu třídy PetronilkaSifra s vstupním textem a specifikovaným klíčovým slovem.
        /// </summary>
        /// <param name="rawText">Vstupní text k zašifrování.</param>
        /// <param name="key">Klíčové slovo pro šifrování.</param>
        /// <exception cref="Exception">Výjimka je vyvolána, pokud klíčové slovo neodpovídá požadavkům.</exception>
        public PetronilkaSifra(string rawText, string key) : base()
        {
            KlicSlovo = key;
            if (CheckKey(KlicSlovo))
            {
                string unikatniPismena = new string(KlicSlovo.Distinct().ToArray());
                for (int i = 0; i < unikatniPismena.Length; i++)
                {
                    mapovaniPismen.Add(unikatniPismena[i], i);
                }
                DecText = TextMethods.WithoutDiacriticsToUpper(rawText);
                EncText = Encrypt(DecText);
            }
            else
            {
                throw new Exception("Klíčové slovo neodpovídá požadavkům.");
            }
        }
        /// <summary>
        /// Konstruktor pro inicializaci objektu třídy PetronilkaSifra s vstupním textem, klíčovým slovem a volbou dešifrování.
        /// </summary>
        /// <param name="rawText">Vstupní text k zašifrování/dešifrování.</param>
        /// <param name="key">Klíčové slovo pro šifrování/dešifrování.</param>
        /// <param name="decipher">True, pokud má být prováděno dešifrování; False, pokud má být prováděno šifrování.</param>
        /// <exception cref="Exception">Výjimka je vyvolána, pokud klíčové slovo neodpovídá požadavkům.</exception>
        public PetronilkaSifra(string rawText, string key, bool decypher) : base()
        {
            KlicSlovo = key;
            if (CheckKey(KlicSlovo))
            {
                string unikatniPismena = new string(KlicSlovo.Distinct().ToArray());
                for (int i = 0; i < unikatniPismena.Length; i++)
                {
                    mapovaniPismen.Add(unikatniPismena[i], i);
                }
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
            else
            {
                throw new Exception("Klíčové slovo neodpovídá požadavkům.");
            }
        }
        #endregion
        #region ToString()
        // <summary>
        /// Přetížená metoda pro získání textové reprezentace objektu.
        /// </summary>
        /// <returns>Textová reprezentace objektu.</returns>
        public override string ToString()
        {

            return DecText + "(" + KlicSlovo + ") => " + EncText;
        }
        #endregion
        #region Zašifrování
        /// <summary>
        /// Metoda pro zašifrování vstupního textu.
        /// </summary>
        /// <param name="text">Text k zašifrování.</param>
        /// <returns>Zašifrovaný text.</returns>
        public override string Encrypt(string text)
        {
            StringBuilder encryptedText = new StringBuilder();

            foreach (char znak in text)
            {
                if (mapovaniPismen.ContainsKey(znak))
                {
                    encryptedText.Append(mapovaniPismen[znak]);
                }
                else
                {
                    encryptedText.Append(znak);
                }
            }

            return encryptedText.ToString();
        }
        /// <summary>
        /// Metoda pro dešifrování vstupního textu.
        /// </summary>
        /// <param name="text">Text k dešifrování.</param>
        /// <returns>Dešifrovaný text.</returns>
        #endregion
        #region Rozšifrování
        public override string Decrypt(string text)
        {
            StringBuilder decryptedText = new StringBuilder();
            foreach (char znak in text)
            {
                if (char.IsDigit(znak))
                {
                    // Pokud je znak číslo, zjistíme jeho pozici v klíčovém slově a nahradíme ho odpovídajícím písmenem
                    int position = int.Parse(znak.ToString());
                    char decryptedChar = mapovaniPismen.FirstOrDefault(x => x.Value == position).Key;
                    decryptedText.Append(decryptedChar);
                }
                else
                {
                    // Pokud znak není číslo, ponecháme ho beze změny
                    decryptedText.Append(znak);
                }
            }

            return decryptedText.ToString();
        }
        #endregion
        #region Metody
        /// <summary>
        /// Metoda pro ověření platnosti klíčového slova.
        /// </summary>
        /// <param name="key">Klíčové slovo k ověření.</param>
        /// <returns>True, pokud je klíčové slovo platné; jinak False.</returns>
        private bool CheckKey(string key)
        {
            if (key.Length != 10)
            {
                return false;
            }
            foreach (char c in key)
            {
                if (!char.IsUpper(c) || char.IsDigit(c))
                {
                    return false;
                }
            }
            HashSet<char> uniqueChars = new HashSet<char>();
            foreach (char c in key)
            {
                if (uniqueChars.Contains(c))
                {
                    return false;
                }
                else
                {
                    uniqueChars.Add(c);
                }
            }
            return true;
        }
        #endregion

    }
}
