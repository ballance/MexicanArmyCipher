using System;
using System.Collections.Generic;
using MexicanArmyCipherBreaker.Library;
using NUnit.Framework;

namespace MexicanArmyCipherBreaker.Test
{
    [TestFixture]
    public class CipherBreakerTests
    {
        LetterDistributionCollection letterDistributionEnglish = new LetterDistributionCollection();
        CryptoWheelSystem<string> cryptoWheelSystem = new CryptoWheelSystem<string>();

        [SetUp]
        public void TestSetup()
        {
            letterDistributionEnglish.Load();

            var cryptoWheelSystem = new CryptoWheelSystem<string>();

            var outerLetterWheel = new CryptoWheel<string> { Name = "Outside Letter Wheel" };
            outerLetterWheel.WheelMarks = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            cryptoWheelSystem.AddWheel(outerLetterWheel);

            var numberWheel1 = new CryptoWheel<string> { Name = "Number Wheel 1" };
            numberWheel1.WheelMarks = new List<string>() { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26" };
            cryptoWheelSystem.AddWheel(numberWheel1);

            var numberWheel2 = new CryptoWheel<string> { Name = "Numbe Wheel 2" };
            cryptoWheelSystem.AddWheel(numberWheel2);

            var numberWheel3 = new CryptoWheel<string> { Name = "Numbe Wheel 3" };
            cryptoWheelSystem.AddWheel(numberWheel3);

            var numberWheel4 = new CryptoWheel<string> { Name = "Numbe Wheel 4" };
            cryptoWheelSystem.AddWheel(numberWheel4);
        }

        [Test]
        public void LoadEnglishLetterDistributionTest()
        {
            Assert.AreEqual(26, letterDistributionEnglish.Count);

            Assert.LessOrEqual((decimal)99.99, letterDistributionEnglish.TotalPercentageSum);
            Assert.GreaterOrEqual((decimal)100.01, letterDistributionEnglish.TotalPercentageSum);

            Assert.IsTrue(letterDistributionEnglish.ContainsOneInstanceOfEachLetter);
        }

        [Test]
        public void CreateThreeWheelTest()
        {
            var testCryptoWheelSystem = new CryptoWheelSystem<string>();

            var wheel1 = new CryptoWheel<string> { Name = "First Wheel" };
            cryptoWheelSystem.AddWheel(wheel1);


            var wheel2 = new CryptoWheel<string> { Name = "Second Wheel" };
            testCryptoWheelSystem.AddWheel(wheel2);


            var wheel3 = new CryptoWheel<string> { Name = "Third Wheel" };
            testCryptoWheelSystem.AddWheel(wheel3);

            Assert.AreEqual(3, testCryptoWheelSystem.Count);

        }

        [TearDown]
        public void TearDown()
        {
            letterDistributionEnglish = null;
        }
    }
}
