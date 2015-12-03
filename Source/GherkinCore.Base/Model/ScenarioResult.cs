using System.Collections.Generic;
using System.Linq;

namespace GherkinCore.Base.Model
{
    public class ScenarioResult
    {
        public IEnumerable<TestStep> TestSteps { get; set; }
        public string Description { get; set; }

        public bool Passed()
        {
            return TestSteps.Last().Passed;
        }
    }
}
