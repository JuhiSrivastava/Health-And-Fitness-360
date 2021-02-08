using Model_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public class UserInfoDAL
    {
        private HealthAndFitnessDBEntities healthAndFitnessDBEntities;
        public UserInfoDAL()
        {
            healthAndFitnessDBEntities = new HealthAndFitnessDBEntities();
        }

        public CustomDO AddUser(UserInfoDO userInfo)
        {
            CustomDO custom = new CustomDO();
            UserInfo user = new UserInfo()
            {
                UserID  = userInfo.UserID,
                UserName = userInfo.UserName,
                UserAge = userInfo.UserAge,
                UserHeight = userInfo.UserHeight,
                UserWeight = userInfo.UserWeight,
                UserMobile = userInfo.UserMobile,
                Symptoms = userInfo.Symptoms
            };
            healthAndFitnessDBEntities.UserInfoes.Add(user);
            int returnVal = healthAndFitnessDBEntities.SaveChanges();
            custom.CustomId = returnVal;
            if (returnVal > 0)
            {
                custom.CustomMessage = "Data Successfully Added";
            }
            else
            {
                custom.CustomMessage = "Unable to Add User";
            }
            return custom;
        }
    }
}
