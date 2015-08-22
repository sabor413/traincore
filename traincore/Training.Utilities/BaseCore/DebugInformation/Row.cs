using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training.Utilities.DebugInformation
{

    public class Row
    {
        public Cell Header { get; private set; }
        public Cell Value { get; private set; }


        public Row(string header)
        {
            Header = new Cell().Add(header);
            Value = new Cell();
        }

        public Row(string header, object text)
        {
            Header = new Cell().Add(header);
            Value = new Cell();
            if (text != null) Value.Add(text);
        }

        public Row AddTextToValue(object text)
        {
            Value.Add(text);
            return this;
        }

        public Row AddTextToHeader(object text)
        {
            Header.Add(text);
            return this;
        }
    }
}