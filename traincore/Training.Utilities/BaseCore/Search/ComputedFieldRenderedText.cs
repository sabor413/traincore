using Sitecore.ContentSearch;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Utilities.BaseCore.Search
{
    public class ComputedFieldRenderedText : Sitecore.ContentSearch.ComputedFields.IComputedIndexField
    {
        public object ComputeFieldValue(IIndexable indexable)
        {
            string renderedField;

            Item obj = (Item)(indexable as SitecoreIndexableItem);

            if (obj.Fields["Page Summary"] != null && !String.IsNullOrEmpty(obj.Fields["Page Summary"].Value))
            {
                return FieldRenderer.Render(obj, "Page Summary");

            }

            return null;
        }
        public string FieldName { get; set; }
        public string ReturnType { get; set; }
    }
}
