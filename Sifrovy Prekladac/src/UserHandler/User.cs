using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Sifrovy_Prekladac.src.UserHandler
{
    /// <summary>
    /// Reprezentuje uživatele v systému.
    /// </summary>
    public class User
    {
        private string _username;
        private string _password;
        private Role _role;
        /// <summary>
        /// Získává nebo nastavuje uživatelské jméno.
        /// </summary>
        public string Username 
        { 
            get { return _username; }
            set { _username = value; } 
        }
        /// <summary>
        /// Získává nebo nastavuje heslo uživatele.
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        /// <summary>
        /// Získává nebo nastavuje roli uživatele.
        /// </summary>
        public Role Role
        {
            get { return _role; }
            set { _role = value; }
        }
        /// <summary>
        /// Inicializuje instanci třídy User s výchozími hodnotami pr anonymního uživatele.
        /// </summary>
        public User() 
        {
            _username = "Anonymous";
            _password = string.Empty;
            _role = Role.Anonymous;
        }
        /// <summary>
        /// Inicializuje instanci třídy User s uživatelským jménem a heslem.
        /// </summary>
        /// <param name="username">Uživatelské jméno</param>
        /// <param name="password">Heslo</param>
        public User(string username, string password)
        {
            Role = Role.User;
            SetUsername(username);
            SetPassword(password);
        }
        /// <summary>
        /// Převede objekt na řetězec obsahující uživatelské jméno a roli.
        /// </summary>
        /// <returns>Řetězec reprezentující uživatele</returns>
        public override string ToString()
        {
            if (Role == Role.Anonymous || Role == Role.Admin)
            {
                return Role.ToString();
            }
            return Username + "(" + Role.ToString() + ")";
        }
        /// <summary>
        /// Kontroluje, zda je heslo platné. Heslo musí mít alespoň 8 znaků, obsahovat malá i velká písmenka, číslice a zvláštní znaky.
        /// </summary>
        /// <param name="password">Heslo k ověření</param>
        /// <returns>True, pokud je heslo platné, jinak False</returns>
        private bool IsPasswordValid(string password)
        {
            return password.Length >= 8 &&
                   Regex.IsMatch(password, "[a-z]") &&
                   Regex.IsMatch(password, "[A-Z]") &&
                   Regex.IsMatch(password, "[0-9]") &&
                   Regex.IsMatch(password, "[^a-zA-Z0-9]");
        }
        /// <summary>
        /// Nastaví heslo uživatele po ověření jeho platnosti.
        /// </summary>
        /// <param name="password">Nové heslo</param>
        /// <exception cref="Exception">Výjimka vyvolaná, pokud je heslo neplatné</exception>
        public void SetPassword(string password)
        {
            if (!IsPasswordValid(password) && Role != Role.Anonymous)
            {
                throw new Exception("Heslo musí mít alespoň 8 znaků, obsahovat malá i velká písmenka, číslice a zvláštní znaky.");
            }
            else
            {
                using (SHA1 sha1 = SHA1.Create())
                {
                    byte[] hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
                    _password = BitConverter.ToString(hashBytes).Replace("-", "");
                }
            }

        }
        /// <summary>
        /// Nastaví uživatelské jméno.
        /// </summary>
        /// <param name="username">Nové uživatelské jméno</param>
        /// <exception cref="Exception">Výjimka vyvolaná, pokud je uživatelské jméno neplatné</exception>
        public void SetUsername(string username)
        {
            if (!string.IsNullOrEmpty(username) || username != Role.Anonymous.ToString()) 
            { 
                _username = username;
            }
            else
            {
                throw new Exception($"{username} není validní.");
            }
        }
        /// <summary>
        /// Nastaví roli uživatele.
        /// </summary>
        /// <param name="role">Nová role</param>
        /// <exception cref="Exception">Výjimka vyvolaná, pokud je role anonymní</exception>
        public void SetRole(Role role)
        {
            if (role != Role.Anonymous) 
            {
                _role = role;
            }
            else
            {
                throw new Exception("Uživatel nesmí být anonymní!");
            }
        }
    }

}
