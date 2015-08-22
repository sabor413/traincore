using System;
using Sitecore.Data.Items;
using Training.Utilities.Basecore.Base;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Fields;
using Sitecore;
using System.Linq;
using Sitecore.Data;
using Sitecore.Layouts;
using Training.Utilities.Basecore.References;
using Sitecore.SecurityModel;
using System.Web.Services;
using System.Collections.Generic;
using Training.Utilities.BaseCore.References;
using System.Collections;
using System.Text.RegularExpressions;
using Training.Utilities.BaseCore.Holidays;
using Training.Utilities.BaseCore.Extensions;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;
using Training.Utilities.BaseCore.Membership;
using Sitecore.Security.Accounts;
using Training.Utilities.BaseCore.Pipelines;
using Sitecore.Pipelines;

namespace Training.BaseCore.Layouts.Content {

    /// <summary>
    /// 
    /// </summary>
    public partial class BookHoliday : BaseSublayout
    {
        private readonly string fnThankYouPage = "Thank You Page";
        private readonly string dbMaster = "master";
        private readonly string fnPageTitle = "Page Title";
        private readonly string fnPageHeading = "Page Heading";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDowns();

                if (ItemReferences.InvalidName != null && ItemReferences.InvalidSurname !=null)
                {
                    txtFirstName.Attributes["data-msg-required"] = FieldRenderer.Render(ItemReferences.InvalidName, "Text", "disable-web-editing=true");
                    txtSurname.Attributes["data-msg-required"] = FieldRenderer.Render(ItemReferences.InvalidSurname, "Text", "disable-web-editing=true");

                    scTextValidationName.Item = ItemReferences.InvalidName;
                    scTextValidationSurname.Item = ItemReferences.InvalidSurname;
                }
            
                if (!Request.QueryString.HasKeys())
                    return;

                Date = Request.QueryString[Keys.DateID];

                if (!String.IsNullOrEmpty(Date))
                {
                    Item holidayDate = Sitecore.Context.Database.GetItem(new ID(Date));

                    if (holidayDate != null)
                    {
                        string holidayID = holidayDate.Axes.GetAncestors().Where(x => x.TemplateID == TemplateReferences.Holiday).Select(x => x.ID).FirstOrDefault().ToString();
                        ddlHoliday.SelectedValue = holidayID;

                        Item holiday = Sitecore.Context.Database.GetItem(new ID(new Guid(holidayID)));

                        PopulatDateDropDown(holiday);
                        ddlHolidayDate.SelectedValue = Date;
                    }
                }
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBook_Click(object sender, EventArgs e)
        {
            if (ItemReferences.SiteRoot != null)
            {
                // Equivalent to Sitecore.Configuration.Factory.GetDatabase("master");
                Database master = Sitecore.Data.Database.GetDatabase(dbMaster);

                Item bookingsRoot = master.GetItem(ItemReferences.BookingsRoot.ID);

                if (bookingsRoot != null)
                {
                    // Rather than using the SecurityDisabler(), set up a user whose job is to create bookings, and use the UserSwitcher() to 
                    // run the code with their security privileges.

                    using (new SecurityDisabler())
                    {
                        string name = Regex.Replace(txtFirstName.Text + txtSurname.Text, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled).ToLower();

                        Guid dateGuid;
                        if (Guid.TryParse(ddlHolidayDate.SelectedValue, out dateGuid))
                        {
                            // create new booking
                            Booking booking = new Booking();

                            booking.BookingItemName = Encoder.XmlEncode(name + DateUtil.IsoNow);
                            booking.FirstName = Encoder.HtmlEncode(txtFirstName.Text);
                            booking.Surname = Encoder.HtmlEncode(txtSurname.Text);
                            booking.HolidayDate = dateGuid;
                            booking.BookingsRoot = master.GetItem(ItemReferences.BookingsRoot.ID);

                            // Execute booking pipeline
                            HolidayBookingPipelineArgs pipelineArgs = new HolidayBookingPipelineArgs(Sitecore.Context.Item, booking);

                            CorePipeline.Run("bookHoliday", pipelineArgs);
                            if (!pipelineArgs.Valid && !string.IsNullOrEmpty(pipelineArgs.Message))
                            {
                                // Execute code here to deal with failed validation
                            }
                        }
                    }

                    // get URL for thank-you page - specified in Sitecore - and redirect
                    ReferenceField redirect = Sitecore.Context.Item.Fields[fnThankYouPage];

                    if (redirect.TargetItem != null)
                    {
                        Response.Redirect(Sitecore.Links.LinkManager.GetItemUrl(redirect.TargetItem), false);
                    }
                }
            }
        }

        #region Dropdowns

        /// <summary>
        /// Gets dates associated with the selected holiday.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlHoliday_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid holidayItem;
            if (Guid.TryParse(ddlHoliday.SelectedValue, out holidayItem))
            {
                Item holiday = Sitecore.Context.Database.GetItem(new ID(holidayItem));

                if (holiday != null)
                {
                    PopulatDateDropDown(holiday);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="holiday"></param>
        private void PopulatDateDropDown(Item holiday)
        {
            ddlHolidayDate.Items.Clear();
            ddlHolidayDate.Items.Add(new ListItem("", ""));

            foreach (Item date in holiday.Axes.GetDescendants().Where(x => x.TemplateID == TemplateReferences.HolidayDate))
            {
                ddlHolidayDate.Items.Add(new ListItem(FieldRenderer.Render(date, fnPageHeading, "disable-web-editing=true"), date.ID.ToString()));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void BindDropDowns()
        {
            Item holidayRoot = ItemReferences.HolidaysRoot;

            foreach (Item holiday in holidayRoot.Axes.GetDescendants().Where(x => x.TemplateID == TemplateReferences.Holiday).ToList())
            {
                ddlHoliday.Items.Add(new System.Web.UI.WebControls.ListItem(FieldRenderer.Render(holiday, fnPageTitle, "disable-web-editing=true"), holiday.ID.ToString()));
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public string Date
        {
            get;
            set;
        }

    }
}