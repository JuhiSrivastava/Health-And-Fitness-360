using CsvHelper.Configuration;
using Model_Object;
using System.Globalization;

namespace Data_Access.CSVHelpers.Mappers
{
    internal class UserSymptomsMap : ClassMap<UserSymptomsDO>
    {
        public UserSymptomsMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.EmailAddress).Index(0);
            Map(m => m.Symptoms).Index(1);
        }
    }
}
