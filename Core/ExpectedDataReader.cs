using System;
using System.IO;
using Core.Model;
using Newtonsoft.Json;

namespace Core
{
    public static class ExpectedDataReader
    {   
        public static ExpectedDataModel GetExpectedData()
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
                throw new DirectoryNotFoundException();

            var fileName = "expectedData.json";
            var fullPath = path + $"\\{fileName}";
            var jsonStr = File.ReadAllText(fullPath);

            return JsonConvert.DeserializeObject<ExpectedDataModel>(jsonStr);
        }

        public static string GetAboutPageHeading()
        {
            return GetExpectedData().ExpectedHeadingInAboutPage;
        }

        public static string GetTitleOfRussianLanguage()
        {
            return GetExpectedData().TitleOfRussianLanguage;
        }
        
        public static string GetTitleOfEnglishLanguage()
        {
            return GetExpectedData().TitleOfEnglishLanguage;
        }
        
        public static string GetTitleOfUzbekLanguage()
        {
            return GetExpectedData().TitleOfUzbekLanguage;
        }

        public static string GetArticle()
        {
            return GetExpectedData().ArticleToBeSearched;
        }
    }
}
