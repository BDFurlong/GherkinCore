using System.Linq;
using GherkinCore.Base.Model;
using GherkinCore.Base.Pipelines;
using GherkinCore.Common.Extensions;
using Sitecore;
using Sitecore.Shell.Framework.Commands;

namespace GherkinCore.Base.Commands
{
    public class RunTests : Command
    {
        public override void Execute([NotNull] CommandContext context)
        {
            var testRunItem = context.Items.FirstOrDefault();

            if (testRunItem == null)
            {
                return;
            }

            if (!testRunItem.IsTemplate(GherkinCore.Common.Constants.TestGroupTemplate.TempalteID))
            {
                return;
            }
            var testGroup = new TestGroup(testRunItem);
            var results = testGroup.TestFeatures();

            var pipelineArgs = new GherkinCoreReportingPipelineArgs { Results = results };
            //CorePipeline.Run(Constants.GherkinCoreReportingPipeline.Pipeline, pipelineArgs);
        }
    }
}