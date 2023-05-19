using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class MarketProucts
    {
        List<Products> products = new List<Products>();

        public void addProduct(Products prod)
        {
            products.Add(prod);

        }
        public void removeProduct(Products prod)
        {
            products.Remove(prod);

        }
        public void displayProducts(Products prod)
        {
            Console.WriteLine($"Item Name {}");
        }

    }

}
