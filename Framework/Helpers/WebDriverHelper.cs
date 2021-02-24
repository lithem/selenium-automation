using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Framework.Helpers
{
    public static class WebDriverHelper
    {
        public static IWebDriver WebDriver;
        public static WebDriverWait Wait;

        public static void SetupWebDriver()
        {
            if (WebDriver == null)
            {
                switch (Settings.Browser.ToLower())
                {
                    case "firefox":
                        WebDriver = new FirefoxDriver();
                        break;
                    default:
                        break;
                }

                if(Settings.Maximize == true)
                {
                    WebDriver.Manage().Window.Maximize();
                }
            }

            if(Wait == null)
            {
                Wait = new WebDriverWait(WebDriver, new System.TimeSpan(0, 0, Settings.WaitTimeOutSeconds));
            }
        }

        public static void CloseWebDriver()
        {
            if(WebDriver != null)
            {
                WebDriver.Close();
                WebDriver.Quit();

                WebDriver = null;
            }
        }
    }
}