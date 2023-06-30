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
        public static void getUser(UserInfo user)
        {
            UserDataServices.users.Add(user);
        }
        public static UserInfo retrieveUser(string user)
        {
            foreach (var userr in UserDataServices.users)
            {
                if (userr.username.Contains(user))
                {
                    return userr;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
        public void SaveUserData(string userName, string userAddress, String userEmail, int userMobile)
        {
            UserInfo newUser = new UserInfo
            {
                username = userName,
                useraddress = userAddress,
                userEmail = userEmail,
                usermobile = userMobile
            };

            UserDataServices.users.Add(newUser);

        }
    }
}
