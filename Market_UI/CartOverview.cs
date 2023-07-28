using Market_BusinessRules;
using Market_Data;
using Market_Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_UI
{
    public class CartOverview
    {
        CartRules cartRules;
        UserRules userRules;
        public CartOverview()
        {
            cartRules = new CartRules();
            userRules = new UserRules();
        }
        public static void viewCartStat()
        {
            CartOverview cartOverview = new CartOverview();
            cartOverview.viewCart();
        }

        public void viewCart()
        {
            Console.Write("Enter username: ");
            string user = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(user + "'s Cart: ");
            Console.WriteLine("**************************");

            ProductRules rules = new ProductRules();
            List<Cart> cartList;
            cartList = cartRules.ViewCart(user);
            double totalPrice = 0;


            if (cartList.Count == 0)
            {
                Console.WriteLine("Your Cart is Empty");
            }
            else
            {
                foreach (var item in cartList)
                {
                    Console.WriteLine("Item Name: " + item.itemName);
                    Console.WriteLine("Price: " + item.itemPrice + "\n");
                    totalPrice += item.itemPrice;
                }
                Console.WriteLine("Total Price: " + totalPrice);
            }
            Console.WriteLine("==========================");
            Console.WriteLine("\nEnter 1 to remove a product from the cart");
            Console.WriteLine("Enter 2 to Checkout");
            Console.WriteLine("Press X to return");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                removeCartProduct(user);
            }
            else if (choice == "2")
            {
                checkOut(user);
            }
            else if (choice.ToUpper() == "X") 
            {
                Console.WriteLine("Returning to main menu...");
            }


        }
        public void addToCart(string prodName)
        {
            Console.WriteLine("Confirm adding to cart");

            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();

            if (!string.IsNullOrEmpty(userName))
            {
                if(cartRules.addToCart(prodName, userName))
                {
                    Console.WriteLine(prodName + " successfully added to your cart " + userName);
                }
                else
                {
                    Console.WriteLine("Product not found: " + prodName);
                }
                
                
            }
            else
            {
                Console.WriteLine("We need your name");

            }
        }
        public void removeCartProduct(string userName)
        {
            Console.Clear();
            Console.WriteLine("Remove From Cart:");
            Console.WriteLine("*************************");


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
        public void checkOut(string user)
        {
            Console.WriteLine("\nProceed Check-out");
            Console.WriteLine("*************************");

            UserRules uRules = new UserRules();
            CartRules cRules = new CartRules();
            List<UserInfo> userList;
            userList = userRules.getUserInfo(user);


            if (userList.Count == 0)
            {
                Console.Write("Enter your address: ");
                string address = Console.ReadLine();
                Console.Write("Enter your email: ");
                string email = Console.ReadLine();
                Console.Write("Enter your mobile number: ");
                string mobile = Console.ReadLine();

                Console.WriteLine("Thank you for purchasing!");

                UserInfo userInfo = new UserInfo
                {
                    username = user,
                    useraddress = address,
                    useremail = email,
                    usermobile = mobile
                };
                userRules.addUser(userInfo);

            }

            else

            {
                foreach (var item in userList)
                {
                    Console.WriteLine("======Current Contact Information======");
                    Console.WriteLine("Buyer name: " + item.username);
                    Console.WriteLine("Home Address: " + item.useraddress);
                    Console.WriteLine("Email Address: " + item.useremail);
                    Console.WriteLine("Mobile Number: " + item.usermobile + "\n");

                }
                Console.WriteLine("Enter 1 to Update your contact information");
                Console.WriteLine("Enter 2 to proceed to check out");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter your new Home Address:");
                    string newUseraddress = Console.ReadLine();

                    Console.Write("Enter your new Email Address:");
                    string newUseremail = Console.ReadLine();

                    Console.Write("Enter your new Mobile Number:");
                    string newUsermobile = Console.ReadLine();

                    UserInfo userToUpdate = new UserInfo()
                    {
                        username = user,
                        useraddress = newUseraddress,
                        useremail = newUseremail,
                        usermobile = newUsermobile,
                    };

                    if (uRules.updateUserInfo(userToUpdate))
                    {
                        Console.WriteLine("User contact information updated successfully!");
                        cRules.ClearCart(user);
                        Console.WriteLine("Thank you for purchasing!");
                        
                    }
                    else
                    {
                        Console.WriteLine("User not found.");
                        return;

                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine();
                    Console.WriteLine("Thank you for purchasing!");
                    cRules.ClearCart(user);
                }


            }


        }
    }
}
