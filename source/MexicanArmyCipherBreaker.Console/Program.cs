﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MexicanArmyCipherBreaker.Library;

namespace MexicanArmyCipherBreaker.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var letterDistributionEnglish = new LetterDistributionCollection();
            letterDistributionEnglish.Load();

            var codeWheelSystem = LoadMexicanArmyCodeWheel(new CryptoWheelSystem<string>(26));

            codeWheelSystem.SetWheelPositions("c", "03", "33", "67", "84");
            
            FileHelper fh = new FileHelper();
            var cipherTextFromFile = fh.GetCipherTextFromFile(@"c:\home\temp\cipherText.txt");
            var textToDecode = cipherTextFromFile.Split(' ');

            var decodedText = codeWheelSystem.DecodeText(textToDecode);
           // var decodedPlaintextLetter = codeWheelSystem.Decode(codeToLookUp);
            System.Console.WriteLine($"{decodedText}");
            System.Console.ReadKey();
        }

        private static CryptoWheelSystem<string> LoadMexicanArmyCodeWheel(CryptoWheelSystem<string> cryptoWheelSystem)
        {
            var outerLetterWheel = new CryptoWheel<string>(26) { Name = "Outside Letter Wheel"};
            var outerLetterWheelmarkValues = new string[] {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
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

            //var numberWheel4 = new CryptoWheel<string> { Name = "Number Wheel 4" };
            //List<string> numberWheelMarkValues4 = new List<string>  { "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "00", "null1", "null2", "null3", "null4" };
            //var wheelMarks4 = new List<Wheelmark<string>>(26);
            //wheelMarks4.AddRange(numberWheelMarkValues4.Select(wheelMarkvalue => new Wheelmark<string>() { null, wheelMarkvalue }));
            //numberWheel4.WheelMarks = wheelMarks4;
            //cryptoWheelSystem.AddWheel(numberWheel4);

            return cryptoWheelSystem;
        }
    }
}
