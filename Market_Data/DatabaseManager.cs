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
    public class DatabaseManager
    {
        static string connectionString = "Data Source = G-HUBSERVER\\SQLEXPRESS;Initial Catalog = MarketPlaceDB;Integrated Security = True;";
        
        static SqlConnection sqlConnection;

        public DatabaseManager()
        {
            sqlConnection = new SqlConnection(connectionString);

        }
        public List<ProductsInfo> GetProduct()
        {
            string selectStatement = "SELECT itemName, itemPrice FROM Products";
            SqlCommand sqlCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            var prodList = new List<ProductsInfo>();

            while (sqlDataReader.Read())
            {
                prodList.Add(new ProductsInfo
                {
                    itemName = sqlDataReader["itemName"].ToString(),
                    itemPrice = Convert.ToDouble(sqlDataReader["itemPrice"].ToString())

                });
            }
            sqlConnection.Close();

            return prodList;
        }
        public void InsertProduct(ProductsInfo prodInfo)
        {
            
            string insertStatement = "INSERT INTO Products VALUES (@itemName, @itemPrice, @itemCategory, @itemDescription, @itemRFS, @TimeAdded)";
            SqlCommand sqlCommand = new SqlCommand(insertStatement, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@itemName", prodInfo.itemName);
            sqlCommand.Parameters.AddWithValue("@itemPrice", prodInfo.itemPrice);
            sqlCommand.Parameters.AddWithValue("@itemCategory", prodInfo.itemCategory);
            sqlCommand.Parameters.AddWithValue("@itemDescription", prodInfo.itemDescription);
            sqlCommand.Parameters.AddWithValue("@itemRFS", prodInfo.itemRFS);
            sqlCommand.Parameters.AddWithValue("@TimeAdded", prodInfo.TimeAdded);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public List<ProductsInfo> GetProductInfos()
        {
            string selectStatement = "SELECT * FROM Products";
            SqlCommand sqlCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            var prodList = new List<ProductsInfo>();

            while (sqlDataReader.Read())
            {
                prodList.Add(new ProductsInfo
                {
                    itemName = sqlDataReader["itemName"].ToString(),
                    itemPrice = Convert.ToDouble(sqlDataReader["itemPrice"].ToString()),
                    itemCategory = sqlDataReader["itemCategory"].ToString(),
                    itemDescription = sqlDataReader["itemDescription"].ToString(),
                    itemRFS = sqlDataReader["itemRFS"].ToString(),
                    TimeAdded = Convert.ToDateTime(sqlDataReader["TimeAdded"])

                });
            }
            sqlConnection.Close();

            return prodList;
        }
        public void DeleteProduct(string productsInfo)
        {
            string deleteStatement = "DELETE FROM Products WHERE itemName = @itemName";
            SqlCommand sqlCommand = new SqlCommand(deleteStatement, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@itemName", productsInfo);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }
        public void UpdateProductInfos(ProductsInfo productToUpdate, string productName)
        {
            string updateStatement = "UPDATE Products SET itemPrice = @itemPrice, itemCategory = @itemCategory, itemDescription = @itemDescription, itemRFS = @itemRFS WHERE itemName = @itemName";
            SqlCommand sqlCommand = new SqlCommand(updateStatement, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@itemPrice", productToUpdate.itemPrice);
            sqlCommand.Parameters.AddWithValue("@itemCategory", productToUpdate.itemCategory);
            sqlCommand.Parameters.AddWithValue("@itemDescription", productToUpdate.itemDescription);
            sqlCommand.Parameters.AddWithValue("@itemRFS", productToUpdate.itemRFS);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

    }
}