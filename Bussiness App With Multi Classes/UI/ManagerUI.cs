
using System;
using rms.BL;
using RMS;

namespace rms.UI
{

    class ManagerUI
    {
        public static void Header()
        {
            MiscUI.printHeader();
            Console.Write("\n");
            Console.WriteLine("           LOGGED IN AS MANAGER              ");
            Console.WriteLine("_____________________________________________");

        }

        // ***************** MANAGER SUBMENU FUNCTION *******************

        public static void SubMenu(string submenu)
        {

            string message = " \nMANAGER > " + submenu;
            Console.WriteLine(message);
            Console.WriteLine("_____________________________________________\n");
        }


        public static int managerMenu(MUser manager)
        {
            int managerOpt = 0;
            Console.Clear();
            MiscUI.printHeader();
            Console.WriteLine("\t***** WELCOME MANAGER ***** ");
            Console.WriteLine("_______________________q______________________\n");
            Console.WriteLine("          LOGGED IN AS " + manager.GetName());
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("1. ADD STOCK                                                           ");
            Console.WriteLine("2. ADD CASHIER                                                        ");
            Console.WriteLine("3. RECORD OF CASHIERS                                                 ");
            Console.WriteLine("4. FIND CASHIER                                                       ");
            Console.WriteLine("5. FIRE CASHIER                                                       ");
            Console.WriteLine("6. UPDATE CASHIER INFO                                                ");
            Console.WriteLine("7. VIEW STOCK                                                          ");
            Console.WriteLine("8. SORTED LIST OF PRICES                                               ");
            Console.WriteLine("9. SEARCH ITEM FROM STOCK                                              ");
            Console.WriteLine("10. REMOVE ITEM FROM STOCK                                             ");
            Console.WriteLine("11. UPDATE STOCK                                                       ");
            Console.WriteLine("12. LOG OUT                                                            ");
            Console.WriteLine("13. EXIT                                                               ");
            Console.Write("     YOUR OPTION: ");
            managerOpt = MiscUI.ValidateInteger();
            return managerOpt;
        }
    }
}