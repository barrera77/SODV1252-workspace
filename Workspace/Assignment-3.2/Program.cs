using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_3._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string promptMsg = "Enter the number of elements you wish to add to the array (between 1 and 30): ";

            CreateResult(promptMsg);


        }

        public static void CreateResult(string promptMsg)
        {
            int numOfElements = 0;
            int intElement = 0;

            double average = 0;
            double standardDeviation = 0;
            double median = 0;
            double mode = 0;
            List<double> modes  = new List<double>();

            List<int> elementsList = new List<int>();
            int[] reversedElementsList;

            numOfElements = ValidateInput(promptMsg);

            Console.WriteLine(numOfElements);

            for (int i = 0; i < numOfElements; i++)
            {
                string prompt = ($"Enter integer # {i + 1} (between -10,000 and 10,000): ");
                intElement = ValidateInteger(prompt);
                
                elementsList.Add(intElement);
            }

            //Return the array of elements
            Console.WriteLine("Entered array:");

            foreach (var element in elementsList)
            {
                Console.Write($"{element} ");
            }

            //Return the reversed array
            Console.WriteLine("\nReversed array:");

            reversedElementsList = elementsList.ToArray();
            Array.Reverse(reversedElementsList);
                       
            foreach (var element in reversedElementsList)
            {
                Console.Write($"{element} ");
            }

            //Return the average of the array elements
            average = reversedElementsList.Average();
            Console.WriteLine($"\nThe average of the elements is: {average}");

            //Return the SD of the array elements
            standardDeviation = CalculateStandardDeviation(reversedElementsList);
            Console.WriteLine($"The standard deviation of the array elements is: {standardDeviation.ToString("0.00")}");

            //Rerturn the median of the array elements
            Array.Sort(reversedElementsList);
            median = CalculateMedian(reversedElementsList);
            Console.WriteLine($"The median of the array elements is: {median.ToString("0.00")}");

            //Return the mode of the array elements
            Array.Sort(reversedElementsList);
            mode = FindMode(reversedElementsList);
            Console.WriteLine($"The mode of the array elements is: {mode.ToString("0.00")}");
          

            

        }

        private static int ValidateInput(string promptMsg)
        {
            bool isValidNumOfElements = false;

            string input = "";

            int num = 0;

            Console.Write(promptMsg);

            while (!isValidNumOfElements)
            {
                input = Console.ReadLine();
              
                if (int.TryParse(input, out num))
                {
                    
                    if (num > 0 && num <= 30)
                    {
                        isValidNumOfElements = true; 
                    }
                    else
                    {
                        Console.Write("Invalid input. The number must be between 1 and 30: ");
                    }
                }
                else
                {
                    Console.Write("Invalid input. Please enter a valid number: ");
                }
            }
            
            return num;           
        }

        private static int ValidateInteger(string prompt)
        {
            bool isValidInteger = false;

            string input = "";

            int num = 0;

            Console.Write(prompt);

            while (!isValidInteger)
            {
                input = Console.ReadLine();

                if (int.TryParse(input, out num))
                {

                    if (num > -10000 && num <= 10000)
                    {
                        isValidInteger = true;
                    }
                    else
                    {
                        Console.Write("Invalid input. Please enter an integer between -10,000 and 10,000: ");
                    }
                }
                else
                {
                    Console.Write("Invalid input. Please enter a valid number: ");
                }
            }

            return num;
        }

       
        private static double CalculateStandardDeviation(int[] elementsList)
        {
            double standardDeviation = 0;
            double sum = 0;
            double average = 0;
            
            int count = 0;

            count = elementsList.Count();
            average = elementsList.Average();
            sum = elementsList.Sum(sd => (sd - average) * (sd - average));
            standardDeviation = Math.Sqrt(sum/count);

            return standardDeviation;
        }

        public static double CalculateMedian(int[] elementList)
        {
            double medianCalculation;
            int length = elementList.Length;  
            int middle = length / 2;
            Array.Sort(elementList);

            if(length % 2 == 0)
            {                 
                medianCalculation = (double)(elementList[middle - 1] + elementList[middle]) / 2;
            }
            else
            {
                medianCalculation = (double)elementList[middle];
            }

            return medianCalculation;
        }

        public static int FindMode(int[] elementsList)
        {
            int highestFrequency = 0;

            Dictionary<int, int> elementsArray = new Dictionary<int, int>();

            foreach (int element in elementsList)
            {
                if(elementsArray.ContainsKey(element))
                {
                    elementsArray[element]++;
                }
                else
                {
                    elementsArray[element] = 1;
                }
            }
            
            foreach (var value in elementsArray.Values)
            {
                if (value > highestFrequency)
                {
                    highestFrequency = value;
                }
            }

            foreach (KeyValuePair<int, int> elementPair in elementsArray)
            {
                if (elementPair.Value == highestFrequency)
                {
                    return elementPair.Key; 
                }
            }

            return elementsList[0];
        }



    }
}
