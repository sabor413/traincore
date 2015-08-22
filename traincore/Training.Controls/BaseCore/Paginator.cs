using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.Utilities.BaseCore.References;
using Training.Utilities.BaseCore.Search;
[assembly: TagPrefix("Training.Controls.BaseCore", "tc")]

namespace Training.Controls.BaseCore
{
    public class Paginator : WebControl
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }

        protected override void Render(System.Web.UI.HtmlTextWriter output)
        {
            var searchLinkManager = new SearchLinkManager();
            int pages = Total / PageSize;

            if (Total % PageSize > 0)
            {
                pages = pages + 1;
            }

            if (pages > 1)
            {

                for (int i = 1; i <= pages; i++)
                {
                    output.AddAttribute(System.Web.UI.HtmlTextWriterAttribute.Class, "searchPagination");

                    if (i != Page)
                    {
                        output.AddAttribute(System.Web.UI.HtmlTextWriterAttribute.Href, searchLinkManager.GetPageLink(i));
                        output.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.A);
                        output.WriteLine(i.ToString());
                        output.RenderEndTag();
                    }
                    else
                    {
                        output.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Span);
                        output.WriteLine(i.ToString());
                        output.RenderEndTag();
                    }
                }
            }
        }
    }
}
