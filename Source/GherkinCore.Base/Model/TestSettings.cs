using Sitecore.Data;

namespace GherkinCore.Base.Model
{
    public class TestSettings
    {
        public string BaseUrl { get; set; }
        public Database TestContentDatabase { get; set; }
    }
}
