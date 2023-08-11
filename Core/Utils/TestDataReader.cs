using Core.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Core.Utils
{
    public class TestDataReader
    {
        public static IConfiguration InitConfiguration(string path, string fileName)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile(fileName)
                .Build();
            
            return configuration;
        }

        public static User GetUserData()
        {            
            string path = $"{AppDomain.CurrentDomain.BaseDirectory}/resources";
            string fileName = "userData.json";
            var configuration = InitConfiguration(path, fileName);
            
            return new User(configuration["username"], configuration["password"]);
        }

        public static string GetTestUsername() => GetUserData().GetUserName();

        public static string GetTestUserPassword() => GetUserData().GetPassword();

        public static string GetExpectedData(string parameter)
        {
            string path = $"{AppDomain.CurrentDomain.BaseDirectory}/resources";
            string fileName = "expectedData.json";
            var configuration = InitConfiguration(path, fileName);

            return configuration[parameter];

        }
    }
}
