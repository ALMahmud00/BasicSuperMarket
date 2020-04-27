using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicSuperMarket
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=========================================\n" +
                "Welcome to Super Market Shop Menu\n" +
                "=========================================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Add Product items\n" +
                "2. Delete items\n" +
                "3. Buy an Item\n" +
                "4. Show min and max items based on Quantity\n" +
                "5. Find an item\n" +
                "6. Print all items\n" +
                "7. Exit\n" +
                "=========================================\n");


            string PrID;
            string PrName;
            double PrAmount;
            int PrQuantity;
            int PrRating;
            int id=204;
            List<Product> ProductList = new List<Product>();
            List<BuyProduct> BuyProductList = new List<BuyProduct>();
            
            //default add product list
            ProductList.Add(new Product() { ProductID="101", ProductName = "Biscuit", ProductAmount = 100.00, ProductQuantity = 20, ProductRating = 5});
            ProductList.Add(new Product() { ProductID = "102", ProductName = "Cake", ProductAmount = 150.00, ProductQuantity = 60, ProductRating = 5 });
            ProductList.Add(new Product() { ProductID = "103", ProductName = "Bread", ProductAmount = 250.00, ProductQuantity = 30, ProductRating = 5 });
            ProductList.Add(new Product() { ProductID = "104", ProductName = "Pepsi", ProductAmount = 120.00, ProductQuantity = 25, ProductRating = 5 });
            ProductList.Add(new Product() { ProductID = "105", ProductName = "Rc", ProductAmount = 130.00, ProductQuantity = 50, ProductRating = 5 });
            //default add buy product list
            BuyProductList.Add(new BuyProduct() { ID = "201", ProductID = "101", ProductQuantity = 10 });
            BuyProductList.Add(new BuyProduct() { ID = "202", ProductID = "101", ProductQuantity = 10 });
            BuyProductList.Add(new BuyProduct() { ID = "203", ProductID = "102", ProductQuantity = 10});

            bool loop = true;
            while(loop)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter your choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter product ID: ");
                        PrID = Console.ReadLine();
                        Console.Write("Enter product Name: ");
                        PrName = Console.ReadLine();
                        Console.Write("Enter product Price: ");
                        PrAmount =Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter product Quantity: ");
                        PrQuantity = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter product Rating: ");
                        PrRating = Convert.ToInt32(Console.ReadLine());

                        ProductList.Add(new Product() { ProductID = PrID, ProductName = PrName, ProductAmount = PrAmount, ProductQuantity = PrQuantity, ProductRating = PrRating });
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("=========================================\n" +
                           "Product Added Successfully.\n" +
                           "=========================================");
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Enter a product code to delete: ");
                        PrID = Console.ReadLine();

                        var delProd = ProductList.Where(x=> x.ProductID == PrID).ToList<Product>();

                        if(delProd.Count() == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("=========================================\n" +
                               "Product didn't found.\n" +
                               "=========================================");
                        }
                        else
                        {
                            ProductList.RemoveAll(x => x.ProductID == PrID);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("=========================================\n" +
                               "Product Removed Successfully.\n" +
                               "=========================================");
                        }
                        
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.White;
                        
                        Console.Write("Enter product ID: ");
                        PrID = Console.ReadLine();
                        
                        Console.Write("Enter product Quantity: ");
                        PrQuantity = Convert.ToInt32(Console.ReadLine());
                        
                        BuyProductList.Add(new BuyProduct() { ID = id.ToString(), ProductID = PrID, ProductQuantity = PrQuantity });
                        id++;


                        var minusQuantity = ProductList.Where(x=> x.ProductID == PrID).FirstOrDefault();
                        
                        minusQuantity.ProductQuantity -= PrQuantity;
                       
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("=========================================\n" +
                          "Product Bought Successfully.\n" +
                          "=========================================");
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(">>>>>>>>>>>> Minimum Quantity <<<<<<<<<<<");
                        var FindMin = (from x in ProductList
                                       select x.ProductQuantity).Min();
                        var findMinObj = (from x in ProductList
                                         where x.ProductQuantity == FindMin
                                         select x);
                        Console.ForegroundColor = ConsoleColor.White;
                        foreach (var item in findMinObj)
                        {
                            item.ShowProduct();
                        }
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(">>>>>>>>>>>> Maximum Quantity <<<<<<<<<<<");
                        var findMax = (from x in ProductList
                                       select x.ProductQuantity).Max();
                        var findMaxObj = (from x in ProductList
                                          where x.ProductQuantity == findMax
                                          select x);
                        Console.ForegroundColor = ConsoleColor.White;
                        foreach (var item in findMaxObj)
                        {
                            item.ShowProduct();
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("=========================================\n" +
                          "\n" +
                          "=========================================");
                        break;


                    case 5:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Enter Product id to find: ");
                        PrID = Console.ReadLine();

                        var findPr = ProductList.Where(x => x.ProductID == PrID);

                        if(findPr.Count() == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(">>>>>>>>>>>> no product <<<<<<<<<<<");
                        }else{
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(">>>>>>>>>>>> found product <<<<<<<<<<<");
                            Console.ForegroundColor = ConsoleColor.White;
                            foreach (var item in findPr)
                            {
                                item.ShowProduct();
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("=========================================\n" +
                          "\n" +
                          "=========================================");
                        break;


                    case 6:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(">>>>>>>>>>>>>> Product List <<<<<<<<<<<<<");
                        Console.ForegroundColor = ConsoleColor.White;
                        foreach (var item in ProductList)
                        {
                            item.ShowProduct();
                        }
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(">>>>>>>>>>>> Buy Product List <<<<<<<<<<<");
                        Console.ForegroundColor = ConsoleColor.White;
                        foreach (var item in BuyProductList)
                        {
                            item.ShowBuyProduct();
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("=========================================");
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("=========================================\n" +
                            "Thank you to shop here\n" +
                            "=========================================\n");
                        loop = false;
                        break;
                }
                Console.ForegroundColor = ConsoleColor.White;
            }


           
        }
    }
}
