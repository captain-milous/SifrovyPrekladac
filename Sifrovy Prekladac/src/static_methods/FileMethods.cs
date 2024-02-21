using Sifrovy_Prekladac.src.conf;
using Sifrovy_Prekladac.src.logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.static_methods
{
    /// <summary>
    /// Třída obsahující metody pro zápis a čtení textových dat ze souborů.
    /// </summary>
    public static class FileMethods
    {
        /// <summary>
        /// Zapíše zadaný text do souboru.
        /// </summary>
        /// <param name="fileName">Název souboru, do kterého se má zapisovat text.</param>
        /// <param name="text">Text, který se má zapsat do souboru.</param>
        /// <exception cref="Exception">Výjimka, která může být vyvolána při chybě při zápisu do souboru.</exception>
        public static void Write(string fileName, string text)
        {
            try
            {
                if (!fileName.EndsWith(".txt"))
                {
                    fileName += ".txt";
                }
                string filePath = ConfigHandler.Config.OutputFile + "\\" + fileName;
                if (File.Exists(filePath))
                {
                    using (StreamWriter writer = File.AppendText(filePath))
                    {
                        writer.WriteLine(text);
                    }
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine(text);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHandler.Write($"Chyba při zápisu do souboru: {ex.Message}");
                throw new Exception($"Chyba při zápisu do souboru: {ex.Message}");
            }
        }
        /// <summary>
        /// Načte textová data ze zadaného souboru.
        /// </summary>
        /// <param name="fileName">Název souboru, ze kterého se má číst text.</param>
        /// <returns>Načtený text ze souboru.</returns>
        /// <exception cref="Exception">Výjimka, která může být vyvolána při chybě při čtení ze souboru.</exception>
        public static string Read(string fileName)
        {
            try
            {
                if (!fileName.EndsWith(".txt"))
                {
                    throw new Exception("Nepodporovaný typ souboru.");
                }
                string filePath = ConfigHandler.Config.OutputFile + "\\" + fileName;
                Console.WriteLine();
                Console.WriteLine(filePath);
                Console.WriteLine();
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("Soubor neexistuje.", filePath);
                }
                if (!HasReadPermission(filePath))
                {
                    throw new UnauthorizedAccessException("Nemáte oprávnění ke čtení souboru.");
                }

                string text = File.ReadAllText(filePath);
                if (string.IsNullOrEmpty(text))
                {
                    throw new Exception("Soubor je prázdný.");
                }
                return text;
            }
            catch (Exception ex)
            {
                LogHandler.Write($"Chyba při čtení ze souboru: {ex.Message}");
                throw new Exception($"Chyba při čtení ze souboru: {ex.Message}");
            }
        }
        /// <summary>
        /// Zkontroluje, zda má aktuální uživatel oprávnění ke čtení zadaného souboru.
        /// </summary>
        /// <param name="filePath">Cesta k souboru.</param>
        /// <returns>True, pokud má uživatel oprávnění ke čtení souboru, jinak False.</returns>
        static bool HasReadPermission(string filePath)
        {
            try
            {
                using (FileStream fs = File.OpenRead(filePath))
                {
                    return true;
                }
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }

    }
}
