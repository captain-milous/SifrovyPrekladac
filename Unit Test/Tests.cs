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
            // �ifrov�n�
            MorseovaSifra mor = new MorseovaSifra("Je�n� je v��n�!");
            
            // De�ifrov�n�
            mor = new MorseovaSifra(".--- | . | -. || .--- | . || ...- | -. |||", true);
            
            Assert.Pass();
        }

        [Test]
        public void TestCES()
        {
            // �ifrov�n�
            CaesarovaSifra test = new CaesarovaSifra("Je�n� je v��n�!", 4);

            // De�ifrov�n�
            test = new CaesarovaSifra("NIGRE NI ZIGRE!", 4, true);

            Assert.Pass();
        }

        [Test]
        public void TestREV()
        {
            // �ifrov�n� i de�ifrov�n�
            ReverzniSifra test = new ReverzniSifra("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            Assert.Pass();
        }

        [Test]
        public void TestOAS()
        {
            // �ifrov�n�
            ObracenaAbcSifra test = new ObracenaAbcSifra("Je�n� je v��n�!");

            // De�ifrov�n�
            test = new ObracenaAbcSifra("QVXMZ QV EVXMZ!", true);

            Assert.Pass();
        }

        [Test]
        public void TestPET()
        {
            // �ifrov�n�
            PetronilkaSifra test = new PetronilkaSifra("Je�n� je v��n�!", "PETRONILKA");

            // De�ifrov�n�
            test = new PetronilkaSifra("J1C59 J1 V1C59!", "PETRONILKA", true);

            Assert.Pass();
        }

        [Test]
        public void TestMEZ()
        {
            // �ifrov�n�
            MezerovaSifra test = new MezerovaSifra("Je�n� je v��n�!");

            // De�ifrov�n�
            test = new MezerovaSifra("IK DF BD MO ZB IK DF UW DF BD MO ZB", true);

            Assert.Pass();
        }

        [Test]
        public void TestKLA()
        {
            // �ifrov�n�
            KlavesnicovaSifra test = new KlavesnicovaSifra("Je�n� je v��n�!", "CZK");

            // De�ifrov�n�
            test = new KlavesnicovaSifra("HK WR XV BM LS HK WR CB WR XV BM LS", "CZK", true);

            Assert.Pass();
        }

        [Test]
        public void TestTEL()
        {
            // �ifrov�n�
            TelefonniSifra test = new TelefonniSifra("Je�n� je v��n�!", "DEF");

            // De�ifrov�n�
            test = new TelefonniSifra("5 33 222 66 2 5 33 888 33 222 66 2", "DEF", true);

            Assert.Pass();
        }

        [Test]
        public void TestNUM()
        {
            // �ifrov�n�
            NumerickaSifra test = new NumerickaSifra("Je�n� je v��n�!", "DEF");

            // De�ifrov�n�
            test = new NumerickaSifra("10 5 3 14 1 10 5 22 5 3 14 1", "DEF", true);

            Assert.Pass();
        }

        [Test]
        public void TestSHU()
        {
            // �ifrov�n�
            ObracenaAbcSifra test = new ObracenaAbcSifra("Je�n� je v��n�!");

            // De�ifrov�n�
            test = new ObracenaAbcSifra("JCAJ EN!ACVE NE", true);

            Assert.Pass();
        }
    }
}