using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace AnagramaGen
{
    class Program
    {
        private static String startWord;
        private static WordLib mainLib;

        // Not a complex interface was developed here, it's just functional.
        // Rodrigo Wantuk, 2019-11-21.
        static void Main(string[] args)
        {
            int wordsFound = 0;

            // Beginning below with some validations. Testing the input word and the words dictionary.
            try
            {
                Console.WriteLine();
                Console.Write(" # Validating input word... ");

                if (args.Length != 1) // Only one parameter, with the word, can be specified.
                {
                    Console.WriteLine("Fail.");
                    Console.Error.WriteLine("Fail: You must specify only one parameter, a simple word.");
                    return;
                }

                startWord = args[0].Trim().ToUpper();

                if (startWord.Length < 1 || startWord.Length > 16) // Invalid parameter size.
                {
                    Console.WriteLine("Fail.");
                    Console.Error.WriteLine("Fail: The word must be valid, between 1 and 16 characters.");
                    return;
                }

                if (!Regex.IsMatch(startWord, "[A-Z]+")) // Using regex to match valid characted (A-Z letters only). Regex: [A-Z]+
                {
                    Console.WriteLine("Fail.");
                    Console.Error.WriteLine("Fail: Invalid character found.");
                    return;
                }

                Console.WriteLine("OK [" + startWord + "]!");

                Console.WriteLine();
                Console.Write(" # Validating words library... ");

                if (!File.Exists(".\\palavras.txt"))
                {
                    Console.WriteLine("Fail.");
                    Console.Error.WriteLine("Fail: Words library ['palavras.txt'] not found.");
                    return;
                }

                Console.WriteLine("OK!");

                Console.WriteLine();
                Console.Write(" # Filling dictionary... ");

                mainLib = new WordLib(".\\palavras.txt", startWord.Length);

                Console.WriteLine("OK [" + mainLib.TotalWords + " words loaded]!");

                Console.WriteLine();
                Console.WriteLine(" # Locating words... ");
                wordsFound = 0;

                foreach(AnagramableString dicWord in mainLib.DicLib[startWord.Length][StringUtils.CountVowels(startWord)])
                {
                    if(dicWord.IsAnagram(startWord))
                    {
                        wordsFound++;
                        Console.WriteLine("    - " + dicWord);
                    }
                }

                Console.WriteLine();
                Console.WriteLine(" # " + wordsFound.ToString() + " words found.");

            }
            catch (Exception e)
            {
                Console.WriteLine("Internal Fail.");
                Console.Error.WriteLine("Internal Fail: " + e.Message);
                Console.Error.WriteLine(e.StackTrace);
            }

            Console.WriteLine();
            Console.WriteLine("developed by http://www.rwantuk.com.br/ - Version " + System.Reflection.Assembly.GetCallingAssembly().GetName().Version);

        }
    }
}
