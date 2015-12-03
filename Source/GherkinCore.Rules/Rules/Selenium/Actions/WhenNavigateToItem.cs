using System;
using GherkinCore.Base.Model;
using GherkinCore.Base.Rules;
using GherkinCore.Base.Util;
using Sitecore.Links;
using Sitecore.Rules.Actions;

namespace GherkinCore.Rules.Rules.Selenium.Actions
{
    public class WhenNavigateToItem<T> : RuleAction<T> where T : GherkinRuleContext
    {
        public string NavigationItem { get; set; }

        public override void Apply(T ruleContext)
        {
            var navigationItem = ruleContext.GetContentItem(NavigationItem);

            if (navigationItem == null)
            {
                return;
            }

            //ruleContext.Driver.Url = "http://gherkincoredemo" + LinkManager.GetItemUrl(navigationItem);
            DriverManager.GetDriver().Navigate().GoToUrl("http://gherkincoredemo" + LinkManager.GetItemUrl(navigationItem));
            
            var testStep = new TestStep();
            testStep.Passed = true;
            testStep.Screenshot = DriverManager.TakeScreenshot();
            testStep.StepDescription = $"Navigate to Item {DriverManager.GetDriver().Url}";
            ruleContext.TestSteps.Add(testStep);
        }
    }
}
