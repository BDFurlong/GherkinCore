namespace GherkinCore.Common
{
    public static class Constants
    {
        public static class PhantomJSSettings
        {
            //TODO this should be getting pulled from sitecore config
            public const string Path = @"C:\inetpub\wwwroot\runwild\Data\tools\phantomjs";
        }
        public static class ScenarioTemplate
        {
            public const string TemplateId = "{0125B92B-7975-4415-8B9C-B9EA1C2001B4}";
            public static class Fields
            {
                public const string Scenario = "Scenario";
            }
        }

        public static class TestGroupTemplate
        {
            public const string TempalteID = "{61E11240-D306-477E-A57A-C3802E0E28E8}";

            public static class Fields
            {
                public const string Features = "Features";
            }
        }

        public static class GherkinCoreReportingPipeline
        {
            public const string Pipeline = "gherkinCoreReportingPipeline";
        }
    }
}
