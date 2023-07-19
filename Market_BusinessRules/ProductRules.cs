using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market_Data;
using Market_Models;

namespace Market_BusinessRules
{
    public class ProductRules
    {
        ProductDataServices productDataServices;
        public ProductRules()
        {
            productDataServices = new ProductDataServices();

        }

        public List<ProductsInfo> ViewProducts()
        {
            return productDataServices.retrieveProducts();
        }
        public void addProduct(string name, double price, string category, string desc, string rfs)
        {
            ProductsInfo prodInfo = new ProductsInfo
            {
                itemName = name,
                itemPrice = price,
                itemCategory = category,
                itemDescription = desc,
                itemRFS = rfs
            };
            productDataServices.addProducts(prodInfo);
        }
        public void removeProduct(string productName)
        {
            productDataServices.removeProducts(productName);

        }

        //public List<ProductsInfo> checkProduct(string prod)
        //{
        //    var products  = new List<ProductsInfo>();
        //    foreach (var product in products)
        //    {
        //        if (product.itemName.Contains(prod))
        //        {
        //            return products;
        //        }
        //    }
        //    return null;
        //}

        public static string getProducts(ProductsInfo prod)
        {
            string productInfo = "";

            productInfo += $"Item Name: {prod.itemName}\n";
            productInfo += $"Price: {prod.itemPrice}\n";
            productInfo += $"Category: {prod.itemCategory} \n";
            productInfo += $"Description: {prod.itemDescription} \n";
            productInfo += $"Reason for Selling: {prod.itemRFS} \n";

            return productInfo;

        }

        //public void SaveProductData(string itemname, double itemprice, string itemcategory, string itemdescription, string itemRFS)
        //{
        //    ProductsInfo newProduct = new ProductsInfo
        //    {
        //        itemName = itemname,
        //        itemPrice = itemprice,
        //        itemCategory = itemcategory,
        //        itemDescription = itemdescription,
        //        itemRFS = itemRFS
        //    };

        //    addProduct(newProduct);

        //}
        //public ProductsInfo UpdateProductData(string itemname, double itemprice, string itemcategory, string itemdescription, string ItemRFS)
        //{
        //    ProductsInfo existingProduct = retrieveProduct(itemname);

        //    if (existingProduct != null)
        //    {
        //        existingProduct.itemPrice = itemprice;
        //        existingProduct.itemCategory = itemcategory;
        //        existingProduct.itemDescription = itemdescription;
        //        existingProduct.itemRFS = ItemRFS;

        //        return existingProduct;

        //    }
        //    else
        //    {
        //        return null;

        //    }

        //}

    }
}