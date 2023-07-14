using Market_Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Data
{
    internal class SqlData : InterProductData
    {
        private string connectionString = "Data Source = MYOUI\\SQLEXPRESS;Initial Catalog = MarketPlaceDB;Integrated Security = True;";

        private string query = "SELECT * FROM Products";

        public List<ProductsInfo> getProductsInfo()
        {
            var productsInfo = new List<ProductsInfo>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader =  command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                productsInfo.Add(new ProductsInfo
                                {
                                    itemName = reader.GetString(reader.GetOrdinal("itemName")),
                                    itemPrice = reader.GetInt32(reader.GetOrdinal("itemPrice")),
                                    itemCategory = reader.GetString(reader.GetOrdinal("itemCategory")),
                                    itemDescription = reader.GetString(reader.GetOrdinal("itemDescription")),
                                    itemRFS = reader.GetString(reader.GetOrdinal("itemRFS")),
                                    TimeAdded = reader.GetDateTime(reader.GetOrdinal("TimeAdded"))

                                });
                                return null;

                            }
                        }
                        else
                        {
                            return null;
                        }
                        return null;

                    }
                }

                connection.Close();

            }

        }
        public void saveProducts(List<ProductsInfo> products)
        {

        }

        public void updateProducts(ProductsInfo products)
        {

        }
    }
}
