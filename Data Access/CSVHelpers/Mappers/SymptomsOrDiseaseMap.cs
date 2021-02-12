using CsvHelper.Configuration;
using Model_Object;
using System.Globalization;

namespace Data_Access.CSVHelpers.Mappers
{
    internal class SymptomsOrDiseaseMap : ClassMap<SymptomsOrDiseaseDO>
    {
        public SymptomsOrDiseaseMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.SymptomsOrDiseaseName).Index(0);
            Map(m => m.Medication).Index(1);
            Map(m => m.Tests).Index(2);
            Map(m => m.Cure).Index(3);
        }
    }
}
