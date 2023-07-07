using Market_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Data
{
    public class DatabaseManager : InterProductData
    {
        private string connectionString = "Data Source = MYOUI\SQLEXPRESS;Initial Catalog = MarketPlaceDB;Integrated Security = True;";

        static SqlConnection sqlConnection;

        public DatabaseManager() 
        {
            sqlConnections = new SqlConnection(connectionString);
        }

        public List<ProductsInfo> products()
        {
            var selectStatement = "Select * From Products";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnections);
            SqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var productsInfo = new List<ProductsInfo>();

            while (reader.Read())
            {
                productsInfo.Add(new ProductsInfo
                {
                    itemName = ProductDataServices.retrieveProduct(reader["Name"].ToString()),
                    itemPrice = Convert.ToInt16(reader["Price"])
                    //itemCategory
                });
            }

            sqlConnection.Close();

            return null;
        }

        public void saveProducts(List<ProductsInfo> products)
        {
            
        }

        public void updateProducts(ProductsInfo products)
        {
            
        }
    }
}
