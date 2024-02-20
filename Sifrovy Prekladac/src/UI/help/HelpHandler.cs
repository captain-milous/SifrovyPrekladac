using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sifrovy_Prekladac.src.UserHandler;

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
            { Commands.activesifry, "Zobrazí seznam šifer, které tato verze programu podporuje." },
            { Commands.cmdsifrovani, "Šifruje/dešifruje zadaný text z klávesnice." },
            { Commands.filesifrovani, "Šifruje/dešifruje zadaný text z textového souboru." },
            { Commands.historie, "Zobrazí vaší historii šifrování." },
            { Commands.favourites, "Zobrazí vaše oblíbené šifry." },
            { Commands.activeusers, "Zobrazí seznam aktivních uživatelů." },
            { Commands.journal, "Zobrazí logy." },
            { Commands.clear, "Vyčistí command linku." },
            { Commands.logout, "Odhlásí uživatele" },
            { Commands.exit, "Ukončí program" }
        };
        /// <summary>
        /// Slovník obsahující autorizační prvky pro použití příkazu. 
        /// </summary>
        public static Dictionary<Commands, Role> Authorization = new Dictionary<Commands, Role>() 
        {
            { Commands.exit, Role.Anonymous },
            { Commands.clear, Role.Anonymous },
            { Commands.logout, Role.Anonymous },
            { Commands.cmdsifrovani, Role.Anonymous },
            { Commands.filesifrovani, Role.Anonymous },
            { Commands.activesifry, Role.Anonymous },
            { Commands.historie, Role.User },
            { Commands.favourites, Role.User },
            { Commands.activeusers, Role.Admin },
            { Commands.journal, Role.Admin },
        };
        /// <summary>
        /// Zobrazí nápovědu obsahující popisy jednotlivých příkazů.
        /// </summary>
        public static void Start(User user)
        {
            Console.WriteLine("Příkazy, které můžete použít:\n");
            foreach (Commands command in description.Keys)
            {
                if(user.Role == Role.Admin)
                {
                    if (Authorization[command] != Role.User && command != Commands.cmdsifrovani && command != Commands.filesifrovani && command != Commands.activesifry)
                    {
                        Console.WriteLine("   - " + command.ToString() + ": " + description[command].ToString());
                    }
                }
                else if(user.Role == Role.User) 
                {
                    if (Authorization[command] != Role.Admin)
                    {
                        Console.WriteLine("   - " + command.ToString() + ": " + description[command].ToString());
                    }
                }
                else if (user.Role == Role.Anonymous)
                {
                    if (Authorization[command] == Role.Anonymous)
                    {
                        Console.WriteLine("   - " + command.ToString() + ": " + description[command].ToString());
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
