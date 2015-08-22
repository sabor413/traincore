namespace Training.layouts.BaseCore.content
{
    using Generic.SitecoreUtilities.Sublayouts;
    using Sitecore.Globalization;
    using Sitecore.Security.Authentication;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class basecore_login : BaseUserControl
    {
        private static string DefaultDomain = "extranet";
        private void Page_Load(object sender, EventArgs e)
        {
            PasswordRequiredFieldValidator.ErrorMessage = Translate.Text(PasswordRequiredFieldValidator.ErrorMessage);
            UserRequiredFieldValidator.ErrorMessage = Translate.Text(UserRequiredFieldValidator.ErrorMessage);
            CustomValidator.ErrorMessage = Translate.Text(CustomValidator.ErrorMessage);
        }

        protected void SubmitButton_OnClick(object sender, EventArgs e)
        {
            var username = UserTextBox.Text;
            if (!username.Contains("\\"))
            {
                username = string.Concat(DefaultDomain, '\\', username);
            }

            if (CustomValidator.IsValid = AuthenticationManager.Login(username, PasswordTextBox.Text))
            {
                //user has succesfully logged in
                Response.Redirect("/");
            }
            PasswordRequiredFieldValidator.Visible = false;
        }
    }
}