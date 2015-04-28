using System;
using System.IO;
using System.Collections.Generic;

namespace BeautifulStrings
{
    class Program
    {
        static int Main(string[] args)
        {
            // Check the argument and file exists
            if (args.Length == 0 || !File.Exists(args[0]))
            {
                Console.Write("You failed to specify the file to read, or entered a non existant file path.\nPlease try again with the file name as the first argument.");
                return 0;
            }

            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (null == line) continue;

                    if ("" == line) continue;

                    PrintBeautifulStringsValues(line);
                }
            }

            return 0;
        }

        /// <summary>
        /// Given a string s, little Johnny defined the beauty of the string as the sum of the beauty of the letters in it. 
        /// The beauty of each letter is an integer between 1 and 26, inclusive, and no two letters have the same beauty. 
        /// Johnny doesn't care about whether letters are uppercase or lowercase, so that doesn't affect the beauty of a letter. 
        /// (Uppercase 'F' is exactly as beautiful as lowercase 'f', for example.) 
        /// </summary>
        /// <param name="sumOfParts"></param>
        static void PrintBeautifulStringsValues(string splitNum)
        {
            Dictionary<char, int> countOfNumbers = new Dictionary<char, int>();

            splitNum = splitNum.ToLower();

            foreach (char character in splitNum)
            {
                if (Char.IsLetter(character))
                {
                    if (countOfNumbers.ContainsKey(character))
                    {
                        ++countOfNumbers[character];
                    }
                    else
                    {
                        countOfNumbers.Add(character, 1);
                    }
                }
            }

            int valueOfString = 0;
            int valueOfCurrentChar = 26;
            char mostCommonChar = ' ';

            while (0 < countOfNumbers.Count)
            {
                foreach (KeyValuePair<char, int> kvp in countOfNumbers)
                {
                    if (mostCommonChar == ' ')
                    {
                        mostCommonChar = kvp.Key;
                    }
                    else if(countOfNumbers[mostCommonChar] < countOfNumbers[kvp.Key])
                    {
                        mostCommonChar = kvp.Key;
                    }
                }

                valueOfString += valueOfCurrentChar * countOfNumbers[mostCommonChar];
                countOfNumbers.Remove(mostCommonChar);

                mostCommonChar = ' ';
                --valueOfCurrentChar;
            }

            Console.WriteLine(valueOfString);
        }
    }
}
