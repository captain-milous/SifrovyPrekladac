using Sifrovy_Prekladac.src.sifry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sifrovy_Prekladac
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MorseovaSifra test = new MorseovaSifra("Miloš Tesař", false);
            Console.WriteLine(test.ToString());
            test = new MorseovaSifra("Miloš Tesař", "REV", false);
            Console.WriteLine(test.ToString());
            test = new MorseovaSifra("Miloš Tesař", "NUM", false);
            Console.WriteLine(test.ToString());
            CaesarovaSifra test2 = new CaesarovaSifra("ABCDEFGHIJKLMNOPQ", 2, false);
            Console.WriteLine(test2);
            test2 = new CaesarovaSifra("CDEFGHIJKLMNOPQRS", 2, true);
            Console.WriteLine(test2);



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
