using Sifrovy_Prekladac.src.logs;
using Sifrovy_Prekladac.src.sifry;
using Sifrovy_Prekladac.src.UI;
using Sifrovy_Prekladac.src.UserHandler;

namespace Sifrovy_Prekladac.src
{
    /// <summary>
    /// Obsahuje vstupní bod aplikace.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Vstupní bod aplikace.
        /// </summary>
        /// <param name="args">Argumenty příkazového řádku</param>
        static void Main(string[] args)
        {
            // Test
            CaesarovaSifra test = new CaesarovaSifra("Ahoj Michale, jak se dneska máš?",-3,false);
            Console.WriteLine(test);
            test = new CaesarovaSifra("DKRM PLFKDOH MDN VH GQHVND PDV",3,true);
            Console.WriteLine(test);
            /*
            bool run = true;
            // configurace
            try
            {
                CheckStructure.Start();
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                LogFileWriter.WriteEmergancy();
                run = false; 
            }
            InitialMenu.Start(run);*/
        }
    }
}