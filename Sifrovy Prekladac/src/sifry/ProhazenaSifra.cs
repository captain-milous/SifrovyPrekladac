using Sifrovy_Prekladac.src.static_methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.sifry
{
    public class ProhazenaSifra : Sifra
    {
        #region Konstruktory
        public ProhazenaSifra(string rawText) : base()
        {
            DecText = TextMethods.WithoutDiacriticsToUpper(rawText);
            EncText = Encrypt(DecText);
        }
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
        #region
        public override string Encrypt(string text)
        {
            return base.Encrypt(text);
        }
        #endregion
        #region
        public override string Decrypt(string text)
        {
            return base.Decrypt(text);
        }
        #endregion
    }
}
