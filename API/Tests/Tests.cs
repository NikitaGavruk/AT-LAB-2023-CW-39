using NUnit.Framework;
using RestSharp;
using System.Net;
using Core.enums;
using System.Collections.Generic;

namespace API.Tests
{
    [TestFixture]
    public class Tests : BaseTest
    {
        [Test]
        public void GetArticlePdfRequest()
        {
            var url = ApiResourcesData.PdfRequestEndpoint;
            var expectedContentType = ApiResourcesData.PdfRequestContentType;

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
        
        [Test]
        public void GetTitleMetadataRequest()
        {
            var endPoint = ApiResourcesData.MetadataRequestEndpoint;
            var expectedContentType = ApiResourcesData.MetadataRequestContentType;

            logger.LogInfo(LogLevel.Info, $"Create GET request taking the endpoint {endPoint}");
            RestRequest request = api.CreateGetRequest(endPoint, ("accept", "application/json"));
            logger.LogInfo(LogLevel.Info, "Send the request and get the response");
            RestResponse response = api.GetResponse(request);

            logger.LogInfo(LogLevel.Info, "Check if the response status code is OK");
            Assert.That(response.StatusCode == HttpStatusCode.OK);

            logger.LogInfo(LogLevel.Info, "Check if the response content type matches the expected content type");
            Assert.That(response.ContentType, Is.EqualTo(expectedContentType));
        }

        [Test]
        public void GetApiPageItemsRequest()
        {
            string url = ApiResourcesData.PageItemsRequestEndpoint;
            var expectedContent = ApiResourcesData.PageItems;

            logger.LogInfo(LogLevel.Info, $"Create GET request taking the endpoint {url}");
            RestRequest request = api.CreateGetRequest(url, ("accept", "application/json"));
            logger.LogInfo(LogLevel.Info, "Send the request and get the response");
            RestResponse response = api.GetResponse(request);
            var actualContent = api.DeserializeToClass<Dictionary<string, string[]>>(response);

            logger.LogInfo(LogLevel.Info, "Check if the response content is compare to expected");
            Assert.That(actualContent, Is.EqualTo(expectedContent));
        }
    }
}
