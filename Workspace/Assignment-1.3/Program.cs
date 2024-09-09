using System.Linq.Expressions;

namespace Assignment_1._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = 0;
            int secondNumber = 0;            
            int result = 0;
                        
            string operationSymbol;  
            
            bool quit = false;

            Console.WriteLine("Arithmetic Operations");
            Console.WriteLine("Please provide 2 numbers");
            Console.WriteLine();

            do
            {
                firstNumber = ValidateNumber("First Number: ");
                secondNumber = ValidateNumber("Second Number: ");


                Console.Write("Enter symbol (+, -, /, *): ");
                operationSymbol = Console.ReadLine().Trim();

                string input = "";

                switch (operationSymbol)
                {

                    case "+":
                        result = firstNumber + secondNumber;

                        Console.WriteLine($"Addition: {firstNumber} + {secondNumber} = {result}\n");
                        Console.Write("Do you want to continue (y/n)? ");

                        input = Console.ReadLine().Trim().ToLower();

                        if (input == "y")
                        {
                            continue;
                        }
                        else
                        {
                            quit = true;
                        }
                        return;

                    case "-":
                        result = firstNumber - secondNumber;

                        Console.WriteLine($"Subtraction: {firstNumber} - {secondNumber} = {result}\n");
                        Console.Write("Do you want to continue (y/n)? ");

                        input = Console.ReadLine().Trim().ToLower();

                        if (input == "y")
                        {
                            continue;
                        }
                        else
                        {
                            quit = true;
                        }

                        return;

                    case "*":
                        result = firstNumber * secondNumber;

                        Console.WriteLine($"Multiplication: {firstNumber} * {secondNumber} = {result}\n");
                        Console.Write("Do you want to continue (y/n)? ");

                        input = Console.ReadLine().Trim().ToLower();

                        if (input == "y")
                        {
                            continue;
                        }
                        else
                        {
                            quit = true;
                        }

                        return;

                    case "/":
                        result = firstNumber / secondNumber;

                        Console.WriteLine($"Division: {firstNumber} / {secondNumber} = {result} \n");
                        Console.Write("Do you want to continue (y/n)? ");

                        input = Console.ReadLine().Trim().ToLower();

                        if (input == "y")
                        {
                            continue;
                        }
                        else
                        {
                            quit = true;
                        }
                        return;

                    default:
                        Console.WriteLine("Invalid symbol, try again");
                        continue;
                }                
            }
            while (!quit);
        }

        private static int ValidateNumber(string propmtMsg)
        {
            int number = 0;
            bool isValidInput = false;

            while(!isValidInput)
            {
                Console.Write(propmtMsg);

                if (int.TryParse(Console.ReadLine(), out number))
                {
                    if (number > 0)
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
    }
}
