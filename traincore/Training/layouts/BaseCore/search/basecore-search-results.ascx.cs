using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.Utilities.Basecore.Base;
using Sitecore.Search;
using Sitecore.Data;
using Training.Utilities.Basecore.References;
using Sitecore.ContentSearch.LuceneProvider;
using Training.Utilities.BaseCore.Search;
using Sitecore.Data.Items;
using Training.Utilities.BaseCore.References;
using Sitecore.ContentSearch.Linq;
using Sitecore.Web.UI.WebControls;
using Sitecore.ContentSearch;
using Sitecore.Globalization;
using Sitecore.Analytics;
using Sitecore.Analytics.Data;

namespace Training.BaseCore.Layouts.Search
{
    public partial class SearchResults : BaseSublayout
    {

        private const int itemsPerPage = 5;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ID template = TemplateReferences.Holiday.ID;
            Guid path = ItemReferences.SiteHome.ID.Guid;
            ID rootID = Sitecore.Context.Item.ID;

            // Get context database index
            SitecoreIndexableItem indexableItem = new SitecoreIndexableItem(Sitecore.Context.Item);
            var index = Sitecore.ContentSearch.ContentSearchManager.GetIndex(indexableItem);
            //var index = Sitecore.ContentSearch.ContentSearchManager.GetIndex(Sitecore.Context.Item as IIndexable);       

            // Set up search context
            using (var context = index.CreateSearchContext())
            {
                // Initiate query - use custsom SitecoreItem class
                IQueryable<SitecoreItem> query = context.GetQueryable<SitecoreItem>();

                // Retrieve rich search object from session - this is just a property bag
                SearchObject searchObject = GetSearchObject();

                // Build query from SearchObject properties
                if (searchObject != null)
                {
                    query = BuildQuery(searchObject, query);
                }

                //var computedLanguage = Sitecore.Context.Language.CultureInfo.Name.Replace("-", String.Empty);
                var language = Sitecore.Context.Language.ToString();

                // Append standard query parameters - e.g. language, template, root item
                // and get results object
                var results = query
                             .Where(x => x.Paths.Contains(rootID))
                             .Where(x => x.TemplateId == template)
                             .Where(x => x.Language == language)
                             .Page(searchObject.Page - 1, itemsPerPage)
                             .OrderBy(x => x.PageHeading)
                             .GetResults();


                if (results != null)
                {
                    if (results.Hits.Any())
                    {
                        rpHolidays.DataSource = results.Hits.Select(x => x.Document);
                        rpHolidays.DataBind();
                    }
                    ShowNoResultsMessage(results.Hits.Any());
                }

                pgPagination.Page = searchObject.Page;
                pgPagination.PageSize = itemsPerPage;
                pgPagination.Total = results.TotalSearchResults;
            }
        }

        private void ShowNoResultsMessage(bool hasresults)
        {
            if (!hasresults) // we don't have results
            {
                litNoResultsMessage.Text = Translate.Text(litNoResultsMessage.Text);
                
                //get most common searches with results
                var analyticsDB = new Training.Utilities.BaseCore.Analytics.AnalyticsDatabase();
                rpNoResults.DataSource = analyticsDB.MostCommonSearches();
                rpNoResults.DataBind();
            }

            NoResultsPanel.Visible = !hasresults;
        }

        /// <summary>
        /// Return search property bag (search term, terrtain type, holiday type) - this is a custom
        /// implementation and does not come as standard with Sitecore.
        /// </summary>
        /// <returns></returns>
        private SearchObject GetSearchObject()
        {
            var searchLinkManager = new SearchLinkManager();

            return searchLinkManager.RetrieveSearchInformation();
        }

        /// <summary>
        /// Build up query from options in the SearchObject.
        /// </summary>
        /// <param name="searchObject"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        private IQueryable<SitecoreItem> BuildQuery(SearchObject searchObject, IQueryable<SitecoreItem> query)
        {
            Guid holidayType = searchObject.HolidayType;
            Guid terrain = searchObject.Terrain;
            string text = searchObject.Text;

            if (terrain != Guid.Empty)
            {
                query = query.Where(x => x.Terrain == terrain);
            }
            if (holidayType != Guid.Empty)
            {
                query = query.Where(x => x.HolidayType == holidayType);
            }
            if (!String.IsNullOrEmpty(text))
            {
                query = query.Where(x => (x.PageHeading.Contains(text) || x.PageContent.Contains(text)));
            }

            return query;
        }

        public string FallbackHolidayImage
        {
            get
            {
                return FieldRenderer.Render(ItemReferences.SampleHolidayImage, "Image");
            }
        }

        protected void rpNoResults_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            var searchLinkManager = new SearchLinkManager();
            var url = searchLinkManager.GetRedirectLink(new SearchObject() { Text = e.CommandArgument.ToString() });
            Response.Redirect(url);
        }
    }
}