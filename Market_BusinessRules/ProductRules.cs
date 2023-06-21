using Market_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market_Data;
using Market_Models;

namespace Market_BusinessRules
{
    public class ProductRules
    {
        public static void addProduct(ProductsInfo prod)
        {
            ProductList.products.Add(prod);

        }
        public static void removeProduct(ProductsInfo prod)
        {
            ProductList.products.Remove(prod);

        }
        public static bool checkProductExistence(string prod)
        {
            foreach (var product in ProductList.products)
            {
                if (product.itemName.Contains(prod))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public static void getProducts(ProductsInfo prod)
        {
            Console.WriteLine($"Item Name: {prod.itemName}");
            Console.WriteLine($"Price: {prod.itemPrice}");
            Console.WriteLine($"Category: {prod.itemCategory}");
            Console.WriteLine($"Description: {prod.itemDescription}");
            Console.WriteLine($"Reason for Selling: {prod.itemRFS}");

        }

    }
}
