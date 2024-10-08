using System;
using System.Runtime.InteropServices;
using System.Xml;

namespace FileAnalyzer
{
    internal class Program
    {

        private static List<Sale> SalesByProduct = new List<Sale>();
        private static List<Sale> SalesByMonth = new List<Sale>();

        static void Main(string[] args)
        {
            string fileName = "sales.txt";
            string directoryPath = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(directoryPath, fileName);
          
            List<Sale> sales = ReadSalesData(filePath);

            DisplayTotalSalesByProduct(sales, "title");
            DisplayTotalSalesByMonth(sales, "title");



        }

        #region Main Tasks

        /// <summary>
        /// Read the info from the file and format it into a list
        /// for further processing
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
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

            return sales;
        }

        /// <summary>
        /// Sort the sales by product name and compute the total sales
        /// for each product
        /// </summary>
        /// <param name="sales"></param>
        /// <param name="title"></param>
        static void DisplayTotalSalesByProduct(List<Sale> sales, string title)
        {
            SalesByProduct = sales.GroupBy(s => s.ProductName)
                                            .Select(salesGroup => new Sale
                                            {
                                                ProductName = salesGroup.Key,
                                                SalesAmount = salesGroup.Sum(sg => sg.SalesAmount)

                                            })
                                            .OrderByDescending(ps => ps.SalesAmount)
                                            .ToList();

            Console.WriteLine("Total sales by Product: ");
            foreach (Sale sale in SalesByProduct)
            {
                Console.WriteLine($"{sale.ProductName}: ${sale.SalesAmount}");
            }
        }

        /// <summary>
        /// Sort the sales by month and compute the total sales
        /// for each product
        /// </summary>
        /// <param name="sales"></param>
        /// <param name="title"></param>
        static void DisplayTotalSalesByMonth(List<Sale> sales, string title)
        {
            SalesByMonth = sales.GroupBy(s => s.DateOfSale.Month)
                                                        .Select(salesGroup => new Sale
                                                        {
                                                            ProductName = GetMonthOfTheYear(salesGroup.Key),
                                                            SalesAmount = salesGroup.Sum(sg => sg.SalesAmount)
                                                        })
                                                        .OrderByDescending(ps => ps.SalesAmount)
                                                        .ToList();

            Console.WriteLine("\n\n\nTotal sales by Month: ");
            foreach (Sale sale in SalesByMonth)
            {
                Console.WriteLine($"{sale.ProductName}: ${sale.SalesAmount}");
            }

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

        /// <summary>
        /// Format the file lines into Sale objects
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Obtain the name of the month based on numeric value from the
        /// DateOfSale property
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        static string GetMonthOfTheYear(int month)
        {
            DateTime date = new DateTime(2024, month, 1);
            return date.ToString("MMMM");
        }

        
        static void SearchSalesData(List<Sale> sales)
        {
            Console.Write("Enter search strings separated by commas: ");

            
        }
       

        #endregion
    }
}
