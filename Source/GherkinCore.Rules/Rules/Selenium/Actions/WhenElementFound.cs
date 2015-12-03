using GherkinCore.Base.Model;
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
            var locateBy = SeleniumLocatorFactory.GetLocator(TemplateId, Value);
            
            ruleContext.CurrentElement = DriverManager.GetDriver().FindElement(locateBy);

            var testStep = new TestStep();
            testStep.Passed = true;
            testStep.Screenshot = DriverManager.TakeScreenshot();
            testStep.StepDescription = $"Element with  {Value} found";
            ruleContext.TestSteps.Add(testStep);
        }
    }
}
