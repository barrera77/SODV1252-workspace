using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzer
{
    internal class Sale
    {
        private string _productName;
        private DateOnly _dateOfSale;
        private decimal _salesAmount;

        //Default Constructor


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
        public DateOnly DateOfSale
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
                if(_salesAmount < 0)
                {
                    throw new ArgumentException("Invalid input, please provide a valid amount");
                }
                _salesAmount = value;
            }
        }

        //Greedy Constructor
        public Sale(string productName, DateOnly dateOfSale, decimal salesAmount)
        {
            ProductName = productName;
            DateOfSale = dateOfSale; ;
            SalesAmount = salesAmount;
        }



    }
}
