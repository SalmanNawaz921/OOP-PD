using System;
using System.IO;
using rms.BL;

namespace RMS
{
    public class Program
    {
        public static string name = "", role = "", password = "";
        public const int Max_Limit = 10;
        public static int countEmployee = 0;
        public static int countCustomers = 0;
        public static int countGoal = 0;
        public static int countFood = 0;
        public static int managerOpt = 0;
        public static int cashierOpt = 0;

        static void login()
        {
            Console.WriteLine("                                              ---------------------------                 ");
            Console.WriteLine("                                               ****** LOGIN MENU ******     ");
            Console.WriteLine("                                              ---------------------------                  ");
            Console.Write("\t\t\t\t\tEnter Your Name: ");
            name = Console.ReadLine();
            Console.Write("\t\t\t\t\tEnter Your Password: ");
            password = Console.ReadLine(); ;
            Console.Write("\t\t\t\t\tEnter Your Role: ");
            role = Console.ReadLine();
        }

        // ****************** LOGIN MENU FUNCTIONALITY *******************

        static string loginMenu(List<Employee> employees)
        {
            string valid = "";

            login();

            if (name == "Manager" && role == "MANAGER" && password == "manager921")
            {
                valid = role;
            }
            else if (name != "Manager")
            {
                for (int i = 0; i < countEmployee; i++)
                {
                    if (employees[i].employeeRole == "CASHIER" && role == "CASHIER" && name == employees[i].employeeName && password == employees[i].employeePassword)
                    {
                        valid = role;
                        break;
                    }
                }
            }
            else
            {
                valid = "Wrong";
            }

            return valid;
        }
      

        static int managerMenu(int managerOpt)
        {
            Console.Clear();
            // rmasHeader();
            Console.WriteLine("\t\t\t\t\t\t***** WELCOME MANAGER ***** ");
            Console.WriteLine("                                                   LOGGED IN AS MANAGER                                 ");
            Console.WriteLine("                                         _____________________________________________                 ")
                ;
            Console.WriteLine("                                                   1.ADD STOCK                                                           ");
            Console.WriteLine("                                                   2.ADD EMPLOYEES                                                       ");
            Console.WriteLine("                                                   3.RECORD OF EMPLOYEES                                                 ");
            Console.WriteLine("                                                   4.FIND EMPLOYEE                                                       ");
            Console.WriteLine("                                                   5.FIRE EMPLOYEE                                                       ");
            Console.WriteLine("                                                   6.UPDATE EMPLOYEE INFO                                                ");
            Console.WriteLine("                                                   7.VIEW STOCK                                                          ");
            Console.WriteLine("                                                   8.SORTED LIST OF PRICES                                               ");
            Console.WriteLine("                                                   9.SEARCH ITEM FROM STOCK                                             ");
            Console.WriteLine("                                                   10.REMOVE ITEM FROM STOCK                                             ");
            Console.WriteLine("                                                   11.UPDATE STOCK                                                       ");
            Console.WriteLine("                                                   12.LOG OUT                                                            ");
            Console.WriteLine("                                                   13.EXIT                                                               ");
            Console.WriteLine("                                                        YOUR OPTION: ");
            managerOpt = validateInteger();
            return managerOpt;
        }
        static int cashierMenu(int cashierOpt)
        {
            Console.Clear();
            // rmasHeader();
            Console.WriteLine("\t\t\t\t\t\t***** WELCOME CASHIER ***** \n");
            Console.WriteLine("                                                   LOGGED IN AS CASHIER                                 ");
            Console.WriteLine("                                         _____________________________________________                 \n");

            Console.WriteLine("                                                   1.FOOD MENU                                                           ");
            Console.WriteLine("                                                   2.ADD CUSTOMER                                                        ");
            Console.WriteLine("                                                   3.VIEW CUSTOMER ORDER                                                 ");
            Console.WriteLine("                                                   4.PRINT BILL                                                          ");
            Console.WriteLine("                                                   5.SORT CUSTOMERS BY THEIR ID                                          ");
            Console.WriteLine("                                                   6.VIEW ITEMS LEFT IN STOCK                                            ");
            Console.WriteLine("                                                   7.DAILY SALE RECORD                                                   ");
            Console.WriteLine("                                                   8.SEARCH CUSTOMER                                                     ");
            Console.WriteLine("                                                   9.REMOVE CUSTOMER                                                     ");
            Console.WriteLine("                                                   10.UPDATE CUSTOMER INFO                                               ");
            Console.WriteLine("                                                   11.LOG OUT                                                            ");
            Console.WriteLine("                                                   12.EXIT                                                               ");
            Console.Write("                                                        YOUR OPTION: ");
            cashierOpt = validateInteger();
            return cashierOpt;
        }

