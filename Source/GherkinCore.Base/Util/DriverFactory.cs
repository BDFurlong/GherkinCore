using GherkinCore.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace GherkinCore.Base.Util
{
    public static class DriverFactory
    {
        public static IWebDriver Driver(string driverName)
        {
            ////TODO: handle default case here?
            //IWebDriver driver = null;

            //switch (driverName)
            //{
            //    case "Firefox":
            //        driver = new FirefoxDriver();
            //        break;

            //    case "Chrome":
            //        driver = new ChromeDriver();
            //        break;

            //    case "PhantomJS":
            //        driver = new PhantomJSDriver();
            //        break;

            //    case "IE":
            //        driver = new InternetExplorerDriver();
            //        break;

            //    //case "Remote":
            //    //    driver = new RemoteWebDriver();
            //    //    break;

            //    case "Safari":
            //        driver = new SafariDriver();
            //        break;

            //    case "":
            //        driver = new EdgeDriver();
            //        break;

            //    case "Opera":
            //        driver = new OperaDriver();
            //        break;
            //}

            return new PhantomJSDriver(Constants.PhantomJSSettings.Path);
        }
    }
}
