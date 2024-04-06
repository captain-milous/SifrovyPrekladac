using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sifrovy_Prekladac.src.UserHandler;
using System.Drawing;
using Colorful;
using Console = Colorful.Console;

namespace Sifrovy_Prekladac.src.UI.help
{
    /// <summary>
    /// Statická třída obsahující metody pro zobrazení nápovědy k jednotlivým příkazům.
    /// </summary>
    public static class HelpHandler
    {
        /// <summary>
        /// Slovník obsahující popisy jednotlivých příkazů pro zobrazení nápovědy.
        /// </summary>
        private static Dictionary<Commands, string> description = new Dictionary<Commands, string>()
        {
            //{ Commands.help, "Zobrazí seznam možných komandů." },
            { Commands.sifrovani, "Šifruje/dešifruje zadaný text do jakékoli aktivní šifry z klávesnice nebo z textového souboru." },
            { Commands.historie, "Zobrazí vaší historii šifrování." },
            { Commands.activesifry, "Zobrazí seznam šifer, které tato verze programu podporuje." },
            //{ Commands.favourites, "Zobrazí vaše oblíbené šifry." }, Dodělat!
            { Commands.activeusers, "Zobrazí seznam aktivních uživatelů." },
            { Commands.journal, "Zobrazí logy." },
            { Commands.clear, "Vyčistí command linku." },
            { Commands.logout, "Odhlásí uživatele" },
            { Commands.exit, "Ukončí program" }
        };

        /// <summary>
        /// Slovník obsahující zkratky pro příkazy.
        /// </summary>
        public static Dictionary<Commands, string> Zkratky = new Dictionary<Commands, string>()
        {
            { Commands.help, "?" },
            { Commands.exit, "x" },
            { Commands.logout, "out" },
            { Commands.clear, "clr" },
            { Commands.sifrovani, "sif" },
            { Commands.favourites, "fav" },
            { Commands.historie, "his" },
            { Commands.journal , "jor" },
            { Commands.activesifry , "as" },
            { Commands.activeusers , "au" },
        };
        /// <summary>
        /// Slovník obsahující autorizační prvky pro použití příkazu. 
        /// </summary>
        public static Dictionary<Commands, Role> Authorization = new Dictionary<Commands, Role>() 
        {
            { Commands.exit, Role.Anonymous },
            { Commands.clear, Role.Anonymous },
            { Commands.logout, Role.Anonymous },
            { Commands.sifrovani, Role.Anonymous },
            { Commands.activesifry, Role.Anonymous },
            { Commands.historie, Role.User },
            { Commands.favourites, Role.User },
            { Commands.activeusers, Role.Admin },
            { Commands.journal, Role.Admin },
        };
        /// <summary>
        /// Zobrazí nápovědu obsahující popisy jednotlivých příkazů.
        /// </summary>
        /// <param name="user">Uživatel pro kterého se bude nápověda zobrazovat</param>
        public static void Start(User user)
        {
            Console.WriteLine("Příkazy, které můžete použít:\n");
            foreach (Commands command in description.Keys)
            {
                if(user.Role == Role.Admin)
                {
                    if (Authorization[command] != Role.User && command != Commands.sifrovani && command != Commands.activesifry)
                    {
                        PrintCommand(command);
                    }
                }
                else if(user.Role == Role.User) 
                {
                    if (Authorization[command] != Role.Admin)
                    {
                        PrintCommand(command);
                    }
                }
                else if (user.Role == Role.Anonymous)
                {
                    if (Authorization[command] == Role.Anonymous)
                    {
                        PrintCommand(command);
                    }
                }
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Vytiskne příkaz spolu s jeho popisem a zkratkou.
        /// </summary>
        /// <param name="command">Příkaz k vytisknutí.</param>
        private static void PrintCommand(Commands command)
        {
            int delkaZkr = Zkratky[command].Length;
            int pocMez = 3 - delkaZkr;
            while (pocMez > 0)
            {
                Console.Write(" ");
                pocMez--;
            }
            Console.Write("  [");
            Console.Write(Zkratky[command].ToString(),Color.Blue);
            Console.Write("] ");            
            Console.Write(command.ToString()+": ");
            int delkaCom = command.ToString().Length;
            pocMez = 12 - delkaCom;
            while (pocMez > 0)
            {
                Console.Write(" ");
                pocMez--;
            }
            Console.WriteLine(description[command].ToString(),Color.Green);
        }
    }
}
