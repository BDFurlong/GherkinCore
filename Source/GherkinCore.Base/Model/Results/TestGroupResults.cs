using System.Collections.Generic;

namespace GherkinCore.Base.Model.Results
{
    public class TestGroupResult
    {
        public IEnumerable<FeatureResult> Features { get; set; }
    }
}
