using Core.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
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
            string path = $"{Environment.CurrentDirectory}/core/resources";
            string fileName = "userData.json";
            var configuration = InitConfiguration(path, fileName);
            return new User(configuration["username"], configuration["password"]);
        }

        public static string GetTestUsername()
        {
            return GetUserData().GetUserName();
        }

        public static string GetTestUserPassword()
        {
            return GetUserData().GetPassword();
        }
    }
}
