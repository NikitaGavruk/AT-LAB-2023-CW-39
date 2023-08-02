using NUnit.Framework;

namespace UI.Tests
{
    [TestFixture]
    public class DisplayAboutPageTest : BaseTest
    {
        [Test]
        public void DisplayAboutPageTest_Success()
        {
            var expectedHeading = "Wikipedia:About";
            var username = "Shokirov Abdulaziz";
            var password = "NAS9iFp.3.,T%d,";

            var aboutPage = MainPage
                .ToLoginPage()
                .EnterUsername(username)
                .EnterPassword(password)
                .ClickToLoginButton()
                .ClickAboutWikipediaLink();

            Assert.AreEqual(expectedHeading, aboutPage.GetActualHeading());
        }
    }
}