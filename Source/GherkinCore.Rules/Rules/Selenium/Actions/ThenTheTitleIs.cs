using System;
using GherkinCore.Base.Model;
using GherkinCore.Base.Rules;
using GherkinCore.Base.Util;
using Sitecore.Rules.Actions;

namespace GherkinCore.Rules.Rules.Selenium.Actions
{
    public class ThenTheTitleIs<T> : RuleAction<T> where T : GherkinRuleContext
    {
        public string Value { get; set; }
        public override void Apply(T ruleContext)
        {
            var testStep = new TestStep();
            testStep.Passed = DriverManager.GetDriver().Title == Value;
            testStep.StepDescription = $"Title is currently equal to {Value} and the test has {testStep.Passed}";
            testStep.Screenshot = DriverManager.TakeScreenshot();
            ruleContext.TestSteps.Add(testStep);
        }
    }
}
