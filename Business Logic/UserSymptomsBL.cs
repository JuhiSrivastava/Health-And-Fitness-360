using Data_Access;
using Model_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class UserSymptomsBL
    {
        public CustomDO AddSymptoms(string emailId, List<string> symptoms)
        {
            emailId = UserInfoBL.EncodeItemToBase64(emailId);
            CustomDO custom = new UserSymptomsDAL().AddSymptoms(emailId, symptoms);
            return custom;
        }
        public List<UserSymptomsDO> GetSymptoms(string emailId)
        {
            emailId = UserInfoBL.EncodeItemToBase64(emailId);
            List < UserSymptomsDO > userSymptoms = new UserSymptomsDAL().GetSymptoms(emailId);
            foreach(UserSymptomsDO userSymptom in userSymptoms)
                userSymptom.EmailAddress = UserInfoBL.DecodeFrom64(userSymptom.EmailAddress);
            return userSymptoms;
        }
    }
}
