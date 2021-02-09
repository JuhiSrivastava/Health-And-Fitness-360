using Model_Object;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
                EmailId  = userInfo.EmailId,
                UserName = userInfo.UserName,
                UserAge = userInfo.UserAge,
                UserHeight = userInfo.UserHeight,
                UserWeight = userInfo.UserWeight,
                UserMobile = userInfo.UserMobile,
                Password = userInfo.Password
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

        public UserInfoDO GetUser(string emailId, string password)
        {
            UserInfoDO userInfo = new UserInfoDO();
            UserInfo user = healthAndFitnessDBEntities.UserInfoes.FirstOrDefault(x => x.EmailId.Equals(emailId) && x.Password.Equals(password));
            if (user != null)
            {
                userInfo.EmailId = user.EmailId;
                userInfo.UserName = user.UserName;
                userInfo.UserAge = user.UserAge;
                userInfo.UserHeight = user.UserHeight;
                userInfo.UserWeight = user.UserWeight;
                userInfo.UserMobile = user.UserMobile;
                userInfo.Password = userInfo.Password;
            }
            return userInfo;
        }
    }
}
