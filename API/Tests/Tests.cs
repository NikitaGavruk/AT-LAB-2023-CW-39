using NUnit.Framework;
using RestSharp;
using System.Net;
using Core.enums;

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
    }
}
