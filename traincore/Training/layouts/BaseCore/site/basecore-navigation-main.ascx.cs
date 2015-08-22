namespace Training.layouts.BaseCore.site
{
    using Generic.SitecoreUtilities.Sublayouts;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Globalization;
    using Sitecore.Links;
    using System;
    using System.Collections;
    using System.Linq;
    using Training.Utilities.Basecore.References;
    using Training.Utilities.BaseCore.Search;

    public partial class basecore_navigation_main : BaseUserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            SearchButton.Text = Translate.Text("search");
        }

        public IEnumerable GetData_NavigationRepeater()
        {
            var siteroot = ItemReferences.SiteRoot;
            if (siteroot == null) return null;
            
            var navigationroot = siteroot.Database.GetItem(siteroot["Main Navigation Root"]);
            if (navigationroot == null) return null;

            return navigationroot.Children.Select(TransformMenuItem).Where(i=> i != null);
        }

        private object TransformMenuItem(Item i)
        {
            if (i.Template.Key == "simple item")
            {
                var navigationItem = i.Database.GetItem(i["Item"]);
                if (navigationItem == null || navigationItem["Hide from Navigation"] == "1") return null;
                return new { Text=navigationItem["navigation title"], Link=LinkManager.GetItemUrl(navigationItem), Class = IsCurrent(navigationItem) ? "current" : "" };
            }
            LinkField link = i.Fields["Link"];

            return new { Text = link.Text, Link = link.GetFriendlyUrl(), Class = "" };

        }

        private bool IsCurrent(Item navigationItem)
        {
            return (Sitecore.Context.Item.Axes.GetAncestors().Select(i => i.ID).Contains(navigationItem.ID) && navigationItem.Template.Key != "home") || (Sitecore.Context.Item.ID == navigationItem.ID);
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            SearchLinkManager searchLinkManager = new SearchLinkManager();
            SearchObject searchObject = new SearchObject()
            {
                Text = SearchBox.Text,
            };

            Response.Redirect(searchLinkManager.GetRedirectLink(searchObject), false);
        }
    }
}