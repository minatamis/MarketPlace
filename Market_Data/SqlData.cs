using Market_Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Data
{
    internal class SqlData
    {
        static string connectionString = "Data Source = MYOUI\\SQLEXPRESS;Initial Catalog = MarketPlace;Integrated Security = True;";
        static SqlConnection sqlConnection;
        public SqlData()
        {
            sqlConnection = new SqlConnection(connectionString);

        }
        public List<ProductsInfo> GetProduct()
        {
            string selectStatement = "SELECT Name, Price FROM ListedProducts";
            SqlCommand sqlCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            var prodList = new List<ProductsInfo>();

            while(sqlDataReader.Read())
            {
                prodList.Add(new ProductsInfo
                {
                    itemName = sqlDataReader["Name"].ToString(),
                    itemPrice = Convert.ToDouble(sqlDataReader["Price"].ToString())

                });
            }
            sqlConnection.Close();

            return prodList;
        }
        public void AddProduct(ProductsInfo productsInfo)
        {
            string insertStatement = "INSERT INTO ListedProducts VALUES (@Name, @Price, @Category, @Description, @RFS)";
            SqlCommand sqlCommand = new SqlCommand(insertStatement, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Name", productsInfo.itemName);
            sqlCommand.Parameters.AddWithValue("@Price", productsInfo.itemPrice);
            sqlCommand.Parameters.AddWithValue("@Category", productsInfo.itemCategory);
            sqlCommand.Parameters.AddWithValue("@Description", productsInfo.itemDescription);
            sqlCommand.Parameters.AddWithValue("@RFS", productsInfo.itemRFS);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public List<ProductsInfo> GetProductsInfos()
        {
            string selectStatement = "SELECT * FROM ListedProducts";
            SqlCommand sqlCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            var prodList = new List<ProductsInfo>();

            while (sqlDataReader.Read())
            {
                prodList.Add(new ProductsInfo
                {
                    itemName = sqlDataReader["Name"].ToString(),
                    itemPrice = Convert.ToDouble(sqlDataReader["Price"].ToString()),
                    itemCategory = sqlDataReader["Category"].ToString(),
                    itemDescription = sqlDataReader["Description"].ToString(),
                    itemRFS = sqlDataReader["RFS"].ToString()

                });
            }
            sqlConnection.Close();

            return prodList;
        }

        public void UpdateProductInfo(ProductsInfo productToUpdate)
        {
            //to figure out
        }

    }

}
