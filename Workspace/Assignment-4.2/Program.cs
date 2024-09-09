namespace Assignment_4._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        /// <summary>
        /// Compile operations and format output to print for the user
        /// </summary>
        /// <param name="promptMsg"></param>
        public static void CreateResult()
        {
            //Display menu to initiate the program sequence
            DisplayMainMenu();
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

        }
    }
}
