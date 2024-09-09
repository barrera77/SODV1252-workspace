using System.Text.RegularExpressions;

namespace Assignment_4._1
{
    internal class Program
    {
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
            DisplayMainMenu();
            HandleMainMenu();

            //TODO:Revise HandleMainMenu(), the program ends right away 

        }
        public static void AddGrade()
        {
            string input = "";
            string promptMessage = "Enter the grade/grades (separated by a space) to add: ";
            List<int> gradesList = new List<int>();

            gradesList = ValidateGrades(promptMessage);


        }

        public static void CalculateAverageGrade(List<int> gradesList)
        {

        }

        public static void FindHighestGrade(List<int> gradesList)
        {

        }

        public static void FindLowestGrade(List<int> gradesList)
        {

        }

        static void DisplayMainMenu()
        {
            string mainMenu = "--- Student Grading System ---\n" +
            "\n1. Add Grade(s)\n" +
            "2. Calculate Average Grade\n" +
            "3. Find Highest Grade\n" +
            "4. Find Lowest Grade\n" +
            "5. Exit";

            Console.Clear();
            Console.WriteLine(mainMenu);
        }

        static void HandleMainMenu()
        {
            DisplayMainMenu();
            string mainMenuOption = "";
            Console.Write("\nPlease enter your choice: ");

            switch (mainMenuOption)
            {
                case "1":
                    AddGrade();
                    break;
                
                default:
                   
                    break;
            }
        }


        /// <summary>
        /// Validates that the provided integer is within requested parameters
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        private static List<int> ValidateGrades(string prompt)
        {
            bool isValidInteger = false;

            string input = "";
            int numericalGrade = 0;

            List<int> gradesList = new List<int>(); 

            Console.Write(prompt);

            while (!isValidInteger)
            {
                input = Console.ReadLine();

                char[] chars = { ' ' };
                string[] grades = input.Split(chars, StringSplitOptions.RemoveEmptyEntries);

                foreach(string grade in grades)
                {
                    //Regex to allow only positive int values
                    string pattern = @"^\d+$";
                    Regex regex = new Regex(pattern);

                    input = input.Trim();

                    if(regex.IsMatch(grade))
                    {
                        numericalGrade = int.Parse(grade);  
                        if (numericalGrade > 0 && numericalGrade <= 100)
                        {
                            gradesList.Add(int.Parse(grade));
                            isValidInteger = true;
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
            }

            return gradesList;
        }

    }

}
