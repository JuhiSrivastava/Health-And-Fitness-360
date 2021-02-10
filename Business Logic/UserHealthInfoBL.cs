using Model_Object;
using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class UserHealthInfoBL
    {
        public CustomDO AddUserHealthInfo(UserHealthInfoDO userHealthInfo)
        {
            return new UserHealthInfoDAL().AddUserHealthInfo(userHealthInfo);
        }
        public UserHealthInfoDO GetUserHealthInfo(string emailId)
        {
            return new UserHealthInfoDAL().GetUserHealthInfo(emailId);
        }
    }
}
