using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MexicanArmyCipherBreaker.Library
{
    public static class StringExtensionsEnglish
    {
        private static List<string> _frequentEnglshWords = new List<string>() {"iloveyou"}; //"success", "that", "have", "with", "this", "from", "widge", "poppet", "xmas", "christmas", "present", "love"};
        private static List<string> _frequentEnglshWords2 = new List<string>() { "dearest" }; //"success", "that", "have", "with", "this", "from", "widge", "poppet", "xmas", "christmas", "present", "love"};
        private static List<string> _frequentEnglshWords3 = new List<string>() { "wonderul" }; //"success", "that", "have", "with", "this", "from", "widge", "poppet", "xmas", "christmas", "present", "love"};
        private static List<string> _frequentEnglshWords4 = new List<string>() { "bunch" }; //"success", "that", "have", "with", "this", "from", "widge", "poppet", "xmas", "christmas", "present", "love"};

        public static bool HasFrequentEnglishWord(this string str)
        {
            return _frequentEnglshWords.Any(str.Contains) &&
                   _frequentEnglshWords2.Any(str.Contains) &&
                   _frequentEnglshWords3.Any(str.Contains) &&
                   _frequentEnglshWords4.Any(str.Contains);
        }
    }
}
