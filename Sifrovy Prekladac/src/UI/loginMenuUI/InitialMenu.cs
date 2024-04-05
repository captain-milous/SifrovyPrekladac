using Sifrovy_Prekladac.src.UI.mainMenUI;
using Sifrovy_Prekladac.src.UserHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;

namespace Sifrovy_Prekladac.src.UI.loginMenuUI
{
    /// <summary>
    /// Obsahuje přihlašovací menu aplikace.
    /// </summary>
    public static class InitialMenu
    {
        /// <summary>
        /// Oddělovač pro vizuální oddělení sekce.
        /// </summary>
        public static string Oddelovac = Print.Oddelovac;
        /// <summary>
        /// Spustí přihlašovací menu.
        /// </summary>
        /// <param name="run">True, pokud má být menu spuštěno, jinak False.</param>
        public static void Start(bool run)
        {
            if (run)
            {
                Thread.Sleep(400);
                Print.Introduction("3.8");
            }
            while (run)
            {
                Console.Clear();
                Print.Initial();
                int input = SelectOption(Console.ReadLine());
                Console.WriteLine();
                switch (input)
                {
                    case 1:
                        LoginUI.Start();
                        break;
                    case 2:
                        RegistrationUI.Start();
                        break;
                    case 3:
                        Console.WriteLine("Ukončil/a jste program.");
                        Console.WriteLine(Oddelovac);
                        Thread.Sleep(1000);
                        Console.Clear();
                        run = false;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Vyberte prosím validní možnost!");
                        Thread.Sleep(1000);
                        break;
                }
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
                { "registrace", 1 },
                { "reg", 1 },
                { "r", 1 },
                { "prihlaseni", 2 },
                { "pri", 2 },
                { "log", 2 },
                { "p", 2 },
                { "konec", 3 },
                { "kon", 3 },
                { "k", 3 },
                { "exit", 3 },
                { "x", 3 },
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
    }
}
