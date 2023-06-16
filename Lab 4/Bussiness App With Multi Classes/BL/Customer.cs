
using System;
using System.IO;
using RMS;

namespace rms.BL
{
    public class Customer
    {
        public Customer()
        {
            customerName = "No Name";
            customerOrder = "No Order";
            customerId = 0;
            customerQuantity = 0;
            totalBill = 0;
            leftQuantity = 0;
        }
        public Customer(string name, string order, int id, int quantity, int bill, int left)
        {
            customerName = name;
            customerOrder = order;
            customerId = id;
            customerQuantity = quantity;
            totalBill = bill;
            leftQuantity = left;
        }
        public static void SortCustomers(List<Customer> customers)
        {
            Program.cashierHeader();
            Program.cashierSubMenu("SORT CUSTOMERS BY THEIR ID");

            Console.WriteLine("{0, -40}{1, -20}{2, -20}{3, -20}{4, -20}", "", "CUSTOMER NAME", "CUSTOMER ID", "ORDER", "QUANTITY", "PRICE");

            customers.Sort((x, y) => x.customerId.CompareTo(y.customerId));
            for (int i = 0; i < customers.Count; i++)
            {
                Console.WriteLine("{0, -40}{1, -20}{2, -20}{3, -20}{4, -20}", "", customers[i].customerName, customers[i].customerId, customers[i].customerOrder, customers[i].customerQuantity, customers[i].totalBill);
            }
        }
        // ***************** 6. VIEW LEFT ITEMS IN STOCK FUNCTION *******************

