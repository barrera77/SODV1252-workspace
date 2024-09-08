using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment_2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input;
            int sum = 0;

            string word = "";
            string reversedWord = "";
            string promptMesg = "Please write a number between 1 and 10: ";
            string header = "Assignment 2.2:  Control Flow and Looping Fundamentals\n";

            Console.WriteLine(header);
            input = ValidateInput(promptMesg);

            CreateResult(input);
        }

        /// <summary>
        /// Validates that the user input is numeric
        /// </summary>
        /// <param name="propmtMsg"></param>
        /// <returns>The validated number </returns>
        private static int ValidateInput(string propmtMsg)
        {
            int number = 0;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.Write(propmtMsg);

                if (int.TryParse(Console.ReadLine(), out number))
                {
                    if (number > 0 )
                    {
                        isValidInput = true;
                    }                 
                    else
                    {
                        Console.WriteLine("Number cannot be negative or zero");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    
                }
            }
            return number;
        }

        private static void CreateResult(int number)
        {
            int sum = 0;
            string promptMsg = "Enter a string: ";
            string reversedString = "";

            if (number > 10)
            {
                Console.WriteLine("Invalid Input");
                sum = SumNumbers(number);
                Console.WriteLine($"The sum from 1 to {number} is: {sum}");

                reversedString = ReverseString(promptMsg);
                Console.WriteLine($"Reversed String: {reversedString}");
                Console.ReadLine();


            }

            switch (number)
            {
                case 1:

                    Console.WriteLine($"The word representation of {number} is: One");

                    sum = SumNumbers(number);
                    Console.WriteLine($"The sum from 1 to {number} is: {sum}");

                    reversedString = ReverseString(promptMsg);
                    Console.WriteLine($"Reversed String: {reversedString}");
                    Console.ReadLine();
                    return;

                case 2:

                    Console.WriteLine($"The word representation of {number} is: Two");

                    sum = SumNumbers(number);
                    Console.WriteLine($"The sum from 1 to {number} is: {sum}");

                    reversedString = ReverseString(promptMsg);
                    Console.WriteLine($"Reversed String: {reversedString}");
                    Console.ReadLine();
                    return;

                case 3:

                    Console.WriteLine($"The word representation of {number} is: Three");

                    sum = SumNumbers(number);
                    Console.WriteLine($"The sum from 1 to {number} is: {sum}");

                    reversedString = ReverseString(promptMsg);
                    Console.WriteLine($"Reversed String: {reversedString}");
                    Console.ReadLine();
                    return;

                case 4:

                    Console.WriteLine($"The word representation of {number} is: Four");

                    sum = SumNumbers(number);
                    Console.WriteLine($"The sum from 1 to {number} is: {sum}");

                    reversedString = ReverseString(promptMsg);
                    Console.WriteLine($"Reversed String: {reversedString}");
                    Console.ReadLine();
                    return;

                case 5:

                    Console.WriteLine($"The word representation of {number} is: Five");

                    sum = SumNumbers(number);
                    Console.WriteLine($"The sum from 1 to {number} is: {sum}");

                    reversedString = ReverseString(promptMsg);
                    Console.WriteLine($"Reversed String: {reversedString}");
                    Console.ReadLine();
                    return;

                case 6:

                    Console.WriteLine($"The word representation of {number} is: Six");

                    sum = SumNumbers(number);
                    Console.WriteLine($"The sum from 1 to {number} is: {sum}");

                    reversedString = ReverseString(promptMsg);
                    Console.WriteLine($"Reversed String: {reversedString}");
                    Console.ReadLine();
                    return;

                case 7:

                    Console.WriteLine($"The word representation of {number} is: Seven");

                    sum = SumNumbers(number);
                    Console.WriteLine($"The sum from 1 to {number} is: {sum}");

                    reversedString = ReverseString(promptMsg);
                    Console.WriteLine($"Reversed String: {reversedString}");
                    Console.ReadLine();
                    return;

                case 8:

                    Console.WriteLine($"The word representation of {number} is: Eight");

                    sum = SumNumbers(number);
                    Console.WriteLine($"The sum from 1 to {number} is: {sum}");

                    reversedString = ReverseString(promptMsg);
                    Console.WriteLine($"Reversed String: {reversedString}");
                    Console.ReadLine();
                    return;

                case 9:

                    Console.WriteLine($"The word representation of {number} is: Nine");

                    sum = SumNumbers(number);
                    Console.WriteLine($"The sum from 1 to {number} is: {sum}");

                    reversedString = ReverseString(promptMsg);
                    Console.WriteLine($"Reversed String: {reversedString}");
                    Console.ReadLine();
                    return;

                case 10:

                    Console.WriteLine($"The word representation of {number} is: Ten");

                    sum = SumNumbers(number);
                    Console.WriteLine($"The sum from 1 to {number} is: {sum}");

                    reversedString = ReverseString(promptMsg);
                    Console.WriteLine($"Reversed String: {reversedString}");
                    Console.ReadLine();
                    return;

               
            }
        }

        /// <summary>
        /// Sum the numbers from 1 to a given x-number from user input
        /// </summary>
        /// <param name="number"></param>
        /// <returns>The sum of the number from 1 to x</returns>
        private static int SumNumbers(int number)
        {
            int sum = 0;

            for (int i = 1; i <= number; i++)
            {
                sum = i * (i + 1) / 2;
            }

            return sum;
        }

        /// <summary>
        /// Reverse a string based on user input
        /// </summary>
        /// <param name="propmtMsg"></param>
        /// <returns>Reversed string</returns>
        private static string ReverseString(string propmtMsg)
        {
            string input;
            string reversedInput = "";

            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.Write(propmtMsg);
                input = Console.ReadLine();

                //Regex to disallow special chars
                string pattern = @"^[a-zA-Z0-9 ]+$";
                Regex regex = new Regex(pattern);

                if (string.IsNullOrWhiteSpace(input) || !regex.IsMatch(input))
                {
                    Console.WriteLine("Invalid entry, provide a valid string");
                }
                else
                {
                    char[] charArray = input.Trim().ToCharArray();

                    for (int i = charArray.Length - 1; i > -1; i--)
                    {
                        //append characters to the reversed string array
                        reversedInput += charArray[i];
                    }                   

                    isValidInput = true;
                }
            }

            return reversedInput;
        }


    }
}
