using System;
using Training.Utilities.Basecore.Base;

namespace Training.BaseCore.Layouts.Containers {

    /// <summary>
    /// Container for footer.
    /// </summary>
    public partial class FooterContainer : BaseSublayout
    {
        private void Page_Load(object sender, EventArgs e)
        {
            litDateTime.Text = Sitecore.DateUtil.DateTimeToMilitary(DateTime.Now);
        }
    }
}