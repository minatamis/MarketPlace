using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market_Models;

namespace Market_Data
{
    public class ProductDataServices
    {
        public static List<ProductsInfo> products;

        public ProductDataServices()
        {
            products = new List<ProductsInfo>();


        }
        public static List<ProductsInfo> getProduct()
        {
            return products;
        }
        public static ProductsInfo getProduct(string prod)
        {
            ProductsInfo foundProd = new ProductsInfo();
            foreach (var item in products)
            {
                if (item.itemName == prod)
                {
                    foundProd = item;
                }
            }
            return foundProd;
        }

    }

}
