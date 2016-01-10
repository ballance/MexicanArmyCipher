using System.Diagnostics;
using MexicanArmyCipherBreaker.Library;

namespace MexicanArmyCipherBreaker.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            RunSolve();
        }

        private static void RunSolve()
        {
            var sw = new Stopwatch();
            sw.Start();
            var letterDistributionEnglish = new LetterDistributionCollection();
            letterDistributionEnglish.Load();

            var fileHelper = new FileHelper();
            var cipherTextFromFile = fileHelper.GetCipherTextFromFile(@"c:\home\temp\cipherText.txt");
            var textToDecode = cipherTextFromFile.Split(' ');

            var initialWheelSystem = LoadInitialMexicanArmyCodeWheel(new CryptoWheelSystem<string>(26));

            System.Console.Write("Setting up the wheels.");

            //SolveKnownConfiguration(codeWheelSystem, textToDecode);

            var solver = new Solver();
            //var solutions = 
                solver.BruteForce(initialWheelSystem, textToDecode, fileHelper);
            //foreach (var solution in solutions)
            //{
            //    fileHelper.WritePlainTextToFile(solution.DecodedText, solution.WheelConfiguration);
            //}

            sw.Stop();
            System.Console.WriteLine($"Completed in {sw.Elapsed.TotalSeconds} seconds.");
            System.Console.ReadKey();
        }
        
        private static CryptoWheelSystem<string> LoadInitialMexicanArmyCodeWheel(CryptoWheelSystem<string> cryptoWheelSystem)
        {
            // Set up outside letter wheel.  Wheels are added from outer to inner
            var outerLetterWheel = new CryptoWheel<string>(26) { Name = "Outside Letter Wheel" };
            var outerLetterWheelmarkValues = new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            var outerLetterWheelIterator = 0;
            foreach (var mark in outerLetterWheelmarkValues)
            {
                outerLetterWheel.AddWheelMark(outerLetterWheelIterator++, mark);
            }
            cryptoWheelSystem.AddWheel(outerLetterWheel);
            
            // Set up number wheel #1
            var numberWheel1 = new CryptoWheel<string>(26) { Name = "Number Wheel 1" };
            var numberWheelmarkValues1 = new[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26" };
            var numberWheel1Iterator = 0;
            foreach (var mark in numberWheelmarkValues1)
            {
                numberWheel1.AddWheelMark(numberWheel1Iterator++, mark);
            }
            cryptoWheelSystem.AddWheel(numberWheel1);

            // Set up number wheel #2
            var numberWheel2 = new CryptoWheel<string>(26) { Name = "Number Wheel 2" };
            var numberWheelmarkValues2 = new[] { "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52" };

            var numberWheel2Iterator = 0;
            foreach (var mark in numberWheelmarkValues2)
            {
                numberWheel2.AddWheelMark(numberWheel2Iterator++, mark);
            }
            cryptoWheelSystem.AddWheel(numberWheel2);

            // Set up number wheel #3
            var numberWheel3 = new CryptoWheel<string>(26) { Name = "Number Wheel 3" };
            var numberWheelmarkValues3 = new string[] { "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78" };

            var numberWheel3Iterator = 0;
            foreach (var mark in numberWheelmarkValues3)
            {
                numberWheel3.AddWheelMark(numberWheel3Iterator++, mark);
            }
            cryptoWheelSystem.AddWheel(numberWheel3);

            // Set up number wheel #4
            var numberWheel4 = new CryptoWheel<string>(26) { Name = "Number Wheel 4" };
            var numberWheelmarkValues4 = new string[] { "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "00", "null1", "null2", "null3", "null4" };

            int numberWheel4Iterator = 0;
            foreach (var mark in numberWheelmarkValues4)
            {
                numberWheel4.AddWheelMark(numberWheel4Iterator++, mark);
            }
            cryptoWheelSystem.AddWheel(numberWheel4);
            return cryptoWheelSystem;
        }
    }
}