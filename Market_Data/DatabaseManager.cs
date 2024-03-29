﻿using Market_Models;
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
        static string connectionString = "Data Source = MYOUI\\SQLEXPRESS;Initial Catalog = MarketPlaceDB;Integrated Security = True;";
        
        static SqlConnection sqlConnection;

        public DatabaseManager()
        {
            sqlConnection = new SqlConnection(connectionString);

        }

        //market connections
        //maam sample
        //public List<ProductsInfo> GetProduct()
        //{
        //    string selectStatement = "SELECT itemName, itemPrice FROM Products";
        //    SqlCommand sqlCommand = new SqlCommand(selectStatement, sqlConnection);
        //    sqlConnection.Open();
        //    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

        //    var prodList = new List<ProductsInfo>();

        //    while (sqlDataReader.Read())
        //    {
        //        prodList.Add(new ProductsInfo
        //        {
        //            itemName = sqlDataReader["itemName"].ToString(),
        //            itemPrice = Convert.ToDouble(sqlDataReader["itemPrice"].ToString())

        //        });
        //    }
        //    sqlConnection.Close();

        //    return prodList;
        //}
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
        public bool DeleteProduct(string productsInfo)
        {
            string deleteStatement = "DELETE FROM Products WHERE itemName = @itemName";
            SqlCommand sqlCommand = new SqlCommand(deleteStatement, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@itemName", productsInfo);

            sqlConnection.Open();
            int boolValue = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return boolValue>0;
        }
        public bool UpdateProductInfos(ProductsInfo productToUpdate)
        {
            string selectStatement = "SELECT* FROM Products WHERE itemName = @itemName";
            string updateStatement = "UPDATE Products SET itemPrice = @itemPrice, itemCategory = @itemCategory, itemDescription = @itemDescription, itemRFS = @itemRFS WHERE itemName = @itemName";
            SqlCommand sqlUpdate = new SqlCommand(updateStatement, sqlConnection);
            SqlCommand sqlSelect = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            
            sqlSelect.Parameters.AddWithValue("@itemName", productToUpdate.itemName);
            SqlDataReader sqlDataReader = sqlSelect.ExecuteReader();

            bool foundRow = sqlDataReader.Read();
            if (foundRow)
            {
                double price = (productToUpdate.itemPrice == null) ? Convert.ToDouble(sqlDataReader["itemPrice"].ToString()) : productToUpdate.itemPrice;
                string category = (productToUpdate.itemCategory == "") ? sqlDataReader["itemCategory"].ToString() : productToUpdate.itemCategory;
                string description = (productToUpdate.itemDescription == "") ? sqlDataReader["itemDescription"].ToString() : productToUpdate.itemDescription;
                string rfs = (productToUpdate.itemRFS == "") ? sqlDataReader["itemRFS"].ToString() : productToUpdate.itemRFS;

                sqlDataReader.Close();

                sqlUpdate.Parameters.AddWithValue("@itemPrice", price);
                sqlUpdate.Parameters.AddWithValue("@itemCategory", category);
                sqlUpdate.Parameters.AddWithValue("@itemDescription", description);
                sqlUpdate.Parameters.AddWithValue("@itemRFS", rfs);
                sqlUpdate.Parameters.AddWithValue("@itemName", productToUpdate.itemName);

                sqlUpdate.ExecuteNonQuery();
            }

            sqlDataReader.Close();
            sqlConnection.Close();
            return foundRow;
        }

        //cart connections=====================================================================================================================
        public bool AddtoCart(string productName, string username)
        {
            string selectStatement = "SELECT itemName,itemPrice FROM Products WHERE itemName = @itemName";
            string insertStatement = "INSERT INTO Cart VALUES (@userName, @itemName, @itemPrice)";
            SqlCommand sqlSelect = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();

            sqlSelect.Parameters.AddWithValue("@itemName", productName);

            SqlDataReader sqlDataReader = sqlSelect.ExecuteReader();
            bool foundRow = sqlDataReader.Read();
            if (foundRow)
            {
                string prodName = sqlDataReader["itemName"].ToString();
                double ProdPrice = Convert.ToDouble(sqlDataReader["itemPrice"].ToString());
                sqlDataReader.Close();

                sqlConnection.Close();

                sqlConnection.Open();

                SqlCommand sqlAdd = new SqlCommand(insertStatement, sqlConnection);
                sqlAdd.Parameters.AddWithValue("@userName", username);
                sqlAdd.Parameters.AddWithValue("@itemName", prodName);
                sqlAdd.Parameters.AddWithValue("@itemPrice", ProdPrice);

                sqlAdd.ExecuteNonQuery();
            }
            sqlSelect.Dispose();
            sqlConnection.Close();
            return foundRow;
           
        }
        public List<Cart> GetCartItems(string username)
        {
            string selectStatement = "SELECT * FROM Cart WHERE userName = @userName";
            SqlCommand sqlCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();

            sqlCommand.Parameters.AddWithValue("@userName", username);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            var cartList = new List<Cart>();

            while (sqlDataReader.Read())
            {
                cartList.Add(new Cart
                {
                    userName = sqlDataReader["userName"].ToString(),
                    itemName = sqlDataReader["itemName"].ToString(),
                    itemPrice = Convert.ToDouble(sqlDataReader["itemPrice"])
                });
            }

            sqlDataReader.Close();
            sqlConnection.Close();

            return cartList;
        }
        public void RemoveFromCart(string itemName, string userName)
        {
            string deleteStatement = "DELETE FROM Cart WHERE itemName = @itemName AND userName = @userName";
            SqlCommand sqlCommand = new SqlCommand(deleteStatement, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@itemName", itemName);
            sqlCommand.Parameters.AddWithValue("@userName", userName);


            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void clearCart(string user)
        {
            string deleteStatement = "DELETE FROM Cart WHERE userName = @userName";
            SqlCommand sqlCommand = new SqlCommand(deleteStatement, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@userName", user);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        //user connections=====================================================================================================================
        public void InsertUserInfo(UserInfo userInfo)
        {
            string insertStatement = "INSERT INTO UserInfo VALUES (@username, @useraddress, @useremail, @usermobile)";
            SqlCommand sqlCommand = new SqlCommand(insertStatement, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@username", userInfo.username);
            sqlCommand.Parameters.AddWithValue("@useraddress", userInfo.useraddress);
            sqlCommand.Parameters.AddWithValue("@useremail", userInfo.useremail);
            sqlCommand.Parameters.AddWithValue("@usermobile", userInfo.usermobile);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public List<UserInfo> GetUserInfo(string username)
        {
            string selectStatement = "SELECT * FROM UserInfo WHERE username = @username";
            SqlCommand sqlCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();

            sqlCommand.Parameters.AddWithValue("@username", username);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            var userList = new List<UserInfo>();

            while (sqlDataReader.Read())
            {
                userList.Add(new UserInfo
                {
                    username = sqlDataReader["username"].ToString(),
                    useraddress = sqlDataReader["useraddress"].ToString(),
                    useremail = sqlDataReader["useremail"].ToString(),
                    usermobile = sqlDataReader["usermobile"].ToString()
                });
            }

            sqlDataReader.Close();
            sqlConnection.Close();

            return userList;
        }
        public bool UpdateUserInfos(UserInfo userToUpdate)
        {
            string selectStatement = "SELECT* FROM UserInfo WHERE username = @username";
            string updateStatement = "UPDATE UserInfo SET useraddress = @useraddress, useremail = @useremail, usermobile = @usermobile WHERE username = @username";
            SqlCommand sqlUpdate = new SqlCommand(updateStatement, sqlConnection);
            SqlCommand sqlSelect = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            sqlSelect.Parameters.AddWithValue("@username", userToUpdate.username);
            SqlDataReader sqlDataReader = sqlSelect.ExecuteReader();

            bool foundRow = sqlDataReader.Read();
            if (foundRow)
            {
                string address = (userToUpdate.useraddress == "") ? sqlDataReader["useraddress"].ToString() : userToUpdate.useraddress;
                string email = (userToUpdate.useremail == "") ? sqlDataReader["useremail"].ToString() : userToUpdate.useremail;
                string mobile = (userToUpdate.usermobile == "") ? sqlDataReader["usermobile"].ToString() : userToUpdate.usermobile;

                sqlDataReader.Close();

                sqlUpdate.Parameters.AddWithValue("@useraddress", address);
                sqlUpdate.Parameters.AddWithValue("@useremail", email);
                sqlUpdate.Parameters.AddWithValue("@usermobile", mobile);
                sqlUpdate.Parameters.AddWithValue("@username", userToUpdate.username);

                sqlUpdate.ExecuteNonQuery();
            }

            sqlDataReader.Close();
            sqlConnection.Close();
            return foundRow;
        }
    }
}
