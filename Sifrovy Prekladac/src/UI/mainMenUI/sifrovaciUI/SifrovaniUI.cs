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
        public static void Start(string InputText, bool decypher)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Seznam aktivních šifer: \n");
            Console.WriteLine("Zkratka   Šifra");
            foreach (ActiveSifry sifra in ZkratkySifer.Keys)
            {
                Console.WriteLine("  (" + ZkratkySifer[sifra] + ") " + sifra);
            }
            ActiveSifry Sifra = ActiveSifry.Morseova_Sifra;
            bool run = true;
            while(run)
            {
                Console.WriteLine();
                if (!decypher)
                {
                    Console.Write("Vyberte jakou šifrou chcete Váš text zašifrovat, tím že zadáte její zkratku: ");
                }
                else
                {
                    Console.Write("Vyberte jakou šifrou chcete Váš text dešifrovat, tím že zadáte její zkratku: ");
                }
                string answer = Console.ReadLine().ToUpper();
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
                    if (!decypher)
                    {
                        MOR.Encrypt(InputText);
                    }
                    else
                    {
                        MOR.Decrypt(InputText);
                    }
                    break;
                case ActiveSifry.Caesarova_Sifra:
                    if (!decypher)
                    {
                        CES.Encrypt(InputText);
                    }
                    else
                    {
                        CES.Decrypt(InputText);
                    }
                    break;
                case ActiveSifry.Petronilka:
                    if (!decypher)
                    {
                        PET.Encrypt(InputText);
                    }
                    else
                    {
                        PET.Decrypt(InputText);
                    }
                    break;
                case ActiveSifry.Mezerova_Sifra:
                    if (!decypher)
                    {
                        MEZ.Encrypt(InputText);
                    }
                    else
                    {
                        MEZ.Decrypt(InputText);
                    }
                    break;
                case ActiveSifry.Klavesnicova_Sifra:
                    if (!decypher)
                    {
                        KLA.Encrypt(InputText);
                    }
                    else
                    {
                        KLA.Decrypt(InputText);
                    }
                    break;
                case ActiveSifry.Telefonni_Sifra:
                    if (!decypher)
                    {
                        TEL.Encrypt(InputText);
                    }
                    else
                    {
                        TEL.Decrypt(InputText);
                    }
                    break;
                case ActiveSifry.Numericka_Sifra:
                    if (!decypher)
                    {
                        NUM.Encrypt(InputText);
                    }
                    else
                    {
                        NUM.Decrypt(InputText);
                    }
                    break;
                case ActiveSifry.Reverzni_Sifra:
                    if (!decypher)
                    {
                        REV.Encrypt(InputText);
                    }
                    else
                    {
                        REV.Decrypt(InputText);
                    }
                    break;
                case ActiveSifry.Obracena_ABC_Sifra:
                    if (!decypher)
                    {
                        OAS.Encrypt(InputText);
                    }
                    else
                    {
                        OAS.Decrypt(InputText);
                    }
                    break;
                case ActiveSifry.Prohazena_Sifra:
                    if (!decypher)
                    {
                        SHU.Encrypt(InputText);
                    }
                    else
                    {
                        SHU.Decrypt(InputText);
                    }
                    break;
                default:
                    Console.WriteLine("Nevybrali jste žádnou šifru.. Tohle by nikdy nemělo nastat.");
                    break;
            }
        }
    }
}
