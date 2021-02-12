using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Data_Access
{
    internal class CSVHelper
    {
        private string _basePath;

        public CSVHelper()
        {
            var appDomain = System.AppDomain.CurrentDomain;
            this._basePath = appDomain.BaseDirectory;
        }

        public List<T> Read<T, TMap>() where TMap : ClassMap<T>
        {
            List<T> returnValues = new List<T>();

            try
            {
                using (var reader = new StreamReader($"{this._basePath}\\CSVData\\{typeof(T).Name}.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Configuration.RegisterClassMap<TMap>();
                        returnValues = csv.GetRecords<T>()?.ToList();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Data for {typeof(T).Name} not found.");
            }

            return returnValues;
        }

        public void InsertList<T, TMap>(List<T> records) where TMap : ClassMap<T>
        {
            try
            {
                using (var writer = new StreamWriter($"{this._basePath}\\CSVData\\{typeof(T).Name}.csv"))
                {
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.Configuration.RegisterClassMap<TMap>();
                        csv.WriteRecords<T>(records);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Data list Insert failed for {typeof(T).Name}.");
            }
        }

        public void InsertRecord<T, TMap>(T record) where TMap : ClassMap<T>
        {
            try
            {
                // Do not include the header row if the file already exists
                CsvConfiguration csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
                {
                    HasHeaderRecord = !File.Exists($"{this._basePath}\\CSVData\\{typeof(T).Name}.csv")
                };

                using (var stream = new FileStream($"{this._basePath}\\CSVData\\{typeof(T).Name}.csv", FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        using (var csv = new CsvWriter(writer, csvConfig))
                        {
                            csv.Configuration.RegisterClassMap<TMap>();

                            csv.WriteRecord(record);
                            writer.Write("\n");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Record Insert failed for {typeof(T).Name}.");
            }
        }

        public void DeleteRecord<T, TMap>(T record, string Key) where TMap : ClassMap<T>
        {
            try
            {
                List<T> existingRecords = this.Read<T, TMap>();

                PropertyInfo property = typeof(T).GetProperty(Key);

                object recordToDelete = property.GetValue(record, null);

                //compare and delete the record.
                for (int i = 0; i < existingRecords.Count; i++)
                {
                    object value = property.GetValue(existingRecords[i], null);

                    if (recordToDelete?.ToString() == value?.ToString())
                    {
                        existingRecords.RemoveAt(i);
                    }
                }

                this.InsertList<T, TMap>(existingRecords);
            }
            catch
            {
                throw new Exception($"Delete failed for {typeof(T).Name}.");
            }
        }

        public void UpdateRecord<T, TMap>(T record, string Key) where TMap : ClassMap<T>
        {
            try
            {
                List<T> existingRecords = this.Read<T, TMap>();

                PropertyInfo property = typeof(T).GetProperty(Key);

                object recordToUpdate = property.GetValue(record, null);

                //compare and update record.
                for (int i = 0; i < existingRecords.Count; i++)
                {
                    object value = property.GetValue(existingRecords[i], null);

                    if (recordToUpdate?.ToString() == value?.ToString())
                    {
                        existingRecords[i] = record;
                    }
                }

                this.InsertList<T, TMap>(existingRecords);
            }
            catch
            {
                throw new Exception($"Update failed for {typeof(T).Name}.");
            }
        }
    }
}