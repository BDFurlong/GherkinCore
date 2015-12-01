using GherkinCore.Base.Rules;
using GherkinCore.Base.Util;
using Sitecore.Rules.Actions;

namespace GherkinCore.Rules.Rules.Selenium.Actions
{
    public class WhenElementFound<T> : RuleAction<T> where T : GherkinRuleContext
    {
        public string TemplateId { get; set; }
        public string Locator { get; set; }
        public string Value { get; set; }

        public override void Apply(T ruleContext)
        {
            ruleContext.CurrentElement = ruleContext.Driver.FindElement(SeleniumLocatorFactory.GetLocator(Locator, Value));
        }
    }
}
