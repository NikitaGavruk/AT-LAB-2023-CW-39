using API.APIUtils;
using Core.Utils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Core.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Model;

namespace API.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected APIUtils.API api;
        protected Client client;
        protected ICustomLogger logger;

        [SetUp]
        public void SetUp()
        {
            client = Client.Instance;
            api = new APIUtils.API();
            logger = new CustomLogger();
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
