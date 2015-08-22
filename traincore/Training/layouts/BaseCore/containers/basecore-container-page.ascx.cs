using System;
using Sitecore.Data.Fields;
using Sitecore.Globalization;
using Training.Utilities.Basecore.Base;

namespace Training.BaseCore.Layouts.Containers {

    /// <summary>
    /// Container for page content.
    /// </summary>
    public partial class PageContainer : BaseSublayout
    {
        private void Page_Load(object sender, EventArgs e)
        {
            CheckboxField allowPrint = Sitecore.Context.Item.Fields["Allow Print"];

            if (allowPrint != null)
            {
                if (allowPrint.Checked)
                {
                    phPrint.Visible = true;
                }
            }
        }
    }
}