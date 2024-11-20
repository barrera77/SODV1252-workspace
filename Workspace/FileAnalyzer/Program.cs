

namespace FileAnalyzer
{
    internal class Program
    {

        static private List<KeyValuePair<string, decimal>> salesByProductList;
        static private List<KeyValuePair<string, decimal>> salesByMonthList;
        //static private List<Sale> sales;
        static void Main(string[] args)
        {
            GetAndProcessUserInput();

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
            Dictionary<string, decimal> salesByProduct = new Dictionary<string, decimal>();

            decimal totalSales = 0;

            foreach (var sale in sales)
            {
                if (salesByProduct.ContainsKey(sale.ProductName))
                {
                    salesByProduct[sale.ProductName] += sale.SalesAmount;
                }
                else
                {
                    salesByProduct.Add(sale.ProductName, sale.SalesAmount);
                }

                totalSales += sale.SalesAmount;
            }

            salesByProductList = new List<KeyValuePair<string, decimal>>(salesByProduct);

            for (int i = 0; i < salesByProductList.Count - 1; i++)
            {
                for (int j = 0; j < salesByProductList.Count - 1 - i; j++)
                {
                    if (salesByProductList[j].Value < salesByProductList[j + 1].Value)
                    {
                        var temp = salesByProductList[j];
                        salesByProductList[j] = salesByProductList[j + 1];
                        salesByProductList[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine($"\n\n{title}");
            foreach (var kvp in salesByProductList)
            {
                Console.WriteLine($"\n{kvp.Key}: {kvp.Value}");
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
            Console.WriteLine($"\n\n{title}");
            SortSalesByDate(sales);
        }

            static void WriteSalesData(List<Sale> sales, string file)
            {
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string outputFilePath = Path.Combine(projectDirectory, file);

            Console.WriteLine(projectDirectory);
            
                try
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        foreach (var sale in sales)
                        {
                            // Write the data in the same format: ProductName, SaleDate, Amount
                            string line = $"{sale.ProductName}, {sale.DateOfSale:MM/dd/yyyy}, {sale.SalesAmount:F2}";
                            writer.WriteLine(line);
                        }
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine($"Error writing the file: {e.Message}");
                }
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
        static string ValidateInput(string prompt)
        {
            bool isValidInput = false;
            string input = "";

            Console.Write(prompt);

            while (!isValidInput)
            {
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.Write($"Invalid input. Please enter a valid search criteria:");
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
            string input = ValidateInput("\n\nEnter search strings separated by commas: ");

            string[] searchCriteria = input.Split(", ");
                        
            Console.WriteLine("\n\nTotal sales by Filtered product:");

            //Find the sales by product as per search criteria
            foreach (var kvp in salesByProductList)
            {
                foreach (var criteria in searchCriteria)
                {
                    if (kvp.Key.Contains(criteria))
                    {
                        Console.WriteLine($"\n{kvp.Key}: {kvp.Value}");
                    }
                }
            }
            List<Sale> filteredSales = new List<Sale>();

            //Sales Filtered by product and groupped by Month
            foreach (var sale in sales)
            {
                foreach (var criteria in searchCriteria)
                {
                    if (sale.ProductName.Contains(criteria))
                    {
                        filteredSales.Add(sale);
                    }                   
                }
            }

            Console.WriteLine("\n\nTotal sales by Filtered product group by Month:");
            SortSalesByDate(filteredSales);

        }

        static void SortSalesByDate(List<Sale> salesList)
        {
            Dictionary<string, decimal> salesByProduct = new Dictionary<string, decimal>();
            decimal totalSales = 0;

            foreach (var sale in salesList)
            {
                if (salesByProduct.ContainsKey(sale.DateOfSale.Month.ToString()))
                {
                    salesByProduct[sale.DateOfSale.Month.ToString()] += sale.SalesAmount;
                }
                else
                {
                    salesByProduct.Add(sale.DateOfSale.Month.ToString(), sale.SalesAmount);
                }

                totalSales += sale.SalesAmount;
            }

            List<KeyValuePair<string, decimal>> groupedSalesList = new List<KeyValuePair<string, decimal>>(salesByProduct);

            for (int i = 0; i < groupedSalesList.Count - 1; i++)
            {
                for (int j = 0; j < groupedSalesList.Count - 1 - i; j++)
                {
                    if (groupedSalesList[j].Value < groupedSalesList[j + 1].Value)
                    {
                        var temp = groupedSalesList[j];
                        groupedSalesList[j] = groupedSalesList[j + 1];
                        groupedSalesList[j + 1] = temp;
                    }
                }
            }

            foreach (var vpk in groupedSalesList)
            {
                Console.WriteLine($"\n{GetMonthOfTheYear(Int32.Parse(vpk.Key))}: {vpk.Value}");
            }
        }

        static void GetAndProcessUserInput()
        {
            string inputFileName = "";
            string outputFileName = "";
            bool isValidInputFile = true;
            bool isValidOutputFile = true;

            while (isValidInputFile)
            {
                Console.Write("Enter the input file path:");
                inputFileName = Console.ReadLine();

                if (!IsValidFileInput(inputFileName))
                {
                    Console.WriteLine("Invalid file path. Please enter a valid path e.g. file.txt");
                    
                    continue;
                }
                else
                {
                    isValidInputFile = false;   
                }   

                while (isValidOutputFile)
                {
                    Console.Write("\nEnter the output file path:");                    
                    outputFileName = Console.ReadLine();

                    if (!IsValidFileInput(outputFileName))
                    {
                        Console.WriteLine("Invalid file path. Please enter a valid path e.g. file.txt");
                        continue;
                    }
                    else
                    {
                        isValidOutputFile = false;
                    }                    
                }
                //string fileName = "sales.txt";
                string directoryPath = Directory.GetCurrentDirectory();
                string inputFilePath = Path.Combine(directoryPath, inputFileName);
                string outputFilePath = Path.Combine(directoryPath, outputFileName);

                List<Sale> sales = ReadSalesData(inputFilePath);

                Console.WriteLine(sales);

                DisplayTotalSalesByProduct(sales, "Total sales by Product: ");
                DisplayTotalSalesByMonth(sales, "Total sales by Month:");
                SearchSalesData(sales);

                WriteSalesData(sales, outputFileName);

                Console.Write($"\n\nThe output is successfully saved to {outputFileName}.");
                Console.ReadLine();
            }
           
        }

        /// <summary>
        /// validate the file name and extension entered by the user
        /// </summary>
        /// <param name="inputFileName"></param>
        /// <returns></returns>
        static bool IsValidFileInput(string inputFileName)
        {            

            string fileExtension = Path.GetExtension(inputFileName);

            return fileExtension.Equals(".txt", StringComparison.OrdinalIgnoreCase) &&
                inputFileName.IndexOfAny(Path.GetInvalidFileNameChars()) == -1;
            
        }

        #endregion
    }
}
