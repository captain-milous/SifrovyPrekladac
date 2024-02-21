using Sifrovy_Prekladac.src.conf;
using Sifrovy_Prekladac.src.sifry.related;
using Sifrovy_Prekladac.src.static_methods;
using Sifrovy_Prekladac.src.UserHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Sifrovy_Prekladac.src.UI.mainMenUI.SifrovaciUI
{
    /// <summary>
    /// 
    /// </summary>
    public static class SifrovaniUI
    {
        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<ActiveSifry, string> ZkratkySifer = new Dictionary<ActiveSifry, string>()
        {
            { ActiveSifry.Morseova_Sifra, "MOR" },
            { ActiveSifry.Caesarova_Sifra, "CES" },
            { ActiveSifry.Petronilka, "PET" },
            { ActiveSifry.Mezerova_Sifra, "MEZ" },
            { ActiveSifry.Klavesnicova_Sifra, "KLA" },
            { ActiveSifry.Telefonni_Sifra, "TEL" },
            { ActiveSifry.Numericka_Sifra, "NUM" },
            { ActiveSifry.Reverzni_Sifra, "REV" },
            { ActiveSifry.Obracena_ABC_Sifra, "OAS" },
            { ActiveSifry.Prohazena_Sifra, "SHU" },
        };
        /// <summary>
        /// 
        /// </summary>
        public static void Start(string InputText)
        {
            Console.WriteLine();
            Console.WriteLine("Seznam aktivních šifer: \n");
            Console.WriteLine("Zkratka   Sifra            Popis");
            foreach (ActiveSifry sifra in MainMenu.ActveSifry.Keys)
            {
                Console.WriteLine("  (" + ZkratkySifer[sifra] + ") " + sifra + ": " + MainMenu.ActveSifry[sifra]);
            }
            Console.WriteLine();
            bool run = true;
            while(run)
            {
                Console.Write("Vyberte jakou sifrou chcete Váš text zašifrovat, tím že zadáte její zkratku: ");
                Console.ReadLine();
                ActiveSifry Sifra = ActiveSifry.Morseova_Sifra;
                switch (Sifra)
                {
                    case ActiveSifry.Morseova_Sifra:

                        break;
                    case ActiveSifry.Caesarova_Sifra:

                        break;
                    case ActiveSifry.Petronilka:

                        break;
                    case ActiveSifry.Mezerova_Sifra:

                        break;
                    case ActiveSifry.Klavesnicova_Sifra:

                        break;
                    case ActiveSifry.Telefonni_Sifra:

                        break;
                    case ActiveSifry.Numericka_Sifra:

                        break;
                    case ActiveSifry.Reverzni_Sifra:

                        break;
                    case ActiveSifry.Obracena_ABC_Sifra:

                        break;
                    case ActiveSifry.Prohazena_Sifra:

                        break;

                    default:

                        break;
                }

                run = false;
            }
        }

    }
}
