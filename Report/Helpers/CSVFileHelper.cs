using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Helpers
{
    public class CSVFileHelper
    {
        private static CSVFileHelper _instance;

        private CsvConfiguration config;

        private CSVFileHelper()
        {
            config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
            };
        }

        public static CSVFileHelper Instance()
        {
            if (null == _instance)
                _instance = new CSVFileHelper();
            return _instance;
        }

        public List<T> ConvertClass<T>(string filePath)
        {
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HeaderValidated = null,
                    MissingFieldFound = null
                };
                using (var reader = new StreamReader(filePath))
                {
                    using (var csv = new CsvReader(reader, config))
                    {
                        var tests = csv.GetRecords<T>().ToList();
                        return tests;
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
        }

        public void Save<T>(IList<T> records, string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords<T>(records);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private static void MissingFieldFound(MissingFieldFoundArgs args)
        {
            for (var i = 0; i < args.HeaderNames.Length; i++)
            {
                Console.WriteLine(args.HeaderNames[i]);
            }
        }


    }
}
