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
            { "co" , "compress" },
            { "de" , "decompress" },
            { "in" , "input" },
            { "out" , "output" },
        };
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
                    case Commands.journal:
                        //string text = FileHandler.ReadFromFile("log\\LogFile.txt");
                        //Console.WriteLine(text);
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

        private static int SelectOption(string input)
        {
            int output = -1;

            return output;
        }
    }
}
