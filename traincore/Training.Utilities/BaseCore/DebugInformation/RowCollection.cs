using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training.Utilities.DebugInformation
{
    public class RowCollection : List<Row>
    {
        public Row Add(string header)
        {
            return Add(header, null);
        }

        public Row Add(string header, object text) 
        {
            var row = new Row(header, text);
            this.Add(row);
            return row;
        }
    }
}