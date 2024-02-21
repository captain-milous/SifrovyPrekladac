using Sifrovy_Prekladac.src.conf;
using Sifrovy_Prekladac.src.logs;
using Sifrovy_Prekladac.src.sifry;
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
            { "cmd", "cmdsifrovani" },
            { "fil", "filesifrovani" },
            { "fav", "favourites" },
            { "his", "historie" },
            { "jor", "journal" },
            { "as", "activesifry" },
            { "au", "activeusers" },
            { "act", "activeusers" },
        };
        /// <summary>
        /// Slovník obsahující popisy aktivních šifer této verze programu.
        /// </summary>
        static Dictionary<ActiveSifry, string> actveSifry = new Dictionary<ActiveSifry, string>() 
        { 
            { ActiveSifry.Morseova_Sifra, "Popis" }, 
            { ActiveSifry.Caesarova_Sifra, "Popis" }, 
            { ActiveSifry.Petronilka, "Popis" }, 
            { ActiveSifry.Mezerova_Sifra, "Popis" }, 
            { ActiveSifry.Klavesnicova_Sifra, "Popis" },
            { ActiveSifry.Telefonni_Sifra, "Popis" },
            { ActiveSifry.Numericka_Sifra, "Popis" },
            { ActiveSifry.Reverzni_Sifra, "Popis" },
            { ActiveSifry.Obracena_ABC_Sifra, "Popis" },
            { ActiveSifry.Prohazena_Sifra, "Popis" },
        };
        /// <summary>
        /// Oddělovač pro vizuální oddělení sekce.
        /// </summary>
        private static string Oddelovac = InitialMenu.Oddelovac;
        /// <summary>
        /// 
        /// </summary>
        private static User _user = new User();
        /// <summary>
        /// 
        /// </summary>
        public static User LoggedInUser { get { return _user; } private set { _user = value; } }
        /// <summary>
        /// Přihlášení do aplikace pod určitým uživatelem
        /// </summary>
        /// <param name="user">Uživatel</param>
        public static void Start(User user)
        {
            LoggedInUser = user;
            LogHandler.Write($"{LoggedInUser.Username} se úspěšně přihlásit do aplikace.");
            Console.Clear();
            if(LoggedInUser.Role != Role.Anonymous)
            {
                Console.WriteLine(LoggedInUser + " se přihlásil!\n");
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
                        // Zobrazí dostupné příkazy pro daného uživatele
                        HelpHandler.Start(LoggedInUser);
                        break;
                    case Commands.cmdsifrovani:
                        // UI pro zašifrovaní/rozšifrovaní textu
                        if(LoggedInUser.Role != Role.Admin)
                        {
                            SifrovaniUI.Start(LoggedInUser);
                        }
                        else
                        {
                            Console.Write("K tomuto příkazu nemáte oprávnění. ");
                            Console.WriteLine("Napište 'help' pro nápovědu.\n");
                        }
                        break;
                    case Commands.filesifrovani:
                        // UI pro zašifrovaní/rozšifrovaní textu
                        if (LoggedInUser.Role != Role.Admin)
                        {
                            SifrovaniUI.Start(LoggedInUser);
                        }
                        else
                        {
                            Console.Write("K tomuto příkazu nemáte oprávnění. ");
                            Console.WriteLine("Napište 'help' pro nápovědu.\n");
                        }
                        break;
                    case Commands.activesifry:
                        // List aktivních šifer s krátkým popisem
                        if (LoggedInUser.Role != Role.Admin)
                        {
                            Console.WriteLine("Seznam aktivních šifer: \n");
                            foreach(ActiveSifry sifra in actveSifry.Keys)
                            {
                                Console.WriteLine("  - " + sifra + ": " + actveSifry[sifra]);
                            }
                            Console.WriteLine("\nPodrobný popis každé z těchto šifer můžeš nalézt v dokumentaci.\n");
                        }
                        else
                        {
                            Console.Write("K tomuto příkazu nemáte oprávnění. ");
                            Console.WriteLine("Napište 'help' pro nápovědu.\n");
                        }
                        break;
                    case Commands.favourites:
                        // Zobrazení oblíbených šifer pro uživatele
                        if (LoggedInUser.Role == Role.User)
                        {
                            UserUI.Favourites(LoggedInUser);
                        }
                        else
                        {
                            Console.Write("K tomuto příkazu nemáte oprávnění. ");
                            Console.WriteLine("Napište 'help' pro nápovědu.\n");
                        }
                        break;
                    case Commands.historie:
                        // Zobrazení Historie šifrování pro uživatele
                        if(LoggedInUser.Role == Role.User)
                        {
                            UserUI.Historie(LoggedInUser);
                        }
                        else
                        {
                            Console.Write("K tomuto příkazu nemáte oprávnění. ");
                            Console.WriteLine("Napište 'help' pro nápovědu.\n");
                        }
                        break;
                    case Commands.journal:
                        // Zobrazení logů pro Admina
                        if (LoggedInUser.Role == Role.Admin)
                        {
                            AdminUI.Journal();
                        }
                        else
                        {
                            Console.Write("K tomuto příkazu nemáte oprávnění. ");
                            Console.WriteLine("Napište 'help' pro nápovědu.\n");
                        }
                        break;
                    case Commands.activeusers:
                        // Zobrazení Aktivních uživatelů pro Admina
                        if (LoggedInUser.Role == Role.Admin)
                        {
                            AdminUI.ActiveUsers();
                        }
                        else
                        {
                            Console.Write("K tomuto příkazu nemáte oprávnění. ");
                            Console.WriteLine("Napište 'help' pro nápovědu.\n");
                        }
                        break;
                    case Commands.clear:
                        // Vyčištění commandů
                        Console.Clear();
                        break;
                    case Commands.logout:
                        // Odhlášení uživatele
                        LogHandler.Write($"{LoggedInUser.Username} se odhlásil.");
                        run = false;
                        break;
                    case Commands.exit:
                        // Ukončení Programu
                        Console.WriteLine("Ukončil/a jste program.");
                        Console.WriteLine(Oddelovac);
                        LogHandler.Write($"{LoggedInUser.Username} ukončil program.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        run = false;
                        Environment.Exit(0);
                        break;
                    default:
                        // neplatný příkaz
                        Console.Write("Neplatný příkaz. ");
                        Console.WriteLine("Napište 'help' pro nápovědu.\n");
                        break;
                }
            }
        }
    }
}
