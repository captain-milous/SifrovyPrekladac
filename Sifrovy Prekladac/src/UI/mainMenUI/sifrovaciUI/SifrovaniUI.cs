using Sifrovy_Prekladac.src.conf;
using Sifrovy_Prekladac.src.sifry.related;
using Sifrovy_Prekladac.src.static_methods;
using Sifrovy_Prekladac.src.UI.mainMenUI.sifrovaciUI.SifryUI;
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
    /// Třída poskytující uživatelské rozhraní pro provádění šifrování textu pomocí různých šifer.
    /// </summary>
    public static class SifrovaniUI
    {
        /// <summary>
        /// Slovník obsahující zkratky pro různé aktivní šifry.
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
        /// Zahájí uživatelské rozhraní pro provádění šifrování.
        /// </summary>
        /// <param name="InputText">Vstupní text k šifrování.</param>
        public static void Start(string InputText)
        {
            Console.WriteLine();
            Console.WriteLine("Seznam aktivních šifer: \n");
            Console.WriteLine("Zkratka   Šifra            Popis");
            foreach (ActiveSifry sifra in MainMenu.ActveSifry.Keys)
            {
                Console.WriteLine("  (" + ZkratkySifer[sifra] + ") " + sifra + ": " + MainMenu.ActveSifry[sifra]);
            }
            ActiveSifry Sifra = ActiveSifry.Morseova_Sifra;
            bool run = true;
            while(run)
            {
                Console.WriteLine();
                Console.Write("Vyberte jakou šifrou chcete Váš text zašifrovat, tím že zadáte její zkratku: ");
                string answer = Console.ReadLine();
                if (ZkratkySifer.ContainsValue(answer))
                {
                    Sifra = ZkratkySifer.FirstOrDefault(x => x.Value == answer).Key;
                    run = false;
                }
                else
                {
                    Console.WriteLine("Zadaná zkratka neodpovídá žádné sifře.");
                }
            }
            switch (Sifra)
            {
                case ActiveSifry.Morseova_Sifra:
                    MOR.Encrypt(InputText);
                    break;
                case ActiveSifry.Caesarova_Sifra:
                    CES.Encrypt(InputText);
                    break;
                case ActiveSifry.Petronilka:
                    PET.Encrypt(InputText);
                    break;
                case ActiveSifry.Mezerova_Sifra:
                    MEZ.Encrypt(InputText);
                    break;
                case ActiveSifry.Klavesnicova_Sifra:
                    KLA.Encrypt(InputText);
                    break;
                case ActiveSifry.Telefonni_Sifra:
                    TEL.Encrypt(InputText);
                    break;
                case ActiveSifry.Numericka_Sifra:
                    NUM.Encrypt(InputText);
                    break;
                case ActiveSifry.Reverzni_Sifra:
                    REV.Encrypt(InputText);
                    break;
                case ActiveSifry.Obracena_ABC_Sifra:
                    OAS.Encrypt(InputText);
                    break;
                case ActiveSifry.Prohazena_Sifra:
                    SHU.Encrypt(InputText);
                    break;
                default:
                    Console.WriteLine("Nevybrali jste žádnou šifru.. Tohle by nikdy nemělo nastat.");
                    break;
            }
        }
    }
}
