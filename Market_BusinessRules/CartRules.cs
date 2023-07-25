using Market_Data;
using Market_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_BusinessRules
{
    public class CartRules
    {
        CartDataService cartDataService;
        public CartRules()
        {
            cartDataService = new CartDataService();
        }
        public List<Cart> ViewCart(string user)
        {
            return cartDataService.getCart(user);
        }
        public void addToCart(string product, string user)
        {
            cartDataService.addProdToCart(product, user);
        }
        public void removeFromCart(string product, string user)
        {
            cartDataService.removeProdFromCart(product, user);
        }
    }
}
