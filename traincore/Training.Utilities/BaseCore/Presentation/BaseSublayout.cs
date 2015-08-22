using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web.UI;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Data.Query;
using Sitecore.Web.UI;
using Sitecore.Web.UI.WebControls;

namespace Training.Utilities.Basecore.Base
{
    /// <summary>
    /// A base class with properties that are common across all sublayouts, so that the same code does not have
    /// to be implemented every time. A commented version of these properties can be seen in <see cref="Training.BaseCore.Layouts.Spots.GeneralSpot"/>,
    /// which, for the sake of demonstration, inherits directly from UserControl and duplicates the functionality seen here.
    /// </summary>
    public abstract class BaseSublayout : UserControl
    {        
        private Item _item = null;
        public Item GetItem()
        {
            // 
            if (_item == null)
            {
                if (Parent is Sublayout)
                {
                    if (!String.IsNullOrEmpty(((Sublayout)Parent).DataSource))
                    {
                        _item = Sitecore.Context.Database.GetItem(((Sublayout)Parent).DataSource);
                    }
                    else
                    {
                        _item = Sitecore.Context.Item;
                    }
                }
            }

            return _item;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Parameters
        {
            get
            {
                string parameters = String.Empty;

                Sublayout sublayout = this.Parent as Sublayout;

                if (sublayout != null)
                {
                    parameters = sublayout.Parameters;
                }

                return parameters;
            }
        }
    }
}
