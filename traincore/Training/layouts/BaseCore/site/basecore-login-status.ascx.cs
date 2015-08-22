namespace Training.layouts.BaseCore.site
{
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Globalization;
    using Sitecore.Links;
    using System;
    using Training.Utilities.Basecore.References;

    public partial class basecore_login_status : System.Web.UI.UserControl
    {


        private void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetLoginTexts();
            }
        }

        private bool ShouldShowLogin()
        {
            var siteroot = ItemReferences.SiteRoot;
            if (siteroot == null) return false;
            return !string.IsNullOrEmpty(siteroot["Login page"]);
        }

        private Item GetLoginPage()
        {
            var siteroot = ItemReferences.SiteRoot;
            if (siteroot == null) return null;

            ReferenceField loginPageField = siteroot.Fields["login page"];
            return loginPageField.TargetItem;
        }

        private void SetLoginTexts()
        {
            if (ShouldShowLogin())
            {
                if (Sitecore.Context.IsLoggedIn) //user is logged in
                {
                    LoginStatusLiteral.Text = String.Format(Translate.Text("Logged in as {0}"), Sitecore.Context.User.LocalName);
                    LogLink.Text = Translate.Text("Logout");
                }
                // else if ([...]) // user is known from a previous log in - soft login
                //{

                //}
                else //user is logged out
                {
                    LoginStatusLiteral.Text = "Not logged in";
                    LogLink.Text = Translate.Text("Login");
                }
            }
            else
            {
                LoginStatusLiteral.Visible = LogLink.Visible = false;
            }
        }



        protected void LogLink_Click(object sender, EventArgs e)
        {

            //user is logged in so clicking to log out
            if (Sitecore.Context.IsLoggedIn)
            {
                Sitecore.Context.Logout();
                SetLoginTexts();
            }
            else //logged out so clicking to log in
            {
                var loginItem = GetLoginPage();
                if (loginItem != null)
                {
                    Response.Redirect(LinkManager.GetItemUrl(loginItem));
                }
            }
        }
    }
}