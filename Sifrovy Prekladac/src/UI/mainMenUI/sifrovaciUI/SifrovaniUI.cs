﻿using Sifrovy_Prekladac.src.conf;
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
            Print.VypisZkratekASifer(ZkratkySifer, InputText);
            ActiveSifry Sifra = ActiveSifry.Morseova_Sifra;
            bool run = true;
            while(run)
            {
                Console.WriteLine();
                if (!decypher)
                {
                    Console.Write("Vyberte zkratku šifry, kterou budete šifrovat: ");
                }
                else
                {
                    Console.Write("Vyberte zkratku šifry, kterou budete dešifrovat: ");
                }
                string input = Console.ReadLine().ToUpper();
                if (ZkratkySifer.ContainsValue(input))
                {
                    Sifra = ZkratkySifer.FirstOrDefault(x => x.Value == input).Key;
                    run = false;
                }
                else
                {
                    Console.WriteLine("\nVyberte prosím validní možnost!");
                    Thread.Sleep(1000);
                }
            }
            switch (Sifra)
            {
                case ActiveSifry.Morseova_Sifra:
                    MOR.Start(InputText, decypher);
                    break;
                case ActiveSifry.Caesarova_Sifra:
                    CES.Start(InputText, decypher);
                    break;
                case ActiveSifry.Petronilka:
                    PET.Start(InputText, decypher);
                    break;
                case ActiveSifry.Mezerova_Sifra:
                    MEZ.Start(InputText, decypher);
                    break;
                case ActiveSifry.Klavesnicova_Sifra:
                    KLA.Start(InputText, decypher);
                    break;
                case ActiveSifry.Telefonni_Sifra:
                    TEL.Start(InputText, decypher);
                    break;
                case ActiveSifry.Numericka_Sifra:
                    NUM.Start(InputText, decypher);
                    break;
                case ActiveSifry.Reverzni_Sifra:
                    REV.Start(InputText, decypher);
                    break;
                case ActiveSifry.Obracena_ABC_Sifra:
                    OAS.Start(InputText, decypher);
                    break;
                case ActiveSifry.Prohazena_Sifra:
                    SHU.Start(InputText, decypher);
                    break;
                default:
                    Console.WriteLine("Nevybrali jste žádnou šifru.. Tohle by nikdy nemělo nastat.");
                    break;
            }
        }
    }
}
