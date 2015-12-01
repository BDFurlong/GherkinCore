using GherkinCore.Base.Rules;
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
        }
    }
}
