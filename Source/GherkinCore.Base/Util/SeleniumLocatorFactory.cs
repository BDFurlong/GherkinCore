using OpenQA.Selenium;

namespace GherkinCore.Base.Util
{
    public static class SeleniumLocatorFactory
    {
        public static By GetLocator(string locatorName, string locatorValue)
        {
            switch (locatorName)
            {
                case "{DEBC9033-4CFD-4AFD-B5F1-DC26E76602A1}":
                    return By.ClassName(locatorValue);

                case "{8A37F5EA-244E-4351-A554-18645467672D}":
                    return By.CssSelector(locatorValue);

                case "{302FF6F0-A57B-43D8-9F12-44D56ED884E3}":
                    return By.Id(locatorValue);

                case "{3ECC3FC0-BDF2-46DC-9528-3350F02CA090}":
                    return By.LinkText(locatorValue);

                case "{038A164F-FFA7-4897-9658-6DAFA6A53B48}":
                    return By.Name(locatorValue);

                case "{2CB0B0AB-B57A-4023-9C95-48995EFC2BF3}":
                    return By.PartialLinkText(locatorValue);

                case "{0604D2B7-7720-49A9-BF61-CBB9A41977B7}":
                    return By.XPath(locatorValue);

                default:
                    return By.ClassName(locatorValue);
            }
        }
    }
}
