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
    public class ComputedFieldLanguage : Sitecore.ContentSearch.ComputedFields.IComputedIndexField
    {
        public object ComputeFieldValue(IIndexable indexable)
        {
            string renderedField;

            Item obj = (Item)(indexable as SitecoreIndexableItem);

            return obj.Language.CultureInfo.Name.Replace("-", String.Empty);
        }
        public string FieldName { get; set; }
        public string ReturnType { get; set; }
    }
}
