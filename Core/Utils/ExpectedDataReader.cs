using System;
using System.IO;
using Newtonsoft.Json;

namespace Core.Utils
{
    public static class ExpectedDataReader
    {   
        public static T GetExpectedData<T>(string fileName) where T: class
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
            
            var fullPath = path + $"\\{fileName}.json";
            var jsonStr = File.ReadAllText(fullPath);

            return JsonConvert.DeserializeObject<T>(jsonStr);
        }
    }
}
