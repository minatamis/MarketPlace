using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductsFunctions
    {
        public static List<Products> products = new List<Products>();

        public static void addProduct(Products prod)
        {
            products.Add(prod);

        }
        public static void removeProduct(Products prod)
        {
            products.Remove(prod);

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
