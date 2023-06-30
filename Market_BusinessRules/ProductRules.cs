using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            ProductDataServices.products.Add(prod);

        }
        public static void removeProduct(ProductsInfo prod)
        {
            ProductDataServices.products.Remove(prod);

        }

        public static void editProduct(ProductsInfo prod)
        {
           // not yet finished need help ma'am 
        }

        public static ProductsInfo retrieveProduct(string prod)
        {
            foreach (var product in ProductDataServices.products)
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

        public static string getProducts(ProductsInfo prod)
        {
            string productInfo = "";
            
            productInfo += $"Item Name: {prod.itemName}\n";
            productInfo += $"Price: {prod.itemPrice}\n";
            productInfo += $"Category: {prod.itemCategory} \n";
            productInfo += $"Description: {prod.itemDescription} \n";
            productInfo += $"Reason for Selling: {prod.itemRFS} \n";

            return productInfo;

        }



    }
}
