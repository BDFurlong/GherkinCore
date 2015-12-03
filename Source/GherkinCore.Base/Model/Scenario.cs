using System.IO;
using System.Web.UI;
using GherkinCore.Base.Rules;
using GherkinCore.Common;
using Sitecore.Data.Items;
using Sitecore.Rules;
using Sitecore.Shell.Applications.Rules;

namespace GherkinCore.Base.Model
{
    public class Scenario
    {
        public Item ScenarioItem { get; set; }
        private GherkinRuleContext RuleContext { get; set; }
        private TestSettings TestSettings { get; set; }

        public Scenario(Item item, TestSettings settings)
        {
            ScenarioItem = item;
            CreateRuleContext();
        }

        private string ScenarioField()
        {
            return ScenarioItem.Fields[Constants.ScenarioTemplate.Fields.Scenario].Value;
        }

        private string RenderRule()
        {
            var ruleRenderer = new RulesRenderer(ScenarioField());
            var stringWriter = new StringWriter();
            var htmlWriter = new HtmlTextWriter(stringWriter);
            ruleRenderer.Render(htmlWriter);
            return stringWriter.ToString();
        }

        public ScenarioResult RunScenario()
        {
            var rule = RuleFactory.GetRules<GherkinRuleContext>(ScenarioItem.Fields[Constants.ScenarioTemplate.Fields.Scenario]);
            rule.Run(RuleContext);
            return CreateScenarioResult();

        }

        private void CreateRuleContext()
        {
            RuleContext = new GherkinRuleContext(TestSettings);
        }

        private ScenarioResult CreateScenarioResult()
        {
            var result = new ScenarioResult
            {
                TestSteps = RuleContext.TestSteps,
                Description = RenderRule()
            };

            return result;
        }
    }
}
