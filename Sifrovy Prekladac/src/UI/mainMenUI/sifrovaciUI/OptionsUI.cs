using Sifrovy_Prekladac.src.conf;
using Sifrovy_Prekladac.src.static_methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovy_Prekladac.src.UI.mainMenUI.SifrovaciUI
{
    public static class OptionsUI
    {
        public static void InputFromCmdOrFile()
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine();
                Console.Write("Chcete načíst ze souboru? (A/n) ");
                Console.WriteLine("(Ano - Načtení ze souboru; Ne - Načtení z cmd; Exit - Zpět do hlavního menu)");
                Console.Write("Vaše volba: ");
                string answer = Console.ReadLine().ToLower();
                if (answer.StartsWith("n"))
                {
                    OptionsUI.InputFromCmdOrFile();
                    run = false;
                }
                else if (answer.StartsWith("y") || answer.StartsWith("a"))
                {

                }
                else if (answer == "exit" || answer == "x")
                {
                    run = false;
                }
                else
                {
                    run = true;
                    Console.WriteLine("Neplatná volba!");
                }
            }
            Console.WriteLine();
        }
    }
}
