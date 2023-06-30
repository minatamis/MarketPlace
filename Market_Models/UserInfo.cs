using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Models
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserMobile { get; set; }

        public static UserInfo Find(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }

}
