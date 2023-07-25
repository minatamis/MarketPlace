using Market_BusinessRules;
using Market_Data;
using Market_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_UI
{
    public class CartOverview
    {
        CartRules cartRules;
        public CartOverview()
        {
            cartRules = new CartRules();
        }

        public void viewCart(string user)
        {
            Console.Clear();
            Console.WriteLine("Cart: ");
            Console.WriteLine("**************************");

            ProductRules rules = new ProductRules();
            List<Cart> cartList;
            cartList = cartRules.ViewCart(user);

            if (cartList.Count == 0)
            {
                Console.WriteLine("Your Cart is Empty");
            }
            else
            {
                foreach (var item in cartList)
                {
                    Console.WriteLine(cartList.Count+ ")");
                    Console.WriteLine("Item Name: " + item.itemName);
                    Console.WriteLine("Price: " + item.itemPrice);
                }

            }
        }
        public void addToCart()
        {
            Console.Clear();
            Console.WriteLine("Add To Cart:");
            Console.WriteLine("*************************");

            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();

            if (!string.IsNullOrEmpty(userName))
            {
                Console.Write("Enter the name of the product: ");
                string prodName = Console.ReadLine();

                cartRules.addToCart(prodName, userName);
                Console.WriteLine(prodName+" successfully added to your cart " + userName);
            }
            else
            {
                Console.WriteLine("We need your name");

            }
        }
        public void removeCartProduct()
        {
            Console.Clear();
            Console.WriteLine("Remove From Cart:");
            Console.WriteLine("*************************");

            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();

            if (!string.IsNullOrEmpty(userName))
            {
                Console.Write("Enter the name of the product: ");
                string prodName = Console.ReadLine();
                if (!string.IsNullOrEmpty(prodName))
                {
                    cartRules.removeFromCart(prodName, userName);
                    Console.WriteLine(prodName + " successfully removed from your cart " + userName);
                }
                else
                {
                    Console.WriteLine("Product name cannot be empty");

                }
            }
            else
            {
                Console.WriteLine("We need your name");

            }
        }
    }
}
