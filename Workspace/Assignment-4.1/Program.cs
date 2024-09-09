using System.Text.RegularExpressions;

namespace Assignment_4._1
{
    internal class Program
    {
        //Grades List
        private static List<int> gradesList = new List<int>();
        static void Main(string[] args)
        {
            CreateResult();
        }

        /// <summary>
        /// Compile operations and format output to print for the user
        /// </summary>
        /// <param name="promptMsg"></param>
        public static void CreateResult()
        {
            //Display menu to initiate the program sequence
            DisplayMainMenu();
            HandleMainMenu();
        }

        /// <summary>
        /// Add the provided grades to a list
        /// </summary>
        /// <param name="grade"></param>
        public static void AddGrade(int grade)
        {                        
            gradesList.Add(grade);
        }

        /// <summary>
        /// Calculates the average of the provided grades and 
        /// prints the output
        /// </summary>
        public static void CalculateAverageGrade()
        {
            double averageGrade = 0;
            int[] grades = gradesList.ToArray();

            if(gradesList.Count == 0)
            {
                Console.Write("No grades available to calculate the average. ");
                Console.ReadLine();
            }
            else
            {
                averageGrade = (double)grades.Average();
                Console.Write($"Average Grade: {averageGrade.ToString("0.000")}" );
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Finds the highest grade among the provided grades and 
        /// prints the output
        /// </summary>
        public static void FindHighestGrade()
        {
            int[] grades = gradesList.ToArray();
            int count = grades.Length;

            if (count == 0)
            {
                Console.Write("No grades available to find the higest grade. ");
                Console.ReadLine();
            }
            else
            {
                int highestGrade = grades.Take(count).Max();

                Console.Write($"Highest Grade: {highestGrade}");
                Console.ReadLine();
            }            
        }

        /// <summary>
        /// Finds the lowest grade among the provided grades and 
        /// prints the output
        /// </summary>
        public static void FindLowestGrade()
        {
            int[] grades = gradesList.ToArray();
            int count = grades.Length;

            if (count == 0)
            {
                Console.Write("No grades available to find the higest grade. ");
                Console.ReadLine();
            }
            else
            {
                int lowestGrade = grades.Take(count).Min();

                Console.Write($"Lowest Grade: {lowestGrade}");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Prints the main menu
        /// </summary>
        static void DisplayMainMenu()
        {
            string mainMenu = "Student Grading System:\n" +
            "\n1. Add Grade(s)\n" +
            "2. Calculate Average Grade\n" +
            "3. Find Highest Grade\n" +
            "4. Find Lowest Grade\n" +
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

            do
            {
                DisplayMainMenu();

                Console.Write("\nPlease enter your choice: ");
                mainMenuOption = Console.ReadLine();

                switch (mainMenuOption)
                {
                    case "1":
                        string promptMsg = "Enter the grade/grades (separated by space) to add: ";
                        ValidateGrades(promptMsg);
                        Console.WriteLine("Please hit enter to continue. . .");
                        Console.ReadLine();

                        ////Reset the menu
                        //DisplayMainMenu();
                        //Console.Write("\nPlease enter your choice: ");
                        //mainMenuOption = Console.ReadLine();
                        break;

                    case "2":
                        CalculateAverageGrade();
                        break;

                    case "3":
                        FindHighestGrade();
                        break;

                    case "4":
                        FindLowestGrade();
                        break;

                    case "5":
                        Console.WriteLine("Exiting the system. Have a great day!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ReadLine();
                        break;
                }
            }
            while (mainMenuOption != "5");
        }

        /// <summary>
        /// Validates that the provided integer is within requested parameters
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        private static void ValidateGrades(string prompt)
        {
            bool isValidInteger = false;

            string input;
            int numericalGrade;

            Console.Write(prompt);

            while (!isValidInteger)
            {
                input = Console.ReadLine();

                char[] chars = [ ' ' ];
                string[] grades = input.Split(chars, StringSplitOptions.RemoveEmptyEntries);

                foreach(string grade in grades)
                {            
                    if(int.TryParse(grade, out numericalGrade))
                    {                          
                        if (numericalGrade > 0 && numericalGrade <= 100)
                        {
                            AddGrade(numericalGrade);                                                       
                        }
                        else
                        {
                            Console.Write("One or more grades are invalid. Please enter a grade between 0 and 100: ");
                        }
                    }
                    else
                    {
                        Console.Write("Invalid input. Please enter a valid number: ");
                    }
                }

                isValidInteger = true;
            }
            Console.WriteLine("Grade(s) added succesfully.");
        }

    }

}
