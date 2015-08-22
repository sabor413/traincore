using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Utilities.BaseCore.Holidays
{
    /// <summary>
    /// Transient class for holiday booking.
    /// </summary>
    public class Booking
    {
        public string BookingItemName { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public Guid HolidayDate { get; set; }
        public Item BookingsRoot { get; set; }
    }
}
