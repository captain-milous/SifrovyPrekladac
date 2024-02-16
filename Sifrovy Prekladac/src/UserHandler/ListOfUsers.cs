using Sifrovy_Prekladac.src.logs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.UserHandler
{
    /// <summary>
    /// Obsahuje operace pro práci s kolekcí uživatelů.
    /// </summary>
    public static class ListOfUsers
    {
        /// <summary>
        /// Seznam uživatelů.
        /// </summary>
        private static List<User> Users = new List<User>();
        /// <summary>
        /// Načte uživatele ze souboru.
        /// </summary>
        public static void LoadUsers()
        {
            try
            {
                Users = UserFileHandler.LoadUserListFromXML();
            }
            catch
            {
                Users = new List<User>();
                UploadUsers();
            }
        }
        /// <summary>
        /// Nahraje uživatele do souboru.
        /// </summary>
        public static void UploadUsers()
        {
            UserFileHandler.UploadUserListToXML(Users);
        }
        /// <summary>
        /// Vyčistí seznam uživatelů.
        /// </summary>
        public static void Clear()
        {
            Users.Clear();
        }
        /// <summary>
        /// Přidá uživatele do seznamu.
        /// </summary>
        /// <param name="user">Uživatel k přidání</param>
        /// <exception cref="Exception">Výjimka vyvolaná, pokud je uživatel anonymní</exception>
        public static void Add(User user)
        {
            bool exists = false;
            foreach (User u in Users)
            {
                if(user.Username == u.Username)
                {
                    exists = true;
                }
            }
            if (!exists)
            {
                if (user.Role != Role.Anonymous)
                {
                    Users.Add(user);
                    UploadUsers();
                    CheckStructure.Start();
                }
                else
                {
                    throw new Exception("Anonymní role nelze přidat do Listu uživatelů.");
                }
            }
            else
            {
                throw new Exception($"Uživatel {user.Username} již existuje.");
            }           
        }
        /// <summary>
        /// Odebere uživatele ze seznamu.
        /// </summary>
        /// <param name="username">Jméno uživatele k odstranění</param>
        public static void Remove(String username)
        {
            foreach (User user in Users)
            {
                if (user.Username == username)
                {
                    Users.Remove(user);
                    UploadUsers();
                    CheckStructure.Start();
                }
            }
        }
        /// <summary>
        /// Vrátí uživatele podle zadaného jména.
        /// </summary>
        /// <param name="username">Jméno uživatele k získání</param>
        /// <returns>Uživatel odpovídající zadanému jménu</returns>
        /// <exception cref="Exception">Výjimka vyvolaná, pokud uživatel není nalezen nebo je anonymní</exception>
        public static User Get(String username)
        {
            User user = new User();
            foreach (User u in Users)
            {
                if (u.Username == username)
                {
                    user = u;
                }
            }
            if(user.Role != Role.Anonymous)
            {
                return user;
            }
            else
            {
                throw new Exception($"Uživatel {username} nebyl nalezen.");
            }
        }
        /// <summary>
        /// Vrátí všechny uživatele.
        /// </summary>
        /// <returns>Seznam všech uživatelů.</returns>
        public static List<User> GetAll()
        {
            return Users;
        }
        /// <summary>
        /// Převede seznam uživatelů na řetězec obsahující seznam všechn aktivních uživatelů.
        /// </summary>
        /// <returns>Řetězec reprezentující seznam uživatelů</returns>
        public static string ToString()
        {
            string output = "Aktivní uživatelé:\n";
            for(int i = 1; i <= Users.Count; i++)
            {
                output += $"{i}. {Users[i].ToString}\n";
            }
            return output;
        }

    }
}
