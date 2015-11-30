using GherkinCore.Base.Model.Results;
using Sitecore.Pipelines;

namespace GherkinCore.Base.Pipelines
{
    public class GherkinCoreReportingPipelineArgs : PipelineArgs
    {
        public TestGroupResult Results { get; set; }
    }
}
