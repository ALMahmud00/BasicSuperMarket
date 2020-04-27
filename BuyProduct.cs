using System;
using System.Collections.Generic;
using System.Text;

namespace BasicSuperMarket
{
    class BuyProduct
    {
        public string ID { set; get; }
        public string ProductID { set; get; }
        public int ProductQuantity { set; get; }

        public void ShowBuyProduct()
        {
            Console.Write("ID: " + ID);

            Console.Write("  Product ID: " + ProductID);
            
            Console.WriteLine("  Quantity: " + ProductQuantity);
            
        }

    }
}
