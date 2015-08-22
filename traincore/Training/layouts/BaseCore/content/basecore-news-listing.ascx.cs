using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Data.Items;
using Training.Utilities.Basecore.References;

namespace Training.BaseCore.Layouts.Content
{
    /// <summary>
    /// The news listing sublayout.
    /// </summary>
    public partial class NewsListing : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Item newsItem = Sitecore.Context.Item;

            if (newsItem.TemplateID == TemplateReferences.NewsListing)
            {
                List<Item> descendants = newsItem.Axes.GetDescendants().ToList();

                if (descendants.Any())
                {   
                    rpNewsListing.DataSource = descendants;
                    rpNewsListing.DataBind();
                }
            }            
        }
    }
}