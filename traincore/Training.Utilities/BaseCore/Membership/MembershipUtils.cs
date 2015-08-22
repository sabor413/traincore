using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Security.Accounts;
using Training.Utilities.BaseCore.References;

namespace Training.Utilities.BaseCore.Membership
{
    /// <summary>
    /// 
    /// </summary>
    public class MembershipUtils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="username"></param>
        public static User GetUser(string domain, string username, string password)
        {
            if (!System.Web.Security.Membership.ValidateUser(domain + @"\" + username, password))
                return null;
            if (User.Exists(domain + @"\" + username))
                return User.FromName(domain + @"\" + username, true);
            return null;
        }
    }
}
