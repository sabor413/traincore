namespace Training.layouts.BaseCore.content
{
    using Sitecore.Data;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Web;
    using Sitecore.Web.UI.WebControls;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class RelatedArticles : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            MultilistField relatedArticlesField = Sitecore.Context.Item.Fields["Related Articles"];

            if (relatedArticlesField != null)
            {
                IEnumerable<Item> articles = relatedArticlesField.GetItems();

                if (articles.Any())
                {
                    rpArticles.DataSource = articles;
                    rpArticles.DataBind();
                }
            }

            var urlparameters = Attributes["sc_parameters"];

            var nvcparameters = WebUtil.ParseUrlParameters(urlparameters);

            var nvcclass = nvcparameters["Class"];

            if (!String.IsNullOrEmpty(nvcclass))
            {
                Guid nvcguid = Guid.Empty;
                if (Guid.TryParse(nvcclass, out nvcguid))
                {
                    Item parameteritem = Sitecore.Context.Database.GetItem(new ID(nvcguid));
                    CssClass = FieldRenderer.Render(parameteritem, "CSS Classes", "disable-web-editing=true");
                } 
            }
        }

        public string CssClass { get; set; }
    }
}