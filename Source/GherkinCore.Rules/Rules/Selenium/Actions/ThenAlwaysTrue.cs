using GherkinCore.Base.Model;
using GherkinCore.Base.Rules;
using GherkinCore.Base.Util;
using Sitecore.Rules.Actions;

namespace GherkinCore.Rules.Rules.Selenium.Actions
{
    public class ThenAlwaysTrue<T> : RuleAction<T> where T : GherkinRuleContext
    {
        public override void Apply(T ruleContext)
        {
            ruleContext.TestSteps.Add(new TestStep()
            {
                Passed = true,
                Screenshot = DriverManager.TakeScreenshot()
            });

            
        }
    }
}
