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
        public static void askDeliveryInfo(Products) 
        {

            Console.WriteLine("Delivery Info");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Address: ");
            string address = Console.ReadLine();
            int mobileNumber;
            do
            {
                Console.WriteLine("Contact Number: ");
                mobileNumber = Convert.ToInt32(Console.ReadLine());
            }
            while (Payment.numberCountChecker(mobileNumber,11) == false);

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
