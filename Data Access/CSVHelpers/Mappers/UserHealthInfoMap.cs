using CsvHelper.Configuration;
using Model_Object;
using System.Globalization;

namespace Data_Access.CSVHelpers.Mappers
{
    internal class UserHealthInfoMap : ClassMap<UserHealthInfoDO>
    {
        public UserHealthInfoMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.EmailId).Index(0);
            Map(m => m.Calories_Day_1).Index(1);
            Map(m => m.Calories_Day_2).Index(2);
            Map(m => m.Calories_Day_3).Index(3);
            Map(m => m.Calories_Day_4).Index(4);
            Map(m => m.Calories_Day_5).Index(5);
            Map(m => m.Calories_Day_6).Index(6);
            Map(m => m.Calories_Day_7).Index(7);
            Map(m => m.CurrentCalories).Index(8);
            Map(m => m.PeriodDate).Index(9).TypeConverter<DateTimeConverter>();
            Map(m => m.FertilityDate).Index(10).TypeConverter<DateTimeConverter>();
            Map(m => m.Medication1).Index(11);
            Map(m => m.StartDateM1).Index(12).TypeConverter<DateTimeConverter>();
            Map(m => m.DurationM1).Index(13);
            Map(m => m.Medication2).Index(14);
            Map(m => m.StartDateM2).Index(15).TypeConverter<DateTimeConverter>();
            Map(m => m.DurationM2).Index(16);
            Map(m => m.MenstrualCycleDuration).Index(17);
            Map(m => m.PregnancyDate).Index(18).TypeConverter<DateTimeConverter>();
        }
    }
}