        static void Main(string[] args)
        {
            bool exit = false;
            string path = "D:\\OOP\\RMS\\RMS\\Employee.txt";
            string path1 = "D:\\OOP\\RMS\\RMS\\Stock.txt";
            string path3 = "D:\\OOP\\RMS\\RMS\\Customers.txt";
            List<Employee> employees = new List<Employee>();
            List<Product> products = new List<Product>();
            List<Customer> customers = new List<Customer>();
            loadEmployee(path, employees);
            loadStock(path1, products);
            LoadCustomers(path3, customers);
            string roleIt = " ";
            while (true)
            {
                roleIt = (loginMenu(employees));
                if (roleIt == "MANAGER")
                {
                    while (true)
                    {
                        int opt = managerMenu(managerOpt);
                        if (opt == 1)
                        {
                            addStock(path1, products);
                        }
                        else if (opt == 2)
                        {
                            addEmployee(path, employees);
                        }
                        else if (opt == 3)
                        {
                            Record(employees);
                        }
                        else if (opt == 4)
                        {
                            Employee.FindEmployee(employees);
                        }
                        else if (opt == 5)
                        {
                            Employee.FireEmployee(path, employees);
                        }
                        else if (opt == 6)
                        {
                            Employee.UpdateInfo(path, employees);
                        }
                        else if (opt == 7)
                        {
                            ViewStock(products);
                        }
                        else if (opt == 8)
                        {
                            Employee.sortedList(products);
                        }
                        else if (opt == 9)
                        {
                            Product.SearchItem(products);
                        }
                        else if (opt == 10)
                        {
                            Product.RemoveItem(path1, products);
                        }
                        else if (opt == 11)
                        {
                            Product.UpdateStock(path1, products);
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
                            Console.Write("\n\t\t\t\t\tSelect Valid option...");
                        }
                        Console.Write("\n\t\t\t\t\tPress Any Key...");
                        Console.ReadKey();
                    }
                    if (exit == true)
                    {
                        break;
                    }
                }
                else if (roleIt == "CASHIER")
                {
                    while (true)
                    {
                        int opt = cashierMenu(cashierOpt);
                        if (opt == 1)
                        {
                            FoodMenu(products);
                        }
                        else if (opt == 2)
                        {
                            addCustomer(path3, path1, customers, products);
                        }
                        else if (opt == 3)
                        {
                            viewOrder(customers);
                        }
                        else if (opt == 5)
                        {
                            Customer.SortCustomers(customers);
                        }
                        else if (opt == 6)
                        {
                            Customer.viewLeftItems(products);
                        }
                        else if (opt == 7)
                        {
                            Customer.dailySaleRecord(customers);
                        }
                        else if (opt == 8)
                        {
                            Customer.SearchCustomer(customers);
                        }
                        else if (opt == 9)
                        {
                            Customer.RemoveCustomer(path3, customers);
                        }
                        else if (opt == 10)
                        {
                            Customer.UpdateCustomerInfo(path3, path1, products, customers);
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
                            Console.Write("\n\t\t\t\t\tSelect Valid option...");
                        }
                        Console.Write("\n\t\t\t\t\tPress Any Key...");
                        Console.ReadKey();
                    }
                    if (exit == true)
                    {
                        break;
                    }
                }

            }
        }
          static void addEmployee(string path, List<Employee> employees)
        {
            managerHeader();
            managerSubMenu("ADD EMPLOYEE");
            bool invalid = false;
            bool idError = false;
            bool roleError = false;
            if (employees.Count < 10)
            {
                Console.Write("                                       1.ENTER EMPLOYEE NAME:  ");
                string name = Console.ReadLine();
                invalid = employeeNameValidation(employees);
                if (invalid == true)
                {
                    Console.WriteLine("\t\t\t\t\tEMPLOYEE NAME SHOULD ONLY CONTAIN LETTERS");
                }
                if (invalid == false)
                {
                    Console.Write("                                        2.ENTER EMPLOYEE ID:  ");
                    int id = validateInteger();
                    Console.Write("                                       3.ENTER EMPLOYEE SALARY: ");
                    int salary = validateInteger();
                    Console.Write("                                        4.ENTER EMPLOYEE ROLE(CASHIER OR WAITER): ");
                    string role = (Console.ReadLine());
                    roleError = employeeRoleValidation(employees);
                    if (roleError == true)
                    {
                        Console.WriteLine("                                          YOU HAVE ENTERED WRONG ROLE!!! ");
                        idError = false;
                    }
                    if (roleError == false)
                    {
                        Console.Write("                                        4.ENTER EMPLOYEE PASSWORD: ");
                        string password = Console.ReadLine();
                        Employee employee = employees.Find(e => e.employeeId ==id);
                        if (employee != null)
                        {
                            Console.WriteLine("\t\t\t\t\tSorry, Another Employee with Same ID Already Exists");
                            idError = true;
                        }
                        else
                        {
                            if (idError == false && invalid == false)
                            {
                                countEmployee++;
                                Employee newEmployee = new Employee(name,id,salary,role,password);
                                employees.Add(newEmployee);
                                storeEmployee(path, employees);
                            }
                        }
                    }
                }
            }

            else
            {
                Console.WriteLine("\t\t\t\t\tSorry, We Have Maximum Employees");
            }
        }

