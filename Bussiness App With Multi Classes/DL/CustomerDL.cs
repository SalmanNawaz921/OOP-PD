using rms.BL;
using rms.UI;

namespace rms.DL
{
    public class CustomerDL
    {
        private static List<Customer> sortedCustomersList = new List<Customer>();

        public static List<Customer> getSortedListt()
        {

            return sortedCustomersList;

        }

        public static Customer FindCustomer()
        {
            Console.Write("1. ENTER CUSTOMER ID:  ");
            int id = MiscUI.ValidateInteger();
            Customer customer = Cashier.customerList().FirstOrDefault(e => e.getCustomerID() == id);
            return customer;
        }
        public static void RemoveCustomer(string path)
        {
            CashierUI.Header();
            CashierUI.SubMenu("REMOVE CUSTOMER");
            Customer customer = FindCustomer();
            if (customer != null)
            {
                Console.WriteLine("\n\tYOU HAVE REMOVED " + customer.getCustomerName());
                Cashier.customerList().Remove(customer);
                StoreCustomers(path, customer);
            }
            else
            {
                CashierUI.employeeError();
            }
        }
        public static void UpdateCustomerInfo(string path)
        {
            CashierUI.Header();
            CashierUI.SubMenu("UPDATE CUSTOMER");
            Customer customer = FindCustomer();

            if (customer != null)
            {
                Customer updateCustomer = CustomerUI.takeInputForExistingCustomer();

                int index = Cashier.customerList().IndexOf(customer);
                if (updateCustomer != null)
                {
                    string customerName = customer.getCustomerName();
                    updateCustomer.setCustomerName(customerName);
                    // Update the customer's order without modifying the product quantities
                    foreach (Product order in customer.getOrderList())
                    {
                        foreach (Product item in Manager.productList())
                        {
                            if (item.getItemName() == order.getItemName())
                            {
                                int originalQuantity = item.getItemQuantity() + order.getItemQuantity();
                                item.setItemQuantity(originalQuantity);
                                originalQuantity = 0;
                            }
                        }
                    }

                    Console.WriteLine("\t Updated Customer Info \n");
                    Console.WriteLine("{0, 0}{1, -20}{2, -20}{3, -20}{4, -20}", "", "CUSTOMER NAME", "CUSTOMER ID", "ORDER", "QUANTITY", "PRICE");
                    Cashier.customerList().RemoveAt(index);
                    Cashier.customerList().Insert(index, updateCustomer);
                    StoreCustomers(path, updateCustomer);
                    Console.WriteLine(updateCustomer.toString());
                }
                else
                {
                    updateCustomer = customer;
                }
            }
            else
            {
                CashierUI.employeeError();
            }
        }

        public static List<Customer> sortedCustomers()
        {
            sortedCustomersList = Cashier.customerList().OrderBy(o => o.getCustomerID()).ToList();
            return sortedCustomersList;
        }
        /****************** LOAD CUSTOMERS *****************/
        public static void LoadCustomers(string path)
        {
            StreamReader file = new StreamReader(path);
            string line;
            while ((line = file.ReadLine()) != null)
            {

                string[] usersField = line.Split(',');
                string name = usersField[0];
                int id = int.Parse(usersField[1]);
                string[] orderNames = usersField[2].Split(';');
                List<Product> orders = new List<Product>();
                for (int i = 0; i < orderNames.Length; i++)
                {
                    string orderName = orderNames[i];
                    Product item = Manager.productList().Find(e => e.getItemName() == orderName);
                    if (item != null)
                    {
                        if (!(orders.Contains(item)))
                        {
                            orders.Add(item);
                        }
                    }
                }
                int quantity = int.Parse(usersField[3]);
                int bill = int.Parse(usersField[4]);
                Customer customer = new Customer(name, id, orders, quantity, bill);
                Cashier.customerList().Add(customer);
            }
            file.Close();
        }

        /****************** STORE CUSTOMERS *****************/
        public static void StoreCustomers(string path, Customer customer)
        {
            StreamWriter file = new StreamWriter(path, true);
            string orderNames = "";

            if (customer.getOrderList() != null || customer != null)
            {
                for (int x = 0; x < customer.getOrderList().Count; x++)
                {

                    if (x == customer.getOrderList().Count - 1)
                    {
                        orderNames += customer.getOrderList()[x].getItemName();
                    }
                    else
                    {
                        orderNames += customer.getOrderList()[x].getItemName() + ";";
                    }

                }
                file.Write(customer.getCustomerName() + ",");
                file.Write(customer.getCustomerID() + ",");
                file.Write(orderNames + ",");
                file.Write(customer.getCustomerQuantity() + ",");
                file.Write(customer.getCustomerBill() + "\n");
            }

            file.AutoFlush = true;
            file.Close();
        }
    }
}