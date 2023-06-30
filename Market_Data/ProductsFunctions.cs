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

        public static List<UserInfo> users = new List<UserInfo>();      
        public static void addProduct(Products prod)
        {
            products.Add(prod);

        }
        public static void removeProduct(Products prod)
        {

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
            Console.WriteLine($"Reason for Selling: {prod.ItemRFS}");

        }
        public void SaveUserData(string userName, string userAddress, int userMobile)
        {
            UserInfo newUser = new UserInfo
            {
                username = userName,
                useraddress = userAddress,
                usermobile = userMobile
            };

            users.Add(newUser);
            Console.WriteLine("User data saved successfully.");
        }
        public void UpdateUserData(string userName, string userAddress, int userMobile)
        {
            UserInfo existingUser = users.Find(u => u.username == userName);

            if (existingUser != null)
            {
                existingUser.useraddress = userAddress;
                existingUser.usermobile = userMobile;
                Console.WriteLine("User data updated successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
        public void SaveProductData(string itemname, double itemprice, string itemcategory, string itemdescription, string itemRFS)
        {
            Products newProduct = new Products
            {
                itemName = itemname,
                itemPrice = itemprice,
                itemCategory = itemcategory,
                itemDescription = itemdescription,
                itemRFS = itemRFS
            };

            products.Add(newProduct);
            Console.WriteLine("Product data saved successfully.");
        }
    }
}
