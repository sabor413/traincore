using System;
using Training.Utilities.Basecore.Base;

namespace Training.BaseCore.Layouts.Columns {

    /// <summary>
    /// Summary description for Tc_containerSublayout
    /// </summary>
    public partial class OneColumn : BaseSublayout
    {
        private void Page_Load(object sender, EventArgs e)
        {
            var x = Sitecore.DateUtil.IsoNow;
        }
    }
}