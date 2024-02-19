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
            { Commands.sifra, "Šifruje/dešifruje zadaný text." },
            { Commands.historie, "Zobrazí vaší historii šifrování." },
            { Commands.favourites, "Zobrazí vaše oblíbené šifry." },
            { Commands.users, "Zobrazí seznam aktivních uživatelů." },
            { Commands.journal, "Zobrazí logy." },
            { Commands.logout, "Odhlásí uživatele" },
            { Commands.exit, "Ukončí program" }
        };

        private static Dictionary<Commands, Role> authorization = new Dictionary<Commands, Role>() 
        {
            { Commands.exit, Role.Anonymous },
            { Commands.logout, Role.Anonymous },
            { Commands.sifra, Role.Anonymous },
            { Commands.historie, Role.User },
            { Commands.favourites, Role.User },
            { Commands.users, Role.Admin },
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
                    if (authorization[command] != Role.User)
                    {
                        Console.WriteLine("   - " + command.ToString() + ": " + description[command].ToString());
                    }
                }
                else if(user.Role == Role.User) 
                {
                    if (authorization[command] != Role.Admin)
                    {
                        Console.WriteLine("   - " + command.ToString() + ": " + description[command].ToString());
                    }
                }
                else if (user.Role == Role.Anonymous)
                {
                    if (authorization[command] == Role.Anonymous)
                    {
                        Console.WriteLine("   - " + command.ToString() + ": " + description[command].ToString());
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
