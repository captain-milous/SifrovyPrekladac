using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.sifry.related
{
    /// <summary>
    /// Enumerace představující seznam aktivních  šifer, kterými lze sifrovat, či dešifrovat v této verzi aplikace.
    /// </summary>
    public enum ActiveSifry
    {
        Morseova_Sifra,
        Caesarova_Sifra,
        Petronilka,
        Mezerova_Sifra,
        Klavesnicova_Sifra,
        Telefonni_Sifra,
        Numericka_Sifra,
        Reverzni_Sifra,
        Obracena_ABC_Sifra,
        Prohazena_Sifra
    }
}
