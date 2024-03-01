using Sifrovy_Prekladac.src.logs;
using Sifrovy_Prekladac.src.sifry;
using Sifrovy_Prekladac.src.static_methods;
using Sifrovy_Prekladac.src.UI.loginMenuUI;
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
            bool run = true;
            // configurace
            try
            {
                CheckStructure.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                LogFileWriter.WriteEmergancy();
                run = false;
            }
            InitialMenu.Start(run);
        }
    }
}