using Colorful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Console = System.Console;

namespace Sifrovy_Prekladac.src.UI.loginMenuUI
{
    /// <summary>
    /// Třída obsahující metody pro získání uživatelského jména a hesla z konzole.
    /// </summary>
    public static class GetFromCmdUI
    {
        /// <summary>
        /// Metoda pro získání hesla z konzole.
        /// </summary>
        /// <returns>Heslo z konzole.</returns>
        public static string GetPassword()
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (cki.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        Console.Write("\b\0\b");
                        sb.Length--;
                    }

                    continue;
                }
                else if (!char.IsControl(cki.KeyChar)) { }

                Console.Write('*');
                sb.Append(cki.KeyChar);
            }
            return sb.ToString();
        }
        /// <summary>
        /// Metoda pro získání uživatelského jména z konzole.
        /// </summary>
        /// <returns>Uživatelské jméno z konzole.</returns>
        /// <exception cref="Exception">Vyhazuje výjimku, pokud uživatelské jméno obsahuje zakázané znaky.</exception>
        public static string GetUsername()
        {
            StringBuilder sb = new StringBuilder();
            string forbitten = @"[\\/:*?""|]";
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (cki.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        Console.Write("\b\0\b");
                        sb.Length--;
                    }

                    continue;
                }
                else if (!char.IsControl(cki.KeyChar)) { }

                if (Regex.IsMatch(cki.KeyChar.ToString(), forbitten))
                {
                    throw new Exception("Přihlašovací jméno nesmí obsahovat speciální znaky (\\/:*?\"\"|).");
                }
                else
                {
                    Console.Write(cki.KeyChar.ToString());
                    sb.Append(cki.KeyChar);
                }
            }
            return sb.ToString();
        }
    }
}
