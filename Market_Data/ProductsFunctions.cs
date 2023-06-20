using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market_Models;

namespace Market_Data
{
    public class ProductsFunctions
    {
        public static List<Products> products = new List<Products>();

        public static void addProduct(Products prod)
        {
            products.Add(prod);

        }
        public static void removeProduct(Products prod)
        {prod.

            products.Remove(prod);

        }
        public static Products searchProduct(string prod)
        {
            foreach (var product in products)
            {
                if (product.itemName.Contains(prod))
                {
                    return product;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
        public static void displayProducts(Products prod)
        {
            Console.WriteLine($"Item Name: {prod.itemName}");
            Console.WriteLine($"Price: {prod.itemPrice}");
            Console.WriteLine($"Category: {prod.itemCategory}");
            Console.WriteLine($"Description: {prod.itemDescription}");
            Console.WriteLine($"Reason for Selling: {prod.itemRFS}");

        }

    }

}