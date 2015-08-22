namespace Training.layouts.BaseCore.widgets
{
    using System;
    using Sitecore.Data.Items;
    using Training.Utilities.Basecore.Base;
    using Training.Utilities.Basecore.References;

    public partial class basecore_widget_traveller_quote : BaseWidget
    {
        private void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            Item datasource = this.GetItem();
            if (datasource != null) 
            {
                TravellerQuote.Item = datasource;
                QuoteAuthor.Item = datasource;
            }
        }
    }
}