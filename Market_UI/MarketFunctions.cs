﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market_Models;
using Market_BusinessRules;
using System.Collections.Concurrent;
using Market_Data;

namespace Market_UI
{
    public class MarketFunctions
    {
        public static void ViewProducts(List<ProductsInfo> products)
        {
            Console.Clear();
            Console.WriteLine("Products:");
            Console.WriteLine("**************************");

            if (products.Count == 0)
            {
                Console.WriteLine("There is no product available at the moment.");

            }
            else
            {
                Console.WriteLine("Products: ");
                foreach (var product in products)
                {
                    
                    string productInfo = ProductRules.getProducts(product);
                    Console.WriteLine(productInfo);

                }

                //Console.WriteLine("\nSelect a product number to add to cart (0 to cancel): ");
                //int productNumber;
                //if (int.TryParse(Console.ReadLine(), out productNumber) && productNumber >= 1 && productNumber <= products.Count)
                //{
                //    string selectedProduct = products.Keys.ElementAt(productNumber - 1);
                //    cart.Add(selectedProduct);
                //    Console.WriteLine("Product '{0}' added to cart.", selectedProduct);
                //}
                //else if (productNumber != 0)
                //{
                //    Console.WriteLine("Invalid product number.");
                //}

            }


            // Under Construction... (Add to Cart Function)
        }
        public static void AddProduct()
        {
            Console.Clear();
            Console.WriteLine("Add Product:");
            Console.WriteLine("*************************");

            Console.Write("Enter the name of the product: ");
            string product = Console.ReadLine();

            if (!string.IsNullOrEmpty(product))
            {
                Console.Write("Enter the price of the product: PHP");
                if (double.TryParse(Console.ReadLine(), out double price))
                {
                    Console.Write("Enter the description of the product: ");
                    string description = Console.ReadLine();
                    Console.Write("Enter the category of the product: ");
                    string category = Console.ReadLine();
                    Console.Write("Enter your reason for selling: ");
                    string rfs = Console.ReadLine();

                    ProductsInfo addProd = new ProductsInfo
                    {
                        itemName = product,
                        itemPrice = price,
                        itemCategory = category,
                        itemDescription = description,
                        itemRFS = rfs
                    };
                    ProductRules.addProduct(addProd);

                    //products.Add(product, (price, description));
                    Console.WriteLine("Product has been added.");

                }
                else
                {
                    Console.WriteLine("Price not applicable.");

                }

            }
            else
            {
                Console.WriteLine("Product name cannot be empty.");

            }

        }
        public static void RemoveProduct()
        {
            Console.Clear();
            Console.WriteLine("Remove Product:");
            Console.WriteLine("****************************");

            Console.Write("Enter the name of the product to remove: ");
            string product = Console.ReadLine();

            if(ProductRules.checkProductExistence(product))
            {
                ProductsInfo removeProd = new ProductsInfo();
                //ProductsFunctions.removeProduct();
                Console.WriteLine("Product has been removed.");

            }
            else
            {
                Console.WriteLine("Product is not available.");

            }

        }

        public static void EditProduct()
        {
            Console.Clear();
            Console.WriteLine("Edit Product:");
            Console.WriteLine("**************************");

            Console.Write("Enter the name of the product to Edit: ");
            string itemName = Console.ReadLine();

            ProductsInfo newprod = ProductDataServices.products.Find(p => p.itemName == itemName);

            if (newprod == null)
            {
                Console.WriteLine("Product not found.");
                return;

            }
            else
            {
                Console.WriteLine("Enter the new item name: ");
                newprod.itemName = Console.ReadLine();

                Console.WriteLine("Enter the new item price:");
                newprod.itemPrice = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter the new item category:");
                newprod.itemCategory = Console.ReadLine();

                Console.WriteLine("Enter the new item description:");
                newprod.itemDescription = Console.ReadLine();

                Console.WriteLine("Enter the new reason for selling:");
                newprod.itemRFS = Console.ReadLine();

                Console.WriteLine("Product edited successfully!");
            }


        }
    }


 }

       
    

