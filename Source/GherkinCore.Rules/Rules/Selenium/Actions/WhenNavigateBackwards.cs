using GherkinCore.Base.Rules;
using GherkinCore.Base.Util;
using Sitecore.Rules.Actions;

namespace GherkinCore.Rules.Rules.Selenium.Actions
{
    public class WhenNavigateBackwards<T> : RuleAction<T> where T : GherkinRuleContext
    {
        public override void Apply(T ruleContext)
        {
            DriverManager.GetDriver().Navigate().Back();
        }
    }
}
