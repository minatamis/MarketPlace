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
        public static ProductsInfo retrieveProduct(string prod)
        {
            foreach (var product in ProductDataServices.products)
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

    }

}
