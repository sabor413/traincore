using Sitecore.Data.Items;
using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Utilities.BaseCore.Holidays;

namespace Training.Utilities.BaseCore.Pipelines
{
    public class HolidayBookingPipelineArgs : PipelineArgs
    {
        private bool m_valid = false;
        private string m_message = string.Empty;
        private Item m_item = null;
        private Booking m_booking = null;

        public bool Valid
        {
            get { return m_valid; }
            set { m_valid = value; }
        }

        public string Message
        {
            get { return m_message; }
            set { m_message = value; }
        }

        public Item Item
        {
            get { return m_item; }
            set { m_item = value; }
        }

        public Booking Booking 
        { 
            get { return m_booking; } 
            set { m_booking = value; } 
        }

        public HolidayBookingPipelineArgs(Item item, Booking booking)
        {
            m_item = item;
            m_booking = booking;
        }
    }
}
