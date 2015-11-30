using System.Collections.Generic;
using System.Linq;
using GherkinCore.Base.Model.Results;
using GherkinCore.Common;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Web;

namespace GherkinCore.Base.Model
{
    public class TestGroup
    {
        public Item TestGroupItem { get; set; }
        public IEnumerable<Feature> Features { get; set; }
        
        public TestGroup(Item item)
        {
            TestGroupItem = item;
            GetFeatures();
        }

        public TestGroupResult TestFeatures()
        {
            var featureResults = Features.Select(i => i.RunFeature());
            var testGroupResult = new TestGroupResult();
            testGroupResult.Features = featureResults;

            return testGroupResult;
        }

        private void GetFeatures()
        {
            MultilistField featureItems = TestGroupItem.Fields[Constants.TestGroupTemplate.Fields.Features];
            Features = featureItems.GetItems().Select(i => new Feature(i));
        }
    }
}
