using GherkinCore.Base.Rules;
using Sitecore.Rules.Actions;

namespace GherkinCore.Rules.Rules.Selenium.Actions
{
    public class WhenNavigateForward<T> : RuleAction<T> where T : GherkinRuleContext
    {
        public override void Apply(T ruleContext)
        {
            ruleContext.Driver.Navigate().Forward();
        }
    }
}
