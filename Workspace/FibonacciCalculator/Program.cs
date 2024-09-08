namespace FibonacciCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string header = "Assignment 2.3: Switches and Jump Statements\n*********** Fibonacci Sequence ***********\n";
            string promptMsg = "Please enter the number of terms in the sequence you would like to calculate: ";

            Console.WriteLine(header);
            CreateResult(promptMsg);
        }

        /// <summary>
        /// Format output to print for user
        /// </summary>
        /// <param name="promptMsg"></param>
        public static void CreateResult(string promptMsg)
        {
            string numOfTerms = "";

            Console.Write(promptMsg);

            try
            {
                numOfTerms = Console.ReadLine();               

                CalculateFibonnaciSequence(int.Parse(numOfTerms));
                Console.ReadLine();
            }
            catch (Exception e) 
            {
                Console.WriteLine("Please enter a Postive Integer");    
            }
        }

        /// <summary>
        /// Calculates the Fibonacci sequence based on a number of 
        /// terms provided by the user
        /// </summary>
        /// <param name="terms"></param>
        public static void CalculateFibonnaciSequence(int terms)
        {
            long firstTerm = 0;
            long secondTerm = 1;
            long sum = 0;

            //print the first and second term (0 & 1)
            Console.WriteLine($"{firstTerm} (first term)");
            Console.WriteLine($"{secondTerm} (second term)");

            for (int i = 2; i < terms; i++)
            {
                sum = firstTerm + secondTerm;

                if (sum < 0)
                {
                    Console.WriteLine("\nValue Exceeded data range!\n Please try again with a small number!");
                    Console.ReadLine();
                    break;
                }

                Console.WriteLine($"The sum of term {i - 1} and term {i} is {sum}");
                firstTerm = secondTerm;
                secondTerm = sum;
            }            
        }
    }
}
