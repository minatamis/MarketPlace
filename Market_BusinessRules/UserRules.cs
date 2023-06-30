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
    }
}
