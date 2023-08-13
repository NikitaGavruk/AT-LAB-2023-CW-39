using API.APIUtils;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Linq;
using System.Net;
using Core.enums;
using Core.Utils;

namespace API.Tests
{
    [TestFixture]
    public class Tests : BaseTest
    {
        [Test]
        public void GetArticlePdfRequest()
        {
            string url = "page/pdf/Mikhail_Lomonosov";
            string expectedContentType = TestDataReader.GetExpectedData("contentType");

            logger.LogInfo(LogLevel.Info, $"Create GET request taking the endpoint {url}");
            RestRequest request = api.CreateGetRequest(url, ("accept", "application/pdf"));
            logger.LogInfo(LogLevel.Info, "Send the request and get the response");
            RestResponse response = api.GetResponse(request);
            string actualContentType = response.ContentType;

            logger.LogInfo(LogLevel.Info, "Check if the response content is compare to expected");
            Assert.That(actualContentType, Is.EqualTo(expectedContentType));
        }

        [Test]
        public void GetLinterError()
        {
            RestRequest request = api.CreateGetRequest("https://en.wikipedia.org/api/rest_v1/page/lint/formula_1");
            RestResponse response = api.GetResponse(request);

            logger.LogInfo(LogLevel.Info, "Make and API request and get the response");
            Assert.That(response.StatusCode == HttpStatusCode.OK);
            logger.LogInfo(LogLevel.Info, "Get the status code and compare it with OK");

            string responseBody = response.Content;
            logger.LogInfo(LogLevel.Info, "Get response body");

            string expectedResponseBody = "[{\"type\":\"missing-end-tag\",\"dsr\":[120305,120333,3,0],\"params\":{\"name\":\"b\",\"inTable\":true}}]";
            logger.LogInfo(LogLevel.Info, "Compare it to expected data");
            Assert.AreEqual(responseBody, expectedResponseBody, "Response body does not match expected result");
        }
    }
}
