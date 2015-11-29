using GherkinCore.Base.Rules;
using Sitecore.Rules.Actions;

namespace GherkinCore.Rules.Rules.Selenium.Actions
{
    public class WhenNavigateToUrl<T> : RuleAction<T> where T : GherkinRuleContext
    {
        public string Url { get; set; }

        public override void Apply(T ruleContext)
        {
            ruleContext.Driver.Url = Url;
            ruleContext.Driver.Navigate();
        }
    }
}
