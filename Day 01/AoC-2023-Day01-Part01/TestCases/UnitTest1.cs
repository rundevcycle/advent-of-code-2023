using System.Reflection;

namespace TestCases
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void EmptyString_Zero()
        {
            string input = "";

            var mainApp = new MainApplication(input);

            mainApp.Run();

            Assert.AreEqual(0, mainApp.FinalSum);
        }


        [Test]
        public void OneLine_NoDigits_Zero()
        {
            string input = "abcdefg";
            var mainApp = new MainApplication(input);
            mainApp.Run();
            Assert.AreEqual(0, mainApp.FinalSum);
        }


        [Test]
        public void OneLine_OneDigit()
        {
            string input = "abcd2efg";
            var mainApp = new MainApplication(input);
            mainApp.Run();
            Assert.AreEqual(22, mainApp.FinalSum);
        }


        [Test]
        public void OneLine_TwoDigits()
        {
            string input = "ab3cd2efg";
            var mainApp = new MainApplication(input);
            mainApp.Run();
            Assert.AreEqual(32, mainApp.FinalSum);
        }



    }
}