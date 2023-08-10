using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace API.APIUtils
{
    public class ResponseReader
    {
        public static string GetResponseParameterValue(RestResponse response, string parameter)
        {
            var jsonObject = GetJsonFromResponse(response);
            JArray itemsArray = (JArray)jsonObject["items"];
            
            //default value. may be change to work with objects where more items
            JObject item = (JObject)itemsArray[0]; 
            
            return (string)item[parameter];
        }

        public static JObject GetJsonFromResponse(RestResponse response)
        {
            if (response == null && response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception($"Response error. Status code {response.StatusCode}");
            string jsonResponse = response.Content;
            
            return JObject.Parse(jsonResponse);
        }
    }
}
