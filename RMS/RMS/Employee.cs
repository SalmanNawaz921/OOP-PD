using System;
using System.IO;

namespace RMS
{
    public class Employee
    {
        public Employee()
        {
            employeeName = "No Name";
            employeeId = 0;
            employeeSalary = 0;
            employeeRole = "No Role";
            employeePassword = "No Password";
        }
        public Employee(string name, int id, int salary, string role, string password)
        {
            employeeName = name;
            employeeId = id;
            employeeSalary = salary;
            employeeRole = role;
            employeePassword = password;
        }
        public static void FireEmployee(string path, List<Employee> employees)
        {
            Program.managerHeader();
            Program.managerSubMenu("FIRE EMPLOYEE");

            Console.Write("                                         1. ENTER EMPLOYEE ID (YOU WANT TO REMOVE):  ");
            int id = Program.validateInteger();

            bool flag = false;

            for (int i = 0; i < employees.Count; i++)
            {
                if (id == employees[i].employeeId)
                {
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\tYOU HAVE FIRED " + employees[i].employeeName);
                    employees.RemoveAt(i);
                    flag = true;
                    Program.countEmployee--;
                    Program.storeEmployee(path, employees);
                    break;
                }
                else
                {
                    flag = false;
                }
            }

            if (flag == false)
            {
                Program.employeeError();
            }
        }

        // ****************** 4. FIND EMPLOYEE FUNCTION *******************
        public static void FindEmployee(List<Employee> employees)
        {
            Program.managerHeader();
            Program.managerSubMenu("FIND EMPLOYEE");

            Console.Write("                                       1. ENTER EMPLOYEE ID (YOU WANT TO SEARCH):  ");
            int id = Program.validateInteger();
            Console.WriteLine();
            Console.WriteLine("                                                   RESULTS FOR YOUR SEARCH ");

            bool flag = true;

            Employee employee = employees.Find(e => e.employeeId == id);

            if (employee != null)
            {
                Console.Write("                      \t\tEMPLOYEE NAME     EMPLOYEE ID      EMPLOYEE SALARY     EMPLOYEE ROLE\n");
                Console.Write("                      \t\t");
                Console.WriteLine(employee.employeeName + "              " + employee.employeeId + "                  " + employee.employeeSalary + "                " + employee.employeeRole + " ");
                return;
            }
            else
            {
                flag = false;
            }


            if (flag == false)
            {
                Program.employeeError();
            }
        }
        public static void UpdateInfo(string path, List<Employee> employees)
        {
            Program.managerHeader();
            Program.managerSubMenu("UPDATE EMPLOYEE INFO");
            Console.Write("                                       1. ENTER ID OF EMPLOYEE (WHOSE INFO YOU WANT TO UPDATE):  ");
            int id = Program.validateInteger();
            bool roleError;
            bool flag = true;
            bool idError = false;
            for (int i = 0; i < employees.Count; i++)
            {
                if (id == employees[i].employeeId)
                {

                    int id1;
                    Console.Write("                                       2. ENTER EMPLOYEE'S NEW ID :  ");
                    id1 = Program.validateInteger();
                    for (int idx = 0; idx < employees.Count; idx++)
                    {
                        if (id1 == employees[idx].employeeId)
                        {
                            idError = true;
                            flag = true;
                            Console.WriteLine("\n\t\t\t\t\t\tEmployee ID Already Exists!!!");
                            break;
                        }
                    }
                    if (idError == false)
                    {
                        string name = employees[i].employeeName;
                        int empId = id1;
                        Console.Write("                                       3. ENTER EMPLOYEE'S NEW SALARY  :  ");
                        int salary = Program.validateInteger();
                        Console.Write("                                       3. ENTER EMPLOYEE'S NEW ROLE  :  ");
                        string role = Console.ReadLine();
                        roleError = Program.employeeRoleValidation(employees);
                        flag = true;
                        if (roleError == false)
                        {
                            Console.Write("                                       3. ENTER EMPLOYEE'S NEW PASSWORD  :  ");
                            string password = Console.ReadLine();
                            Console.WriteLine("\n                          {0} HAS BEEN SUCCESSFULLY ALLOTED A NEW ID OF {1} & HIS ROLE IS CHANGED TO {2} & HIS SALARY IS UPDATED TO {3}", employees[i].employeeName, employees[i].employeeId, employees[i].employeeRole, employees[i].employeeSalary);
                            flag = true;
                            employees.RemoveAt(i);
                            Employee updateEmployee = new Employee(name,empId,salary,role,password);
                            employees.Insert(i, updateEmployee);
                            break;
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                }

                if (flag == false && idError == false)
                {
                    Program.employeeError();
                }
            }

            Program.storeEmployee(path, employees);
        }
        public static void sortedList(List<Product> products)
        {
            string leftPad = " ";
            Program.managerHeader();
            Program.managerSubMenu("SORTED LIST OF ITEMS");
            Console.WriteLine("                                              FOOD ITEMS FROM PRICE LOW TO HIGH  \n");
            products.Sort((x, y) => x.foodPrice.CompareTo(y.foodPrice));
            Console.WriteLine("                                          ITEM NAME        PRICE            QUANTITY");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{leftPad,-42}{products[i].foodName,-24}{products[i].foodPrice,-22}" +
                                                 $"{products[i].foodQuantity,-20}");
            }
        }
        public string employeeName = "";
        public int employeeId = 0;
        public int employeeSalary = 0;
        public string employeeRole = "";
        public string employeePassword = "";
    }
}