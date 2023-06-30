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

        public static void addUser(UserInfo user)
        {
            UserDataServices.users.Add(user);

        }
        public static void removeUser(UserInfo user)
        {
            UserDataServices.users.Remove(user);

        }

        public void SaveUserData(string userName, string userAddress, int userMobile)
        {
            UserInfo newUser = new UserInfo
            {
                username = userName,
                useraddress = userAddress,
                usermobile = userMobile
            };

            UserDataServices.users.Add(newUser);

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

        public UserInfo UpdateUserData(string userName, string userAddress, int userMobile)
        {
            UserInfo existingUser = retrieveUser(userName);

            if (existingUser != null)
            {
                existingUser.useraddress = userAddress;
                existingUser.usermobile = userMobile;

                return existingUser;
            }
            else
            {
                return null;
            }
        }

    }
}
