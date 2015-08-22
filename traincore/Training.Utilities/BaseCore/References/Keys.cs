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
    public class Keys
    {
        #region Query String Keys

        public static string BookingID { get { return "bookingID"; } }
        public static string DateID { get { return "dateID"; } }
        public static string SearchPage { get { return "page"; } }

        #endregion

        #region Field Names

        public static string SimpleTextFieldName { get { return "Text"; } }

        #endregion

        #region Session Keys

        public static string HolidaySearchSession { get { return "searchObject"; } }
        public static string Javascript { get { return "Javascript"; } }

        #endregion
    }
}
