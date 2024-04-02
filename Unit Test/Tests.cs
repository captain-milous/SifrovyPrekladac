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
            TestOAS();
            TestPET();
            TestMEZ();
            TestKLA();
            TestTEL();
            TestNUM();
            TestSHU();
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
            MorseovaSifra mor = new MorseovaSifra("Jeèná je vìèná!");
            
            // Dešifrování
            mor = new MorseovaSifra(".--- | . | -. || .--- | . || ...- | -. |||", true);
            
            Assert.Pass();
        }

        [Test]
        public void TestCES()
        {
            // Šifrování
            CaesarovaSifra test = new CaesarovaSifra("Jeèná je vìèná!", 4);

            // Dešifrování
            test = new CaesarovaSifra("NIGRE NI ZIGRE!", 4, true);

            Assert.Pass();
        }

        [Test]
        public void TestREV()
        {
            // Šifrování i dešifrování
            ReverzniSifra test = new ReverzniSifra("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            Assert.Pass();
        }

        [Test]
        public void TestOAS()
        {
            // Šifrování
            ObracenaAbcSifra test = new ObracenaAbcSifra("Jeèná je vìèná!");

            // Dešifrování
            test = new ObracenaAbcSifra("QVXMZ QV EVXMZ!", true);

            Assert.Pass();
        }

        [Test]
        public void TestPET()
        {
            // Šifrování
            PetronilkaSifra test = new PetronilkaSifra("Jeèná je vìèná!", "PETRONILKA");

            // Dešifrování
            test = new PetronilkaSifra("J1C59 J1 V1C59!", "PETRONILKA", true);

            Assert.Pass();
        }

        [Test]
        public void TestMEZ()
        {
            // Šifrování
            MezerovaSifra test = new MezerovaSifra("Jeèná je vìèná!");

            // Dešifrování
            test = new MezerovaSifra("IK DF BD MO ZB IK DF UW DF BD MO ZB", true);

            Assert.Pass();
        }

        [Test]
        public void TestKLA()
        {
            // Šifrování
            KlavesnicovaSifra test = new KlavesnicovaSifra("Jeèná je vìèná!", "CZK");

            // Dešifrování
            test = new KlavesnicovaSifra("HK WR XV BM LS HK WR CB WR XV BM LS", "CZK", true);

            Assert.Pass();
        }

        [Test]
        public void TestTEL()
        {
            // Šifrování
            TelefonniSifra test = new TelefonniSifra("Jeèná je vìèná!", "DEF");

            // Dešifrování
            test = new TelefonniSifra("5 33 222 66 2 5 33 888 33 222 66 2", "DEF", true);

            Assert.Pass();
        }

        [Test]
        public void TestNUM()
        {
            // Šifrování
            NumerickaSifra test = new NumerickaSifra("Jeèná je vìèná!", "DEF");

            // Dešifrování
            test = new NumerickaSifra("10 5 3 14 1 10 5 22 5 3 14 1", "DEF", true);

            Assert.Pass();
        }

        [Test]
        public void TestSHU()
        {
            // Šifrování
            ObracenaAbcSifra test = new ObracenaAbcSifra("Jeèná je vìèná!");

            // Dešifrování
            test = new ObracenaAbcSifra("JCAJ EN!ACVE NE", true);

            Assert.Pass();
        }
    }
}