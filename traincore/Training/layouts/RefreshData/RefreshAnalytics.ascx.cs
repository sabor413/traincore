using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.SecurityModel;

namespace Training.layouts.RefreshData
{
    public partial class RefreshAnalytics : System.Web.UI.UserControl
    {
        public static string ClassName { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ClassName = "msgHide";
        }


        protected string getConnnectionStr(string name) 
        {
            string connectionstr = null; 
            ConnectionStringSettings str = ConfigurationManager.ConnectionStrings[name];
            if (str != null) 
            {
                connectionstr = str.ConnectionString;
            }
            return connectionstr;
        }
        
        protected void btnRefresh_Click(object sender, EventArgs e) 
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(getConnnectionStr("analytics"));
                SqlCommand command = new SqlCommand("sp_sc_Refresh_Analytics", sqlConnection);           
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@lastUpdate", SqlDbType.DateTime));
                command.Parameters["@lastUpdate"].Direction = ParameterDirection.Output;
                sqlConnection.Open();
                command.ExecuteNonQuery();
                var lastUpdate = (DateTime)command.Parameters["@lastUpdate"].Value;
                sqlConnection.Close();
                btnRefresh.Enabled = false;

                // update campaign startdate and enddate
                using (new SecurityDisabler())
                {
                    var masterDb = Sitecore.Configuration.Factory.GetDatabase("master");
                    var campaignsRoot = masterDb.GetItem("/sitecore/system/Marketing Center/Campaigns");
                    var campaigns = campaignsRoot.Axes.GetDescendants()
                        .Where(x => x.TemplateID == new ID("{94FD1606-139E-46EE-86FF-BC5BF3C79804}")); // Campaign template ID
                    foreach (var campaign in campaigns)
                    {
                        var startDateField = new DateField(campaign.Fields["StartDate"]);
                        var endDateField = new DateField(campaign.Fields["EndDate"]);
                        var daySpan = DateTime.UtcNow - lastUpdate;

                        // update item field
                        using (new EditContext(campaign))
                        {
                            campaign.Editing.BeginEdit();
                            if (!string.IsNullOrEmpty(startDateField.Value))
                            {
                                startDateField.Value = DateUtil.ToIsoDate(startDateField.DateTime.AddDays(daySpan.Days));
                            }

                            if (!string.IsNullOrEmpty(endDateField.Value))
                            {
                                endDateField.Value = DateUtil.ToIsoDate(endDateField.DateTime.AddDays(daySpan.Days));
                            }

                            campaign.Editing.EndEdit();
                        }
                    }
                }

                ClassName = "msgShow";
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }

            
        }
    }
}