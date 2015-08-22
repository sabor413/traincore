using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Shell.Framework.Commands;
using Training.Utilities.Basecore.References;

namespace Training.Utilities.BaseCore.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class BlankCommand : Command
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void Execute(Sitecore.Shell.Framework.Commands.CommandContext context)
        {
            if (context.Items.Length == 1)
            {
                Sitecore.Data.Items.Item item = context.Items[0];

                System.Collections.Specialized.NameValueCollection parameters = new System.Collections.Specialized.NameValueCollection();

                parameters["id"] = item.ID.ToString();
                parameters["language"] = item.Language.ToString();
                parameters["database"] = item.Database.Name;

                Sitecore.Context.ClientPage.Start(this, "Run", parameters);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected void Run(Sitecore.Web.UI.Sheer.ClientPipelineArgs args)
        {
            if (args.IsPostBack)
            {
                if ((!String.IsNullOrEmpty(args.Result)) && args.Result != "undefined")
                {
                    Sitecore.Data.Database db = Sitecore.Configuration.Factory.GetDatabase(args.Parameters["database"]);
                    Sitecore.Data.Items.Item item = db.GetItem(args.Parameters["id"], Sitecore.Globalization.Language.Parse(args.Parameters["language"]));
                }
            }
        }
    }
}
