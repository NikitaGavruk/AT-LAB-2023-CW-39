using System;
using System.IO;
using Core.enums;
using Newtonsoft.Json;

namespace Core.Utils
{
    public static class ExpectedDataReader
    {   
        public static T GetExpectedData<T>(Resources fileType) where T: class
        {
            string path;

            if (Environment.CurrentDirectory.EndsWith("AT-LAB-2023-CW-39"))
            {
                path = $"{Environment.CurrentDirectory}/Core/resources";
            }
            else if (Environment.CurrentDirectory.EndsWith("UI"))
            {
                path = $"{Directory.GetParent(Environment.CurrentDirectory)}/Core/resources";
            }
            else
            {
                path = $"{AppDomain.CurrentDomain.BaseDirectory}/resources";
            }

            var fileName = GetFileName(fileType);
            var fullPath = path + $"\\{fileName}.json";
            var jsonStr = File.ReadAllText(fullPath);

            return JsonConvert.DeserializeObject<T>(jsonStr);
        }
        
        private static string GetFileName(Resources fileType)
        {
            switch (fileType)
            {
                case Resources.ApiResources:
                    return "apiResources";
                case Resources.ExpectedData:
                    return "expectedData";
                case Resources.UserData:
                    return "userData";
                case Resources.DriverCapabilitys:
                    return "driverCapabilitys";
                default:
                    throw new ArgumentException("Invalid file type");
            }
        }
    }
}
