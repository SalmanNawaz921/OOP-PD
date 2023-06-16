using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RMS;
using rms.BL;

namespace rms.UI
{
    public class MUserUI
    {
        public static MUser takeInputForSignUP()
        {
            signUpMenu();
            Console.Write("Enter User Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter User ID: ");
            int id = MiscUI.ValidateInteger();
            Console.Write("Enter User Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter User Role: ");
            string role = Console.ReadLine();
            MUser newUser = new MUser(name, id, password, role);
            return newUser;
        }
        public static MUser takeInputForLogin()
        {
            loginMenu();
            Console.Write("Enter User Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter User Password: ");
            string password = Console.ReadLine();
            MUser existingUser = new MUser(name, password);
            return existingUser;
        }

        public static MUser loginUsingId()
        {
            loginMenu();
            Console.Write("Enter Your ID: ");
            int id = MiscUI.ValidateInteger();
            MUser existingUser = new MUser(id);
            return existingUser;
        }

        public static int LoginOptions()
        {
            Console.WriteLine(" 1. Login Using ID (For Cashier Only) ");
            Console.WriteLine(" 2. Login Using Credentials (Cashier/Manager) ");
            Console.Write("         Your Option:  ");
            int option = MiscUI.ValidateInteger();
            return option;
        }
        public static void signUpMenu()
        {
            Console.WriteLine("---------------------------                 ");
            Console.WriteLine("****** SIGN UP MENU *******     ");
            Console.WriteLine("---------------------------                  ");
        }
        public static void loginMenu()
        {
            Console.WriteLine("---------------------------                 ");
            Console.WriteLine(" ****** LOGIN MENU *******     ");
            Console.WriteLine("---------------------------                  ");
        }

    }
}