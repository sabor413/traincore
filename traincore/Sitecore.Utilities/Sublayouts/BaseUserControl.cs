using System;
using System.Collections.Specialized;
using Sitecore.Data.Items;
using Sitecore.Web;
using System.Linq;
using Sitecore.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using Sitecore.Globalization;
using Sitecore.Analytics;

namespace Generic.SitecoreUtilities.Sublayouts
{
    public class BaseUserControl : System.Web.UI.UserControl
    {
        public Item DataSourceItem { get; set; }
        private NameValueCollection Parameters;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            DataSourceItem = GetDataSourceItem() ?? Sitecore.Context.Item;
            if (Parameters == null)
            {
                Parameters = WebUtil.ParseUrlParameters(Attributes["sc_parameters"]);
                foreach (var prop in this.GetType().GetProperties())
                {
                    if (Parameters.AllKeys.Contains(prop.Name))
                    {
                        if (prop.PropertyType == typeof(string))
                        {
                            prop.SetValue(this, Parameters[prop.Name]);
                        }
                        else if (prop.PropertyType == typeof(Sitecore.Data.ID))
                        {
                            var stringID = Parameters[prop.Name];
                            if (Sitecore.Data.ID.IsID(stringID))
                            {
                                prop.SetValue(this, new ID(stringID));
                            }
                        }
                    }
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            //cancel page tracking if is postback
            if (IsPostBack)
            {
                Tracker.Current.CurrentPage.Cancel();
            }
            foreach (var control in Controls)
            {
                if (control is Label || control is Button)
                {
                    var textControl = control as ITextControl;
                    if (textControl != null)
                    {
                        textControl.Text = Translate.Text(textControl.Text);
                    }
                }
                else if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    var placeholder = textBox.Attributes["placeholder"];
                    if (!string.IsNullOrEmpty(placeholder))
                    {
                        textBox.Attributes["placeholder"] = Translate.Text(placeholder);
                    }
                }

            }
            base.OnLoad(e);
        }

        protected virtual Item GetDataSourceItem()
        {
            var ds = Attributes["sc_datasource"]; //this only works in v.7 up1+
            if (!string.IsNullOrWhiteSpace(ds))
            {
                return Sitecore.Context.Database.GetItem(ds);
            }
            return null;
        }

        protected virtual string GetParameter(string key)
        {
           
            return Parameters[key];
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            using (new ContextItemSwitcher(DataSourceItem))
            {
                base.Render(writer);
            }
        }
    }
}