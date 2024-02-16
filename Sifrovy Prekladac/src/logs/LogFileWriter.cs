using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.logs
{
    /// <summary>
    /// Statická třída obsahující metody pro zápis logů do souboru.
    /// </summary>
    public static class LogFileWriter
    {
        /// <summary>
        /// Cesta k souboru, kam budou ukládány logy v případě mimořádné události.
        /// </summary>
        private static string emergancyLog = "log\\emergency.log";
        /// <summary>
        /// Cesta k hlavnímu souboru, kam budou ukládány systémové logy.
        /// </summary>
        public static string LogPath = "log\\system.log";

        /// <summary>
        /// Zapíše zprávu do hlavního logovacího souboru.
        /// </summary>
        /// <param name="message">Objekt logu, který má být zapsán.</param>
        public static void Write(Log message)
        {
            try
            {
                if (!File.Exists(LogPath))
                {
                    File.Create(LogPath).Close();
                }
                File.AppendAllText(LogPath, message.ToString());
            }
            catch
            {
                WriteEmergancy();
            }
        }

        /// <summary>
        /// Zápis mimořádné události do odděleného souboru, změna cesty logu a ukončení programu.
        /// </summary>
        public static void WriteEmergancy()
        {
            LogHandler.ChangeLogPath(emergancyLog);
            Write(new Log("Emergancy","Došlo k neočekávané fatální chybě."));
            Environment.Exit(0);
        }
    }
}
