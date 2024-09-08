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

        public static void CreateResult(string prompyMsg)
        {
            string numOfTerms = "";

            Console.Write(prompyMsg);

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
            long a = 0;
            long b = 1;
            long c = 0;

            //print the first and second term (0 & 1)
            Console.WriteLine($"{a} (first term)");
            Console.WriteLine($"{b} (second term)");

            for (int i = 2; i < terms; i++)
            {
                c = a + b;
                Console.WriteLine($"The sum of term {i} and term {c}", c);
                a = b;
                b = c;
            }
        }
    }
}
