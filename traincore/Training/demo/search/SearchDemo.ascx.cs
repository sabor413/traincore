using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Training.demo.search
{
    public partial class SearchDemo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Clear()
        {
            rpSearchDemo.DataSource = null;
            rpSearchDemo.DataBind();

            lblFacet.Text = "";
            lblFacet.Visible = false;
            lblTotalSrch.Text = "";
            lblTotalSrch.Visible = false;
        }

        protected void DemoA_Click(object sender, EventArgs e)
        {
            Clear();

            var index = ContentSearchManager.GetIndex("sitecore_web_index");

            using (var context = index.CreateSearchContext()) 
            {
                var queryable = context.GetQueryable<SearchResultItem>();

                rpSearchDemo.DataSource = queryable;
                rpSearchDemo.DataBind();
            }
        }

        protected void DemoB_Click(object sender, EventArgs e)
        {
            Clear();

            var index = ContentSearchManager.GetIndex("sitecore_web_index");

            using (var context = index.CreateSearchContext())
            {
                var queryable = context.GetQueryable<SearchResultItem>();

                var results = queryable.Page(1, 10);

                rpSearchDemo.DataSource = results;
                rpSearchDemo.DataBind();
            }
        }

        protected void DemoC_Click(object sender, EventArgs e)
        {
            Clear();

            var index = ContentSearchManager.GetIndex("sitecore_web_index");

            Sitecore.Data.ID cycID = Sitecore.Context.Database.GetItem("/sitecore/content/sitecore-cycling-holidays").ID;

            using (var context = index.CreateSearchContext())
            {
                var queryable = context.GetQueryable<SearchResultItem>();

                var results = queryable.Where(x => x.Paths.Contains(cycID));

                rpSearchDemo.DataSource = results;
                rpSearchDemo.DataBind();
            }
        }

        protected void DemoD_Click(object sender, EventArgs e)
        {
            Clear();

            var index = ContentSearchManager.GetIndex("sitecore_web_index");

            using (var context = index.CreateSearchContext())
            {
                var queryable = context.GetQueryable<SearchResultItem>();

                var results = queryable.Where(x => x.Name.Contains("bike"));

                rpSearchDemo.DataSource = results;
                rpSearchDemo.DataBind();
            }
        }

        protected void DemoE_Click(object sender, EventArgs e)
        {
            Clear();

            var index = ContentSearchManager.GetIndex("sitecore_web_index");

            using (var context = index.CreateSearchContext())
            {
                var queryable = context.GetQueryable<SearchResultItem>();

                var results = queryable.Where(x => x["page_heading"].Contains("bike"));

                rpSearchDemo.DataSource = results;
                rpSearchDemo.DataBind();
            }
        }

        protected void DemoF_Click(object sender, EventArgs e)
        {
            Clear();

            var index = ContentSearchManager.GetIndex("sitecore_web_index");

            using (var context = index.CreateSearchContext())
            {
                var queryable = context.GetQueryable<CustomSearch>();

                var results = queryable.Where(x => x.PageHeading.Contains("bike"));

                rpSearchDemo.DataSource = results;
                rpSearchDemo.DataBind();
            }
        }

        protected void DemoG_Click(object sender, EventArgs e)
        {
            Clear();

            var index = ContentSearchManager.GetIndex("sitecore_web_index");

            using (var context = index.CreateSearchContext())
            {
                var queryable = context.GetQueryable<CustomSearch>();

                var results = queryable.Where(x => x.PageHeading.Contains("bike"))
                    .GetResults();

                lblTotalSrch.Visible = true;
                lblTotalSrch.Text = "Total Search Results: " + results.TotalSearchResults.ToString();

                rpSearchDemo.DataSource = results.Hits.Select(x => x.Document);
                rpSearchDemo.DataBind();
            }
        }

        protected void DemoH_Click(object sender, EventArgs e)
        {
            Clear();

            var index = ContentSearchManager.GetIndex("sitecore_web_index");

            using (var context = index.CreateSearchContext())
            {
                var queryable = context.GetQueryable<CustomSearch>();

                var results = queryable.Where(x => x.TemplateName.Equals("Holiday"))
                    .FacetOn(x => x.TemplateName)
                    .FacetOn(x => x.Location)
                    .FacetOn(x => x.PageHeading)
                    .GetResults();

                lblTotalSrch.Visible = true;
                lblTotalSrch.Text = "Total Search Results: " + results.TotalSearchResults.ToString();

                #region DYNAMIC TABLE CODE
                lblFacet.Visible = true;
                lblFacet.Text = "<table><b><u>Facet Information</u></b><br />";
                foreach (FacetCategory facet in results.Facets.Categories)
                {
                    lblFacet.Text += "<tr><td><b>" + facet.Name + "</b>:</td></tr>";
                    foreach (FacetValue facetv in facet.Values)
                    {
                        lblFacet.Text += "<tr><td>&nbsp;</td><td>" + facetv.Name + " (" + facetv.AggregateCount.ToString() + ")</td></tr>"; 
                    }
                }
                lblFacet.Text += "</table>";
                #endregion

                rpSearchDemo.DataSource = results.Hits.Select(x => x.Document);
                rpSearchDemo.DataBind();
            }
        }
    }
}