using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.logs
{
    /// <summary>
    /// Statická třída obsahující metody pro manipulaci s logy, zejména pro změnu cesty k hlavnímu logovacímu souboru.
    /// </summary>
    public static class LogHandler
    {
        /// <summary>
        /// Výchozí autor pro logy.
        /// </summary>
        private static string defaultAutor = "system";

        /// <summary>
        /// Změní cestu k hlavnímu logovacímu souboru.
        /// </summary>
        /// <param name="logPath">Nová cesta k logovacímu souboru.</param>
        public static void ChangeLogPath(string logPath)
        {
            if (!string.IsNullOrEmpty(logPath) || !logPath.EndsWith(".log"))
            {
                LogFileWriter.LogPath = logPath;
            }
            else
            {
                Write($"Nelze změnit cestu k LogFilu na {logPath}!");
            }
        }
        /// <summary>
        /// Zapíše zprávu do logu s výchozím autorem.
        /// </summary>
        /// <param name="message">Textová zpráva k zapsání.</param>
        public static void Write(string message)
        {
            LogFileWriter.Write(new Log(defaultAutor, message));
        }
        /// <summary>
        /// Zapíše zprávu do logu s konkrétním autorem.
        /// </summary>
        /// <param name="author">Autor zprávy.</param>
        /// <param name="message">Textová zpráva k zapsání.</param>
        public static void Write(string author, string message)
        {
            if(string.IsNullOrEmpty(author))
            {
                author = defaultAutor;
            }
            LogFileWriter.Write(new Log(author,message));
        }
    }
}
