using Sifrovy_Prekladac.src.conf;
using Sifrovy_Prekladac.src.logs;
using Sifrovy_Prekladac.src.UI.help;
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
        /// Slovník obsahující zkratky pro příkazy.
        /// </summary>
        static Dictionary<string, string> Zkratky = new Dictionary<string, string>()
        {
            { "?", "help" },
            { "he", "help" },
            { "x", "exit" },
            { "ex", "exit" },
            { "exi", "exit" },
            { "out", "logout" },
            { "sif", "sifrovani" },
            { "fav", "favourites" },
            { "his", "historie" },
            { "jor", "journal" },
            { "au", "activeusers" },
            { "act", "activeusers" },
        };
        /// <summary>
        /// Oddělovač pro vizuální oddělení sekce.
        /// </summary>
        private static string Oddelovac = InitialMenu.Oddelovac;
        /// <summary>
        /// Přihlášení do aplikace pod určitým uživatelem
        /// </summary>
        /// <param name="user">Uživatel</param>
        public static void Start(User user)
        {
            LogHandler.Write($"{user.Username} se úspěšně přihlásit do aplikace.");
            Console.Clear();
            if(user.Role != Role.Anonymous)
            {
                Console.WriteLine(user + " se přihlásil!\n");
            }
            Console.WriteLine("Napište 'help' pro nápovědu.");
            Console.WriteLine(Oddelovac);
            bool run = true;
            while (run)
            {
                #region Input from user
                string lineStartText = user + "> ";
                Console.Write(lineStartText);
                string input = Console.ReadLine().ToLower();
                Console.WriteLine();
                if (input.Length < 4)
                {
                    if (Zkratky.TryGetValue(input, out string hodnota))
                    {
                        input = hodnota;
                    }
                }
                Commands userCommand = Commands.def;
                try
                {
                    userCommand = (Commands)Enum.Parse(typeof(Commands), input, true);
                }
                catch
                {
                    LogHandler.Write($"{user.Username} použil neexistující příkaz.");
                }
                #endregion
                switch (userCommand)
                {
                    case Commands.help:
                        HelpHandler.Start(user);
                        break;
                    case Commands.sifrovani:
                        SifrovaniUI.Start(user);
                        break;
                    case Commands.favourites:
                        if (user.Role == Role.User)
                        {
                            UserUI.Favourites(user);
                        }
                        else
                        {
                            Console.WriteLine("Napište 'help' pro nápovědu.");
                        }
                        break;
                    case Commands.historie:
                        if(user.Role == Role.User)
                        {
                            UserUI.Historie(user);
                        }
                        else
                        {
                            Console.WriteLine("Napište 'help' pro nápovědu.");
                        }
                        break;
                    case Commands.journal:
                        if (user.Role == Role.Admin)
                        {
                            AdminUI.Journal();
                        }
                        else
                        {
                            Console.WriteLine("Napište 'help' pro nápovědu.");
                        }
                        break;
                    case Commands.activeusers:
                        if (user.Role == Role.Admin)
                        {
                            AdminUI.ActiveUsers();
                        }
                        else
                        {
                            Console.WriteLine("Napište 'help' pro nápovědu.");
                        }
                        break;
                    case Commands.logout:
                        LogHandler.Write($"{user.Username} se odhlásil.");
                        run = false;
                        break;
                    case Commands.exit:
                        Console.WriteLine("Ukončil/a jste program.");
                        Console.WriteLine(Oddelovac);
                        LogHandler.Write($"{user.Username} ukončil program.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        run = false;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Napište 'help' pro nápovědu.");
                        break;
                }
            }
        }
    }
}
