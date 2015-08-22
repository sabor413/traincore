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
    /// A single image with a heading, text, and a link built from a gallery slide. Interchangeable with
    /// <see cref="Training.Controls.BaseCore.Gallery"/>
    /// </summary>
    public class Banner : WebControl
    {
        private static readonly string galleryItemImage = "Gallery Item Image";
        private static readonly string galleryItemHeading = "Gallery Item Heading";
        private static readonly string galleryItemText = "Gallery Item Text";
        private static readonly string galleryItemLink = "Gallery Item Link";
        private static readonly string slideContent = "slideContent";
        private static string headingElement = "span";
        private static string headingClass = "heading";
        private static readonly string headerImageClass = "headerImage";
        private static readonly string element = "Element";
        private static readonly string cssClass = "Class";
        private static readonly string maxWidth = "mw=960";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        protected override void DoRender(HtmlTextWriter output)
        {
            Item galleryItem = GetSingleSlide(this.GetItem());

            output.AddAttribute(HtmlTextWriterAttribute.Class, headerImageClass);
            output.RenderBeginTag(HtmlTextWriterTag.Div);

            if (galleryItem != null)
            {

                /* The banner can take a single gallery item, or an entire gallery - in which case it will pick a random slide. */

                // Example banner HTML:
                //
                // <div class="headerImage">
                //      <div>
                //        <img src="/~/media/BaseCore/Galleries/slide-forset.ashx?mw=960" alt="Forest cycling" width="960" height="400">
                //        <div class="slideContent">
                //            <span class="heading">Go abroad with your bike</span>
                //            <p>Challenge yourself by planning your next trip abroad.</p>
                //            <p><a href="/holidays/cycle-south-east-asia.aspx">Cycle South-East Asia</a></p>
                //        </div>
                //      </div>
                // </div>

                // <div class="headerImage">


                if (Heading != null)
                {
                    headingElement = FieldRenderer.Render(Heading, element);
                    headingClass = FieldRenderer.Render(Heading, cssClass);
                }

                // <div>
                output.RenderBeginTag(HtmlTextWriterTag.Div);

                // <img src="/~/media/BaseCore/Galleries/slide-forset.ashx?mw=960" alt="Forest cycling" width="960" height="400">
                output.Write(FieldRenderer.Render(galleryItem, galleryItemImage, maxWidth));

                // <div class="slideContent">
                output.AddAttribute(HtmlTextWriterAttribute.Class, slideContent);
                output.RenderBeginTag(HtmlTextWriterTag.Div);

                // <h2 class="heading">
                output.AddAttribute(HtmlTextWriterAttribute.Class, headingClass);
                output.RenderBeginTag(headingElement);

                output.Write(FieldRenderer.Render(galleryItem, galleryItemHeading));

                // </h2>
                output.RenderEndTag();

                // <p>
                output.RenderBeginTag(HtmlTextWriterTag.P);

                output.Write(FieldRenderer.Render(galleryItem, galleryItemText));

                // </p>
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

        /// <summary>
        /// Determines whether datasource is a gallery slide or entire gallery, and returns a random
        /// gallery slide from the gallery in the case of the latter.
        /// </summary>
        /// <param name="datasource"></param>
        /// <returns></returns>
        private static Item GetSingleSlide(Item datasource)
        {
            if (datasource.TemplateID == TemplateReferences.GalleryItem)
                return datasource;

            Item singleSlide = null;

            if (datasource.TemplateID == TemplateReferences.Gallery)
            {
                Random random = new Random();

                int i = random.Next(0, datasource.Children.Count - 1);

                singleSlide = datasource.Children[i];
            }

            return singleSlide;
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
