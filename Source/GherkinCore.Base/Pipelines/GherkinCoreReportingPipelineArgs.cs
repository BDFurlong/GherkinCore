using GherkinCore.Base.Model;
using GherkinCore.Base.Model.Results;
using Sitecore.Pipelines;

namespace GherkinCore.Base.Pipelines
{
    public class GherkinCoreReportingPipelineArgs : PipelineArgs
    {
        public TestSettings TestSettings { get; set; }
        public TestGroupResult Results { get; set; }    
    }
}
