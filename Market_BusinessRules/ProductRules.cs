﻿using System;
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

        public void addProduct(string name, double price, string category, string desc, string rfs, DateTime TimeAdded)
        {
            ProductsInfo prodInfo = new ProductsInfo
            {
                itemName = name,
                itemPrice = price,
                itemCategory = category,
                itemDescription = desc,
                itemRFS = rfs,
                TimeAdded = TimeAdded
            };
            productDataServices.addProducts(prodInfo);
        }

        public bool removeProduct(string productName)
        {
            return productDataServices.removeProducts(productName);

        }
        public bool checkProduct(string prod)
        {
            var products = new List<ProductsInfo>();
            foreach (var product in products)
            {
                if (product.itemName.Contains(prod))
                {
                    return true;
                }
            }
            return false;
        }
        public bool UpdateProductData(ProductsInfo productToUpdate)
        {
            return productDataServices.updateProducts(productToUpdate);

        }


    }
}