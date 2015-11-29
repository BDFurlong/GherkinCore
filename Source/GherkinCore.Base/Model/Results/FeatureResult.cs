using System.Collections.Generic;

namespace GherkinCore.Base.Model.Results
{
    public class FeatureResult
    {
        public string FeatureDescription { get; set; }
        public IEnumerable<ScenarioResult> ScenarioResults { get; set; }
    }
}
