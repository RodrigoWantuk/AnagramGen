using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AnagramaGen
{
    public class WordLib
    {
        private String wordFile;

        // The dictionary is indexed first by the total count of the letters, and then by the count of vowels.
        // It's intended to improve performance of finding the anagrams.
        private Dictionary<int, Dictionary<int, List<AnagramableString>>> dicLib;
        private int limitSize;
        private int totalWords;

        public int TotalWords { get => totalWords; }
        public Dictionary<int, Dictionary<int, List<AnagramableString>>> DicLib { get => dicLib; }

        public WordLib(String _wordFile) : this(_wordFile, -1) { }

        public WordLib(String _wordFile, int _limitSize)
        {
            this.totalWords = 0;
            this.limitSize = _limitSize;
            this.wordFile = _wordFile;
            this.dicLib = new Dictionary<int, Dictionary<int, List<AnagramableString>>>();

            if (!File.Exists(this.wordFile))
                throw new Exception("File " + this.wordFile + " not found.");

            FillDictionaries();
        }

        private void FillDictionaries()
        {
            int wordCount = 0;
            int vowelCount = 0;
            String normWord = "";
            foreach (String word in File.ReadAllLines(this.wordFile))
            {
                normWord = word.ToUpper().Trim();
                wordCount = normWord.Length;
                vowelCount = StringUtils.CountVowels(normWord);
                if (this.limitSize < 0 || this.limitSize == wordCount)
                    AddToDictionary(wordCount, vowelCount, normWord);
            }
        }

        private void AddToDictionary(int _wordIndex, int _vowelIndex, String word)
        {
            if (!this.DicLib.ContainsKey(_wordIndex))
                this.DicLib.Add(_wordIndex, new Dictionary<int, List<AnagramableString>>());

            if (!this.DicLib[_wordIndex].ContainsKey(_vowelIndex))
                this.DicLib[_wordIndex].Add(_vowelIndex, new List<AnagramableString>());

            this.DicLib[_wordIndex][_vowelIndex].Add(new AnagramableString(word));
            this.totalWords++;
        }
    }
}
