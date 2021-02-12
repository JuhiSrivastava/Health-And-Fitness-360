using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Globalization;

namespace Data_Access.CSVHelpers
{
    public class DateTimeConverter : ITypeConverter
    {
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            DateTime dateTime;
            if (text == null || text.Length == 0)
                return new DateTime();
            if (DateTime.TryParseExact(text, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture,DateTimeStyles.None, out dateTime))
            {
                return dateTime;
            }

            return text;
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            if (value is DateTime date)
            {
                return date.ToString("yyyy-MM-dd hh:mm:ss");
            }
            return value?.ToString() ?? string.Empty;
        }
    }
}