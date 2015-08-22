using Sitecore.Configuration;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Resources.Media;
using Sitecore.Sites;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Utilities.BaseCore.Search
{
    public class ComputedHolidayName : Sitecore.ContentSearch.ComputedFields.IComputedIndexField
    {
        public string FieldName { get; set; }

        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            Item item = (Item)(indexable as SitecoreIndexableItem);
            
            if (item == null)
            {
                return null;
            }

            ReferenceField holidayDate = item.Fields["Booked Date"];

            if (holidayDate != null)
            {
                Item holiday = CheckParentForHoliday(holidayDate.TargetItem);

                if (holiday != null)
                {
                    return holiday.Fields["Page Heading"];
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private Item CheckParentForHoliday(Item item)
        {
            if (item.Parent.TemplateName == "Holiday")
            {
                return item.Parent;
            }

            else
            {
                return CheckParentForHoliday(item.Parent);
            }
        }
    }

}
