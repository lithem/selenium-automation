using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Pages
{
    public class DuckDuckGoPage
    {
        private readonly IWebDriver _webDriver;
        private readonly WebDriverWait _wait;

        public DuckDuckGoPage(IWebDriver webDriver, WebDriverWait wait)
        {
            _webDriver = webDriver;
            _wait = wait;
        }

        private readonly By searchBarBy = By.Id("search_form_input_homepage");
        private readonly By searchResultsContainerBy = By.ClassName("results--main");

        public void Search(string searchTerm)
        {
            var searchBar = _wait.Until(ExpectedConditions.ElementToBeClickable(searchBarBy));
            searchBar.Clear();
            searchBar.SendKeys(searchTerm);
            searchBar.SendKeys(Keys.Enter);

            _wait.Until(ExpectedConditions.ElementIsVisible(searchResultsContainerBy));
        }

        public bool IsSearchResultsPageDisplayed()
        {
            return _webDriver.FindElement(searchResultsContainerBy).Displayed;
        }
    }
}
