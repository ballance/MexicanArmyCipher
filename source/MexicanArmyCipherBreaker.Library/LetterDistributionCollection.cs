using System.Collections.Generic;
using System.Linq;

namespace MexicanArmyCipherBreaker.Library
{
    public class LetterDistributionCollection
    {
        public LetterDistributionCollection()
        {
            _letterDistribution = new List<LetterDistributionItem>();
        }
        private List<LetterDistributionItem> _letterDistribution { get; set; }

        public decimal TotalPercentageSum
        {
            get { return _letterDistribution.Sum(x => x.Frequency); }
        }

        public bool ContainsOneInstanceOfEachLetter
        {
            get
            {
                return _letterDistribution.Select(x => x.Letter).ToList().All(letter => _letterDistribution.Count(x => x.Letter.Equals(letter)) == 1);
            }
        }

        public int Count => _letterDistribution.Count;

        public void Add(char letter, decimal frequency)
        {
            _letterDistribution.Add(new LetterDistributionItem(letter, frequency));
        }

        public void Load()
        {
            // English Letter Frequency - based on 40,000 word sample - table taken from http://www.math.cornell.edu/~mec/2003-2004/cryptography/subs/frequencies.html
            Add('e', (decimal)12.02);
            Add('t', (decimal)9.10);
            Add('a', (decimal)8.12);
            Add('o', (decimal)7.68);
            Add('i', (decimal)7.31);
            Add('n', (decimal)6.95);
            Add('s', (decimal)6.28);
            Add('r', (decimal)6.02);
            Add('h', (decimal)5.92);
            Add('d', (decimal)4.32);
            Add('l', (decimal)3.98);
            Add('u', (decimal)2.88);
            Add('c', (decimal)2.71);
            Add('m', (decimal)2.61);
            Add('f', (decimal)2.30);
            Add('y', (decimal)2.11);
            Add('w', (decimal)2.09);
            Add('g', (decimal)2.03);
            Add('p', (decimal)1.82);
            Add('b', (decimal)1.49);
            Add('v', (decimal)1.11);
            Add('k', (decimal)0.69);
            Add('x', (decimal)0.17);
            Add('q', (decimal)0.11);
            Add('j', (decimal)0.10);
            Add('z', (decimal)0.07);
        }
    }
}