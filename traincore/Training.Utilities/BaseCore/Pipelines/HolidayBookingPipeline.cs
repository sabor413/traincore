using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Utilities.Basecore.References;

namespace Training.Utilities.BaseCore.Pipelines.HolidayBooking
{
    /// <summary>
    /// 
    /// </summary>
    public class BookHoliday : IHolidayBookingPipeline
    {
        private readonly string fnBookedDate = "Booked Date";
        private readonly string fnFirstName = "First Name";
        private readonly string fnSurname = "Surname";

        public void Process(HolidayBookingPipelineArgs args)
        {
            if (args.Booking == null)
            {
                args.Valid = false;
                args.Message = "No booking item has been created";
            }

            var booking = args.Booking;

            // create an item under the bookings root

            Item bookingItem = booking.BookingsRoot.Add(booking.BookingItemName, TemplateReferences.Booking);

            // populate the item with values from the transient booking item

            bookingItem.Editing.BeginEdit();
            bookingItem.Fields[fnFirstName].Value = booking.FirstName;
            bookingItem.Fields[fnSurname].Value = booking.Surname;
            bookingItem.Fields[fnBookedDate].Value = booking.HolidayDate.ToString();
            bookingItem.Editing.EndEdit();
        }
    }
}
