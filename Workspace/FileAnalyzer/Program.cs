using System;
using System.Xml;

namespace FileAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "sales.txt";
            string directoryPath = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(directoryPath, fileName);
          
            List<Sale> sales = ReadSalesData(filePath);

            DisplayTotalSalesByProduct(sales, "title");



        }

        #region Main Tasks
        static List<Sale> ReadSalesData(string file)
        {
            List<Sale> sales = new List<Sale>();

            try
            {
                if (File.Exists(file))
                {
                    string[] lines = File.ReadAllLines(file);

                    foreach(var line in lines)
                    {
                        Sale sale = ParseFileLines(line);
                        sales.Add(sale);    
                    }
                }
                else
                {
                    throw new IOException("Error reading the sales data file.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            foreach (Sale sale in sales)
            {
                Console.WriteLine(sale.ProductName + ", " + sale.DateOfSale + ", " + sale.SalesAmount);
            }

            return sales;
        }

        static void DisplayTotalSalesByProduct(List<Sale> sales, string title)
        {
            List<Sale> salesByProduct =  sales;
            salesByProduct.Sort();
            salesByProduct.Reverse();

            foreach(Sale sale in salesByProduct)
            {
                Console.WriteLine(sale.ProductName + ", " + sale.DateOfSale + ", " + sale.SalesAmount);
            }

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

        static Sale ParseFileLines(string line)
        {
            string[] parts = line.Split(",");
            Sale sale = new Sale();

            if (parts.Length == 3 
                && DateTime.TryParse(parts[1].Trim(), out DateTime date) 
                && decimal.TryParse(parts[2], out decimal amount))
            {
                sale = new Sale
                {
                    ProductName = parts[0].Trim(),
                    DateOfSale = date,
                    SalesAmount = amount,

                };
            }

            return sale;
        }

       

        #endregion
    }
}
