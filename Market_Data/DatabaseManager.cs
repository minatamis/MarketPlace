using Market_Models;
using Market_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataServices
{
    public class DatabaseManager : InterProductData
    {
        private string connectionString = "Data Source = MYOUI\\SQLEXPRESS;Initial Catalog = MarketPlace;Integrated Security = True;";

        static SqlConnection sqlConnection;

        public ProductDataServices productDataServices;

        public DatabaseManager()
        {
            sqlConnection = new SqlConnection(connectionString);
            productDataServices = new ProductDataServices();
        }

        public List<ProductsInfo> getProductsInfo()
        {
            var selectStatement = "SELECT itemName FROM Products";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var productsInfo = new List<ProductsInfo>();

            while (reader.Read())
            {
                productsInfo.Add(new ProductsInfo
                {
                    itemName = productDataServices.getProduct(reader["itemName"].ToString()),

                });
            }

            sqlConnection.Close();

            return productsInfo;
        }


        public void saveProducts(List<ProductsInfo> products)
        {
            
        }

        public void updateProducts(ProductsInfo products)
        {
            
        }
    }
}
