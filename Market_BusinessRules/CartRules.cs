using Market_Data;
using Market_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_BusinessRules
{
    internal class CartRules
    {
        public static string getProduct(Cart cart)
        {
            string Cart = "";

            Cart += $"Item Name: {cart.itemName}\n";
            Cart += $"Price: {cart.itemPrice}\n";
            Cart += $"Category: {cart.itemCategory} \n";
            Cart += $"Description: {cart.itemDescription} \n";
            Cart += $"Reason for Selling: {cart.itemRFS} \n";

            return Cart;

        }

    }
}
