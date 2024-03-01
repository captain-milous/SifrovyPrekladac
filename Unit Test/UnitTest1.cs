using Sifrovy_Prekladac.src.sifry;

namespace Unit_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestMOR();
            TestCES();
            TestREV();
        }
        /*
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }*/
        [Test]
        public void TestMOR()
        {
            // Šifrování
            MorseovaSifra mor = new MorseovaSifra("Ahoj svìte! Dnes máme pøekrásný den!");
            
            // Dešifrování
            mor = new MorseovaSifra(".- | .... | --- | .--- || ... | ...- | - | . || -.. | -. | . | ... || -- | -- | . || .--. | . | -.- | .-. | ... | -. || -.. | . | -. |||", true);
            
            Assert.Pass();
        }

        [Test]
        public void TestCES()
        {
            // Šifrování
            CaesarovaSifra test = new CaesarovaSifra("Ahoj Michale, jak se dneska máš?", 4);

            // Dešifrování
            test = new CaesarovaSifra("ELSN QMGLEPI, NEO WI HRIWOE QEW?", 4, true);

            Assert.Pass();
        }
        [Test]
        public void TestREV()
        {
            ReverzniSifra test = new ReverzniSifra("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            Assert.Pass();
        }
    }
}