using Sifrovy_Prekladac.src.conf;
using Sifrovy_Prekladac.src.static_methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;

namespace Sifrovy_Prekladac.src.UI.mainMenUI.SifrovaciUI
{
    /// <summary>
    /// Poskytuje uživatelské rozhraní pro načtení textu ze souboru nebo vstupu z příkazového řádku.
    /// </summary>
    public static class LoadInputUI
    {
        /// <summary>
        /// Spustí uživatelské rozhraní pro výběr zdroje textu (soubor, příkazový řádek) pro zašifrování/dešifrování.
        /// </summary>
        public static void Start()
        {
            Console.Clear();
            bool run = true;
            while (run)
            {
                Print.VolbaTextu();
                int input = SelectOption(Console.ReadLine());
                Console.WriteLine();
                switch (input)
                {
                    case 1:
                        FromCMD();
                        run = false;
                        break;
                    case 2:
                        FromFile();
                        run = false;
                        break;
                    case 3:
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Vyberte prosím validní možnost!");
                        Thread.Sleep(1000);
                        break;
                }
                Console.Clear();
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
                { "cmd", 1 },
                { "c", 1 },
                { "soubor", 2 },
                { "sou", 2 },
                { "s", 2 },
                { "file", 2 },
                { "back", 3 },
                { "b", 3 }
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
        /// Načte text z příkazového řádku a spustí zašifrování/dešifrování.
        /// </summary>
        public static void FromCMD()
        {
            bool run = true;
            while (run)
            {
                Console.Write("Zadejte text: ");
                string rawText = Console.ReadLine();
                if (ChceckIfCorrect(rawText))
                {
                    Console.Clear();
                    Print.VolbaSifDesif(rawText);
                    Console.ReadLine();
                    string answer = ChooseSifXDesif();
                    switch (answer)
                    {
                        case "sifrovat":
                            SifrovaniUI.Start(rawText, false);
                            run = false;
                            break;
                        case "desifrovat":
                            SifrovaniUI.Start(rawText, true);
                            run = false; 
                            break;
                        case "exit":
                            run = false;
                            break;
                    }
                }
                Console.Clear();
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Načte text ze souboru a spustí zašifrování/dešifrování.
        /// </summary>
        public static void FromFile()
        {
            List<string> availableFiles = new List<string>();
            bool run = true;
            while (run)
            {
                availableFiles = GetTxtFiles(ConfigHandler.Config.UserFolder);
                if (availableFiles.Count > 0)
                {
                    string fileName = string.Empty;
                    Console.WriteLine();
                    foreach (string filePath in availableFiles)
                    {
                        string[] fullPath = filePath.Split('\\');
                        fileName = fullPath[fullPath.Length - 1];
                        Console.WriteLine("  " + fileName);
                    }
                    Console.Write("\nVyberte jeden ze souborů: ");
                    fileName = Console.ReadLine();
                    if (!fileName.EndsWith(".txt"))
                    {
                        fileName += ".txt";
                    }
                    string path = ConfigHandler.Config.UserFolder + "\\" + fileName;
                    if (availableFiles.Contains(path))
                    {
                        try
                        {
                            string rawText = FileMethods.Read(ConfigHandler.Config.UserFolder, fileName);
                            if (ChceckIfCorrect(rawText))
                            {
                                string answer = ChooseSifXDesif();
                                switch (answer)
                                {
                                    case "sifrovat":
                                        SifrovaniUI.Start(rawText, false);
                                        run = false;
                                        break;
                                    case "desifrovat":
                                        SifrovaniUI.Start(rawText, true);
                                        run = false;
                                        break;
                                    case "exit":
                                        run = false;
                                        break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Chyba: " + ex.Message);
                            run = false;
                        }
                    }
                    else
                    {
                        Console.Write("  Chyba: " + fileName + " tento soubor se neshoduje s žádnými z nabídky. ");
                        Console.WriteLine("(Pokud nemůžete svůj soubor v tomto listu nalézt, podívejte se do konfiguračního souboru a podle InputFile, tedy cestě k načítacím souborům, vložte Váš soubor do příslušného adresáře.)");
                    }
                }
                else
                {
                    Console.Write("  Chyba: V " + ConfigHandler.Config.UserFolder + " není žádný podporovaný soubor.");
                    Console.WriteLine("(Zkontrulujte zda je Váš soubor ve adresáři, který je uvedený v konfiguračním souboru, tedy zda je cesta k souborům správně. Pokud ne, vložte soubor do příslušného adresáře, nebo ukončete program, změňte cestu v konfiguračním souboru a znovu program zapněte.)");
                    run = false;
                }
            }
        }
        /// <summary>
        /// Zkontroluje, zda je zadaný text správný.
        /// </summary>
        /// <param name="text">Zadaný text.</param>
        /// <returns>True, pokud je text správný; jinak false.</returns>
        static bool ChceckIfCorrect(string text)
        {
            Console.WriteLine();
            Console.WriteLine("'" + text + "'", Color.Green);
            while (true)
            {
                Console.Write("\nJe toto opravdu text, který chcete přeložit? (A/N)");
                Console.Write("\nVaše volba: ");
                string answer = Console.ReadLine().ToLower();
                if (answer.StartsWith("n"))
                {
                    return false;
                }
                else if (answer.StartsWith("y") || answer.StartsWith("a") || answer.StartsWith("j"))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Neplatná volba!");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Získá seznam textových souborů z daného adresáře.
        /// </summary>
        /// <param name="Path">Cesta k adresáři.</param>
        /// <returns>Seznam textových souborů.</returns>
        static List<string> GetTxtFiles(string Path)
        {
            List<string> txtFiles = new List<string>();
            try
            {
                string[] files = Directory.GetFiles(Path);
                foreach (var file in files)
                {
                    if (file.EndsWith(".txt"))
                    {
                        txtFiles.Add(file);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba: " + ex.Message);
            }
            return txtFiles;
        }
        /// <summary>
        /// Zobrazí uživateli možnosti zašifrování nebo dešifrování textu.
        /// </summary>
        /// <returns>Řetězec označující zvolenou volbu (zašifrovat, dešifrovat, exit).</returns>
        static string ChooseSifXDesif()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Chcete zašifrovat/dešifrovat text?");
                Console.WriteLine("(Zas - Zašifrovat, Des - Dešifrovat, Exit - Zpět do hlavního menu)");
                Console.Write("Vaše volba: ");
                string answer = Console.ReadLine().ToLower();
                if (answer.StartsWith("s") || answer.StartsWith("z"))
                {
                    return "sifrovat";
                }
                else if (answer.StartsWith("d"))
                {
                    return "desifrovat";
                }
                else if (answer == "exit" || answer == "x")
                {
                    return "exit";
                }
                else
                {
                    Console.WriteLine("Neplatná volba!");
                }
            }
        }
    }
}
