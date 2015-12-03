using System.IO;
using Sitecore.Data;
using Sitecore.Resources.Media;
using Sitecore.SecurityModel;
using DateTime = System.DateTime;

namespace GherkinCore.Base.Pipelines
{
    public class CreateTestResultMediaItems
    {
        public void Process(GherkinCoreReportingPipelineArgs args)
        {
            foreach (var feature in args.Results.Features)
            {
                foreach (var scenarioResult in feature.ScenarioResults)
                {
                    foreach (var testStep in scenarioResult.TestSteps)
                    {
                        var mediaOptions = new MediaCreatorOptions();
                        mediaOptions.FileBased = false;
                        

                        var mediaCreator = new MediaCreator();
                        var screenShotStream = new MemoryStream(testStep.Screenshot.AsByteArray);
                        

                        var imageBucket =  Sitecore.Context.ContentDatabase.GetItem(ID.Parse("{889870D2-15A6-423C-87C3-9944586BC64A}"));

                        using (new SecurityDisabler())
                        {
                            var mediaPath =  "TestThis.png";
                            mediaOptions.Destination = mediaPath;
                            var item = mediaCreator.CreateFromStream(screenShotStream, mediaPath,
                                mediaOptions);
                            item.Editing.BeginEdit();
                            item.Fields["Media"].SetBlobStream(screenShotStream);
                            item.Editing.EndEdit();

                        }
                        
                    }
                }
            }
        }
    }
}
