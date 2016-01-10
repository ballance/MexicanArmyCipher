using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace MexicanArmyCipherBreaker.Library
{
    public class Solver
    {
        private bool _writeInteractive = false;

        /// <summary>
        /// Solve by brute force based on output containing common plaintext English words 
        /// TODO: Add letter distribution score in ranking of candidate cipher wheel configurations
        /// TODO: This is currently off by one for the inner wheel (#4)
        /// </summary>
        /// <param name="initialCodeWheelSystem"></param>
        /// <param name="textToDecode"></param>
        /// <param name="fileHelper"></param>
        public void BruteForce(CryptoWheelSystem<string> initialCodeWheelSystem, string[] textToDecode, FileHelper fileHelper)
        {
            if (_writeInteractive) { Console.Write("Setting up the wheels.");}

            var swSetup = new Stopwatch();
            swSetup.Start();

            var codeWheelSystemConfigurations = new List<CryptoWheelSystem<string>>();

            for (var wheel1Index = 0; wheel1Index < 26 /* Move to single setter area*/; wheel1Index++)
            {
                for (var wheel2Index = 0; wheel2Index < 26; wheel2Index++)
                {
                    for (var wheel3Index = 0; wheel3Index < 26; wheel3Index++)
                    {
                        for (var wheel4Index = 0; wheel4Index < 26; wheel4Index++)
                        {
                            var currentCodeWheelSystem = new CryptoWheelSystem<string>(26);
                            currentCodeWheelSystem.Clone(initialCodeWheelSystem);

                            codeWheelSystemConfigurations.Add(currentCodeWheelSystem);
                            initialCodeWheelSystem.ShiftWheelTopPositionRight(4);
                            if(_writeInteractive) { Console.Write(".");}
                        }
                        initialCodeWheelSystem.ShiftWheelTopPositionRight(3);
                        if (_writeInteractive) { Console.Write("#");}
                    }
                    initialCodeWheelSystem.ShiftWheelTopPositionRight(2);
                    if (_writeInteractive) { Console.Write("//");}
                }
                initialCodeWheelSystem.ShiftWheelTopPositionRight(1);
                if (_writeInteractive) { Console.Write("&&&");}
            }

            swSetup.Stop();
            Console.WriteLine($"SETUP Completed in {swSetup.Elapsed.TotalSeconds} seconds.");

            var swSolve = new Stopwatch();
            swSolve.Start();


            Parallel.ForEach(codeWheelSystemConfigurations, new ParallelOptions { MaxDegreeOfParallelism = 1}, (wheelConfig) =>
            {
                var decodedText = wheelConfig.EncodeText(textToDecode);
                if (decodedText.HasFrequentEnglishWord())
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(
                        "******************************************************************************");
                    Console.WriteLine(
                        $"* BOOM!  Decyphered a candidate at {wheelConfig.WriteConfigToString()}");
                    Console.WriteLine(
                        "******************************************************************************");
                    Console.WriteLine();
                    Console.ResetColor();
                    var candidateSolution = new CandidateSolution
                    {
                        DecodedText = decodedText,
                        WheelConfiguration = wheelConfig.WriteConfigToString()
                    };
                    fileHelper.WritePlainTextToFile(candidateSolution.DecodedText, candidateSolution.WheelConfiguration);
                }
                wheelConfig.ClearCache();
            });

            swSolve.Stop();
            Console.WriteLine($"SOLVE completed in {swSolve.Elapsed.TotalSeconds} seconds.");

        }

        /// <summary>
        /// Solves when the configuration is known in advance
        /// </summary>
        /// <param name="codeWheelSystem"></param>
        /// <param name="textToDecode"></param>
        public void SolveKnownConfiguration(CryptoWheelSystem<string> codeWheelSystem, string[] textToDecode)
        {
            codeWheelSystem.SetWheelPositions("a", "12", "45", "58", "85");
            var decodedText = codeWheelSystem.EncodeText(textToDecode);
            Console.WriteLine(decodedText);
        }
    }
}