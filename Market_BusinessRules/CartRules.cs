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
        public static void addProductToCart(Cart cart)
            {
                CartDataServices.cartItems.Add(cart);
            }

    }
}
