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
            bool testing = false;
            if(!testing) 
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
            else
            {

                MorseovaSifra mor = new MorseovaSifra("Ahoj světe! Dnes máme překrásný den!");
                string expectedResult = ".- | .... | --- | .--- || ... | ...- | - | . || -.. | -. | . | ... || -- | -- | . || .--. | . | -.- | .-. | ... | -. || -.. | . | -. |||";
                if (mor.EncText == expectedResult)
                {
                    Console.WriteLine("Fail");
                }
                Console.WriteLine(mor);
                Console.WriteLine();
                // Test
                CaesarovaSifra test = new CaesarovaSifra("Ahoj Michale, jak se dneska máš?", TextMethods.Abeceda.Length, false);
                Console.WriteLine(test);
                test = new CaesarovaSifra("DKRM PLFKDOH MDN VH GQHVND PDV",3,true);
                Console.WriteLine(test);

                // Mezerova
                MezerovaSifra test2 = new MezerovaSifra("Tohle je veliký test, ahoj!");
                Console.WriteLine(test2);
                test2 = new MezerovaSifra("SU NP GI KM DF IK DF UW DF KM HJ JL XZ SU DF RT SU ZB GI NP IK", true);
                Console.WriteLine(test2);

                ProhazenaSifra test3 = new ProhazenaSifra("Ahoj Michale, jak se dneska máš?");
                Console.WriteLine(test3);
                test3 = new ProhazenaSifra("AO IHL,JKS NSAMS?A KEDE A EACMJH", true);
                Console.WriteLine(test3);

                PetronilkaSifra test4 = new PetronilkaSifra("Ahoj Michale, jak se dneska máš?");
                Console.WriteLine(test4);
            }            
        }
    }
}