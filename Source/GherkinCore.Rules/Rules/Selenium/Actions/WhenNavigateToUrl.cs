using GherkinCore.Base.Model;
using GherkinCore.Base.Rules;
using GherkinCore.Base.Util;
using Sitecore.Links;
using Sitecore.Rules.Actions;

namespace GherkinCore.Rules.Rules.Selenium.Actions
{
    public class WhenNavigateToUrl<T> : RuleAction<T> where T : GherkinRuleContext
    {
        public string Url { get; set; }

        public override void Apply(T ruleContext)
        {
            DriverManager.GetDriver().Navigate().GoToUrl(Url);

            var testStep = new TestStep();
            testStep.Passed = true;
            testStep.Screenshot = DriverManager.TakeScreenshot();
            testStep.StepDescription = $"Navigate to Item {DriverManager.GetDriver().Url}";
            ruleContext.TestSteps.Add(testStep);
        }
    }
}
