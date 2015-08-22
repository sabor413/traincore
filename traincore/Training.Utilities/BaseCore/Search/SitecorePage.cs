using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.LuceneProvider;
using Sitecore.ContentSearch.SearchTypes;

namespace Training.Utilities.BaseCore.Search
{
    public class SitecoreItem : SearchResultItem
    {
        public readonly NameValueCollection fields = new NameValueCollection();

        #region Generic Page Properties

        [IndexField("page_heading")]
        public string PageHeading { get; set; }

        [IndexField("page_content")]
        public string PageContent { get; set; }

        [IndexField("page_summary")]
        public string PageSummary { get; set; }

        [IndexField("summaryimagecomputed")]
        public string SummaryImage { get; set; }

        [IndexField("summarycomputed")]
        public string SummaryComputed { get; set; }

        [IndexField("languagecomputed")]
        public string LanguageComputed { get; set; }

        #endregion

        #region Holidays

        [IndexField("type")]
        public Guid HolidayType { get; set; }

        [IndexField("terrain")]
        public Guid Terrain { get; set; }

        #endregion

    }
}
