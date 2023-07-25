using Market_Models;
using MarketDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Data
{
    public class CartDataService
    {
        DatabaseManager productData;
        private List<Cart> cartList;

        public CartDataService()
        {
            productData = new DatabaseManager();
            cartList = new List<Cart>();

        }
        public List<Cart> getCart(string username)
        {
            return productData.GetCartItems(username);
        }
        public void addProdToCart(string prodToAdd,string user)
        {
            productData.AddtoCart(prodToAdd, user);
        }
        public void removeProdFromCart(string prodToRemove,string user)
        {
            productData.RemoveFromCart(prodToRemove, user);
        }
    }
}
