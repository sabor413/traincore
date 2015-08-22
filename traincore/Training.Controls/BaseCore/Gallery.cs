using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Web.UI;
using Training.Utilities.Basecore.Base;
using System.Web.UI;
using Sitecore.Data.Items;
using Training.Utilities.Basecore.References;
using Sitecore.Web.UI.WebControls;
using Training.Utilities.Basecore;

namespace Training.Controls.BaseCore
{
    /// <summary>
    /// A set of gallery slides, each with with a heading, text, and a link. Interchangeable with
    /// <see cref="Training.Controls.BaseCore.Banner"/>
    /// </summary>
    public class Gallery : WebControl
    {
        #region Strings

        private static readonly string galleryItemImage = "Gallery Item Image";
        private static readonly string galleryItemHeading = "Gallery Item Heading";
        private static readonly string galleryItemText = "Gallery Item Text";
        private static readonly string galleryItemLink = "Gallery Item Link";
        private static readonly string slides = "slides";
        private static readonly string slidesContainer = "slides_container";
        private static readonly string slideContent = "slideContent";
        private static string headingElement = "span";
        private static string headingClass = "heading";
        private static readonly string element = "Element";
        private static readonly string cssClass = "Class";
        private static readonly string maxWidth = "mw=960";
        private string uniqueID = String.Empty;

        #endregion

        protected override void OnPreRender(EventArgs e)
        {
            uniqueID = "#" + slides + "-" + this.ClientID;

            ClientScriptManager cs = Page.ClientScript;

            if (!cs.IsStartupScriptRegistered(uniqueID))
            {
                cs.RegisterStartupScript(typeof(Page), uniqueID, String.Format("<script>jQuery(document).ready(function ($) {{ SlideShow.init('{0}') }});</script>", uniqueID));
            }

            base.OnPreRender(e);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        protected override void DoRender(HtmlTextWriter output)
        {
            string uniqueID = slides + "-" + this.ClientID;

            Item datasource = this.GetItem();

            // <div id="slides">
            output.AddAttribute(HtmlTextWriterAttribute.Id, uniqueID);
            output.AddAttribute(HtmlTextWriterAttribute.Class, "slides");
            output.RenderBeginTag(HtmlTextWriterTag.Div);

            if (datasource != null)
            {
                if (datasource.TemplateID == TemplateReferences.Gallery)
                {
                    // Example gallery HTML:
                    //
                    // <div id="slides">
                    //  <div class="slides_container">
                    //      <div>
                    //          <img src="/~/media/BaseCore/Galleries/slide-canyon.ashx?mw=960" alt="Canyon cycling" width="960" height="400" />
                    //          <div class="slideContent">
                    //              <span class="heading">Active family holidays in Wales</span><p>Whisk the family away to an active weekend in the Welsh mountains.</p>
                    //          </div>
                    //      </div>
                    //      <div>
                    //          <img src="/~/media/BaseCore/Galleries/slide-forset.ashx?mw=960" alt="Forest cycling" width="960" height="400" /><div class="slideContent">
                    //          <span class="heading">Go abroad with your bike</span>
                    //          <p>Challenge yourself by planning your next trip abroad.</p>
                    //          <p><a href="/holidays/cycle-south-east-asia.aspx">Cycle South-East Asia</a></p>
                    //      </div>
                    //  </div>
                    //  <div>
                    //      <img src="/~/media/BaseCore/Galleries/slide-bike.ashx?mw=960" alt="Red bike" width="960" height="400" /><div class="slideContent">
                    //      <span class="heading">Try a new bike</span><p>Try a bike you  might not have chosen for yourself.</p><p><a href="/bikes/the-allrounder.aspx">Welsh mountain biking adventure</a></p>
                    //  </div>
                    // </div>

                    // <div class="slides_container">
                    output.AddAttribute(HtmlTextWriterAttribute.Class, slidesContainer);
                    output.RenderBeginTag(HtmlTextWriterTag.Div);

                    if (Heading != null)
                    {
                        headingElement = FieldRenderer.Render(Heading, element);
                        headingClass = FieldRenderer.Render(Heading, cssClass);
                    }

                    foreach (Item galleryItem in datasource.Children.Where(x => x.TemplateID == TemplateReferences.GalleryItem && x.Versions.Count>0))
                    {
                        // <div>
                        output.RenderBeginTag(HtmlTextWriterTag.Div);
                        output.Write(FieldRenderer.Render(galleryItem, galleryItemImage, maxWidth));

                        // <div class="slideContent">
                        output.AddAttribute(HtmlTextWriterAttribute.Class, slideContent);
                        output.RenderBeginTag(HtmlTextWriterTag.Div);

                        // <h2 class="headingClass">
                        output.AddAttribute(HtmlTextWriterAttribute.Class, headingClass);
                        output.RenderBeginTag(headingElement);

                        // Heading text
                        output.Write(FieldRenderer.Render(galleryItem, galleryItemHeading));

                        // </h2>
                        output.RenderEndTag();

                        // <p>
                        output.RenderBeginTag(HtmlTextWriterTag.P);
                        output.Write(FieldRenderer.Render(galleryItem, galleryItemText));
                        
                        //</p>
                        output.RenderEndTag();

                        string link = FieldRenderer.Render(galleryItem, galleryItemLink);

                        if (!String.IsNullOrEmpty(link))
                        {
                            // <p>
                            output.RenderBeginTag(HtmlTextWriterTag.P);
                            output.Write(FieldRenderer.Render(galleryItem, galleryItemLink));

                            // </p>
                            output.RenderEndTag();
                        }

                        // </div>
                        output.RenderEndTag();

                        // </div>
                        output.RenderEndTag();
                    }

                    // </div>
                    output.RenderEndTag();
                }
            }

            // </div>
            output.RenderEndTag();
        }

        /// <summary>
        /// 
        /// </summary>
        private Item Heading
        {
            get
            {
                return ParameterReferences.HeadingType(Sitecore.Web.WebUtil.ParseUrlParameters(this.Parameters));
            }
        }
    }
}
