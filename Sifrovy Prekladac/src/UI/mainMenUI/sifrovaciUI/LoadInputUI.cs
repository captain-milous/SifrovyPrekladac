﻿using Sifrovy_Prekladac.src.conf;
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
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("Chcete použít pro zašifrování/rozšifrování text, který si načtete ze souboru, nebo který si napíšete sami?");
                Console.WriteLine("(Soubor - Načtení textu ze souboru; CMD - Použití textu, který si napíšete sami; Exit - Zpět do hlavního menu)");
                Console.Write("Vaše volba: ");
                string answer = Console.ReadLine().ToLower();
                if (answer.StartsWith("c"))
                {
                    Console.Clear();
                    FromCMD();
                    run = false;
                }
                else if (answer.StartsWith("s"))
                {
                    Console.Clear();
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
        }
        /// <summary>
        /// 
        /// </summary>
        public static void FromCMD()
        {
            bool run = true;
            while (run)
            {
                Console.Write("\nZadejte text, který chcete zašifrovat/dešifrovat: ");
                string rawText = Console.ReadLine();
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
                    string path = ConfigHandler.Config.InputFile + "\\" + fileName;
                    if (availableFiles.Contains(path))
                    {
                        try
                        {
                            string rawText = FileMethods.Read(fileName);
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
            Console.Clear();
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
