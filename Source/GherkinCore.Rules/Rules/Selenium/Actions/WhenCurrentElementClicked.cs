using GherkinCore.Base.Model;
using GherkinCore.Base.Rules;
using GherkinCore.Base.Util;
using Sitecore.Rules.Actions;

namespace GherkinCore.Rules.Rules.Selenium.Actions
{
    public class WhenCurrentElementClicked<T> : RuleAction<T> where T : GherkinRuleContext
    {
        public override void Apply(T ruleContext)
        {
            if (ruleContext.CurrentElement == null)
            {
                //TODO: Fail Test
                return;
            }
            ruleContext.CurrentElement.Click();

            var testStep = new TestStep();
            testStep.Passed = true;
            testStep.Screenshot = DriverManager.TakeScreenshot();
            testStep.StepDescription = "Click on current element";
            ruleContext.TestSteps.Add(testStep);
        }
    }
}
