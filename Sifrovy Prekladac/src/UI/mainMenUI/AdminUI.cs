using Sifrovy_Prekladac.src.logs;
using Sifrovy_Prekladac.src.UserHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.UI.mainMenUI
{
    /// <summary>
    /// Poskytuje uživatelské rozhraní pro správu administrátorských funkcí.
    /// </summary>
    public static class AdminUI
    {
        /// <summary>
        /// Zobrazí obsah systémového žurnálu.
        /// </summary>
        public static void Journal()
        {
            try
            {
                string[] allLines = File.ReadAllLines("log\\system.log");
                foreach (string line in allLines)
                {
                    Console.WriteLine("  " + line);
                }
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("  Nepovedlo se načíst z logů.");
                LogHandler.Write("Nezdařily se přečíst logy.");
            }
        }
        /// <summary>
        /// Zobrazí seznam aktivních uživatelů.
        /// </summary>
        public static void ActiveUsers()
        {
            try
            {
                Console.WriteLine("Aktivní uživatelé:");
                foreach (User user in ListOfUsers.GetAll())
                {
                    Console.WriteLine("  " + user.Username);
                }
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("  Nezdařilo se načíst aktivní uživatele.");
                LogHandler.Write("Nezdařilo se načíst aktivní uživatele.");
            }
        }
    }
}
