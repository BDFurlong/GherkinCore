using System.Text;
using GherkinCore.Common;
using Sitecore.Data;

namespace GherkinCore.Base.Pipelines
{
    public class CreateNewHtmlReport
    {
        public void Process(GherkinCoreReportingPipelineArgs args)
        {
          
            var testReport =  args.TestSettings.ReportBucket.Add(CreateReportName(), new TemplateID(ID.Parse(Constants.TestReportTemplate.TemplateId)));

            var stringBuilder = new StringBuilder();

            foreach (var feature in args.Results.Features)
            {
                stringBuilder.Append(feature.FeatureDescription);
                stringBuilder.Append("================================== <br />");

                foreach (var scenario in feature.ScenarioResults)
                {
                    stringBuilder.Append(scenario.Description);
                }
            }

            testReport.Editing.BeginEdit();
            testReport.Fields[Constants.TestReportTemplate.Fields.Result].Value = stringBuilder.ToString();
            testReport.Editing.EndEdit();
        }

        private string CreateReportName()
        {
            return "TestReport";
        }
    }
}
