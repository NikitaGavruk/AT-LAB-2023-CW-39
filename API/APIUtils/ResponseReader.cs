using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.APIUtils
{
    public class ResponseReader
    {
        public static string GetResponseParameterValue(RestResponse response, string parameter)
        {
            var jsonObject = GetJsonFromResponse(response);
            JArray itemsArray = (JArray)jsonObject["items"];
            JObject item = (JObject)itemsArray[0];  //default value. may be change to work with objects where more items
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
