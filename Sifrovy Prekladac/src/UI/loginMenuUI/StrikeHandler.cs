using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;

namespace Sifrovy_Prekladac.src.UI.loginMenuUI
{
    /// <summary>
    /// Spravuje počet a manipulaci se striky.
    /// </summary>
    public static class StrikeHandler
    {
        /// <summary>
        /// Počet aktuálních striků.
        /// </summary>
        public static int Strike = 0;
        /// <summary>
        /// Maximální povolený počet striků.
        /// </summary>
        public static int MaxStrike { get; set; }
        /// <summary>
        /// Přidá jeden strike.
        /// </summary>
        public static void AddStrike()
        {
            Strike++;
        }
        /// <summary>
        /// Resetuje počet striků na nulu.
        /// </summary>
        public static void Reset()
        {
            Strike = 0;
        }
        /// <summary>
        /// Vrátí výsledek podle aktuálního stavu striků.
        /// </summary>
        /// <param name="errorMessage">Chybová zpráva.</param>
        /// <param name="suggestion">Návrh na řešení.</param>
        /// <returns>True, pokud je počet striků menší než maximální povolený počet, jinak false.</returns>
        public static bool GetResult(string errorMessage, string suggestion)
        {
            string message = "\n  Chyba: " + errorMessage + "\n  Máte " + Strike + "/" + MaxStrike + " striků. " + suggestion + "\n";
            if (Strike < MaxStrike)
            {
                Console.WriteLine(message, Color.DarkRed);
                return true;
            }
            else
            {
                message = "\n  " + errorMessage + "\n  Dosáhli jste " + MaxStrike + " striků.\n";
                Console.WriteLine(message, Color.DarkRed);
                Thread.Sleep(1000);
                Reset();
                return false;
            }
        }
    }
}
