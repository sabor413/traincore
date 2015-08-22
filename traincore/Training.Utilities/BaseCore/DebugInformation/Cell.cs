using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training.Utilities.DebugInformation
{
    public class Cell
    {
        private readonly List<string> lines = new List<string>();
        public IEnumerable<string> Lines { get { return lines ;}}

        public Cell()
        {

        }

        public Cell Add(object text)
        {
            lines.Add(text.ToString());
            return this;
        }

        //public string First { get { return lines.First(); } }
        //public IEnumerable<string> Other { get { return lines.Skip(1);  } }
    }
}