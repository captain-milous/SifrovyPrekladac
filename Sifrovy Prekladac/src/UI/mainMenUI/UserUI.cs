﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sifrovy_Prekladac.src.logs;
using Sifrovy_Prekladac.src.UserHandler;

namespace Sifrovy_Prekladac.src.UI.mainMenUI
{
    /// <summary>
    /// 
    /// </summary>
    public static class UserUI
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        private static List<string> GetTxtFiles(string Path)
        {
            List<string> txtFiles = new List<string>();
            try
            {
                string[] files = Directory.GetFiles(Path);
                var sortedFiles = files.OrderBy(soubor => File.GetCreationTime(soubor));
                foreach (var file in sortedFiles)
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
        /// <param name="user"></param>
        public static void Favourites(User user)
        {
            string favouritePath = $"users\\{user.Username}\\favourites";
            List<string> favourites = GetTxtFiles(favouritePath);
            if (favourites.Count > 0)
            {
                Console.WriteLine("Tvé oblíbené šifry: \n");
                foreach (string favourite in favourites)
                {
                    string[] allLines = File.ReadAllLines(favourite);
                    if (allLines.Length > 0)
                    {
                        string firstLine = allLines[0];
                        Console.WriteLine("  " + firstLine);
                    }
                    else
                    {
                        LogHandler.Write($"{favourite} je prázdný.");
                    }
                }
            }
            else
            {
                Console.WriteLine("  Nemáte zatím žádnou šifru uloženou v oblíbených.");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public static void Historie(User user)
        {
            string historiePath = $"users\\{user.Username}\\historie";
            List<string> historie = GetTxtFiles(historiePath);
            if (historie.Count > 0)
            {
                Console.WriteLine("Tvá historie šifry: \n");
                foreach (string hist in historie)
                {
                    string[] allLines = File.ReadAllLines(hist);
                    if (allLines.Length > 0)
                    {
                        string firstLine = allLines[0];
                        Console.WriteLine("  " + File.GetCreationTime(hist) + ": " + firstLine);
                    }
                    else
                    {
                        LogHandler.Write($"{hist} je prázdný.");
                    }
                }
            }
            else
            {
                Console.WriteLine("  Neprovedl jste zatím žádné šifrování.");
            }
            Console.WriteLine();
        }
    }
}
