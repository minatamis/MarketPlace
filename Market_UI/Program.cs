using System;
using System.Collections.Generic;
using Market_UI;
using Market_Data;
using Market_BusinessRules;
using Market_Models;

namespace MarketPlace
{
    class Program
    {
        //static List<string> cart = new List<string>();
        static DateTime gettime = DateTime.Now;
        static void Main(string[] args)
        {

            ProductRules rules = new ProductRules();
            List<ProductsInfo> products = new List<ProductsInfo>();
            products = rules.ViewProducts();

            foreach (var item in products)
            {
                Console.WriteLine(item.itemName);
                Console.WriteLine(item.itemPrice);
                Console.WriteLine(item.itemCategory);
                Console.WriteLine(item.itemDescription);
                Console.WriteLine(item.itemRFS);

            }
            rules.removeProduct("Maica");
            //rules.addProd("Aldrich",10000,"pogi","di maasim","naaasiman sakin");
            Console.WriteLine("====================");
            


            //MarketFunctions marketOverview = new MarketFunctions();

            //// Display the main menu and wait for user input
            //while (true)
            //{
            //    Console.Clear();
            //    int hour = gettime.Hour;

            //    GetHour(hour);
            //    Console.WriteLine("**********************");
            //    Console.WriteLine("1. View Product List"); // ADD TO CART INSIDE View Products if there is a selected product.
            //    Console.WriteLine("2. Add Product to the Market"); // Seller's POV
            //    Console.WriteLine("3. Remove Product"); // Seller's POV
            //    Console.WriteLine("4. Edit Product"); // Under Construction
            //    Console.WriteLine("5. View Cart"); // >>>> Check Out for the confirmation of Address and Payment Method?????
            //    Console.WriteLine("6. Exit");
            //    Console.Write("Please select an option: ");

            //    string choice = Console.ReadLine();

            //    switch (choice)
            //    {
            //        case "1"://unfinished
            //            //MarketFunctions.ViewProducts(products);
            //            ProductRules rules = new ProductRules();
            //            var list = rules.ViewProducts();

            //            foreach (var item in list)
            //            {
            //                Console.WriteLine(item.itemName);
            //                Console.WriteLine(item.itemPrice);
            //            }

            //            break;

            //        case "2":
            //            MarketFunctions.AddProduct();

            //            break;

            //        case "3":
            //            MarketFunctions.RemoveProduct();

            //            break;

            //        case "4":
            //            MarketFunctions.EditProduct();

            //            break;

            //        case "5":
            //            //ViewCart();

            //            break;

            //        case "6":
            //            Environment.Exit(0);

            //            break;

            //        default:
            //            Console.WriteLine("Invalid choice. Please try again.");

            //            break;

            //    }


            //    Console.WriteLine("\nPress any key to continue...");
            //    Console.ReadKey();

            //}

        }

        

        static void GetHour(int hour)
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


        // Under Construction
        /*static void AddtoCart(Dictionary<string, (double Price, string Description)> products)
        {

        }*/


        //static void ViewCart()
        //{
        //    Console.Clear();
        //    Console.WriteLine("Cart:");
        //    Console.WriteLine("===========================");

        //    if (cart.Count == 0)
        //    {
        //        Console.WriteLine("Cart is empty.");
        //    }
        //    else
        //    {
        //        int index = 1;
        //        foreach (string product in cart)
        //        {
        //            Console.WriteLine("{0}. {1}", index, product);
        //            index++;

        //        }

        //    }

        //}

    }

}