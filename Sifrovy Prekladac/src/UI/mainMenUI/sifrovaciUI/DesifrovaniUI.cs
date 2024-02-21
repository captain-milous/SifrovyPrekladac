using Sifrovy_Prekladac.src.sifry.related;
using Sifrovy_Prekladac.src.UI.mainMenUI.sifrovaciUI.SifryUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.UI.mainMenUI.SifrovaciUI
{
    /// <summary>
    /// Třída poskytující uživatelské rozhraní pro dešifrování textu pomocí různých šifer.
    /// </summary>
    public static class DesifrovaniUI
    {
        /// <summary>
        /// Zahájí uživatelské rozhraní pro dešifrování textu.
        /// </summary>
        /// <param name="InputText">Vstupní zašifrovaný text k dešifrování.</param>
        public static void Start(string InputText)
        {
            Console.WriteLine();
            Console.WriteLine("Seznam aktivních šifer: \n");
            Console.WriteLine("Zkratka   Šifra            Popis");
            foreach (ActiveSifry sifra in MainMenu.ActveSifry.Keys)
            {
                Console.WriteLine("  (" + SifrovaniUI.ZkratkySifer[sifra] + ") " + sifra + ": " + MainMenu.ActveSifry[sifra]);
            }
            ActiveSifry Sifra = ActiveSifry.Morseova_Sifra;
            bool run = true;
            while (run)
            {
                Console.WriteLine();
                Console.Write("Vyberte jakou šifrou chcete Váš text dešifrovat, tím že zadáte její zkratku: ");
                string answer = Console.ReadLine();
                if (SifrovaniUI.ZkratkySifer.ContainsValue(answer))
                {
                    Sifra = SifrovaniUI.ZkratkySifer.FirstOrDefault(x => x.Value == answer).Key;
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
                    MOR.Decrypt(InputText);
                    break;
                case ActiveSifry.Caesarova_Sifra:
                    CES.Decrypt(InputText);
                    break;
                case ActiveSifry.Petronilka:
                    PET.Decrypt(InputText);
                    break;
                case ActiveSifry.Mezerova_Sifra:
                    MEZ.Decrypt(InputText);
                    break;
                case ActiveSifry.Klavesnicova_Sifra:
                    KLA.Decrypt(InputText);
                    break;
                case ActiveSifry.Telefonni_Sifra:
                    TEL.Decrypt(InputText);
                    break;
                case ActiveSifry.Numericka_Sifra:
                    NUM.Decrypt(InputText);
                    break;
                case ActiveSifry.Reverzni_Sifra:
                    REV.Decrypt(InputText);
                    break;
                case ActiveSifry.Obracena_ABC_Sifra:
                    OAS.Decrypt(InputText);
                    break;
                case ActiveSifry.Prohazena_Sifra:
                    SHU.Decrypt(InputText);
                    break;
                default:
                    Console.WriteLine("Nevybrali jste žádnou šifru.. Tohle by nikdy nemělo nastat.");
                    break;
            }
        }
    }
}
