using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;
using Sifrovy_Prekladac.src.sifry.related;

namespace Sifrovy_Prekladac.src.UI
{
    /// <summary>
    /// 
    /// </summary>
    public static class Print
    {
        /// <summary>
        /// 
        /// </summary>
        public static string SifrovyPrekladac = @"
 _\_/   _   __                      __                
/ ___| (_) / _| _ __  ___ __   __ _/_/_               
\___ \ | || |_ | '__|/ _ \\ \ / /| | | |              
 ___) || ||  _|| |  | (_) |\ V / | |_| |              
|____/ |_||_|  |_|   \___/  \_/   \__, |              
                                  |___/               
        \\//       _     _             _          \\//
 _ __   _\/_  ___ | | __| |  __ _   __| |  __ _   _\/ 
| '_ \ | '__|/ _ \| |/ /| | / _` | / _` | / _` | / __|
| |_) || |  |  __/|   < | || (_| || (_| || (_| || (__ 
| .__/ |_|   \___||_|\_\|_| \__,_| \__,_| \__,_| \___|
|_|                                                   
";
        /// <summary>
        /// Oddělovač pro vizuální oddělení sekce.
        /// </summary>
        public static string Oddelovac = "\n----------------------------------------------------------------------------------\n";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="message"></param>
        private static void PrintMenuItem(string prefix, string message)
        {
            Console.Write("[");
            Console.Write(prefix, Color.Green);
            Console.WriteLine("] " + message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="version"></param>
        public static void Introduction(string version)
        {
            Console.Clear();
            Console.WriteLine(Oddelovac);
            Console.WriteLine(SifrovyPrekladac, Color.Blue);
            Console.WriteLine("Miloš Tesař C4b");
            string verze = "Verze: " + version;
            Console.WriteLine(verze);
            Console.WriteLine(Oddelovac);
            Console.Write("Zmáčkněte Enter pro start..");
            Console.ReadLine();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Initial()
        {
            Console.WriteLine(Oddelovac);
            Console.WriteLine("Přihlašovací nabídka");
            PrintMenuItem("1", "Přihlášení");
            PrintMenuItem("2", "Registrace");
            PrintMenuItem("3", "Ukončit program");
            Console.Write("\nVyberte možnost: ");
        }

        public static void VolbaTextu()
        {
            Console.WriteLine(Oddelovac);
            Console.WriteLine("Jaký chcete použít text?");
            PrintMenuItem("1", "Napsaný vámi");
            PrintMenuItem("2", "Načtený ze souboru");
            PrintMenuItem("3", "Zpět do konzole");
            Console.Write("\nVaše volba: ");
        }
        /// <summary>
        /// Zobrazí uživateli možnosti zašifrování nebo dešifrování textu.
        /// </summary>
        /// <returns>Řetězec označující zvolenou volbu (zašifrovat, dešifrovat, exit).</returns>
        public static void VolbaSifDesif(string text)
        {
            Console.WriteLine(Oddelovac);
            Console.WriteLine("'" + text + "'", Color.Green);
            Console.WriteLine("\nCo chcete udělat s tímto textem?");
            PrintMenuItem("1", "Zašifrovat");
            PrintMenuItem("2", "Dešifrovat");
            PrintMenuItem("3", "Zahodit text");
            Console.Write("\nVaše volba: ");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ZkratkySifer"></param>
        /// <param name="InputText"></param>
        public static void VypisZkratekASifer(Dictionary<ActiveSifry, string> ZkratkySifer, string InputText)
        {
            Console.WriteLine(Oddelovac);
            Console.WriteLine("Seznam aktivních šifer: \n");
            Console.WriteLine(" Zkratka   Šifra");
            foreach (ActiveSifry sifra in ZkratkySifer.Keys)
            {
                Console.Write("  ");
                PrintMenuItem(ZkratkySifer[sifra], sifra.ToString());
            }
            Console.WriteLine();
            Console.Write("Váš text: ", Color.Blue);
            Console.WriteLine(InputText);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="decypher"></param>
        public static void MorPodsifry(bool decypher)
        {
            string SifDesif = "zašifruje";
            if (decypher) {
                SifDesif = "dešifruje";
            }
            Console.WriteLine("\nVyberte jakým typem morseovky se text " + SifDesif + ":\n");
            Console.Write("  ");
            PrintMenuItem("DEF", "Klasický překlad morseovky");
            Console.Write("  ");
            PrintMenuItem("REV", "Tečky jsou čárky a naopak");
            Console.Write("  ");
            PrintMenuItem("NUM", "Pomocí čísel (0 = tečka, 1 = čárka)");
            Console.Write("  ");
            PrintMenuItem("ABC", "Pomocí velkých a malých písmen");
            Console.Write("\nVaše volba: ");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="decypher"></param>
        public static void KlaPodsifry(bool decypher)
        {
            string SifDesif = "zašifrovat";
            if (decypher)
            {
                SifDesif = "dešifrovat";
            }
            Console.WriteLine("\nVyberte pomocí jakého rozpoložení klávesnice chcete " + SifDesif +":\n");
            Console.Write("  ");
            PrintMenuItem("EN", "Anglické (QWERTY)");
            Console.Write("  ");
            PrintMenuItem("CZ", "České (QWERTZ)");
            Console.Write("\nVaše volba: ");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="decypher"></param>
        public static void NumPodsifry(bool decypher)
        {
            string SifDesif = "zašifrovat";
            if (decypher)
            {
                SifDesif = "dešifrovat";
            }
            Console.WriteLine("\nVyberte na jaká čísla chcete aby se text " + SifDesif + ":\n");
            Console.Write("  ");
            PrintMenuItem("DEF", "Základní (Dle pořadí v abecedě)");
            Console.Write("  ");
            PrintMenuItem("BTR", "Lepší (čísla 1 - 9, mají před sebou 0)");
            Console.Write("  ");
            PrintMenuItem("SPI", "Spirálové šifrování (čisla 1 - 99)");
            Console.Write("  ");
            PrintMenuItem("ROM", "Římské číslice");
            Console.Write("  ");
            PrintMenuItem("HEX", "Hexadecimální čísla");
            Console.Write("\nVaše volba: ");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="decypher"></param>
        public static void TelPodsifry(bool decypher)
        {
            string SifDesif = "zašifrovat";
            if (decypher)
            {
                SifDesif = "dešifrovat";
            }
            Console.WriteLine("\nVyberte jakým způsobem chcete text " + SifDesif + ":\n");
            Console.Write("  ");
            PrintMenuItem("DEF", "Zakladní (Stará telefonní klávesnice)");
            Console.Write("  ");
            PrintMenuItem("BTR", "Přehlednější (Dvojice čísel)");
            Console.Write("  ");
            Console.Write("\nVaše volba: ");
        }
        /// <summary>
        /// 
        /// </summary>
        public static void WhereToSave()
        {
            Console.WriteLine("\nKam chcete přeložený text uložit?\n");
            PrintMenuItem("1", "Na plochu");
            PrintMenuItem("2", "Do dokumentů");
            PrintMenuItem("3", "Do vaší složky");
            PrintMenuItem("4", "Neukládat text");
            Console.Write("\nVaše volba: ");
        }
        /// <summary>
        /// 
        /// </summary>
        public static void ImportFromFolder()
        {
            Console.WriteLine("Odkud chcete soubor načíst?");
            PrintMenuItem("1", "Z plochy");
            PrintMenuItem("2", "Z dokumentů");
            PrintMenuItem("3", "Z vaší složky");
            PrintMenuItem("4", "Vrátit se zpět");
            Console.Write("\nVaše volba: ");
        }
        
        public static void AvailableFiles(string folderPath, List<string> availableFiles)
        {
            if (availableFiles.Count > 0)
            {
                Console.WriteLine("\nZ kterého souboru budete chtít načíst?");
                int j = 1;
                foreach (string filePath in availableFiles)
                {
                    string[] fullPath = filePath.Split('\\');
                    string fileName = fullPath[fullPath.Length - 1];
                    PrintMenuItem(j.ToString(), fileName);
                    j++;
                }
                Console.Write("\nVaše volba: ");
            }
            else
            {
                throw new Exception("\nSložka neobsahuje žadný textový soubor.");
            }
        }
    }
}
