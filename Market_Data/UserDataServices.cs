using Market_Models;
using MarketDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Data
{
    public class UserDataServices
    {
        private List<UserInfo> users;
        DatabaseManager userData;

        public UserDataServices()
        {
            users = new List<UserInfo>();
            userData = new DatabaseManager();
        }
        public void AddUser(UserInfo user)
        {
            userData.InsertUserInfo(user);
        }
    }
}