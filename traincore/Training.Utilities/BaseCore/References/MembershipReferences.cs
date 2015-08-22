using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.SitecoreUtilities.Configuration;

namespace Training.Utilities.BaseCore.References
{
    /// <summary>
    /// 
    /// </summary>
    public class MembershipReferences
    {
        private static readonly string domain = "DomainTrainCore";
        private static readonly string userTrainCoreBasicUser = "UserTrainCoreBasicUser";
        private static readonly string roleTrainCoreHolidayBooker = "RoleTrainCoreHolidayBooker";

        public static string DomainTrainCore { get { return ConfigurationUtils.GetAppSetting(domain); } }
        public static string UserTrainCoreBasicUser { get { return ConfigurationUtils.GetAppSetting(userTrainCoreBasicUser); } }
        public static string RoleTrainCoreHolidayBooker { get { return ConfigurationUtils.GetAppSetting(roleTrainCoreHolidayBooker); } }
    }
}
