using Sifrovy_Prekladac.src.conf;
using Sifrovy_Prekladac.src.logs;
using Sifrovy_Prekladac.src.static_methods;
using Sifrovy_Prekladac.src.UI.mainMenUI.SifrovaciUI;
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
    public static class LoadFromFileUI
    {
        /// <summary>
        /// Načte text ze souboru a spustí zašifrování/dešifrování.
        /// </summary>
        public static void Start()
        {
            List<string> availableFiles = new List<string>();
            bool run = true;
            bool run2 = false;
            while (run)
            {
                Console.Clear();
                Console.WriteLine(Print.Oddelovac);
                Print.ImportFromFolder();
                string folderPath = string.Empty;
                int option = ChooseFolder();
                switch (option)
                {
                    case 1:
                        folderPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Preklad_Sifer";
                        break;
                    case 2:
                        folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Preklad_Sifer";
                        break;
                    case 3:
                        folderPath = ConfigHandler.Config.UserFolder;
                        break;
                    case 4:
                        run = false;
                        break;
                    default:
                        throw new Exception("Neexistující složka");
                }
                if (run)
                {
                    try
                    {
                        availableFiles = GetTxtFiles(folderPath);
                        if (availableFiles.Count > 0)
                        {
                            Print.AvailableFiles(folderPath, availableFiles);
                            run = false;
                            run2 = true;
                        }
                        else
                        {
                            Console.WriteLine("\nSložka neobsahuje žadný textový soubor.");
                            Thread.Sleep(1000);
                            run = true;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Thread.Sleep(500);
                        run = true;
                    }
                }
            }
            if (run2)
            {
                int selectedFile = ChooseFile(availableFiles) - 1;
                string text = string.Empty;
                try
                {
                    text = FileMethods.Read(availableFiles[selectedFile]);
                }
                catch (Exception e)
                {
                    run2 = false;
                    if (string.IsNullOrEmpty(text))
                    {
                        Console.WriteLine("\nTextový soubor neobsauje žádný text.");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("\n" + e.Message);
                        Thread.Sleep(1000);
                    }
                }
                if(run2)
                {
                    SifrovaniUI.Start(text);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="availableFiles"></param>
        /// <returns></returns>
        static int ChooseFile(List<string> availableFiles)
        {
            int output = -1;
            while (output < 0)
            {
                try
                {
                    output = Convert.ToInt32(Console.ReadLine());
                    if (output > availableFiles.Count && output < 1)
                    {
                        throw new Exception("Mimo range");
                    }
                }
                catch
                {
                    Console.WriteLine("\nNeplatná volba!");
                    output = -1;
                }
                if (output < 0)
                {
                    Console.Write("Vyberte jednu z možností: ");
                }
            }
            return output;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static int ChooseFolder()
        {
            int output = -1;
            while (output < 0)
            {
                try
                {
                    output = Convert.ToInt32(Console.ReadLine());
                    if (output > 4 && output < 1)
                    {
                        throw new Exception("Mimo range");
                    }
                }
                catch
                {
                    Console.WriteLine("\nNeplatná volba!");
                    output = -1;
                }
                if (output < 0)
                {
                    Console.Write("Vyberte jednu z možností: ");
                }
            }
            return output;
        }
        /// <summary>
        /// Získá seznam textových souborů z daného adresáře.
        /// </summary>
        /// <param name="Path">Cesta k adresáři.</param>
        /// <returns>Seznam textových souborů.</returns>
        static List<string> GetTxtFiles(string Path)
        {
            List<string> txtFiles = new List<string>();
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
                LogHandler.Write($"Byla vytvořena složka pro překlad šifer");
            }
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
