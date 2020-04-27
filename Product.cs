using System;
using System.Collections.Generic;
using System.Text;

namespace BasicSuperMarket
{
    class Product
    {
        public string ProductID { set; get;}
        public string ProductName { set; get; }
        public double ProductAmount { set; get; }
        public int ProductQuantity { set; get; }
        public int ProductRating { set; get; }

        public void ShowProduct()
        {
            Console.Write("Product ID: "+ProductID);
            Console.Write("  Name: " + ProductName);
            Console.Write("  Price: " + ProductAmount);
            Console.Write("  Quantity: " + ProductQuantity);
            Console.WriteLine("  Rating: " + ProductRating);
        }
    
    }
}
