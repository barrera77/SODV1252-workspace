namespace Assignment_4._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HandleMainMenu();
        }        

        /// <summary>
        /// Prints the main menu
        /// </summary>
        static void DisplayMainMenu()
        {
            string mainMenu = "Statistics Calculator:\n" +
            "\n1. Calculate mean of two integers\n" +
            "2. Calculate mean of two double\n" +
            "3. Calculate mean of an array of integers\n" +
            "4. Calculate mean of an array of doubles\n" +
            "5. Exit";

            Console.Clear();
            Console.WriteLine(mainMenu);
        }

        /// <summary>
        /// Handles the menu option selected by the user
        /// and redirects to the appropiate action
        /// </summary>
        static void HandleMainMenu()
        {
            string mainMenuOption;
            double mean;
            int numOfElements;

            do
            {
                DisplayMainMenu();

                Console.Write("\nPlease choose an option: ");
                mainMenuOption = Console.ReadLine();

                switch (mainMenuOption)
                {
                    case "1":
                        //Calculate Mean of two integers
                        int intOne = ValidateIntInput("Enter the first integer: ", -10000, 10000);
                        int intTwo = ValidateIntInput("Enter the Second integer: ", -10000, 10000);
                        mean = CalculateMean(intOne, intTwo);

                        Console.WriteLine($"Mean of two integers: {mean}");
                        Console.Write("\nPlease press Enter to continue. . .");
                        Console.ReadLine();
                        break;

                    case "2":
                        //Calculate Mean of two doubles
                        double doubleOne= (double)ValidateDoubleInput("Enter first double: ", -10000, 10000);
                        double doubleTwo = (double)ValidateDoubleInput("Enter second double: ", -10000, 10000);
                        mean = CalculateMean(doubleOne, doubleTwo);

                        Console.WriteLine($"Mean of two doubles: {mean}");
                        Console.Write("\nPlease press Enter to continue. . .");
                        Console.ReadLine();
                        break;

                    case "3":
                        //Calculate Mean of an array of integers
                        numOfElements = ValidateIntInput("Enter the number of elements in the array: ", 1, 30);

                        List<int> intsList = new List<int>();

                        for(int i = 0; i < numOfElements; i++)
                        {
                            intsList.Add(ValidateIntInput($"Enter element {i + 1}: ", -10000, 10000));
                        }

                        mean = CalculateMean(intsList);

                        Console.WriteLine($"Mean of the array: {mean}");
                        Console.Write("\nPlease press Enter to continue. . .");
                        Console.ReadLine();
                        break;

                    case "4":
                        //Calculate Mean of an array of doubles
                        numOfElements = ValidateIntInput("Enter the number of elements in the array: ", 1, 30);

                        List<double> doublesList = new List<double>();

                        for (int i = 0; i < numOfElements; i++)
                        {
                            doublesList.Add(ValidateDoubleInput($"Enter element {i + 1}: ", -10000, 10000));
                        }

                        mean = CalculateMean(doublesList);

                        Console.WriteLine($"Mean of the array: {mean}");
                        Console.Write("\nPlease press Enter to continue. . .");
                        Console.ReadLine();
                        break;

                    case "5":
                        Console.WriteLine("Exiting the system. Have a great day!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");                        
                        break;
                }

            }
            while (mainMenuOption != "5");
        }

        //Calculate Mean of two integers
        static double CalculateMean(int numOne, int numTwo)
        {
            return (numOne + numTwo) / 2.0;
            
        }

        //Calculate Mean of two doubles
        static double CalculateMean(double numOne, double numTwo)
        {
            return (numOne + numTwo) / 2.0;            
        }

        //Calculate Mean of an array of integers
        static double CalculateMean(List<int> elementsList)
        {
            double mean;

            int[] ints = elementsList.ToArray();

            return mean = (double)ints.Average();
        }

        //Calculate Mean of an array of doubles
        static double CalculateMean(List<double> elementsList)
        {
            double mean = 0;

            double[] doubles = elementsList.ToArray();

            return mean = doubles.Average();
        }

        #region Helper Methods

        /// <summary>
        /// Checks if input is a valid integer
        /// </summary>
        /// <param name="input"></param>
        /// <param name="validInt"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns>false/true and validated int</returns>
        static bool IsValidInt(string input, out int validInt, int minValue, int maxValue)
        {
            if (int.TryParse(input, out validInt))
            {
                if(validInt >= minValue && validInt <= maxValue)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Invalid input: the number must be between {minValue} and {maxValue}");
                    return false;
                }                
            }            
            else
            {
                Console.Write("Invalid input. Please enter a valid number: ");
                return false;
            }
        }

        /// <summary>
        /// Checks if input is a valid double
        /// </summary>
        /// <param name="input"></param>
        /// <param name="validDouble"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns>false/true and validated double</returns>
        static bool IsValidDouble(string input, out double validDouble, int minValue, int maxValue)
        {
            if (double.TryParse(input, out validDouble))
            {
                if (validDouble >= minValue && validDouble <= maxValue)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Invalid input: the number must be between {minValue} and {maxValue}");
                    return false;
                }
            }
            else
            {
                Console.Write("Invalid input. Please enter a valid number: ");
                return false;
            }
        }

        /// <summary>
        /// Validates and verifies that the input is valid int
        /// </summary>
        /// <param name="promptMsg"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns>validated int input</returns>
        static int ValidateIntInput(string promptMsg, int minValue, int maxValue)
        {
            int validatedInput;
            bool isValidInput;

            string input;

            do
            {
                Console.Write(promptMsg);
                input = Console.ReadLine();
                isValidInput = IsValidInt(input, out validatedInput, minValue, maxValue);
            }
            while (!isValidInput);

            return validatedInput;
        }

        /// <summary>
        /// Validates and verifies that the input is valid double
        /// </summary>
        /// <param name="promptMsg"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns>validated double input</returns>
        static double ValidateDoubleInput(string promptMsg, int minValue, int maxValue)
        {
            double validatedInput;
            bool isValidInput;

            string input;

            do
            {
                Console.Write(promptMsg);
                input = Console.ReadLine();
                isValidInput = IsValidDouble(input, out validatedInput, minValue, maxValue);
            }
            while (!isValidInput);

            return validatedInput;
        }
        #endregion
    }
}
