using Sifrovy_Prekladac.src.static_methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Sifrovy_Prekladac.src.sifry
{
    public class PetronilkaSifra : Sifra
    {
        #region Proměnné
        private string klicSlovo = "PETRONILKA";


        Dictionary<char, int> mapovaniPismen = new Dictionary<char, int>();
        #endregion
        #region Konstruktory
        public PetronilkaSifra(string rawText) : base()
        {
            if (CheckKey(klicSlovo))
            {
                string unikatniPismena = new string(klicSlovo.Distinct().ToArray());
                for (int i = 0; i < unikatniPismena.Length; i++)
                {
                    mapovaniPismen.Add(unikatniPismena[i], i);
                }
                DecText = TextMethods.Simplify(rawText);
                EncText = Encrypt(DecText);
            }
            else
            {
                throw new Exception("Klíčové slovo neodpovídá požadavkům.");
            }
        }
        public PetronilkaSifra(string rawText, string key) : base()
        {
            klicSlovo = key;
            if (CheckKey(klicSlovo))
            {
                string unikatniPismena = new string(klicSlovo.Distinct().ToArray());
                for (int i = 0; i < unikatniPismena.Length; i++)
                {
                    mapovaniPismen.Add(unikatniPismena[i], i);
                }
                DecText = TextMethods.Simplify(rawText);
                EncText = Encrypt(DecText);
            }
            else
            {
                throw new Exception("Klíčové slovo neodpovídá požadavkům.");
            }
        }
        public PetronilkaSifra(string rawText, string key, bool decipher) : base()
        {
            klicSlovo = key;
            if (CheckKey(klicSlovo))
            {
                string unikatniPismena = new string(klicSlovo.Distinct().ToArray());
                for (int i = 0; i < unikatniPismena.Length; i++)
                {
                    mapovaniPismen.Add(unikatniPismena[i], i);
                }
                DecText = TextMethods.Simplify(rawText);
                EncText = Encrypt(DecText);
            }
            else
            {
                throw new Exception("Klíčové slovo neodpovídá požadavkům.");
            }
        }
        #endregion
        #region ToString()
        public override string ToString()
        {

            return DecText + "(" + klicSlovo + ") => " + EncText;
        }
        #endregion
        #region Zašifrování
        public override string Encrypt(string text)
        {
            string zasifrovanyText = "";

            foreach (char pismeno in text)
            {
                if (mapovaniPismen.ContainsKey(pismeno))
                {
                    zasifrovanyText += mapovaniPismen[pismeno].ToString();
                }
                else
                {
                    zasifrovanyText += pismeno;
                }
            }

            return zasifrovanyText;
        }
        #endregion
        #region Rozšifrování
        public override string Decrypt(string text)
        {
            return text;
        }
        #endregion
        
        private bool CheckKey(string key)
        {
            if(key.Length == 10)
            {
                return true;
            }
            return false;
        }


    }
}
