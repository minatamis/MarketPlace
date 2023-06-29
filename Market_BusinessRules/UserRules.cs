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

    }
}
