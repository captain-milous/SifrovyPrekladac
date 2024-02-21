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
    /// 
    /// </summary>
    public static class SaveToFileUI
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public static void Start(string text)
        {
            Console.WriteLine();
            Console.WriteLine("Zašifrovaný text: " + text);
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
        /// 
        /// </summary>
        /// <param name="text"></param>
        private static void SaveToFile(string text)
        {
            Console.Write("\nNapište název textového souboru: ");
            while (true)
            {
                string fileName = Console.ReadLine();
                if (!fileName.EndsWith(".txt"))
                {
                    fileName += ".txt";
                }
                if (!File.Exists(fileName))
                {
                    FileMethods.Write(fileName, text);
                    LogHandler.Write($"{MainMenu.LoggedInUser} uložil svůj překlad do {fileName}");
                }
                else
                {
                    Console.WriteLine("Tento soubor již existuje!");
                    Console.Write("\nNapište znovu název: ");
                }
            }
        }
    }
}
