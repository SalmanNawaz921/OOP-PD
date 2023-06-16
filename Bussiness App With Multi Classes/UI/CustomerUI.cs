using rms.BL;
using rms.DL;

namespace rms.UI
{
    public class CustomerUI
    {
        public static Customer takeInputForCustomer()
        {
            CashierUI.Header();
            CashierUI.SubMenu("ADD CUSTOMER");
            Customer newCustomer = new Customer();
            List<Product> ordersList = new List<Product>();
            bool idError = false;
            bool nameError = false;
            int bill = 0, left = 0;

            if (Cashier.customerList().Count < 10)
            {
                Console.Write("1. ENTER CUSTOMER NAME:  ");
                string name = MiscUI.NameValidation();
                Console.Write("2. ENTER CUSTOMER ID: ");
                int id = MiscUI.ValidateInteger();
                Customer customer = Cashier.customerList().Find(c => c.getCustomerID() == id);
                if (customer != null)
                {
                    Console.WriteLine("\n\tSorry, Another Customer With Same ID Already Exists");
                    idError = true; // Set idError to true when there is a duplicate customer ID
                }

                string order = "";
                int quantity = 0;
                int totalBill = 0;
                int totalQuantiity = 0;
                int totalLeft = 0;

                if (!idError)
                {
                    Console.Write("ENTER NO OF PRODUCTS YOU WANT TO ADD: ");
                    int no = MiscUI.ValidateInteger();
                    for (int i = 0; i < no; i++)
                    {
                        // quantity += quantity;
                        Console.Write("3. ADD CUSTOMER ORDER " + i + 1 + " :");
                        order = Console.ReadLine();
                        Console.Write("4. ADD QUANTITY OF ORDER: ");
                        quantity = int.Parse(Console.ReadLine());
                        var product = Manager.productList().FirstOrDefault(p => p.getItemName() == order);
                        if (product == null)
                        {
                            Console.WriteLine("\n\tError: " + order + " not found");
                            nameError = true;// Set nameError to true when there is a product not found error
                        }
                        else if (product.getItemQuantity() < quantity)
                        {
                            Console.WriteLine("\n\tError: Not enough " + order + " in stock");
                            nameError = true; // Set nameError to true when there is a product out of stock error

                        }
                        else
                        {
                            nameError = false;
                            idError = false;
                            int ProductPrice = product.getItemPrice() * quantity;
                            bill = product.getItemPrice() * quantity;
                            totalBill += bill;
                            totalQuantiity += quantity;
                            int foodQuantity = product.getItemQuantity();
                            foodQuantity -= quantity;
                            product.setItemQuantity(foodQuantity);
                            left = product.getItemQuantity();
                            totalLeft += left;
                            ordersList.Add(new Product(order, ProductPrice, quantity));
                        }
                    }
                }

                if (idError == false && nameError == false) // Only add the new customer if there is no error
                {
                    newCustomer = new Customer(name, id, ordersList, totalQuantiity, totalBill, totalLeft);
                }
                else
                {
                    newCustomer = null;
                }

            }
            else
            {
                Console.WriteLine("\n\tSorry, We Have Maximum Customers");
                newCustomer = null;
            }
            return newCustomer;
        }

        public static Customer takeInputForExistingCustomer()
        {
            CashierUI.Header();
            CashierUI.SubMenu("UPDATE CUSTOMER INFO");
            Customer updateCustomer = new Customer();
            bool idError = false;
            bool productError = false;
            int totalBill = 0;
            int totalQuantity = 0;
            int totalLeft = 0;
            List<Product> ordersList = new List<Product>();

            Console.Write("ENTER CUSTOMER'S ID: ");
            int newId = MiscUI.ValidateInteger();

            Customer customer = Cashier.customerList().Find(c => c.getCustomerID() == newId);

            if (customer != null)
            {
                Console.WriteLine("\n\tError: Customer ID already exists");
                idError = true;
            }
            else
            {
                Console.Write("ENTER NO OF PRODUCTS YOU WANT TO EDIT: ");
                int no = MiscUI.ValidateInteger();

                for (int i = 0; i < no; i++)
                {
                    Console.Write("ENTER CUSTOMER'S NEW ORDER: ");
                    string newOrder = Console.ReadLine();

                    Product product = Manager.productList().FirstOrDefault(p => p.getItemName() == newOrder);

                    if (product == null)
                    {
                        Console.WriteLine("\tError: Product not found");
                        productError = true;
                    }
                    else
                    {
                        Console.Write("ENTER CUSTOMER'S NEW QUANTITY: ");
                        int newQuantity = MiscUI.ValidateInteger();

                        if (product.getItemQuantity() < newQuantity)
                        {
                            Console.WriteLine("Error: Not enough {0} in stock", newOrder);
                            productError = true;
                        }

                        if (productError == false && idError == false && product != null)
                        {
                            productError = false;
                            idError = false;
                            int newPrice = product.getItemPrice() * newQuantity;
                            int foodQuantity = product.getItemQuantity();
                            foodQuantity -= newQuantity;
                            totalQuantity += newQuantity;
                            product.setItemQuantity(foodQuantity);
                            int bill = product.getItemPrice() * newQuantity;
                            totalBill += bill;
                            int left = product.getItemQuantity();
                            totalLeft += left;
                            ordersList.Add(new Product(newOrder, newPrice, newQuantity));
                            Console.WriteLine("Reached");
                        }
                    }
                }
            }

            if (idError == true || productError == true)
            {
                Console.WriteLine("fALSE");
                updateCustomer = null;
            }
            else
            {

                Console.WriteLine("True");
                updateCustomer = new Customer(" ", newId, ordersList, totalQuantity, totalBill, totalLeft);
                //updateCustomer.setOrderList(ordersList);

            }

            return updateCustomer;
        }


