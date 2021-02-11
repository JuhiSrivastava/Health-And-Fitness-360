using Data_Access;
using Model_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class UserInfoBL
    {
        public CustomDO AddUser(UserInfoDO userInfo)
        {
            userInfo.EmailId = EncodeItemToBase64(userInfo.EmailId);
            userInfo.UserMobile = EncodeItemToBase64(userInfo.UserMobile);
            CustomDO custom = new UserInfoDAL().AddUser(userInfo);
            userInfo.EmailId = DecodeFrom64(userInfo.EmailId);
            userInfo.UserMobile = DecodeFrom64(userInfo.UserMobile);
            return custom;
        }
        public UserInfoDO GetUser(string emailId, string password)
        {
            emailId = EncodeItemToBase64(emailId);
            UserInfoDO userInfo = new UserInfoDAL().GetUser(emailId, password);
            userInfo.EmailId = DecodeFrom64(userInfo.EmailId);
            userInfo.UserMobile = DecodeFrom64(userInfo.UserMobile);
            return userInfo;
        }
        public CustomDO UpdateUserInfo(UserInfoDO userInfo)
        {
            userInfo.EmailId = EncodeItemToBase64(userInfo.EmailId);
            userInfo.UserMobile = EncodeItemToBase64(userInfo.UserMobile);
            CustomDO custom = new UserInfoDAL().UpdateUserInfo(userInfo);
            userInfo.EmailId = DecodeFrom64(userInfo.EmailId);
            userInfo.UserMobile = DecodeFrom64(userInfo.UserMobile);
            return custom;
        }
        public string BMICalculation(double height, double weight, int age)
        {
            double bmi = (weight / (height * height));
            string healthMonitor = "";
            if (age < 18)
            {
                healthMonitor += "4";
            }
            else
            {
                if (bmi < 16)
                    healthMonitor += "1";
                else if (bmi >= 16 && bmi < 17)
                    healthMonitor += "2";
                else if (bmi >=17 && bmi < 18.5)
                    healthMonitor += "3";
                else if (bmi >=18.5 && bmi < 25)
                    healthMonitor += "4";
                else if (bmi >=25 && bmi < 30)
                    healthMonitor += "5";
                else if (bmi >= 30 && bmi < 35)
                    healthMonitor += "6";
                else if (bmi >= 35 && bmi < 40)
                    healthMonitor += "7";
                else
                    healthMonitor += "8";
            }
            healthMonitor += " " + bmi.ToString();
            return healthMonitor;
        }
        //this function Convert to Encode
        public static string EncodeItemToBase64(string data)
        {
            try
            {
                byte[] encData_byte = new byte[data.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(data);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        } //this function Convert to Decode
        public static string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
    }
}
