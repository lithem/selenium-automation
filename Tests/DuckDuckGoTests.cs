using Pages;
using Framework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DuckDuckGoTests
    {
        DuckDuckGoPage _duckDuckGoPage;

        [TestInitialize]
        public void SetUp()
        {
            WebDriverHelper.SetupWebDriver();
        }

        [TestMethod]
        public void Search()
        {
            _duckDuckGoPage = new DuckDuckGoPage(WebDriverHelper.WebDriver, WebDriverHelper.Wait);

            WebDriverHelper.WebDriver.Navigate().GoToUrl("https://duckduckgo.com");
            _duckDuckGoPage.Search("Selenium Testing");
            Assert.IsTrue(_duckDuckGoPage.IsSearchResultsPageDisplayed());
        }

        [TestCleanup]
        public void CleanUp()
        {
            WebDriverHelper.CloseWebDriver();
        }
    }
}
