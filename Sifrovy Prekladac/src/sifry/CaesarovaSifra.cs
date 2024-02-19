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
    /// Třída reprezentující Caesarovu šifru, odvozená od základní třídy Sifra.
    /// </summary>
    public class CaesarovaSifra : Sifra
    {
        #region 
        private int _posun;
        /// <summary>
        /// Posunutí znaků při šifrování/dešifrování.
        /// </summary>
        public int Posun
        {
            get { return _posun; }
            set 
            { 
                if(value >= 0 && value < TextMethods.Abeceda.Length)
                {
                    _posun = (int)value;
                } 
                else
                {
                    int assistValue = (int)value;
                    while(!(assistValue >= 0 && assistValue < TextMethods.Abeceda.Length))
                    {
                        if (assistValue < 0)
                        {
                            assistValue += TextMethods.Abeceda.Length;
                        }
                        else if(assistValue >= TextMethods.Abeceda.Length) 
                        { 
                            assistValue -= TextMethods.Abeceda.Length;
                        }
                    }
                    _posun = assistValue;
                }
            }
        }
        #endregion 
        #region 
        /// <summary>
        /// Konstruktor pro vytvoření instance Caesarovy šifry.
        /// </summary>
        /// <param name="rawText">Text k zašifrování nebo dešifrování.</param>
        /// <param name="posun">Počet míst, o které se mají znaky posunout.</param>
        /// <param name="decypher">Určuje, zda se má provést dešifrování.</param>
        public CaesarovaSifra(string rawText, int posun, bool decypher) : base()
        {
            Posun = posun;
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
        /// Přetížená metoda ToString pro vrácení textové reprezentace instance Caesarovy šifry.
        /// </summary>
        /// <returns>Dešifrovaný text (+posun) a zašifrovaný text.</returns>
        public override string ToString()
        {
            return DecText + " (+" + Posun + ") => " + EncText;
        }
        #endregion 
        #region Šifrování
        /// <summary>
        /// Metoda pro šifrování textu pomocí Caesarovy šifry.
        /// </summary>
        /// <param name="text">Text k zašifrování.</param>
        /// <returns>Šifrovaný text.</returns>
        public override string Encrypt(string text)
        {
            char[] abeceda = TextMethods.Abeceda;
            char[] posunutaAbeceda = new char[abeceda.Length];
            int rozdilPismen = RozdilPismen(Posun);
            for (int i = 0; i < abeceda.Length; i++)
            {
                posunutaAbeceda[i] = abeceda[rozdilPismen];
                rozdilPismen++;
                if (rozdilPismen == abeceda.Length)
                {
                    rozdilPismen = 0;
                }
            }
            return UpravText(text, posunutaAbeceda);
        }
        #endregion 
        #region Dešifrování
        /// <summary>
        /// Metoda pro dešifrování textu pomocí Caesarovy šifry.
        /// </summary>
        /// <param name="text">Text k dešifrování.</param>
        /// <returns>Dešifrovaný text.</returns>
        public override string Decrypt(string text)
        {
            char[] abeceda = TextMethods.Abeceda;
            char[] posunutaAbeceda = new char[abeceda.Length];
            int rozdilPismen = RozdilPismen(Posun);
            for (int i = 0; i < abeceda.Length; i++)
            {
                posunutaAbeceda[rozdilPismen] = abeceda[i];
                rozdilPismen++;
                if (rozdilPismen == abeceda.Length)
                {
                    rozdilPismen = 0;
                }
            }
            return UpravText(text, posunutaAbeceda);
        }
        #endregion 
        #region Ostatní metody
        /// <summary>
        /// Metoda pro dešifrování textu pomocí Caesarovy šifry.
        /// </summary>
        /// <param name="text">Text k dešifrování.</param>
        /// <returns>Dešifrovaný text.</returns>
        private int RozdilPismen(int posun)
        {
            char[] abeceda = TextMethods.Abeceda;
            int rozdilPismen = Posun;
            while (rozdilPismen > abeceda.Length && Posun < 0)
            {
                if (rozdilPismen > abeceda.Length)
                {
                    rozdilPismen -= abeceda.Length;
                }
                if (rozdilPismen < 0)
                {
                    rozdilPismen += abeceda.Length;
                }
            }
            return rozdilPismen;
        }
        /// <summary>
        /// Metoda pro získání rozdílu mezi znaky abecedy.
        /// </summary>
        /// <param name="posun">Počet míst, o které se mají znaky posunout.</param>
        /// <returns>Rozdíl mezi znaky abecedy.</returns>
        private string UpravText(string text, char[] posunutaAbeceda)
        {
            char[] rozsifrovanyText = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                char pismeno = text[i];
                int index = Array.IndexOf(TextMethods.Abeceda, pismeno);

                if (index == -1)
                {
                    rozsifrovanyText[i] = pismeno;
                }
                else
                {
                    rozsifrovanyText[i] = posunutaAbeceda[index];
                }
            }
            return new string(rozsifrovanyText);
        }
        #endregion 
    }
}