        public static void storeEmployee(string path, List<Employee> employees)
        {
            StreamWriter file = new StreamWriter(path);

            for (int i = 0; i < employees.Count; i++)
            {
                file.WriteLine(employees[i].employeeName + "," + (employees[i].employeeId) + "," + (employees[i].employeeSalary) + "," + employees[i].employeeRole + "," + employees[i].employeePassword);
            }
            file.Close();
        }
        static void loadEmployee(string path, List<Employee> employees)
        {

            string line;
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    Employee employee = new Employee();
                    employee.employeeName = parseData(line, 1);
                    employee.employeeId = int.Parse(parseData(line, 2));
                    employee.employeeSalary = int.Parse(parseData(line, 3));
                    employee.employeeRole = parseData(line, 4);
                    employee.employeePassword = parseData(line, 5);
                    countEmployee++;
                    employees.Add(employee);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("File Not Exists");
            }
        }

        static void addStock(string path1, List<Product> products)
        {
            managerHeader();
            managerSubMenu("ADD STOCK");
            bool nameError = false;
            bool invalid = false;
            if (products.Count < 10)
            {
                Console.Write("           	                        1. ENTER FOOD ITEM NAME:  ");
                string name = Console.ReadLine();
                invalid = itemNameValidation(products);
                if (invalid == true)
                {
                    Console.WriteLine("\t\t\t\t\tItem Name Should Only Contain Letters");

                    nameError = false;
                }
                if (invalid == false)
                {
                    Console.Write("           	                        2. ENTER FOOD ITEM PRICE: ");
                    int price = validateInteger();
                    Console.Write("           	                        3. ENTER FOOD ITEM QUANTITY: ");
                    int quantity = validateInteger();
            Product product = products.Find(e => e.foodName == name);
                   if(product!=null)
                         {   Console.WriteLine("\t\t\t\t\tSorry, Another Food Item With Same Name Exists");}

                            else
                      
                   { if (nameError == false && invalid == false)
                    {
                        countFood++;
                Product newProduct = new Product(name,price,quantity);
                        products.Add(newProduct);
                        storeStock(path1, products);
                    }
                }}
            }
            else
            {
                Console.WriteLine("\t\t\t\t\tSorry, We Have Maximum Food Items");

            }
        }
        static void loadStock(string path1, List<Product> products)
        {
            string line;
            if (File.Exists(path1))
            {
                StreamReader file = new StreamReader(path1);
                while ((line = file.ReadLine()) != null)
                {
                    Product product = new Product();
                    product.foodName = parseData(line, 1);
                    product.foodPrice = int.Parse(parseData(line, 2));
                    product.foodQuantity = int.Parse(parseData(line, 3));
                    countFood++;
                    products.Add(product);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("Path Not Found");
            }
        }

        //****************** STORE STOCK *****************

        public static void storeStock(string path1, List<Product> products)
        {
            StreamWriter file = new StreamWriter(path1);
            for (int i = 0; i < products.Count; i++)
            {
                file.WriteLine(products[i].foodName + "," + products[i].foodPrice + "," + products[i].foodQuantity);
            }
            file.Close();
        }
        // ****************** 3. VIEW RECORD OF ALL EMPLOYEES *******************

        static void Record(List<Employee> employees)
        {
            managerHeader();
            managerSubMenu("RECORD OF EMPLOYEES");
            string leftPad = " ";
            Console.WriteLine("                                    EMPLOYEE NAME      " +
                              "   EMPLOYEE SALARY" +
                              "     EMPLOYEE ID" +
                              "     EMPLOYEE ROLE");

            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine($"{leftPad,-37}{employees[i].employeeName,-25}{employees[i].employeeSalary,-20}" +
                                  $"{employees[i].employeeId,-15}{employees[i].employeeRole,-15}");
            }
        }


