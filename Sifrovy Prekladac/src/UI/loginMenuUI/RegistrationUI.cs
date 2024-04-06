using Sifrovy_Prekladac.src.logs;
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
using StrikeHandler = Sifrovy_Prekladac.src.UI.loginMenuUI.StrikeHandler;

namespace Sifrovy_Prekladac.src.UI.loginMenuUI
{
    /// <summary>
    /// Obsahuje uživatelské rozhraní pro registraci nového uživatele.
    /// </summary>
    public static class RegistrationUI
    {
        /// <summary>
        /// Spustí uživatelské rozhraní pro registraci.
        /// </summary>
        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("Nápověda: ", Color.Green);
            Console.Write("Pro vrácení do hlavní nabídky napište: back.", Color.Green);
            Console.WriteLine(InitialMenu.Oddelovac, Color.Green);
            Console.WriteLine("Registrace nového uživatele:\n");
            string input = string.Empty;
            StrikeHandler.MaxStrike = 3;
            bool mainRun = true;
            User newUser = new User();
            newUser.SetRole(Role.User);
            while (mainRun)
            {
                bool exit = false;
                Console.Write("Zadejte uživatelské jméno: ");
                input = Console.ReadLine().ToLower().Replace(" ", "");
                bool userExists = false;
                if (input == "back")
                {
                    exit = true;
                    userExists = true;
                }
                foreach (User u in ListOfUsers.GetAll())
                {
                    if (u.Username == input)
                    {
                        userExists = true;
                    }
                }
                if (!userExists && input != "anonymous" && input != "admin" && input != "administrator" && !string.IsNullOrEmpty(input))
                {
                    newUser.SetUsername(input);
                    bool run = true;
                    while (run)
                    {
                        Console.Write("Zadejte heslo: ");
                        string pass1 = Console.ReadLine();
                        try
                        {
                            newUser.SetPassword(pass1);
                            Console.Write("Znovu heslo: ");
                            string pass2 = Console.ReadLine();
                            if (pass1 != pass2)
                            {
                                throw new Exception("Hesla se neshodují.");
                            }
                            else
                            {
                                LogHandler.Write($"Byl vytvořen nový uživatel {newUser.Username}.");
                                ListOfUsers.Add(newUser);
                                run = false;
                                mainRun = false;
                                MainMenu.Start(newUser);
                            }
                            Console.WriteLine(newUser.Password);
                        }
                        catch (Exception ex)
                        {
                            StrikeHandler.AddStrike();
                            run = StrikeHandler.GetResult(ex.Message, "Zadejte validní heslo!");
                        }
                    }
                    StrikeHandler.Reset();
                }
                else if (exit)
                {
                    mainRun = false;
                }
                else if (string.IsNullOrEmpty(input))
                {
                    StrikeHandler.AddStrike();
                    mainRun = StrikeHandler.GetResult("Uživatelské jméno nesmí být prázdné.", "Zadejte validní uživatelské jméno!");
                }
                else
                {
                    StrikeHandler.AddStrike();
                    mainRun = StrikeHandler.GetResult("Uživatel s tímto uživatelským jménem již existuje.", "Zadejte validní uživatelské jméno!");
                }
            }
            StrikeHandler.Reset();
        }
    }
}
