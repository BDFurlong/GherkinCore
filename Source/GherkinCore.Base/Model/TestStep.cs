using GherkinCore.Interfaces;
using OpenQA.Selenium;

namespace GherkinCore.Base.Model
{
    public class TestStep : ITestStep
    {
        public Screenshot Screenshot { get; set; }
        public bool Passed { get; set; }
    }
}
