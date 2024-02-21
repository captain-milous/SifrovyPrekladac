using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sifrovy_Prekladac.src.logs;
using Sifrovy_Prekladac.src.UserHandler;

namespace Sifrovy_Prekladac.src.historie
{
    /// <summary>
    /// Třída pro správu historie zpráv uživatelů.
    /// </summary>
    public static class HistoryHandler
    {
        /// <summary>
        /// Cesta k adresáři, kde je ukládána historie zpráv.
        /// </summary>
        private static string historyPath = string.Empty;
        /// <summary>
        /// Zapíše zprávu do historie daného uživatele.
        /// </summary>
        /// <param name="user">Uživatel, jehož historie se má aktualizovat.</param>
        /// <param name="text">Text zprávy k uložení do historie.</param>
        public static void Write(User user, string text)
        {
            historyPath = "users\\" + user.Username + "\\historie";
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            string filePath = historyPath + "\\" + timestamp.ToString() + ".txt";
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }
                File.AppendAllText(filePath, text);
            }
            catch
            {
                LogHandler.Write("Nastala chyba při zapsání do " + user.Username + " historie.");
            }
        }
    }
}
