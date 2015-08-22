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
    public class ComputedFieldRenderedImage : Sitecore.ContentSearch.ComputedFields.IComputedIndexField
    {
        public object ComputeFieldValue(IIndexable indexable)
        {
            string renderedField;

            Item obj = (Item)(indexable as SitecoreIndexableItem);

            if (obj.Fields["Summary Image"] != null && !String.IsNullOrEmpty(obj.Fields["Summary Image"].Value))
            {
                string processed = FieldRenderer.Render(obj, "Summary Image");

                if (processed.Contains("/sitecore/shell"))
                {
                    processed = processed.Replace("/sitecore/shell", String.Empty);
                }

                return processed;

            }

            return null;
        }
        public string FieldName { get; set; }
        public string ReturnType { get; set; }
    }
}
