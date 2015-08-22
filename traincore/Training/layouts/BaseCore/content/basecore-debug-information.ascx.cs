namespace Training.layouts.BaseCore.content
{
    using System;
using System.Collections.Generic;
using Training.Utilities.DebugInformation;

    public partial class basecore_debug_information : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
        }

        public IEnumerable<Row> GetData()
        {
            var rows = new RowCollection();

            if (true) //check if analytics enabled )
            {
                rows.Add("Analytics enabled", "true");

                //visitor information
                rows.Add("Visitor Information", "[visitor id]")
                    .AddTextToValue("number of visits [x]");

                //visit information
                rows.Add("Visit Information", "Started [xxxx] ")
                    .AddTextToValue("No. of pages [x]");


                //latest pages
                var pagesRow = rows.Add("Latest pages");


                pagesRow.AddTextToValue("[page 1]");
                pagesRow.AddTextToValue("[page 2]");
                pagesRow.AddTextToValue("[page 3]");
                pagesRow.AddTextToValue("[...]");

            }
            else
            {
                rows.Add("Analytics enabled", "false");
            }
            return rows;
        }
    }
}