
using System;
using RMS;
using rms.BL;
using rms.UI;

namespace rms.DL
{

    class ProductsDL
    {
        public static List<Product> sortedList = new List<Product>();
        public static Product SearchItem()
        {
            Console.Write("1. ENTER ITEM NAME: ");
            string name = MiscUI.NameValidation();
            Product product = Manager.productList().Find(e => e.getItemName() == name);
            return product;
        }
        public static void RemoveItem()
        {
            ManagerUI.Header();
            ManagerUI.SubMenu("REMOVE ITEM FROM STOCK");
            Product product = SearchItem();
            if (product != null)
            {
                Console.WriteLine($"\n\tYOU HAVE REMOVED {product.getItemName()}");
                Manager.productList().Remove(product);
            }
            else
            {
                ProductUI.itemError();
            }
        }
        public static List<Product> sortProducts()
        {
            Console.WriteLine("1. PRICE LOW TO HIGH");
            Console.WriteLine("2. PRICE HIGH TO LOW");
            Console.Write("    YOUR OPTION: ");
            int option = MiscUI.ValidateInteger();
            if (option == 1)
            {
                sortedList = Manager.productList().OrderBy(o => o.getItemPrice()).ToList();
            }
            else if (option == 2)
            {
                sortedList = Manager.productList().OrderByDescending(o => o.getItemPrice()).ToList();
            }
            else
            {
                sortedList = Manager.productList();
            }
            return sortedList;

        }
        public static void UpdateStock()
        {
            ManagerUI.Header();
            ManagerUI.SubMenu("UPDATE STOCK");
            Product product = SearchItem();
            if (product != null)
            {
                int index = Manager.productList().IndexOf(product);
                Product updateProduct = ProductUI.takeInputForExistingItem();
                if (updateProduct != null)
                {
                    string foodName = product.getItemName();
                    updateProduct.setItemName(foodName);
                    Manager.productList().RemoveAt(index);
                    Manager.productList().Insert(index, updateProduct);
                }
                else
                {
                    return;
                }
            }
            else
            {
                ProductUI.itemError();
            }
        }
        public static void loadStock(string path)
        {
            string line;
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    string[] userFields = line.Split(',');
                    string name = userFields[0];
                    int price = int.Parse(userFields[1]);
                    int quantity = int.Parse(userFields[2]);
                    Product product = new Product(name, price, quantity);
                    Manager.productList().Add(product);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("Path Not Found");
            }
        }

        //****************** STORE STOCK *****************

        public static void storeStock(string path)
        {
            StreamWriter file = new StreamWriter(path);
            foreach (Product product in Manager.productList())
            {
                file.WriteLine(product.getItemName() + "," + product.getItemPrice() + "," + product.getItemQuantity());
            }
            file.Close();
        }

    }
}