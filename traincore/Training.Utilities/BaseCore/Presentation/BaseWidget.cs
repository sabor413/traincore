using System;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using Training.Utilities.Basecore.References;

namespace Training.Utilities.Basecore.Base
{
    // TODO: Write an XSLT version of widget

    /// <summary>
    /// A 'widget' in the context of this site is a reuseable unit of content, regardless of where it occurs on the site.
    /// A 'widget' is the base class for 'spot' (right-hand column vertical content) and 'widget' (horizontal content - e.g. a row of blocks on the home page) 
    /// user controls - e.g. <see cref="Training.BaseCore.Layouts.Widgets.WidgetHalf"/> or <see cref="Training.BaseCore.Layouts.Widgets.WidgetThird"/>. 
    /// 
    /// All of these user controls use the same properties - like 'HideImage' and 'Css' - which is why they have been abstracted into this class.
    /// The functionality is duplicated in <see cref="Training.BaseCore.Layouts.Spots.GeneralSpot"/> for the sake of demonstration.
    /// 
    /// It also inherits properties like 'DataSource' and 'Parameters' from <see cref="Training.Utilities.Basecore.Base.BaseSublayout"/>.
    /// </summary>
    public abstract class BaseWidget : BaseSublayout
    {
        public bool HideImage
        {
            get
            {
                return ParameterReferences.HideImage(Sitecore.Web.WebUtil.ParseUrlParameters(this.Parameters));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Item HeadingType
        {
            get
            {
                return ParameterReferences.HeadingType(Sitecore.Web.WebUtil.ParseUrlParameters(this.Parameters));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ImageOrientation
        {
            get
            {
                return ParameterReferences.ImageOrientation(Sitecore.Web.WebUtil.ParseUrlParameters(this.Parameters));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Class
        {
            get
            {
                return ParameterReferences.Class(Sitecore.Web.WebUtil.ParseUrlParameters(this.Parameters));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string WidthClass
        {
            get
            {
                return ParameterReferences.WidthClass(Sitecore.Web.WebUtil.ParseUrlParameters(this.Parameters));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string HeadingPrefix 
        {
            get
            {
                if (HeadingType != null)
                {
                    string element = FieldRenderer.Render(HeadingType, "Element", "disable-web-editing=true");
                    string css = FieldRenderer.Render(HeadingType, "Class", "disable-web-editing=true");

                    if (!String.IsNullOrEmpty(element))
                    {
                        return String.Format("<{0}{1}>", element, !String.IsNullOrEmpty(css) ? String.Format(" class=\"{0}\"", css) : String.Empty);
                    }
                }

                return String.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string HeadingSuffix
        {
            get
            {
                if (HeadingType != null)
                {
                    string element = FieldRenderer.Render(HeadingType, "Element", "disable-web-editing=true");

                    if (!String.IsNullOrEmpty(element))
                    {
                        return String.Format("</{0}>", element);
                    }
                }

                return String.Empty;
            }
        }
    }
}
    