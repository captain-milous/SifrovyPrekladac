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
            // Šifrování
            MorseovaSifra mor = new MorseovaSifra("Ahoj svìte! Dnes máme pøekrásný den!");
            string expectedResult = ".- | .... | --- | .--- || ... | ...- | - | . || -.. | -. | . | ... || -- | -- | . || .--. | . | -.- | .-. | ... | -. || -.. | . | -. |||";
            if (mor.EncText == expectedResult)
            {
                Assert.Fail(mor.ToString() +" != " + expectedResult);
            }
            // Dešifrování
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