using GherkinCore.Interfaces;
using OpenQA.Selenium;
using Sitecore.Data.Items;

namespace GherkinCore.Base.Model
{
    public class TestStep : ITestStep
    {
        public Screenshot Screenshot { get; set; }
        public MediaItem ScreenShotItem { get; set; }
        public string StepDescription { get; set; }
        public bool Passed { get; set; }
    }
}
