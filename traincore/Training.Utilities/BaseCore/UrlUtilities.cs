using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;

namespace Training.Utilities.BaseCore
{
    public class UrlUtilities
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceItem"></param>
        public string DeviceQuery(DeviceItem deviceItem)
        {
            return deviceItem.QueryString;
        }
    }
}
