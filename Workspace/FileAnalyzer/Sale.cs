using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzer
{
    public class Sale 
    {
        private string _productName;
        private DateTime _dateOfSale;
        private decimal _salesAmount;

        //Default Constructor
        public Sale() { }

        //ProductName
        public string ProductName
        {
            get { return _productName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input, please provide a name for the product");
                }
                else
                {
                    _productName = value.Trim();
                }
            }
        }

        //Date of Sale
        public DateTime DateOfSale
        { 
            get { return _dateOfSale; } 
            set
            {
                _dateOfSale = value;
            }
        }

        public decimal SalesAmount
        { 
            get { return _salesAmount; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Invalid input, please provide a valid amount");
                }
                _salesAmount = value;
            }
        }

        //Greedy Constructor
        public Sale(string productName, DateTime dateOfSale, decimal salesAmount)
        {
            ProductName = productName;
            DateOfSale = dateOfSale; ;
            SalesAmount = salesAmount;
        }

        public override string ToString()
        {
            return $"{ProductName}, {DateOfSale.ToShortDateString()}, {SalesAmount:F2}";
        }

        
        public string ToCustomString()
        {
            return $"{ProductName}: ${SalesAmount:F2}";
        }

        public string ToMonthSummaryString()
        {
            return $"{DateOfSale.ToString("MMMM")}: ${SalesAmount:F2}";
        }
    }
}
