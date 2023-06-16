using System;
using rms.UI;
using rms.BL;
using RMS;

namespace rms.DL
{

    public class CashierDL
    {
        public static Cashier FindCashier()
        {

            Console.Write("1. ENTER CASHIER ID:  ");
            int id = MiscUI.ValidateInteger();
            Cashier employee = Manager.cashierList().FirstOrDefault(e => e.GetId() == id);
            return employee;
        }
        public static void FireCashier()
        {
            ManagerUI.Header();
            ManagerUI.SubMenu("FIRE EMPLOYEE");
            Cashier employee = FindCashier();
            if (employee != null)
            {
                Console.WriteLine("\n\tYOU HAVE FIRED " + employee.GetName());
                Manager.cashierList().Remove(employee);
            }
            else
            {
                CashierUI.employeeError();
            }
        }
        public static void UpdateInfo()
        {
            ManagerUI.Header();
            ManagerUI.SubMenu("UPDATE CASHIER INFO");
            Cashier employee = FindCashier();
            if (employee != null)
            {
                int index = Manager.cashierList().IndexOf(employee);
                Cashier updateCashier = CashierUI.takeInputForExistingCashier();
                if (updateCashier != null)
                {
                    string name = employee.GetName();
                    updateCashier.SetName(name);
                    Manager.cashierList().RemoveAt(index);
                    Manager.cashierList().Insert(index, updateCashier);
                }
            }
            else
            {
                return;
            }
        }

        public static void storeCashier(string path)
        {
            StreamWriter file = new StreamWriter(path);

            foreach (Cashier emp in Manager.cashierList())
            {
                file.WriteLine(emp.GetName() + "," + (emp.GetId()) + "," + (emp.getCashierSalary()) + "," + emp.GetPassword());
            }
            file.Close();

        }
        public static void loadCashier(string path)
        {

            string line;
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    string[] userFields = line.Split(',');
                    string name = userFields[0];
                    int id = int.Parse(userFields[1]);
                    int salary = int.Parse(userFields[2]);
                    string password = userFields[3];
                    Cashier employee = new Cashier(name, id, salary, password);
                    Manager.addCashier(employee);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("File Not Exists");
            }
        }

    }
}