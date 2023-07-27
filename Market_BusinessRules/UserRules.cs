using Market_Data;
using Market_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_BusinessRules
{
    public class UserRules
    {
        UserDataServices userDataServices;
        public UserRules()
        {
            userDataServices = new UserDataServices();
        }

        public void addUser(UserInfo user)
        {
            userDataServices.AddUser(user);

        }
        public List<UserInfo> getUserInfo(string username)
        {
            return userDataServices.getUser(username);

        }
    }
}
