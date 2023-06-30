using Market_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Data
{
    public class UserDataServices
    {
        public static  List<UserInfo> users = new List<UserInfo>();
        public void SaveUserData(string userName, string userAddress, string userEmail, int userMobile)
        {
            UserInfo newUser = new UserInfo
            {
                username = userName,
                useraddress = userAddress,
                useremail = userEmail,
                usermobile = userMobile
            };

            users.Add(newUser);
            Console.WriteLine("User data saved successfully.");
        }
    }
}