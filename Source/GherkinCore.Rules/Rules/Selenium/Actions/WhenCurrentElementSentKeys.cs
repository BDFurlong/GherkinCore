using GherkinCore.Base.Rules;
using Sitecore.Rules.Actions;

namespace GherkinCore.Rules.Rules.Selenium.Actions
{
    public class WhenCurrentElementSentKeys<T> : RuleAction<T> where T : GherkinRuleContext
    {
        public string Value { get; set; }

        public override void Apply(T ruleContext)
        {
            if (ruleContext.CurrentElement == null)
            {
                //TODO Fail test
                return;
            }

            ruleContext.CurrentElement.SendKeys(Value);
        }
    }
}
