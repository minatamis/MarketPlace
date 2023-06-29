using Market_BusinessRules;
using Market_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_UI
{
    public class CartOverview
    {
        public static void GetUser()
        {
            Console.Clear();
            Console.WriteLine("Shipping Info");

            Console.WriteLine("**************");

            Console.WriteLine("Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Email Address: ");
            string email = Console.ReadLine();

            Console.WriteLine("Mobile Number: ");
            int mnum = Convert.ToInt32(Console.ReadLine());

            UserInfo getNewUser = new UserInfo
            {
                username = name,
                useremail = email,
                usermobile = mnum,
            };
            UserRules.getUser(getNewUser);
        }

        public static void GetAddress(string address)
        {
            Console.Clear();
            Console.WriteLine("Enter your Address: ");
            address = Console.ReadLine();

            UserInfo getAdd = new UserInfo
            {
                useraddress = address
            };
            UserRules.getUser(getAdd);
        }

    }
}
