using System;
using System.Xml;

namespace FileAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string fileName = "sales.txt";
            //string directoryPath = Directory.GetCurrentDirectory();
            //string filePath = Path.Combine(directoryPath, fileName);
            //ReadSalesData(filePath);

            int n = 6;

            //left triangle
            //for (int i = 1; i <= n; i++)
            //{
            //    for(int j = 1; j <= n -i + 1; j++)
            //    {
                    
            //    }
            //}

            //Right Triangle
            //for (int i = 1; i <= n; i++)
            //{
            //    for (int j = 1; j <= i ;j++ )
            //    {

            //    }
            //}


            //for (int i = 1; i <= n; i++)
            //{
            //    for (int j = 1; j <= i - 1; j++)
            //    {
            //        Console.Write("  ");
            //    }
            //    for (int j = 1; j <= n -i + 1; j++)
            //    {
            //        Console.Write((n+2) -i -j + " ");

                //    }
                //    Console.WriteLine();
                //}
                //Console.ReadLine();

                //To create a pyramid, start by dividing the pattern in triangles

                //for(int i = 0; i < n; i++)
                //{
                //  Space Triangle    
                //    for (int j = 1; j <= n - i; j++)
                //    {
                //        Console.Write("  ");
                //    }

                //Left Triangle
                //    for (int j = 1; j <= i; j++)
                //    {
                //        Console.Write(i - j + 1 + " ");
                //    }                

                //Right Triangle
                //    for (int j = 1; j <= i - 1; j++)
                //    {
                //        Console.Write(j + 1 +" ");
                //    }
                //    Console.WriteLine();

                //}
                //Console.ReadLine();

                //TODO - Make it a pyramid
                //for(int i = 1; i <=n; i++)
                //{
                //    for(int j = 1; j <= n -i; j++)
                //    {
                //        Console.Write(" ");
                //    }
                //    Console.WriteLine();

                //    for(int k = 1; k <= i; k++)
                //    {
                //        Console.Write("* ");
                //    }
                //}
                //Console.ReadLine();

                //TODO - Make it a pyramid
                //for (int i = 1; i <= n; i++)
                //{
                //    for(int j = 1; j <= n-1; j++)
                //    {
                //        Console.Write("  ");
                //    }
                //    for (int j = 1; j <= i; j++)
                //    {
                //        Console.Write(j + " ");
                //    }

                //    for(int j = 1; j <= i -1; j ++)
                //    {
                //        Console.Write(i - j + " ");
                //    }
                //    Console.WriteLine();
                //}
                //Console.ReadLine();

            //Make these 2 the same result
            //for (int i = 1; i <= n; i++)
            //{
            //    for (int j = 1; j <= i; j++)
            //    {
            //        Console.Write(i * j + " ");
            //    }
            //    Console.WriteLine();

            //}

            //for (int i = 1; i <= n; i++)
            //{
            //    for (int j = 1; j <= i*i; j += i)
            //    {
            //        Console.Write(j + " ");
            //    }
            //    Console.WriteLine();

            //}

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
                    throw new IOException("Error reading the story template file.");
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
