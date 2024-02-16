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
    /// 
    /// </summary>
    public class CaesarovaSifra : Sifra
    {
        private int _posun;
        /// <summary>
        /// 
        /// </summary>
        public int Posun
        {
            get { return _posun; }
            set { _posun = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawText"></param>
        /// <param name="posun"></param>
        /// <param name="decypher"></param>
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return DecText + " (+" + Posun + ") => " + EncText;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="posun"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="posunutaAbeceda"></param>
        /// <returns></returns>
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
    }
}
