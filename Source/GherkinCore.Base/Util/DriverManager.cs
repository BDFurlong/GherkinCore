using OpenQA.Selenium;

namespace GherkinCore.Base.Util
{
    public static class DriverManager
    {
        private static IWebDriver Driver { get; set; }

        public static IWebDriver GetDriver()
        {
            if (Driver == null)
            {
                //TODO: Handle default case
                Driver = GetDriver("default");
            }
            return Driver;
        }

        public static IWebDriver GetDriver(string driverName)
        {
            if (Driver == null)
            {
                Driver = DriverFactory.Driver(driverName);
            }
            return Driver;
        }

        public static Screenshot TakeScreenshot()
        {
            //TODO: This needs to change, can end up in a situation with a null
            var screenshot = ((ITakesScreenshot) Driver).GetScreenshot();
            return screenshot;
        }
    }
}
