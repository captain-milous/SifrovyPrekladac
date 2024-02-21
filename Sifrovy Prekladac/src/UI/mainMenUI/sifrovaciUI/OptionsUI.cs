using Sifrovy_Prekladac.src.conf;
using Sifrovy_Prekladac.src.static_methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.UI
{
    public static class OptionsUI
    {
        public static void InputFromCmdOrFile()
        {
            bool run = true;
            while (run)
            {
                Console.Write("Chcete načíst ze souboru? (Y/n) ");
                string answer = Console.ReadLine().ToLower();
                if (answer.StartsWith("n"))
                {
                    Console.Write("Zadejte text: ");
                    string rawText = Console.ReadLine();
                    ChceckIfCorrect(rawText);
                }
                else if (answer.StartsWith("y"))
                {
                    List<string> availableFiles = GetTxtFiles(ConfigHandler.Config.InputFile);
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
                        answer = Console.ReadLine();
                        if (availableFiles.Contains(answer))
                        {
                            try
                            {
                                string rawText = FileMethods.Read(answer);
                                ChceckIfCorrect(rawText);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Chyba: " + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("V " + ConfigHandler.Config.InputFile + " není žádný podporovaný soubor.");
                    }
                }
                else if (answer == "exit")
                {
                    run = false;
                }
                else
                {
                    Console.WriteLine("Neplatná volba!");
                }
            }
            Console.WriteLine();
        }
    }
}