        public static void viewLeftItems(List<Product> products)
        {
            string leftPad = " ";
            Program.cashierHeader();
            Program.cashierSubMenu("VIEW ITEMS LEFT IN STOCK");
            Console.WriteLine("                                          ITEM NAME       PRICE              QUANTITY");

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{leftPad,-42}{products[i].foodName,-16}{products[i].foodPrice,-23}" +
                                                  $"{products[i].foodQuantity,-10}");
            }
        }

        // ***************** 7. VIEW DAILY SALE RECORD *******************

        public static void dailySaleRecord(List<Customer> customers)
        {
            int total = 0;
            Program.cashierHeader();
            Program.cashierSubMenu("VIEW DAILY SALE RECORD");

            Console.WriteLine("\n                                                       DAILY SALE RECORD !!                           \n");

            Console.WriteLine("{0,-45} {1,-20}", "ITEM NAME", "SOLD QUANTITY");

            for (int i = 0; i < customers.Count; i++)
            {
                Console.WriteLine("{0,-45} {1,-20}", customers[i].customerOrder, customers[i].customerQuantity);
                total = total + customers[i].totalBill;
            }

            Console.WriteLine("\n                                             ---------------------------------------------------------");
            Console.WriteLine("                                                      TOTAL DAILY SALE : {0:C}", total);
            Console.WriteLine("                                             ---------------------------------------------------------\n");
        }

        public static void SearchCustomer(List<Customer> customers)
        {
            Program.cashierHeader();
            Program.cashierSubMenu("SEARCH CUSTOMER");
            Console.Write("\t\t\t\t\t\t1. ENTER CUSTOMER ID (YOU WANT TO SEARCH): ");
            int id = Program.validateInteger();
            bool flag = false;

            Console.WriteLine("\t\t\t\t\t\t\t\nRESULTS FOR YOUR SEARCH\n");
            Customer customer = customers.Find(e => e.customerId == id);
            if (customer != null)
            {
                Console.WriteLine("\t\t\t\t\t\tCUSTOMER NAME\tCUSTOMER ID\tORDER\tQUANTITY");
                Console.WriteLine($"\t\t\t\t\t\t{customer.customerName}\t\t\t\t\t{customer.customerId}\t\t\t\t{customer.customerOrder}\t\t\t{customer.customerQuantity}");
                flag = true;

            }
            if (!flag)
            {
                Program.employeeError();
            }
        }
        public static void RemoveCustomer(string path3, List<Customer> customers)
        {
            Program.cashierHeader();
            Program.cashierSubMenu("REMOVE CUSTOMER");
            Console.Write("         1. ENTER CUSTOMER ID (YOU WANT TO REMOVE):  ");
            int id = Program.validateInteger();
            bool flag = false;

            for (int i = 0; i < customers.Count; i++)
            {
                if (id == customers[i].customerId)
                {
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\tYOU HAVE REMOVED " + customers[i].customerName);
                    customers.RemoveAt(i);
                    flag = true;
                    Program.countCustomers--;
                    Program.StoreCustomers(path3, customers);

                    break;
                }
                else
                {
                    flag = false;
                }
            }

            if (!flag)
            {
                Program.employeeError();
            }
        }
  public static void UpdateCustomerInfo(string path3, string path1, List<Product> products, List<Customer> customers)
{
    Program.cashierHeader();
    Program.cashierSubMenu("UPDATE CUSTOMER INFO");

    Console.Write("\t\t\t\t\t\tEnter ID of customer whose info you want to update: ");
    int id = Program.validateInteger();

    Customer customer = customers.FirstOrDefault(c => c.customerId == id);
    if (customer == null)
    {
        Program.employeeError();
        return;
    }

    Console.Write("\t\t\t\t\t\tEnter new ID: ");
    int newId = Program.validateInteger();
    if (customers.Any(c => c.customerId == newId))
    {
        Console.WriteLine("\t\t\t\t\tError: Customer ID already exists");
        return;
    }

    Console.Write("\t\t\t\t\t\tEnter new order: ");
    string newOrder = Console.ReadLine();

    Console.Write("\t\t\t\t\t\tEnter new quantity: ");
    int newQuantity = Program.validateInteger();

    Product product = products.FirstOrDefault(p => p.foodName == newOrder);
    if (product == null)
    {
        Console.WriteLine("\t\t\t\t\tError: Product not found");
        return;
    }

    if (product.foodQuantity < newQuantity)
    {
        Console.WriteLine("\t\t\t\t\tError: Not enough {0} in stock", newOrder);
        return;
    }

    product.foodQuantity -= newQuantity;
    int bill = product.foodPrice * newQuantity;
    int left = product.foodQuantity;

    customer.customerId = newId;
    customer.customerOrder = newOrder;
    customer.customerQuantity = newQuantity;
    customer.totalBill = bill;
    customer.leftQuantity = left;

    Console.WriteLine("\t\t\t\t\t{0} has been successfully allotted a new ID of {1} and his order is changed to {2} {3}", customer.customerName, customer.customerId, newQuantity, newOrder);

    Program.StoreCustomers(path3, customers);
    Program.storeStock(path1, products);
}

        public static void PrintBill(string path3, List<Customer> customers)
        {
            Program.cashierHeader();
            Program.cashierSubMenu("PRINT BILL");

            Console.Write("           	                           1. ENTER CUSTOMER ID (WHOSE BILL YOU WANT TO PRINT):  ");
            int id = int.Parse(Console.ReadLine());

            bool flag = true;

            for (int i = 0; i < customers.Count; i++)
            {
                if (id == customers[i].customerId)
                {
                    Console.WriteLine();
                    Console.WriteLine($"           	                                     NAME:  {customers[i].customerName}");
                    Console.WriteLine($"           	                                     ORDER:  {customers[i].customerOrder}");
                    Console.WriteLine($"           	                                     QUANTITY:  {customers[i].customerQuantity}");
                    Console.WriteLine("           	                                    __________________________________");
                    Console.WriteLine($"           	                                     TOTAL BILL:  {customers[i].totalBill}PKR");
                    Console.WriteLine("           	                                    __________________________________");
                    Console.WriteLine("           	                                          THANKS FOR COMING !!!");

                    customers.RemoveAt(i);

                    flag = true;
                    Program.countCustomers--;

                    Program.StoreCustomers(path3, customers);

                    break;
                }
                else
                {
                    flag = false;
                }
            }

            if (flag == false)
            {
                Console.WriteLine("           	               You Have Entered Wrong Customer ID!!!");
            }
        }

        public string customerName = "";
        public string customerOrder = "";
        public int customerId;
        public int customerQuantity;
        public int totalBill;
        public int leftQuantity;
    }
}