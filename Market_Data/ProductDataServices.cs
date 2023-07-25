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
        private List<ProductsInfo> products;
        DatabaseManager productData;

        public ProductDataServices()
        {
            productData = new DatabaseManager();
            products = new List<ProductsInfo>();

        }
        public ProductsInfo retrieveProduct(string prod)
        {
            products = productData.GetProduct();

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
            return productData.GetProductInfos();
        }
        public void removeProducts(string product)
        {
            productData.DeleteProduct(product);
        }
        public void addProducts(ProductsInfo product)
        {
            productData.InsertProduct(product);
        }
        public void updateProducts(ProductsInfo product)
        {
            productData.UpdateProductInfos(product);
        }

    }

}