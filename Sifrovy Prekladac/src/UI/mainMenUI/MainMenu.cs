using Sifrovy_Prekladac.src.conf;
using Sifrovy_Prekladac.src.logs;
using Sifrovy_Prekladac.src.sifry.related;
using Sifrovy_Prekladac.src.UI.help;
using Sifrovy_Prekladac.src.UI.mainMenUI.SifrovaciUI;
using Sifrovy_Prekladac.src.UserHandler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;

namespace Sifrovy_Prekladac.src.UI.mainMenUI
{
    /// <summary>
    /// Tato třída reprezentuje Aplikaci do které se chcete přihlásit.
    /// </summary>
    public static class MainMenu
    {
        /// <summary>
        /// Oddělovač pro vizuální oddělení sekce.
        /// </summary>
        private static string Oddelovac = Print.Oddelovac;
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
                string welcome = LoggedInUser + " se přihlásil!\n";
                Console.WriteLine(welcome, Color.Green);
                Thread.Sleep(1000);
            }
            Console.Clear();
            Console.Write("Napište 'help' pro nápovědu.", Color.Green);
            Console.WriteLine(Oddelovac, Color.Green);
            bool run = true;
            while (run)
            {
                #region Input from user
                string lineStartText = user + "> ";
                Console.Write(lineStartText);
                Commands userCommand = TryGetCommand(Console.ReadLine().ToLower());
                if(userCommand == Commands.def)
                {
                    LogHandler.Write($"{user.Username} použil neexistující příkaz.");
                }
                Console.WriteLine();
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
                            GetInputUI.Start();
                            Console.Clear();
                            Console.Write("Napište 'help' pro nápovědu.", Color.Green);
                            Console.WriteLine(Oddelovac, Color.Green);
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
                                WriteActiveSifra(sifra);
                            }
                            Console.WriteLine("\nPodrobný popis každé z těchto šifer můžeš nalézt v dokumentaci.\n", Color.Blue);
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
                        Console.Write("Napište 'help' pro nápovědu.", Color.Green);
                        Console.WriteLine(Oddelovac, Color.Green);
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
                        Console.WriteLine("Neplatný příkaz. Napište 'help' pro nápovědu.\n");
                        break;
                }
            }
        }

        /// <summary>
        /// Vybere možnost z textového vstupu.
        /// </summary>
        /// <param name="input">Textový vstup</param>
        /// <returns>Číslo vybrané možnosti</returns>
        private static Commands TryGetCommand(string input)
        {
            Commands output = Commands.def;
            try
            {
                foreach (Commands command in HelpHandler.Zkratky.Keys)
                {
                    if (HelpHandler.Zkratky[command] == input || command.ToString() == input)
                    {
                        output = command;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return output;
        }
        /// <summary>
        /// Slovník obsahující popisy aktivních šifer této verze programu.
        /// </summary>
        public static Dictionary<ActiveSifry, string> ActveSifry = new Dictionary<ActiveSifry, string>()
        {
            { ActiveSifry.Caesarova_Sifra, "Posune všechna písmena o vámi zadaný počet v abecedě." },
            { ActiveSifry.Klavesnicova_Sifra, "Změní jednotlivá písmena na dvojci písmen, které jsou vedle daného písmene na klávensnici." },
            { ActiveSifry.Mezerova_Sifra, "Změní jednotlivá písmena na dvojci písmen, která jsou před a po něm v abecedě." },
            { ActiveSifry.Morseova_Sifra, "Text je přeložen do morseovy abecedy." },
            { ActiveSifry.Numericka_Sifra, "Přemění písmena na čísla, dle jejich indexu v abecedě." },
            { ActiveSifry.Obracena_ABC_Sifra, "Změní písmena tak, aby A=Z, B=Y, atd." },
            { ActiveSifry.Petronilka, "Za písmena v unikátním klíči dosadíme číslice." },
            { ActiveSifry.Prohazena_Sifra, "Přemění text tak ayste museli číst jak ze předu, tak zezadu." },
            { ActiveSifry.Reverzni_Sifra, "Převrátí text tak, aby jste ho museli číst odzadu." },
            { ActiveSifry.Telefonni_Sifra, "Jednotlivá písmena se přeloží na telefonní čísla." }
        };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sifra"></param>
        private static void WriteActiveSifra(ActiveSifry sifra)
        {
            int pocMez = 20 - sifra.ToString().Length;
            Console.Write("  " + sifra + ": ");
            while(pocMez > 0)
            {
                Console.Write(" ");
                pocMez--;
            }
            Console.WriteLine(ActveSifry[sifra], Color.Green);
        }
    }
}
