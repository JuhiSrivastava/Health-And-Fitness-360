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
            return new UserSymptomsDAL().AddSymptoms(emailId, symptoms);
        }
        public List<UserSymptomsDO> GetSymptoms(string emailId)
        {
            return new UserSymptomsDAL().GetSymptoms(emailId);
        }
    }
}