        //public static Customer takeInputForExistingCustomer()
        //{
        //    CashierUI.Header();
        //    CashierUI.SubMenu("UPDATE CUSTOMER INFO");
        //    Customer updateCustomer = new Customer();
        //    bool idError = false;
        //    bool productError = false;
        //    int totalBill = 0;
        //    int totalQuantity = 0;
        //    int totalLeft = 0;
        //    List<Product> ordersList = new List<Product>();
        //    Console.Write("ENTER CUSTOMER'S ID: ");
        //    int newId = MiscUI.ValidateInteger();
        //    Customer customer = Cashier.customerList().Find(c => c.getCustomerID() == newId);
        //    if (customer != null)
        //    {

        //        Console.WriteLine("\n\tError: Customer ID already exists");
        //        idError = true;
        //    }
        //    else
        //    {
        //        Console.Write("ENTER NO OF PRODUCTS YOU WANT TO EDIT: ");
        //        int no = MiscUI.ValidateInteger();

        //        for (int i = 0; i < no; i++)
        //        {
        //            Console.Write("ENTER CUSTOMER'S NEW ORDER ");
        //            string newOrder = Console.ReadLine();
        //            Product product = Manager.productList().FirstOrDefault(p => p.getItemName() == newOrder);
        //            if (product == null)
        //            {
        //                Console.WriteLine("\tError: Product not found");
        //                productError = true;
        //            }
        //            else
        //            {
        //                Console.Write("ENTER CUSTOMER'S NEW QUANTITY: ");
        //                int newQuantity = MiscUI.ValidateInteger();


        //                if (product.getItemQuantity() < newQuantity)
        //                {
        //                    Console.WriteLine("Error: Not enough {0} in stock", newOrder);
        //                    productError = true;

        //                }
        //                if (productError == false && idError == false && product != null)
        //                {
        //                    string name = " ";
        //                    int newPrice = product.getItemPrice() * newQuantity;
        //                    int foodQuantity = product.getItemQuantity();
        //                    foodQuantity -= newQuantity;
        //                    totalQuantity += newQuantity;
        //                    product.setItemQuantity(foodQuantity);
        //                    int bill = product.getItemPrice() * newQuantity;
        //                    totalBill += bill;
        //                    int left = product.getItemQuantity();
        //                    totalLeft += left;
        //                    if (customer != null)
        //                    {
        //                        //customer.getOrderList().Clear();
        //                        ordersList.Add(new Product(newOrder, newQuantity, newPrice));
        //                    }
        //                    Console.WriteLine("Reached");
        //                }
        //            }

        //        }
        //    }
        //    if (idError == true || productError == true)
        //    {
        //        updateCustomer = null;
        //    }
        //    else
        //    {
        //        if (customer != null)
        //        {

        //            updateCustomer = new Customer(customer.getCustomerName(), newId, ordersList, totalQuantity, totalBill, totalLeft);
        //        }

        //    }
        //    return updateCustomer;
        //}
        public static void SortCustomers()
        {
            CashierUI.Header();
            CashierUI.SubMenu("SORT CUSTOMERS BY THEIR ID");
            List<Customer> sortedList = CustomerDL.sortedCustomers();
            Console.WriteLine("{0, 0}{1, -20}{2, -20}{3, -20}{4, -20}", "", "CUSTOMER NAME", "CUSTOMER ID", "ORDER", "QUANTITY", "PRICE");
            foreach (Customer customer in sortedList)
            {
                Console.WriteLine(customer.toString());
            }
        }
        public static void viewOrder()
        {
            CashierUI.Header();
            CashierUI.SubMenu("VIEW ORDER");

            Console.WriteLine("\n\tORDER OF CUSTOMERS!!\n");
            Console.WriteLine("{0, 0}{1, -20}{2, -20}{3, -20}{4, -20}{5,-20}", "", "CUSTOMER NAME", "CUSTOMER ID", "ORDER", "QUANTITY", "PRICE");
            foreach (Customer customer in Cashier.customerList())
            {
                Console.WriteLine(customer.toString());
            }
        }
        public static void viewSearchedCustomer()
        {
            CashierUI.Header();
            CashierUI.SubMenu("SEARCH CUSTOMER");
            Customer customer = CustomerDL.FindCustomer();
            if (customer != null)
            {
                Console.WriteLine("{0, 0}{1, -20}{2, -20}{3, -20}{4, -20}{5,-20}", "", "CUSTOMER NAME", "CUSTOMER ID", "ORDER", "QUANTITY", "PRICE");
                Console.WriteLine(customer.toString());
            }
            else
            {
                CashierUI.employeeError();
            }
        }
        public static void PrintBill(string path)
        {
            CashierUI.Header();
            CashierUI.SubMenu("PRINT BILL");
            Customer customer = CustomerDL.FindCustomer();
            if (customer != null)
            {
                Console.WriteLine();
                Console.WriteLine($"     NAME:  {customer.getCustomerName()}");
                Console.WriteLine($"     ORDER:  {customer.getAllOrders()}");
                Console.WriteLine($"     QUANTITY:  {customer.getCustomerQuantity()}");
                Console.WriteLine("    __________________________________");
                Console.WriteLine($"    \nTOTAL BILL:  {customer.getCustomerBill()}PKR");
                Console.WriteLine("    __________________________________");
                Console.WriteLine("          THANKS FOR COMING !!!");
                Cashier.customerList().Remove(customer);
                CustomerDL.StoreCustomers(path, customer);
            }
            else
            {
                CashierUI.employeeError();
            }
        }

    }
}