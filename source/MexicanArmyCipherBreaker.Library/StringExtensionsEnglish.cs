using System.Collections.Generic;
using System.Linq;

namespace MexicanArmyCipherBreaker.Library
{
    public static class StringExtensionsEnglish
    {
        // List of common English words taken from http://www.wordfrequency.info/free.asp?s=y (update to this list)
        private static readonly List<string> FrequentEnglshWords = new List<string>() {"success","the", "that", "have", "with", "this", "from", "love"};
      
        // Specification to check if a string contains a common English word
        public static bool HasFrequentEnglishWord(this string str)
        {
            return FrequentEnglshWords.Any(str.Contains);
        }
    }
}
