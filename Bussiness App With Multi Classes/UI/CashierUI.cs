using System;
using rms.BL;
using rms.DL;
using RMS;

namespace rms.UI
{

    public class CashierUI
    {
        public static Cashier takeInputForCashier()
        {
            ManagerUI.Header();
            ManagerUI.SubMenu("Add Cashier");
            Cashier newCashier = new Cashier();
            bool idError = false;
            if (Manager.cashierList().Count < 10)
            {
                Console.Write("1.ENTER CASHIER NAME:  ");
                string name = MiscUI.NameValidation();
                Console.Write("2.ENTER CASHIER ID:  ");
                int id = MiscUI.ValidateInteger();
                Cashier employee = Manager.cashierList().Find(e => e.getCashierID() == id);
                if (employee != null)
                {
                    Console.WriteLine("\tSorry, Another Cashier with Same ID Already Exists");
                    idError = true;
                }
                else
                {
                    Console.Write("3.ENTER CASHIER SALARY: ");
                    int salary = MiscUI.ValidateInteger();
                    Console.Write("4.ENTER CASHIER PASSWORD: ");
                    string password = Console.ReadLine();
                    if (idError == false)
                    {
                        newCashier = new Cashier(name, id, salary, password);
                    }

                }

                if (idError == true)
                {
                    newCashier = null;
                }
            }
            else
            {
                Console.WriteLine("\tSorry, We Have Maximum Cashiers");
                newCashier = null;
            }
            return newCashier;

        }

        public static Cashier takeInputForExistingCashier()
        {
            Cashier updateCashier = new Cashier();
            bool idError = false;
            Console.Write("1.ENTER CASHIER NEW ID:  ");
            int id = MiscUI.ValidateInteger();
            Cashier employee = Manager.cashierList().Find(e => e.getCashierID() == id);
            if (employee != null)
            {
                Console.WriteLine("\n\tSorry, Another Cashier with Same ID Already Exists");
                idError = true;
            }
            else if (idError != true && employee == null)
            {
                string name = " ";
                Console.Write("2.ENTER CASHIER NEW SALARY: ");
                int salary = MiscUI.ValidateInteger();
                Console.Write("3.ENTER CASHIER NEW PASSWORD: ");
                string password = Console.ReadLine();
                updateCashier = new Cashier(name, id, salary, password);

            }
            if (idError == true)
            {

                updateCashier = null;

            }
            return updateCashier;
        }

        public static void viewSearchedCashier()
        {
            ManagerUI.Header();
            ManagerUI.SubMenu("FIND CASHIER");
            Cashier employee = CashierDL.FindCashier();
            Console.WriteLine("\n\tRESULTS FOR YOUR SEARCH ");
            if (employee != null)
            {
                Console.WriteLine("{0, 0}{1, -20}{2, -20}{3, -20}", "", "CASHIER NAME", "CASHIER ID", "CASHIER SALARY");
                Console.WriteLine(employee.toString());
            }
            else
            {
                Console.Write("\n\tCashier Not Found");
            }
        }

        // ****************** 3. VIEW RECORD OF ALL EMPLOYEES *******************

        public static void Record()
        {
            ManagerUI.Header();
            ManagerUI.SubMenu("RECORD OF CASHIERS");
            Console.WriteLine("{0, 0}{1, -20}{2, -20}{3, -20}", "", "CASHIER NAME", "CASHIER ID", "CASHIER SALARY");
            foreach (Cashier emp in Manager.cashierList())
            {
                Console.WriteLine(emp.toString());
            }
        }

        public static void employeeError()
        {
            Console.WriteLine("\n\tSorry, You Have Entered Wrong Id");

        }

        // ***************** CASHIER HEADER FUNCTION *******************

        public static void Header()
        {
            MiscUI.printHeader();
            Console.Write("\n");
            Console.WriteLine("           LOGGED IN AS CASHIER              ");
            Console.WriteLine("_____________________________________________");

        }


        // ***************** CASHIER SUBMENU FUNCTION *******************

        public static void SubMenu(string submenu)
        {

            string message = " \nCASHIER > " + submenu;
            Console.WriteLine(message);
            Console.WriteLine("_____________________________________________\n");
        }
        // ***************** 6. VIEW LEFT ITEMS IN STOCK FUNCTION *******************

        public static void viewLeftItems()
        {
            string leftPad = " ";
            CashierUI.Header();
            CashierUI.SubMenu("VIEW ITEMS LEFT IN STOCK");
            Console.WriteLine("ITEM NAME       PRICE              QUANTITY");

            foreach (Product product in Manager.productList())
            {
                Console.WriteLine($"{leftPad,0}{product.getItemName(),-16}{product.getItemPrice(),-23}" +
                                                  $"{product.getItemQuantity(),-10}");
            }
        }
        // ***************** 7. VIEW DAILY SALE RECORD *******************

        public static void dailySaleRecord()
        {
            int total = 0;
            CashierUI.Header();
            CashierUI.SubMenu("VIEW DAILY SALE RECORD");

            Console.WriteLine("\n\tDAILY SALE RECORD !!\n");

            Console.WriteLine("{0,0}{1,-20}{2,-20}", "", "ITEM NAME", "SOLD QUANTITY");

            foreach (Customer customer in Cashier.customerList())
            {
                Console.WriteLine("{0,0} {1,-20}{2,-20}", "", customer.getAllOrders(), customer.getCustomerQuantity());
                total = total + customer.getCustomerBill();
            }

            Console.WriteLine("\n---------------------------------------------------------");
            Console.WriteLine("         TOTAL DAILY SALE : {0:C}", total);
            Console.WriteLine("---------------------------------------------------------\n");
        }
        public static void FoodMenu()
        {
            Header();
            SubMenu("FOOD MENU");
            Console.WriteLine("\tFOOD MENU \n");

            Console.WriteLine("ITEM NAME        PRICE\n");

            foreach (Product product in Manager.productList())
            {
                Console.WriteLine("{0,0} {1,-12} {2,-21}", "", product.getItemName(), product.getItemPrice());
            }
        }



        public static int cashierMenu(MUser cashier)
        {
            int cashierOpt = 0;
            Console.Clear();
            MiscUI.printHeader();
            Console.WriteLine("\n\t***** WELCOME CASHIER ***** \n");
            Console.WriteLine(" _____________________________________________                 \n");
            Console.WriteLine("             LOGGED IN AS " + cashier.GetName());
            Console.WriteLine(" _____________________________________________                 \n");

            Console.WriteLine(" 1. FOOD MENU                  ");
            Console.WriteLine(" 2. ADD CUSTOMER               ");
            Console.WriteLine(" 3. VIEW CUSTOMER ORDER        ");
            Console.WriteLine(" 4. PRINT BILL                 ");
            Console.WriteLine(" 5. SORT CUSTOMERS BY THEIR ID ");
            Console.WriteLine(" 6. VIEW ITEMS LEFT IN STOCK   ");
            Console.WriteLine(" 7. DAILY SALE RECORD          ");
            Console.WriteLine(" 8. SEARCH CUSTOMER            ");
            Console.WriteLine(" 9. REMOVE CUSTOMER            ");
            Console.WriteLine("10. UPDATE CUSTOMER INFO       ");
            Console.WriteLine("11. LOG OUT                    ");
            Console.WriteLine("12. EXIT                       ");
            Console.Write("                  YOUR OPTION: ");
            cashierOpt = MiscUI.ValidateInteger();
            return cashierOpt;
        }
    }
}