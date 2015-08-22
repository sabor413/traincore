using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Utilities.BaseCore.Extensions
{
    public static class DateTimeExtensions
    {
        public static string FormattedDate(this DateTime dateTime)
        {
            return Sitecore.DateUtil.FormatDateTime(dateTime, "d", Sitecore.Context.Culture);
        }
    }
}
