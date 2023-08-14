using Core.Model;
using Microsoft.Extensions.Configuration;
using System;

namespace Core.Utils
{
    public class TestDataReader
    {
        private static IConfiguration InitConfiguration(string path, string fileName)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile(fileName)
                .Build();
            
            return configuration;
        }

        private static User GetUserData()
        {            
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}/resources";
            var fileName = "userData.json";
            var configuration = InitConfiguration(path, fileName);
            
            return new User(configuration["username"], configuration["password"]);
        }

        public static string GetTestUsername() => GetUserData().GetUserName();

        public static string GetTestUserPassword() => GetUserData().GetPassword();

        public static string GetExpectedData(string parameter)
        {
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}/resources";
            var fileName = "expectedData.json";
            var configuration = InitConfiguration(path, fileName);

            return configuration[parameter];
        }
    }
}
