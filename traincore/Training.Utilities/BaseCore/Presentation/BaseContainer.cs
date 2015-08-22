using System;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using Training.Utilities.Basecore.References;

namespace Training.Utilities.Basecore.Base
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseContainer : BaseSublayout
    {
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
    }
}
