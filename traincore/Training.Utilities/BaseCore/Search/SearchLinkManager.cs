using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Training.Utilities.BaseCore.References;
using Generic.SitecoreUtilities.Configuration;

namespace Training.Utilities.BaseCore.Search
{
    public class SearchLinkManager
    {
        //private static readonly string SearchKey = "SearchResultPageId";
        //public string SearchResultsPage = ConfigurationUtils.GetAppSetting(SearchKey);
        public string SearchResultsPage = "{2144B62C-BEAB-4649-920C-6124624AF1C4}";
        public string GetRedirectLink(SearchObject searchObject)
        {
            StoreSearchInformation(searchObject);
      
            var holidaysItem = Sitecore.Context.Database.GetItem(SearchResultsPage);
            return String.Concat(LinkManager.GetItemUrl(holidaysItem), GetPageLink(searchObject.Page));
        }

        public string GetPageLink(int page)
        {
            return String.Format("?{0}={1}", Keys.SearchPage, page);
        }

        public void StoreSearchInformation(SearchObject searchObject)
        {
            var session = System.Web.HttpContext.Current.Session;

            // Clear existing holiday search session
            session.Remove(Keys.HolidaySearchSession);

            session.Add(Keys.HolidaySearchSession, searchObject);
        }

        public SearchObject RetrieveSearchInformation()
        {
            var searchObject = HttpContext.Current.Session[Keys.HolidaySearchSession] as SearchObject ?? new SearchObject();
            
            int page = 1;
            int.TryParse(HttpContext.Current.Request.QueryString[Keys.SearchPage],out page);
            if (page == 0)   //if no page parameter in the query string,default to 1 
            {
                page = 1;
            }
            searchObject.Page = page;
            
            return searchObject;

        }
    }


}
