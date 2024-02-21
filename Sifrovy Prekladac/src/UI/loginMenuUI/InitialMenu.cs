using Sifrovy_Prekladac.src.UI.mainMenUI;
using Sifrovy_Prekladac.src.UserHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static string Oddelovac = "\n----------------------------------------------------------------------------------\n";
        /// <summary>
        /// Spustí přihlašovací menu.
        /// </summary>
        /// <param name="run">True, pokud má být menu spuštěno, jinak False.</param>
        public static void Start(bool run)
        {
            if (run)
            {
                Console.WriteLine(Oddelovac);
                Console.WriteLine("Vítejte v programu Šifrový Překladač!");
                Console.WriteLine("Autor: Miloš Tesař C4b");
                Console.WriteLine("Verze: 3.6");
                Console.WriteLine(Oddelovac);
                Console.WriteLine("Zmáčkněte Enter pro start.");
                Console.ReadLine();
            }
            while (run)
            {
                Console.Clear();
                Console.WriteLine(Oddelovac);
                Console.WriteLine("MENU\n1 - Přihlášení\n2 - Registrace\n3 - Anonymní režim\n4 - Konec");
                Console.Write("Vyberte možnost: ");
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
                        MainMenu.Start(new User());
                        break;
                    case 4:
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
                { "anonym", 3 },
                { "a", 3 },
                { "konec", 4 },
                { "kon", 4 },
                { "k", 4 },
                { "exit", 4 },
                { "x", 4 },
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
