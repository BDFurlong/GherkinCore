using GherkinCore.Base.Model;
using GherkinCore.Base.Rules;
using GherkinCore.Base.Util;
using Sitecore.Data.Items;
using Sitecore.Rules.Actions;

namespace GherkinCore.Rules.Rules.Selenium.Actions
{
    public class ThenCurrentElementValueShouldMatchField<T> : RuleAction<T> where T : GherkinRuleContext
    {
        public string FieldName { get; set; }
        public string ItemId { get; set; }

        public override void Apply(T ruleContext)
        {
            Item contentItem = ruleContext.GetContentItem(ItemId);

            var result = ruleContext.CurrentElement.Text == contentItem.Fields[FieldName].Value;
            var testStep = new TestStep();
            testStep.Passed = result;
            testStep.Screenshot = DriverManager.TakeScreenshot();
            testStep.StepDescription =
            $"Current Element Text was {ruleContext.CurrentElement.Text} and Field Text was {contentItem.Fields[FieldName].Value}";
            ruleContext.TestSteps.Add(testStep);
        }
    }
}
