using Sifrovy_Prekladac.src.logs;
using Sifrovy_Prekladac.src.UserHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.UI
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
            Console.Clear();
            Console.WriteLine("Pro vrácení do hlavní nabídky napište exit.");
            Console.WriteLine(InitialMenu.Oddelovac);
            Console.WriteLine("Přihlášení již existujícího uživatele:\n");

            string input = string.Empty;
            int strike = 0;
            int maxStrike = 3;
            bool mainRun = true;
            User user = new User();
            while (mainRun)
            {
                Console.Write("Uživatelské jméno: ");
                input = Console.ReadLine().ToLower().Replace(" ", "");
                bool userExists = false;
                foreach(User u in ListOfUsers.GetAll())
                {
                    if(u.Username.ToLower() == input)
                    {
                        userExists = true;
                        user = u;
                    }
                }
                if(input == "exit") 
                {
                    userExists = false;
                    mainRun = false;
                }
                if (userExists)
                {
                    bool run = true;
                    int pswStrike = 0;
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
                            Console.WriteLine("\n  Chyba: Špatné heslo!");
                            pswStrike++;

                            if (pswStrike < maxStrike)
                            {
                                Console.Write("  Máte " + pswStrike + "/" + maxStrike + " pokusů.");
                                Console.WriteLine("Zadejte správné heslo!\n");
                            }
                            else
                            {
                                Console.WriteLine("  Dosáhli jste " + strike + " pokusů.");
                                run = false;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\n  Chyba: Tento uživatel neexistuje.");
                    strike++; 
                    if (strike < maxStrike)
                    {
                        Console.Write("  Máte " + strike + "/" + maxStrike + " striků.");
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
