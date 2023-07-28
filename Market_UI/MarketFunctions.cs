using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market_Models;
using Market_BusinessRules;
using System.Collections.Concurrent;
using MarketDataServices;
using System.Drawing.Text;
using Microsoft.VisualBasic;

namespace Market_UI
{
    public static class MarketFunctions
    {
        private static ProductRules productRules = new ProductRules();
        private static CartOverview cartOverview = new CartOverview();

        public static void ViewProducts()
        {
            Console.Clear();
            Console.WriteLine("Products: ");
            Console.WriteLine("**************************");

            ProductRules rules = new ProductRules();
            List<ProductsInfo> products = new List<ProductsInfo>();
            products = rules.ViewProducts();


            if (products.Count == 0)
            {
                Console.WriteLine("There is no product available at the moment.");
            }
            else
            {
                foreach (var item in products)
                {
                    Console.WriteLine("Item Name: " + item.itemName);
                    Console.WriteLine("Price: " + item.itemPrice);
                    Console.WriteLine("Category: " + item.itemCategory);
                    Console.WriteLine("Description: " + item.itemDescription);
                    Console.WriteLine("Reason for Selling: " + item.itemRFS);


                    TimeSpan timeSinceAdded = DateTime.Now - item.TimeAdded;
                    string timeAgo = GetTimeAgoString(timeSinceAdded);

                    Console.WriteLine($"Posted {timeAgo} ago \n");
                }

                string prod;
                do
                {
                    Console.WriteLine("Enter name of product to add to cart or X to stop adding to cart");
                    prod = Console.ReadLine();
                    if(prod == "x" || prod == "X")
                    {
                        break;
                    }
                    else
                    {
                        cartOverview.addToCart(prod);

                    }

                } while (prod != "x" || prod != "X");

            }

        }
        public static void AddProduct()
        {
            ProductRules rules = new ProductRules();
            Console.Clear();
            Console.WriteLine("Add Product:");
            Console.WriteLine("*************************");


            Console.Write("enter the name of the product: ");
            string name = Console.ReadLine();

            if (!string.IsNullOrEmpty(name))
            {
                Console.Write("enter the price of the product: php");
                if (double.TryParse(Console.ReadLine(), out double price))
                {
                    Console.Write("enter the description of the product: ");
                    string desc = Console.ReadLine();
                    Console.Write("enter the category of the product: ");
                    string category = Console.ReadLine();
                    Console.Write("enter your reason for selling: ");
                    string rfs = Console.ReadLine();

                    DateTime TimeAdded = DateTime.Now;


                    Console.Write("The product was successfully added to the Market Place.");

                    rules.addProduct(name, price, desc, category, rfs, TimeAdded);


                    
                }
                else
                {
                    Console.WriteLine("price not applicable.");

                }

            }
            else
            {
                Console.WriteLine("product name cannot be empty.");

            }

        }

        public static void RemoveProduct()
        {
            ProductRules rules = new ProductRules();
            Console.Clear();
            Console.WriteLine("Remove Product:");
            Console.WriteLine("****************************");

            Console.Write("Enter the name of the product to remove: ");
            string productName = Console.ReadLine();

            bool toRemove = rules.removeProduct(productName);

            if (toRemove)
            {
                Console.WriteLine("Product has been removed.");
            }
            else
            {
                Console.WriteLine("Product is not available.");

            }
        }

        public static void EditProduct()
        {
            ProductRules rules = new ProductRules();
            Console.Clear();
            Console.WriteLine("Edit Product:");
            Console.WriteLine("**************************");
            Console.Write("Enter the name of the product to Edit: ");
            string itemName = Console.ReadLine();

            Console.Write("Enter the new item price:");
            double newPrice = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the new item description:");
            string newDescription = Console.ReadLine();

            Console.Write("Enter the new item category:");
            string newCategory = Console.ReadLine();

            Console.Write("Enter the new reason for selling:");
            string newRFS = Console.ReadLine();

            ProductsInfo productToUpdate = new ProductsInfo()
            {
                itemName = itemName,
                itemPrice = newPrice,
                itemDescription = newDescription,
                itemCategory = newCategory,
                itemRFS = newRFS
            };


            if (rules.UpdateProductData(productToUpdate))
            {
                Console.WriteLine("Product edited successfully!");
            }
            else
            {
                Console.WriteLine("Product not found.");
                return;

            }
        }


        static string GetTimeAgoString(TimeSpan timeSpan)
        {
            if (timeSpan.TotalSeconds < 60)
            {
                return $"{Convert.ToInt32(Math.Round(timeSpan.TotalSeconds))} seconds";
            }
            else if (timeSpan.TotalMinutes < 60)
            {
                return $"{Math.Round(timeSpan.TotalMinutes)} minutes";
            }
            else if (timeSpan.TotalHours < 24)
            {
                return $"{Math.Round(timeSpan.TotalHours)} hours";
            }
            else
            {
                return $"{Convert.ToInt32(Math.Round(timeSpan.TotalDays))} days";
            }
        }
    }


 }

       
    

