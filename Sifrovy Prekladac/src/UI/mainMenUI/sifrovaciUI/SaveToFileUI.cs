using Sifrovy_Prekladac.src.conf;
using Sifrovy_Prekladac.src.logs;
using Sifrovy_Prekladac.src.static_methods;
using Sifrovy_Prekladac.src.UI.mainMenUI.sifrovaciUI.SifryUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.UI.mainMenUI.sifrovaciUI
{
    /// <summary>
    /// Třída pro ukládání přeložených textů do souborů.
    /// </summary>
    public static class SaveToFileUI
    {
        /// <summary>
        /// Zobrazí uživateli zašifrovaný nebo dešifrovaný text a umožní mu rozhodnout se, zda jej chce uložit do souboru.
        /// </summary>
        /// <param name="text">Text, který má být uložen do souboru.</param>
        /// <param name="decypher">Určuje, zda je text dešifrován (true) nebo zašifrován (false).</param>
        public static void Start(string text, bool decypher)
        {
            Console.Clear();
            Console.WriteLine();
            if(!decypher)
            {
                Console.WriteLine("Zašifrovaný text: " + text);
            }
            else
            {
                Console.WriteLine("Dešifrovaný text: " + text);
            }
            while (true)
            {
                Console.WriteLine("Chcete tento přeložený text uložit do souboru? (Ano/Ne)");
                Console.Write("Vaše volba: ");
                string answer = Console.ReadLine().ToLower();
                if (answer.StartsWith("n"))
                {
                    break;
                }
                else if (answer.StartsWith("y") || answer.StartsWith("a") || answer.StartsWith("j"))
                {
                    SaveToFile(text);
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatná volba!");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Uloží text do textového souboru.
        /// </summary>
        /// <param name="text">Text, který má být uložen do souboru.</param>
        private static void SaveToFile(string text)
        {
            Console.Write("\nNapište název textového souboru: ");
            while (true)
            {
                string fileName = Console.ReadLine();
                string FN = fileName.ToLower();
                if (FN.EndsWith(".txt") || FN.EndsWith(".pdf"))
                {
                    string fullPath = ConfigHandler.Config.OutputFile + "\\" + fileName;
                    if (!File.Exists(fullPath))
                    {
                        if (FN.EndsWith(".txt"))
                        {
                            FileMethods.Write(fileName, text);
                        }
                        else if (FN.EndsWith(".pdf"))
                        {
                            PdfMethods.SaveToPDF(fileName, text);
                        }
                        LogHandler.Write($"{MainMenu.LoggedInUser.Username} uložil svůj překlad do {fileName}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Tento soubor již existuje!");
                        Console.Write("\nNapište znovu název: ");
                    }
                }
                else
                {
                    Console.WriteLine("Tento typ souboru není podporován! (Název musí mít koncovku '.pdf' nebo '.txt')");
                    Console.Write("\nNapište znovu název: ");
                }
                
            }
        }
    }
}
