namespace Training.layouts.BaseCore.widgets
{

    using Generic.SitecoreUtilities.Sublayouts;
    using Sitecore.Globalization;
    using System;
    using Training.Utilities.BaseCore.Polls;

    public partial class basecore_poll_widget : BaseUserControl
    {
        protected Poll poll;
        private void Page_Load(object sender, EventArgs e)
        {
            Submit.Text = Translate.Text("submit");
            ThankYouLiteral.Text = Translate.Text("thankyouLiteral");
            poll = new Poll(DataSourceItem);
            if (!IsPostBack)
            {
                AnswersList.DataSource = poll.PossibleAnswers;
                //AnswersList.SelectedValue = null;
                AnswersList.DataBind(); 
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            var selectedAnswer = AnswersList.SelectedValue;

            Submit.Visible = AnswersList.Visible = false;

            // We can store the selected value in a visitor tag

            ThankYouLiteral.Visible = true;   
        }
    }
}