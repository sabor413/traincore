using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using Sitecore.Data.Items;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Generic.SitecoreUtilities.Parameters;

namespace Training.Utilities.Basecore.References
{
    /// <summary>
    /// Utility used to get common Sitecore sublayout parameters from a NameValueCollection object.
    /// </summary>
    public class ParameterReferences
    {
        /// <summary>
        /// 
        /// </summary>
        public static bool HideImage(NameValueCollection parameters)
        {
            return ParameterUtils.FieldValueGet<bool>(parameters, "Hide Image");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Item HeadingType(NameValueCollection parameters)
        {
            return ParameterUtils.ReferencedItemGet(parameters, "Heading");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string Class(NameValueCollection parameters)
        {
            return ParameterUtils.ReferencedItemFieldValueGet<string>(parameters, "Class", "CSS Classes");            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string WidthClass(NameValueCollection parameters)
        {
            return ParameterUtils.ReferencedItemFieldValueGet<string>(parameters, "Widget Width", "CSS Classes");
        }     

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string ImageOrientation(NameValueCollection parameters)
        {
            return ParameterUtils.ReferencedItemFieldValueGet<string>(parameters, "Image Orientation", "Text");
        }
    }
}