        static void ViewStock(List<Product> products)
        {
            string leftPad = " ";
            managerHeader();
            managerSubMenu("VIEW STOCK");
            Console.WriteLine("                                                        STOCK OF ITEMS\n");
            Console.WriteLine("                                          ITEM NAME              PRICE               QUANTITY");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{leftPad,-42}{products[i].foodName,-24}{products[i].foodPrice,-22}" +
                                  $"{products[i].foodQuantity,-20}");
            }
        }

       

        static void FoodMenu(List<Product> products)
        {
            cashierHeader();
            cashierSubMenu("FOOD MENU");
            Console.WriteLine("                                                        FOOD MENU \n");

            Console.WriteLine("                                                   ITEM NAME        PRICE\n");

            for (int i = 0; i < countFood; i++)
            {
                Console.WriteLine("{0,-52} {1,-12} {2,-21}", "", products[i].foodName, products[i].foodPrice);
            }
        }

static void addCustomer(string path3, string path1, List<Customer> customers, List<Product> products)
{
    cashierHeader();
    cashierSubMenu("ADD CUSTOMER");
    bool idError = false;
    bool nameError = false;
    bool invalid;
    int bill = 0, left = 0;

    if (customers.Count < 10)
    {
        Console.Write("                                            1. ENTER CUSTOMER NAME:  ");
        string name = Console.ReadLine();
        invalid = customerNameValidation(customers);
        if (invalid == true)
        {
            Console.WriteLine("\n\t\t\t\t\t\t\t\tCUSTOMER NAME SHOULD ONLY CONTAIN LETTERS");
            nameError = true; // Set nameError to true when there is an invalid customer name
        }
        if (invalid == false)
        {
            Console.Write("                                            2. ENTER CUSTOMER ID: ");
            int id = validateInteger();

            if (customers.Exists(c => c.customerId == id))
            {
                Console.WriteLine("\n\t\t\t\t\t\t\t\tSorry, Another Customer With Same ID Already Exists");
                idError = true; // Set idError to true when there is a duplicate customer ID
            }

            Console.Write("                                            3. ADD CUSTOMER ORDER: ");
            string order = Console.ReadLine();
            Console.Write("                                            4. ADD QUANTITY OF ORDER: ");
            int quantity = validateInteger();

            if (!idError)
            {
                var product = products.FirstOrDefault(p => p.foodName == order);
                if (product == null)
                {
                    Console.WriteLine("\n\t\t\t\t\t\t\t\tError: " + order + " not found");
                    nameError = true; // Set nameError to true when there is a product not found error
                }
                else if (product.foodQuantity < quantity)
                {
                    Console.WriteLine("\n\t\t\t\t\t\t\t\tError: Not enough " + order + " in stock");
                    nameError = true; // Set nameError to true when there is a product out of stock error
                }
                else
                {
                    bill = product.foodPrice * quantity;
                    product.foodQuantity -= quantity;
                    left = product.foodQuantity;
                }
            }

            if (!idError && !nameError) // Only add the new customer if there is no error
            {
                countCustomers++;
                Customer newCustomer = new Customer(name, order, id, quantity, bill, left);
                customers.Add(newCustomer);
                StoreCustomers(path3, customers);
            }
        }
    }
    else
    {
        Console.WriteLine("\n\t\t\t\t\t\t\t\tSorry, We Have Maximum Customers");
    }
    storeStock(path1, products);
}


        /****************** LOAD CUSTOMERS *****************/
        public static void LoadCustomers(string path3, List<Customer> customers)
        {
            StreamReader file = new StreamReader(path3);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                Customer customer = new Customer();
                customer.customerName = parseData(line, 1);
                customer.customerOrder = parseData(line, 2);
                customer.customerId = int.Parse(parseData(line, 3));
                customer.customerQuantity = int.Parse(parseData(line, 4));
                customer.totalBill = int.Parse(parseData(line, 5));
                customers.Add(customer);
                countCustomers++;
            }
            file.Close();
        }

        /****************** STORE CUSTOMERS *****************/
        public static void StoreCustomers(string path3, List<Customer> customers)
        {
            StreamWriter file = new StreamWriter(path3);
            for (int i = 0; i < countCustomers; i++)
            {
                file.Write(customers[i].customerName + ",");
                file.Write(customers[i].customerOrder + ",");
                file.Write(customers[i].customerId + ",");
                file.Write(customers[i].customerQuantity + ",");
                file.Write(customers[i].totalBill + "\n");
            }
            file.Close();
        }
        static void viewOrder(List<Customer> customers)
        {
            cashierHeader();
            cashierSubMenu("VIEW ORDER");

            Console.WriteLine("                                                             ORDER OF CUSTOMERS!!                           ");
            Console.WriteLine();
            Console.WriteLine("                      \t\tCUSTOMER NAME\tCUSTOMER ID\tORDER\tQUANTITY\tPRICE");

            for (int i = 0; i < customers.Count; i++)
            {
                Console.WriteLine("{0,35}{1,-18}{2,-11}{3,-10}{4,-14}{5,-5}", "", customers[i].customerName, customers[i].customerId, customers[i].customerOrder, customers[i].customerQuantity, customers[i].totalBill);
            }
        }

        public static void managerHeader()
        {
            Console.Clear();
            Console.Write("\n");
            Console.WriteLine("                                                    LOGGED IN AS MANAGER                                ");
            Console.WriteLine("                                         _____________________________________________                   ");

        }

        // ***************** CASHIER HEADER FUNCTION *******************

        public static void cashierHeader()
        {
            Console.Clear();
            Console.Write("\n");
            Console.WriteLine("                                                    LOGGED IN AS CASHIER                                 ");
            Console.WriteLine("                                         _____________________________________________                   ");

        }

        // ***************** MANAGER SUBMENU FUNCTION *******************

        public static void managerSubMenu(string submenu)
        {

            string message = "                                          MANAGER > " + submenu;
            Console.WriteLine(message);
            Console.WriteLine("                                         _____________________________________________                  \n");
        }

        // ***************** CASHIER SUBMENU FUNCTION *******************

        public static void cashierSubMenu(string submenu)
        {

            string message = "                                          CASHIER > " + submenu;
            Console.WriteLine(message);
            Console.WriteLine("                                         _____________________________________________                  \n");
        }

        // ***************** ITEM ERROR FUNCTION *******************

        public static void itemError()
        {
            Console.WriteLine("\t\t\t\t\tSorry, Item Does Not Exist");
        }

        // ***************** EMPLOYEE ERROR FUNCTION *******************-

        public static void employeeError()
        {
            Console.WriteLine("\t\t\t\t\tSorry, You Have Entered Wrong Id");

        }

        // Validations

        public static bool itemNameValidation(List<Product> products)
        {
            bool invalid = false;
            if (countFood < products.Count)
            {
                for (int i = 0; i < products[countFood].foodName.Length; i++)
                {
                    if (!Char.IsLetter((products[countFood].foodName[i])) && products[countFood].foodName[i] != ' ')
                    {
                        invalid = true;
                        break;
                    }
                }
            }
            return invalid;
        }

        // For Emlpuyee

        public static bool employeeNameValidation(List<Employee> employees)
        {
            bool invalid = false;

            if (countEmployee < employees.Count)
            {
                for (int i = 0; i < employees[countEmployee].employeeName.Length; i++)
                {
                    if (!Char.IsLetter((employees[countEmployee].employeeName[i])) && employees[countEmployee].employeeName[i] != ' ')
                    {
                        invalid = true;
                        break;
                    }
                }
            }

            return invalid;
        }
        public static bool employeeRoleValidation(List<Employee> employees)
        {
            bool roleError = true;

            if (employees[employees.Count - 1].employeeRole == "CASHIER" || employees[employees.Count - 1].employeeRole == "WAITER")
            {
                roleError = false;
            }

            return roleError;
        }

        // For Customers
        static bool customerNameValidation(List<Customer> customers)
        {
            bool invalid = false;
            if (countCustomers < customers.Count)
            {
                for (int i = 0; i < customers[countCustomers].customerName.Length; i++)
                {
                    if (!Char.IsLetter((customers[countCustomers].customerName[i])) && customers[countCustomers].customerName[i] != ' ')
                    {
                        invalid = true;
                        break;
                    }
                }
            }
            return invalid;
        }
                static string parseData(string line, int field)
        {
            int commaCount = 1;
            string data = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ',')
                {
                    commaCount++;
                }
                else if (commaCount == field)
                {
                    data = data + line[i];
                }
            }
            return data;
        }
        public static int validateInteger()
        {
            string id = " ";
            char c;
            bool isValid = false;
            while (!isValid)
            {
                bool isNumeric = true;

                id = Console.ReadLine();
                for (int i = 0; i < id.Length; i++)
                {
                    c = id[i];
                    if (c >= 48 && c <= 57)
                    {
                        isNumeric = true;
                    }
                    else
                    {
                        isNumeric = false;
                        break;
                    }
                }
                if (isNumeric)
                {

                    isValid = true;
                    return int.Parse(id);
                }
                else
                {
                    Console.Write("                                              ENTER VALID INPUT: ");
                    isValid = false;


                }
            }
            return 0;
        }

    }
}