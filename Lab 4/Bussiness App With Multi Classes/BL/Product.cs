
using System;
using System.IO;
using RMS;

namespace rms.BL
{
    public class Product
    {
        public Product()
        {
            foodName = "No Name";
            foodPrice = 0;
            foodQuantity = 0;
        }

        public Product(string name, int price, int quantity)
        {
            foodName = name;
            foodPrice = price;
            foodQuantity = quantity;
        }
        public static void SearchItem(List<Product> products)
        {
            Program.managerHeader();
            Program.managerSubMenu("SEARCH ITEM FROM STOCK");

            Console.Write("           	                       1. ENTER ITEM NAME (YOU WANT TO SEARCH):  ");
            string name = Console.ReadLine();

            Console.WriteLine("\n                                                   RESULTS OF YOUR SEARCH\n");

            bool flag = false;
            Product product = products.Find(e => e.foodName == name);
            if (product != null)
            {
                Console.WriteLine("                                          ITEM NAME      " + "   PRICE" + "          " + "   QUANTITY");
                Console.WriteLine("{0,-42} {1,-12} {2,-21} {3,-20}", "", product.foodName, product.foodPrice, product.foodQuantity);
                flag = true;
            }
            else
            {
                flag = false;
            }


            if (!flag)
            {
                Program.itemError();
            }
        }
        // ****************** 12. REMOVE ITEM FROM STOCK FUNCTION *******************

        public static void RemoveItem(string path1, List<Product> products)
        {
            Program.managerHeader();
            Program.managerSubMenu("REMOVE ITEM FROM STOCK");
            Console.Write("\t\t\t\t\t\t\t 1. ENTER ITEM NAME (YOU WANT TO REMOVE): ");
            string name = Console.ReadLine();
            bool flag = false;
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].foodName == name)
                {
                    Console.WriteLine($"\n \t \t \t \t \t \t \t YOU HAVE REMOVED {products[i].foodName}");
                    products.RemoveAt(i);
                    flag = true;
                    Program.countFood--;
                    Program.storeStock(path1, products);
                    break;
                }
                else
                {
                    flag = false;
                }
            }
            if (flag == false)
            {
                Program.itemError();
            }
        }
        public static void UpdateStock(string path1, List<Product> products)
        {
            Program.managerHeader();
            Program.managerSubMenu("UPDATE STOCK");

            Console.Write("           	                       1. ENTER ITEM NAME (YOU WANT TO UPDATE):  ");
            string name = Console.ReadLine();

            bool flag = false;
            for (int i = 0; i < products.Count; i++)
            {
                if (name == products[i].foodName)
                {
                    string itemName = products[i].foodName;
                    Console.Write("           	                       2. ENTER ITEM'S NEW PRICE:  ");
                    int price = Program.validateInteger();
                    Console.Write("           	                       3.ENTER ITEM'S NEW QUANTITY:  ");
                    int quantity = Program.validateInteger();

                    Console.WriteLine("\n                      \t\t      ITEM NAME         UPDATED PRICE         UPDATED QUANTITY");
                    Product updateProduct = new Product(itemName,price,quantity);
                    Console.WriteLine($"{"",42}{updateProduct.foodName,12}      {updateProduct.foodPrice,21}{updateProduct.foodQuantity,20}");
                    products.RemoveAt(i);
                    products.Insert(i, updateProduct);
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                Program.itemError();
            }
            Program.storeStock(path1, products);
        }


        public string foodName = "";
        public int foodPrice;
        public int foodQuantity;
    }
}