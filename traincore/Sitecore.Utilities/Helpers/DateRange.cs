using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.SitecoreUtilities.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class DateRange
    {
        public DateRange()
        {
            StartDate = DateTime.MinValue;
            EndDate = DateTime.MaxValue;
        }

        public DateRange(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
