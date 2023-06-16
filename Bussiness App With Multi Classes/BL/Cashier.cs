using rms.DL;
using rms.UI;
using RMS;

namespace rms.BL
{
    public class Cashier : Manager
    {
        private int cashierId = 0;
        private int cashierSalary = 0;

        public Cashier()
        {

        }
        public Cashier(string userName, int userId, int cashierSalary, string userPassword) : base(userName, userId, userPassword)
        {
            this.userName = userName;
            this.userId = userId;
            this.userPassword = userPassword;
            this.cashierSalary = cashierSalary;
        }
        public int getCashierID()
        {
            return this.cashierId;
        }
        public int getCashierSalary()
        {
            return this.cashierSalary;
        }
        public void setCashierSalary(int cashierSalary)
        {
            this.cashierSalary = cashierSalary;
        }

        private static List<Customer> customers = new List<Customer>();

        public static List<Customer> customerList()
        {
            return customers;
        }
        public static void addCustomer(Customer customer)
        {
            if (customer != null)
            {
                customers.Add(customer);
            }
            else
            {
                return;
            }
        }
        public static void CashierOperations(ref bool exit, MUser cashier)
        {
            while (true)
            {
                int opt = CashierUI.cashierMenu(cashier);
                Console.Clear();
                if (opt == 1)
                {
                    CashierUI.FoodMenu();
                }
                else if (opt == 2)
                {
                    Customer newCustomer = CustomerUI.takeInputForCustomer();
                    addCustomer(newCustomer);
                    if (newCustomer != null)
                    { CustomerDL.StoreCustomers(Program.path3, newCustomer); }
                    ProductsDL.storeStock(Program.path1);
                }
                else if (opt == 3)
                {
                    CustomerUI.viewOrder();
                }
                else if (opt == 4)
                {
                    CustomerUI.PrintBill(Program.path3);
                }
                else if (opt == 5)
                {
                    CustomerUI.SortCustomers();
                }
                else if (opt == 6)
                {
                    CashierUI.viewLeftItems();
                }
                else if (opt == 7)
                {
                    CashierUI.dailySaleRecord();
                }
                else if (opt == 8)
                {
                    CustomerUI.viewSearchedCustomer();
                }
                else if (opt == 9)
                {
                    CustomerDL.RemoveCustomer(Program.path3);

                }
                else if (opt == 10)
                {
                    CustomerDL.UpdateCustomerInfo(Program.path3);
                    ProductsDL.storeStock(Program.path1);
                }
                else if (opt == 11)
                {
                    break;
                }
                else if (opt == 12)
                {
                    exit = true;
                    break;
                }

                else
                {
                    Console.Write("\n\tSelect Valid option...");
                }
                MiscUI.Clear();
            }
        }

        public override string toString()
        {
            return $"{base.toString()}{GetId(),-20}{getCashierSalary(),-20}";
        }

    }
}