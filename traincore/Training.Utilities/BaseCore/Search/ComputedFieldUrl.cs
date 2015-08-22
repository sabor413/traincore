using Sitecore.Configuration;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Resources.Media;
using Sitecore.Sites;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Utilities.BaseCore.Search
{
    public class ComputedFieldUrl : Sitecore.ContentSearch.ComputedFields.IComputedIndexField
    {
        public string FieldName { get; set; }

        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            Item item = (Item)(indexable as SitecoreIndexableItem);
            if (item == null)
            {
                return null;
            }
            if (item.Paths.IsMediaItem)
            {
                return MediaManager.GetMediaUrl(item);
            }
            UrlOptions defaultUrlOptions = LinkManager.GetDefaultUrlOptions();
            //defaultUrlOptions.LanguageEmbedding= LanguageEmbedding.Never;
            defaultUrlOptions.SiteResolving = Settings.Rendering.SiteResolving;

            var link = LinkManager.GetItemUrl(item, defaultUrlOptions);
            var noProtocol = link.Replace("://", String.Empty);
            var siteName = noProtocol.Split('/');

            var processedLink = noProtocol.Replace(siteName[0], String.Empty);          
            return processedLink;           
        }
    }
}
