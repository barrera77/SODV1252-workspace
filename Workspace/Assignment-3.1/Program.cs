using System.Text.RegularExpressions;

namespace Assignment_3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string promptMsg = "Please provide a paragraph of text: \n";

            CreateResult(promptMsg);
        }

        public static void CreateResult(string promptMsg)
        {
            string input = "";
            bool isValidInput = false;          

            while (!isValidInput)
            {
                Console.WriteLine(promptMsg);
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Invalid entry, provide a valid text");
                }
                else
                {
                    WordCount(input);
                    VowelCount(input);

                    Console.WriteLine("Word Frequency Count\n");
                    Console.WriteLine("{0, 17} {1,5}\n", "Word  ", "  Frequency");
                    WordFrequencyCount(input);

                    isValidInput = true;
                }

            }
        }

        /// <summary>
        /// Coun the number of words in a given string
        /// </summary>
        /// <param name="input"></param>
        public static void WordCount(string input)
        {
            int words = 1;

            for (int i = 0; i <= input.Length - 1; i++)
            {
                if (input[i] == ' ' || input[i] == '\n' || input[i] == '\t')
                {
                    words++;
                }
            }
            Console.WriteLine($"Word Count: {words}");
        }

        /// <summary>
        /// Count the number of vowels in a given string
        /// </summary>
        /// <param name="input"></param>
        public static void VowelCount(string input)
        {
            int numOfVowels = 0;

            //Create a list of vowels
            List<char> vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u'};   

            foreach(var ch in input.ToLower())
            {
                if( vowels.Contains(ch) )
                {
                    numOfVowels++;
                }
            }
            Console.WriteLine($"Vowel Count: {numOfVowels}");
        }
                
        /// <summary>
        /// Count the frequency of words in a given string
        /// </summary>
        /// <param name="input"></param>
        public static void WordFrequencyCount(string input)
        { 
            //Array to store the words and its occurrences
            Dictionary<string, int> wordsList = new Dictionary<string, int>();

            //Ignore uppercase
            input = input.ToLower();

            //Split the words in the text
            char[] chars = { ' ', '.', ',', ';', ':', '?', '\n', '\r' };
            string[] words = input.Split(chars, StringSplitOptions.RemoveEmptyEntries);           

            foreach(var word in words)
            {
                if(wordsList.ContainsKey(word))
                {
                    wordsList[word]++;
                }
                else
                {
                    wordsList[word] = 1;
                }
            }

            foreach (var w in wordsList)
            {
                Console.WriteLine("{0, 15} {1, 5}", w.Key, w.Value);
            }
        }
    }
}
