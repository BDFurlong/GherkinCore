using System.Collections.Generic;
using GherkinCore.Base.Model;
using GherkinCore.Base.Util;
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
        public ITestActor TestActor { get; set; }
        public List<TestStep> TestSteps { get; set; }
        public IWebElement CurrentElement { get; set; }
        public Database ContentDatabase { get; set; }
        public TestSettings TestSettings { get; set; }

        public GherkinRuleContext(TestSettings settings)
        {
            TestSteps = new List<TestStep>();
            ContentDatabase = Sitecore.Context.ContentDatabase;
            TestSettings = settings;
        }

        //TODO: move this or refactor
        public Item GetConfiguratioItem(string id)
        {
            return GetItem(id, ContentDatabase);
        }
        //TODO: move this or refactor
        public Item GetContentItem(string id)
        {
            //TODO: make the db configurable from test settings
            return GetItem(id, TestSettings.TestContentDatabase);
        }

        //TODO: move this or refactor
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
