using GherkinCore.Base.Rules;
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

            ruleContext.Driver.Url = LinkManager.GetItemUrl(navigationItem);
            ruleContext.Driver.Navigate();
        }
    }
}
