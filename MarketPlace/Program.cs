using System;
using System.Collections.Generic;

namespace MarketPlace
{
    class items
    {
        public string itemName { get; set; }
        public string itemCategoory { get; set; }
        public int itemPrice { get; set; }

    }
    internal class Program
    {
        static List<items> cartItems = new List<items>();


        static void viewMarket()
        {

        }

        static void viewwCart()
        {
            Console.WriteLine("Items in cart:");
            foreach (items cartItem in cartItems)
            {
                Console.WriteLine("- " + cartItem);

            }

        }
        static void checkOut()
        {

        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Add item to cart");
                Console.WriteLine("2. View cart");
                Console.WriteLine("3. Checkout");
                Console.WriteLine("4. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        viewMarket();
                        break;

                    case 2:
                        viewwCart();
                        break;

                    case 3:
                        checkOut();
                        break;

                    case 4:
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            }

        }

    }

}