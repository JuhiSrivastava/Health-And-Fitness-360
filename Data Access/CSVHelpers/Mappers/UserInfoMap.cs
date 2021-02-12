using CsvHelper.Configuration;
using Model_Object;
using System.Globalization;

namespace Data_Access.CSVHelpers.Mappers
{
    internal class UserInfoMap : ClassMap<UserInfoDO>
    {
        public UserInfoMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.ConfirmPassword).Ignore();
            Map(m => m.UserName).Index(0);
            Map(m => m.UserAge).Index(1);
            Map(m => m.UserHeight).Index(2);
            Map(m => m.UserWeight).Index(3);
            Map(m => m.UserMobile).Index(4);
            Map(m => m.EmailId).Index(5);
            Map(m => m.Password).Index(6);
            Map(m => m.Gender).Index(7);
        }
    }
}