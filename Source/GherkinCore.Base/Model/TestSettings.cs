using GherkinCore.Common;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace GherkinCore.Base.Model
{
    public class TestSettings
    {
        public string BaseUrl { get; set; }
        public Database TestContentDatabase { get; set; }
        public Item ImageBucket { get; private set; }
        public Item ReportBucket { get; set; }

        public TestSettings(Item testSettingsItem)
        {
            //TODO pull these out of constructor into setters
            var targetSiteId = testSettingsItem.Fields[Constants.TestGroupTemplate.Fields.TargetSite].Value;

            var targetSiteItem = Sitecore.Context.ContentDatabase.GetItem(ID.Parse(targetSiteId));
            BaseUrl = targetSiteItem.Fields[Constants.TargetSiteItem.Fields.BaseUrl].Value;

            var testContentDatabaseName = targetSiteItem.Fields[Constants.TargetSiteItem.Fields.TargetDatabase].Value;
            TestContentDatabase = Sitecore.Configuration.Factory.GetDatabase(testContentDatabaseName);

            var imageBucketId = testSettingsItem.Fields[Constants.TestSettingsTemplate.Fields.ImageBucket].Value;
            ImageBucket = Sitecore.Context.ContentDatabase.GetItem(ID.Parse(imageBucketId));

            var reportItemId = testSettingsItem.Fields[Constants.TestSettingsTemplate.Fields.ReportBucket].Value;
            ReportBucket = Sitecore.Context.ContentDatabase.GetItem(ID.Parse(reportItemId));
        }
    }
}
