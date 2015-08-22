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
using Sitecore.Web.UI.WebControls;
using Sitecore.Links;
using Training.Utilities.BaseCore.References;
using Sitecore.Globalization;

namespace Training.BaseCore.Layouts.Search
{
    public partial class SearchForm : BaseSublayout
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblTerrain.Text = Translate.Text("LabelTerrainType");
                lblHoliday.Text = Translate.Text("LabelHolidayType");
                lblSearchText.Text = Translate.Text("LabelSearchTerm");
                Search.Text = Translate.Text("ButtonBookHoliday");

                foreach (Item i in ItemReferences.HolidayTypes.Children)
                {
                    if (i.Versions.Count > 0) 
                    {
                        ddlHolidayType.Items.Add(new ListItem(HttpUtility.HtmlDecode(FieldRenderer.Render(i, "Text", "disable-web-editing=true")), i.ID.Guid.ToString()));
                    }                   
                }

                foreach (Item i in ItemReferences.Terrains.Children)
                {
                    if (i.Versions.Count > 0) 
                    {
                        ddlTerrain.Items.Add(new ListItem(HttpUtility.HtmlDecode(FieldRenderer.Render(i, "Text", "disable-web-editing=true")), i.ID.Guid.ToString()));
                    }                   
                }

                var searchLinkManager = new SearchLinkManager();
                var searchObject = searchLinkManager.RetrieveSearchInformation();
                if (searchObject != null)
                {

                    string v = searchObject.HolidayType.ToString();

                    ddlHolidayType.SelectedIndex = ddlHolidayType.Items.IndexOf(ddlHolidayType.Items.FindByValue(searchObject.HolidayType.ToString()));
                    ddlTerrain.SelectedValue = searchObject.Terrain.ToString();
                    txtSearchText.Text = searchObject.Text;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Search_Click(object sender, EventArgs e)
        {
            // Clear existing holiday search session
            Session.Remove(Keys.HolidaySearchSession);

            SearchObject searchObject = new SearchObject()
            {
                Text = txtSearchText.Text,
                HolidayType = !String.IsNullOrEmpty(ddlHolidayType.SelectedValue) ? new Guid(ddlHolidayType.SelectedValue) : Guid.Empty,
                Terrain = !String.IsNullOrEmpty(ddlTerrain.SelectedValue) ? new Guid(ddlTerrain.SelectedValue) : Guid.Empty,
                Page = 1
            };
            var searchLinkManager = new SearchLinkManager();
            Response.Redirect(searchLinkManager.GetRedirectLink(searchObject), false);
        }
    }
}