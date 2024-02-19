using Sifrovy_Prekladac.src.conf;
using Sifrovy_Prekladac.src.logs;
using Sifrovy_Prekladac.src.UserHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src
{
    /// <summary>
    /// Obsahuje metody pro kontrolu struktury systému.
    /// </summary>
    public static class CheckStructure
    {
        /// <summary>
        /// Spustí kontrolu struktury systému.
        /// </summary>
        /// <exception cref="Exception">Výjimka vyvolaná, pokud konfigurační soubor neexistuje nebo dojde k chybě při načítání konfigurace</exception>
        public static void Start()
        {
            if (!File.Exists("config.xml"))
            {
                throw new Exception("Konfigurační soubor neexistuje.");
            }
            else
            {
                try
                {
                    ConfigHandler.Load();
                    LogHandler.ChangeLogPath(ConfigHandler.Config.LogFilePath);
                    if (!Directory.Exists("users"))
                    {
                        Directory.CreateDirectory("users");
                    }
                    ListOfUsers.LoadUsers();
                    if (ListOfUsers.GetAll().Count == 0)
                    {
                        try
                        {
                            User admin = new User("Admin", ConfigHandler.Config.AdminPassword);
                            admin.SetRole(Role.Admin);
                            ListOfUsers.Add(admin);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception($"Chyba při vytváření administrátorské role. {ex.Message}");
                        }
                    }
                    else if (ListOfUsers.GetAll().Count() > 0)
                    {
                        foreach (User u in ListOfUsers.GetAll())
                        {
                            string uPath = "users\\" + u.Username;
                            if (!Directory.Exists(uPath))
                            {
                                if(u.Role != Role.Admin)
                                {
                                    Directory.CreateDirectory(uPath);
                                    Directory.CreateDirectory(uPath + "\\historie");
                                    Directory.CreateDirectory(uPath + "\\favourites");
                                    LogHandler.Write($"Byla vytvořena složka pro uživatele {u.Username}");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Při načítání z konfigurace se něco pokazilo: " + ex.Message);
                }
            }
            Console.WriteLine("Konfigurace byla úspěšně načtena.");
        }
    }
}
