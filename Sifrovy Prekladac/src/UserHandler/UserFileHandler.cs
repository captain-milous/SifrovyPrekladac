using Sifrovy_Prekladac.src.conf;
using Sifrovy_Prekladac.src.logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sifrovy_Prekladac.src.UserHandler
{
    /// <summary>
    /// Třída obsahující metody pro manipulaci s uživatelskými daty a ukládání/načítání do/z XML souboru.
    /// </summary>
    public static class UserFileHandler
    {
        /// <summary>
        /// Název výchozího XML souboru pro ukládání a načítání seznamu uživatelů.
        /// </summary>
        private static string fileName = ConfigHandler.Config.ListOfUsersFilePath;
        /// <summary>
        /// Uloží seznam uživatelů do XML souboru.
        /// </summary>
        /// <param name="users">Seznam uživatelů k uložení.</param>
        public static void UploadUserListToXML(List<User> users)
        {
            try
            {
                if (!fileName.EndsWith(".xml"))
                {
                    throw new Exception("Typ souboru není podporován.");
                }
                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                    Console.WriteLine("Vytvořeno");
                }
                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
                using (TextWriter writer = new StreamWriter(fileName))
                {
                    serializer.Serialize(writer, users);
                }
            }
            catch (Exception ex)
            {
                LogHandler.Write($"Nastala neočekávaná chyba při načítání do {fileName}: {ex.Message}");
                throw new Exception($"Nastala neočekávaná chyba při načítání do {fileName}: {ex.Message}");
            }
        }
        /// <summary>
        /// Načte seznam uživatelů z XML souboru.
        /// </summary>
        /// <returns>Seznam načtených uživatelů.</returns>
        public static List<User> LoadUserListFromXML()
        {
            List<User> users = new List<User>();
            try
            {
                if (!fileName.EndsWith(".xml"))
                {
                    throw new Exception("Typ souboru není podporován.");
                }
                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                }
                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
                using (TextReader reader = new StreamReader(fileName))
                {
                    users = (List<User>)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                LogHandler.Write($"Nastala neočekávaná chyba při čtení z {fileName}: {ex.Message}");
                throw new Exception($"Nastala neočekávaná chyba při čtení z {fileName}: {ex.Message}");
            }
            return users;
        }
    }
}
