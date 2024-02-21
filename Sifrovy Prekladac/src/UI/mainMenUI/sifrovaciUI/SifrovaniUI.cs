using Sifrovy_Prekladac.src.conf;
using Sifrovy_Prekladac.src.static_methods;
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
    /// 
    /// </summary>
    public static class SifrovaniUI
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Start(string InputText)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public static void OldStart(User user)
        {
            bool run = true;
            while (run)
            {
                Console.Write("Chcete načíst ze souboru? ");
                string answer = Console.ReadLine().ToLower();
                if (answer.StartsWith("n"))
                {
                    Console.Write("Zadejte text: ");
                    string rawText = Console.ReadLine();
                    ChceckIfCorrect(rawText);
                }
                else if (answer.StartsWith("y") || answer.StartsWith("a") || answer.StartsWith("j"))
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        static void ChceckIfCorrect(string text)
        {
            Console.WriteLine(text);
            while (true)
            {
                Console.Write("Je toto spravný text? ");
                string answer = Console.ReadLine().ToLower();
                if (answer.StartsWith("n"))
                {
                    break;
                }
                else if (answer.StartsWith("y") || answer.StartsWith("a") || answer.StartsWith("j"))
                {
                    ChooseSifrovaniXDesifrovani();
                }
                else
                {
                    Console.WriteLine("Neplatná volba!");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        static void ChooseSifrovaniXDesifrovani()
        {
            while (true)
            {
                Console.Write("Chcete zašifrovat text? (Ne, znamená dešifrovat)");
                string answer = Console.ReadLine().ToLower();
                if (answer.StartsWith("n"))
                {
                    decipher = true;
                    break;
                }
                else if (answer.StartsWith("y") || answer.StartsWith("a") || answer.StartsWith("j"))
                {
                    decipher = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatná volba!");
                }
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
    }
}
