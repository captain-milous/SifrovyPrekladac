using Sifrovy_Prekladac.src.logs;
using Sifrovy_Prekladac.src.UI.mainMenUI;
using Sifrovy_Prekladac.src.UserHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;
using StrikeHandler = Sifrovy_Prekladac.src.UI.loginMenuUI.StrikeHandler;

namespace Sifrovy_Prekladac.src.UI.loginMenuUI
{
    /// <summary>
    /// Obsahuje uživatelské rozhraní pro přihlášení.
    /// </summary>
    public static class LoginUI
    {
        /// <summary>
        /// Spustí uživatelské rozhraní pro přihlášení.
        /// </summary>
        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("Nápověda: ", Color.Green);
            Console.WriteLine("Přihlašovací jméno do administrátorského účtu je: admin.",Color.Green);
            Console.WriteLine("Přihlašovací jméno do anonymního účtu je: anonym.", Color.Green);
            Console.Write("Pro vrácení do přihlašovací nabídky napište: back.", Color.Green);
            Console.WriteLine(InitialMenu.Oddelovac, Color.Green);
            Console.WriteLine("Přihlášení již existujícího uživatele:\n");

            string input = string.Empty;
            StrikeHandler.MaxStrike = 3;
            bool mainRun = true;
            User user = new User();
            while (mainRun)
            {
                Console.Write("Uživatelské jméno: ");
                input = Console.ReadLine().ToLower().Replace(" ", "");
                bool exit = false;

                if (input == "back")
                {
                    exit = true;
                }
                else if (input == "admin" || input == "administrator")
                {
                    user.SetUsername("Administrator");
                    user.SetRole(Role.Admin);
                    MainMenu.Start(user);
                    exit = true;
                }
                else if (input == "anonym" || input == "anonymous")
                {
                    MainMenu.Start(user);
                    exit = true;
                }
                else
                {
                    bool userExists = false;
                    foreach (User u in ListOfUsers.GetAll())
                    {
                        if (u.Username.ToLower() == input)
                        {
                            userExists = true;
                            user = u;
                        }
                    }
                    if (userExists)
                    {
                        bool run = true;
                        StrikeHandler.Reset();
                        while (run)
                        {
                            Console.Write("Vaše heslo: ");
                            input = Console.ReadLine();
                            using (SHA1 sha1 = SHA1.Create())
                            {
                                byte[] hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                                input = BitConverter.ToString(hashBytes).Replace("-", "");
                            }
                            if (user.Password.ToString() == input)
                            {
                                MainMenu.Start(user);
                                run = false;
                                mainRun = false;
                            }
                            else
                            {
                                LogHandler.Write(user.Username + " se pokusil přihlásit.");
                                StrikeHandler.AddStrike();
                                run = StrikeHandler.GetResult("Špatné heslo.", "Zadejte správné heslo!");
                            }
                        }
                        StrikeHandler.Reset();
                    }
                    else
                    {
                        StrikeHandler.AddStrike();
                        mainRun = StrikeHandler.GetResult("Tento uživatel neexistuje.", "Zadejte validní uživatelské jméno!");
                    }
                }

                if (exit)
                {
                    mainRun = false;
                }         
            }
        }
    }
}
