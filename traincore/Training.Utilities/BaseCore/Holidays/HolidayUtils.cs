using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.SitecoreUtilities.Helpers;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Training.Utilities.Basecore.References;

namespace Training.Utilities.BaseCore.Holidays
{
    /// <summary>
    /// 
    /// </summary>
    public class HolidayUtils
    {
        /// <summary>
        /// Returns holiday start date as DateTime.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static DateRange GetHolidayDateRange(Item item)
        {
            DateRange range = new DateRange();

            DateField startDateField = item.Fields["Start Date"];
            DateField endDateField = item.Fields["End Date"];

            range = new DateRange(startDateField != null ? startDateField.DateTime : DateTime.MinValue, endDateField != null ? endDateField.DateTime : DateTime.MaxValue);

            return range;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int GetHolidayDateSpaces(Item item)
        {
            int maxParticipants = 0;

            if (item.TemplateID == TemplateReferences.HolidayDate)
            {
                Field maximumParticipantsField = item.Fields["Maximum Participants"];

                if (maximumParticipantsField != null)
                {
                    if (int.TryParse(maximumParticipantsField.Value, out maxParticipants))
                    {
                        return maxParticipants - GetHolidayDateBookings(item).Count;
                    }
                }
            }

            return maxParticipants;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static List<Item> GetHolidayDateBookings(Item item)
        {
            List<Item> bookings = new List<Item>();

            if (item.TemplateID == TemplateReferences.HolidayDate)
            {
                Item bookingsFolder = ItemReferences.SiteRoot.Children.Where(x => x.TemplateID == TemplateReferences.BookingsFolder).FirstOrDefault();

                if (bookingsFolder != null)
                {
                    bookings = bookingsFolder.Axes.GetDescendants().Where(x => x.TemplateID == TemplateReferences.Booking && item.ID.ToString().Equals(x.Fields["Booked Date"].Value)).ToList();
                }
            }

            return bookings;
        }
    }
}
