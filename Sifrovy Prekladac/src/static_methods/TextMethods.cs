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
        /// Odstraní diakritiku
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <returns>Text bez diakritiky</returns>
        public static string WithoutDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            Dictionary<char, char> diacriticsMap = new Dictionary<char, char>
            {
                {'á', 'a'}, {'č', 'c'}, {'ď', 'd'}, {'é', 'e'}, {'ě', 'e'},
                {'í', 'i'}, {'ň', 'n'}, {'ó', 'o'}, {'ř', 'r'}, {'š', 's'},
                {'ť', 't'}, {'ú', 'u'}, {'ů', 'u'}, {'ý', 'y'}, {'ž', 'z'},
                {'Á', 'A'}, {'Č', 'C'}, {'Ď', 'D'}, {'É', 'E'}, {'Ě', 'E'},
                {'Í', 'I'}, {'Ň', 'N'}, {'Ó', 'O'}, {'Ř', 'R'}, {'Š', 'S'},
                {'Ť', 'T'}, {'Ú', 'U'}, {'Ů', 'U'}, {'Ý', 'Y'}, {'Ž', 'Z'}
            };
            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
            {
                if (diacriticsMap.ContainsKey(c))
                    sb.Append(diacriticsMap[c]);
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }
        /// <summary>
        /// Odstraní diakritiku a převede text na velká písmena.
        /// </summary>
        /// <param name="text">Vstupní text.</param>
        /// <returns>Text bez diakritiky v uppercase.</returns>
        public static string WithoutDiacriticsToUpper(string text)
        {
            return WithoutDiacritics(text).ToUpper();
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
