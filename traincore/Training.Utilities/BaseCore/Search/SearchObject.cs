using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Utilities.BaseCore.Search
{
    public class SearchObject
    {
        public string Text;
        public Guid HolidayType;
        public Guid Terrain;
        public int Page;

        public SearchObject()
        {
            Text = null;
            HolidayType = Guid.Empty;
            Terrain = Guid.Empty;
            Page = 1;
        }
    }
}
