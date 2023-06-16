using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rms.DL;
using rms.UI;
using RMS;

namespace rms.BL
{
    public class Manager : MUser
    {
         private static List<Cashier> cashiers = new List<Cashier>();
                  private static List<Product> products = new List<Product>();

        public static List<Product> productList()
        {
            return products;
        }
        public static List<Cashier> cashierList()
        {
            return cashiers;
        }
        public static void addCashier(Cashier emp)
        {
            if (emp != null)
            {
                cashiers.Add(emp);
            }
            else
            {
                return;
            }
        }
        public static void addProduct(Product product)
        {
            if (product != null)
            {
                products.Add(product);
            }
            else
            {
                return;
            }
        }
        public Manager()
        {

        }
        public Manager(string username, string userPassword, string role) : base(username, userPassword, role)
        {
            this.userName = username;
            this.userPassword = userPassword;
            this.role = role;
        }
        public Manager(string username, int userId, string userPassword) : base(username, userId, userPassword)
        {
            this.userName = username;
            this.userId = userId;
            this.userPassword = userPassword;
        }
       
        public static void ManagerOperations(ref bool exit, MUser user)
        {
            while (true)
            {
                int opt = ManagerUI.managerMenu(user);
                Console.Clear();
                if (opt == 1)
                {
                    Product newProduct = ProductUI.takeInputForProduct();
                    Manager.addProduct(newProduct);
                    ProductsDL.storeStock(Program.path1);

                }
                else if (opt == 2)
                {
                    Cashier newCashier = CashierUI.takeInputForCashier();
                    addCashier(newCashier);
                    CashierDL.storeCashier(Program.path);
                }
                else if (opt == 3)
                {
                    CashierUI.Record();
                }
                else if (opt == 4)
                {
                    CashierUI.viewSearchedCashier();
                }
                else if (opt == 5)
                {
                    CashierDL.FireCashier();
                    CashierDL.storeCashier(Program.path);
                }
                else if (opt == 6)
                {
                    CashierDL.UpdateInfo();
                    CashierDL.storeCashier(Program.path);
                }
                else if (opt == 7)
                {
                    ProductUI.ViewStock();
                }
                else if (opt == 8)
                {
                    ProductUI.viewSortedList();
                }
                else if (opt == 9)
                {
                    ProductUI.viewSearchedProduct();
                }
                else if (opt == 10)
                {
                    ProductsDL.RemoveItem();
                    ProductsDL.storeStock(Program.path1);
                }
                else if (opt == 11)
                {
                    ProductsDL.UpdateStock();
                    ProductsDL.storeStock(Program.path1);
                }
                else if (opt == 12)
                {
                    break;
                }
                else if (opt == 13)
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
            return base.toString();
        }
    }
}