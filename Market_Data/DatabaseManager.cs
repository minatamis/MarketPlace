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
        private string connectionString = "Data Source = G-HUBSERVER\\SQLEXPRESS;Initial Catalog = MarketPlace;Integrated Security = True;";

        static SqlConnection sqlConnection;

        public ProductDataServices productDataServices= new ProductDataServices();

        public DatabaseManager() 
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<ProductsInfo> products()
        {
            var selectStatement = "SELECT * FROM dbo.ProductsInfo";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection); 
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var productsInfo = new List<ProductsInfo>();

            while (reader.Read())
            {
                productsInfo.Add(new ProductsInfo
                {
                    itemName = productDataServices.retrieveProduct(reader["itemName"].ToString()),
                    itemPrice = Convert.ToInt16(reader["itemPrice"]),
                    //itemCategory = productDataServices.retrieveProduct(reader["itemCategorry"].ToString()),
                    //itemDescription = productDataServices.retrieveProduct(reader["itemDescription"].ToString()),
                    //itemRFS = productDataServices.retrieveProduct(reader["itemRFS"].ToString()),
                    //TimeAdded = productDataServices.retrieveProduct(reader["TimeAdded"].ToString()),
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
