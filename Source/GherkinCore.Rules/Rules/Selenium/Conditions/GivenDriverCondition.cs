using GherkinCore.Base.Rules;
using GherkinCore.Base.Util;
using Sitecore.Data;
using Sitecore.Rules.Conditions;

namespace GherkinCore.Rules.Rules.Selenium.Conditions
{
    public class GivenDriverCondition<T> : WhenCondition<T> where T : GherkinRuleContext
    {
        public string DriverName { get; set; }

        protected override bool Execute(T ruleContext)
        {
            var driverItem = ruleContext.GetConfigurationItem(DriverName);

            if (driverItem == null)
            {
                return false;
            }

            ruleContext.Driver = DriverManager.GetDriver(driverItem.DisplayName);

            return true;
        }
    }
}
