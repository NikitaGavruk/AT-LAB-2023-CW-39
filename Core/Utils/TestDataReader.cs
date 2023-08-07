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
            string path = "";

            if (Environment.CurrentDirectory.EndsWith("AT-LAB-2023-CW-39"))
            {
                path = $"{Environment.CurrentDirectory}/Core/resources";
            }
            else if (Environment.CurrentDirectory.EndsWith("UI"))
            {
                path = $"{Directory.GetParent(Environment.CurrentDirectory)}/Core/resources";
            }
            else
                throw new DirectoryNotFoundException();

            string fileName = "userData.json";
            var configuration = InitConfiguration(path, fileName);
            
            return new User(configuration["username"], configuration["password"]);
        }

        public static string GetTestUsername() => GetUserData().GetUserName();

        public static string GetTestUserPassword() => GetUserData().GetPassword();
    }
}
