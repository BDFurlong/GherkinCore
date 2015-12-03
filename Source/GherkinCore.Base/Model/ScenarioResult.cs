using System.Collections.Generic;

namespace GherkinCore.Base.Model
{
    public class ScenarioResult
    {
        public IEnumerable<TestStep> TestSteps { get; set; }
        public string Description { get; set; }
        public bool Passed { get; set; }
    }
}
