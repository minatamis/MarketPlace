using Market_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market_Models;
using Market_Data;

namespace Market_UI
{
    public class MarketFunctions
    {
        public static void ViewProducts(List<ProductsInfo> products)
        {
            Console.Clear();
            Console.WriteLine("Products:");
            Console.WriteLine("**************************");

            if (products.Count == 0)
            {
                Console.WriteLine("There is no product available at the moment.");

            }
            else
            {
                int index = 1;
                foreach (var product in products)
                {
                    Console.WriteLine($"{index})");
                    ProductsFunctions.displayProducts(product);

                    index++;

                }

                //Console.WriteLine("\nSelect a product number to add to cart (0 to cancel): ");
                //int productNumber;
                //if (int.TryParse(Console.ReadLine(), out productNumber) && productNumber >= 1 && productNumber <= products.Count)
                //{
                //    string selectedProduct = products.Keys.ElementAt(productNumber - 1);
                //    cart.Add(selectedProduct);
                //    Console.WriteLine("Product '{0}' added to cart.", selectedProduct);
                //}
                //else if (productNumber != 0)
                //{
                //    Console.WriteLine("Invalid product number.");
                //}

            }


            // Under Construction... (Add to Cart Function)
        }
        public static void AddProduct()
        {
            Console.Clear();
            Console.WriteLine("Add Product:");
            Console.WriteLine("*************************");

            Console.Write("Enter the name of the product: ");
            string product = Console.ReadLine();

            if (!string.IsNullOrEmpty(product))
            {
                Console.Write("Enter the price of the product: PHP");
                if (double.TryParse(Console.ReadLine(), out double price))
                {
                    Console.Write("Enter the description of the product: ");
                    string description = Console.ReadLine();
                    Console.Write("Enter the category of the product: ");
                    string category = Console.ReadLine();
                    Console.Write("Enter your reason for selling: ");
                    string rfs = Console.ReadLine();

                    ProductsInfo addProd = new ProductsInfo
                    {
                        itemName = product,
                        itemPrice = price,
                        itemCategory = category,
                        itemDescription = description,
                        itemRFS = rfs
                    };
                    ProductsFunctions.addProduct(addProd);

                    //products.Add(product, (price, description));
                    Console.WriteLine("Product has been added.");

                }
                else
                {
                    Console.WriteLine("Price not applicable.");

                }

            }
            else
            {
                Console.WriteLine("Product name cannot be empty.");

            }

        }
        public static void RemoveProduct()
        {
            Console.Clear();
            Console.WriteLine("Remove Product:");
            Console.WriteLine("****************************");

            Console.Write("Enter the name of the product to remove: ");
            string product = Console.ReadLine();

            if(ProductsFunctions.searchProduct(product))
            {
                ProductsInfo removeProd = new ProductsInfo();
                //ProductsFunctions.removeProduct();
                Console.WriteLine("Product has been removed.");

            }
            else
            {
                Console.WriteLine("Product is not available.");

            }

        }

    }
}
