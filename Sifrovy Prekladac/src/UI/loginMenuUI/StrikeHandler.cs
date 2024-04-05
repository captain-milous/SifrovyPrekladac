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
    /// 
    /// </summary>
    public static class StrikeHandler
    {
        /// <summary>
        /// 
        /// </summary>
        public static int Strike = 0;
        /// <summary>
        /// 
        /// </summary>
        public static int MaxStrike { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static void AddStrike()
        {
            Strike++;
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Reset()
        {
            Strike = 0;
        } 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="suggestion"></param>
        /// <returns></returns>
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
