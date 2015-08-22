using Sitecore;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Web.UI.WebControls;

namespace Training.Utilities.BaseCore.Polls
{
    public class Poll
    {
        public string Question { get; set; }
        public string Tag { get; set; }
        public IEnumerable<Answer> PossibleAnswers { get; set; }
        public string SelectedAnswer { get; set; }

        public Poll()
        {

        }

        public Poll(Item item)
        {
            if (item != null)
            {
                Question = FieldRenderer.Render(item,"question");
                Tag = StringUtil.GetString(item["tag"], item.Name);
                PossibleAnswers = item.Children.Select
                    (i => new Answer(i)).ToList();
            }
        }
    }

}
