using Sifrovy_Prekladac.src.conf;
using Sifrovy_Prekladac.src.logs;
using Sifrovy_Prekladac.src.static_methods;
using Sifrovy_Prekladac.src.UI.mainMenUI.sifrovaciUI.SifryUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Colorful;
using Console = Colorful.Console;
using Sifrovy_Prekladac.src.UI.loginMenuUI;

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
            bool run = true;
            while (run)
            {
                Console.Clear();
                if (!decypher)
                {
                    Console.WriteLine("Zašifrovaný text: " + text, Color.Green);
                }
                else
                {
                    Console.WriteLine("Dešifrovaný text: " + text, Color.Green);
                }
                Console.WriteLine(InitialMenu.Oddelovac, Color.Green);
                Print.WhereToSave();
                int input = SelectOption(Console.ReadLine());
                Console.WriteLine();
                string path = "Preklad_Sifer";
                switch (input)
                {
                    case 1:
                        path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Preklad_Sifer";
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                            LogHandler.Write($"Byla vytvořena složka pro překlad šifer");
                        }
                        SaveToFile(text, path);
                        run = false;
                        break;
                    case 2:
                        path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Preklad_Sifer";
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                            LogHandler.Write($"Byla vytvořena složka pro překlad šifer");
                        }
                        SaveToFile(text, path);

                        run = false;
                        break;
                    case 3:
                        path = ConfigHandler.Config.UserFolder; 
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                            LogHandler.Write($"Byla vytvořena složka pro překlad šifer");
                        }
                        SaveToFile(text, path);
                        run = false;
                        break;
                    case 4:
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Vyberte prosím validní možnost!");
                        break;
                }
                Thread.Sleep(1000);
            }
        }
        /// <summary>
        /// Vybere možnost z textového vstupu.
        /// </summary>
        /// <param name="input">Textový vstup</param>
        /// <returns>Číslo vybrané možnosti</returns>
        private static int SelectOption(string input)
        {
            int output = -1;
            Dictionary<string, int> options = new Dictionary<string, int>()
            {
                { "desktop", 1 },
                { "des", 1 },
                { "documents", 2 },
                { "doc", 2 },
                { "myfolder", 3 },
                { "fol", 3 },
                { "back", 4 },
                { "b", 4 },
            };

            try
            {
                output = Convert.ToInt32(input);
            }
            catch
            {
                input = input.ToLower().Replace(" ", "");
                if (options.ContainsKey(input))
                {
                    output = options[input];
                }
                else
                {
                    output = -1;
                }
            }
            return output;
        }
        /// <summary>
        /// Uloží text do textového souboru.
        /// </summary>
        /// <param name="text">Text, který má být uložen do souboru.</param>
        private static void SaveToFile(string text, string path)
        {
            Console.Clear();
            Console.WriteLine("Název souboru musí obsahovat i koncovkou (.pdf nebo .txt).",Color.Green);
            Console.Write(Print.Oddelovac, Color.Green);
            Console.Write("\nNapište název: ");
            while (true)
            {
                string fileName = Console.ReadLine();
                string FN = fileName.ToLower();
                if (FN.EndsWith(".txt") || FN.EndsWith(".pdf"))
                {
                    string fullPath = path + "\\" + fileName;
                    if (!File.Exists(fullPath))
                    {
                        if (FN.EndsWith(".txt"))
                        {
                            FileMethods.Write(path, fileName, text);
                        }
                        else if (FN.EndsWith(".pdf"))
                        {
                            PdfMethods.SaveToPDF(path, fileName, text);
                        }
                        Console.WriteLine("\nSoubor se úspěšně podařilo uložit.", Color.Green);
                        LogHandler.Write($"{MainMenu.LoggedInUser.Username} uložil svůj překlad do {fileName}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nTento soubor již existuje!", Color.DarkRed);
                        Console.Write("\nNapište znovu název: ");
                    }
                }
                else
                {
                    Console.WriteLine("\nTento typ souboru není podporován! (Název musí mít koncovku '.pdf' nebo '.txt')", Color.DarkRed);
                    Console.Write("\nNapište znovu název: ");
                }
                
            }
        }
    }
}
