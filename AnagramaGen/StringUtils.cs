using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AnagramaGen
{
    public static class StringUtils
    {
        public static string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        public static int CountVowels(String word)
        {
            return Regex.Matches(word, "[aeiouAEIOU]").Count;
        }

        // Identify if one string is an anagram from another.
        // Method wrote by Rodrigo Wantuk on 2019-11-21.
        public static bool IsAnagram(String wordA, String wordB)
        {
            if (wordA.Length != wordB.Length)
                return false;

            wordA = wordA.ToUpper();
            wordB = wordB.ToUpper();

            String subChar = "";
            while(wordA.Length > 0)
            {
                subChar = wordA.Substring(0, 1);
                wordA = wordA.Substring(1);
                if (!wordB.Contains(subChar))
                    return false;

                wordB = StringUtils.ReplaceFirst(wordB, subChar, "");
            }

            if (wordB.Length > 0)
                return false;

            return true;
        }

    }
}
