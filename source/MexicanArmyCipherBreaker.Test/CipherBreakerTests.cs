using System;
using System.Collections.Generic;
using MexicanArmyCipherBreaker.Library;
using NUnit.Framework;

namespace MexicanArmyCipherBreaker.Test
{
    [TestFixture]
    public class CipherBreakerTests
    {
        LetterDistributionCollection _letterDistributionEnglish = new LetterDistributionCollection();
        readonly CryptoWheelSystem<string> _cryptoWheelSystem = new CryptoWheelSystem<string>(26);

        [SetUp]
        public void TestSetup()
        {
            _letterDistributionEnglish.Load();

            var cryptoWheelSystem = new CryptoWheelSystem<string>(26);
            var outerLetterWheel = new CryptoWheel<string>(26) { Name = "Outside Letter Wheel" };
            var outerLetterWheelmarkValues = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            int j = 0;
            foreach (var mark in outerLetterWheelmarkValues)
            {
                outerLetterWheel.AddWheelMark(j++, mark);
            }
            cryptoWheelSystem.AddWheel(outerLetterWheel);

            var numberWheel1 = new CryptoWheel<string>(26) { Name = "Number Wheel 1" };
            var numberWheelmarkValues1 = new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26" };
            int k = 0;
            foreach (var mark in numberWheelmarkValues1)
            {
                numberWheel1.AddWheelMark(k++, mark);
            }
            cryptoWheelSystem.AddWheel(numberWheel1);


            var numberWheel2 = new CryptoWheel<string>(26) { Name = "Number Wheel 2" };
            var numberWheelmarkValues2 = new string[] { "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52" };

            int l = 0;
            foreach (var mark in numberWheelmarkValues2)
            {
                numberWheel2.AddWheelMark(l++, mark);
            }
            cryptoWheelSystem.AddWheel(numberWheel2);


            var numberWheel3 = new CryptoWheel<string>(26) { Name = "Number Wheel 3" };
            var numberWheelmarkValues3 = new string[] { "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78" };

            int m = 0;
            foreach (var mark in numberWheelmarkValues3)
            {
                numberWheel3.AddWheelMark(m++, mark);
            }
            cryptoWheelSystem.AddWheel(numberWheel3);


            var numberWheel4 = new CryptoWheel<string>(26) { Name = "Number Wheel 4" };
            var numberWheelmarkValues4 = new string[] { "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "00", "null1", "null2", "null3", "null4" };

            int n = 0;
            foreach (var mark in numberWheelmarkValues4)
            {
                numberWheel4.AddWheelMark(n++, mark);
            }
            cryptoWheelSystem.AddWheel(numberWheel4);

        }

        [Test]
        public void LoadEnglishLetterDistributionTest()
        {
            Assert.AreEqual(26, _letterDistributionEnglish.Count);

            Assert.LessOrEqual((decimal)99.99, _letterDistributionEnglish.TotalPercentageSum);
            Assert.GreaterOrEqual((decimal)100.01, _letterDistributionEnglish.TotalPercentageSum);

            Assert.IsTrue(_letterDistributionEnglish.ContainsOneInstanceOfEachLetter);
        }

        [Test]
        public void CreateThreeWheelTest()
        {
            var testCryptoWheelSystem = new CryptoWheelSystem<string>(26);

            var wheel1 = new CryptoWheel<string>(26) { Name = "First Wheel" };
            _cryptoWheelSystem.AddWheel(wheel1);
            
            var wheel2 = new CryptoWheel<string>(26) { Name = "Second Wheel" };
            testCryptoWheelSystem.AddWheel(wheel2);
            
            var wheel3 = new CryptoWheel<string>(26) { Name = "Third Wheel" };
            testCryptoWheelSystem.AddWheel(wheel3);

            var wheel4 = new CryptoWheel<string>(26) { Name = "Fourth Wheel" };
            testCryptoWheelSystem.AddWheel(wheel4);

            Assert.AreEqual(4, testCryptoWheelSystem.Count);

        }

        [TearDown]
        public void TearDown()
        {
            _letterDistributionEnglish = null;
        }
    }
}
