using Sifrovy_Prekladac.src.sifry;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.static_methods
{
    /// <summary>
    /// Statická třída obsahující metody pro manipulaci s textem.
    /// </summary>
    public static class TextMethods
    {
        /// <summary>
        /// Abeceda, která je použita v některých šifrách
        /// </summary>
        public static char[] Abeceda = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        /// <summary>
        /// Odstraní diakritiku a převede text na velká písmena.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <returns>Text bez diakritiky v uppercase.</returns>
        public static string WithoutDiacriticsToUpper(string text)
        {
            text = text.ToUpper();
            string normalizedString = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < normalizedString.Length; i++)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(normalizedString[i]);
                }
            }

            return stringBuilder.ToString();
        }
        /// <summary>
        /// Odstraní speciální znaky z textu.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <returns>Text bez speciálních znaků.</returns>
        public static string WithoutSpecialChar(string text)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in text)
            {
                if (c == ' ')
                {
                    stringBuilder.Append(c);
                }
                else
                {
                    if (Abeceda.Contains(c))
                    {
                        stringBuilder.Append(c);
                    }
                }
            }

            return stringBuilder.ToString();
        }
        /// <summary>
        /// Odstraní mezery z textu.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <returns>Text bez mezer.</returns>
        public static string WithoutSpaces(string text)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in text)
            {
                if (c != ' ')
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString();
        }
        /// <summary>
        /// Zjednoduší text odstraněním diakritiky, převedením na velká písmena a odstraněním speciálních znaků.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <returns>Zjednodušený text.</returns>
        public static string Simplify(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            return WithoutSpecialChar(WithoutDiacriticsToUpper(text));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string SimplifyWithoutSpaces(string text)
        {
            return WithoutSpaces(Simplify(text));
        }
        /// <summary>
        /// Najde index písmenka v abecedě. Pokud ale není v abecedě, tak vrátí -1
        /// </summary>
        /// <param name="input">Písmeno v abecedě</param>
        /// <returns>Index písmena</returns>
        public static int FindIndexInAlphabet(char input)
        {
            string letter = input.ToString().ToUpper();
            for (int i = 0; i < Abeceda.Length; i++)
            {
                if (Abeceda[i].ToString() == letter)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
