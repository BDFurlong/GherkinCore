using System.Text;
using GherkinCore.Common;
using Sitecore.Data;
using Sitecore.Resources.Media;
using Sitecore.StringExtensions;

namespace GherkinCore.Base.Pipelines
{
    public class CreateNewHtmlReport
    {
        public void Process(GherkinCoreReportingPipelineArgs args)
        {
            var reportName = args.TestSettings.TestName;
            var testReport =  args.TestSettings.ReportBucket.Add(reportName, new TemplateID(ID.Parse(Constants.TestReportTemplate.TemplateId)));

            var stringBuilder = new StringBuilder();
            
            foreach (var feature in args.Results.Features)
            {
                stringBuilder.Append(feature.FeatureDescription);
                stringBuilder.Append("================================== <p>&nbsp;</p>");

                foreach (var scenario in feature.ScenarioResults)
                {
                    stringBuilder.Append(scenario.Description);
                    stringBuilder.Append("<p></p>");
                    stringBuilder.Append("Passed: ");
                    stringBuilder.Append(scenario.Passed().ToString());
                    

                    foreach (var testStep in scenario.TestSteps)
                    {
                        if (testStep.ScreenShotItem != null)
                        {
                            if (!testStep.StepDescription.IsNullOrEmpty())
                            {
                                stringBuilder.Append("<p>" + testStep.StepDescription + "</p>");
                            }
                            stringBuilder.Append("<img src=\"");
                            stringBuilder.Append(MediaManager.GetMediaUrl(testStep.ScreenShotItem));
                           
                            stringBuilder.Append("\"");
                            stringBuilder.Append(">");
                        }
                    }
                }
            }

            testReport.Editing.BeginEdit();
            testReport.Fields[Constants.TestReportTemplate.Fields.Result].Value = stringBuilder.ToString();
            testReport.Editing.EndEdit();
        }

       
    }
}
