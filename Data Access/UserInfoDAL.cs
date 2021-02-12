using Data_Access.CSVHelpers.Mappers;
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
        private CSVHelper CSVHelper;
        public UserInfoDAL()
        {
            healthAndFitnessDBEntities = new HealthAndFitnessDBEntities();
            this.CSVHelper = new CSVHelper();
        }

        public CustomDO AddUser(UserInfoDO userInfo)
        {
            CustomDO custom = new CustomDO();
            /*UserInfo user = new UserInfo()
            {
                EmailId = userInfo.EmailId,
                UserName = userInfo.UserName,
                UserAge = userInfo.UserAge,
                Gender = userInfo.Gender,
                UserHeight = userInfo.UserHeight,
                UserWeight = userInfo.UserWeight,
                UserMobile = userInfo.UserMobile,
                Password = userInfo.Password
            };*/
            //healthAndFitnessDBEntities.UserInfoes.Add(user);
            //int returnVal = healthAndFitnessDBEntities.SaveChanges();

            this.CSVHelper.InsertRecord<UserInfoDO, UserInfoMap>(userInfo);

            custom.CustomId = 1;
            if (custom.CustomId > 0)
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
            //UserInfo user = healthAndFitnessDBEntities.UserInfoes.FirstOrDefault(x => x.EmailId.Equals(emailId) && x.Password.Equals(password));
            UserInfoDO user = this.CSVHelper.Read<UserInfoDO, UserInfoMap>().FirstOrDefault(x => x.EmailId.Equals(emailId) && x.Password.Equals(password));
            /*if (user != null)
            {
                userInfo.EmailId = user.EmailId;
                userInfo.UserName = user.UserName;
                userInfo.UserAge = user.UserAge;
                userInfo.Gender = user.Gender;
                userInfo.UserHeight = user.UserHeight;
                userInfo.UserWeight = user.UserWeight;
                userInfo.UserMobile = user.UserMobile;
                userInfo.Password = user.Password;
            }*/
            //return userInfo;
            return user;
        }

        public CustomDO UpdateUserInfo(UserInfoDO userInfo)
        {
            CustomDO custom = new CustomDO();
            //UserInfo user = healthAndFitnessDBEntities.UserInfoes.FirstOrDefault(x => x.EmailId.Equals(userInfo.EmailId));
            UserInfoDO user = this.CSVHelper.Read<UserInfoDO, UserInfoMap>().FirstOrDefault(x => x.EmailId.Equals(userInfo.EmailId) && x.Password.Equals(userInfo.Password));

            this.CSVHelper.DeleteRecord<UserInfoDO, UserInfoMap>(user, "UserName");

            //user.UserAge = userInfo.UserAge;
            //user.Gender = userInfo.Gender;
            //user.UserHeight = userInfo.UserHeight;
            //user.UserWeight = userInfo.UserWeight;

            //int returnVal = healthAndFitnessDBEntities.SaveChanges();
            this.CSVHelper.InsertRecord<UserInfoDO, UserInfoMap>(userInfo);

            int returnVal = 1;
            custom.CustomId = returnVal;
            if (returnVal > 0)
            {
                custom.CustomMessage = "Data Successfully Modified";
            }
            else
            {
                custom.CustomMessage = "Unable to Add User";
            }
            return custom;
        }
    }
}
