﻿using System;
using System.Collections.Generic;
using Market_UI;
using Market_Data;
using Market_BusinessRules;
using Market_Models;

namespace MarketPlace
{
    class Program
    {
        static DateTime gettime = DateTime.Now;
        public static int choice;
        public static void Main(string[] args)
        {
            while (true)
            {
                SystemGreet();
                ShowMainMenu();
                GetInput();
                SelectedOption();
            }
        }

        public static void ShowMainMenu()
        {
            Console.WriteLine("**********************");
            Console.WriteLine("1. view product list"); // add to cart inside view products if there is a selected product.
            Console.WriteLine("2. add product to the market"); // seller's pov
            Console.WriteLine("3. remove product"); // seller's pov
            Console.WriteLine("4. edit product"); // under construction
            Console.WriteLine("5. view cart"); // >>>> check out for the confirmation of address and payment method?????
            Console.WriteLine("6. exit");

        }

        public static void SelectedOption()
        {

            switch (choice)
            {
                case 1:

                    MarketFunctions.ViewProducts();

                    break;

                case 2:
                    MarketFunctions.AddProduct();

                    break;

                case 3:
                    MarketFunctions.RemoveProduct();

                    break;

                case 4:
                    MarketFunctions.EditProduct();

                    break;

                case 5:
                    CartOverview.viewCartStat();

                    break;

                case 6:
                    Environment.Exit(0);

                    break;

                default:
                    Console.WriteLine("invalid choice. please try again.");

                    break;

            }


            Console.WriteLine("\npress any key to continue...");
            Console.ReadKey();

        }
        public static int GetInput()
        {
            Console.Write("please select an option: ");
            choice =Convert.ToInt32(Console.ReadLine());

            return choice;
        }

        
        public static void SystemGreet()
        {
            Console.Clear();
            int hour = gettime.Hour;

            GetHour(hour);

        }
        

        public static void GetHour(int hour)
        {
            if (hour < 12)
            {
                Console.WriteLine("Good Morning!, Welcome to MarketHUB");

            }

            else if (hour < 17 && !(hour == 12))
            {
                Console.WriteLine("Good Afternoon!, Welcome to MarketHUB");

            }
            else if (hour == 12)
            {
                Console.WriteLine("Good Noon!, Welcome to MarketHUB");

            }
            else
            {
                Console.WriteLine("Good Evening!, Welcome to MarketHUB");

            }

        }

    }

}