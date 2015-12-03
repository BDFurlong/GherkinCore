using GherkinCore.Base.Model;
using GherkinCore.Base.Rules;
using GherkinCore.Base.Util;
using Sitecore.Rules.Actions;

namespace GherkinCore.Rules.Rules.Selenium.Actions
{
    public class WhenScreenshotTaken<T> : RuleAction<T> where T : GherkinRuleContext
    {
        public override void Apply(T ruleContext)
        {
            var testStep = new TestStep();
            testStep.Screenshot = DriverManager.TakeScreenshot();

            ruleContext.TestSteps.Add(testStep);
        }
    }
}
