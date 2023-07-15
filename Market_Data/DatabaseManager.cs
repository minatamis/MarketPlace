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
        private string connectionString = "Data Source = DESKTOP-UTJ2GI1\\SQLEXPRESS;Initial Catalog = MarketPlaceDB;Integrated Security = True;";

        static SqlConnection sqlConnection;

        //public ProductDataServices productDataServices= new ProductDataServices();

        public DatabaseManager() 
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<ProductsInfo> products()
        {
            var selectStatement = "SELECT * FROM dbo.Products";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection); 
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            //ProductDataServices productDataServices = new ProductDataServices();

            var productsInfo = new List<ProductsInfo>();

            while (reader.Read())
            {
                productsInfo.Add(new ProductsInfo
                {
                    itemName = reader["itemName"].ToString(),
                    itemPrice = Convert.ToInt16(reader["itemPrice"]),
                    //itemCategory = productDataServices.retrieveProduct(reader["itemCategorry"].ToString()),
                    //itemDescription = productDataServices.retrieveProduct(reader["itemDescription"].ToString()),
                    //itemRFS = productDataServices.retrieveProduct(reader["itemRFS"].ToString()),
                    //TimeAdded = productDataServices.retrieveProduct(reader["TimeAdded"].ToString()),
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
