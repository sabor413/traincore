using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training.demo.search
{
    public class CustomSearch : SearchResultItem
    {
        [IndexField("page heading")]
        public string PageHeading { get; set; }

        [IndexField("page summary")]
        public string PageSummary { get; set; }

        public string Location { get; set; }
    }
}