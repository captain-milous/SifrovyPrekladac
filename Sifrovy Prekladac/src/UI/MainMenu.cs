using Sifrovy_Prekladac.src.logs;
using Sifrovy_Prekladac.src.UserHandler;
using System;
using System.Collections.Generic;
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
        /// Přihlášení do aplikace pod určitým uživatelem
        /// </summary>
        /// <param name="user"></param>
        public static void Start(User user)
        {
            LogHandler.Write($"{user.Username} se úspěšně přihlásit do aplikace.");
            Console.Clear();
            Console.WriteLine(user + " se přihlásil!");
            Thread.Sleep(5000);
        }
    }
}
