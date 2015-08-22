using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.Utilities.Basecore.References;
using Training.Utilities.BaseCore.JSON;

namespace Training.layouts.BaseCore
{
    public partial class BaseCore_JSON : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var item = Sitecore.Context.Item;

            if (item.TemplateID == TemplateReferences.Holiday)
            {
                var json = new JSONHoliday();

                json.PageHeading = FieldRenderer.Render(item, "Page Heading");
                json.PageContent = FieldRenderer.Render(item, "Page Content");

                ReferenceField difficulty = item.Fields["Difficulty"];

                json.DifficultyLabel = Sitecore.Globalization.Translate.Text("Difficulty");
                json.Difficulty = FieldRenderer.Render(difficulty.TargetItem, "Text");

                ReferenceField type = item.Fields["Type"];

                json.TypeLabel = Sitecore.Globalization.Translate.Text("Type");
                json.Type = FieldRenderer.Render(type.TargetItem, "Text");

                MultilistField terrain = item.Fields["Terrain"];

                json.TerrainLabel = Sitecore.Globalization.Translate.Text("Terrain");
                json.Terrain = string.Join(",", terrain.GetItems().Select(x => FieldRenderer.Render(x, "Text")));

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Response.Write(serializer.Serialize(json));
            }
        }
    }
}