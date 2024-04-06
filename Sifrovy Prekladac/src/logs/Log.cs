using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.logs
{
    /// <summary>
    /// Třída reprezentující záznam v logu obsahující informace o zprávě, autorovi a datu záznamu.
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Získá nebo nastaví zprávu logu.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Získá nebo nastaví autora logu.
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Získá nebo nastaví datum a čas vytvoření logu.
        /// </summary>
        public DateTime LogDate { get; set; }
        /// <summary>
        ///  Inicializuje novou instanci třídy Log s konkrétním autorem, zprávou a aktuálním datem a časem.
        /// </summary>
        /// <param name="author">Autor logu.</param>
        /// <param name="message">Zpráva logu.</param>
        public Log(string author, string message)
        {
            Author = author;
            Message = message;
            LogDate = DateTime.Now;
        }
        /// <summary>
        /// Inicializuje novou instanci třídy Log s konkrétním autorem, zprávou a určeným datem a časem.
        /// </summary>
        /// <param name="author">Autor logu.</param>
        /// <param name="message">Zpráva logu.</param>
        /// <param name="logDate">Datum a čas vytvoření logu.</param>
        public Log(string author, string message, DateTime logDate)
        {
            Author = author;
            Message = message;
            LogDate = logDate;
        }
        /// <summary>
        /// Převede objekt Log na textovou reprezentaci ve formátu "Datum (Autor): Zpráva".
        /// </summary>
        /// <returns>Textová reprezentace logu.</returns>
        public override string ToString()
        {
            return LogDate + " (" + Author + "): " + Message + "\n";
        }
    }
}
