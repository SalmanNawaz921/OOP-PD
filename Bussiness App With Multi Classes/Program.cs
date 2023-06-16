using System;
using System.IO;
using rms.BL;
using rms.DL;
using rms.UI;

namespace RMS
{
    public class Program
    {
        public static string path3 = "Customers.txt";
        public static string path = "Cashiers.txt";
        public static string path1 = "Stock.txt";
        public static string path4 = "Users.txt";

        public static int printMenU()
        {
            MiscUI.printHeader();
            Console.WriteLine("---------------------------                 ");
            Console.WriteLine(" ****** MAIN  MENU ******     ");
            Console.WriteLine("---------------------------                  ");
            Console.WriteLine(" 1.Sign Up ");
            Console.WriteLine(" 2.Sign In ");
            Console.WriteLine(" 3.Exit ");
            Console.Write("\tYour Option: ");
            int option = MiscUI.ValidateInteger();
            return option;

        }

        static void Main(string[] args)
        {
            bool exit = false;

            CashierDL.loadCashier(path);
            ProductsDL.loadStock(path1);
            CustomerDL.LoadCustomers(path3);
            MUserDL.loadUser(path4);
            string roleIt = " ";
            while (true)
            {
                int choice = printMenU();
                Console.Clear();
                MiscUI.printHeader();
                if (choice == 1)
                {
                    MUser newUser = MUserUI.takeInputForSignUP();
                    MUserDL.addUser(newUser, path4);
                }
                else if (choice == 2)
                {
                    int opt = MUserUI.LoginOptions();
                    Console.Clear();
                    MiscUI.printHeader();
                    if (opt == 1)
                    {
                        MUser existingUser = MUserUI.loginUsingId();
                        roleIt = MUser.validUser(existingUser);
                        if (roleIt == "CASHIER")
                        {
                            Cashier.CashierOperations(ref exit, existingUser);
                        }
                    }
                    else if (opt == 2)
                    {
                        MUser existingUser = MUserUI.takeInputForLogin();
                        roleIt = MUser.validUser(existingUser);
                        if (roleIt == "MANAGER")
                        {
                            Manager.ManagerOperations(ref exit, existingUser);
                        }
                        else if (roleIt == "CASHIER")
                        {
                            Cashier.CashierOperations(ref exit, existingUser);
                        }
                        else
                        {
                            Console.WriteLine("\n\t" + roleIt);
                        }
                    }
                    else
                    {
                        exit = true;
                        ;
                    }
                }
                else
                {
                    exit = true;
                    break;
                }
                MiscUI.Clear();
                if (exit == true)
                {
                    break;
                }
            }
        }

    }
}