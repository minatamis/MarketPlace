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
        public void SaveUserData(string username, string userAddress, string userMobile)
        {
            UserInfo newUser = new UserInfo
            {
                UserName = username,
                UserAddress = userAddress,
                UserMobile = userMobile
            };

            users.Add(newUser);
            Console.WriteLine("User data saved successfully.");
        }
        public void UpdateUserData(string username, string userAddress, string userMobile)
        {
            UserInfo existingUser = users.Find(u => u.UserName == username);

            if (existingUser != null)
            {
                existingUser.UserAddress = userAddress;
                existingUser.UserMobile = userMobile;
                Console.WriteLine("User data updated successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
    }

}