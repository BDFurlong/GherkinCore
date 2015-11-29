using System.Collections.Generic;
using GherkinCore.Base.Model;
using GherkinCore.Common;
using GherkinCore.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Rules;
using Sitecore.StringExtensions;

namespace GherkinCore.Base.Rules
{
    public class GherkinRuleContext : RuleContext
    {
        public IWebDriver Driver { get; set; }
        public ITestActor TestActor { get; set; }
        public IEnumerable<TestStep> TestSteps { get; set; }
        public IWebElement CurrentElement { get; set; }
        public Database ContentDatabase { get; set; }

        public GherkinRuleContext()
        {
            TestSteps = new List<TestStep>();
            ContentDatabase = Sitecore.Context.ContentDatabase;
            Driver = new PhantomJSDriver(Constants.PhantomJSSettings.Path);
        }

        public Item GetConfiguratioItem(string id)
        {
            return GetItem(id, ContentDatabase);
        }

        public Item GetContentItem(string id)
        {
            //TODO: make the db configurable from test settings
            return GetItem(id, Sitecore.Configuration.Factory.GetDatabase("web"));
        }

        private Item GetItem(string id, Database database)
        {
            ID itemId;
            Item = null;

            if (id.IsNullOrEmpty())
            {
                return Item;
            }

            if (database == null)
            {
                return Item;
            }

            if (ID.TryParse(id, out itemId))
            {
                Item = database.GetItem(itemId);
            }

            return Item;
        }
    }
}
