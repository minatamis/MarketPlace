using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace BusinessRules
{
    internal class DeliveryInfo
    {
        public static void askDeliveryInfo() 
        {

            Console.WriteLine("Delivery Info");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Address: ");
            string address = Console.ReadLine();
            Console.WriteLine("Contact Number: ");
            int mobileNumber = Convert.ToInt32(Console.ReadLine());

            //sample store only
            UserInfo userDeliveryInfo = new UserInfo
            {
                userName = name,
                userAddress = address,
                userMobile = mobileNumber
            };

            Console.WriteLine("Info stored successfully");

        }

    }

}
