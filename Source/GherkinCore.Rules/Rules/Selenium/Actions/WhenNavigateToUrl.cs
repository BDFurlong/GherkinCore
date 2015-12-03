using GherkinCore.Base.Rules;
using Sitecore.Links;
using Sitecore.Rules.Actions;

namespace GherkinCore.Rules.Rules.Selenium.Actions
{
    public class WhenNavigateToUrl<T> : RuleAction<T> where T : GherkinRuleContext
    {
        public string Url { get; set; }

        public override void Apply(T ruleContext)
        {
            ruleContext.Driver.Url = ruleContext.TestSettings.BaseUrl + LinkManager.GetItemUrl(ruleContext.Item);
            ruleContext.Driver.Navigate();
        }
    }
}
