﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MexicanArmyCipherBreaker.Library
{
    public class LetterDistributionItem
    {
        public LetterDistributionItem(char letter, decimal frequency)
        {
            Letter = letter;
            Frequency = frequency;
        }
        public char Letter { get; private set; }
        public decimal Frequency { get; private set; }
    }
}
