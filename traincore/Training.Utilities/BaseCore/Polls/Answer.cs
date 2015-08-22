using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Web.UI.WebControls;

namespace Training.Utilities.BaseCore.Polls
{
    public class Answer
    {
        private Sitecore.Data.Items.Item i;

        public Answer(string id) : this(Sitecore.Context.Database.GetItem(id)) { }

        public Answer(Sitecore.Data.Items.Item i)
        {
            this.i = i;
            Text = FieldRenderer.Render(i, "text");
            Value = i["value"];
            Id = i.ID.Guid;
            Checked = false;
            Tag = i.Parent["tag"];
        }

        public string Text { get; set; }   
        public string Value { get; set; }
        public Guid Id { get; private set; }


        public bool Checked { get; set; }
        public string Tag { get; set; }
    }
}
