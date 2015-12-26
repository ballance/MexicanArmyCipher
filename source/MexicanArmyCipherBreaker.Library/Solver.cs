using System;
using System.Collections.Generic;

namespace MexicanArmyCipherBreaker.Library
{
    public class Solver
    {
        /// <summary>
        /// Solve by brute force based on output containing common plaintext English words 
        /// TODO: Add letter distribution score in ranking of candidate cipher wheel configurations
        /// TODO: This is currently off by one for the inner wheel (#4)
        /// </summary>
        /// <param name="codeWheelSystem"></param>
        /// <param name="textToDecode"></param>
        /// <param name="fileHelper"></param>
        public IEnumerable<CandidateSolution> BruteForce(CryptoWheelSystem<string> codeWheelSystem, string[] textToDecode, FileHelper fileHelper)
        {
            for (var wheel1Index = 0; wheel1Index < 26 /* Move to single setter area*/; wheel1Index++)
            {
                for (var wheel2Index = 0; wheel2Index < 26; wheel2Index++)
                {
                    for (var wheel3Index = 0; wheel3Index < 26; wheel3Index++)
                    {
                        for (var wheel4Index = 0; wheel4Index < 26; wheel4Index++)
                        {
                            var decodedText = codeWheelSystem.EncodeText(textToDecode);
                            if (decodedText.HasFrequentEnglishWord())
                            {
                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(
                                    "******************************************************************************");
                                Console.WriteLine(
                                    $"* BOOM!  Decyphered a candidate at {codeWheelSystem.WriteConfigToString()}");
                                Console.WriteLine(
                                    "******************************************************************************");
                                Console.WriteLine();
                                Console.ResetColor();
                                var candidateSolution = new CandidateSolution
                                {
                                    DecodedText = decodedText,
                                    WheelConfiguration = codeWheelSystem.WriteConfigToString()
                                };
                                yield return candidateSolution;
                            }
                            codeWheelSystem.ClearCache();
                            codeWheelSystem.ShiftWheelTopPositionRight(4);
                            Console.Write(".");
                        }
                        codeWheelSystem.ShiftWheelTopPositionRight(3);
                        Console.Write("#");
                    }
                    codeWheelSystem.ShiftWheelTopPositionRight(2);
                    Console.Write("//");
                }
                codeWheelSystem.ShiftWheelTopPositionRight(1);
                Console.Write("&&&");
            }
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