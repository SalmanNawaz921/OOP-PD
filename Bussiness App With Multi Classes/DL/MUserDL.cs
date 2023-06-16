using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rms.BL;
using rms.UI;

namespace rms.DL
{
    public class MUserDL
    {
        public static List<MUser> usersList = new List<MUser>();
        public static void addUser(MUser user, string path)
        {
            bool flag = true;
            foreach (MUser u in usersList)
            {
                if (user.GetRole() == "MANAGER")
                {
                    if (u.GetPassword() == user.GetPassword() && u.GetName() == user.GetPassword())
                    {
                        flag = false;
                        Console.WriteLine("Sign Up Failed!");
                        break;
                    }
                }
            }
            if (user.GetRole() == "CASHIER")
            {

                foreach (Cashier employee in Manager.cashierList())
                {
                    if (employee.GetName() == user.GetName() && employee.GetPassword() == user.GetPassword())
                    {
                        flag = true;
                        break;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
            if (flag == true)
            {
                usersList.Add(user);
                storeUser(path, user);
                Console.WriteLine("Signed Up Successfully!");
            }
        }
        public static void storeUser(string path, MUser newUser)
        {
            StreamWriter writer = new StreamWriter(path);
            foreach (MUser user in usersList)
            {
                writer.WriteLine(user.GetName() + "," + user.GetPassword() + "," + user.GetRole());
            }
            writer.Close();
        }
        public static void loadUser(string path)
        {
            string line;
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    string[] userFields = line.Split(',');
                    MUser newUser = new MUser();
                    newUser.SetName(userFields[0]);
                    newUser.SetPassword(userFields[1]);
                    newUser.SetRole(userFields[2]);
                    usersList.Add(newUser);
                }
                file.Close();
            }
        }
    }
}