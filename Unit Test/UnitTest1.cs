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
            // �ifrov�n�
            MorseovaSifra mor = new MorseovaSifra("Ahoj sv�te! Dnes m�me p�ekr�sn� den!");
            
            // De�ifrov�n�
            mor = new MorseovaSifra(".- | .... | --- | .--- || ... | ...- | - | . || -.. | -. | . | ... || -- | -- | . || .--. | . | -.- | .-. | ... | -. || -.. | . | -. |||", true);
            
            Assert.Pass();
        }

        [Test]
        public void TestCES()
        {
            // �ifrov�n�
            CaesarovaSifra test = new CaesarovaSifra("Ahoj Michale, jak se dneska m�?", 4);

            // De�ifrov�n�
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