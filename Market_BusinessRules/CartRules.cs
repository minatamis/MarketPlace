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
        public static Cart retrieveProductCart(string cartProd)
        {
            foreach (var product in CartDataServices.cartItems)
            {
                if (product.itemName.Contains(cartProd))
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

    }
}
