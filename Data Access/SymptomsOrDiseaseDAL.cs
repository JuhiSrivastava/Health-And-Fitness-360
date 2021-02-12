using Data_Access.CSVHelpers.Mappers;
using Model_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public class SymptomsOrDiseaseDAL
    {
        private HealthAndFitnessDBEntities healthAndFitnessDBEntities;
        private CSVHelper CSVHelper;
        public SymptomsOrDiseaseDAL()
        {
            healthAndFitnessDBEntities = new HealthAndFitnessDBEntities();
            this.CSVHelper = new CSVHelper();
        }
        public SymptomsOrDiseaseDO GetSymptomsOrDiseaseDetails(string symptoms)
        {
            /*SymptomsOrDiseaseDO symptomsOrDiseaseDO = new SymptomsOrDiseaseDO();
            SymptomsOrDisease symptomsOrDisease = healthAndFitnessDBEntities.SymptomsOrDiseases.FirstOrDefault(x => x.SymptomsOrDiseaseName.Equals(symptoms));
            if (symptomsOrDisease != null)
            {
                symptomsOrDiseaseDO.SymptomsOrDiseaseName = symptomsOrDisease.SymptomsOrDiseaseName;
                symptomsOrDiseaseDO.Medication = symptomsOrDisease.Medication;
                symptomsOrDiseaseDO.Tests = symptomsOrDisease.Tests;
                symptomsOrDiseaseDO.Cure = symptomsOrDisease.Cure;
            }
            return symptomsOrDiseaseDO;*/
            SymptomsOrDiseaseDO symptomsOrDiseaseDO = this.CSVHelper.Read<SymptomsOrDiseaseDO, SymptomsOrDiseaseMap>().FirstOrDefault(x => x.SymptomsOrDiseaseName.Equals(symptoms));
            return symptomsOrDiseaseDO;

        }

    }
}
