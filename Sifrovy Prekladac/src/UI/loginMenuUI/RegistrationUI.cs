using Sifrovy_Prekladac.src.logs;
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
            Console.WriteLine("Pro vrácení do hlavní nabídky napište exit.");
            Console.WriteLine(InitialMenu.Oddelovac);
            Console.WriteLine("Registrace nového uživatele:\n");

            string input = string.Empty;
            int strike = 0;
            int maxStrike = 3;
            bool mainRun = true;
            User newUser = new User();
            newUser.SetRole(Role.User);
            while (mainRun)
            {
                Console.Write("Zadejte uživatelské jméno: ");
                input = Console.ReadLine().ToLower().Replace(" ", "");
                bool userExists = false;
                if (input == "exit")
                {
                    userExists = true;
                    mainRun = false;
                }
                foreach (User u in ListOfUsers.GetAll())
                {
                    if (u.Username == input)
                    {
                        userExists = true;
                    }
                }
                if (!userExists && input != "anonymous" && !string.IsNullOrEmpty(input))
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
                            Console.WriteLine("\n  Chyba: " + ex.Message);
                            strike++;
                            if (strike < maxStrike)
                            {
                                Console.Write("  Máte " + strike + "/" + maxStrike + " striků. ");
                                Console.WriteLine("Zadejte validní uživatelské jméno!\n");
                            }
                            else
                            {
                                Console.WriteLine("  Dosáhli jste " + strike + " striků.\n");
                                run = false;
                                strike = 0;
                            }
                        }
                    }

                }
                else if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("\n  Chyba: Uživatelské jméno nesmí být prázdné!");
                    strike++;
                    if (strike < maxStrike)
                    {
                        Console.Write("  Máte " + strike + "/" + maxStrike + " striků. ");
                        Console.WriteLine("Zadejte validní uživatelské jméno!\n");
                    }
                    else
                    {
                        Console.WriteLine("  Dosáhli jste " + strike + " striků.");
                        mainRun = false;
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("\n  Chyba: Uživatel s tímto uživatelským jménem již existuje!");
                    strike++;
                    if (strike < maxStrike)
                    {
                        Console.Write("  Máte " + strike + "/" + maxStrike + " striků. ");
                        Console.WriteLine("Zadejte validní uživatelské jméno!\n");
                    }
                    else
                    {
                        Console.WriteLine("  Dosáhli jste " + strike + " striků.");
                        mainRun = false;
                        Thread.Sleep(1000);
                    }
                }
            }

        }
    }
}
