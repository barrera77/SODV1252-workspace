namespace Assignment_2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string productName = "";

            decimal productCost;
            decimal taxRate;
            decimal subTotal;
            decimal total;

            int productQty;

            bool isValidInput = false;

            Console.WriteLine("Variables and Data Types\n");            
            
            while(!isValidInput)
            {
                Console.Write("Enter the name of the product: ");
                productName = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(productName))
                {
                    Console.WriteLine("Invalid entry");
                    isValidInput = false;
                }
                else
                {
                    productCost = ValidateAmounts("Enter the cost of the product: ");
                    productQty = ValidateQty("Enter the quantity of the product: ");
                    taxRate = ValidateAmounts("Enter the tax rate for example enter 0.07 for 7%: ");

                    subTotal = productCost * (decimal)productQty;
                    total = subTotal + (subTotal * taxRate);

                    Console.WriteLine("\n---- Product Summary ----");
                    Console.WriteLine($"Product Name: {productName}");
                    Console.WriteLine($"Product Cost: {productCost}");
                    Console.WriteLine($"product Quantity: {productQty}");
                    Console.WriteLine($"Tax Rate: {taxRate * 100}%");
                    Console.WriteLine($"Total Price with Tax: ${total}");
                    Console.ReadLine();

                    isValidInput = true;
                }              
            }
        }

        /// <summary>
        /// Verifies that the price and tax amounts are valid numeric values
        /// </summary>
        /// <param name="propmtMsg"></param>
        /// <returns>the validated amount as a decimal</returns>
        private static decimal ValidateAmounts(string propmtMsg)
        {
            decimal number = 0;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.Write(propmtMsg);

                if (decimal.TryParse(Console.ReadLine(), out number))
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

        /// <summary>
        /// Verifies that the product quantity is a valid numeric value
        /// </summary>
        /// <param name="propmtMsg"></param>
        /// <returns>the validated number of items as int</returns>
        private static int ValidateQty(string propmtMsg)
        {
            int number = 0;
            bool isValidInput = false;

            while (!isValidInput)
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
