using Data_Access.CSVHelpers.Mappers;
using Model_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public class UserSymptomsDAL
    {
        private HealthAndFitnessDBEntities healthAndFitnessDBEntities;
        private CSVHelper CSVHelper;
        public UserSymptomsDAL()
        {
            healthAndFitnessDBEntities = new HealthAndFitnessDBEntities();
            this.CSVHelper = new CSVHelper();
        }

        public CustomDO AddSymptoms(string emailId, List<string> symptoms)
        {
            CustomDO custom = new CustomDO();
            foreach (string symptom in symptoms)
            {
                /*UserSymptom userSymptom = new UserSymptom()
                {
                    EmailAddress = emailId,
                    Symptoms = symptom
                };*/
                //healthAndFitnessDBEntities.UserSymptoms.Add(userSymptom);
                //int returnVal = healthAndFitnessDBEntities.SaveChanges();

                UserSymptomsDO userSymptom = new UserSymptomsDO()
                {
                    EmailAddress = emailId,
                    Symptoms = symptom
                };
                this.CSVHelper.InsertRecord<UserSymptomsDO, UserSymptomsMap>(userSymptom);
                custom.CustomId = 1;
                int returnVal = 1;
                if (returnVal > 0)
                {
                    custom.CustomMessage = "Data Successfully Added";
                }
                else
                {
                    custom.CustomMessage = "Unable to Add User";
                    return custom;
                }
            }
            return custom;
        }

        public List<UserSymptomsDO> GetSymptoms(string emailId)
        {
            List<UserSymptomsDO> userSymptomsList = new List<UserSymptomsDO>();
            //List<UserSymptom> userSymptoms = healthAndFitnessDBEntities.UserSymptoms.Where(x => x.EmailAddress.Equals(emailId)).ToList();
            List<UserSymptomsDO> userSymptoms = this.CSVHelper.Read<UserSymptomsDO, UserSymptomsMap>().Where(x => x.EmailAddress.Equals(emailId)).ToList();
            /*
            foreach (UserSymptom symptom in userSymptoms)
            {
                UserSymptomsDO userSymptom = new UserSymptomsDO();
                if (symptom !=null)
                {
                    userSymptom.EmailAddress = symptom.EmailAddress;
                    userSymptom.Symptoms = symptom.Symptoms;
                   
                    userSymptomsList.Add(userSymptom);
                }
            }
            return userSymptomsList;*/
            return userSymptoms;
        }
    }
}
