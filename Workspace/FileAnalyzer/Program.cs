namespace FileAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        #region Main Tasks
        static List<Sale> ReadSalesData(string file)
        {
            List<Sale> sales = new List<Sale>();    




            return sales;

        }

        static void DisplayTotalSalesByProduct(List<Sale> sales, string title)
        {

        }

        static void DisplayTotalSalesByMonth(List<Sale> sales, string title)
        {

        }

        static void WriteSalesData(List<Sale> sales, string file)
        {

        }

        #endregion

        #region Helper Methods
        //Validate file name
        static bool IsValidFileName(string fileName)
        {
            return !String.IsNullOrWhiteSpace(fileName);
        }

        /// <summary>
        /// Validates user input
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="element"></param>
        /// <returns>validated input</returns>
        static string ValidateInput(string prompt, string element)
        {
            bool isValidInput = false;
            string input = "";

            Console.Write(prompt);

            while (!isValidInput)
            {

                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.Write($"Invalid input. Please enter a valid {element}:");
                }
                else
                {
                    isValidInput = true;
                }
            }
            return input;
        }

       

        #endregion
    }
}
