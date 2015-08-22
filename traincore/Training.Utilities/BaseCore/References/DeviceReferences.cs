using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.SitecoreUtilities.Configuration;
using Sitecore;
using Sitecore.Data.Items;

namespace Training.Utilities.BaseCore.References
{
    /// <summary>
    /// Reference file for Sitecore devices.
    /// </summary>
    public class DeviceReferences
    {
        #region Devices

        public static DeviceItem Print
        {
            get
            {
                return Context.Database.Resources.Devices["Print"];
            }
        }

        #endregion
    }
}
