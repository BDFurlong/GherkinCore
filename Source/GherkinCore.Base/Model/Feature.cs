using System.Collections.Generic;
using System.Linq;
using GherkinCore.Base.Model.Results;
using GherkinCore.Common;
using GherkinCore.Common.Extensions;
using Sitecore.Data.Items;

namespace GherkinCore.Base.Model
{
    public class Feature
    {
        public string Description { get; set; }
        public IEnumerable<Scenario> Scenarios { get; set; }
        public Item FeatureItem { get; set; }

        public Feature(Item item)
        {
            FeatureItem = item;
            Description = FeatureDescription();
            Scenarios = GetScenarios();
        }

        public FeatureResult RunFeature()
        {
            var featureResult = new FeatureResult();
            featureResult.ScenarioResults = RunScenarios();
            featureResult.FeatureDescription = FeatureDescription();

            return featureResult;
        }

        private string FeatureDescription()
        {
            //TODO: move to constants
            return FeatureItem.Fields["Feature Description"].Value;
        }

        private IEnumerable<Scenario> GetScenarios()
        {
            var scenarioItems = FeatureItem.Children.Where(i => i.IsTemplate(Constants.ScenarioTemplate.TemplateId));

            return scenarioItems.Select(i => new Scenario(i));
        }

        private IEnumerable<ScenarioResult> RunScenarios()
        {
            var results = Scenarios.Select(i => i.RunScenario());
            return results.ToList();
        }
    }
}
