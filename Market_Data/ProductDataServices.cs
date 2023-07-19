using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market_Models;
using MarketDataServices;

namespace Market_Data
{
    public class ProductDataServices
    {
        public List<ProductsInfo> products = new List<ProductsInfo>();
        DatabaseManager productdata;

        public ProductDataServices() 
        {
            productdata = new DatabaseManager();
            products = new List<ProductsInfo>();
     
        }
        public ProductsInfo retrieveProduct(string prod)
        {
            products = productdata.GetProduct();

            foreach (var product in products)
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
        
        public List<ProductsInfo> retrieveProducts()
        {
           return productdata.GetProductInfos();
        }

        public void addProduct(ProductsInfo product)
        {
            productdata.InsertProduct(product);
        }
    }

}
