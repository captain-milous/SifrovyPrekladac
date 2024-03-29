﻿using Sifrovy_Prekladac.src.conf;
using Sifrovy_Prekladac.src.logs;
using Sifrovy_Prekladac.src.sifry.related;
using Sifrovy_Prekladac.src.UI.help;
using Sifrovy_Prekladac.src.UI.loginMenuUI;
using Sifrovy_Prekladac.src.UI.mainMenUI.SifrovaciUI;
using Sifrovy_Prekladac.src.UserHandler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.UI.mainMenUI
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
            { "s", "sifrovani" },
            { "sif", "sifrovani" },
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
        public static Dictionary<ActiveSifry, string> ActveSifry = new Dictionary<ActiveSifry, string>()
        {
            { ActiveSifry.Caesarova_Sifra, "Posune všechna písmena o vámi zadaný počet v abecedě" },
            { ActiveSifry.Klavesnicova_Sifra, "Popis" },
            { ActiveSifry.Mezerova_Sifra, "Popis" },
            { ActiveSifry.Morseova_Sifra, "Popis" },
            { ActiveSifry.Numericka_Sifra, "Přemění písmena na čísla, dle jejich indexu v abecedě." },
            { ActiveSifry.Obracena_ABC_Sifra, "Změní písmena tak, aby A=Z, B=Y, atd." },
            { ActiveSifry.Petronilka, "Popis" },
            { ActiveSifry.Prohazena_Sifra, "Přemění text tak ayste museli číst jak ze předu, tak zezadu." },
            { ActiveSifry.Reverzni_Sifra, "Převrátí text tak, aby jste ho museli číst odzadu." },
            { ActiveSifry.Telefonni_Sifra, "Popis" }
        };
        /// <summary>
        /// Oddělovač pro vizuální oddělení sekce.
        /// </summary>
        private static string Oddelovac = InitialMenu.Oddelovac;
        /// <summary>
        /// Přihlášený uživatel
        /// </summary>
        private static User _user = new User();
        /// <summary>
        /// Veřejný přístup k přihlášenému uživateli.
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
            if (LoggedInUser.Role != Role.Anonymous)
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
                    case Commands.sifrovani:
                        // UI pro zašifrovaní/rozšifrovaní textu
                        if (LoggedInUser.Role != Role.Admin)
                        {
                            LoadInputUI.Start();
                            Console.Clear() ;
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
                            foreach (ActiveSifry sifra in ActveSifry.Keys)
                            {
                                Console.WriteLine("  - " + sifra + ": " + ActveSifry[sifra]);
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
                        if (LoggedInUser.Role == Role.User)
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
