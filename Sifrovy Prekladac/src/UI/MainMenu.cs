using Sifrovy_Prekladac.src.logs;
using Sifrovy_Prekladac.src.UserHandler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.UI
{
    /// <summary>
    /// Tato třída reprezentuje Aplikaci do které se chcete přihlásit.
    /// </summary>
    public static class MainMenu
    {
        /// <summary>
        /// 
        /// </summary>
        private static string Oddelovac = InitialMenu.Oddelovac;
        /// <summary>
        /// Přihlášení do aplikace pod určitým uživatelem
        /// </summary>
        /// <param name="user"></param>
        public static void Start(User user)
        {
            LogHandler.Write($"{user.Username} se úspěšně přihlásit do aplikace.");
            Console.Clear();
            Console.WriteLine(user + " se přihlásil!");
            Thread.Sleep(5000);
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine(Oddelovac);
                switch (user.Role)
                {
                    case Role.Admin:

                        break;
                    case Role.User:

                        break;
                    case Role.Anonymous:

                        break;
                    default:
                        throw new Exception("Tato situace by nikdy neměla nastat");
                }
                Console.WriteLine("Havní menu\n1 - Registrace\n2 - Přihlášení\n3 - Anonymní režim\n4 - Konec");
                Console.Write("Vyberte možnost: ");
                int input = SelectOption(Console.ReadLine());
                Console.WriteLine();
                switch (input)
                {
                    case 1:
                        RegistrationUI.Start();
                        break;
                    case 2:
                        LoginUI.Start();
                        break;
                    case 3:
                        MainMenu.Start(new User());
                        break;
                    case 4:
                        Console.WriteLine("Ukončil/a jste program.");
                        Thread.Sleep(1000);
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Vyberte prosím validní možnost!");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        private static int SelectOption(string input)
        {
            int output = -1;

            return output;
        }
    }
}
