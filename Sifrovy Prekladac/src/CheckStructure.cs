using Sifrovy_Prekladac.src.conf;
using Sifrovy_Prekladac.src.logs;
using Sifrovy_Prekladac.src.UserHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
                WriteNewConfig();
            }
            try
            {
                ConfigHandler.Load();
                LogHandler.ChangeLogPath(ConfigHandler.Config.LogFilePath);
                if (!Directory.Exists(ConfigHandler.Config.OutputFile))
                {
                    Directory.CreateDirectory(ConfigHandler.Config.OutputFile);
                }
                if (!Directory.Exists(ConfigHandler.Config.InputFile))
                {
                    Directory.CreateDirectory(ConfigHandler.Config.InputFile);
                }
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
                            if (u.Role != Role.Admin)
                            {
                                Directory.CreateDirectory(uPath);
                                Directory.CreateDirectory(uPath + "\\historie");
                                Directory.CreateDirectory(uPath + "\\favourites");
                                LogHandler.Write($"Byla vytvořena složka pro uživatele {u.Username}");
                            }
                        }
                        if (u.Role == Role.Admin)
                        {
                            u.SetPassword(ConfigHandler.Config.AdminPassword);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Při načítání z konfigurace se něco pokazilo: " + ex.Message);
            }
            Console.WriteLine("Konfigurace byla úspěšně načtena.");
        }
        /// <summary>
        /// Vytvoří nový element s daným názvem a textovým obsahem.
        /// </summary>
        /// <param name="doc">XmlDocument instance, do které bude nový element přidán.</param>
        /// <param name="elementName">Název nového elementu.</param>
        /// <param name="text">Textový obsah nového elementu.</param>
        /// <returns>XmlElement instance reprezentující nově vytvořený element.</returns>
        static XmlElement CreateElementWithText(XmlDocument doc, string elementName, string text)
        {
            XmlElement element = doc.CreateElement(elementName);
            element.InnerText = text;
            return element;
        }
        /// <summary>
        /// Vytvoří nový konfigurační soubor a uloží ho do adresáře aplikace.
        /// </summary>
        /// <exception cref="Exception">Vyjímka, která se vyvolá, pokud selže vytvoření konfiguračního souboru.</exception>
        private static void WriteNewConfig()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlElement root = doc.CreateElement("Configuration");
                doc.AppendChild(root);
                XmlComment comment1 = doc.CreateComment("Důležité pro chod aplikace. Neměnit pokud není potřeba!");
                root.AppendChild(comment1);
                root.AppendChild(CreateElementWithText(doc, "LogFilePath", "log\\system.log"));
                root.AppendChild(CreateElementWithText(doc, "ListOfUsersFilePath", "users\\ActiveUsers.xml"));
                XmlComment comment2 = doc.CreateComment("Změna administrátorského helsa");
                root.AppendChild(comment2);
                root.AppendChild(CreateElementWithText(doc, "AdminPassword", "Heslo123*"));
                XmlComment comment3 = doc.CreateComment("Změna složky pro import a export textových souborů. \nnapř.: <InputFile>C:\\Users\\username\\Desktop</InputFile>");
                root.AppendChild(comment3);
                root.AppendChild(CreateElementWithText(doc, "InputFile", "data"));
                root.AppendChild(CreateElementWithText(doc, "OutputFile", "data"));
                doc.Save("config.xml");
            } 
            catch 
            {
                throw new Exception("Vytvoření konfigurace se nezdařilo.");
            }
        }
    }
}
