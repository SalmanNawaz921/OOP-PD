
using System;
using RMS;
using rms.BL;
using rms.UI;

namespace rms.DL
{

    class ProductUI
    {
        public static Product takeInputForProduct()
        {
            ManagerUI.Header();
            ManagerUI.SubMenu("ADD STOCK");
            Product newProduct = new Product();
            bool nameError = false;
            if (Manager.productList().Count < 10)
            {
                Console.Write("1. ENTER FOOD ITEM NAME:  ");
                string name = MiscUI.NameValidation();
                Console.Write("2. ENTER FOOD ITEM PRICE: ");
                int price = MiscUI.ValidateInteger();
                Console.Write("3. ENTER FOOD ITEM QUANTITY: ");
                int quantity = MiscUI.ValidateInteger();
                Product product = Manager.productList().Find(e => e.getItemName() == name);
                if (product != null)
                {
                    Console.WriteLine("\tSorry, Another Food Item With Same Name Exists");
                    nameError = true;
                }

                if (nameError == false)
                {
                    newProduct = new Product(name, price, quantity);
                }
                else
                {
                    newProduct = null;
                }
            }
            else
            {
                Console.WriteLine("\tSorry, We Have Maximum Food Items");
                newProduct = null;
            }
            return newProduct;
        }
        public static Product takeInputForExistingItem()
        {
            Product updateProduct = new Product();
            bool nameError = false;
            Console.Write("1. ENTER FOOD ITEM NAME:  ");
            string name = MiscUI.NameValidation();
            Product product = Manager.productList().Find(e => e.getItemName() == name);
            if (product != null)
            {
                Console.WriteLine("\tSorry, Another Food Item With Same Name Exists");
                nameError = true;
            }
            else if (nameError != true && product == null)
            {
                Console.Write("2. ENTER FOOD ITEM PRICE: ");
                int price = MiscUI.ValidateInteger();
                Console.Write("3. ENTER FOOD ITEM QUANTITY: ");
                int quantity = MiscUI.ValidateInteger();

                updateProduct = new Product(name, price, quantity);

            }

            if (nameError == true)
            {
                updateProduct = null;
            }

            return updateProduct;
        }

        public static void viewSearchedProduct()
        {
            ManagerUI.Header();
            ManagerUI.SubMenu("SEARCH ITEM FROM STOCK");
            Product product = ProductsDL.SearchItem();
            if (product != null)
            {
                Console.WriteLine("{0, 0}{1, -20}{2, -15}{3, -20}", "", "ITEM NAME", "PRICE", "QUANTITY");
                Console.WriteLine(product.toString());
            }
            else
            {
                itemError();
            }
        }
        public static void ViewStock()
        {
            ManagerUI.Header();
            ManagerUI.SubMenu("VIEW STOCK");
            Console.WriteLine("\tSTOCK OF ITEMS\n");
            Console.WriteLine("{0, 0}{1, -20}{2, -15}{3, -20}", "", "ITEM NAME", "PRICE", "QUANTITY");
            foreach (Product product in Manager.productList())
            {
                Console.WriteLine(product.toString());

            }
        }

        public static void viewSortedList()
        {
            ManagerUI.Header();
            ManagerUI.SubMenu("SORTED LIST");
            List<Product> sortedList = ProductsDL.sortProducts();
            Console.WriteLine("{0, 0}{1, -20}{2, -15}{3, -20}", "", "ITEM NAME", "PRICE", "QUANTITY");
            foreach (Product product in sortedList)
            {
                Console.WriteLine(product.toString());

            }
        }
        public static void itemError()
        {
            Console.WriteLine("\tSorry, Item Does Not Exist");
        }
    }
}