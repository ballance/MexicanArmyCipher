using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MexicanArmyCipherBreaker.Library
{
    public static class StringExtensionsEnglish
    {
        private static List<string> _frequentEnglshWords = new List<string>() { "key", "success", "the", "and", "that", "have", "for", "with", "you", "this", "from", "widge", "poppet", "xmas", "christmas", "present", "love" };

        public static bool HasFrequentEnglishWord(this string str)
        {
            return true;
            return _frequentEnglshWords.Any(str.Contains);
        }
    }
}
