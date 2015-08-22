using System;
using Sitecore.Data.Items;
using Training.Utilities.Basecore.Base;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Fields;
using Sitecore;
using System.Linq;
using Sitecore.Data;
using Sitecore.Layouts;
using Training.Utilities.Basecore.References;
using System.Collections.Generic;
using Generic.SitecoreUtilities.Fields;
using Training.Utilities.BaseCore.Holidays;
using Training.Utilities.BaseCore.References;

namespace Training.BaseCore.Layouts.Print {

    /// <summary>
    /// 
    /// </summary>
    public partial class HolidayPrint : BaseSublayout
    {
        private static readonly string fnType = "Type";
        private static readonly string fnDifficulty = "Difficulty";
        private static readonly string fnTerrain = "Terrain";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Load(object sender, EventArgs e)
        {
            Item context = Sitecore.Context.Item;

            if (context.TemplateID == TemplateReferences.Holiday)
            {
                PageHeading.Item = context.Axes.GetDescendants().Where(x => x.TemplateID == TemplateReferences.HolidayDates).FirstOrDefault();

                /* 'GetDescendants' is an expensive operation if you do it on a large tree - make sure you know the section
                 * of the tree you are targeting is never going to grow beyond a certain size. In this case, we know holiday
                 * dates will be limited to ~ 20. For more common mistakes, see: http://blog.boro2g.co.uk/common-mistakes-when-programming-with-sitecore-pt1/. 
                 */

                List<Item> descendants = Sitecore.Context.Item.Axes.GetDescendants().ToList();

                if (descendants.Any())
                {
                    List<Item> holidayDates = descendants.Where(x => x.TemplateID == TemplateReferences.HolidayDate).ToList();

                    if (holidayDates.Any())
                    {
                        holidayDates.OrderByDescending(x => HolidayUtils.GetHolidayDateRange(x).StartDate);

                        rpDays.DataSource = holidayDates.Where(x => HolidayUtils.GetHolidayDateRange(x).StartDate > DateTime.Today);
                        rpDays.DataBind();
                    }

                    SummaryHeading.Item = context;

                    txtType.Item = FieldUtils.GetReferenceFieldItem(fnType);
                    txtDifficulty.Item = FieldUtils.GetReferenceFieldItem(fnDifficulty);

                    List<Item> terrains = FieldUtils.GetListFieldItems(fnTerrain);

                    if (terrains.Any())
                    {
                        litTerrain.Text = string.Join(", ", terrains.Select(x => FieldUtils.GetFieldValue(x, Keys.SimpleTextFieldName)));
                    }
                }
            }
        }
    }
}