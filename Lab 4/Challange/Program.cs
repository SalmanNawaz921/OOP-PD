using System;

namespace Test
{

    class Program
    {
        static void Main(string[] args)
        {
            List<Ship> ships = new List<Ship>();
            int option = 0;
            do
            {
                Console.Clear();
                option = menu();
                if (option == 1)
                {
                    ships.Add(Add_Ship());
                }
                else if (option == 2)
                {
                    Console.Write("Enter Ship Serial No: ");
                    string serial = (Console.ReadLine());
                    Ship findShip = ships.Find(e => e.serialNo == serial);
                    if (findShip != null)
                    {
                        findShip.Ship_Position();
                    }
                    Console.ReadKey();
                }
                else if (option == 3)
                {
                    Console.Write("Enter Ship Latitude: ");
                    string shipLatitude = (Console.ReadLine());
                    Ship findLatitude = ships.Find(e => e.latitude.Display_Angle() == shipLatitude);
                    if (findLatitude != null)
                    {
                        Console.Write("Enter Ship Longitude: ");
                        string shipLongitude = (Console.ReadLine());
                        Ship findLongitude = ships.Find(e => e.longitude.Display_Angle() == shipLongitude);
                        if (findLongitude != null)
                        {
                            findLongitude.Ship_Serial();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Ship Not Found");
                        }

                    }
                    else
                    {

                        Console.WriteLine("Ship Not Found");
                    }
                }
                else if (option == 4)
                {
                    Console.Write("Enter Ship Serial No: ");
                    string serial = (Console.ReadLine());
                    Ship findShip = ships.Find(e => e.serialNo == serial);
                    if (findShip != null)
                    {
                        int index = ships.IndexOf(findShip);
                        ships.Insert(index, updateShip(serial));
                    }
                }
                else
                {
                    break;
                }
                Console.WriteLine("Press Enter To Continue");
                Console.ReadKey();
            } while (option != 6);
        }

        static int menu()
        {
            int option = 0;
            Console.WriteLine("1. Add Ship");
            Console.WriteLine("2. View Ship Position ");
            Console.WriteLine("3. View Ship Serial Number");
            Console.WriteLine("4. Change Ship Position");
            Console.WriteLine("5. Exit");
            Console.Write("Your Option: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        static Ship Add_Ship()
        {
            Console.Write("Enter Ship Serial Number: ");
            string serial_no = (Console.ReadLine());
            Console.WriteLine("Enter Ship Latitude: ");
            Console.Write("Enter Latitude's Degree: ");
            int latDegree = int.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Minutes: ");
            float latMin = int.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Direction: ");
            char latDir = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Enter Ship Longitude: ");
            Console.Write("Enter Longitude's Degree: ");
            int lonDegree = int.Parse(Console.ReadLine());
            Console.Write("Enter Longitude's Minutes: ");
            float lonMin = int.Parse(Console.ReadLine());
            Console.Write("Enter Longitude's Direction: ");
            char lonDir = Convert.ToChar(Console.ReadLine());
            Ship ship = new Ship(serial_no, latDegree, latMin, latDir, lonDegree, lonMin, lonDir);
            return ship;
        }

        static Ship updateShip(string no)
        {
            string serial_no = no;
            Console.WriteLine("Enter Ship Latitude: ");
            Console.Write("Enter Latitude's Degree: ");
            int latDegree = int.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Minutes: ");
            float latMin = int.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Direction: ");
            char latDir = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Enter Ship Longitude: ");
            Console.Write("Enter Longitude's Degree: ");
            int lonDegree = int.Parse(Console.ReadLine());
            Console.Write("Enter Longitude's Minutes: ");
            float lonMin = int.Parse(Console.ReadLine());
            Console.Write("Enter Longitude's Direction: ");
            char lonDir = Convert.ToChar(Console.ReadLine());
            Ship ship = new Ship(serial_no, latDegree, latMin, latDir, lonDegree, lonMin, lonDir);
            return ship;
        }

    }
}