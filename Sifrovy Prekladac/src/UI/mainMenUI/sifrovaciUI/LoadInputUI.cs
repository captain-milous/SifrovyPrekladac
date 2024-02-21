using Sifrovy_Prekladac.src.conf;
using Sifrovy_Prekladac.src.static_methods;
using Sifrovy_Prekladac.src.UI.loginMenuUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.UI.mainMenUI.SifrovaciUI
{
    /// <summary>
    /// 
    /// </summary>
    public static class LoadInputUI
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Start()
        {
            Console.WriteLine(InitialMenu.Oddelovac);
            bool run = true;
            while (run)
            {
                Console.WriteLine("Chcete načíst ze souboru nebo z cmd?");
                Console.WriteLine("(Soubor - Načtení ze souboru; CMD - Načtení z cmd; Exit - Zpět do hlavního menu)");
                Console.Write("Vaše volba: ");
                string answer = Console.ReadLine().ToLower();
                if (answer.StartsWith("c"))
                {
                    FromCMD();
                    run = false;
                }
                else if (answer.StartsWith("s"))
                {
                    FromFile();
                    run = false;
                }
                else if (answer == "exit" || answer == "x")
                {
                    run = false;
                }
                else
                {
                    run = true;
                    Console.WriteLine("Neplatná volba!");
                }
                Console.WriteLine();
            }
            Console.WriteLine(InitialMenu.Oddelovac);
        }
        /// <summary>
        /// 
        /// </summary>
        public static void FromCMD()
        {
            bool run = true;
            while (run)
            {
                Console.Write("\nZadejte text: ");
                string rawText = Console.ReadLine();
                if (ChceckIfCorrect(rawText))
                {
                    string answer = ChooseSifXDesif();
                    switch (answer)
                    {
                        case "sifrovat":
                            SifrovaniUI.Start(rawText);
                            run = false;
                            break;
                        case "desifrovat":
                            DesifrovaniUI.Start(rawText);
                            run = false; 
                            break;
                        case "exit":
                            run = false;
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static void FromFile()
        {
            List<string> availableFiles = new List<string>();
            bool run = true;
            while (run)
            {
                availableFiles = GetTxtFiles(ConfigHandler.Config.InputFile);
                if (availableFiles.Count > 0)
                {
                    Console.WriteLine();
                    foreach (string filePath in availableFiles)
                    {
                        string[] fullPath = filePath.Split('\\');
                        string fileName = fullPath[fullPath.Length - 1];
                        Console.WriteLine("  " + fileName);
                    }
                    Console.Write("\nVyberte jeden ze souborů: ");
                    string answer = Console.ReadLine();
                    if (!answer.EndsWith(".txt"))
                    {
                        answer += ".txt";
                    }
                    string path = ConfigHandler.Config.InputFile + "\\" + answer;
                    if (availableFiles.Contains(path))
                    {
                        try
                        {
                            string rawText = FileMethods.Read(path);
                            if (ChceckIfCorrect(rawText))
                            {
                                answer = ChooseSifXDesif();
                                switch (answer)
                                {
                                    case "sifrovat":
                                        SifrovaniUI.Start(rawText);
                                        run = false;
                                        break;
                                    case "desifrovat":
                                        DesifrovaniUI.Start(rawText);
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
                        Console.Write("  Chyba: " + answer + " tento soubor se neshoduje s žádnými z nabídky. ");
                        Console.WriteLine("(Pokud nemůžete svůj soubor v tomto listu nalézt, podívejte se do konfiguračního souboru a podle InputFile, tedy cestě k načítacím souborům, vložte Váš soubor do příslušného adresáře.)");
                    }
                }
                else
                {
                    Console.Write("  Chyba: V " + ConfigHandler.Config.InputFile + " není žádný podporovaný soubor.");
                    Console.WriteLine("(Zkontrulujte zda je Váš soubor ve adresáři, který je uvedený v konfiguračním souboru, tedy zda je cesta k souborům správně. Pokud ne, vložte soubor do příslušného adresáře, nebo ukončete program, změňte cestu v konfiguračním souboru a znovu program zapněte.)");
                    run = false;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static bool ChceckIfCorrect(string text)
        {
            Console.WriteLine();
            Console.WriteLine("'" + text + "'");
            while (true)
            {
                Console.WriteLine("Je toto spravný text? (Ano/Ne)");
                Console.Write("Vaše volba: ");
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
        /// 
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <returns></returns>
        static string ChooseSifXDesif()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Chcete zašifrovat/dešifrovat text?");
                Console.WriteLine("(Exit - Zpět do hlavního menu)");
                Console.Write("Vaše volba: ");
                string answer = Console.ReadLine().ToLower();
                if (answer.StartsWith("s") || answer.StartsWith("s"))
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
