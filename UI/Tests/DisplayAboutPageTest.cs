using Core;
using NUnit.Framework;

namespace UI.Tests
{
    [TestFixture]
    public class DisplayAboutPageTest : BaseTest
    {
        [Test]
        [Category("Display")]
        public void DisplayAboutPageTest_Success()
        {
            var aboutPage = MainPage
                .ToLoginPage()
                .EnterUsername(TestDataReader.GetTestUsername())
                .EnterPassword(TestDataReader.GetTestUserPassword())
                .ClickToLoginButton()
                .ClickAboutWikipediaLink();

            Assert.AreEqual(ExpectedDataReader.GetAboutPageHeading(), aboutPage.GetActualHeading());
        }
    }
}