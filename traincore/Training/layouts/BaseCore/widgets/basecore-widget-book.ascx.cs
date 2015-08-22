using System;
using System.Collections.Specialized;
using System.Web.UI;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using Training.Utilities.Basecore.Base;
using System.Collections.Generic;
using System.Linq;
using Training.Utilities.Basecore.References;
using Sitecore.Links;
using Training.Utilities.BaseCore.References;
using System.Web.UI.WebControls;
using Training.Utilities.BaseCore.Holidays;

namespace Training.BaseCore.Layouts.Widgets {

    /// <summary>
    /// A vertical widget used on the holiday page. Uses the same base class as 
    /// <see cref="Training.BaseCore.Layouts.Widgets.WidgetQuarter"/> with some added functionality.
    /// </summary>
    public partial class WidgetBook : BaseWidget
    {
        private void Page_Load(object sender, EventArgs e)
        {
            Item source = GetItem();

            if (source.TemplateID == TemplateReferences.Holiday)
            {
                PageHeading.Item = source.Axes.GetDescendants().Where(x => x.TemplateID == TemplateReferences.HolidayDates).FirstOrDefault();

                /* 'GetDescendants' is an expensive operation if you do it on a large tree - make sure you know the section
                 * of the tree you are targeting is never going to grow beyond a certain size. In this case, we know holiday
                 * dates will be limited to ~ 20. For more common mistakes, see: http://blog.boro2g.co.uk/common-mistakes-when-programming-with-sitecore-pt1/. 
                 */

                List<Item> descendants = Sitecore.Context.Item.Axes.GetDescendants().ToList();

                if (descendants.Any())
                {
                    /* 'HolidayDate' is a so-called 'custom item'. Navigate to the class to find out more about the
                     * custom item pattern in Sitecore.
                     */

                    /* TODO: Refactor to use search instead */

                    List<Item> holidayDates = descendants.Where(x => x.TemplateID == TemplateReferences.HolidayDate && x.Versions.Count > 0).ToList();

                    var validDates = holidayDates.Where(x => HolidayUtils.GetHolidayDateRange(x).StartDate > DateTime.Today);

                    if (validDates.Any())
                    {
                        rpDays.DataSource = validDates;
                        rpDays.DataBind();
                    }
                    else
                    {
                        NoHolidays.Visible = true;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void HolidayDates_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Item date = e.Item.DataItem as Item;

                HyperLink hlBook = (HyperLink)e.Item.FindControl("hlBook");

                hlBook.NavigateUrl = String.Format("{0}?{1}={2}", LinkManager.GetItemUrl(ItemReferences.BookingsPage), Keys.DateID, date.ID);
            }
        }
    }
}