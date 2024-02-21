using Sifrovy_Prekladac.src.sifry;

namespace Unit_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestMOR();
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
            string expectedResult = ".- | .... | --- | .--- || ... | ...- | - | . || -.. | -. | . | ... || -- | -- | . || .--. | . | -.- | .-. | ... | -. || -.. | . | -. |||";
            if (mor.EncText == expectedResult)
            {
                Assert.Fail(mor.ToString() +" != " + expectedResult);
            }
            // De�ifrov�n�
            mor = new MorseovaSifra(".- | .... | --- | .--- || ... | ...- | - | . || -.. | -. | . | ... || -- | -- | . || .--. | . | -.- | .-. | ... | -. || -.. | . | -. |||", true);
            expectedResult = "AHOJ SVETE DNES MAME PREKRASNY DEN";
            if (mor.DecText == expectedResult)
            {
                Assert.Fail(expectedResult);
            }
            Assert.Pass();
        }
    }
}