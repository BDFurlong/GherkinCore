using System.Collections.Generic;

namespace GherkinCore.Base.Model.Reporting
{
    public class TestReport
    {
        public IEnumerable<TestStep> TestSteps { get; set; }
        public IEnumerable<Feature> Features { get; set; }
    }
}
