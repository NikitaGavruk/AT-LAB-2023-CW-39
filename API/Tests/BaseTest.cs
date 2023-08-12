using API.APIUtils;
using Core.enums;
using Core.Interfaces;
using Core.Model;
using Core.Utils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace API.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected APIUtils.API api;
        protected Client client;
        protected ICustomLogger logger;

        protected static ApiResourcesModel ApiResourcesData;
        
        [SetUp]
        public void SetUp()
        {
            client = Client.Instance;
            api = new APIUtils.API();
            logger = new CustomLogger();
            
            ApiResourcesData = ExpectedDataReader.GetExpectedData<ApiResourcesModel>(Resources.ApiResources);
        }

        [TearDown]
        public void Quit()
        {
            TestStatus NUnit_status = TestContext.CurrentContext.Result.Outcome.Status;

            if (NUnit_status.Equals(TestStatus.Failed))
            {
                var failMessage = $"[{TestContext.CurrentContext.Test.Name}] Test failed with Status: " +
                    TestContext.CurrentContext.Result.Message;
                logger.LogInfo(LogLevel.Error, failMessage);                
            }
            else
            {
                var statusMessage = $"[{TestContext.CurrentContext.Test.Name}] Test ended with Status: " +
                    TestContext.CurrentContext.Result.Outcome.Status.ToString();
                logger.LogInfo(LogLevel.Info, statusMessage);
            }

            Client.QuitClient();
            APIUtils.API.CloseRequest();
        }
    }
}
